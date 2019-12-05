namespace realstate
{
    partial class fileList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fileList));
            this.TMainTable = new System.Windows.Forms.TableLayoutPanel();
            this.listGrid = new System.Windows.Forms.DataGridView();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.codegrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dategrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownergrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typegrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floorgrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kindgrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rahn_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ejare_metri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zirbana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Senn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMainTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TMainTable
            // 
            this.TMainTable.ColumnCount = 1;
            this.TMainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TMainTable.Controls.Add(this.listGrid, 0, 0);
            this.TMainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TMainTable.Location = new System.Drawing.Point(0, 0);
            this.TMainTable.Name = "TMainTable";
            this.TMainTable.RowCount = 2;
            this.TMainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.85612F));
            this.TMainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.14388F));
            this.TMainTable.Size = new System.Drawing.Size(800, 556);
            this.TMainTable.TabIndex = 0;
            // 
            // listGrid
            // 
            this.listGrid.AllowUserToAddRows = false;
            this.listGrid.AllowUserToDeleteRows = false;
            this.listGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox,
            this.codegrid,
            this.dategrid,
            this.ownergrid,
            this.typegrid,
            this.floorgrid,
            this.kindgrid,
            this.rahn_total,
            this.ejare_metri,
            this.bed,
            this.zirbana,
            this.Senn,
            this.Address});
            this.listGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGrid.Location = new System.Drawing.Point(3, 3);
            this.listGrid.Name = "listGrid";
            this.listGrid.ReadOnly = true;
            this.listGrid.Size = new System.Drawing.Size(794, 438);
            this.listGrid.TabIndex = 0;
            this.listGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.listGrid_CellMouseEnter);
            this.listGrid.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.listGrid_CellMouseLeave);
            this.listGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.listGrid_ColumnHeaderMouseClick);
            // 
            // checkbox
            // 
            this.checkbox.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.checkbox.DataPropertyName = "checkbox";
            this.checkbox.HeaderText = "کل";
            this.checkbox.Name = "checkbox";
            this.checkbox.ReadOnly = true;
            this.checkbox.Width = 27;
            // 
            // codegrid
            // 
            this.codegrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.codegrid.DataPropertyName = "codegrid";
            this.codegrid.HeaderText = "کد";
            this.codegrid.Name = "codegrid";
            this.codegrid.ReadOnly = true;
            this.codegrid.Width = 44;
            // 
            // dategrid
            // 
            this.dategrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dategrid.DataPropertyName = "dategrid";
            this.dategrid.HeaderText = "تاریخ";
            this.dategrid.Name = "dategrid";
            this.dategrid.ReadOnly = true;
            this.dategrid.Width = 57;
            // 
            // ownergrid
            // 
            this.ownergrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ownergrid.DataPropertyName = "ownergrid";
            this.ownergrid.HeaderText = "مالک";
            this.ownergrid.Name = "ownergrid";
            this.ownergrid.ReadOnly = true;
            this.ownergrid.Width = 51;
            // 
            // typegrid
            // 
            this.typegrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.typegrid.DataPropertyName = "typegrid";
            this.typegrid.HeaderText = "نوع";
            this.typegrid.Name = "typegrid";
            this.typegrid.ReadOnly = true;
            this.typegrid.Width = 49;
            // 
            // floorgrid
            // 
            this.floorgrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.floorgrid.DataPropertyName = "floorgrid";
            this.floorgrid.HeaderText = "طبقه";
            this.floorgrid.Name = "floorgrid";
            this.floorgrid.ReadOnly = true;
            this.floorgrid.Width = 53;
            // 
            // kindgrid
            // 
            this.kindgrid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.kindgrid.DataPropertyName = "kindgrid";
            this.kindgrid.HeaderText = "مورد";
            this.kindgrid.Name = "kindgrid";
            this.kindgrid.ReadOnly = true;
            this.kindgrid.Width = 53;
            // 
            // rahn_total
            // 
            this.rahn_total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.rahn_total.DataPropertyName = "rahn_total";
            this.rahn_total.HeaderText = "کل/ودیعه";
            this.rahn_total.Name = "rahn_total";
            this.rahn_total.ReadOnly = true;
            this.rahn_total.Width = 77;
            // 
            // ejare_metri
            // 
            this.ejare_metri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ejare_metri.DataPropertyName = "ejare_metri";
            this.ejare_metri.HeaderText = "متری/اجاره";
            this.ejare_metri.Name = "ejare_metri";
            this.ejare_metri.ReadOnly = true;
            this.ejare_metri.Width = 86;
            // 
            // bed
            // 
            this.bed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bed.DataPropertyName = "bed";
            this.bed.HeaderText = "خواب";
            this.bed.Name = "bed";
            this.bed.ReadOnly = true;
            this.bed.Width = 56;
            // 
            // zirbana
            // 
            this.zirbana.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.zirbana.DataPropertyName = "zirbana";
            this.zirbana.HeaderText = "زیربنا";
            this.zirbana.Name = "zirbana";
            this.zirbana.ReadOnly = true;
            this.zirbana.Width = 58;
            // 
            // Senn
            // 
            this.Senn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Senn.DataPropertyName = "Senn";
            this.Senn.HeaderText = "سن";
            this.Senn.Name = "Senn";
            this.Senn.ReadOnly = true;
            this.Senn.Width = 48;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "آدرس";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Width = 55;
            // 
            // fileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 556);
            this.Controls.Add(this.TMainTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fileList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "نمایش فایل";
            this.TMainTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TMainTable;
        private System.Windows.Forms.DataGridView listGrid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn codegrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dategrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownergrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn typegrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn floorgrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn kindgrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn rahn_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn ejare_metri;
        private System.Windows.Forms.DataGridViewTextBoxColumn bed;
        private System.Windows.Forms.DataGridViewTextBoxColumn zirbana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Senn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}