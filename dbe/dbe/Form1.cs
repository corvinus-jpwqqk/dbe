using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbe
{
    public partial class Form1 : Form
    {
        string connectionString;
        List<string> tables = new List<string>();
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
            cmd = new SqlCommand("SELECT name FROM sys.tables WHERE name <> 'sysdiagrams'", con);
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    this.tables.Add(rdr[0].ToString());
                }
            }
            lbTbl.DataSource = this.tables;
        }
    }
}
