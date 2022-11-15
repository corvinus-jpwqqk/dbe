using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dbe
{
    class Exercise
    {
        public string ExerciseTextHun { get; set; }
        public string ExerciseTextSQL { get; set; }
        private readonly SqlConnection con;
        private int checkCount = 0;
        readonly List<FunctionTemplate> templates;
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
            generateExercise();
        }

        private void generateExercise()
        {
            clearFields();
            // getSelectColumns(3);
            //whereBuilder(true);
            //this.ExerciseTextSQL += groupBy;
            buildSetOperation();
            checkExercise();
            //var f = functionBuilder(DataTypeCategory.String, 2);
            //this.exerciseTextHun = f.FunctionTextHun;
            //this.exerciseTextSQL = f.FunctionTextSQL;
        }

        private void clearFields()
        {
            this.ExerciseTextHun = "";
            this.ExerciseTextSQL = "";
            this.activeTables.Clear();
            this.usedColumns.Clear();
            this.groupBy = "";
        }

        public string getExerciseHun()
        {
            return this.ExerciseTextHun;
        }
        public string getExerciseSql()
        {
            return this.ExerciseTextSQL;
        }

        private void createSelect()
        {
            this.ExerciseTextSQL += "SELECT ";
            this.ExerciseTextHun += "Válaszd ki a(z) ";
            for (int i = 0; i < usedColumns.Count - 1; i++)
            {
                this.ExerciseTextSQL += usedColumns[i].fullName() + ", ";
                this.ExerciseTextHun += usedColumns[i].fullName() + ", ";
            }
            this.ExerciseTextSQL += usedColumns[usedColumns.Count - 1].fullName();
            this.ExerciseTextHun += usedColumns[usedColumns.Count - 1].fullName() + " oszlopokat";
        }

        public virtual void getSelectColumns(int tableCount)
        {
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
            createSelect();
            this.ExerciseTextHun += ", valamint a következőt: ";
            this.ExerciseTextSQL += ", ";
            Tuple<string, string> aggregateFunction = getAggregateFunction(ref usedColumns);
            this.ExerciseTextSQL += aggregateFunction.Item1;
            this.ExerciseTextHun += aggregateFunction.Item2 + ". ";
            getFrom();
        }

        private void getSelectColumns(List<DataTypeCategory> colReturnTypes)
        {
            this.usedColumns.Clear();
            this.activeTables.Clear();
            List<Column> eligibleColumns = new List<Column>();
            foreach(Table t in this.tables)
            {
                foreach(Column c in t.columns)
                {
                    if(c.DataType == colReturnTypes[0])
                    {
                        eligibleColumns.Add(c);
                    }
                }
            }
            var firstCol = eligibleColumns[rnd.Next(eligibleColumns.Count)];
            usedColumns.Add(firstCol);
            var firstTable = this.tables.Where(t => t.id == firstCol.TableID).ToList()[0];
            this.activeTables.Add(firstTable);
            for(int i = 1; i < colReturnTypes.Count; i++)
            {
                checkNeighbours(firstTable, colReturnTypes[i]);
            }
            createSelect();
            getFrom();
        }

        private bool checkNeighbours(Table origin, DataTypeCategory returnType)
        {
            foreach(var relation in origin.relations)
            {
                Table relatedTable = this.tables.Where(t => t.id == relation.Item2).ToList()[0];
                var eligibleColumns = relatedTable.columns.Where(c => c.DataType == returnType).ToList();
                if(eligibleColumns.Count > 0)
                {
                    var newCol = eligibleColumns[rnd.Next(eligibleColumns.Count)];
                    usedColumns.Add(newCol);
                    var newColTable = this.tables.Where(t => t.id == newCol.TableID).ToList()[0];
                    if (!activeTables.Contains(newColTable))
                    {
                        activeTables.Add(newColTable);
                    }
                    return true;
                }
            }
            foreach (var relation in origin.relations)
            {
                if(checkNeighbours(this.tables.Where(t => t.id == relation.Item2).ToList()[0], returnType))
                {
                    return true;
                }
            }
            return false;
        }
        
        private void getActiveTables(int tableCount)
        {
            if(this.activeTables.Count == 0)
            {
                this.activeTables.Add(this.tables[this.rnd.Next(this.tables.Count)]);
            }
            else
            {
                addRelatedTable();
            }
            if(tableCount == 1)
            {
                return;
            }
            else
            {
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
                        return;
                    }
                }
            }
        }

        private void buildSetOperation()
        {
            int type = rnd.Next(2);
            List<DataTypeCategory> columnTypes = new List<DataTypeCategory>();
            int colCount = rnd.Next(2, 5);
            for(int i = 0; i < colCount; i++)
            {
                columnTypes.Add(getRandomReturnType());
            }
            string connectHun;
            string connectSql;
            if (type == 0)
            {
                connectHun = "únióját";
                connectSql = "UNION";

            }
            else if(type == 1)
            {
                connectHun = "metszetét";
                connectSql = "INTERSECT";
            }
            else
            {
                connectHun = "különbségét";
                connectSql = "EXCEPT";
            }
            this.ExerciseTextHun += "Készítsd el a következő két lekérdezés " + connectHun + ": \n";
            getSelectColumns(columnTypes);
            whereBuilder(false);
            this.ExerciseTextHun += "\nvalamint \n";
            this.ExerciseTextSQL += "\n" + connectSql + "\n";
            getSelectColumns(columnTypes);
            //whereBuilder(false);
        }

        private DataTypeCategory getRandomReturnType()
        {
            int type = rnd.Next(2);
            if(type == 0)
            {
                return DataTypeCategory.String;
            }
            else if (type == 1)
            {
                return DataTypeCategory.Numeric;
            }
            else
            {
                return DataTypeCategory.Date;
            }
        }

        private void getFrom()
        {
            List<int> connected = new List<int>();
            string fromSql = "\nFROM " + activeTables[0].name;
            while(connected.Count < activeTables.Count)
            {
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
            }
            this.ExerciseTextSQL += fromSql;
        }

        private void whereBuilder(bool combine)
        {
            this.ExerciseTextSQL += "\nWHERE (";
            this.ExerciseTextHun += "\nSzűkítsd a lekérdezést a következőkre: ";
            int usedCol = getWhereClause(-1);
            this.ExerciseTextSQL += ") ";
            if (combine)
            {
                int type = rnd.Next(1);
                if(type == 1)
                {
                    this.ExerciseTextSQL += " AND (";
                    this.ExerciseTextHun += ", valamint ";
                }
                else
                {
                    this.ExerciseTextSQL += " OR (";
                    this.ExerciseTextHun += ", vagy ";
                }
                getWhereClause(usedCol);
                this.ExerciseTextSQL += ") ";
            }
        }

        public virtual int getWhereClause(int usedCol)
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
                List<Column> availableColumns = this.usedColumns.Where(c => c.ColID != usedCol).ToList();
                whereColumn = availableColumns[rnd.Next(availableColumns.Count)];
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
            return whereColumn.ColID;
        }

        private void getNumericWhere(ref Column whereColumn, double minValue, double maxValue)
        {
            Random rnd = new Random();
            int whereType = rnd.Next(3);
            if(whereType == 0)
            {
                int ltValue = rnd.Next((Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2, Convert.ToInt32(maxValue));
                this.ExerciseTextSQL += whereColumn.fullName() + "<" + ltValue.ToString();
                this.ExerciseTextHun += whereColumn.fullName() + " mező értéke kisebb, mint " + ltValue.ToString();
            }
            else if(whereType == 1)
            {
                int gtValue = rnd.Next(Convert.ToInt32(minValue), (Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2);
                this.ExerciseTextSQL += whereColumn.fullName() + ">" + gtValue.ToString();
                this.ExerciseTextHun += whereColumn.fullName() + " mező értéke nagyobb, mint " + gtValue.ToString();
            }
            else
            {
                int btMin = rnd.Next(Convert.ToInt32(minValue), (Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2);
                int btMax = rnd.Next((Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2, Convert.ToInt32(maxValue));
                this.ExerciseTextSQL += whereColumn.fullName() + " BETWEEN " + btMin + " AND " + btMax;
                this.ExerciseTextHun += whereColumn.fullName() + " mező értéke " + btMin.ToString() + " és " + btMax.ToString() + " közé esik";
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
                this.ExerciseTextSQL += whereColumn.fullName() + "<'" + ltValue.ToString("yyyy-MM-dd") + "'";
                this.ExerciseTextHun += whereColumn.fullName() + " mező értéke kisebb, mint " + ltValue.ToString("yyyy. MM. dd");
            }
            else if (whereType == 1)
            {
                DateTime gtValue = minDate.AddDays(rnd.Next(range/2));
                this.ExerciseTextSQL += whereColumn.fullName() + ">'" + gtValue.ToString("yyyy-MM-dd") + "'";
                this.ExerciseTextHun += whereColumn.fullName() + " mező értéke nagyobb, mint " + gtValue.ToString("yyyy. MM. dd");
            }
            else
            {
                DateTime btMin = minDate.AddDays(Convert.ToInt32(range/4));
                DateTime btMax = minDate.AddDays(Convert.ToInt32(range/2) + Convert.ToInt32(range / 4));
                this.ExerciseTextSQL += whereColumn.fullName() + " BETWEEN '" + btMin.ToString("yyyy-MM-dd") + "' AND '" + btMax.ToString("yyyy-MM-dd") + "'";
                this.ExerciseTextHun += whereColumn.fullName() + " mező értéke a " + btMin.ToString("yyyy. MM. dd") + " és " + btMax.ToString("yyyy. MM. dd") + " közé esik";
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
                this.ExerciseTextSQL += whereColumn.fullName() + " LIKE '" + startsWith + "%'";
                this.ExerciseTextHun += whereColumn.fullName() + " mező így kezdődik: '" + startsWith + "'";
            }
            else if(whereType == 1)
            {
                //like...
            }
        }
        private void checkExercise()
        {
            if (checkCount > 5)
            {
                MessageBox.Show("Could not generate exercise");
            }
            else
            {
                this.checkCount++;
                Console.WriteLine("Checking sql: " + this.ExerciseTextSQL);
                SqlCommand cmd = new SqlCommand(this.ExerciseTextSQL, con);
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
                            f.buildParam(param, p);
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
            List<Column> eligibleColumns = new List<Column>();
            foreach(Table t in this.tables)
            {
                foreach(Column c in t.columns)
                {
                    if(c.DataType == returnType) { eligibleColumns.Add(c); }
                }
            }
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
        private void getOrderBy()
        {
            this.ExerciseTextSQL += "\nORDER BY ";
            this.ExerciseTextHun += "Rendezd az eredményt ";
            var obCol = this.usedColumns[rnd.Next(this.usedColumns.Count)];
            this.ExerciseTextSQL += obCol.fullName();
            var direction = rnd.Next(1);
            if(direction == 0)
            {
                this.ExerciseTextSQL += " ASC ";
                this.ExerciseTextHun += "növekvő ";
            }
            else
            {
                this.ExerciseTextSQL += " DESC ";
                this.ExerciseTextHun += "csökkenő ";
            }
            this.ExerciseTextHun += "sorrendbe a(z) " + obCol.fullName() + " oszlop szerint!";
        }

        
    }
}

