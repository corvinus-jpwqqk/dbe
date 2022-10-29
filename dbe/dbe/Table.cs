using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbe
{
    class Table
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<Column> columns { get; set; }
        public List<Tuple<int, int, int>> relations { get; set; }

        public Table(int id_, string name_)
        {
            this.name = name_;
            this.id = id_;
            this.columns = new List<Column>();
            this.relations = new List<Tuple<int, int, int>>();
        }

        public void fetchColumns(ref SqlConnection con)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT name, max_length, system_type_id, column_id FROM sys.columns WHERE object_id = " + this.id, con);
                using (IDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        this.columns.Add(new Column(rdr[0].ToString(), Convert.ToInt32(rdr[2]), Convert.ToInt32(rdr[1]), this.name, this.id, Convert.ToInt32(rdr[3])));
                        Console.WriteLine("To table: " + this.name + ", added new Column: " + rdr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching table columns: " + ex.Message);
                return;
            }
        }

        private void getFunctions()
        {

        }

        public void getRelationSheeps(ref SqlConnection con)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT parent_column_id, referenced_object_id, referenced_column_id FROM sys.foreign_key_columns WHERE parent_object_id=" + this.id, con);
                using (IDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int pColId = Convert.ToInt32(rdr[0]);
                        int rTableId = Convert.ToInt32(rdr[1]);
                        int rColId = Convert.ToInt32(rdr[2]);
                        this.relations.Add(new Tuple<int, int, int>(pColId, rTableId, rColId));
                    }
                }
                cmd = new SqlCommand("SELECT referenced_column_id, parent_column_id, parent_object_id FROM sys.foreign_key_columns WHERE referenced_object_id=" + this.id, con);
                using (IDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        int rColId = Convert.ToInt32(rdr[0]);
                        int pTableId = Convert.ToInt32(rdr[1]);
                        int pColId = Convert.ToInt32(rdr[2]);
                        this.relations.Add(new Tuple<int, int, int>(rColId, pTableId, pColId)); 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching column type name: " + ex.Message);
                return;
            }
        }

        public void getDataTypeNames(ref SqlConnection con)
        {
            foreach (Column column in this.columns)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT name FROM sys.types WHERE system_type_id= " + column.getDataType(), con);
                    using (IDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            column.setDataTypeName(rdr[0].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while fetching column type name: " + ex.Message);
                    return;
                }
            }
        }
    }
}