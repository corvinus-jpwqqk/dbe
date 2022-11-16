
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
            this.btnExport = new System.Windows.Forms.Button();
            this.cbSingleTable = new System.Windows.Forms.CheckBox();
            this.cbFunctions = new System.Windows.Forms.CheckBox();
            this.cbAggrFunctions = new System.Windows.Forms.CheckBox();
            this.cbMultiTable = new System.Windows.Forms.CheckBox();
            this.cbSetOperation = new System.Windows.Forms.CheckBox();
            this.nUDexCount = new System.Windows.Forms.NumericUpDown();
            this.lblExCount = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbMarked = new System.Windows.Forms.CheckBox();
            this.lblExNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDexCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTbl
            // 
            this.lbTbl.FormattingEnabled = true;
            this.lbTbl.ItemHeight = 16;
            this.lbTbl.Location = new System.Drawing.Point(13, 13);
            this.lbTbl.Name = "lbTbl";
            this.lbTbl.Size = new System.Drawing.Size(160, 180);
            this.lbTbl.TabIndex = 0;
            this.lbTbl.SelectedIndexChanged += new System.EventHandler(this.lbTbl_SelectedIndexChanged);
            // 
            // dgvPos
            // 
            this.dgvPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPos.Location = new System.Drawing.Point(179, 13);
            this.dgvPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPos.Name = "dgvPos";
            this.dgvPos.RowHeadersWidth = 62;
            this.dgvPos.RowTemplate.Height = 28;
            this.dgvPos.Size = new System.Drawing.Size(773, 174);
            this.dgvPos.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 410);
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
            this.txtHun.Location = new System.Drawing.Point(179, 191);
            this.txtHun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHun.Multiline = true;
            this.txtHun.Name = "txtHun";
            this.txtHun.Size = new System.Drawing.Size(375, 321);
            this.txtHun.TabIndex = 3;
            // 
            // txtSql
            // 
            this.txtSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSql.Location = new System.Drawing.Point(560, 191);
            this.txtSql.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(392, 321);
            this.txtSql.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(14, 513);
            this.btnExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(141, 35);
            this.btnExport.TabIndex = 5;
            this.btnExport.Text = "Export XML";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbSingleTable
            // 
            this.cbSingleTable.AutoSize = true;
            this.cbSingleTable.Location = new System.Drawing.Point(13, 210);
            this.cbSingleTable.Name = "cbSingleTable";
            this.cbSingleTable.Size = new System.Drawing.Size(109, 21);
            this.cbSingleTable.TabIndex = 6;
            this.cbSingleTable.Text = "Single Table";
            this.cbSingleTable.UseVisualStyleBackColor = true;
            // 
            // cbFunctions
            // 
            this.cbFunctions.AutoSize = true;
            this.cbFunctions.Location = new System.Drawing.Point(13, 237);
            this.cbFunctions.Name = "cbFunctions";
            this.cbFunctions.Size = new System.Drawing.Size(91, 21);
            this.cbFunctions.TabIndex = 7;
            this.cbFunctions.Text = "Functions";
            this.cbFunctions.UseVisualStyleBackColor = true;
            // 
            // cbAggrFunctions
            // 
            this.cbAggrFunctions.AutoSize = true;
            this.cbAggrFunctions.Location = new System.Drawing.Point(13, 264);
            this.cbAggrFunctions.Name = "cbAggrFunctions";
            this.cbAggrFunctions.Size = new System.Drawing.Size(161, 21);
            this.cbAggrFunctions.TabIndex = 8;
            this.cbAggrFunctions.Text = "Aggregate Functions";
            this.cbAggrFunctions.UseVisualStyleBackColor = true;
            // 
            // cbMultiTable
            // 
            this.cbMultiTable.AutoSize = true;
            this.cbMultiTable.Location = new System.Drawing.Point(13, 291);
            this.cbMultiTable.Name = "cbMultiTable";
            this.cbMultiTable.Size = new System.Drawing.Size(125, 21);
            this.cbMultiTable.TabIndex = 9;
            this.cbMultiTable.Text = "Multiple Tables";
            this.cbMultiTable.UseVisualStyleBackColor = true;
            // 
            // cbSetOperation
            // 
            this.cbSetOperation.AutoSize = true;
            this.cbSetOperation.Location = new System.Drawing.Point(13, 318);
            this.cbSetOperation.Name = "cbSetOperation";
            this.cbSetOperation.Size = new System.Drawing.Size(125, 21);
            this.cbSetOperation.TabIndex = 10;
            this.cbSetOperation.Text = "Set Operations";
            this.cbSetOperation.UseVisualStyleBackColor = true;
            // 
            // nUDexCount
            // 
            this.nUDexCount.Location = new System.Drawing.Point(14, 373);
            this.nUDexCount.Name = "nUDexCount";
            this.nUDexCount.Size = new System.Drawing.Size(120, 22);
            this.nUDexCount.TabIndex = 11;
            this.nUDexCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblExCount
            // 
            this.lblExCount.AutoSize = true;
            this.lblExCount.Location = new System.Drawing.Point(13, 353);
            this.lblExCount.Name = "lblExCount";
            this.lblExCount.Size = new System.Drawing.Size(119, 17);
            this.lblExCount.TabIndex = 12;
            this.lblExCount.Text = "Feladatok száma:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(560, 517);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 34);
            this.button2.TabIndex = 13;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(515, 517);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(39, 34);
            this.button3.TabIndex = 14;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cbMarked
            // 
            this.cbMarked.AutoSize = true;
            this.cbMarked.Location = new System.Drawing.Point(605, 525);
            this.cbMarked.Name = "cbMarked";
            this.cbMarked.Size = new System.Drawing.Size(125, 21);
            this.cbMarked.TabIndex = 15;
            this.cbMarked.Text = "Mark for export";
            this.cbMarked.UseVisualStyleBackColor = true;
            this.cbMarked.CheckedChanged += new System.EventHandler(this.cbMarked_CheckedChanged);
            // 
            // lblExNo
            // 
            this.lblExNo.AutoSize = true;
            this.lblExNo.Location = new System.Drawing.Point(447, 526);
            this.lblExNo.Name = "lblExNo";
            this.lblExNo.Size = new System.Drawing.Size(46, 17);
            this.lblExNo.TabIndex = 16;
            this.lblExNo.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(955, 559);
            this.Controls.Add(this.lblExNo);
            this.Controls.Add(this.cbMarked);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblExCount);
            this.Controls.Add(this.nUDexCount);
            this.Controls.Add(this.cbSetOperation);
            this.Controls.Add(this.cbMultiTable);
            this.Controls.Add(this.cbAggrFunctions);
            this.Controls.Add(this.cbFunctions);
            this.Controls.Add(this.cbSingleTable);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtSql);
            this.Controls.Add(this.txtHun);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPos);
            this.Controls.Add(this.lbTbl);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDexCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTbl;
        private System.Windows.Forms.DataGridView dgvPos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtHun;
        private System.Windows.Forms.TextBox txtSql;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox cbSingleTable;
        private System.Windows.Forms.CheckBox cbFunctions;
        private System.Windows.Forms.CheckBox cbAggrFunctions;
        private System.Windows.Forms.CheckBox cbMultiTable;
        private System.Windows.Forms.CheckBox cbSetOperation;
        private System.Windows.Forms.NumericUpDown nUDexCount;
        private System.Windows.Forms.Label lblExCount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox cbMarked;
        private System.Windows.Forms.Label lblExNo;
    }
}

