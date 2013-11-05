namespace CityTools.Components.DatabaseEditing {
    partial class DatabaseEditor {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.statusStripDatabases = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton4 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewDatabaseName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.listDatabases = new System.Windows.Forms.ListBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtAddDatabaseColumnName = new System.Windows.Forms.ToolStripTextBox();
            this.cbAddDatabaseColumnType = new System.Windows.Forms.ToolStripComboBox();
            this.btnAddDatabaseColumn = new System.Windows.Forms.ToolStripButton();
            this.dgvDatabases = new System.Windows.Forms.DataGridView();
            this.statusStripDatabases.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabases)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripDatabases
            // 
            this.statusStripDatabases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton4,
            this.toolStripDropDownButton1});
            this.statusStripDatabases.Location = new System.Drawing.Point(0, 504);
            this.statusStripDatabases.Name = "statusStripDatabases";
            this.statusStripDatabases.Size = new System.Drawing.Size(712, 22);
            this.statusStripDatabases.TabIndex = 8;
            this.statusStripDatabases.Text = "Database Controls";
            // 
            // toolStripSplitButton4
            // 
            this.toolStripSplitButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.txtNewDatabaseName});
            this.toolStripSplitButton4.Image = global::CityTools.Properties.Resources.add;
            this.toolStripSplitButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton4.Name = "toolStripSplitButton4";
            this.toolStripSplitButton4.Size = new System.Drawing.Size(100, 20);
            this.toolStripSplitButton4.Text = "Add Library";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(407, 22);
            this.toolStripMenuItem4.Text = "Type the name of the new database and press enter to create it.";
            // 
            // txtNewDatabaseName
            // 
            this.txtNewDatabaseName.Name = "txtNewDatabaseName";
            this.txtNewDatabaseName.Size = new System.Drawing.Size(100, 23);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Image = global::CityTools.Properties.Resources.delete;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(116, 20);
            this.toolStripDropDownButton1.Text = "Delete Selected";
            // 
            // listDatabases
            // 
            this.listDatabases.Dock = System.Windows.Forms.DockStyle.Left;
            this.listDatabases.FormattingEnabled = true;
            this.listDatabases.Location = new System.Drawing.Point(0, 0);
            this.listDatabases.Name = "listDatabases";
            this.listDatabases.Size = new System.Drawing.Size(183, 504);
            this.listDatabases.Sorted = true;
            this.listDatabases.TabIndex = 9;
            // 
            // toolStrip
            // 
            this.toolStrip.Enabled = false;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtAddDatabaseColumnName,
            this.cbAddDatabaseColumnType,
            this.btnAddDatabaseColumn});
            this.toolStrip.Location = new System.Drawing.Point(183, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(529, 25);
            this.toolStrip.TabIndex = 10;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(75, 22);
            this.toolStripLabel1.Text = "Add Column";
            // 
            // txtAddDatabaseColumnName
            // 
            this.txtAddDatabaseColumnName.Name = "txtAddDatabaseColumnName";
            this.txtAddDatabaseColumnName.Size = new System.Drawing.Size(100, 25);
            // 
            // cbAddDatabaseColumnType
            // 
            this.cbAddDatabaseColumnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddDatabaseColumnType.Items.AddRange(new object[] {
            "Number",
            "String"});
            this.cbAddDatabaseColumnType.Name = "cbAddDatabaseColumnType";
            this.cbAddDatabaseColumnType.Size = new System.Drawing.Size(121, 25);
            // 
            // btnAddDatabaseColumn
            // 
            this.btnAddDatabaseColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDatabaseColumn.Image = global::CityTools.Properties.Resources.add;
            this.btnAddDatabaseColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDatabaseColumn.Name = "btnAddDatabaseColumn";
            this.btnAddDatabaseColumn.Size = new System.Drawing.Size(23, 22);
            this.btnAddDatabaseColumn.Text = "Add Column";
            // 
            // dgvDatabases
            // 
            this.dgvDatabases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatabases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatabases.Location = new System.Drawing.Point(183, 25);
            this.dgvDatabases.Name = "dgvDatabases";
            this.dgvDatabases.Size = new System.Drawing.Size(529, 479);
            this.dgvDatabases.TabIndex = 11;
            // 
            // DatabaseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDatabases);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.listDatabases);
            this.Controls.Add(this.statusStripDatabases);
            this.Name = "DatabaseEditor";
            this.Size = new System.Drawing.Size(712, 526);
            this.statusStripDatabases.ResumeLayout(false);
            this.statusStripDatabases.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabases)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripDatabases;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripTextBox txtNewDatabaseName;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ListBox listDatabases;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtAddDatabaseColumnName;
        private System.Windows.Forms.ToolStripComboBox cbAddDatabaseColumnType;
        private System.Windows.Forms.ToolStripButton btnAddDatabaseColumn;
        private System.Windows.Forms.DataGridView dgvDatabases;
    }
}
