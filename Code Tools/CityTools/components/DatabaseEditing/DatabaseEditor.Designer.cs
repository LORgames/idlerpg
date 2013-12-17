namespace CityTools.Components.DatabaseEditing {
    partial class DatabaseEditor {
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
            this.btnDeleteDatabases = new System.Windows.Forms.ToolStripDropDownButton();
            this.listDatabases = new System.Windows.Forms.ListBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtAddDatabaseColumnName = new System.Windows.Forms.ToolStripTextBox();
            this.cbAddDatabaseColumnType = new System.Windows.Forms.ToolStripComboBox();
            this.btnAddDatabaseColumn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddRow = new System.Windows.Forms.ToolStripButton();
            this.numHidden = new System.Windows.Forms.NumericUpDown();
            this.txtHidden = new System.Windows.Forms.TextBox();
            this.cbHidden = new System.Windows.Forms.ComboBox();
            this.lvLibrary = new CityTools.Components.ListViewEx();
            this.statusStripDatabases.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHidden)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStripDatabases
            // 
            this.statusStripDatabases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton4,
            this.btnDeleteDatabases});
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
            this.toolStripSplitButton4.Size = new System.Drawing.Size(112, 20);
            this.toolStripSplitButton4.Text = "Add Database";
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
            // btnDeleteDatabases
            // 
            this.btnDeleteDatabases.Image = global::CityTools.Properties.Resources.delete;
            this.btnDeleteDatabases.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteDatabases.Name = "btnDeleteDatabases";
            this.btnDeleteDatabases.Size = new System.Drawing.Size(116, 20);
            this.btnDeleteDatabases.Text = "Delete Selected";
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
            this.listDatabases.SelectedIndexChanged += new System.EventHandler(this.listDatabases_SelectedIndexChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Enabled = false;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtAddDatabaseColumnName,
            this.cbAddDatabaseColumnType,
            this.btnAddDatabaseColumn,
            this.toolStripSeparator1,
            this.btnAddRow});
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
            this.cbAddDatabaseColumnType.Name = "cbAddDatabaseColumnType";
            this.cbAddDatabaseColumnType.Size = new System.Drawing.Size(121, 25);
            this.cbAddDatabaseColumnType.Sorted = true;
            // 
            // btnAddDatabaseColumn
            // 
            this.btnAddDatabaseColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDatabaseColumn.Image = global::CityTools.Properties.Resources.add;
            this.btnAddDatabaseColumn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDatabaseColumn.Name = "btnAddDatabaseColumn";
            this.btnAddDatabaseColumn.Size = new System.Drawing.Size(23, 22);
            this.btnAddDatabaseColumn.Text = "Add Column";
            this.btnAddDatabaseColumn.Click += new System.EventHandler(this.btnAddDatabaseColumn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Image = global::CityTools.Properties.Resources.add;
            this.btnAddRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(75, 22);
            this.btnAddRow.Text = "Add Row";
            this.btnAddRow.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // numHidden
            // 
            this.numHidden.Location = new System.Drawing.Point(407, 232);
            this.numHidden.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numHidden.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.numHidden.Name = "numHidden";
            this.numHidden.Size = new System.Drawing.Size(115, 20);
            this.numHidden.TabIndex = 12;
            this.numHidden.Visible = false;
            // 
            // txtHidden
            // 
            this.txtHidden.Location = new System.Drawing.Point(407, 258);
            this.txtHidden.Name = "txtHidden";
            this.txtHidden.Size = new System.Drawing.Size(115, 20);
            this.txtHidden.TabIndex = 13;
            this.txtHidden.Visible = false;
            // 
            // cbHidden
            // 
            this.cbHidden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHidden.FormattingEnabled = true;
            this.cbHidden.Location = new System.Drawing.Point(407, 284);
            this.cbHidden.Name = "cbHidden";
            this.cbHidden.Size = new System.Drawing.Size(115, 21);
            this.cbHidden.TabIndex = 14;
            this.cbHidden.Visible = false;
            // 
            // lvLibrary
            // 
            this.lvLibrary.AllowColumnReorder = true;
            this.lvLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLibrary.DoubleClickActivation = false;
            this.lvLibrary.FullRowSelect = true;
            this.lvLibrary.GridLines = true;
            this.lvLibrary.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLibrary.Location = new System.Drawing.Point(183, 25);
            this.lvLibrary.Name = "lvLibrary";
            this.lvLibrary.Size = new System.Drawing.Size(529, 479);
            this.lvLibrary.TabIndex = 11;
            this.lvLibrary.UseCompatibleStateImageBehavior = false;
            this.lvLibrary.View = System.Windows.Forms.View.Details;
            this.lvLibrary.SubItemClicked += new CityTools.Components.SubItemEventHandler(this.lvLibrary_SubItemClicked);
            this.lvLibrary.SubItemBeginEditing += new CityTools.Components.SubItemEventHandler(this.lvLibrary_SubItemBeginEditing);
            this.lvLibrary.SubItemEndEditing += new CityTools.Components.SubItemEndEditingEventHandler(this.lvLibrary_SubItemEndEditing);
            // 
            // DatabaseEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbHidden);
            this.Controls.Add(this.txtHidden);
            this.Controls.Add(this.numHidden);
            this.Controls.Add(this.lvLibrary);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.listDatabases);
            this.Controls.Add(this.statusStripDatabases);
            this.Name = "DatabaseEditor";
            this.Size = new System.Drawing.Size(712, 526);
            this.statusStripDatabases.ResumeLayout(false);
            this.statusStripDatabases.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHidden)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStripDatabases;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripTextBox txtNewDatabaseName;
        private System.Windows.Forms.ToolStripDropDownButton btnDeleteDatabases;
        private System.Windows.Forms.ListBox listDatabases;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtAddDatabaseColumnName;
        private System.Windows.Forms.ToolStripComboBox cbAddDatabaseColumnType;
        private System.Windows.Forms.ToolStripButton btnAddDatabaseColumn;
        private ListViewEx lvLibrary;
        private System.Windows.Forms.ToolStripButton btnAddRow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NumericUpDown numHidden;
        private System.Windows.Forms.TextBox txtHidden;
        private System.Windows.Forms.ComboBox cbHidden;
    }
}
