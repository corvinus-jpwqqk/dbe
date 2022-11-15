
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
            this.dgvPos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.txtHun = new System.Windows.Forms.TextBox();
            this.txtSql = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.cbSingleTable = new System.Windows.Forms.CheckBox();
            this.cbFunctions = new System.Windows.Forms.CheckBox();
            this.cbAggrFunctions = new System.Windows.Forms.CheckBox();
            this.cbMultiTable = new System.Windows.Forms.CheckBox();
            this.cbSetOperation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).BeginInit();
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
            this.lbTbl.SelectedIndexChanged += new System.EventHandler(this.lbTbl_SelectedIndexChanged);
            // 
            // dgvPos
            // 
            this.dgvPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPos.Location = new System.Drawing.Point(136, 13);
            this.dgvPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPos.Name = "dgvPos";
            this.dgvPos.RowHeadersWidth = 62;
            this.dgvPos.RowTemplate.Height = 28;
            this.dgvPos.Size = new System.Drawing.Size(816, 227);
            this.dgvPos.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 262);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtHun
            // 
            this.txtHun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHun.Location = new System.Drawing.Point(323, 262);
            this.txtHun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHun.Multiline = true;
            this.txtHun.Name = "txtHun";
            this.txtHun.Size = new System.Drawing.Size(621, 91);
            this.txtHun.TabIndex = 3;
            // 
            // txtSql
            // 
            this.txtSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSql.Location = new System.Drawing.Point(323, 357);
            this.txtSql.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(620, 191);
            this.txtSql.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(167, 513);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Export XML";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbSingleTable
            // 
            this.cbSingleTable.AutoSize = true;
            this.cbSingleTable.Location = new System.Drawing.Point(12, 292);
            this.cbSingleTable.Name = "cbSingleTable";
            this.cbSingleTable.Size = new System.Drawing.Size(109, 21);
            this.cbSingleTable.TabIndex = 6;
            this.cbSingleTable.Text = "Single Table";
            this.cbSingleTable.UseVisualStyleBackColor = true;
            // 
            // cbFunctions
            // 
            this.cbFunctions.AutoSize = true;
            this.cbFunctions.Location = new System.Drawing.Point(12, 319);
            this.cbFunctions.Name = "cbFunctions";
            this.cbFunctions.Size = new System.Drawing.Size(91, 21);
            this.cbFunctions.TabIndex = 7;
            this.cbFunctions.Text = "Functions";
            this.cbFunctions.UseVisualStyleBackColor = true;
            // 
            // cbAggrFunctions
            // 
            this.cbAggrFunctions.AutoSize = true;
            this.cbAggrFunctions.Location = new System.Drawing.Point(12, 346);
            this.cbAggrFunctions.Name = "cbAggrFunctions";
            this.cbAggrFunctions.Size = new System.Drawing.Size(161, 21);
            this.cbAggrFunctions.TabIndex = 8;
            this.cbAggrFunctions.Text = "Aggregate Functions";
            this.cbAggrFunctions.UseVisualStyleBackColor = true;
            // 
            // cbMultiTable
            // 
            this.cbMultiTable.AutoSize = true;
            this.cbMultiTable.Location = new System.Drawing.Point(12, 373);
            this.cbMultiTable.Name = "cbMultiTable";
            this.cbMultiTable.Size = new System.Drawing.Size(125, 21);
            this.cbMultiTable.TabIndex = 9;
            this.cbMultiTable.Text = "Multiple Tables";
            this.cbMultiTable.UseVisualStyleBackColor = true;
            // 
            // cbSetOperation
            // 
            this.cbSetOperation.AutoSize = true;
            this.cbSetOperation.Location = new System.Drawing.Point(12, 400);
            this.cbSetOperation.Name = "cbSetOperation";
            this.cbSetOperation.Size = new System.Drawing.Size(125, 21);
            this.cbSetOperation.TabIndex = 10;
            this.cbSetOperation.Text = "Set Operations";
            this.cbSetOperation.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(955, 559);
            this.Controls.Add(this.cbSetOperation);
            this.Controls.Add(this.cbMultiTable);
            this.Controls.Add(this.cbAggrFunctions);
            this.Controls.Add(this.cbFunctions);
            this.Controls.Add(this.cbSingleTable);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.txtHun);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPos);
            this.Controls.Add(this.lbTbl);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTbl;
        private System.Windows.Forms.DataGridView dgvPos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtHun;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox cbSingleTable;
        private System.Windows.Forms.CheckBox cbFunctions;
        private System.Windows.Forms.CheckBox cbAggrFunctions;
        private System.Windows.Forms.CheckBox cbMultiTable;
        private System.Windows.Forms.CheckBox cbSetOperation;
    }
}

