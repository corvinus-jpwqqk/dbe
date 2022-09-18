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
        
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            using (LoginForm f = new LoginForm())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    this.connectionString = f.connString;
                    MessageBox.Show("Received ConnectionString: " + connectionString);
                }
                else
                {
                    Application.Exit();
                }
                MessageBox.Show("asd");
            }
            base.OnLoad(e);
        }
    }
}
