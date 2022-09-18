
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
            this.btnOK.Location = new System.Drawing.Point(56, 352);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 35);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Connect";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(268, 352);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 35);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(157, 227);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 31);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tbSrv
            // 
            this.tbSrv.Location = new System.Drawing.Point(56, 53);
            this.tbSrv.Name = "tbSrv";
            this.tbSrv.Size = new System.Drawing.Size(287, 22);
            this.tbSrv.TabIndex = 3;
            this.tbSrv.Text = "bit.uni-corvinus.hu";
            // 
            // tbUsr
            // 
            this.tbUsr.Location = new System.Drawing.Point(56, 116);
            this.tbUsr.Name = "tbUsr";
            this.tbUsr.Size = new System.Drawing.Size(287, 22);
            this.tbUsr.TabIndex = 4;
            this.tbUsr.Text = "hallgato";
            // 
            // lblSrv
            // 
            this.lblSrv.AutoSize = true;
            this.lblSrv.Location = new System.Drawing.Point(56, 33);
            this.lblSrv.Name = "lblSrv";
            this.lblSrv.Size = new System.Drawing.Size(105, 17);
            this.lblSrv.TabIndex = 5;
            this.lblSrv.Text = "Server address";
            // 
            // lblUsr
            // 
            this.lblUsr.AutoSize = true;
            this.lblUsr.Location = new System.Drawing.Point(56, 96);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(73, 17);
            this.lblUsr.TabIndex = 6;
            this.lblUsr.Text = "Username";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.Location = new System.Drawing.Point(56, 162);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(69, 17);
            this.lblPwd.TabIndex = 8;
            this.lblPwd.Text = "Password";
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(56, 182);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(287, 22);
            this.tbPwd.TabIndex = 7;
            // 
            // cbDb
            // 
            this.cbDb.FormattingEnabled = true;
            this.cbDb.Location = new System.Drawing.Point(59, 294);
            this.cbDb.Name = "cbDb";
            this.cbDb.Size = new System.Drawing.Size(284, 24);
            this.cbDb.TabIndex = 9;
            // 
            // lblDb
            // 
            this.lblDb.AutoSize = true;
            this.lblDb.Location = new System.Drawing.Point(56, 274);
            this.lblDb.Name = "lblDb";
            this.lblDb.Size = new System.Drawing.Size(69, 17);
            this.lblDb.TabIndex = 10;
            this.lblDb.Text = "Database";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 399);
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