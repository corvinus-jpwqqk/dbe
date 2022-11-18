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
using System.Xml;

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
        List<Exercise> generatedExercises = new List<Exercise>();
        int exerciseNumber = 0;

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
            List<Tuple<string, string, string>> descriptions = new List<Tuple<string, string, string>>();
            cmd = new SqlCommand("SELECT st.name, sc.name, sep.value " +
                "                 FROM sys.tables st " +
                "                 INNER JOIN sys.columns sc ON st.object_id = sc.object_id" +
                "                 LEFT JOIN sys.extended_properties sep ON st.object_id = sep.major_id" +
                "                                                      AND sc.column_id = sep.minor_id" +
                "                                                      AND sep.name = 'MS_Description' ", con);
            using (IDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    descriptions.Add(new Tuple<string, string, string>(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString()));
                }
            }

            foreach (Table table in this.tables)
            {
                table.fetchColumns(ref con);
                table.getRelationShips(ref con);
                table.getDescriptions(ref descriptions);
            }
            lbTbl.DataSource = this.tables;
            lbTbl.DisplayMember = "Name";
        }
        private void fillDgv()
        {
            string tableName = ((Table)(this.lbTbl.SelectedItem)).name;


            foreach (Table table in this.tables)
            {
                if (table.name == tableName)
                {
                    //dgvPos.DataSource = table.columns;
                    dgvTable.DataSource = table.columns;
                }
            }
        }

        private void lbTbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillDgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int exerciseCount = Convert.ToInt32(nUDexCount.Value);
            if (cbSingleTable.Checked)
            {
                for (int i = 0; i < exerciseCount; i++)
                {
                    generatedExercises.Add(new SingleTableEx(ref this.tables, ref con, ref templates));
                    generatedExercises[generatedExercises.Count - 1].ID = exerciseNumber;
                    exerciseNumber++;
                }
            }
            if (cbFunctions.Checked)
            {
                for (int i = 0; i < exerciseCount; i++)
                {
                    generatedExercises.Add(new FunctionsEx(ref this.tables, ref con, ref templates));
                    generatedExercises[generatedExercises.Count - 1].ID = exerciseNumber;
                    exerciseNumber++;
                }
            }
            if (cbAggrFunctions.Checked)
            {
                for (int i = 0; i < exerciseCount; i++)
                {
                    generatedExercises.Add(new AggregateFunctionEx(ref this.tables, ref con, ref templates));
                    generatedExercises[generatedExercises.Count - 1].ID = exerciseNumber;
                    exerciseNumber++;
                }
            }
            if (cbMultiTable.Checked)
            {
                for (int i = 0; i < exerciseCount; i++)
                {
                    generatedExercises.Add(new MultiTableEx(ref this.tables, ref con, ref templates));
                    generatedExercises[generatedExercises.Count - 1].ID = exerciseNumber;
                    exerciseNumber++;
                }
            }
            if (cbSetOperation.Checked)
            {
                for (int i = 0; i < exerciseCount; i++)
                {
                    generatedExercises.Add(new SetOperationEx(ref this.tables, ref con, ref templates));
                    generatedExercises[generatedExercises.Count - 1].ID = exerciseNumber;
                    exerciseNumber++;
                }
            }


            dgvEx.DataSource = generatedExercises;
            dgvEx.Columns["Marked"].DisplayIndex = 0;
            dgvEx.Columns["ID"].DisplayIndex = 1;
            dgvEx.Columns["ExerciseTextHun"].DisplayIndex = 2;
            dgvEx.Columns["ExerciseTextSQL"].DisplayIndex = 3;
            dgvEx.Update();

            if(generatedExercises.Count > 0)
            {
                txtHun.Text = generatedExercises[0].ExerciseTextHun;
                txtSql.Text = generatedExercises[0].ExerciseTextSQL;
            }
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML-File | *.xml";
            sfd.Title = "Save exercise XML";
            sfd.FileName = "exercise.xml";
            sfd.ShowDialog();

            if(sfd.FileName != "")
            {
                genXML(sfd.FileName);
            }
        }

        private void genXML(string filepath)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = false;
            try
            {
                using (XmlWriter wr = XmlWriter.Create(filepath, settings))
                {
                    wr.WriteStartElement("quiz");
                    for(int i = 0; i < generatedExercises.Count; i++)
                    {
                        wr.WriteStartElement("question");
                        wr.WriteAttributeString("type", "essay");
                        wr.WriteStartElement("name");
                        wr.WriteElementString("text", "Exercise" + (i+1).ToString());
                        wr.WriteEndElement();
                        wr.WriteStartElement("questiontext");
                        wr.WriteAttributeString("format", "html");
                        wr.WriteStartElement("text");
                        wr.WriteCData(generatedExercises[i].ExerciseTextHun);
                        wr.WriteEndElement();
                        wr.WriteEndElement();
                        wr.WriteStartElement("generalfeedback");
                        wr.WriteAttributeString("format", "html");
                        wr.WriteStartElement("text");
                        wr.WriteCData(generatedExercises[i].ExerciseTextSQL);
                        wr.WriteEndElement();
                        wr.WriteEndElement();
                        wr.WriteElementString("responseformat", "plain");
                        wr.WriteElementString("responserequired", "1");
                        wr.WriteElementString("responsefieldlines", "3");
                        wr.WriteEndElement();
                    }
                    wr.WriteEndElement();
                    wr.WriteEndDocument();
                    wr.Close();
                }
                MessageBox.Show("XML successfully saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("XML export was unsuccessful: " + ex.Message);
                throw;
            }
        }
        private void dgvEx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedExerciseID = Convert.ToInt32(dgvEx.Rows[e.RowIndex].Cells[3].Value);
            Exercise selectedExercise = generatedExercises.Where(ex => ex.ID == selectedExerciseID).ToList()[0];
            txtHun.Text = selectedExercise.ExerciseTextHun;
            txtSql.Text = selectedExercise.ExerciseTextSQL;
        }

    }
}
