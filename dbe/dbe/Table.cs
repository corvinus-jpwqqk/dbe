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
        private int id;
        private string name;
        private List<Column> columns;

        public Table(int id_, string name_)
        {
            this.name = name_;
            this.id = id_;
            this.columns = new List<Column>();
        }

        public void fetchColumns(ref SqlConnection con)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT name, max_length, system_type_id FROM sys.columns WHERE object_id = " + this.id, con);
                using (IDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        this.columns.Add(new Column(rdr[0].ToString(), Convert.ToInt32(rdr[2]), Convert.ToInt32(rdr[1])));
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
        public string Name
        {
            get { return this.name; }
        }
        public List<Column> Columns
        {
            get { return this.columns; }
        }
    }
}