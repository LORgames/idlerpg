namespace CityTools.Components.DatabaseEditing {
    partial class StringVariableEditor {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewVariable = new System.Windows.Forms.ToolStripTextBox();
            this.btnDelete = new System.Windows.Forms.ToolStripStatusLabel();
            this.listVariables = new CityTools.Components.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtStringChanger = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.btnDelete});
            this.statusStrip1.Location = new System.Drawing.Point(0, 397);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(677, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStripInts";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.txtNewVariable});
            this.toolStripSplitButton1.Image = global::CityTools.Properties.Resources.add;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(106, 20);
            this.toolStripSplitButton1.Text = "Add Variable";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(389, 22);
            this.toolStripMenuItem1.Text = "Type the name of the new variable and press enter to add it.";
            // 
            // txtNewVariable
            // 
            this.txtNewVariable.Name = "txtNewVariable";
            this.txtNewVariable.Size = new System.Drawing.Size(100, 23);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::CityTools.Properties.Resources.delete;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 17);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnVarDeleteSelected_Click);
            // 
            // listVariables
            // 
            this.listVariables.AllowColumnReorder = true;
            this.listVariables.CheckBoxes = true;
            this.listVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVariables.DoubleClickActivation = false;
            this.listVariables.FullRowSelect = true;
            this.listVariables.GridLines = true;
            this.listVariables.Location = new System.Drawing.Point(0, 0);
            this.listVariables.Name = "listVariables";
            this.listVariables.Size = new System.Drawing.Size(677, 397);
            this.listVariables.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listVariables.TabIndex = 0;
            this.listVariables.UseCompatibleStateImageBehavior = false;
            this.listVariables.View = System.Windows.Forms.View.Details;
            this.listVariables.SubItemClicked += new CityTools.Components.SubItemEventHandler(this.listVariables_SubItemClicked);
            this.listVariables.SubItemEndEditing += new CityTools.Components.SubItemEndEditingEventHandler(this.listVariables_SubItemEndEditing);
            this.listVariables.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listVariables_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Variable Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Initial Value";
            this.columnHeader2.Width = 100;
            // 
            // txtStringChanger
            // 
            this.txtStringChanger.Location = new System.Drawing.Point(346, 266);
            this.txtStringChanger.Name = "txtStringChanger";
            this.txtStringChanger.Size = new System.Drawing.Size(180, 20);
            this.txtStringChanger.TabIndex = 2;
            this.txtStringChanger.Visible = false;
            // 
            // StringVariableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtStringChanger);
            this.Controls.Add(this.listVariables);
            this.Controls.Add(this.statusStrip1);
            this.Name = "StringVariableEditor";
            this.Size = new System.Drawing.Size(677, 419);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private ListViewEx listVariables;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox txtNewVariable;
        private System.Windows.Forms.ToolStripStatusLabel btnDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtStringChanger;
    }
}
