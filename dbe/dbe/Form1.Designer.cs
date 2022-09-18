
namespace dbe
{
    partial class Form1
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
            this.lbTbl = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbTbl
            // 
            this.lbTbl.FormattingEnabled = true;
            this.lbTbl.ItemHeight = 16;
            this.lbTbl.Location = new System.Drawing.Point(13, 13);
            this.lbTbl.Name = "lbTbl";
            this.lbTbl.Size = new System.Drawing.Size(109, 228);
            this.lbTbl.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 559);
            this.Controls.Add(this.lbTbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTbl;
    }
}

