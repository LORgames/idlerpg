﻿namespace CityTools {
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTreeInformation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnDuplicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddAIType = new System.Windows.Forms.Button();
            this.cbAddAIType = new System.Windows.Forms.ComboBox();
            this.lbxAIType = new System.Windows.Forms.ListBox();
            this.txtMonsterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCritterType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.treeAllCritters = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.sptFullForm)).BeginInit();
            this.sptFullForm.Panel1.SuspendLayout();
            this.sptFullForm.Panel2.SuspendLayout();
            this.sptFullForm.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.sptFullForm.Panel1.Controls.Add(this.statusStrip1);
            this.sptFullForm.Panel1.Controls.Add(this.toolStrip1);
            // 
            // sptFullForm.Panel2
            // 
            this.sptFullForm.Panel2.Controls.Add(this.panel2);
            this.sptFullForm.Panel2.Controls.Add(this.panel1);
            this.sptFullForm.Panel2.Controls.Add(this.checkBox1);
            this.sptFullForm.Panel2.Controls.Add(this.label5);
            this.sptFullForm.Panel2.Controls.Add(this.numericUpDown2);
            this.sptFullForm.Panel2.Controls.Add(this.numericUpDown1);
            this.sptFullForm.Panel2.Controls.Add(this.label4);
            this.sptFullForm.Panel2.Controls.Add(this.label3);
            this.sptFullForm.Panel2.Controls.Add(this.comboBox1);
            this.sptFullForm.Panel2.Controls.Add(this.txtMonsterName);
            this.sptFullForm.Panel2.Controls.Add(this.label2);
            this.sptFullForm.Panel2.Controls.Add(this.label1);
            this.sptFullForm.Panel2.Controls.Add(this.cbCritterType);
            this.sptFullForm.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sptFullForm.Size = new System.Drawing.Size(667, 520);
            this.sptFullForm.SplitterDistance = 164;
            this.sptFullForm.TabIndex = 0;
            this.sptFullForm.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTreeInformation});
            this.statusStrip1.Location = new System.Drawing.Point(0, 496);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(162, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTreeInformation
            // 
            this.lblTreeInformation.Name = "lblTreeInformation";
            this.lblTreeInformation.Size = new System.Drawing.Size(85, 17);
            this.lblTreeInformation.Text = "Loading Tree...";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnDuplicate,
            this.toolStripTextBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(162, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(23, 22);
            this.btnAddNew.Text = "New Critter";
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
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Location = new System.Drawing.Point(186, 67);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(94, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "One Of A Kind";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Health:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(252, 38);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(104, 20);
            this.numericUpDown2.TabIndex = 11;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(252, 12);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(104, 20);
            this.numericUpDown1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Experience:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Size:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(75, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(102, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // btnAddAIType
            // 
            this.btnAddAIType.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAIType.Image")));
            this.btnAddAIType.Location = new System.Drawing.Point(97, 3);
            this.btnAddAIType.Name = "btnAddAIType";
            this.btnAddAIType.Size = new System.Drawing.Size(26, 21);
            this.btnAddAIType.TabIndex = 6;
            this.btnAddAIType.UseVisualStyleBackColor = true;
            // 
            // cbAddAIType
            // 
            this.cbAddAIType.FormattingEnabled = true;
            this.cbAddAIType.Location = new System.Drawing.Point(3, 3);
            this.cbAddAIType.Name = "cbAddAIType";
            this.cbAddAIType.Size = new System.Drawing.Size(88, 21);
            this.cbAddAIType.TabIndex = 5;
            // 
            // lbxAIType
            // 
            this.lbxAIType.FormattingEnabled = true;
            this.lbxAIType.Location = new System.Drawing.Point(3, 27);
            this.lbxAIType.Name = "lbxAIType";
            this.lbxAIType.Size = new System.Drawing.Size(120, 95);
            this.lbxAIType.TabIndex = 4;
            // 
            // txtMonsterName
            // 
            this.txtMonsterName.Location = new System.Drawing.Point(75, 38);
            this.txtMonsterName.Name = "txtMonsterName";
            this.txtMonsterName.Size = new System.Drawing.Size(102, 20);
            this.txtMonsterName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Critter Type:";
            // 
            // cbCritterType
            // 
            this.cbCritterType.FormattingEnabled = true;
            this.cbCritterType.Items.AddRange(new object[] {
            "Humanoid",
            "Non-Human"});
            this.cbCritterType.Location = new System.Drawing.Point(75, 12);
            this.cbCritterType.Name = "cbCritterType";
            this.cbCritterType.Size = new System.Drawing.Size(102, 21);
            this.cbCritterType.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnAddAIType);
            this.panel1.Controls.Add(this.lbxAIType);
            this.panel1.Controls.Add(this.cbAddAIType);
            this.panel1.Location = new System.Drawing.Point(362, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 146);
            this.panel1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "AI Types";
            // 
            // treeAllCritters
            // 
            this.treeAllCritters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAllCritters.Location = new System.Drawing.Point(0, 25);
            this.treeAllCritters.Name = "treeAllCritters";
            this.treeAllCritters.Size = new System.Drawing.Size(162, 471);
            this.treeAllCritters.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(8, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 230);
            this.panel2.TabIndex = 15;
            // 
            // CritterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 520);
            this.Controls.Add(this.sptFullForm);
            this.Name = "CritterEditor";
            this.Text = "CritterEditor";
            this.sptFullForm.Panel1.ResumeLayout(false);
            this.sptFullForm.Panel1.PerformLayout();
            this.sptFullForm.Panel2.ResumeLayout(false);
            this.sptFullForm.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sptFullForm)).EndInit();
            this.sptFullForm.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptFullForm;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTreeInformation;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.ToolStripButton btnDuplicate;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCritterType;
        private System.Windows.Forms.TextBox txtMonsterName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddAIType;
        private System.Windows.Forms.ComboBox cbAddAIType;
        private System.Windows.Forms.ListBox lbxAIType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeAllCritters;
        private System.Windows.Forms.Panel panel2;
    }
}