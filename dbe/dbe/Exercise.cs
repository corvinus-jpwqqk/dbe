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
        private Table currentTable;
        private List<Column> currentColumns;
        SqlConnection con;
        private int checkCount = 0;

        public Exercise(ref List<Table> tables, ref SqlConnection con)
        {
            this.con = con;
            Random rnd = new Random();
            currentTable = tables[rnd.Next(tables.Count)];
            currentColumns = new List<Column>();
            generateExercise();
        }

        private void generateExercise()
        {
            getSelects();
            getWhereClause();
            checkExercise();
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
            Random rnd = new Random();
            int colCount = 0;
            while(colCount == 0)
            {
                foreach (Column column in currentTable.Columns)
                {
                    if (rnd.Next(2) == 1)
                    {
                        currentColumns.Add(column);
                        colCount++;
                    }
                }
            }
            if(currentColumns.Count == currentTable.Columns.Count)
            {
                this.exerciseTextSQL = "SELECT * FROM " + currentTable.Name;
                this.exerciseTextHun = "Válaszd ki a " + currentTable.Name + " tábla összes oszlopát ";
            }
            else
            {
                this.exerciseTextSQL = "SELECT ";
                this.exerciseTextHun = "Válaszd ki a " + currentTable.Name + " tábla ";
                for (int i = 0; i < this.currentColumns.Count-1; i++)
                {
                    this.exerciseTextHun += this.currentColumns[i].Name + ", ";
                    this.exerciseTextSQL += this.currentColumns[i].Name + ", ";
                }
                this.exerciseTextHun += this.currentColumns[currentColumns.Count - 1].Name + " ";
                this.exerciseTextSQL += this.currentColumns[currentColumns.Count - 1].Name + " ";
                this.exerciseTextSQL += "FROM " + currentTable.Name;
                this.exerciseTextHun += "oszlopait";
            }
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
                    if (whereColumn.DtCat == DataTypeCategory.Unhandled) continue;
                    else if(whereColumn.DtCat == DataTypeCategory.Date 
                         || whereColumn.DtCat == DataTypeCategory.Numeric)
                    {
                        cmd = new SqlCommand("SELECT MIN(" + whereColumn.Name + "), MAX(" + whereColumn.Name + ") FROM " + currentTable.Name, con);
                        using (IDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                if(whereColumn.DtCat == DataTypeCategory.Numeric)
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
            if(whereColumn.DtCat == DataTypeCategory.Numeric)
            {
                getNumericWhere(ref whereColumn, minValue, maxValue);
            }
            else if(whereColumn.DtCat == DataTypeCategory.Date)
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
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 LEFT(" + whereColumn.Name + ", 1), COUNT(*) FROM " + currentTable.Name 
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
                MessageBox.Show("Could not generate exercise from table: " + this.currentTable.Name);
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
    }
}
