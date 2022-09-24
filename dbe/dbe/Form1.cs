using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbe
{
    enum DataTypeCategory
    {
        Numeric,
        String,
        Date,
        Unhandled
    }
    public partial class Form1 : Form
    {
        string connectionString;
        List<Table> tables = new List<Table>();
        SqlConnection con;
        SqlCommand cmd;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void setupForm()
        {
            con = new SqlConnection(this.connectionString);
            con.Open();
            getTables();
            getSystemTypes();
            fillDgv();
        }
        protected override void OnLoad(EventArgs e)
        {
            using (LoginForm f = new LoginForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    this.connectionString = f.connString;
                    Console.WriteLine("Received ConnectionString: " + connectionString);
                    setupForm();
                }
                else
                {
                    Application.Exit();
                }
            }
            base.OnLoad(e);
        }
        private void getTables()
        {
            cmd = new SqlCommand("SELECT object_id, name FROM sys.tables WHERE name <> 'sysdiagrams'", con);
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    this.tables.Add(new Table(Convert.ToInt32(rdr[0]), rdr[1].ToString()));
                }
            }
            foreach(Table table in this.tables)
            {
                table.fetchColumns(ref con);
            }
            lbTbl.DataSource = this.tables;
            lbTbl.DisplayMember = "Name";
        }
        
        private void getSystemTypes()
        {
            foreach (Table table in this.tables)
            {
                table.getDataTypeNames(ref con);
            }
        }
        private void fillDgv()
        {
            string tableName = ((Table)(this.lbTbl.SelectedItem)).Name;
            

            foreach (Table table in this.tables)
            {
                if (table.Name == tableName)
                {
                    dgvPos.DataSource = table.Columns;
                }
            }
        }

        private void lbTbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //testStuff();
            Exercise ex1 = new Exercise(ref this.tables, ref this.con);
            txtHun.Text = ex1.getExerciseHun();
            txtSql.Text = ex1.getExerciseSql();
        }
        private void testStuff()
        {
            cmd = new SqlCommand("select MIN(ROGZ_IDO) from szallashely", con);
            DateTime stuff = new DateTime();
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    stuff = Convert.ToDateTime(rdr[0]);
                }
            }
            MessageBox.Show("Date: " + stuff);
        }
    }
}
