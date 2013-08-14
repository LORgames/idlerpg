namespace CityTools {
    partial class GlobalVariableEditor {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabGroupVariableTypes = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listVariables = new CityTools.Components.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnVarAddVariable = new System.Windows.Forms.ToolStripSplitButton();
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewVariable = new System.Windows.Forms.ToolStripTextBox();
            this.btnVarDeleteSelected = new System.Windows.Forms.ToolStripDropDownButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtHiddenStringEditing = new System.Windows.Forms.TextBox();
            this.listString = new CityTools.Components.ListViewEx();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewStringName = new System.Windows.Forms.ToolStripTextBox();
            this.btnDeleteStrings = new System.Windows.Forms.ToolStripDropDownButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.numIntegerChanger = new System.Windows.Forms.NumericUpDown();
            this.tabGroupVariableTypes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIntegerChanger)).BeginInit();
            this.SuspendLayout();
            // 
            // tabGroupVariableTypes
            // 
            this.tabGroupVariableTypes.Controls.Add(this.tabPage1);
            this.tabGroupVariableTypes.Controls.Add(this.tabPage2);
            this.tabGroupVariableTypes.Controls.Add(this.tabPage3);
            this.tabGroupVariableTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGroupVariableTypes.ItemSize = new System.Drawing.Size(50, 18);
            this.tabGroupVariableTypes.Location = new System.Drawing.Point(0, 0);
            this.tabGroupVariableTypes.Name = "tabGroupVariableTypes";
            this.tabGroupVariableTypes.SelectedIndex = 0;
            this.tabGroupVariableTypes.Size = new System.Drawing.Size(743, 435);
            this.tabGroupVariableTypes.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numIntegerChanger);
            this.tabPage1.Controls.Add(this.listVariables);
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(735, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Integers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listVariables
            // 
            this.listVariables.AllowColumnReorder = true;
            this.listVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.listVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVariables.DoubleClickActivation = false;
            this.listVariables.FullRowSelect = true;
            this.listVariables.GridLines = true;
            this.listVariables.Location = new System.Drawing.Point(3, 3);
            this.listVariables.Name = "listVariables";
            this.listVariables.Size = new System.Drawing.Size(729, 381);
            this.listVariables.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listVariables.TabIndex = 0;
            this.listVariables.UseCompatibleStateImageBehavior = false;
            this.listVariables.View = System.Windows.Forms.View.Details;
            this.listVariables.SubItemClicked += new CityTools.Components.SubItemEventHandler(this.listVariables_SubItemClicked);
            this.listVariables.SubItemEndEditing += new CityTools.Components.SubItemEndEditingEventHandler(this.listVariables_SubItemEndEditing);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 234;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "InitialValue";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 148;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVarAddVariable,
            this.btnVarDeleteSelected});
            this.statusStrip1.Location = new System.Drawing.Point(3, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(729, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnVarAddVariable
            // 
            this.btnVarAddVariable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem,
            this.txtNewVariable});
            this.btnVarAddVariable.Image = global::CityTools.Properties.Resources.add;
            this.btnVarAddVariable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVarAddVariable.Name = "btnVarAddVariable";
            this.btnVarAddVariable.Size = new System.Drawing.Size(106, 20);
            this.btnVarAddVariable.Text = "Add Variable";
            // 
            // typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem
            // 
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem.Name = "typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem";
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem.Size = new System.Drawing.Size(389, 22);
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem.Text = "Type the name of the new variable and press enter to add it.";
            // 
            // txtNewVariable
            // 
            this.txtNewVariable.Name = "txtNewVariable";
            this.txtNewVariable.Size = new System.Drawing.Size(100, 23);
            this.txtNewVariable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewVariable_KeyDown);
            // 
            // btnVarDeleteSelected
            // 
            this.btnVarDeleteSelected.Image = global::CityTools.Properties.Resources.delete;
            this.btnVarDeleteSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVarDeleteSelected.Name = "btnVarDeleteSelected";
            this.btnVarDeleteSelected.Size = new System.Drawing.Size(116, 20);
            this.btnVarDeleteSelected.Text = "Delete Selected";
            this.btnVarDeleteSelected.Click += new System.EventHandler(this.btnVarDeleteSelected_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtHiddenStringEditing);
            this.tabPage2.Controls.Add(this.listString);
            this.tabPage2.Controls.Add(this.statusStrip2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(735, 409);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "String Table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtHiddenStringEditing
            // 
            this.txtHiddenStringEditing.Location = new System.Drawing.Point(363, 112);
            this.txtHiddenStringEditing.Name = "txtHiddenStringEditing";
            this.txtHiddenStringEditing.Size = new System.Drawing.Size(203, 20);
            this.txtHiddenStringEditing.TabIndex = 4;
            this.txtHiddenStringEditing.TabStop = false;
            this.txtHiddenStringEditing.Visible = false;
            // 
            // listString
            // 
            this.listString.AllowColumnReorder = true;
            this.listString.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.listString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listString.DoubleClickActivation = false;
            this.listString.FullRowSelect = true;
            this.listString.GridLines = true;
            this.listString.Location = new System.Drawing.Point(3, 3);
            this.listString.Name = "listString";
            this.listString.Size = new System.Drawing.Size(729, 381);
            this.listString.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listString.TabIndex = 0;
            this.listString.UseCompatibleStateImageBehavior = false;
            this.listString.View = System.Windows.Forms.View.Details;
            this.listString.SubItemClicked += new CityTools.Components.SubItemEventHandler(this.listString_SubItemClicked);
            this.listString.SubItemEndEditing += new CityTools.Components.SubItemEndEditingEventHandler(this.listString_SubItemEndEditing);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 144;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Value";
            this.columnHeader4.Width = 581;
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.btnDeleteStrings});
            this.statusStrip2.Location = new System.Drawing.Point(3, 384);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(729, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.txtNewStringName});
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
            // txtNewStringName
            // 
            this.txtNewStringName.Name = "txtNewStringName";
            this.txtNewStringName.Size = new System.Drawing.Size(100, 23);
            this.txtNewStringName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewStringName_KeyDown);
            // 
            // btnDeleteStrings
            // 
            this.btnDeleteStrings.Image = global::CityTools.Properties.Resources.delete;
            this.btnDeleteStrings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteStrings.Name = "btnDeleteStrings";
            this.btnDeleteStrings.Size = new System.Drawing.Size(116, 20);
            this.btnDeleteStrings.Text = "Delete Selected";
            this.btnDeleteStrings.Click += new System.EventHandler(this.btnDeleteStrings_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(735, 409);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Trigger Names";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // numIntegerChanger
            // 
            this.numIntegerChanger.Location = new System.Drawing.Point(429, 228);
            this.numIntegerChanger.Name = "numIntegerChanger";
            this.numIntegerChanger.Size = new System.Drawing.Size(120, 20);
            this.numIntegerChanger.TabIndex = 2;
            // 
            // GlobalVariableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 435);
            this.Controls.Add(this.tabGroupVariableTypes);
            this.Name = "GlobalVariableEditor";
            this.Text = "Variable Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlobalVariableEditor_FormClosing);
            this.tabGroupVariableTypes.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIntegerChanger)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabGroupVariableTypes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Components.ListViewEx listVariables;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSplitButton btnVarAddVariable;
        private System.Windows.Forms.ToolStripTextBox txtNewVariable;
        private System.Windows.Forms.ToolStripDropDownButton btnVarDeleteSelected;
        private System.Windows.Forms.ToolStripMenuItem typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem;
        private Components.ListViewEx listString;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox txtNewStringName;
        private System.Windows.Forms.ToolStripDropDownButton btnDeleteStrings;
        private System.Windows.Forms.TextBox txtHiddenStringEditing;
        private System.Windows.Forms.NumericUpDown numIntegerChanger;
        private System.Windows.Forms.TabPage tabPage3;
    }
}