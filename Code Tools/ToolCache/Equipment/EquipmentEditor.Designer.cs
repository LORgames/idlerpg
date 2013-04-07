using ToolCache.Animation.Form;

namespace ToolCache.Equipment {
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
            this.treeEquipmentList = new System.Windows.Forms.TreeView();
            this.cbItemType = new System.Windows.Forms.ComboBox();
            this.cbTileList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnPlayAnimation = new System.Windows.Forms.Button();
            this.btnRotRight = new System.Windows.Forms.Button();
            this.btnRotLeft = new System.Windows.Forms.Button();
            this.pbSetupLinks = new System.Windows.Forms.PictureBox();
            this.pbEquipmentDisplay = new System.Windows.Forms.PictureBox();
            this.lblFrontAnimationName = new System.Windows.Forms.Label();
            this.lblBackAnimationName = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.btnCreateNew = new System.Windows.Forms.Button();
            this.ccAnimationBack = new ToolCache.Animation.Form.AnimationList();
            this.ccAnimationFront = new ToolCache.Animation.Form.AnimationList();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetupLinks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEquipmentDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // treeEquipmentList
            // 
            this.treeEquipmentList.Location = new System.Drawing.Point(12, 170);
            this.treeEquipmentList.Name = "treeEquipmentList";
            this.treeEquipmentList.Size = new System.Drawing.Size(198, 382);
            this.treeEquipmentList.TabIndex = 1;
            this.treeEquipmentList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeEquipmentList_AfterSelect);
            // 
            // cbItemType
            // 
            this.cbItemType.FormattingEnabled = true;
            this.cbItemType.Location = new System.Drawing.Point(216, 217);
            this.cbItemType.Name = "cbItemType";
            this.cbItemType.Size = new System.Drawing.Size(165, 21);
            this.cbItemType.TabIndex = 2;
            this.cbItemType.SelectedIndexChanged += new System.EventHandler(this.cbItemType_SelectedIndexChanged);
            this.cbItemType.TextChanged += new System.EventHandler(this.cbItemType_SelectedIndexChanged);
            // 
            // cbTileList
            // 
            this.cbTileList.FormattingEnabled = true;
            this.cbTileList.Location = new System.Drawing.Point(22, 19);
            this.cbTileList.Name = "cbTileList";
            this.cbTileList.Size = new System.Drawing.Size(121, 21);
            this.cbTileList.TabIndex = 5;
            this.cbTileList.SelectedIndexChanged += new System.EventHandler(this.cbTileList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Left Click To Link Up | Right Click to Link Down";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 428);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "States:";
            // 
            // cbAnimationState
            // 
            this.cbAnimationState.FormattingEnabled = true;
            this.cbAnimationState.Location = new System.Drawing.Point(257, 425);
            this.cbAnimationState.Name = "cbAnimationState";
            this.cbAnimationState.Size = new System.Drawing.Size(108, 21);
            this.cbAnimationState.TabIndex = 9;
            this.cbAnimationState.SelectedIndexChanged += new System.EventHandler(this.cbAnimationState_SelectedIndexChanged);
            // 
            // drpLeft
            // 
            this.drpLeft.AllowDrop = true;
            this.drpLeft.AutoSize = true;
            this.drpLeft.Location = new System.Drawing.Point(371, 431);
            this.drpLeft.Name = "drpLeft";
            this.drpLeft.Size = new System.Drawing.Size(39, 13);
            this.drpLeft.TabIndex = 10;
            this.drpLeft.Text = "[LEFT]";
            this.drpLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragDrop);
            this.drpLeft.DragOver += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragOver);
            // 
            // drpRight
            // 
            this.drpRight.AllowDrop = true;
            this.drpRight.AutoSize = true;
            this.drpRight.Location = new System.Drawing.Point(416, 431);
            this.drpRight.Name = "drpRight";
            this.drpRight.Size = new System.Drawing.Size(47, 13);
            this.drpRight.TabIndex = 11;
            this.drpRight.Text = "[RIGHT]";
            this.drpRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragDrop);
            this.drpRight.DragOver += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragOver);
            // 
            // drpUp
            // 
            this.drpUp.AllowDrop = true;
            this.drpUp.AutoSize = true;
            this.drpUp.Location = new System.Drawing.Point(469, 431);
            this.drpUp.Name = "drpUp";
            this.drpUp.Size = new System.Drawing.Size(28, 13);
            this.drpUp.TabIndex = 12;
            this.drpUp.Text = "[UP]";
            this.drpUp.DragDrop += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragDrop);
            this.drpUp.DragOver += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragOver);
            // 
            // drpDown
            // 
            this.drpDown.AllowDrop = true;
            this.drpDown.AutoSize = true;
            this.drpDown.Location = new System.Drawing.Point(503, 431);
            this.drpDown.Name = "drpDown";
            this.drpDown.Size = new System.Drawing.Size(48, 13);
            this.drpDown.TabIndex = 13;
            this.drpDown.Text = "[DOWN]";
            this.drpDown.DragDrop += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragDrop);
            this.drpDown.DragOver += new System.Windows.Forms.DragEventHandler(this.quickDrop_DragOver);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Quick Drop (hold shift for 2nd layer):";
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
            this.txtName.Size = new System.Drawing.Size(165, 20);
            this.txtName.TabIndex = 17;
            this.txtName.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // ckbAvailableAtStart
            // 
            this.ckbAvailableAtStart.AutoSize = true;
            this.ckbAvailableAtStart.Location = new System.Drawing.Point(219, 283);
            this.ckbAvailableAtStart.Name = "ckbAvailableAtStart";
            this.ckbAvailableAtStart.Size = new System.Drawing.Size(146, 17);
            this.ckbAvailableAtStart.TabIndex = 18;
            this.ckbAvailableAtStart.Text = "Available As Starting Item";
            this.ckbAvailableAtStart.UseVisualStyleBackColor = true;
            this.ckbAvailableAtStart.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // btnPlayAnimation
            // 
            this.btnPlayAnimation.Image = global::ToolCache.Properties.Resources.control_play_blue;
            this.btnPlayAnimation.Location = new System.Drawing.Point(493, 314);
            this.btnPlayAnimation.Name = "btnPlayAnimation";
            this.btnPlayAnimation.Size = new System.Drawing.Size(23, 22);
            this.btnPlayAnimation.TabIndex = 20;
            this.btnPlayAnimation.UseVisualStyleBackColor = true;
            // 
            // btnRotRight
            // 
            this.btnRotRight.Image = global::ToolCache.Properties.Resources.control_fastforward_blue;
            this.btnRotRight.Location = new System.Drawing.Point(586, 314);
            this.btnRotRight.Name = "btnRotRight";
            this.btnRotRight.Size = new System.Drawing.Size(23, 22);
            this.btnRotRight.TabIndex = 19;
            this.btnRotRight.UseVisualStyleBackColor = true;
            this.btnRotRight.Click += new System.EventHandler(this.btnRotRight_Click);
            // 
            // btnRotLeft
            // 
            this.btnRotLeft.Image = global::ToolCache.Properties.Resources.control_rewind_blue;
            this.btnRotLeft.Location = new System.Drawing.Point(393, 314);
            this.btnRotLeft.Name = "btnRotLeft";
            this.btnRotLeft.Size = new System.Drawing.Size(23, 22);
            this.btnRotLeft.TabIndex = 19;
            this.btnRotLeft.UseVisualStyleBackColor = true;
            this.btnRotLeft.Click += new System.EventHandler(this.btnRotLeft_Click);
            // 
            // pbSetupLinks
            // 
            this.pbSetupLinks.Location = new System.Drawing.Point(387, 170);
            this.pbSetupLinks.Name = "pbSetupLinks";
            this.pbSetupLinks.Size = new System.Drawing.Size(229, 173);
            this.pbSetupLinks.TabIndex = 4;
            this.pbSetupLinks.TabStop = false;
            this.pbSetupLinks.Paint += new System.Windows.Forms.PaintEventHandler(this.pbSetupLinks_Paint);
            // 
            // pbEquipmentDisplay
            // 
            this.pbEquipmentDisplay.Location = new System.Drawing.Point(12, 9);
            this.pbEquipmentDisplay.Name = "pbEquipmentDisplay";
            this.pbEquipmentDisplay.Size = new System.Drawing.Size(604, 155);
            this.pbEquipmentDisplay.TabIndex = 3;
            this.pbEquipmentDisplay.TabStop = false;
            this.pbEquipmentDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbEquipmentDisplay_Paint);
            // 
            // lblFrontAnimationName
            // 
            this.lblFrontAnimationName.AutoSize = true;
            this.lblFrontAnimationName.Location = new System.Drawing.Point(222, 534);
            this.lblFrontAnimationName.Name = "lblFrontAnimationName";
            this.lblFrontAnimationName.Size = new System.Drawing.Size(44, 13);
            this.lblFrontAnimationName.TabIndex = 22;
            this.lblFrontAnimationName.Text = "FRONT";
            // 
            // lblBackAnimationName
            // 
            this.lblBackAnimationName.AutoSize = true;
            this.lblBackAnimationName.Location = new System.Drawing.Point(423, 534);
            this.lblBackAnimationName.Name = "lblBackAnimationName";
            this.lblBackAnimationName.Size = new System.Drawing.Size(35, 13);
            this.lblBackAnimationName.TabIndex = 23;
            this.lblBackAnimationName.Text = "BACK";
            // 
            // lblDirection
            // 
            this.lblDirection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDirection.BackColor = System.Drawing.Color.Transparent;
            this.lblDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirection.Location = new System.Drawing.Point(387, 369);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(229, 29);
            this.lblDirection.TabIndex = 24;
            this.lblDirection.Text = "Left";
            this.lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCreateNew
            // 
            this.btnCreateNew.Location = new System.Drawing.Point(217, 171);
            this.btnCreateNew.Name = "btnCreateNew";
            this.btnCreateNew.Size = new System.Drawing.Size(164, 23);
            this.btnCreateNew.TabIndex = 25;
            this.btnCreateNew.Text = "Create New";
            this.btnCreateNew.UseVisualStyleBackColor = true;
            this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
            // 
            // ccAnimationBack
            // 
            this.ccAnimationBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimationBack.Location = new System.Drawing.Point(418, 452);
            this.ccAnimationBack.Name = "ccAnimationBack";
            this.ccAnimationBack.Size = new System.Drawing.Size(199, 100);
            this.ccAnimationBack.TabIndex = 21;
            // 
            // ccAnimationFront
            // 
            this.ccAnimationFront.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimationFront.Location = new System.Drawing.Point(217, 452);
            this.ccAnimationFront.Name = "ccAnimationFront";
            this.ccAnimationFront.Size = new System.Drawing.Size(199, 100);
            this.ccAnimationFront.TabIndex = 6;
            // 
            // EquipmentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 559);
            this.Controls.Add(this.btnCreateNew);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.lblBackAnimationName);
            this.Controls.Add(this.lblFrontAnimationName);
            this.Controls.Add(this.ccAnimationBack);
            this.Controls.Add(this.btnPlayAnimation);
            this.Controls.Add(this.btnRotRight);
            this.Controls.Add(this.btnRotLeft);
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ccAnimationFront);
            this.Controls.Add(this.cbTileList);
            this.Controls.Add(this.pbSetupLinks);
            this.Controls.Add(this.pbEquipmentDisplay);
            this.Controls.Add(this.cbItemType);
            this.Controls.Add(this.treeEquipmentList);
            this.Name = "EquipmentEditor";
            this.Text = "Equipment Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EquipmentEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbSetupLinks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEquipmentDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeEquipmentList;
        private System.Windows.Forms.ComboBox cbItemType;
        private System.Windows.Forms.PictureBox pbEquipmentDisplay;
        private System.Windows.Forms.PictureBox pbSetupLinks;
        private System.Windows.Forms.ComboBox cbTileList;
        private AnimationList ccAnimationFront;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Button btnRotLeft;
        private System.Windows.Forms.Button btnRotRight;
        private System.Windows.Forms.Button btnPlayAnimation;
        private AnimationList ccAnimationBack;
        private System.Windows.Forms.Label lblFrontAnimationName;
        private System.Windows.Forms.Label lblBackAnimationName;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Button btnCreateNew;
    }
}