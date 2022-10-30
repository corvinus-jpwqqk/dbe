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
    enum ParamType
    {
        Column,
        Random
    }
    public partial class Form1 : Form
    {
        string connectionString;
        List<Table> tables = new List<Table>();
        SqlConnection con;
        SqlCommand cmd;
        List<FunctionTemplate> templates = new List<FunctionTemplate>();

        public Form1()
        {
            InitializeComponent();
        }

        private void setupForm()
        {
            con = new SqlConnection(this.connectionString);
            con.Open();
            getTables();
            getFunctionTemplates();
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
            foreach (Table table in this.tables)
            {
                table.fetchColumns(ref con);
                table.getRelationSheeps(ref con);
            }
            lbTbl.DataSource = this.tables;
            lbTbl.DisplayMember = "Name";
            //fetchColumns(ref con);
        }
        private void fillDgv()
        {
            string tableName = ((Table)(this.lbTbl.SelectedItem)).name;


            foreach (Table table in this.tables)
            {
                if (table.name == tableName)
                {
                    dgvPos.DataSource = table.columns;
                }
            }
        }

        private void lbTbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exercise ex1 = new Exercise(ref this.tables, ref this.con, ref this.templates);
            txtHun.Text = ex1.getExerciseHun();
            txtSql.Text = ex1.getExerciseSql().Replace("\n", Environment.NewLine);

            var select = ex1.getExerciseSql();
            var dataAdapter = new SqlDataAdapter(select, this.con);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvPos.ReadOnly = true;
            dgvPos.DataSource = ds.Tables[0];

        }
        private void getFunctionTemplates()
        {
            this.templates.Add(new FunctionTemplate(DataTypeCategory.String, "LEFT([String s col], [Numeric n rnd])", "[s] első [n] karaktere"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.String, "RIGHT([String s col], [Numeric n rnd])", "[s] utolsó [n] karaktere"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.Numeric, "POWER([Numeric n1 col], [Numeric n2 rnd])", "[n1] a(z) [n2] hatványra emelve"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.Numeric, "ABS([Numeric n col])", "[n] anszolútértéke"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.Numeric, "LEN([String s col])", "[s] karaktereinek száma"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.String, "LOWER([String s col])", "[s] kisbetűssé alakítva"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.String, "UPPER([String s col])", "[s] nagybetűssé alakítva"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.String, "CAST([Date d col] AS varchar)", "[d] szöveggé konvertálva"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.String, "CAST([Numeric n col] AS varchar)", "[n] szöveggé konvertálva"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.Date, "GETDATE()", "a mai dátum"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.Numeric, "YEAR([Date d col])", "[d] évszáma"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.Numeric, "MONTH([Date d col])", "[d] hónapszáma"));
            this.templates.Add(new FunctionTemplate(DataTypeCategory.Numeric, "DAY([Date d col])", "[d] napszáma"));
            // this.templates.Add(new FunctionTemplate(DataTypeCategory.String, "CAST([Numeric n] AS varchar)", "[n] szöveggé konvertálva"));
        }
    }
}
