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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCharName = new System.Windows.Forms.TextBox();
            this.txtCharTitle = new System.Windows.Forms.TextBox();
            this.numCharExperience = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGlobalVars = new System.Windows.Forms.TabPage();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            this.tabEquipment = new System.Windows.Forms.TabPage();
            this.pbDisplay = new System.Windows.Forms.PictureBox();
            this.cbEquipmentShadow = new System.Windows.Forms.ComboBox();
            this.cbEquipmentPants = new System.Windows.Forms.ComboBox();
            this.cbEquipmentBody = new System.Windows.Forms.ComboBox();
            this.cbEquipmentFace = new System.Windows.Forms.ComboBox();
            this.cbEquipmentHeadgear = new System.Windows.Forms.ComboBox();
            this.cbEquipmentWeapon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCharExperience)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(158, 95);
            this.listBox1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numCharExperience);
            this.panel1.Controls.Add(this.txtCharTitle);
            this.panel1.Controls.Add(this.txtCharName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Location = new System.Drawing.Point(85, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 111);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(170, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Create New";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(264, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delete Selected";
            this.button2.UseVisualStyleBackColor = true;
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
            // txtCharName
            // 
            this.txtCharName.Location = new System.Drawing.Point(263, 31);
            this.txtCharName.Name = "txtCharName";
            this.txtCharName.Size = new System.Drawing.Size(96, 20);
            this.txtCharName.TabIndex = 5;
            // 
            // txtCharTitle
            // 
            this.txtCharTitle.Location = new System.Drawing.Point(263, 57);
            this.txtCharTitle.Name = "txtCharTitle";
            this.txtCharTitle.Size = new System.Drawing.Size(96, 20);
            this.txtCharTitle.TabIndex = 6;
            // 
            // numCharExperience
            // 
            this.numCharExperience.Location = new System.Drawing.Point(263, 83);
            this.numCharExperience.Name = "numCharExperience";
            this.numCharExperience.Size = new System.Drawing.Size(96, 20);
            this.numCharExperience.TabIndex = 7;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Character Name:";
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
            // pbDisplay
            // 
            this.pbDisplay.Location = new System.Drawing.Point(197, 5);
            this.pbDisplay.Name = "pbDisplay";
            this.pbDisplay.Size = new System.Drawing.Size(317, 179);
            this.pbDisplay.TabIndex = 0;
            this.pbDisplay.TabStop = false;
            // 
            // cbEquipmentShadow
            // 
            this.cbEquipmentShadow.FormattingEnabled = true;
            this.cbEquipmentShadow.Location = new System.Drawing.Point(70, 15);
            this.cbEquipmentShadow.Name = "cbEquipmentShadow";
            this.cbEquipmentShadow.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentShadow.TabIndex = 1;
            // 
            // cbEquipmentPants
            // 
            this.cbEquipmentPants.FormattingEnabled = true;
            this.cbEquipmentPants.Location = new System.Drawing.Point(70, 42);
            this.cbEquipmentPants.Name = "cbEquipmentPants";
            this.cbEquipmentPants.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentPants.TabIndex = 2;
            // 
            // cbEquipmentBody
            // 
            this.cbEquipmentBody.FormattingEnabled = true;
            this.cbEquipmentBody.Location = new System.Drawing.Point(70, 69);
            this.cbEquipmentBody.Name = "cbEquipmentBody";
            this.cbEquipmentBody.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentBody.TabIndex = 3;
            // 
            // cbEquipmentFace
            // 
            this.cbEquipmentFace.FormattingEnabled = true;
            this.cbEquipmentFace.Location = new System.Drawing.Point(70, 96);
            this.cbEquipmentFace.Name = "cbEquipmentFace";
            this.cbEquipmentFace.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentFace.TabIndex = 4;
            // 
            // cbEquipmentHeadgear
            // 
            this.cbEquipmentHeadgear.FormattingEnabled = true;
            this.cbEquipmentHeadgear.Location = new System.Drawing.Point(70, 123);
            this.cbEquipmentHeadgear.Name = "cbEquipmentHeadgear";
            this.cbEquipmentHeadgear.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentHeadgear.TabIndex = 5;
            // 
            // cbEquipmentWeapon
            // 
            this.cbEquipmentWeapon.FormattingEnabled = true;
            this.cbEquipmentWeapon.Location = new System.Drawing.Point(70, 150);
            this.cbEquipmentWeapon.Name = "cbEquipmentWeapon";
            this.cbEquipmentWeapon.Size = new System.Drawing.Size(121, 21);
            this.cbEquipmentWeapon.TabIndex = 6;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Pants";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Face";
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Weapon";
            // 
            // SaveFileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 500);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "SaveFileEditor";
            this.Text = "Save Editor [TESTING]";
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

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
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
    }
}