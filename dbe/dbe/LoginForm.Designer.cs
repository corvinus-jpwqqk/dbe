
namespace dbe
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tbSrv = new System.Windows.Forms.TextBox();
            this.tbUsr = new System.Windows.Forms.TextBox();
            this.lblSrv = new System.Windows.Forms.Label();
            this.lblUsr = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.cbDb = new System.Windows.Forms.ComboBox();
            this.lblDb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(63, 440);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 44);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Connect";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(302, 440);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 44);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(177, 284);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(84, 39);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbSrv
            // 
            this.tbSrv.Location = new System.Drawing.Point(63, 66);
            this.tbSrv.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSrv.Name = "tbSrv";
            this.tbSrv.Size = new System.Drawing.Size(322, 26);
            this.tbSrv.TabIndex = 1;
            this.tbSrv.Text = "bit.uni-corvinus.hu";
            // 
            // tbUsr
            // 
            this.tbUsr.Location = new System.Drawing.Point(63, 145);
            this.tbUsr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbUsr.Name = "tbUsr";
            this.tbUsr.Size = new System.Drawing.Size(322, 26);
            this.tbUsr.TabIndex = 2;
            this.tbUsr.Text = "hallgato";
            // 
            // lblSrv
            // 
            this.lblSrv.AutoSize = true;
            this.lblSrv.Location = new System.Drawing.Point(63, 41);
            this.lblSrv.Name = "lblSrv";
            this.lblSrv.Size = new System.Drawing.Size(116, 20);
            this.lblSrv.TabIndex = 5;
            this.lblSrv.Text = "Server address";
            // 
            // lblUsr
            // 
            this.lblUsr.AutoSize = true;
            this.lblUsr.Location = new System.Drawing.Point(63, 120);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(83, 20);
            this.lblUsr.TabIndex = 6;
            this.lblUsr.Text = "Username";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(63, 202);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(78, 20);
            this.lblPwd.TabIndex = 8;
            this.lblPwd.Text = "Password";
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(63, 228);
            this.tbPwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(322, 26);
            this.tbPwd.TabIndex = 3;
            // 
            // cbDb
            // 
            this.cbDb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDb.FormattingEnabled = true;
            this.cbDb.Location = new System.Drawing.Point(66, 368);
            this.cbDb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbDb.Name = "cbDb";
            this.cbDb.Size = new System.Drawing.Size(319, 28);
            this.cbDb.TabIndex = 5;
            // 
            // lblDb
            // 
            this.lblDb.AutoSize = true;
            this.lblDb.Location = new System.Drawing.Point(63, 342);
            this.lblDb.Name = "lblDb";
            this.lblDb.Size = new System.Drawing.Size(79, 20);
            this.lblDb.TabIndex = 10;
            this.lblDb.Text = "Database";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 499);
            this.Controls.Add(this.lblDb);
            this.Controls.Add(this.cbDb);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.lblUsr);
            this.Controls.Add(this.lblSrv);
            this.Controls.Add(this.tbUsr);
            this.Controls.Add(this.tbSrv);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tbSrv;
        private System.Windows.Forms.TextBox tbUsr;
        private System.Windows.Forms.Label lblSrv;
        private System.Windows.Forms.Label lblUsr;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.ComboBox cbDb;
        private System.Windows.Forms.Label lblDb;
    }
}