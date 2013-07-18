namespace CityTools {
    partial class SaveFileEditor {
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
            this.listAllSaves = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetSlot3 = new System.Windows.Forms.Button();
            this.btnSetSlot2 = new System.Windows.Forms.Button();
            this.btnSetSlot1 = new System.Windows.Forms.Button();
            this.btnSetSlot0 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numCharExperience = new System.Windows.Forms.NumericUpDown();
            this.txtCharTitle = new System.Windows.Forms.TextBox();
            this.txtCharName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDeleteSelectedSaves = new System.Windows.Forms.Button();
            this.btnCreateNewSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGlobalVars = new System.Windows.Forms.TabPage();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.tabEquipment = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbEquipmentWeapon = new System.Windows.Forms.ComboBox();
            this.cbEquipmentHeadgear = new System.Windows.Forms.ComboBox();
            this.cbEquipmentFace = new System.Windows.Forms.ComboBox();
            this.cbEquipmentBody = new System.Windows.Forms.ComboBox();
            this.cbEquipmentPants = new System.Windows.Forms.ComboBox();
            this.cbEquipmentShadow = new System.Windows.Forms.ComboBox();
            this.pbDisplay = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCharExperience)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // listAllSaves
            // 
            this.listAllSaves.FormattingEnabled = true;
            this.listAllSaves.Location = new System.Drawing.Point(6, 5);
            this.listAllSaves.Name = "listAllSaves";
            this.listAllSaves.Size = new System.Drawing.Size(158, 95);
            this.listAllSaves.Sorted = true;
            this.listAllSaves.TabIndex = 1;
            this.listAllSaves.SelectedIndexChanged += new System.EventHandler(this.listAllSaves_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSetSlot3);
            this.panel1.Controls.Add(this.btnSetSlot2);
            this.panel1.Controls.Add(this.btnSetSlot1);
            this.panel1.Controls.Add(this.btnSetSlot0);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numCharExperience);
            this.panel1.Controls.Add(this.txtCharTitle);
            this.panel1.Controls.Add(this.txtCharName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDeleteSelectedSaves);
            this.panel1.Controls.Add(this.btnCreateNewSave);
            this.panel1.Controls.Add(this.listAllSaves);
            this.panel1.Location = new System.Drawing.Point(6, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 111);
            this.panel1.TabIndex = 2;
            // 
            // btnSetSlot3
            // 
            this.btnSetSlot3.Location = new System.Drawing.Point(429, 79);
            this.btnSetSlot3.Name = "btnSetSlot3";
            this.btnSetSlot3.Size = new System.Drawing.Size(92, 23);
            this.btnSetSlot3.TabIndex = 13;
            this.btnSetSlot3.Text = "Set As Slot 3";
            this.btnSetSlot3.UseVisualStyleBackColor = true;
            this.btnSetSlot3.Click += new System.EventHandler(this.btnSelectSlotClicked);
            // 
            // btnSetSlot2
            // 
            this.btnSetSlot2.Location = new System.Drawing.Point(430, 55);
            this.btnSetSlot2.Name = "btnSetSlot2";
            this.btnSetSlot2.Size = new System.Drawing.Size(92, 23);
            this.btnSetSlot2.TabIndex = 12;
            this.btnSetSlot2.Text = "Set As Slot 2";
            this.btnSetSlot2.UseVisualStyleBackColor = true;
            this.btnSetSlot2.Click += new System.EventHandler(this.btnSelectSlotClicked);
            // 
            // btnSetSlot1
            // 
            this.btnSetSlot1.Location = new System.Drawing.Point(430, 31);
            this.btnSetSlot1.Name = "btnSetSlot1";
            this.btnSetSlot1.Size = new System.Drawing.Size(92, 23);
            this.btnSetSlot1.TabIndex = 11;
            this.btnSetSlot1.Text = "Set As Slot 1";
            this.btnSetSlot1.UseVisualStyleBackColor = true;
            this.btnSetSlot1.Click += new System.EventHandler(this.btnSelectSlotClicked);
            // 
            // btnSetSlot0
            // 
            this.btnSetSlot0.Location = new System.Drawing.Point(429, 7);
            this.btnSetSlot0.Name = "btnSetSlot0";
            this.btnSetSlot0.Size = new System.Drawing.Size(92, 23);
            this.btnSetSlot0.TabIndex = 10;
            this.btnSetSlot0.Text = "Set As Slot 0";
            this.btnSetSlot0.UseVisualStyleBackColor = true;
            this.btnSetSlot0.Click += new System.EventHandler(this.btnSelectSlotClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Character Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Title:";
            // 
            // numCharExperience
            // 
            this.numCharExperience.Enabled = false;
            this.numCharExperience.Location = new System.Drawing.Point(263, 83);
            this.numCharExperience.Name = "numCharExperience";
            this.numCharExperience.Size = new System.Drawing.Size(96, 20);
            this.numCharExperience.TabIndex = 7;
            // 
            // txtCharTitle
            // 
            this.txtCharTitle.Enabled = false;
            this.txtCharTitle.Location = new System.Drawing.Point(263, 57);
            this.txtCharTitle.Name = "txtCharTitle";
            this.txtCharTitle.Size = new System.Drawing.Size(96, 20);
            this.txtCharTitle.TabIndex = 6;
            // 
            // txtCharName
            // 
            this.txtCharName.Enabled = false;
            this.txtCharName.Location = new System.Drawing.Point(263, 31);
            this.txtCharName.Name = "txtCharName";
            this.txtCharName.Size = new System.Drawing.Size(96, 20);
            this.txtCharName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Character Name:";
            // 
            // btnDeleteSelectedSaves
            // 
            this.btnDeleteSelectedSaves.Location = new System.Drawing.Point(264, 5);
            this.btnDeleteSelectedSaves.Name = "btnDeleteSelectedSaves";
            this.btnDeleteSelectedSaves.Size = new System.Drawing.Size(95, 23);
            this.btnDeleteSelectedSaves.TabIndex = 3;
            this.btnDeleteSelectedSaves.Text = "Delete Selected";
            this.btnDeleteSelectedSaves.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedSaves.Click += new System.EventHandler(this.btnDeleteSelectedSaves_Click);
            // 
            // btnCreateNewSave
            // 
            this.btnCreateNewSave.Location = new System.Drawing.Point(170, 5);
            this.btnCreateNewSave.Name = "btnCreateNewSave";
            this.btnCreateNewSave.Size = new System.Drawing.Size(88, 23);
            this.btnCreateNewSave.TabIndex = 2;
            this.btnCreateNewSave.Text = "Create New";
            this.btnCreateNewSave.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGlobalVars);
            this.tabControl1.Controls.Add(this.tabStatistics);
            this.tabControl1.Controls.Add(this.tabEquipment);
            this.tabControl1.Location = new System.Drawing.Point(6, 124);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(525, 364);
            this.tabControl1.TabIndex = 3;
            // 
            // tabGlobalVars
            // 
            this.tabGlobalVars.Location = new System.Drawing.Point(4, 22);
            this.tabGlobalVars.Name = "tabGlobalVars";
            this.tabGlobalVars.Padding = new System.Windows.Forms.Padding(3);
            this.tabGlobalVars.Size = new System.Drawing.Size(517, 338);
            this.tabGlobalVars.TabIndex = 0;
            this.tabGlobalVars.Text = "Global Vars";
            this.tabGlobalVars.UseVisualStyleBackColor = true;
            // 
            // tabStatistics
            // 
            this.tabStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistics.Size = new System.Drawing.Size(517, 338);
            this.tabStatistics.TabIndex = 1;
            this.tabStatistics.Text = "Statistics";
            this.tabStatistics.UseVisualStyleBackColor = true;
            // 
            // tabEquipment
            // 
            this.tabEquipment.Controls.Add(this.label9);
            this.tabEquipment.Controls.Add(this.label8);
            this.tabEquipment.Controls.Add(this.label7);
            this.tabEquipment.Controls.Add(this.label6);
            this.tabEquipment.Controls.Add(this.label5);
            this.tabEquipment.Controls.Add(this.label4);
            this.tabEquipment.Controls.Add(this.cbEquipmentWeapon);
            this.tabEquipment.Controls.Add(this.cbEquipmentHeadgear);
            this.tabEquipment.Controls.Add(this.cbEquipmentFace);
            this.tabEquipment.Controls.Add(this.cbEquipmentBody);
            this.tabEquipment.Controls.Add(this.cbEquipmentPants);
            this.tabEquipment.Controls.Add(this.cbEquipmentShadow);
            this.tabEquipment.Controls.Add(this.pbDisplay);
            this.tabEquipment.Location = new System.Drawing.Point(4, 22);
            this.tabEquipment.Name = "tabEquipment";
            this.tabEquipment.Size = new System.Drawing.Size(517, 338);
            this.tabEquipment.TabIndex = 2;
            this.tabEquipment.Text = "Equipment";
            this.tabEquipment.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Weapon";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Headgear";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Face";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Body";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pants";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Shadow";
            // 
            // cbEquipmentWeapon
            // 
            this.cbEquipmentWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentWeapon.FormattingEnabled = true;
            this.cbEquipmentWeapon.Location = new System.Drawing.Point(70, 150);
            this.cbEquipmentWeapon.Name = "cbEquipmentWeapon";
            this.cbEquipmentWeapon.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentWeapon.Sorted = true;
            this.cbEquipmentWeapon.TabIndex = 6;
            this.cbEquipmentWeapon.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // cbEquipmentHeadgear
            // 
            this.cbEquipmentHeadgear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentHeadgear.FormattingEnabled = true;
            this.cbEquipmentHeadgear.Location = new System.Drawing.Point(70, 123);
            this.cbEquipmentHeadgear.Name = "cbEquipmentHeadgear";
            this.cbEquipmentHeadgear.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentHeadgear.Sorted = true;
            this.cbEquipmentHeadgear.TabIndex = 5;
            this.cbEquipmentHeadgear.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // cbEquipmentFace
            // 
            this.cbEquipmentFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentFace.FormattingEnabled = true;
            this.cbEquipmentFace.Location = new System.Drawing.Point(70, 96);
            this.cbEquipmentFace.Name = "cbEquipmentFace";
            this.cbEquipmentFace.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentFace.Sorted = true;
            this.cbEquipmentFace.TabIndex = 4;
            this.cbEquipmentFace.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // cbEquipmentBody
            // 
            this.cbEquipmentBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentBody.FormattingEnabled = true;
            this.cbEquipmentBody.Location = new System.Drawing.Point(70, 69);
            this.cbEquipmentBody.Name = "cbEquipmentBody";
            this.cbEquipmentBody.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentBody.Sorted = true;
            this.cbEquipmentBody.TabIndex = 3;
            this.cbEquipmentBody.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // cbEquipmentPants
            // 
            this.cbEquipmentPants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentPants.FormattingEnabled = true;
            this.cbEquipmentPants.Location = new System.Drawing.Point(70, 42);
            this.cbEquipmentPants.Name = "cbEquipmentPants";
            this.cbEquipmentPants.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentPants.Sorted = true;
            this.cbEquipmentPants.TabIndex = 2;
            this.cbEquipmentPants.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // cbEquipmentShadow
            // 
            this.cbEquipmentShadow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipmentShadow.FormattingEnabled = true;
            this.cbEquipmentShadow.Location = new System.Drawing.Point(70, 15);
            this.cbEquipmentShadow.Name = "cbEquipmentShadow";
            this.cbEquipmentShadow.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentShadow.Sorted = true;
            this.cbEquipmentShadow.TabIndex = 1;
            this.cbEquipmentShadow.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // pbDisplay
            // 
            this.pbDisplay.Location = new System.Drawing.Point(197, 5);
            this.pbDisplay.Name = "pbDisplay";
            this.pbDisplay.Size = new System.Drawing.Size(317, 166);
            this.pbDisplay.TabIndex = 0;
            this.pbDisplay.TabStop = false;
            this.pbDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDisplay_Paint);
            // 
            // SaveFileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 500);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "SaveFileEditor";
            this.Text = "Save Editor";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCharExperience)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabEquipment.ResumeLayout(false);
            this.tabEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listAllSaves;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteSelectedSaves;
        private System.Windows.Forms.Button btnCreateNewSave;
        private System.Windows.Forms.TextBox txtCharTitle;
        private System.Windows.Forms.TextBox txtCharName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCharExperience;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGlobalVars;
        private System.Windows.Forms.TabPage tabStatistics;
        private System.Windows.Forms.TabPage tabEquipment;
        private System.Windows.Forms.PictureBox pbDisplay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEquipmentWeapon;
        private System.Windows.Forms.ComboBox cbEquipmentHeadgear;
        private System.Windows.Forms.ComboBox cbEquipmentFace;
        private System.Windows.Forms.ComboBox cbEquipmentBody;
        private System.Windows.Forms.ComboBox cbEquipmentPants;
        private System.Windows.Forms.ComboBox cbEquipmentShadow;
        private System.Windows.Forms.Button btnSetSlot3;
        private System.Windows.Forms.Button btnSetSlot2;
        private System.Windows.Forms.Button btnSetSlot1;
        private System.Windows.Forms.Button btnSetSlot0;
    }
}