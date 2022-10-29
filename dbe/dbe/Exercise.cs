﻿using System;
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
        private Table currentTable;
        private List<Column> currentColumns;
        SqlConnection con;
        private int checkCount = 0;
        List<string> functionBuilderContent;
        List<FunctionTemplate> templates;
        private List<Column> columns = new List<Column>();
        Random rnd = new Random();
        List<Table> tables; 
        List<Table> usedTables = new List<Table>(); // use only table id for used tables


        public Exercise(ref List<Table> tables, ref SqlConnection con, ref List<FunctionTemplate> templates)
        {
            this.con = con;
            currentTable = tables[rnd.Next(tables.Count)];
            this.tables = tables;
            currentColumns = new List<Column>();
            this.templates = templates;
            functionBuilderContent = new List<string>();
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
            //getSelects();
            //getWhereClause();
            //checkExercise();
            var f = functionBuilder(DataTypeCategory.String, 2);
            this.exerciseTextHun = f.FunctionTextHun;
            this.exerciseTextSQL = f.FunctionTextSql;
        }

        public string getExerciseHun()
        {
            return this.exerciseTextHun;
        }
        public string getExerciseSql()
        {
            return this.exerciseTextSQL;
        }

        public virtual void getSelects()
        {
            this.exerciseTextSQL += "SELECT ";
            this.exerciseTextHun += "Válaszd ki a(z) ";
            List<string> usedColumns = new List<string>();
            foreach(Table table in this.tables)
            {
                foreach(Column col in table.columns)
                {
                    if(rnd.Next(2) == 1)
                    {
                        usedColumns.Add(table.name + "." + col.Name);
                        this.currentColumns.Add(col);
                        this.usedTables.Add(this.tables.Where(t => t.id == col.TableID).ToList()[0]);
                    }
                }
            }
            for (int i = 0; i < currentColumns.Count-1; i++)
            {
                this.exerciseTextSQL += usedColumns[i] + ", ";
                this.exerciseTextHun += usedColumns[i] + ", ";
            }
            this.exerciseTextSQL += usedColumns[usedColumns.Count-1] + " ";
            this.exerciseTextHun += usedColumns[usedColumns.Count - 1] + " oszlopokat";

            getFrom();
        }

        private void getFrom()
        {
            List<int> connected = new List<int>();
            string fromSql = "FROM " + usedTables[0].name + "\n";
            foreach(Table table in this.usedTables)
            {
                foreach(var relation in table.relations)
                {
                    if (usedTables.Where(t => t.id == relation.Item2).ToList().Count > 0 && !connected.Contains(relation.Item2))
                    {
                        Table relatedTable = usedTables.Where(t => t.id == relation.Item2).ToList()[0];
                        Column relatedColumn = relatedTable.columns.Where(c => c.colId == relation.Item3).ToList()[0];
                        Column currentColumn = table.columns.Where(c => c.colId == relation.Item1).ToList()[0];
                        fromSql += "JOIN " + relatedTable.name + " ON " + table.name + "." + currentColumn.Name + " = " + relatedTable.name + "." + relatedColumn.Name + " \n";
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
                whereColumn = this.currentColumns[rnd.Next(currentColumns.Count)];
                SqlCommand cmd;
                try
                {
                    if (whereColumn.DTC == DataTypeCategory.Unhandled) continue;
                    else if(whereColumn.DTC == DataTypeCategory.Date 
                         || whereColumn.DTC == DataTypeCategory.Numeric)
                    {
                        cmd = new SqlCommand("SELECT MIN(" + whereColumn.Name + "), MAX(" + whereColumn.Name + ") FROM " + currentTable.name, con);
                        using (IDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                if(whereColumn.DTC == DataTypeCategory.Numeric)
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
            if(whereColumn.DTC == DataTypeCategory.Numeric)
            {
                getNumericWhere(ref whereColumn, minValue, maxValue);
            }
            else if(whereColumn.DTC == DataTypeCategory.Date)
            {
                getDateWhere(ref whereColumn, minDate, maxDate);
            }
            else
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
                this.exerciseTextSQL += " WHERE " + whereColumn.Name + "<" + ltValue.ToString();
                this.exerciseTextHun += ", ahol a " + whereColumn.Name + " mező értéke kisebb, mint " + ltValue.ToString();
            }
            else if(whereType == 1)
            {
                int gtValue = rnd.Next(Convert.ToInt32(minValue), (Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2);
                this.exerciseTextSQL += " WHERE " + whereColumn.Name + ">" + gtValue.ToString();
                this.exerciseTextHun += ", ahol a " + whereColumn.Name + " mező értéke nagyobb, mint " + gtValue.ToString();
            }
            else
            {
                int btMin = rnd.Next(Convert.ToInt32(minValue), (Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2);
                int btMax = rnd.Next((Convert.ToInt32(minValue) + Convert.ToInt32(maxValue)) / 2, Convert.ToInt32(maxValue));
                this.exerciseTextSQL += " WHERE " + whereColumn.Name + " BETWEEN " + minValue + " AND " + maxValue;
                this.exerciseTextHun += ", ahol a " + whereColumn.Name + " mező értéke " + minValue.ToString() + " és " + maxValue.ToString() + " közé esik ";
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
                this.exerciseTextSQL += " WHERE " + whereColumn.Name + "<'" + ltValue.ToString("yyyy-MM-dd") + "'";
                this.exerciseTextHun += ", ahol a " + whereColumn.Name + " mező értéke kisebb, mint " + ltValue.ToString("yyyy. MM. dd");
            }
            else if (whereType == 1)
            {
                DateTime gtValue = minDate.AddDays(rnd.Next(range/2));
                this.exerciseTextSQL += " WHERE " + whereColumn.Name + ">'" + gtValue.ToString("yyyy-MM-dd") + "'";
                this.exerciseTextHun += ", ahol a " + whereColumn.Name + " mező értéke nagyobb, mint " + gtValue.ToString("yyyy. MM. dd");
            }
            else
            {
                DateTime btMin = minDate.AddDays(Convert.ToInt32(range/4));
                DateTime btMax = minDate.AddDays(Convert.ToInt32(range/2) + Convert.ToInt32(range / 4));
                this.exerciseTextSQL += " WHERE " + whereColumn.Name + " BETWEEN '" + btMin.ToString("yyyy-MM-dd") + "' AND '" + btMax.ToString("yyyy-MM-dd") + "'";
                this.exerciseTextHun += ", ahol a " + whereColumn.Name + " mező értéke a " + btMin.ToString("yyyy. MM. dd") + " és " + btMax.ToString("yyyy. MM. dd") + " közé esik ";
            }
        }
        private void getStringWhere(ref Column whereColumn)
        {
            Random rnd = new Random();
            int whereType = 0; //rnd.Next(3);
            if(whereType == 0)
            {
                string startsWith = "";
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 LEFT(" + whereColumn.Name + ", 1), COUNT(*) FROM " + currentTable.name
                               + "GROUP BY LEFT(" + whereColumn.Name + ", 1) ORDER BY COUNT(*) DESC", con);
                try
                {
                    using (IDataReader rdr = cmd.ExecuteReader())
                    {
                        startsWith = rdr[0].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when getting where for string type / startswith cmd: " + ex.Message);
                    return;
                }
                this.exerciseTextSQL += " WHERE " + whereColumn.Name + " LIKE '" + startsWith + "%'";
                this.exerciseTextHun += ", ahol a " + whereColumn.Name + " mező így kezdődik: '" + startsWith + "'";
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
                MessageBox.Show("Could not generate exercise from table: " + this.currentTable.name);
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
                var eligibleFunctionTemplates = templates.Where(t => t.returnType == returnType).ToList();
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
            var eligibleColumns = columns.Where(c => c.DTC == returnType).ToList();
            var usedColumn = eligibleColumns[rnd.Next(eligibleColumns.Count)];
            var usedTable = this.tables.Where(t => t.id == usedColumn.TableID).ToList()[0];
            usedTables.Add(usedTable);
            f = new Function(usedColumn.TableName + "." + usedColumn.Name);
            return f;
        }
    }
}

