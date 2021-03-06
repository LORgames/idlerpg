﻿namespace CityTools {
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
            this.integerEditor1 = new CityTools.Components.DatabaseEditing.IntegerVariableEditor();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtHiddenStringEditing = new System.Windows.Forms.TextBox();
            this.listString = new CityTools.Components.ListViewEx();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.btnDelete = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewStringName = new System.Windows.Forms.ToolStripTextBox();
            this.btnDeleteStrings = new System.Windows.Forms.ToolStripDropDownButton();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.stringEditor1 = new CityTools.Components.DatabaseEditing.StringVariableEditor();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.scriptFunction = new CityTools.Components.ScriptBox();
            this.listFunctions = new System.Windows.Forms.ListBox();
            this.statusStripFunctions = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewFunctionName = new System.Windows.Forms.ToolStripTextBox();
            this.btnDeleteFunction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pnlUILibrary = new System.Windows.Forms.FlowLayoutPanel();
            this.lstLibraries = new System.Windows.Forms.ListBox();
            this.statusStripUILibraries = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewLibraryName = new System.Windows.Forms.ToolStripTextBox();
            this.btnDeleteLibraries = new System.Windows.Forms.ToolStripDropDownButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.databaseEditor1 = new CityTools.Components.DatabaseEditing.DatabaseEditor();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnVarAddVariable = new System.Windows.Forms.ToolStripSplitButton();
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNewVariable = new System.Windows.Forms.ToolStripTextBox();
            this.btnVarDeleteSelected = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnVarRepack = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabGroupVariableTypes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStripFunctions.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.statusStripUILibraries.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGroupVariableTypes
            // 
            this.tabGroupVariableTypes.Controls.Add(this.tabPage1);
            this.tabGroupVariableTypes.Controls.Add(this.tabPage2);
            this.tabGroupVariableTypes.Controls.Add(this.tabPage6);
            this.tabGroupVariableTypes.Controls.Add(this.tabPage3);
            this.tabGroupVariableTypes.Controls.Add(this.tabPage4);
            this.tabGroupVariableTypes.Controls.Add(this.tabPage5);
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
            this.tabPage1.Controls.Add(this.integerEditor1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(735, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Integer Variables";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // integerEditor1
            // 
            this.integerEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.integerEditor1.Location = new System.Drawing.Point(3, 3);
            this.integerEditor1.Name = "integerEditor1";
            this.integerEditor1.Size = new System.Drawing.Size(729, 403);
            this.integerEditor1.TabIndex = 0;
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
            this.btnDelete,
            this.btnDeleteStrings});
            this.statusStrip2.Location = new System.Drawing.Point(3, 384);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(729, 22);
            this.statusStrip2.TabIndex = 3;
            this.statusStrip2.Text = "statusStripStrings";
            // 
            // btnDelete
            // 
            this.btnDelete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.txtNewStringName});
            this.btnDelete.Image = global::CityTools.Properties.Resources.add;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 20);
            this.btnDelete.Text = "Add Variable";
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
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.stringEditor1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(735, 409);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "String Variables";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // stringEditor1
            // 
            this.stringEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stringEditor1.Location = new System.Drawing.Point(0, 0);
            this.stringEditor1.Name = "stringEditor1";
            this.stringEditor1.Size = new System.Drawing.Size(735, 409);
            this.stringEditor1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.txtFunctionName);
            this.tabPage3.Controls.Add(this.scriptFunction);
            this.tabPage3.Controls.Add(this.listFunctions);
            this.tabPage3.Controls.Add(this.statusStripFunctions);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(735, 409);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Functions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Function Name";
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Enabled = false;
            this.txtFunctionName.Location = new System.Drawing.Point(280, 3);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Size = new System.Drawing.Size(189, 20);
            this.txtFunctionName.TabIndex = 2;
            // 
            // scriptFunction
            // 
            this.scriptFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptFunction.Enabled = false;
            this.scriptFunction.ShowAdvancedButton = false;
            this.scriptFunction.Location = new System.Drawing.Point(189, 29);
            this.scriptFunction.Name = "scriptFunction";
            this.scriptFunction.Script = "";
            this.scriptFunction.ScriptType = ToolCache.Scripting.Types.ScriptTypes.Function;
            this.scriptFunction.Size = new System.Drawing.Size(546, 358);
            this.scriptFunction.TabIndex = 1;
            // 
            // listFunctions
            // 
            this.listFunctions.Dock = System.Windows.Forms.DockStyle.Left;
            this.listFunctions.FormattingEnabled = true;
            this.listFunctions.Location = new System.Drawing.Point(0, 0);
            this.listFunctions.Name = "listFunctions";
            this.listFunctions.Size = new System.Drawing.Size(189, 387);
            this.listFunctions.Sorted = true;
            this.listFunctions.TabIndex = 0;
            this.listFunctions.SelectedIndexChanged += new System.EventHandler(this.listFunctions_SelectedIndexChanged);
            // 
            // statusStripFunctions
            // 
            this.statusStripFunctions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton2,
            this.btnDeleteFunction});
            this.statusStripFunctions.Location = new System.Drawing.Point(0, 387);
            this.statusStripFunctions.Name = "statusStripFunctions";
            this.statusStripFunctions.Size = new System.Drawing.Size(735, 22);
            this.statusStripFunctions.TabIndex = 4;
            this.statusStripFunctions.Text = "statusStrip3";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.txtNewFunctionName});
            this.toolStripSplitButton2.Image = global::CityTools.Properties.Resources.add;
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(111, 20);
            this.toolStripSplitButton2.Text = "Add Function";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(405, 22);
            this.toolStripMenuItem2.Text = "Type the name of the new function and press enter to create it.";
            // 
            // txtNewFunctionName
            // 
            this.txtNewFunctionName.Name = "txtNewFunctionName";
            this.txtNewFunctionName.Size = new System.Drawing.Size(100, 23);
            this.txtNewFunctionName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewFunctionName_KeyDown);
            // 
            // btnDeleteFunction
            // 
            this.btnDeleteFunction.Image = global::CityTools.Properties.Resources.delete;
            this.btnDeleteFunction.Name = "btnDeleteFunction";
            this.btnDeleteFunction.Size = new System.Drawing.Size(103, 17);
            this.btnDeleteFunction.Text = "Delete Selected";
            this.btnDeleteFunction.Click += new System.EventHandler(this.btnDeleteFunction_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pnlUILibrary);
            this.tabPage4.Controls.Add(this.lstLibraries);
            this.tabPage4.Controls.Add(this.statusStripUILibraries);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(735, 409);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "UI Libraries";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pnlUILibrary
            // 
            this.pnlUILibrary.AllowDrop = true;
            this.pnlUILibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUILibrary.Location = new System.Drawing.Point(189, 0);
            this.pnlUILibrary.Name = "pnlUILibrary";
            this.pnlUILibrary.Size = new System.Drawing.Size(546, 387);
            this.pnlUILibrary.TabIndex = 6;
            this.pnlUILibrary.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlUILibrary_DragDrop);
            this.pnlUILibrary.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlUILibrary_DragOver);
            // 
            // lstLibraries
            // 
            this.lstLibraries.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstLibraries.FormattingEnabled = true;
            this.lstLibraries.Location = new System.Drawing.Point(0, 0);
            this.lstLibraries.Name = "lstLibraries";
            this.lstLibraries.Size = new System.Drawing.Size(189, 387);
            this.lstLibraries.Sorted = true;
            this.lstLibraries.TabIndex = 1;
            this.lstLibraries.SelectedIndexChanged += new System.EventHandler(this.lstLibraries_SelectedIndexChanged);
            // 
            // statusStripUILibraries
            // 
            this.statusStripUILibraries.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton3,
            this.btnDeleteLibraries});
            this.statusStripUILibraries.Location = new System.Drawing.Point(0, 387);
            this.statusStripUILibraries.Name = "statusStripUILibraries";
            this.statusStripUILibraries.Size = new System.Drawing.Size(735, 22);
            this.statusStripUILibraries.TabIndex = 5;
            this.statusStripUILibraries.Text = "statusStrip4";
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.txtNewLibraryName});
            this.toolStripSplitButton3.Image = global::CityTools.Properties.Resources.add;
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(100, 20);
            this.toolStripSplitButton3.Text = "Add Library";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(393, 22);
            this.toolStripMenuItem3.Text = "Type the name of the new library and press enter to create it.";
            // 
            // txtNewLibraryName
            // 
            this.txtNewLibraryName.Name = "txtNewLibraryName";
            this.txtNewLibraryName.Size = new System.Drawing.Size(100, 23);
            this.txtNewLibraryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewLibraryName_KeyDown);
            // 
            // btnDeleteLibraries
            // 
            this.btnDeleteLibraries.Image = global::CityTools.Properties.Resources.delete;
            this.btnDeleteLibraries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteLibraries.Name = "btnDeleteLibraries";
            this.btnDeleteLibraries.Size = new System.Drawing.Size(116, 20);
            this.btnDeleteLibraries.Text = "Delete Selected";
            this.btnDeleteLibraries.Click += new System.EventHandler(this.btnDeleteLibraries_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.databaseEditor1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(735, 409);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Databases";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // databaseEditor1
            // 
            this.databaseEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseEditor1.Location = new System.Drawing.Point(3, 3);
            this.databaseEditor1.Name = "databaseEditor1";
            this.databaseEditor1.Size = new System.Drawing.Size(729, 403);
            this.databaseEditor1.TabIndex = 0;
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
            // 
            // btnVarDeleteSelected
            // 
            this.btnVarDeleteSelected.Image = global::CityTools.Properties.Resources.delete;
            this.btnVarDeleteSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVarDeleteSelected.Name = "btnVarDeleteSelected";
            this.btnVarDeleteSelected.Size = new System.Drawing.Size(116, 20);
            this.btnVarDeleteSelected.Text = "Delete Selected";
            // 
            // btnVarRepack
            // 
            this.btnVarRepack.Image = global::CityTools.Properties.Resources.arrow_switch;
            this.btnVarRepack.Name = "btnVarRepack";
            this.btnVarRepack.Size = new System.Drawing.Size(61, 17);
            this.btnVarRepack.Text = "Repack";
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStripFunctions.ResumeLayout(false);
            this.statusStripFunctions.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.statusStripUILibraries.ResumeLayout(false);
            this.statusStripUILibraries.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabGroupVariableTypes;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripSplitButton btnVarAddVariable;
        private System.Windows.Forms.ToolStripTextBox txtNewVariable;
        private System.Windows.Forms.ToolStripDropDownButton btnVarDeleteSelected;
        private System.Windows.Forms.ToolStripMenuItem typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem;
        private Components.ListViewEx listString;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripSplitButton btnDelete;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox txtNewStringName;
        private System.Windows.Forms.ToolStripDropDownButton btnDeleteStrings;
        private System.Windows.Forms.TextBox txtHiddenStringEditing;
        private System.Windows.Forms.TabPage tabPage3;
        private Components.ScriptBox scriptFunction;
        private System.Windows.Forms.ListBox listFunctions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.StatusStrip statusStripFunctions;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripTextBox txtNewFunctionName;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lstLibraries;
        private System.Windows.Forms.StatusStrip statusStripUILibraries;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripTextBox txtNewLibraryName;
        private System.Windows.Forms.ToolStripDropDownButton btnDeleteLibraries;
        private System.Windows.Forms.FlowLayoutPanel pnlUILibrary;
        private System.Windows.Forms.TabPage tabPage5;
        private Components.DatabaseEditing.DatabaseEditor databaseEditor1;
        private System.Windows.Forms.ToolStripStatusLabel btnVarRepack;
        private System.Windows.Forms.TabPage tabPage6;
        private Components.DatabaseEditing.IntegerVariableEditor integerEditor1;
        private Components.DatabaseEditing.StringVariableEditor stringEditor1;
        private System.Windows.Forms.ToolStripStatusLabel btnDeleteFunction;
    }
}