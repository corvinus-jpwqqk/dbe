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
    public partial class LoginForm : Form
    {
        public string connString;
        private readonly List<string> databases = new List<string>();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void login()
        {
            string serverAddr = tbSrv.Text;
            string userName = tbUsr.Text;
            string pwd = tbPwd.Text;
            this.connString = "Server=" + serverAddr + ";Uid=" + userName + ";Password=" + pwd;
            Console.WriteLine("Connecting to server with: " + this.connString);
            using (SqlConnection con = new SqlConnection())
            {
                Cursor.Current = Cursors.WaitCursor;
                con.ConnectionString = this.connString;
                try
                {
                    con.Open();
                    btnLogin.Enabled = false;
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Error while connecting: " + ex.Message);
                    return;
                }

                using (SqlCommand cmd = new SqlCommand("SELECT name FROM sys.databases WHERE owner_sid <> 0x01", con))
                {
                    using (IDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            this.databases.Add(rdr[0].ToString());
                        }
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }
    }
}
