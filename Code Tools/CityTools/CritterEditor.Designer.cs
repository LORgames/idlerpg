namespace CityTools {
    partial class CritterEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CritterEditor));
            this.sptFullForm = new System.Windows.Forms.SplitContainer();
            this.treeAllCritters = new System.Windows.Forms.TreeView();
            this.ssTreeStatus = new System.Windows.Forms.StatusStrip();
            this.lblTreeInformation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolsMainTools = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listLoot = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.cbItemList = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.listAIType = new System.Windows.Forms.ListBox();
            this.cbAITypes = new System.Windows.Forms.ComboBox();
            this.ckbOneOfAKind = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numHealth = new System.Windows.Forms.NumericUpDown();
            this.numExperience = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMonsterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listGroups = new System.Windows.Forms.ListBox();
            this.cbAddGroup = new System.Windows.Forms.ComboBox();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCreateHumanoidCritter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateBeastCritter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDuplicate = new System.Windows.Forms.ToolStripButton();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnAddLoot = new System.Windows.Forms.Button();
            this.btnAddAIType = new System.Windows.Forms.Button();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.sptFullForm)).BeginInit();
            this.sptFullForm.Panel1.SuspendLayout();
            this.sptFullForm.Panel2.SuspendLayout();
            this.sptFullForm.SuspendLayout();
            this.ssTreeStatus.SuspendLayout();
            this.toolsMainTools.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).BeginInit();
            this.SuspendLayout();
            // 
            // sptFullForm
            // 
            this.sptFullForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sptFullForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sptFullForm.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sptFullForm.Location = new System.Drawing.Point(0, 0);
            this.sptFullForm.Name = "sptFullForm";
            // 
            // sptFullForm.Panel1
            // 
            this.sptFullForm.Panel1.Controls.Add(this.treeAllCritters);
            this.sptFullForm.Panel1.Controls.Add(this.ssTreeStatus);
            this.sptFullForm.Panel1.Controls.Add(this.toolsMainTools);
            // 
            // sptFullForm.Panel2
            // 
            this.sptFullForm.Panel2.Controls.Add(this.panel3);
            this.sptFullForm.Panel2.Controls.Add(this.panel2);
            this.sptFullForm.Panel2.Controls.Add(this.panel1);
            this.sptFullForm.Panel2.Controls.Add(this.ckbOneOfAKind);
            this.sptFullForm.Panel2.Controls.Add(this.label5);
            this.sptFullForm.Panel2.Controls.Add(this.numHealth);
            this.sptFullForm.Panel2.Controls.Add(this.numExperience);
            this.sptFullForm.Panel2.Controls.Add(this.label4);
            this.sptFullForm.Panel2.Controls.Add(this.txtMonsterName);
            this.sptFullForm.Panel2.Controls.Add(this.label2);
            this.sptFullForm.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sptFullForm.Size = new System.Drawing.Size(855, 520);
            this.sptFullForm.SplitterDistance = 164;
            this.sptFullForm.TabIndex = 0;
            this.sptFullForm.TabStop = false;
            // 
            // treeAllCritters
            // 
            this.treeAllCritters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAllCritters.Location = new System.Drawing.Point(0, 25);
            this.treeAllCritters.Name = "treeAllCritters";
            this.treeAllCritters.Size = new System.Drawing.Size(162, 471);
            this.treeAllCritters.TabIndex = 2;
            // 
            // ssTreeStatus
            // 
            this.ssTreeStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTreeInformation});
            this.ssTreeStatus.Location = new System.Drawing.Point(0, 496);
            this.ssTreeStatus.Name = "ssTreeStatus";
            this.ssTreeStatus.Size = new System.Drawing.Size(162, 22);
            this.ssTreeStatus.TabIndex = 1;
            this.ssTreeStatus.Text = "statusStrip1";
            // 
            // lblTreeInformation
            // 
            this.lblTreeInformation.Name = "lblTreeInformation";
            this.lblTreeInformation.Size = new System.Drawing.Size(81, 17);
            this.lblTreeInformation.Text = "Loading Tree...";
            // 
            // toolsMainTools
            // 
            this.toolsMainTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.btnDuplicate,
            this.toolStripTextBox1});
            this.toolsMainTools.Location = new System.Drawing.Point(0, 0);
            this.toolsMainTools.Name = "toolsMainTools";
            this.toolsMainTools.Size = new System.Drawing.Size(162, 25);
            this.toolsMainTools.TabIndex = 0;
            this.toolsMainTools.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(90, 21);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.listLoot);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnAddLoot);
            this.panel3.Controls.Add(this.cbItemList);
            this.panel3.Location = new System.Drawing.Point(408, 248);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(266, 248);
            this.panel3.TabIndex = 15;
            // 
            // listLoot
            // 
            this.listLoot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listLoot.GridLines = true;
            this.listLoot.LabelEdit = true;
            this.listLoot.Location = new System.Drawing.Point(3, 30);
            this.listLoot.Name = "listLoot";
            this.listLoot.Size = new System.Drawing.Size(258, 213);
            this.listLoot.TabIndex = 8;
            this.listLoot.UseCompatibleStateImageBehavior = false;
            this.listLoot.View = System.Windows.Forms.View.Details;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Loot";
            // 
            // cbItemList
            // 
            this.cbItemList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbItemList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbItemList.FormattingEnabled = true;
            this.cbItemList.Location = new System.Drawing.Point(58, 3);
            this.cbItemList.Name = "cbItemList";
            this.cbItemList.Size = new System.Drawing.Size(171, 21);
            this.cbItemList.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(8, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 248);
            this.panel2.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.listGroups);
            this.panel1.Controls.Add(this.btnAddGroup);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cbAddGroup);
            this.panel1.Controls.Add(this.btnAddAIType);
            this.panel1.Controls.Add(this.listAIType);
            this.panel1.Controls.Add(this.cbAITypes);
            this.panel1.Location = new System.Drawing.Point(408, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 204);
            this.panel1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "AI Types";
            // 
            // listAIType
            // 
            this.listAIType.FormattingEnabled = true;
            this.listAIType.Location = new System.Drawing.Point(4, 49);
            this.listAIType.Name = "listAIType";
            this.listAIType.Size = new System.Drawing.Size(125, 147);
            this.listAIType.TabIndex = 4;
            // 
            // cbAITypes
            // 
            this.cbAITypes.FormattingEnabled = true;
            this.cbAITypes.Location = new System.Drawing.Point(6, 22);
            this.cbAITypes.Name = "cbAITypes";
            this.cbAITypes.Size = new System.Drawing.Size(97, 21);
            this.cbAITypes.TabIndex = 5;
            // 
            // ckbOneOfAKind
            // 
            this.ckbOneOfAKind.AutoSize = true;
            this.ckbOneOfAKind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbOneOfAKind.Location = new System.Drawing.Point(525, 13);
            this.ckbOneOfAKind.Name = "ckbOneOfAKind";
            this.ckbOneOfAKind.Size = new System.Drawing.Size(94, 17);
            this.ckbOneOfAKind.TabIndex = 13;
            this.ckbOneOfAKind.Text = "One Of A Kind";
            this.ckbOneOfAKind.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Base Health:";
            // 
            // numHealth
            // 
            this.numHealth.Location = new System.Drawing.Point(415, 12);
            this.numHealth.Name = "numHealth";
            this.numHealth.Size = new System.Drawing.Size(104, 20);
            this.numHealth.TabIndex = 11;
            // 
            // numExperience
            // 
            this.numExperience.Location = new System.Drawing.Point(226, 12);
            this.numExperience.Name = "numExperience";
            this.numExperience.Size = new System.Drawing.Size(104, 20);
            this.numExperience.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(157, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Experience:";
            // 
            // txtMonsterName
            // 
            this.txtMonsterName.Location = new System.Drawing.Point(49, 11);
            this.txtMonsterName.Name = "txtMonsterName";
            this.txtMonsterName.Size = new System.Drawing.Size(102, 20);
            this.txtMonsterName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(220, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Groups";
            // 
            // listGroups
            // 
            this.listGroups.FormattingEnabled = true;
            this.listGroups.Location = new System.Drawing.Point(136, 50);
            this.listGroups.Name = "listGroups";
            this.listGroups.Size = new System.Drawing.Size(125, 147);
            this.listGroups.TabIndex = 4;
            // 
            // cbAddGroup
            // 
            this.cbAddGroup.FormattingEnabled = true;
            this.cbAddGroup.Location = new System.Drawing.Point(136, 23);
            this.cbAddGroup.Name = "cbAddGroup";
            this.cbAddGroup.Size = new System.Drawing.Size(98, 21);
            this.cbAddGroup.TabIndex = 5;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateHumanoidCritter,
            this.btnCreateBeastCritter});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "Create A New Critter";
            // 
            // btnCreateHumanoidCritter
            // 
            this.btnCreateHumanoidCritter.Image = global::CityTools.Properties.Resources.Critter_Editor___Humanoid;
            this.btnCreateHumanoidCritter.Name = "btnCreateHumanoidCritter";
            this.btnCreateHumanoidCritter.Size = new System.Drawing.Size(152, 22);
            this.btnCreateHumanoidCritter.Text = "Humanoid";
            this.btnCreateHumanoidCritter.Click += new System.EventHandler(this.btnCreateHumanoidCritter_Click);
            // 
            // btnCreateBeastCritter
            // 
            this.btnCreateBeastCritter.Image = global::CityTools.Properties.Resources.Critter_Editor___Monster;
            this.btnCreateBeastCritter.Name = "btnCreateBeastCritter";
            this.btnCreateBeastCritter.Size = new System.Drawing.Size(152, 22);
            this.btnCreateBeastCritter.Text = "Beast Man";
            this.btnCreateBeastCritter.Click += new System.EventHandler(this.btnCreateBeastCritter_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDuplicate.Image = ((System.Drawing.Image)(resources.GetObject("btnDuplicate.Image")));
            this.btnDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(23, 22);
            this.btnDuplicate.Text = "Duplicate Selected Critter";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGroup.Image")));
            this.btnAddGroup.Location = new System.Drawing.Point(240, 23);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(21, 21);
            this.btnAddGroup.TabIndex = 6;
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnAddLoot
            // 
            this.btnAddLoot.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLoot.Image")));
            this.btnAddLoot.Location = new System.Drawing.Point(235, 3);
            this.btnAddLoot.Name = "btnAddLoot";
            this.btnAddLoot.Size = new System.Drawing.Size(26, 21);
            this.btnAddLoot.TabIndex = 6;
            this.btnAddLoot.UseVisualStyleBackColor = true;
            this.btnAddLoot.Click += new System.EventHandler(this.btnAddLoot_Click);
            // 
            // btnAddAIType
            // 
            this.btnAddAIType.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAIType.Image")));
            this.btnAddAIType.Location = new System.Drawing.Point(108, 22);
            this.btnAddAIType.Name = "btnAddAIType";
            this.btnAddAIType.Size = new System.Drawing.Size(21, 21);
            this.btnAddAIType.TabIndex = 6;
            this.btnAddAIType.UseVisualStyleBackColor = true;
            this.btnAddAIType.Click += new System.EventHandler(this.btnAddAIType_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 94;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Min#";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Max#";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Drop%";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Set";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CritterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 520);
            this.Controls.Add(this.sptFullForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CritterEditor";
            this.Text = "CritterEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CritterEditor_FormClosing);
            this.sptFullForm.Panel1.ResumeLayout(false);
            this.sptFullForm.Panel1.PerformLayout();
            this.sptFullForm.Panel2.ResumeLayout(false);
            this.sptFullForm.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptFullForm)).EndInit();
            this.sptFullForm.ResumeLayout(false);
            this.ssTreeStatus.ResumeLayout(false);
            this.ssTreeStatus.PerformLayout();
            this.toolsMainTools.ResumeLayout(false);
            this.toolsMainTools.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptFullForm;
        private System.Windows.Forms.StatusStrip ssTreeStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblTreeInformation;
        private System.Windows.Forms.ToolStrip toolsMainTools;
        private System.Windows.Forms.ToolStripButton btnDuplicate;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.TextBox txtMonsterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddAIType;
        private System.Windows.Forms.ComboBox cbAITypes;
        private System.Windows.Forms.ListBox listAIType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numHealth;
        private System.Windows.Forms.NumericUpDown numExperience;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckbOneOfAKind;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeAllCritters;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddLoot;
        private System.Windows.Forms.ComboBox cbItemList;
        private System.Windows.Forms.ListView listLoot;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnCreateHumanoidCritter;
        private System.Windows.Forms.ToolStripMenuItem btnCreateBeastCritter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.ListBox listGroups;
        private System.Windows.Forms.ComboBox cbAddGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}