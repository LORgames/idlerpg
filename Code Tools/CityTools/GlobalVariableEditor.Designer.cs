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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnVarAddVariable = new System.Windows.Forms.ToolStripSplitButton();
            this.txtNewVariable = new System.Windows.Forms.ToolStripTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnVarDeleteSelected = new System.Windows.Forms.ToolStripDropDownButton();
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listVariables = new CityTools.Components.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabGroupVariableTypes.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGroupVariableTypes
            // 
            this.tabGroupVariableTypes.Controls.Add(this.tabPage1);
            this.tabGroupVariableTypes.Controls.Add(this.tabPage2);
            this.tabGroupVariableTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGroupVariableTypes.Location = new System.Drawing.Point(0, 0);
            this.tabGroupVariableTypes.Name = "tabGroupVariableTypes";
            this.tabGroupVariableTypes.SelectedIndex = 0;
            this.tabGroupVariableTypes.Size = new System.Drawing.Size(565, 501);
            this.tabGroupVariableTypes.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listVariables);
            this.tabPage1.Controls.Add(this.statusStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(557, 475);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Integers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVarAddVariable,
            this.btnVarDeleteSelected});
            this.statusStrip1.Location = new System.Drawing.Point(3, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(551, 22);
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
            this.btnVarAddVariable.Size = new System.Drawing.Size(99, 20);
            this.btnVarAddVariable.Text = "Add Variable";
            // 
            // txtNewVariable
            // 
            this.txtNewVariable.Name = "txtNewVariable";
            this.txtNewVariable.Size = new System.Drawing.Size(100, 21);
            this.txtNewVariable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNewVariable_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(557, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "String Table";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnVarDeleteSelected
            // 
            this.btnVarDeleteSelected.Image = global::CityTools.Properties.Resources.delete;
            this.btnVarDeleteSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVarDeleteSelected.Name = "btnVarDeleteSelected";
            this.btnVarDeleteSelected.Size = new System.Drawing.Size(111, 20);
            this.btnVarDeleteSelected.Text = "Delete Selected";
            this.btnVarDeleteSelected.Click += new System.EventHandler(this.btnVarDeleteSelected_Click);
            // 
            // typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem
            // 
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem.Name = "typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem";
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem.Size = new System.Drawing.Size(379, 22);
            this.typeTheNameOfTheNewVariableAndPressEnterToAddItToolStripMenuItem.Text = "Type the name of the new variable and press enter to add it.";
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
            this.listVariables.Location = new System.Drawing.Point(3, 3);
            this.listVariables.Name = "listVariables";
            this.listVariables.Size = new System.Drawing.Size(551, 447);
            this.listVariables.TabIndex = 0;
            this.listVariables.UseCompatibleStateImageBehavior = false;
            this.listVariables.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 395;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "InitialValue";
            this.columnHeader3.Width = 86;
            // 
            // GlobalVariableEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 501);
            this.Controls.Add(this.tabGroupVariableTypes);
            this.Name = "GlobalVariableEditor";
            this.Text = "Variable Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlobalVariableEditor_FormClosing);
            this.tabGroupVariableTypes.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
    }
}