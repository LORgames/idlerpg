using CityTools.ClipIns;

namespace CityTools {
    partial class EquipmentEditor {
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
            this.treeEquipmentList = new System.Windows.Forms.TreeView();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.cbTileList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAnimationState = new System.Windows.Forms.ComboBox();
            this.drpLeft = new System.Windows.Forms.Label();
            this.drpRight = new System.Windows.Forms.Label();
            this.drpUp = new System.Windows.Forms.Label();
            this.drpDown = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.ckbAvailableAtStart = new System.Windows.Forms.CheckBox();
            this.pbEquipmentDisplay = new System.Windows.Forms.PictureBox();
            this.lblFrontAnimationName = new System.Windows.Forms.Label();
            this.lblBackAnimationName = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbDispWeapon = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbDispBody = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbDispFace = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbDispPants = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbDispHeadgear = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbPreviewState = new System.Windows.Forms.ComboBox();
            this.numOffsetX_0 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numOffsetY_0 = new System.Windows.Forms.NumericUpDown();
            this.cbDispShadow = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSwapAnimations = new System.Windows.Forms.Button();
            this.ckbDrawWaist = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl3489 = new System.Windows.Forms.Label();
            this.numOffsetY_1 = new System.Windows.Forms.NumericUpDown();
            this.numOffsetX_1 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.numOffsetY_2 = new System.Windows.Forms.NumericUpDown();
            this.numOffsetX_2 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numOffsetY_3 = new System.Windows.Forms.NumericUpDown();
            this.numOffsetX_3 = new System.Windows.Forms.NumericUpDown();
            this.ckbLockOffsets = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.ccAnimationBack = new CityTools.ClipIns.AnimationList();
            this.ccAnimationFront = new CityTools.ClipIns.AnimationList();
            ((System.ComponentModel.ISupportInitialize)(this.pbEquipmentDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX_3)).BeginInit();
            this.SuspendLayout();
            // 
            // treeEquipmentList
            // 
            this.treeEquipmentList.Location = new System.Drawing.Point(12, 170);
            this.treeEquipmentList.Name = "treeEquipmentList";
            this.treeEquipmentList.Size = new System.Drawing.Size(198, 437);
            this.treeEquipmentList.TabIndex = 1;
            this.treeEquipmentList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeEquipmentList_AfterSelect);
            // 
            // cbItemType
            // 
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Location = new System.Drawing.Point(216, 217);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(112, 21);
            this.cbItemType.TabIndex = 2;
            this.cbItemType.SelectedIndexChanged += new System.EventHandler(this.cbItemType_SelectedIndexChanged);
            this.cbItemType.TextChanged += new System.EventHandler(this.cbItemType_SelectedIndexChanged);
            // 
            // cbTileList
            // 
            this.cbTileList.FormattingEnabled = true;
            this.cbTileList.Location = new System.Drawing.Point(16, 139);
            this.cbTileList.Name = "cbTileList";
            this.cbTileList.Size = new System.Drawing.Size(94, 21);
            this.cbTileList.TabIndex = 5;
            this.cbTileList.SelectedIndexChanged += new System.EventHandler(this.cbTileList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(433, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "States:";
            // 
            // cbAnimationState
            // 
            this.cbAnimationState.FormattingEnabled = true;
            this.cbAnimationState.Location = new System.Drawing.Point(478, 480);
            this.cbAnimationState.Name = "cbAnimationState";
            this.cbAnimationState.Size = new System.Drawing.Size(72, 21);
            this.cbAnimationState.TabIndex = 9;
            this.cbAnimationState.SelectedIndexChanged += new System.EventHandler(this.cbAnimationState_SelectedIndexChanged);
            // 
            // drpLeft
            // 
            this.drpLeft.AllowDrop = true;
            this.drpLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.drpLeft.Location = new System.Drawing.Point(220, 458);
            this.drpLeft.Name = "drpLeft";
            this.drpLeft.Size = new System.Drawing.Size(47, 43);
            this.drpLeft.TabIndex = 10;
            this.drpLeft.Text = "[LEFT]";
            this.drpLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.drpLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragDrop);
            this.drpLeft.DragOver += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragOver);
            this.drpLeft.MouseEnter += new System.EventHandler(this.rotDrp_MouseOver);
            // 
            // drpRight
            // 
            this.drpRight.AllowDrop = true;
            this.drpRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.drpRight.Location = new System.Drawing.Point(273, 458);
            this.drpRight.Name = "drpRight";
            this.drpRight.Size = new System.Drawing.Size(47, 43);
            this.drpRight.TabIndex = 11;
            this.drpRight.Text = "[RIGHT]";
            this.drpRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.drpRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragDrop);
            this.drpRight.DragOver += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragOver);
            this.drpRight.MouseEnter += new System.EventHandler(this.rotDrp_MouseOver);
            // 
            // drpUp
            // 
            this.drpUp.AllowDrop = true;
            this.drpUp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.drpUp.Location = new System.Drawing.Point(326, 458);
            this.drpUp.Name = "drpUp";
            this.drpUp.Size = new System.Drawing.Size(47, 43);
            this.drpUp.TabIndex = 12;
            this.drpUp.Text = "[UP]";
            this.drpUp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.drpUp.DragDrop += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragDrop);
            this.drpUp.DragOver += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragOver);
            this.drpUp.MouseEnter += new System.EventHandler(this.rotDrp_MouseOver);
            // 
            // drpDown
            // 
            this.drpDown.AllowDrop = true;
            this.drpDown.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.drpDown.Location = new System.Drawing.Point(379, 458);
            this.drpDown.Name = "drpDown";
            this.drpDown.Size = new System.Drawing.Size(48, 43);
            this.drpDown.TabIndex = 13;
            this.drpDown.Text = "[DOWN]";
            this.drpDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.drpDown.DragDrop += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragDrop);
            this.drpDown.DragOver += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragOver);
            this.drpDown.MouseEnter += new System.EventHandler(this.rotDrp_MouseOver);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 442);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Quick Drop (shift for 2nd layer)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Equipment Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(216, 241);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Equipment Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(216, 257);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(112, 20);
            this.txtName.TabIndex = 17;
            this.txtName.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // ckbAvailableAtStart
            // 
            this.ckbAvailableAtStart.AutoSize = true;
            this.ckbAvailableAtStart.Location = new System.Drawing.Point(216, 283);
            this.ckbAvailableAtStart.Name = "ckbAvailableAtStart";
            this.ckbAvailableAtStart.Size = new System.Drawing.Size(85, 17);
            this.ckbAvailableAtStart.TabIndex = 18;
            this.ckbAvailableAtStart.Text = "Starting Item";
            this.ckbAvailableAtStart.UseVisualStyleBackColor = true;
            this.ckbAvailableAtStart.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // pbEquipmentDisplay
            // 
            this.pbEquipmentDisplay.Location = new System.Drawing.Point(12, 9);
            this.pbEquipmentDisplay.Name = "pbEquipmentDisplay";
            this.pbEquipmentDisplay.Size = new System.Drawing.Size(634, 155);
            this.pbEquipmentDisplay.TabIndex = 3;
            this.pbEquipmentDisplay.TabStop = false;
            this.pbEquipmentDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbEquipmentDisplay_Paint);
            // 
            // lblFrontAnimationName
            // 
            this.lblFrontAnimationName.AutoSize = true;
            this.lblFrontAnimationName.Location = new System.Drawing.Point(221, 582);
            this.lblFrontAnimationName.Name = "lblFrontAnimationName";
            this.lblFrontAnimationName.Size = new System.Drawing.Size(44, 13);
            this.lblFrontAnimationName.TabIndex = 22;
            this.lblFrontAnimationName.Text = "FRONT";
            // 
            // lblBackAnimationName
            // 
            this.lblBackAnimationName.AutoSize = true;
            this.lblBackAnimationName.Location = new System.Drawing.Point(437, 582);
            this.lblBackAnimationName.Name = "lblBackAnimationName";
            this.lblBackAnimationName.Size = new System.Drawing.Size(35, 13);
            this.lblBackAnimationName.TabIndex = 23;
            this.lblBackAnimationName.Text = "BACK";
            // 
            // lblDirection
            // 
            this.lblDirection.BackColor = System.Drawing.Color.Transparent;
            this.lblDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirection.Location = new System.Drawing.Point(488, 462);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(47, 15);
            this.lblDirection.TabIndex = 24;
            this.lblDirection.Text = "Left";
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(217, 171);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(111, 23);
            this.btnCreateNew.TabIndex = 25;
            this.btnCreateNew.Text = "Create New";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbDispWeapon
            // 
            this.cbDispWeapon.FormattingEnabled = true;
            this.cbDispWeapon.Location = new System.Drawing.Point(435, 22);
            this.cbDispWeapon.Name = "cbDispWeapon";
            this.cbDispWeapon.Size = new System.Drawing.Size(100, 21);
            this.cbDispWeapon.TabIndex = 33;
            this.cbDispWeapon.SelectedIndexChanged += new System.EventHandler(this.changeFullDisplay);
            this.cbDispWeapon.TextUpdate += new System.EventHandler(this.changeFullDisplay);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(459, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "Weapon";
            // 
            // cbDispBody
            // 
            this.cbDispBody.FormattingEnabled = true;
            this.cbDispBody.Location = new System.Drawing.Point(15, 22);
            this.cbDispBody.Name = "cbDispBody";
            this.cbDispBody.Size = new System.Drawing.Size(100, 21);
            this.cbDispBody.TabIndex = 35;
            this.cbDispBody.SelectedIndexChanged += new System.EventHandler(this.changeFullDisplay);
            this.cbDispBody.TextUpdate += new System.EventHandler(this.changeFullDisplay);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(46, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Body";
            // 
            // cbDispFace
            // 
            this.cbDispFace.FormattingEnabled = true;
            this.cbDispFace.Location = new System.Drawing.Point(119, 22);
            this.cbDispFace.Name = "cbDispFace";
            this.cbDispFace.Size = new System.Drawing.Size(100, 21);
            this.cbDispFace.TabIndex = 37;
            this.cbDispFace.SelectedIndexChanged += new System.EventHandler(this.changeFullDisplay);
            this.cbDispFace.TextUpdate += new System.EventHandler(this.changeFullDisplay);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Face";
            // 
            // cbDispPants
            // 
            this.cbDispPants.FormattingEnabled = true;
            this.cbDispPants.Location = new System.Drawing.Point(223, 22);
            this.cbDispPants.Name = "cbDispPants";
            this.cbDispPants.Size = new System.Drawing.Size(100, 21);
            this.cbDispPants.TabIndex = 39;
            this.cbDispPants.SelectedIndexChanged += new System.EventHandler(this.changeFullDisplay);
            this.cbDispPants.TextUpdate += new System.EventHandler(this.changeFullDisplay);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Pants";
            // 
            // cbDispHeadgear
            // 
            this.cbDispHeadgear.FormattingEnabled = true;
            this.cbDispHeadgear.Location = new System.Drawing.Point(329, 22);
            this.cbDispHeadgear.Name = "cbDispHeadgear";
            this.cbDispHeadgear.Size = new System.Drawing.Size(100, 21);
            this.cbDispHeadgear.TabIndex = 41;
            this.cbDispHeadgear.SelectedIndexChanged += new System.EventHandler(this.changeFullDisplay);
            this.cbDispHeadgear.TextUpdate += new System.EventHandler(this.changeFullDisplay);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Headgear";
            // 
            // cbPreviewState
            // 
            this.cbPreviewState.FormattingEnabled = true;
            this.cbPreviewState.Location = new System.Drawing.Point(116, 139);
            this.cbPreviewState.Name = "cbPreviewState";
            this.cbPreviewState.Size = new System.Drawing.Size(94, 21);
            this.cbPreviewState.TabIndex = 42;
            this.cbPreviewState.SelectedIndexChanged += new System.EventHandler(this.cbPreviewState_SelectedIndexChanged);
            // 
            // numOffsetX_0
            // 
            this.numOffsetX_0.Location = new System.Drawing.Point(254, 340);
            this.numOffsetX_0.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numOffsetX_0.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numOffsetX_0.Name = "numOffsetX_0";
            this.numOffsetX_0.Size = new System.Drawing.Size(36, 20);
            this.numOffsetX_0.TabIndex = 43;
            this.numOffsetX_0.ValueChanged += new System.EventHandler(this.numOffset_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "X";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(303, 326);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Y";
            // 
            // numOffsetY_0
            // 
            this.numOffsetY_0.Location = new System.Drawing.Point(292, 340);
            this.numOffsetY_0.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numOffsetY_0.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numOffsetY_0.Name = "numOffsetY_0";
            this.numOffsetY_0.Size = new System.Drawing.Size(36, 20);
            this.numOffsetY_0.TabIndex = 45;
            this.numOffsetY_0.ValueChanged += new System.EventHandler(this.numOffset_ValueChanged);
            // 
            // cbDispShadow
            // 
            this.cbDispShadow.FormattingEnabled = true;
            this.cbDispShadow.Location = new System.Drawing.Point(541, 22);
            this.cbDispShadow.Name = "cbDispShadow";
            this.cbDispShadow.Size = new System.Drawing.Size(100, 21);
            this.cbDispShadow.TabIndex = 48;
            this.cbDispShadow.SelectedIndexChanged += new System.EventHandler(this.changeFullDisplay);
            this.cbDispShadow.TextUpdate += new System.EventHandler(this.changeFullDisplay);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(569, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Shadow";
            // 
            // btnSwapAnimations
            // 
            this.btnSwapAnimations.Location = new System.Drawing.Point(556, 478);
            this.btnSwapAnimations.Name = "btnSwapAnimations";
            this.btnSwapAnimations.Size = new System.Drawing.Size(90, 23);
            this.btnSwapAnimations.TabIndex = 49;
            this.btnSwapAnimations.Text = "Animation Swap";
            this.btnSwapAnimations.UseVisualStyleBackColor = true;
            this.btnSwapAnimations.Click += new System.EventHandler(this.btnSwapAnimations_Click);
            // 
            // ckbDrawWaist
            // 
            this.ckbDrawWaist.AutoSize = true;
            this.ckbDrawWaist.Checked = true;
            this.ckbDrawWaist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDrawWaist.Location = new System.Drawing.Point(223, 141);
            this.ckbDrawWaist.Name = "ckbDrawWaist";
            this.ckbDrawWaist.Size = new System.Drawing.Size(76, 17);
            this.ckbDrawWaist.TabIndex = 50;
            this.ckbDrawWaist.Text = "Waist Line";
            this.ckbDrawWaist.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(224, 344);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 13);
            this.label13.TabIndex = 51;
            this.label13.Text = "Left";
            // 
            // lbl3489
            // 
            this.lbl3489.AutoSize = true;
            this.lbl3489.Location = new System.Drawing.Point(217, 366);
            this.lbl3489.Name = "lbl3489";
            this.lbl3489.Size = new System.Drawing.Size(32, 13);
            this.lbl3489.TabIndex = 54;
            this.lbl3489.Text = "Right";
            // 
            // numOffsetY_1
            // 
            this.numOffsetY_1.Location = new System.Drawing.Point(292, 361);
            this.numOffsetY_1.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numOffsetY_1.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numOffsetY_1.Name = "numOffsetY_1";
            this.numOffsetY_1.Size = new System.Drawing.Size(36, 20);
            this.numOffsetY_1.TabIndex = 53;
            this.numOffsetY_1.ValueChanged += new System.EventHandler(this.numOffset_ValueChanged);
            // 
            // numOffsetX_1
            // 
            this.numOffsetX_1.Location = new System.Drawing.Point(254, 361);
            this.numOffsetX_1.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numOffsetX_1.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numOffsetX_1.Name = "numOffsetX_1";
            this.numOffsetX_1.Size = new System.Drawing.Size(36, 20);
            this.numOffsetX_1.TabIndex = 52;
            this.numOffsetX_1.ValueChanged += new System.EventHandler(this.numOffset_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(228, 384);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 57;
            this.label15.Text = "Up";
            // 
            // numOffsetY_2
            // 
            this.numOffsetY_2.Location = new System.Drawing.Point(292, 382);
            this.numOffsetY_2.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numOffsetY_2.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numOffsetY_2.Name = "numOffsetY_2";
            this.numOffsetY_2.Size = new System.Drawing.Size(36, 20);
            this.numOffsetY_2.TabIndex = 56;
            this.numOffsetY_2.ValueChanged += new System.EventHandler(this.numOffset_ValueChanged);
            // 
            // numOffsetX_2
            // 
            this.numOffsetX_2.Location = new System.Drawing.Point(254, 382);
            this.numOffsetX_2.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numOffsetX_2.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numOffsetX_2.Name = "numOffsetX_2";
            this.numOffsetX_2.Size = new System.Drawing.Size(36, 20);
            this.numOffsetX_2.TabIndex = 55;
            this.numOffsetX_2.ValueChanged += new System.EventHandler(this.numOffset_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(214, 405);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 60;
            this.label16.Text = "Down";
            // 
            // numOffsetY_3
            // 
            this.numOffsetY_3.Location = new System.Drawing.Point(292, 403);
            this.numOffsetY_3.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numOffsetY_3.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numOffsetY_3.Name = "numOffsetY_3";
            this.numOffsetY_3.Size = new System.Drawing.Size(36, 20);
            this.numOffsetY_3.TabIndex = 59;
            this.numOffsetY_3.ValueChanged += new System.EventHandler(this.numOffset_ValueChanged);
            // 
            // numOffsetX_3
            // 
            this.numOffsetX_3.Location = new System.Drawing.Point(254, 403);
            this.numOffsetX_3.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numOffsetX_3.Minimum = new decimal(new int[] {
            250,
            0,
            0,
            -2147483648});
            this.numOffsetX_3.Name = "numOffsetX_3";
            this.numOffsetX_3.Size = new System.Drawing.Size(36, 20);
            this.numOffsetX_3.TabIndex = 58;
            this.numOffsetX_3.ValueChanged += new System.EventHandler(this.numOffset_ValueChanged);
            // 
            // ckbLockOffsets
            // 
            this.ckbLockOffsets.AutoSize = true;
            this.ckbLockOffsets.Checked = true;
            this.ckbLockOffsets.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbLockOffsets.Location = new System.Drawing.Point(216, 306);
            this.ckbLockOffsets.Name = "ckbLockOffsets";
            this.ckbLockOffsets.Size = new System.Drawing.Size(115, 17);
            this.ckbLockOffsets.TabIndex = 61;
            this.ckbLockOffsets.Text = "One Set Of Offsets";
            this.ckbLockOffsets.UseVisualStyleBackColor = true;
            this.ckbLockOffsets.CheckedChanged += new System.EventHandler(this.ckbLockOffsets_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(433, 462);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 62;
            this.label14.Text = "Direction:";
            // 
            // ccAnimationBack
            // 
            this.ccAnimationBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimationBack.Location = new System.Drawing.Point(433, 507);
            this.ccAnimationBack.Name = "ccAnimationBack";
            this.ccAnimationBack.Size = new System.Drawing.Size(213, 100);
            this.ccAnimationBack.TabIndex = 21;
            // 
            // ccAnimationFront
            // 
            this.ccAnimationFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimationFront.Location = new System.Drawing.Point(217, 507);
            this.ccAnimationFront.Name = "ccAnimationFront";
            this.ccAnimationFront.Size = new System.Drawing.Size(210, 100);
            this.ccAnimationFront.TabIndex = 6;
            // 
            // EquipmentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 619);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ckbLockOffsets);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.numOffsetY_3);
            this.Controls.Add(this.numOffsetX_3);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.numOffsetY_2);
            this.Controls.Add(this.numOffsetX_2);
            this.Controls.Add(this.lbl3489);
            this.Controls.Add(this.numOffsetY_1);
            this.Controls.Add(this.numOffsetX_1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.ckbDrawWaist);
            this.Controls.Add(this.btnSwapAnimations);
            this.Controls.Add(this.cbDispShadow);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numOffsetY_0);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numOffsetX_0);
            this.Controls.Add(this.cbPreviewState);
            this.Controls.Add(this.cbDispHeadgear);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cbDispPants);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbDispFace);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbDispBody);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbDispWeapon);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.lblBackAnimationName);
            this.Controls.Add(this.lblFrontAnimationName);
            this.Controls.Add(this.ccAnimationBack);
            this.Controls.Add(this.ckbAvailableAtStart);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.drpDown);
            this.Controls.Add(this.drpUp);
            this.Controls.Add(this.drpRight);
            this.Controls.Add(this.drpLeft);
            this.Controls.Add(this.cbAnimationState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ccAnimationFront);
            this.Controls.Add(this.cbTileList);
            this.Controls.Add(this.pbEquipmentDisplay);
            this.Controls.Add(this.cbItemType);
            this.Controls.Add(this.treeEquipmentList);
            this.Name = "EquipmentEditor";
            this.Text = "Equipment Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EquipmentEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbEquipmentDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX_3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeEquipmentList;
        private System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.PictureBox pbEquipmentDisplay;
        private System.Windows.Forms.ComboBox cbTileList;
        private AnimationList ccAnimationFront;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbAnimationState;
        private System.Windows.Forms.Label drpLeft;
        private System.Windows.Forms.Label drpRight;
        private System.Windows.Forms.Label drpUp;
        private System.Windows.Forms.Label drpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox ckbAvailableAtStart;
        private AnimationList ccAnimationBack;
        private System.Windows.Forms.Label lblFrontAnimationName;
        private System.Windows.Forms.Label lblBackAnimationName;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Button btnCreateNew;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbDispWeapon;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbDispBody;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbDispFace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbDispPants;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbDispHeadgear;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbPreviewState;
        private System.Windows.Forms.NumericUpDown numOffsetX_0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numOffsetY_0;
        private System.Windows.Forms.ComboBox cbDispShadow;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSwapAnimations;
        private System.Windows.Forms.CheckBox ckbDrawWaist;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl3489;
        private System.Windows.Forms.NumericUpDown numOffsetY_1;
        private System.Windows.Forms.NumericUpDown numOffsetX_1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numOffsetY_2;
        private System.Windows.Forms.NumericUpDown numOffsetX_2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numOffsetY_3;
        private System.Windows.Forms.NumericUpDown numOffsetX_3;
        private System.Windows.Forms.CheckBox ckbLockOffsets;
        private System.Windows.Forms.Label label14;
    }
}