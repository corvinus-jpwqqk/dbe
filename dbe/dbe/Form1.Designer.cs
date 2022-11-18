
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
            this.tabDb = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvTable = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvEx = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nUDexCount)).BeginInit();
            this.tabDb.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEx)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTbl
            // 
            this.lbTbl.FormattingEnabled = true;
            this.lbTbl.ItemHeight = 16;
            this.lbTbl.Location = new System.Drawing.Point(6, 6);
            this.lbTbl.Name = "lbTbl";
            this.lbTbl.Size = new System.Drawing.Size(160, 484);
            this.lbTbl.TabIndex = 0;
            this.lbTbl.SelectedIndexChanged += new System.EventHandler(this.lbTbl_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 217);
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
            this.txtHun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHun.Location = new System.Drawing.Point(173, 256);
            this.txtHun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHun.Multiline = true;
            this.txtHun.Name = "txtHun";
            this.txtHun.Size = new System.Drawing.Size(364, 245);
            this.txtHun.TabIndex = 3;
            // 
            // txtSql
            // 
            this.txtSql.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSql.Location = new System.Drawing.Point(543, 256);
            this.txtSql.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSql.Multiline = true;
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(374, 245);
            this.txtSql.TabIndex = 4;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(9, 466);
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
            this.cbSingleTable.Location = new System.Drawing.Point(6, 17);
            this.cbSingleTable.Name = "cbSingleTable";
            this.cbSingleTable.Size = new System.Drawing.Size(109, 21);
            this.cbSingleTable.TabIndex = 6;
            this.cbSingleTable.Text = "Single Table";
            this.cbSingleTable.UseVisualStyleBackColor = true;
            // 
            // cbFunctions
            // 
            this.cbFunctions.AutoSize = true;
            this.cbFunctions.Location = new System.Drawing.Point(6, 44);
            this.cbFunctions.Name = "cbFunctions";
            this.cbFunctions.Size = new System.Drawing.Size(91, 21);
            this.cbFunctions.TabIndex = 7;
            this.cbFunctions.Text = "Functions";
            this.cbFunctions.UseVisualStyleBackColor = true;
            // 
            // cbAggrFunctions
            // 
            this.cbAggrFunctions.AutoSize = true;
            this.cbAggrFunctions.Location = new System.Drawing.Point(6, 71);
            this.cbAggrFunctions.Name = "cbAggrFunctions";
            this.cbAggrFunctions.Size = new System.Drawing.Size(161, 21);
            this.cbAggrFunctions.TabIndex = 8;
            this.cbAggrFunctions.Text = "Aggregate Functions";
            this.cbAggrFunctions.UseVisualStyleBackColor = true;
            // 
            // cbMultiTable
            // 
            this.cbMultiTable.AutoSize = true;
            this.cbMultiTable.Location = new System.Drawing.Point(6, 98);
            this.cbMultiTable.Name = "cbMultiTable";
            this.cbMultiTable.Size = new System.Drawing.Size(125, 21);
            this.cbMultiTable.TabIndex = 9;
            this.cbMultiTable.Text = "Multiple Tables";
            this.cbMultiTable.UseVisualStyleBackColor = true;
            // 
            // cbSetOperation
            // 
            this.cbSetOperation.AutoSize = true;
            this.cbSetOperation.Location = new System.Drawing.Point(6, 125);
            this.cbSetOperation.Name = "cbSetOperation";
            this.cbSetOperation.Size = new System.Drawing.Size(125, 21);
            this.cbSetOperation.TabIndex = 10;
            this.cbSetOperation.Text = "Set Operations";
            this.cbSetOperation.UseVisualStyleBackColor = true;
            // 
            // nUDexCount
            // 
            this.nUDexCount.Location = new System.Drawing.Point(7, 180);
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
            this.lblExCount.Location = new System.Drawing.Point(6, 160);
            this.lblExCount.Name = "lblExCount";
            this.lblExCount.Size = new System.Drawing.Size(119, 17);
            this.lblExCount.TabIndex = 12;
            this.lblExCount.Text = "Feladatok száma:";
            // 
            // tabDb
            // 
            this.tabDb.AccessibleName = "";
            this.tabDb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDb.Controls.Add(this.tabPage1);
            this.tabDb.Controls.Add(this.tabPage2);
            this.tabDb.Controls.Add(this.tabPage3);
            this.tabDb.Location = new System.Drawing.Point(12, 12);
            this.tabDb.Name = "tabDb";
            this.tabDb.SelectedIndex = 0;
            this.tabDb.Size = new System.Drawing.Size(931, 535);
            this.tabDb.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvTable);
            this.tabPage2.Controls.Add(this.lbTbl);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvTable
            // 
            this.dgvTable.AllowUserToAddRows = false;
            this.dgvTable.AllowUserToDeleteRows = false;
            this.dgvTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTable.Location = new System.Drawing.Point(172, 6);
            this.dgvTable.MultiSelect = false;
            this.dgvTable.Name = "dgvTable";
            this.dgvTable.ReadOnly = true;
            this.dgvTable.RowHeadersWidth = 51;
            this.dgvTable.RowTemplate.Height = 24;
            this.dgvTable.Size = new System.Drawing.Size(745, 494);
            this.dgvTable.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvEx);
            this.tabPage3.Controls.Add(this.cbSingleTable);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.btnExport);
            this.tabPage3.Controls.Add(this.cbFunctions);
            this.tabPage3.Controls.Add(this.cbAggrFunctions);
            this.tabPage3.Controls.Add(this.txtHun);
            this.tabPage3.Controls.Add(this.txtSql);
            this.tabPage3.Controls.Add(this.lblExCount);
            this.tabPage3.Controls.Add(this.cbMultiTable);
            this.tabPage3.Controls.Add(this.nUDexCount);
            this.tabPage3.Controls.Add(this.cbSetOperation);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(923, 506);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvEx
            // 
            this.dgvEx.AllowUserToAddRows = false;
            this.dgvEx.AllowUserToDeleteRows = false;
            this.dgvEx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEx.Location = new System.Drawing.Point(173, 17);
            this.dgvEx.MultiSelect = false;
            this.dgvEx.Name = "dgvEx";
            this.dgvEx.RowHeadersWidth = 51;
            this.dgvEx.RowTemplate.Height = 24;
            this.dgvEx.Size = new System.Drawing.Size(744, 235);
            this.dgvEx.TabIndex = 18;
            this.dgvEx.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEx_CellClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 559);
            this.Controls.Add(this.tabDb);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.nUDexCount)).EndInit();
            this.tabDb.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTable)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEx)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTbl;
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
        private System.Windows.Forms.TabControl tabDb;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvEx;
        private System.Windows.Forms.DataGridView dgvTable;
    }
}

