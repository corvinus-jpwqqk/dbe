using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbe
{
    class Exercise
    {
        private string exerciseTextHun = "";
        private string exerciseTextSQL = "";
        readonly SqlConnection con;
        private int checkCount = 0;
        readonly List<FunctionTemplate> templates;
        private readonly List<Column> columns = new List<Column>();
        readonly Random rnd = new Random();
        readonly List<Table> tables;
        List<Column> usedColumns = new List<Column>();
        List<Table> activeTables = new List<Table>();
        string groupBy = "";

        public Exercise(ref List<Table> tables, ref SqlConnection con, ref List<FunctionTemplate> templates)
        {
            this.con = con;
            this.tables = tables;
            this.templates = templates;
            foreach(Table table in tables)
            {
                foreach(Column col in table.columns)
                {
                    this.columns.Add(col);
                }
            }
            generateExercise();
        }

        private void generateExercise()
        {
            getSelects(3);
            getWhereClause();
            this.exerciseTextSQL += groupBy;
            checkExercise();
            //var f = functionBuilder(DataTypeCategory.String, 2);
            //this.exerciseTextHun = f.FunctionTextHun;
            //this.exerciseTextSQL = f.FunctionTextSQL;
        }

        public string getExerciseHun()
        {
            return this.exerciseTextHun;
        }
        public string getExerciseSql()
        {
            return this.exerciseTextSQL;
        }

        public virtual void getSelects(int tableCount)
        {
            this.exerciseTextSQL += "SELECT ";
            this.exerciseTextHun += "Válaszd ki a(z) ";
            int max = 4;
            getActiveTables(tableCount);
            foreach(Table table in this.activeTables)
            {
                foreach(Column col in table.columns)
                {
                    if(rnd.Next(2) == 1 && max > 0)
                    {
                        this.usedColumns.Add(col);
                        max -= 1;
                    }
                }
            }
            for (int i = 0; i < usedColumns.Count-1; i++)
            {
                this.exerciseTextSQL += usedColumns[i].fullName() + ", ";
                this.exerciseTextHun += usedColumns[i].fullName() + ", ";
            }
            this.exerciseTextSQL += usedColumns[usedColumns.Count - 1].fullName();
            this.exerciseTextHun += usedColumns[usedColumns.Count - 1].fullName() + " oszlopokat";
            this.exerciseTextHun += ", valamint a következőt: ";
            this.exerciseTextSQL += ", ";
            Tuple<string, string> aggregateFunction = getAggregateFunction(ref usedColumns);
            this.exerciseTextSQL += aggregateFunction.Item1;
            this.exerciseTextHun += aggregateFunction.Item2;
            getFrom();
        }

        private void getActiveTables(int tableCount)
        {
            Console.WriteLine("GetActiveTables called");
            if(this.activeTables.Count == 0)
            {
                this.activeTables.Add(this.tables[this.rnd.Next(this.tables.Count)]);
                Console.WriteLine("Added random table to empty list");
            }
            else
            {
                Console.WriteLine("Calling AddRelatedTable");
                addRelatedTable();
            }
            if(tableCount == 1)
            {
                Console.WriteLine("tc is 1, returning");
                return;
            }
            else
            {
                Console.WriteLine("tc is not 1, calling GetActiveTables with " + (tableCount-1).ToString());
                getActiveTables(tableCount - 1);
            }
        }

        private void addRelatedTable()
        {
            List<int> addedTables = new List<int>();
            foreach(Table t in this.activeTables)
            {
                addedTables.Add(t.id);
            }
            foreach(Table t in this.activeTables)
            {
                foreach(var relation in t.relations)
                {
                    if (!addedTables.Contains(relation.Item2))
                    {
                        var addTable = this.tables.Where(tbl => tbl.id == relation.Item2).ToList()[0];
                        this.activeTables.Add(addTable);
                        Console.WriteLine("Added table" + addTable.name);
                        return;
                    }
                }
            }
        }

        private void getFrom()
        {
            List<int> connected = new List<int>();
            string fromSql = "\nFROM " + activeTables[0].name;
            foreach (Table table in this.activeTables)
            {
                foreach (var relation in table.relations)
                {
                    if (activeTables.Where(t => t.id == relation.Item2).ToList().Count > 0 && !connected.Contains(relation.Item2))
                    {
                        Table relatedTable = activeTables.Where(t => t.id == relation.Item2).ToList()[0];
                        Column relatedColumn = relatedTable.columns.Where(c => c.ColID == relation.Item3).ToList()[0];
                        Column currentColumn = table.columns.Where(c => c.ColID == relation.Item1).ToList()[0];
                        fromSql += "\nJOIN " + relatedTable.name + " ON " + table.name + "." + currentColumn.Name + " = " + relatedTable.name + "." + relatedColumn.Name;
                        connected.Add(table.id);
                        connected.Add(relatedTable.id);
                    }
                }
            }
            this.exerciseTextSQL += fromSql;
        }
        public virtual void getWhereClause()
        {
            Random rnd = new Random();
            bool success = false;
            double minValue = 0;
            double maxValue = 0;
            DateTime minDate = new DateTime();
            DateTime maxDate = new DateTime();
            Column whereColumn = new Column();

            while (!success)
            {
                whereColumn = this.usedColumns[rnd.Next(usedColumns.Count)];
                SqlCommand cmd;
                try
                {
                    if (whereColumn.DataType == DataTypeCategory.Unhandled) continue;
                    else if(whereColumn.DataType == DataTypeCategory.Date 
                         || whereColumn.DataType == DataTypeCategory.Numeric)
                    {
                        cmd = new SqlCommand("SELECT MIN(" + whereColumn.Name + "), MAX(" + whereColumn.Name + ") FROM " + whereColumn.TableName, con);
                        using (IDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                if(whereColumn.DataType == DataTypeCategory.Numeric)
                                {
                                    minValue = Convert.ToDouble(rdr[0]);
                                    maxValue = Convert.ToDouble(rdr[1]);
                                }
                                else
                                {
                                    minDate = Convert.ToDateTime(rdr[0]);
                                    maxDate = Convert.ToDateTime(rdr[1]);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error in getting whereColumn: " + ex.Message);
                    continue;
                }
                success = true;
            }
            if(whereColumn.DataType == DataTypeCategory.Numeric)
            {
                getNumericWhere(ref whereColumn, minValue, maxValue);
            }
            else if(whereColumn.DataType == DataTypeCategory.Date)
            {
                getDateWhere(ref whereColumn, minDate, maxDate);
            }
            else if(whereColumn.DataType == DataTypeCategory.String)
            {
                getStringWhere(ref whereColumn);
            }
        }

        private void getNumericWhere(ref Column whereColumn, double minValue, double maxValue)
        {
            Random rnd = new Random();
            int whereType = rnd.Next(3);
            if(whereType == 0)
            {
                int ltValue = rnd.Next((Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2, Convert.ToInt32(maxValue));
                this.exerciseTextSQL += "\nWHERE " + whereColumn.fullName() + "<" + ltValue.ToString() + " ";
                this.exerciseTextHun += ", ahol a " + whereColumn.fullName() + " mező értéke kisebb, mint " + ltValue.ToString();
            }
            else if(whereType == 1)
            {
                int gtValue = rnd.Next(Convert.ToInt32(minValue), (Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2);
                this.exerciseTextSQL += "\nWHERE " + whereColumn.fullName() + ">" + gtValue.ToString() + " ";
                this.exerciseTextHun += ", ahol a " + whereColumn.fullName() + " mező értéke nagyobb, mint " + gtValue.ToString();
            }
            else
            {
                int btMin = rnd.Next(Convert.ToInt32(minValue), (Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2);
                int btMax = rnd.Next((Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2, Convert.ToInt32(maxValue));
                this.exerciseTextSQL += "\nWHERE " + whereColumn.fullName() + " BETWEEN " + btMin + " AND " + btMax + " ";
                this.exerciseTextHun += ", ahol a " + whereColumn.fullName() + " mező értéke " + btMin.ToString() + " és " + btMax.ToString() + " közé esik ";
            }
        }
        private void getDateWhere(ref Column whereColumn, DateTime minDate, DateTime maxDate)
        {
            int range = (maxDate - minDate).Days;
            Random rnd = new Random();
            int whereType = rnd.Next(3);
            if (whereType == 0)
            {
                DateTime ltValue = minDate.AddDays(range/2 + rnd.Next(range/2));
                this.exerciseTextSQL += "\nWHERE " + whereColumn.fullName() + "<'" + ltValue.ToString("yyyy-MM-dd") + "' ";
                this.exerciseTextHun += ", ahol a " + whereColumn.fullName() + " mező értéke kisebb, mint " + ltValue.ToString("yyyy. MM. dd");
            }
            else if (whereType == 1)
            {
                DateTime gtValue = minDate.AddDays(rnd.Next(range/2));
                this.exerciseTextSQL += "\nWHERE " + whereColumn.fullName() + ">'" + gtValue.ToString("yyyy-MM-dd") + "' ";
                this.exerciseTextHun += ", ahol a " + whereColumn.fullName() + " mező értéke nagyobb, mint " + gtValue.ToString("yyyy. MM. dd");
            }
            else
            {
                DateTime btMin = minDate.AddDays(Convert.ToInt32(range/4));
                DateTime btMax = minDate.AddDays(Convert.ToInt32(range/2) + Convert.ToInt32(range / 4));
                this.exerciseTextSQL += "\nWHERE " + whereColumn.fullName() + " BETWEEN '" + btMin.ToString("yyyy-MM-dd") + "' AND '" + btMax.ToString("yyyy-MM-dd") + "' ";
                this.exerciseTextHun += ", ahol a " + whereColumn.fullName() + " mező értéke a " + btMin.ToString("yyyy. MM. dd") + " és " + btMax.ToString("yyyy. MM. dd") + " közé esik ";
            }
        }
        private void getStringWhere(ref Column whereColumn)
        {
            int whereType = 0; //rnd.Next(3);
            if(whereType == 0)
            {
                string startsWith = "";
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 LEFT(" + whereColumn.Name + ", 1), COUNT(*) FROM " + whereColumn.TableName
                               + " GROUP BY LEFT(" + whereColumn.Name + ", 1) ORDER BY COUNT(*) DESC ", con);
                try
                {
                    using (IDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            startsWith = rdr[0].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when getting where for string type / startswith cmd: " + ex.Message);
                    return;
                }
                this.exerciseTextSQL += "\nWHERE " + whereColumn.fullName() + " LIKE '" + startsWith + "%' ";
                this.exerciseTextHun += ", ahol a " + whereColumn.fullName() + " mező így kezdődik: '" + startsWith + "' ";
            }
            else if(whereType == 1)
            {
                //like...
            }
        }
        private void checkExercise()
        {
            if(checkCount > 3)
            {
                MessageBox.Show("Could not generate exercise");
            }
            else
            {
                this.checkCount++;
                Console.WriteLine("Checking sql: " + this.exerciseTextSQL);
                SqlCommand cmd = new SqlCommand(this.exerciseTextSQL, con);
                int lineCount = 0;
                using (IDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        lineCount++;
                    }
                }
                if (lineCount == 0)
                {
                    Console.WriteLine("Checking failed, retrying ");
                    generateExercise();
                }
                Console.WriteLine("Checking successful, line count: " + lineCount.ToString());
            }
        }
        private Function functionBuilder(DataTypeCategory returnType, int depth)
        {
            Function f;
            if(depth > 0)
            {
                var eligibleFunctionTemplates = templates.Where(t => t.ReturnType == returnType).ToList();
                if(eligibleFunctionTemplates.Count > 0)
                {
                    f = new Function(eligibleFunctionTemplates[rnd.Next(eligibleFunctionTemplates.Count)]);
                    foreach (FunctionParameter param in f.Parameters)
                    {
                        if(param.ParamType == ParamType.Column)
                        {
                            var p = functionBuilder(param.DataType, depth - 1);
                            //MessageBox.Show("created function for: " + p.FunctionTextSql + " , calling buildParam");
                            f.buildParam(param, p);
                            //MessageBox.Show("called buildparam for: " + p.FunctionTextSql + ", here: " + f.FunctionTextSql);
                        }
                        else if(param.ParamType == ParamType.Random) 
                        {
                            var p = new Function(rnd.Next(1,5).ToString());
                            f.buildParam(param, p);
                        }
                    }
                    return f;
                }
            }
            var eligibleColumns = columns.Where(c => c.DataType == returnType).ToList();
            var usedColumn = eligibleColumns[rnd.Next(eligibleColumns.Count)];
            f = new Function(usedColumn.fullName());
            return f;
        }
        
        private Tuple<string, string> getAggregateFunction(ref List<Column> usedColumns)
        {
            List<Column> availableColumns = new List<Column>();
            foreach(Table t in this.activeTables)
            {
                foreach(Column c in t.columns)
                {
                    availableColumns.Add(c);
                }
            }
            var currentColumn = availableColumns[rnd.Next(availableColumns.Count)];
            List<Tuple<string, string>> aggregateFunctions = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("COUNT(DISTINCT ", " különböző értékeinek darabszáma "),
                new Tuple<string, string>("COUNT(", " értékeinek darabszáma ")
            };
            if (currentColumn.DataType == DataTypeCategory.Numeric)
            {
                aggregateFunctions.Add(new Tuple<string, string>("SUM(", " értékeinek összege "));
                aggregateFunctions.Add(new Tuple<string, string>("AVG(", " értékeinek átlaga "));
                aggregateFunctions.Add(new Tuple<string, string>("MAX(", " értékeinek maximuma "));
                aggregateFunctions.Add(new Tuple<string, string>("MIN(", " értékeinek minimuma "));
            }
            var currentFunction = aggregateFunctions[rnd.Next(aggregateFunctions.Count)];
            this.groupBy += "\nGROUP BY " + usedColumns[0].fullName();
            string sql = currentFunction.Item1 + currentColumn.fullName() + ") ";
            string hun = currentColumn.fullName() + currentFunction.Item2 + ", " + usedColumns[0].fullName() + ' ';

            for (int i = 1; i < usedColumns.Count; i++)
            {
                hun += ", majd " + usedColumns[i].fullName();
                this.groupBy += ", " + usedColumns[i].fullName();
            }
            hun += " alapján csoportosítva";
            return new Tuple<string, string>(sql, hun);
        }
    }
}

