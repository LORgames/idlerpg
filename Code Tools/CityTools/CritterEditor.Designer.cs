﻿using CityTools.Components;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CritterEditor));
            this.sptFullForm = new System.Windows.Forms.SplitContainer();
            this.treeAllCritters = new System.Windows.Forms.TreeView();
            this.toolsMainTools = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCreateHumanoidCritter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateBeastCritter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDuplicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.pnlBeast = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.numBeastHeadHeight = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.numBeastOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.numBeastOffsetY = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.numBeastRectHeight = new System.Windows.Forms.NumericUpDown();
            this.numBeastRectWidth = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numBeastFPS = new System.Windows.Forms.NumericUpDown();
            this.lblBeastDirection = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbBeastState = new System.Windows.Forms.ComboBox();
            this.btnBeastRight = new System.Windows.Forms.Button();
            this.btnBeastDown = new System.Windows.Forms.Button();
            this.btnBeastUp = new System.Windows.Forms.Button();
            this.btnBeastLeft = new System.Windows.Forms.Button();
            this.ccBeastAnimations = new CityTools.Components.AnimationList();
            this.numDefence = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numAttackRange = new System.Windows.Forms.NumericUpDown();
            this.txtMonsterName = new System.Windows.Forms.TextBox();
            this.listGroups = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.btnAddToSpawnList = new System.Windows.Forms.Button();
            this.cbAddGroup = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.pnlHumanoid = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbHumanoidWeapon = new System.Windows.Forms.ComboBox();
            this.cbHumanoidHeadgear = new System.Windows.Forms.ComboBox();
            this.cbHumanoidFace = new System.Windows.Forms.ComboBox();
            this.cbHumanoidBody = new System.Windows.Forms.ComboBox();
            this.cbHumanoidPants = new System.Windows.Forms.ComboBox();
            this.cbHumanoidShadow = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listAIType = new System.Windows.Forms.ListBox();
            this.btnAddAIType = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cbAITypes = new System.Windows.Forms.ComboBox();
            this.pbPreviewDisplay = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numRange = new System.Windows.Forms.NumericUpDown();
            this.numExperience = new System.Windows.Forms.NumericUpDown();
            this.numMovementSpeed = new System.Windows.Forms.NumericUpDown();
            this.numHealth = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.ckbOneOfAKind = new System.Windows.Forms.CheckBox();
            this.cbBaseGroup = new System.Windows.Forms.ComboBox();
            this.tabScripts = new System.Windows.Forms.TabPage();
            this.txtScript = new CityTools.Components.ScriptBox();
            this.tabLoot = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbItemList = new System.Windows.Forms.ComboBox();
            this.btnAddLoot = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.numListViewHidden = new System.Windows.Forms.NumericUpDown();
            this.listLoot = new CityTools.Components.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.redrawTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sptFullForm)).BeginInit();
            this.sptFullForm.Panel1.SuspendLayout();
            this.sptFullForm.Panel2.SuspendLayout();
            this.sptFullForm.SuspendLayout();
            this.toolsMainTools.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.pnlBeast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastHeadHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastRectHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastRectWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDefence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttackRange)).BeginInit();
            this.pnlHumanoid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovementSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHealth)).BeginInit();
            this.tabScripts.SuspendLayout();
            this.tabLoot.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numListViewHidden)).BeginInit();
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
            this.sptFullForm.Panel1.Controls.Add(this.toolsMainTools);
            // 
            // sptFullForm.Panel2
            // 
            this.sptFullForm.Panel2.Controls.Add(this.tabControl1);
            this.sptFullForm.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sptFullForm.Size = new System.Drawing.Size(824, 588);
            this.sptFullForm.SplitterDistance = 290;
            this.sptFullForm.TabIndex = 0;
            this.sptFullForm.TabStop = false;
            // 
            // treeAllCritters
            // 
            this.treeAllCritters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAllCritters.Location = new System.Drawing.Point(0, 25);
            this.treeAllCritters.Name = "treeAllCritters";
            this.treeAllCritters.Size = new System.Drawing.Size(288, 561);
            this.treeAllCritters.TabIndex = 2;
            this.treeAllCritters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeAllCritters_AfterSelect);
            // 
            // toolsMainTools
            // 
            this.toolsMainTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.btnDuplicate,
            this.toolStripTextBox1});
            this.toolsMainTools.Location = new System.Drawing.Point(0, 0);
            this.toolsMainTools.Name = "toolsMainTools";
            this.toolsMainTools.Size = new System.Drawing.Size(288, 25);
            this.toolsMainTools.TabIndex = 0;
            this.toolsMainTools.Text = "toolStrip1";
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
            this.btnCreateHumanoidCritter.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateHumanoidCritter.Image")));
            this.btnCreateHumanoidCritter.Name = "btnCreateHumanoidCritter";
            this.btnCreateHumanoidCritter.Size = new System.Drawing.Size(131, 22);
            this.btnCreateHumanoidCritter.Text = "Humanoid";
            this.btnCreateHumanoidCritter.Click += new System.EventHandler(this.btnCreateHumanoidCritter_Click);
            // 
            // btnCreateBeastCritter
            // 
            this.btnCreateBeastCritter.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateBeastCritter.Image")));
            this.btnCreateBeastCritter.Name = "btnCreateBeastCritter";
            this.btnCreateBeastCritter.Size = new System.Drawing.Size(131, 22);
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
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(90, 25);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.Controls.Add(this.tabScripts);
            this.tabControl1.Controls.Add(this.tabLoot);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 586);
            this.tabControl1.TabIndex = 24;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.pnlBeast);
            this.tabInfo.Controls.Add(this.numDefence);
            this.tabInfo.Controls.Add(this.label16);
            this.tabInfo.Controls.Add(this.label1);
            this.tabInfo.Controls.Add(this.numAttackRange);
            this.tabInfo.Controls.Add(this.txtMonsterName);
            this.tabInfo.Controls.Add(this.listGroups);
            this.tabInfo.Controls.Add(this.label7);
            this.tabInfo.Controls.Add(this.btnAddGroup);
            this.tabInfo.Controls.Add(this.btnAddToSpawnList);
            this.tabInfo.Controls.Add(this.cbAddGroup);
            this.tabInfo.Controls.Add(this.label22);
            this.tabInfo.Controls.Add(this.pnlHumanoid);
            this.tabInfo.Controls.Add(this.label6);
            this.tabInfo.Controls.Add(this.listAIType);
            this.tabInfo.Controls.Add(this.btnAddAIType);
            this.tabInfo.Controls.Add(this.label2);
            this.tabInfo.Controls.Add(this.label14);
            this.tabInfo.Controls.Add(this.cbAITypes);
            this.tabInfo.Controls.Add(this.pbPreviewDisplay);
            this.tabInfo.Controls.Add(this.label4);
            this.tabInfo.Controls.Add(this.numRange);
            this.tabInfo.Controls.Add(this.numExperience);
            this.tabInfo.Controls.Add(this.numMovementSpeed);
            this.tabInfo.Controls.Add(this.numHealth);
            this.tabInfo.Controls.Add(this.label5);
            this.tabInfo.Controls.Add(this.label15);
            this.tabInfo.Controls.Add(this.ckbOneOfAKind);
            this.tabInfo.Controls.Add(this.cbBaseGroup);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(520, 560);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Information";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // pnlBeast
            // 
            this.pnlBeast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlBeast.Controls.Add(this.label24);
            this.pnlBeast.Controls.Add(this.numBeastHeadHeight);
            this.pnlBeast.Controls.Add(this.label23);
            this.pnlBeast.Controls.Add(this.numBeastOffsetX);
            this.pnlBeast.Controls.Add(this.label21);
            this.pnlBeast.Controls.Add(this.numBeastOffsetY);
            this.pnlBeast.Controls.Add(this.label20);
            this.pnlBeast.Controls.Add(this.label19);
            this.pnlBeast.Controls.Add(this.numBeastRectHeight);
            this.pnlBeast.Controls.Add(this.numBeastRectWidth);
            this.pnlBeast.Controls.Add(this.label18);
            this.pnlBeast.Controls.Add(this.numBeastFPS);
            this.pnlBeast.Controls.Add(this.lblBeastDirection);
            this.pnlBeast.Controls.Add(this.label17);
            this.pnlBeast.Controls.Add(this.cbBeastState);
            this.pnlBeast.Controls.Add(this.btnBeastRight);
            this.pnlBeast.Controls.Add(this.btnBeastDown);
            this.pnlBeast.Controls.Add(this.btnBeastUp);
            this.pnlBeast.Controls.Add(this.btnBeastLeft);
            this.pnlBeast.Controls.Add(this.ccBeastAnimations);
            this.pnlBeast.Location = new System.Drawing.Point(197, 268);
            this.pnlBeast.Name = "pnlBeast";
            this.pnlBeast.Size = new System.Drawing.Size(226, 286);
            this.pnlBeast.TabIndex = 16;
            this.pnlBeast.Visible = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(0, 196);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 13);
            this.label24.TabIndex = 33;
            this.label24.Text = "HeadY:";
            // 
            // numBeastHeadHeight
            // 
            this.numBeastHeadHeight.Location = new System.Drawing.Point(47, 193);
            this.numBeastHeadHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBeastHeadHeight.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.numBeastHeadHeight.Name = "numBeastHeadHeight";
            this.numBeastHeadHeight.Size = new System.Drawing.Size(62, 20);
            this.numBeastHeadHeight.TabIndex = 32;
            this.numBeastHeadHeight.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(0, 247);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(45, 13);
            this.label23.TabIndex = 31;
            this.label23.Text = "OffsetX:";
            // 
            // numBeastOffsetX
            // 
            this.numBeastOffsetX.Location = new System.Drawing.Point(47, 245);
            this.numBeastOffsetX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBeastOffsetX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numBeastOffsetX.Name = "numBeastOffsetX";
            this.numBeastOffsetX.Size = new System.Drawing.Size(62, 20);
            this.numBeastOffsetX.TabIndex = 30;
            this.numBeastOffsetX.ValueChanged += new System.EventHandler(this.BeastRectValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(112, 247);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 13);
            this.label21.TabIndex = 29;
            this.label21.Text = "OffsetY:";
            // 
            // numBeastOffsetY
            // 
            this.numBeastOffsetY.Location = new System.Drawing.Point(159, 245);
            this.numBeastOffsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBeastOffsetY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numBeastOffsetY.Name = "numBeastOffsetY";
            this.numBeastOffsetY.Size = new System.Drawing.Size(62, 20);
            this.numBeastOffsetY.TabIndex = 28;
            this.numBeastOffsetY.ValueChanged += new System.EventHandler(this.BeastRectValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(112, 221);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 13);
            this.label20.TabIndex = 27;
            this.label20.Text = "Height:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(3, 221);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 13);
            this.label19.TabIndex = 26;
            this.label19.Text = "Width:";
            // 
            // numBeastRectHeight
            // 
            this.numBeastRectHeight.Location = new System.Drawing.Point(159, 219);
            this.numBeastRectHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBeastRectHeight.Name = "numBeastRectHeight";
            this.numBeastRectHeight.Size = new System.Drawing.Size(62, 20);
            this.numBeastRectHeight.TabIndex = 25;
            this.numBeastRectHeight.ValueChanged += new System.EventHandler(this.BeastRectValueChanged);
            // 
            // numBeastRectWidth
            // 
            this.numBeastRectWidth.Location = new System.Drawing.Point(47, 219);
            this.numBeastRectWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numBeastRectWidth.Name = "numBeastRectWidth";
            this.numBeastRectWidth.Size = new System.Drawing.Size(62, 20);
            this.numBeastRectWidth.TabIndex = 24;
            this.numBeastRectWidth.ValueChanged += new System.EventHandler(this.BeastRectValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(120, 195);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "FPS:";
            // 
            // numBeastFPS
            // 
            this.numBeastFPS.DecimalPlaces = 2;
            this.numBeastFPS.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numBeastFPS.Location = new System.Drawing.Point(159, 193);
            this.numBeastFPS.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numBeastFPS.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numBeastFPS.Name = "numBeastFPS";
            this.numBeastFPS.Size = new System.Drawing.Size(62, 20);
            this.numBeastFPS.TabIndex = 22;
            this.numBeastFPS.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numBeastFPS.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // lblBeastDirection
            // 
            this.lblBeastDirection.AutoSize = true;
            this.lblBeastDirection.Location = new System.Drawing.Point(180, 6);
            this.lblBeastDirection.Name = "lblBeastDirection";
            this.lblBeastDirection.Size = new System.Drawing.Size(25, 13);
            this.lblBeastDirection.TabIndex = 21;
            this.lblBeastDirection.Text = "Left";
            this.lblBeastDirection.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "State:";
            // 
            // cbBeastState
            // 
            this.cbBeastState.FormattingEnabled = true;
            this.cbBeastState.Location = new System.Drawing.Point(44, 3);
            this.cbBeastState.Name = "cbBeastState";
            this.cbBeastState.Size = new System.Drawing.Size(106, 21);
            this.cbBeastState.TabIndex = 19;
            // 
            // btnBeastRight
            // 
            this.btnBeastRight.AllowDrop = true;
            this.btnBeastRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBeastRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBeastRight.Location = new System.Drawing.Point(59, 134);
            this.btnBeastRight.Name = "btnBeastRight";
            this.btnBeastRight.Size = new System.Drawing.Size(50, 52);
            this.btnBeastRight.TabIndex = 18;
            this.btnBeastRight.Text = "Right";
            this.btnBeastRight.UseVisualStyleBackColor = false;
            this.btnBeastRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnBeastDirection_DragDrop);
            this.btnBeastRight.DragOver += new System.Windows.Forms.DragEventHandler(this.btnBeastDirection_DragEnter);
            this.btnBeastRight.MouseEnter += new System.EventHandler(this.btnBeastDirection_MouseEnter);
            // 
            // btnBeastDown
            // 
            this.btnBeastDown.AllowDrop = true;
            this.btnBeastDown.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBeastDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBeastDown.Location = new System.Drawing.Point(171, 134);
            this.btnBeastDown.Name = "btnBeastDown";
            this.btnBeastDown.Size = new System.Drawing.Size(50, 52);
            this.btnBeastDown.TabIndex = 17;
            this.btnBeastDown.Text = "Down";
            this.btnBeastDown.UseVisualStyleBackColor = false;
            this.btnBeastDown.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnBeastDirection_DragDrop);
            this.btnBeastDown.DragOver += new System.Windows.Forms.DragEventHandler(this.btnBeastDirection_DragEnter);
            this.btnBeastDown.MouseEnter += new System.EventHandler(this.btnBeastDirection_MouseEnter);
            // 
            // btnBeastUp
            // 
            this.btnBeastUp.AllowDrop = true;
            this.btnBeastUp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBeastUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBeastUp.Location = new System.Drawing.Point(115, 134);
            this.btnBeastUp.Name = "btnBeastUp";
            this.btnBeastUp.Size = new System.Drawing.Size(50, 52);
            this.btnBeastUp.TabIndex = 16;
            this.btnBeastUp.Text = "Up";
            this.btnBeastUp.UseVisualStyleBackColor = false;
            this.btnBeastUp.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnBeastDirection_DragDrop);
            this.btnBeastUp.DragOver += new System.Windows.Forms.DragEventHandler(this.btnBeastDirection_DragEnter);
            this.btnBeastUp.MouseEnter += new System.EventHandler(this.btnBeastDirection_MouseEnter);
            // 
            // btnBeastLeft
            // 
            this.btnBeastLeft.AllowDrop = true;
            this.btnBeastLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBeastLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBeastLeft.Location = new System.Drawing.Point(3, 134);
            this.btnBeastLeft.Name = "btnBeastLeft";
            this.btnBeastLeft.Size = new System.Drawing.Size(50, 52);
            this.btnBeastLeft.TabIndex = 15;
            this.btnBeastLeft.Text = "Left";
            this.btnBeastLeft.UseVisualStyleBackColor = false;
            this.btnBeastLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnBeastDirection_DragDrop);
            this.btnBeastLeft.DragOver += new System.Windows.Forms.DragEventHandler(this.btnBeastDirection_DragEnter);
            this.btnBeastLeft.MouseEnter += new System.EventHandler(this.btnBeastDirection_MouseEnter);
            // 
            // ccBeastAnimations
            // 
            this.ccBeastAnimations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccBeastAnimations.Location = new System.Drawing.Point(3, 28);
            this.ccBeastAnimations.Name = "ccBeastAnimations";
            this.ccBeastAnimations.Size = new System.Drawing.Size(218, 103);
            this.ccBeastAnimations.TabIndex = 0;
            this.ccBeastAnimations.AnimationChanged += new CityTools.ChangedEventHandler(this.ccBeastAnimations_AnimationChanged);
            // 
            // numDefence
            // 
            this.numDefence.Location = new System.Drawing.Point(87, 83);
            this.numDefence.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numDefence.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numDefence.Name = "numDefence";
            this.numDefence.Size = new System.Drawing.Size(104, 20);
            this.numDefence.TabIndex = 26;
            this.numDefence.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numDefence.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(30, 85);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Defence:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Attack Range";
            // 
            // numAttackRange
            // 
            this.numAttackRange.Location = new System.Drawing.Point(87, 213);
            this.numAttackRange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAttackRange.Name = "numAttackRange";
            this.numAttackRange.Size = new System.Drawing.Size(104, 20);
            this.numAttackRange.TabIndex = 24;
            this.numAttackRange.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAttackRange.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // txtMonsterName
            // 
            this.txtMonsterName.Location = new System.Drawing.Point(87, 6);
            this.txtMonsterName.Name = "txtMonsterName";
            this.txtMonsterName.Size = new System.Drawing.Size(102, 20);
            this.txtMonsterName.TabIndex = 3;
            this.txtMonsterName.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // listGroups
            // 
            this.listGroups.FormattingEnabled = true;
            this.listGroups.Location = new System.Drawing.Point(6, 434);
            this.listGroups.Name = "listGroups";
            this.listGroups.Size = new System.Drawing.Size(185, 82);
            this.listGroups.TabIndex = 4;
            this.listGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listAIType_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 387);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Factions";
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnAddGroup.Image")));
            this.btnAddGroup.Location = new System.Drawing.Point(170, 403);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(21, 21);
            this.btnAddGroup.TabIndex = 6;
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // btnAddToSpawnList
            // 
            this.btnAddToSpawnList.Location = new System.Drawing.Point(6, 522);
            this.btnAddToSpawnList.Name = "btnAddToSpawnList";
            this.btnAddToSpawnList.Size = new System.Drawing.Size(185, 23);
            this.btnAddToSpawnList.TabIndex = 19;
            this.btnAddToSpawnList.Text = "Add To Current Spawn Region";
            this.btnAddToSpawnList.UseVisualStyleBackColor = true;
            this.btnAddToSpawnList.Click += new System.EventHandler(this.btnAddToSpawnList_Click);
            // 
            // cbAddGroup
            // 
            this.cbAddGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbAddGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAddGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddGroup.FormattingEnabled = true;
            this.cbAddGroup.Location = new System.Drawing.Point(6, 403);
            this.cbAddGroup.Name = "cbAddGroup";
            this.cbAddGroup.Size = new System.Drawing.Size(158, 21);
            this.cbAddGroup.TabIndex = 5;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(18, 189);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 13);
            this.label22.TabIndex = 23;
            this.label22.Text = "Alert Range";
            // 
            // pnlHumanoid
            // 
            this.pnlHumanoid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlHumanoid.Controls.Add(this.label13);
            this.pnlHumanoid.Controls.Add(this.label12);
            this.pnlHumanoid.Controls.Add(this.label11);
            this.pnlHumanoid.Controls.Add(this.label10);
            this.pnlHumanoid.Controls.Add(this.label9);
            this.pnlHumanoid.Controls.Add(this.label8);
            this.pnlHumanoid.Controls.Add(this.cbHumanoidWeapon);
            this.pnlHumanoid.Controls.Add(this.cbHumanoidHeadgear);
            this.pnlHumanoid.Controls.Add(this.cbHumanoidFace);
            this.pnlHumanoid.Controls.Add(this.cbHumanoidBody);
            this.pnlHumanoid.Controls.Add(this.cbHumanoidPants);
            this.pnlHumanoid.Controls.Add(this.cbHumanoidShadow);
            this.pnlHumanoid.Location = new System.Drawing.Point(203, 274);
            this.pnlHumanoid.Name = "pnlHumanoid";
            this.pnlHumanoid.Size = new System.Drawing.Size(226, 252);
            this.pnlHumanoid.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 208);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Weapon";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Headgear";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Face";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Body";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Legs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Shadow";
            // 
            // cbHumanoidWeapon
            // 
            this.cbHumanoidWeapon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHumanoidWeapon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHumanoidWeapon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHumanoidWeapon.FormattingEnabled = true;
            this.cbHumanoidWeapon.Location = new System.Drawing.Point(6, 224);
            this.cbHumanoidWeapon.Name = "cbHumanoidWeapon";
            this.cbHumanoidWeapon.Size = new System.Drawing.Size(217, 21);
            this.cbHumanoidWeapon.TabIndex = 7;
            this.cbHumanoidWeapon.SelectedIndexChanged += new System.EventHandler(this.ChangedEquipment);
            // 
            // cbHumanoidHeadgear
            // 
            this.cbHumanoidHeadgear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHumanoidHeadgear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHumanoidHeadgear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHumanoidHeadgear.FormattingEnabled = true;
            this.cbHumanoidHeadgear.Location = new System.Drawing.Point(6, 103);
            this.cbHumanoidHeadgear.Name = "cbHumanoidHeadgear";
            this.cbHumanoidHeadgear.Size = new System.Drawing.Size(217, 21);
            this.cbHumanoidHeadgear.TabIndex = 6;
            this.cbHumanoidHeadgear.SelectedIndexChanged += new System.EventHandler(this.ChangedEquipment);
            // 
            // cbHumanoidFace
            // 
            this.cbHumanoidFace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHumanoidFace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHumanoidFace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHumanoidFace.FormattingEnabled = true;
            this.cbHumanoidFace.Location = new System.Drawing.Point(6, 184);
            this.cbHumanoidFace.Name = "cbHumanoidFace";
            this.cbHumanoidFace.Size = new System.Drawing.Size(217, 21);
            this.cbHumanoidFace.TabIndex = 5;
            this.cbHumanoidFace.SelectedIndexChanged += new System.EventHandler(this.ChangedEquipment);
            // 
            // cbHumanoidBody
            // 
            this.cbHumanoidBody.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHumanoidBody.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHumanoidBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHumanoidBody.FormattingEnabled = true;
            this.cbHumanoidBody.Location = new System.Drawing.Point(6, 63);
            this.cbHumanoidBody.Name = "cbHumanoidBody";
            this.cbHumanoidBody.Size = new System.Drawing.Size(217, 21);
            this.cbHumanoidBody.TabIndex = 4;
            this.cbHumanoidBody.SelectedIndexChanged += new System.EventHandler(this.ChangedEquipment);
            // 
            // cbHumanoidPants
            // 
            this.cbHumanoidPants.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHumanoidPants.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHumanoidPants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHumanoidPants.FormattingEnabled = true;
            this.cbHumanoidPants.Location = new System.Drawing.Point(6, 144);
            this.cbHumanoidPants.Name = "cbHumanoidPants";
            this.cbHumanoidPants.Size = new System.Drawing.Size(217, 21);
            this.cbHumanoidPants.TabIndex = 3;
            this.cbHumanoidPants.SelectedIndexChanged += new System.EventHandler(this.ChangedEquipment);
            // 
            // cbHumanoidShadow
            // 
            this.cbHumanoidShadow.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbHumanoidShadow.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbHumanoidShadow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHumanoidShadow.FormattingEnabled = true;
            this.cbHumanoidShadow.Location = new System.Drawing.Point(6, 23);
            this.cbHumanoidShadow.Name = "cbHumanoidShadow";
            this.cbHumanoidShadow.Size = new System.Drawing.Size(217, 21);
            this.cbHumanoidShadow.TabIndex = 2;
            this.cbHumanoidShadow.SelectedIndexChanged += new System.EventHandler(this.ChangedEquipment);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "AI Types";
            // 
            // listAIType
            // 
            this.listAIType.FormattingEnabled = true;
            this.listAIType.Location = new System.Drawing.Point(6, 302);
            this.listAIType.Name = "listAIType";
            this.listAIType.Size = new System.Drawing.Size(185, 82);
            this.listAIType.TabIndex = 4;
            this.listAIType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listAIType_KeyDown);
            // 
            // btnAddAIType
            // 
            this.btnAddAIType.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAIType.Image")));
            this.btnAddAIType.Location = new System.Drawing.Point(170, 268);
            this.btnAddAIType.Name = "btnAddAIType";
            this.btnAddAIType.Size = new System.Drawing.Size(21, 21);
            this.btnAddAIType.TabIndex = 6;
            this.btnAddAIType.UseVisualStyleBackColor = true;
            this.btnAddAIType.Click += new System.EventHandler(this.btnAddAIType_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 22;
            this.label14.Text = "Movement";
            // 
            // cbAITypes
            // 
            this.cbAITypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAITypes.FormattingEnabled = true;
            this.cbAITypes.Location = new System.Drawing.Point(6, 268);
            this.cbAITypes.Name = "cbAITypes";
            this.cbAITypes.Size = new System.Drawing.Size(158, 21);
            this.cbAITypes.TabIndex = 5;
            // 
            // pbPreviewDisplay
            // 
            this.pbPreviewDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreviewDisplay.Location = new System.Drawing.Point(197, 6);
            this.pbPreviewDisplay.Name = "pbPreviewDisplay";
            this.pbPreviewDisplay.Size = new System.Drawing.Size(317, 259);
            this.pbPreviewDisplay.TabIndex = 0;
            this.pbPreviewDisplay.TabStop = false;
            this.pbPreviewDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPreviewDisplay_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Experience:";
            // 
            // numRange
            // 
            this.numRange.Location = new System.Drawing.Point(87, 187);
            this.numRange.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numRange.Name = "numRange";
            this.numRange.Size = new System.Drawing.Size(104, 20);
            this.numRange.TabIndex = 21;
            this.numRange.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numRange.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // numExperience
            // 
            this.numExperience.Location = new System.Drawing.Point(87, 31);
            this.numExperience.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numExperience.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numExperience.Name = "numExperience";
            this.numExperience.Size = new System.Drawing.Size(104, 20);
            this.numExperience.TabIndex = 10;
            this.numExperience.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numExperience.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // numMovementSpeed
            // 
            this.numMovementSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMovementSpeed.Location = new System.Drawing.Point(87, 161);
            this.numMovementSpeed.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numMovementSpeed.Name = "numMovementSpeed";
            this.numMovementSpeed.Size = new System.Drawing.Size(104, 20);
            this.numMovementSpeed.TabIndex = 20;
            this.numMovementSpeed.Value = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.numMovementSpeed.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // numHealth
            // 
            this.numHealth.Location = new System.Drawing.Point(87, 57);
            this.numHealth.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numHealth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numHealth.Name = "numHealth";
            this.numHealth.Size = new System.Drawing.Size(104, 20);
            this.numHealth.TabIndex = 11;
            this.numHealth.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numHealth.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Base Health:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Editor Group:";
            // 
            // ckbOneOfAKind
            // 
            this.ckbOneOfAKind.AutoSize = true;
            this.ckbOneOfAKind.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbOneOfAKind.Location = new System.Drawing.Point(6, 138);
            this.ckbOneOfAKind.Name = "ckbOneOfAKind";
            this.ckbOneOfAKind.Size = new System.Drawing.Size(94, 17);
            this.ckbOneOfAKind.TabIndex = 13;
            this.ckbOneOfAKind.Text = "One Of A Kind";
            this.ckbOneOfAKind.UseVisualStyleBackColor = true;
            this.ckbOneOfAKind.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // cbBaseGroup
            // 
            this.cbBaseGroup.FormattingEnabled = true;
            this.cbBaseGroup.Location = new System.Drawing.Point(87, 109);
            this.cbBaseGroup.Name = "cbBaseGroup";
            this.cbBaseGroup.Size = new System.Drawing.Size(104, 21);
            this.cbBaseGroup.TabIndex = 17;
            this.cbBaseGroup.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // tabScripts
            // 
            this.tabScripts.Controls.Add(this.txtScript);
            this.tabScripts.Location = new System.Drawing.Point(4, 22);
            this.tabScripts.Name = "tabScripts";
            this.tabScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabScripts.Size = new System.Drawing.Size(520, 560);
            this.tabScripts.TabIndex = 1;
            this.tabScripts.Text = "Scripts";
            this.tabScripts.UseVisualStyleBackColor = true;
            // 
            // txtScript
            // 
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(3, 3);
            this.txtScript.Name = "txtScript";
            this.txtScript.Script = "";
            this.txtScript.ScriptType = ToolCache.Scripting.Types.ScriptTypes.Critter;
            this.txtScript.Size = new System.Drawing.Size(514, 554);
            this.txtScript.TabIndex = 19;
            this.txtScript.BeforeParse += new System.EventHandler<CityTools.Components.ScriptInfoArgs>(this.txtScript_BeforeParse);
            this.txtScript.ScriptUpdated += new System.EventHandler<System.EventArgs>(this.ValueChanged);
            // 
            // tabLoot
            // 
            this.tabLoot.Controls.Add(this.tableLayoutPanel2);
            this.tabLoot.Location = new System.Drawing.Point(4, 22);
            this.tabLoot.Name = "tabLoot";
            this.tabLoot.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoot.Size = new System.Drawing.Size(520, 560);
            this.tabLoot.TabIndex = 2;
            this.tabLoot.Text = "Loot";
            this.tabLoot.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(514, 554);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbItemList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddLoot, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(508, 29);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 29);
            this.label3.TabIndex = 7;
            this.label3.Text = "Loot";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbItemList
            // 
            this.cbItemList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbItemList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbItemList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItemList.FormattingEnabled = true;
            this.cbItemList.Location = new System.Drawing.Point(38, 3);
            this.cbItemList.Name = "cbItemList";
            this.cbItemList.Size = new System.Drawing.Size(432, 21);
            this.cbItemList.TabIndex = 5;
            // 
            // btnAddLoot
            // 
            this.btnAddLoot.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLoot.Image")));
            this.btnAddLoot.Location = new System.Drawing.Point(476, 3);
            this.btnAddLoot.Name = "btnAddLoot";
            this.btnAddLoot.Size = new System.Drawing.Size(26, 21);
            this.btnAddLoot.TabIndex = 6;
            this.btnAddLoot.UseVisualStyleBackColor = true;
            this.btnAddLoot.Click += new System.EventHandler(this.btnAddLoot_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.numListViewHidden);
            this.panel3.Controls.Add(this.listLoot);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(508, 513);
            this.panel3.TabIndex = 15;
            // 
            // numListViewHidden
            // 
            this.numListViewHidden.Location = new System.Drawing.Point(87, 80);
            this.numListViewHidden.Name = "numListViewHidden";
            this.numListViewHidden.Size = new System.Drawing.Size(120, 20);
            this.numListViewHidden.TabIndex = 19;
            this.numListViewHidden.TabStop = false;
            this.numListViewHidden.Visible = false;
            // 
            // listLoot
            // 
            this.listLoot.AllowColumnReorder = true;
            this.listLoot.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listLoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLoot.DoubleClickActivation = false;
            this.listLoot.FullRowSelect = true;
            this.listLoot.GridLines = true;
            this.listLoot.LabelEdit = true;
            this.listLoot.Location = new System.Drawing.Point(0, 0);
            this.listLoot.Name = "listLoot";
            this.listLoot.Size = new System.Drawing.Size(508, 513);
            this.listLoot.TabIndex = 8;
            this.listLoot.UseCompatibleStateImageBehavior = false;
            this.listLoot.View = System.Windows.Forms.View.Details;
            this.listLoot.SubItemClicked += new CityTools.Components.SubItemEventHandler(this.listLoot_SubItemClicked);
            this.listLoot.SubItemEndEditing += new CityTools.Components.SubItemEndEditingEventHandler(this.listLoot_SubItemEndEditing);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 106;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Min#";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Max#";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 44;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Drop%";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 47;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Set";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 32;
            // 
            // redrawTimer
            // 
            this.redrawTimer.Enabled = true;
            this.redrawTimer.Interval = 50;
            this.redrawTimer.Tick += new System.EventHandler(this.redrawTimer_Tick);
            // 
            // CritterEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 588);
            this.Controls.Add(this.sptFullForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CritterEditor";
            this.Text = "CritterEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CritterEditor_FormClosing);
            this.sptFullForm.Panel1.ResumeLayout(false);
            this.sptFullForm.Panel1.PerformLayout();
            this.sptFullForm.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sptFullForm)).EndInit();
            this.sptFullForm.ResumeLayout(false);
            this.toolsMainTools.ResumeLayout(false);
            this.toolsMainTools.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabInfo.PerformLayout();
            this.pnlBeast.ResumeLayout(false);
            this.pnlBeast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastHeadHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastRectHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastRectWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBeastFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDefence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttackRange)).EndInit();
            this.pnlHumanoid.ResumeLayout(false);
            this.pnlHumanoid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExperience)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovementSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHealth)).EndInit();
            this.tabScripts.ResumeLayout(false);
            this.tabLoot.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numListViewHidden)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sptFullForm;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TreeView treeAllCritters;
        private System.Windows.Forms.Panel pnlHumanoid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddLoot;
        private System.Windows.Forms.ComboBox cbItemList;
        private CityTools.Components.ListViewEx listLoot;
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
        private System.Windows.Forms.Panel pnlBeast;
        private System.Windows.Forms.PictureBox pbPreviewDisplay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbHumanoidWeapon;
        private System.Windows.Forms.ComboBox cbHumanoidHeadgear;
        private System.Windows.Forms.ComboBox cbHumanoidFace;
        private System.Windows.Forms.ComboBox cbHumanoidBody;
        private System.Windows.Forms.ComboBox cbHumanoidPants;
        private System.Windows.Forms.ComboBox cbHumanoidShadow;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbBaseGroup;
        private Components.AnimationList ccBeastAnimations;
        private System.Windows.Forms.Button btnBeastRight;
        private System.Windows.Forms.Button btnBeastDown;
        private System.Windows.Forms.Button btnBeastUp;
        private System.Windows.Forms.Button btnBeastLeft;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbBeastState;
        private System.Windows.Forms.Label lblBeastDirection;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numBeastFPS;
        private ScriptBox txtScript;
        private System.Windows.Forms.Button btnAddToSpawnList;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numBeastRectHeight;
        private System.Windows.Forms.NumericUpDown numBeastRectWidth;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown numBeastOffsetY;
        private System.Windows.Forms.NumericUpDown numRange;
        private System.Windows.Forms.NumericUpDown numMovementSpeed;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabScripts;
        private System.Windows.Forms.TabPage tabLoot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown numListViewHidden;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numAttackRange;
        private System.Windows.Forms.Timer redrawTimer;
        private System.Windows.Forms.NumericUpDown numDefence;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown numBeastOffsetX;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown numBeastHeadHeight;
    }
}