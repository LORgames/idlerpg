﻿using CityTools.Components;

namespace CityTools {
    partial class EffectEditor {
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
            this.components = new System.ComponentModel.Container();
            this.treeView = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEffectName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.animationList = new CityTools.Components.AnimationList();
            this.cbAnimations = new System.Windows.Forms.ComboBox();
            this.lblAnimPnlName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ckbIsSolid = new System.Windows.Forms.CheckBox();
            this.ckbDrawDebug = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numOffsetY = new System.Windows.Forms.NumericUpDown();
            this.numOffsetX = new System.Windows.Forms.NumericUpDown();
            this.numSizeY = new System.Windows.Forms.NumericUpDown();
            this.numSizeX = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numLifetime = new System.Windows.Forms.NumericUpDown();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.scriptEffect = new CityTools.Components.ScriptBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLifetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(196, 450);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(196, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CityTools.Properties.Resources.add;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "btnCreateNewEffect";
            this.toolStripButton1.Click += new System.EventHandler(this.btnCreateNewEffect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // txtEffectName
            // 
            this.txtEffectName.Location = new System.Drawing.Point(53, 12);
            this.txtEffectName.Name = "txtEffectName";
            this.txtEffectName.Size = new System.Drawing.Size(116, 20);
            this.txtEffectName.TabIndex = 3;
            this.txtEffectName.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.animationList);
            this.panel1.Controls.Add(this.cbAnimations);
            this.panel1.Controls.Add(this.lblAnimPnlName);
            this.panel1.Location = new System.Drawing.Point(324, 321);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 142);
            this.panel1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "[Folder Import Drop]";
            this.label5.DragDrop += new System.Windows.Forms.DragEventHandler(this.Folder_DragDrop);
            this.label5.DragOver += new System.Windows.Forms.DragEventHandler(this.Folder_DragOver);
            // 
            // animationList
            // 
            this.animationList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animationList.Location = new System.Drawing.Point(3, 30);
            this.animationList.Name = "animationList";
            this.animationList.Size = new System.Drawing.Size(384, 106);
            this.animationList.TabIndex = 2;
            this.animationList.AnimationChanged += new CityTools.ChangedEventHandler(this.ValueChanged);
            // 
            // cbAnimations
            // 
            this.cbAnimations.FormattingEnabled = true;
            this.cbAnimations.Location = new System.Drawing.Point(67, 3);
            this.cbAnimations.Name = "cbAnimations";
            this.cbAnimations.Size = new System.Drawing.Size(162, 21);
            this.cbAnimations.TabIndex = 1;
            this.cbAnimations.TextChanged += new System.EventHandler(this.cbAnimations_TextUpdate);
            // 
            // lblAnimPnlName
            // 
            this.lblAnimPnlName.AutoSize = true;
            this.lblAnimPnlName.Location = new System.Drawing.Point(3, 6);
            this.lblAnimPnlName.Name = "lblAnimPnlName";
            this.lblAnimPnlName.Size = new System.Drawing.Size(58, 13);
            this.lblAnimPnlName.TabIndex = 0;
            this.lblAnimPnlName.Text = "Animations";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(324, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 303);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(53, 38);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(116, 21);
            this.cbGroup.TabIndex = 7;
            this.cbGroup.SelectedIndexChanged += new System.EventHandler(this.ValueChanged);
            this.cbGroup.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Group:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ckbIsSolid);
            this.splitContainer1.Panel2.Controls.Add(this.ckbDrawDebug);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.numOffsetY);
            this.splitContainer1.Panel2.Controls.Add(this.numOffsetX);
            this.splitContainer1.Panel2.Controls.Add(this.numSizeY);
            this.splitContainer1.Panel2.Controls.Add(this.numSizeX);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.numLifetime);
            this.splitContainer1.Panel2.Controls.Add(this.numSpeed);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.cbGroup);
            this.splitContainer1.Panel2.Controls.Add(this.txtEffectName);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.scriptEffect);
            this.splitContainer1.Panel2.Enabled = false;
            this.splitContainer1.Size = new System.Drawing.Size(926, 475);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 9;
            // 
            // ckbIsSolid
            // 
            this.ckbIsSolid.AutoSize = true;
            this.ckbIsSolid.Location = new System.Drawing.Point(11, 68);
            this.ckbIsSolid.Name = "ckbIsSolid";
            this.ckbIsSolid.Size = new System.Drawing.Size(49, 17);
            this.ckbIsSolid.TabIndex = 20;
            this.ckbIsSolid.Text = "Solid";
            this.ckbIsSolid.UseVisualStyleBackColor = true;
            this.ckbIsSolid.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // ckbDrawDebug
            // 
            this.ckbDrawDebug.AutoSize = true;
            this.ckbDrawDebug.Location = new System.Drawing.Point(625, 298);
            this.ckbDrawDebug.Name = "ckbDrawDebug";
            this.ckbDrawDebug.Size = new System.Drawing.Size(86, 17);
            this.ckbDrawDebug.TabIndex = 19;
            this.ckbDrawDebug.Text = "Draw Debug";
            this.ckbDrawDebug.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Collision Box Offset";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Collision Box Size";
            // 
            // numOffsetY
            // 
            this.numOffsetY.Location = new System.Drawing.Point(259, 93);
            this.numOffsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numOffsetY.Name = "numOffsetY";
            this.numOffsetY.Size = new System.Drawing.Size(59, 20);
            this.numOffsetY.TabIndex = 16;
            this.numOffsetY.ValueChanged += new System.EventHandler(this.BoxChanged);
            // 
            // numOffsetX
            // 
            this.numOffsetX.Location = new System.Drawing.Point(194, 93);
            this.numOffsetX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numOffsetX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numOffsetX.Name = "numOffsetX";
            this.numOffsetX.Size = new System.Drawing.Size(59, 20);
            this.numOffsetX.TabIndex = 15;
            this.numOffsetX.ValueChanged += new System.EventHandler(this.BoxChanged);
            // 
            // numSizeY
            // 
            this.numSizeY.Location = new System.Drawing.Point(259, 67);
            this.numSizeY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSizeY.Name = "numSizeY";
            this.numSizeY.Size = new System.Drawing.Size(59, 20);
            this.numSizeY.TabIndex = 14;
            this.numSizeY.ValueChanged += new System.EventHandler(this.BoxChanged);
            // 
            // numSizeX
            // 
            this.numSizeX.Location = new System.Drawing.Point(194, 67);
            this.numSizeX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSizeX.Name = "numSizeX";
            this.numSizeX.Size = new System.Drawing.Size(59, 20);
            this.numSizeX.TabIndex = 13;
            this.numSizeX.ValueChanged += new System.EventHandler(this.BoxChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(200, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Life (sec):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Speed:";
            // 
            // numLifetime
            // 
            this.numLifetime.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numLifetime.Location = new System.Drawing.Point(259, 39);
            this.numLifetime.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numLifetime.Name = "numLifetime";
            this.numLifetime.Size = new System.Drawing.Size(59, 20);
            this.numLifetime.TabIndex = 10;
            this.numLifetime.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numLifetime.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // numSpeed
            // 
            this.numSpeed.Location = new System.Drawing.Point(259, 13);
            this.numSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(59, 20);
            this.numSpeed.TabIndex = 9;
            this.numSpeed.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // scriptEffect
            // 
            this.scriptEffect.Location = new System.Drawing.Point(6, 119);
            this.scriptEffect.Name = "scriptEffect";
            this.scriptEffect.Script = "";
            this.scriptEffect.ScriptType = ToolCache.Scripting.ScriptTypes.Effect;
            this.scriptEffect.Size = new System.Drawing.Size(315, 344);
            this.scriptEffect.TabIndex = 5;
            this.scriptEffect.BeforeParse += new System.EventHandler<CityTools.Components.ScriptInfoArgs>(this.scriptEffect_BeforeParse);
            this.scriptEffect.ScriptUpdated += new System.EventHandler<System.EventArgs>(this.ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // EffectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 475);
            this.Controls.Add(this.splitContainer1);
            this.Name = "EffectEditor";
            this.Text = "Effect Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EffectEditor_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLifetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEffectName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbAnimations;
        private System.Windows.Forms.Label lblAnimPnlName;
        private AnimationList animationList;
        private ScriptBox scriptEffect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numLifetime;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numOffsetY;
        private System.Windows.Forms.NumericUpDown numOffsetX;
        private System.Windows.Forms.NumericUpDown numSizeY;
        private System.Windows.Forms.NumericUpDown numSizeX;
        private System.Windows.Forms.CheckBox ckbDrawDebug;
        private System.Windows.Forms.CheckBox ckbIsSolid;
    }
}