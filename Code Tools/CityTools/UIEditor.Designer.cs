﻿namespace CityTools {
    partial class UIEditor {
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
            this.pbExample = new System.Windows.Forms.PictureBox();
            this.listUIElements = new System.Windows.Forms.ListBox();
            this.btnNewUIElement = new System.Windows.Forms.Button();
            this.btnDeleteSelectedUIElements = new System.Windows.Forms.Button();
            this.pnlUIElement = new System.Windows.Forms.Panel();
            this.btnUILayerDelete = new System.Windows.Forms.Button();
            this.btnUILayerAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.listUILayers = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numUIElementOffsetY = new System.Windows.Forms.NumericUpDown();
            this.numUIElementOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUIElementAnchor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUIName = new System.Windows.Forms.TextBox();
            this.pnlUILayer = new System.Windows.Forms.Panel();
            this.pbLayerImage = new System.Windows.Forms.PictureBox();
            this.btnLayerChangeImage = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numLayerOffsetY = new System.Windows.Forms.NumericUpDown();
            this.cbLayerAnchorPosition = new System.Windows.Forms.ComboBox();
            this.numLayerOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numLayerHeight = new System.Windows.Forms.NumericUpDown();
            this.numLayerWidth = new System.Windows.Forms.NumericUpDown();
            this.tbPercent = new System.Windows.Forms.TrackBar();
            this.cbLayerType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.numUIElementSizeY = new System.Windows.Forms.NumericUpDown();
            this.numUIElementSizeX = new System.Windows.Forms.NumericUpDown();
            this.txtLayerName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnMoveLayerDown = new System.Windows.Forms.Button();
            this.btnMoveLayerUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbExample)).BeginInit();
            this.pnlUIElement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUIElementOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUIElementOffsetX)).BeginInit();
            this.pnlUILayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLayerImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayerOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayerOffsetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayerHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayerWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUIElementSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUIElementSizeX)).BeginInit();
            this.SuspendLayout();
            // 
            // pbExample
            // 
            this.pbExample.Location = new System.Drawing.Point(0, 0);
            this.pbExample.Name = "pbExample";
            this.pbExample.Size = new System.Drawing.Size(800, 600);
            this.pbExample.TabIndex = 0;
            this.pbExample.TabStop = false;
            this.pbExample.Paint += new System.Windows.Forms.PaintEventHandler(this.pbExample_Paint);
            // 
            // listUIElements
            // 
            this.listUIElements.FormattingEnabled = true;
            this.listUIElements.Location = new System.Drawing.Point(12, 655);
            this.listUIElements.Name = "listUIElements";
            this.listUIElements.Size = new System.Drawing.Size(195, 160);
            this.listUIElements.TabIndex = 1;
            this.listUIElements.SelectedIndexChanged += new System.EventHandler(this.listUIElements_SelectedIndexChanged);
            // 
            // btnNewUIElement
            // 
            this.btnNewUIElement.Location = new System.Drawing.Point(12, 831);
            this.btnNewUIElement.Name = "btnNewUIElement";
            this.btnNewUIElement.Size = new System.Drawing.Size(96, 23);
            this.btnNewUIElement.TabIndex = 2;
            this.btnNewUIElement.Text = "Add New";
            this.btnNewUIElement.UseVisualStyleBackColor = true;
            this.btnNewUIElement.Click += new System.EventHandler(this.btnNewUIElement_Click);
            // 
            // btnDeleteSelectedUIElements
            // 
            this.btnDeleteSelectedUIElements.Location = new System.Drawing.Point(114, 831);
            this.btnDeleteSelectedUIElements.Name = "btnDeleteSelectedUIElements";
            this.btnDeleteSelectedUIElements.Size = new System.Drawing.Size(93, 23);
            this.btnDeleteSelectedUIElements.TabIndex = 3;
            this.btnDeleteSelectedUIElements.Text = "Delete Selected";
            this.btnDeleteSelectedUIElements.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedUIElements.Click += new System.EventHandler(this.btnDeleteSelectedUIElements_Click);
            // 
            // pnlUIElement
            // 
            this.pnlUIElement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUIElement.Controls.Add(this.btnMoveLayerDown);
            this.pnlUIElement.Controls.Add(this.btnMoveLayerUp);
            this.pnlUIElement.Controls.Add(this.label9);
            this.pnlUIElement.Controls.Add(this.numUIElementSizeY);
            this.pnlUIElement.Controls.Add(this.numUIElementSizeX);
            this.pnlUIElement.Controls.Add(this.btnUILayerDelete);
            this.pnlUIElement.Controls.Add(this.btnUILayerAdd);
            this.pnlUIElement.Controls.Add(this.label4);
            this.pnlUIElement.Controls.Add(this.listUILayers);
            this.pnlUIElement.Controls.Add(this.label3);
            this.pnlUIElement.Controls.Add(this.numUIElementOffsetY);
            this.pnlUIElement.Controls.Add(this.numUIElementOffsetX);
            this.pnlUIElement.Controls.Add(this.label2);
            this.pnlUIElement.Controls.Add(this.cbUIElementAnchor);
            this.pnlUIElement.Controls.Add(this.label1);
            this.pnlUIElement.Controls.Add(this.txtUIName);
            this.pnlUIElement.Enabled = false;
            this.pnlUIElement.Location = new System.Drawing.Point(213, 655);
            this.pnlUIElement.Name = "pnlUIElement";
            this.pnlUIElement.Size = new System.Drawing.Size(220, 199);
            this.pnlUIElement.TabIndex = 4;
            // 
            // btnUILayerDelete
            // 
            this.btnUILayerDelete.Location = new System.Drawing.Point(3, 156);
            this.btnUILayerDelete.Name = "btnUILayerDelete";
            this.btnUILayerDelete.Size = new System.Drawing.Size(40, 23);
            this.btnUILayerDelete.TabIndex = 10;
            this.btnUILayerDelete.Text = "Del";
            this.btnUILayerDelete.UseVisualStyleBackColor = true;
            this.btnUILayerDelete.Click += new System.EventHandler(this.btnUILayerDelete_Click);
            // 
            // btnUILayerAdd
            // 
            this.btnUILayerAdd.Location = new System.Drawing.Point(3, 127);
            this.btnUILayerAdd.Name = "btnUILayerAdd";
            this.btnUILayerAdd.Size = new System.Drawing.Size(40, 23);
            this.btnUILayerAdd.TabIndex = 9;
            this.btnUILayerAdd.Text = "Add";
            this.btnUILayerAdd.UseVisualStyleBackColor = true;
            this.btnUILayerAdd.Click += new System.EventHandler(this.btnUILayerAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Layers";
            // 
            // listUILayers
            // 
            this.listUILayers.FormattingEnabled = true;
            this.listUILayers.Location = new System.Drawing.Point(95, 111);
            this.listUILayers.Name = "listUILayers";
            this.listUILayers.Size = new System.Drawing.Size(121, 82);
            this.listUILayers.TabIndex = 7;
            this.listUILayers.SelectedIndexChanged += new System.EventHandler(this.listUILayers_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Offset Position";
            // 
            // numUIElementOffsetY
            // 
            this.numUIElementOffsetY.Location = new System.Drawing.Point(155, 59);
            this.numUIElementOffsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUIElementOffsetY.Name = "numUIElementOffsetY";
            this.numUIElementOffsetY.Size = new System.Drawing.Size(61, 20);
            this.numUIElementOffsetY.TabIndex = 5;
            this.numUIElementOffsetY.ValueChanged += new System.EventHandler(this.UIElementValueChanged);
            // 
            // numUIElementOffsetX
            // 
            this.numUIElementOffsetX.Location = new System.Drawing.Point(95, 59);
            this.numUIElementOffsetX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUIElementOffsetX.Name = "numUIElementOffsetX";
            this.numUIElementOffsetX.Size = new System.Drawing.Size(61, 20);
            this.numUIElementOffsetX.TabIndex = 4;
            this.numUIElementOffsetX.ValueChanged += new System.EventHandler(this.UIElementValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Anchor To";
            // 
            // cbUIElementAnchor
            // 
            this.cbUIElementAnchor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUIElementAnchor.FormattingEnabled = true;
            this.cbUIElementAnchor.Items.AddRange(new object[] {
            "TopLeft",
            "TopCenter",
            "TopRight",
            "MiddleLeft",
            "MiddleCenter",
            "MiddleRight",
            "BottomLeft",
            "BottomCenter",
            "BottomRight"});
            this.cbUIElementAnchor.Location = new System.Drawing.Point(95, 32);
            this.cbUIElementAnchor.Name = "cbUIElementAnchor";
            this.cbUIElementAnchor.Size = new System.Drawing.Size(121, 21);
            this.cbUIElementAnchor.TabIndex = 2;
            this.cbUIElementAnchor.SelectedIndexChanged += new System.EventHandler(this.UIElementValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Element Name";
            // 
            // txtUIName
            // 
            this.txtUIName.Location = new System.Drawing.Point(95, 6);
            this.txtUIName.Name = "txtUIName";
            this.txtUIName.Size = new System.Drawing.Size(121, 20);
            this.txtUIName.TabIndex = 0;
            this.txtUIName.TextChanged += new System.EventHandler(this.UIElementValueChanged);
            // 
            // pnlUILayer
            // 
            this.pnlUILayer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUILayer.Controls.Add(this.label10);
            this.pnlUILayer.Controls.Add(this.txtLayerName);
            this.pnlUILayer.Controls.Add(this.label8);
            this.pnlUILayer.Controls.Add(this.cbLayerType);
            this.pnlUILayer.Controls.Add(this.pbLayerImage);
            this.pnlUILayer.Controls.Add(this.btnLayerChangeImage);
            this.pnlUILayer.Controls.Add(this.label7);
            this.pnlUILayer.Controls.Add(this.label6);
            this.pnlUILayer.Controls.Add(this.numLayerOffsetY);
            this.pnlUILayer.Controls.Add(this.cbLayerAnchorPosition);
            this.pnlUILayer.Controls.Add(this.numLayerOffsetX);
            this.pnlUILayer.Controls.Add(this.label5);
            this.pnlUILayer.Controls.Add(this.numLayerHeight);
            this.pnlUILayer.Controls.Add(this.numLayerWidth);
            this.pnlUILayer.Enabled = false;
            this.pnlUILayer.Location = new System.Drawing.Point(439, 655);
            this.pnlUILayer.Name = "pnlUILayer";
            this.pnlUILayer.Size = new System.Drawing.Size(349, 199);
            this.pnlUILayer.TabIndex = 5;
            // 
            // pbLayerImage
            // 
            this.pbLayerImage.Location = new System.Drawing.Point(179, 6);
            this.pbLayerImage.Name = "pbLayerImage";
            this.pbLayerImage.Size = new System.Drawing.Size(165, 187);
            this.pbLayerImage.TabIndex = 15;
            this.pbLayerImage.TabStop = false;
            // 
            // btnLayerChangeImage
            // 
            this.btnLayerChangeImage.Location = new System.Drawing.Point(52, 170);
            this.btnLayerChangeImage.Name = "btnLayerChangeImage";
            this.btnLayerChangeImage.Size = new System.Drawing.Size(121, 23);
            this.btnLayerChangeImage.TabIndex = 14;
            this.btnLayerChangeImage.Text = "Change/Assign Image";
            this.btnLayerChangeImage.UseVisualStyleBackColor = true;
            this.btnLayerChangeImage.Click += new System.EventHandler(this.btnLayerChangeImage_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Position";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Anchor";
            // 
            // numLayerOffsetY
            // 
            this.numLayerOffsetY.Location = new System.Drawing.Point(112, 58);
            this.numLayerOffsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLayerOffsetY.Name = "numLayerOffsetY";
            this.numLayerOffsetY.Size = new System.Drawing.Size(61, 20);
            this.numLayerOffsetY.TabIndex = 12;
            this.numLayerOffsetY.ValueChanged += new System.EventHandler(this.UILayerValueChanged);
            // 
            // cbLayerAnchorPosition
            // 
            this.cbLayerAnchorPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayerAnchorPosition.FormattingEnabled = true;
            this.cbLayerAnchorPosition.Items.AddRange(new object[] {
            "TopLeft",
            "TopCenter",
            "TopRight",
            "MiddleLeft",
            "MiddleCenter",
            "MiddleRight",
            "BottomLeft",
            "BottomCenter",
            "BottomRight"});
            this.cbLayerAnchorPosition.Location = new System.Drawing.Point(53, 111);
            this.cbLayerAnchorPosition.Name = "cbLayerAnchorPosition";
            this.cbLayerAnchorPosition.Size = new System.Drawing.Size(120, 21);
            this.cbLayerAnchorPosition.TabIndex = 11;
            this.cbLayerAnchorPosition.SelectedIndexChanged += new System.EventHandler(this.UILayerValueChanged);
            // 
            // numLayerOffsetX
            // 
            this.numLayerOffsetX.Location = new System.Drawing.Point(53, 58);
            this.numLayerOffsetX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numLayerOffsetX.Name = "numLayerOffsetX";
            this.numLayerOffsetX.Size = new System.Drawing.Size(60, 20);
            this.numLayerOffsetX.TabIndex = 11;
            this.numLayerOffsetX.ValueChanged += new System.EventHandler(this.UILayerValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Size";
            // 
            // numLayerHeight
            // 
            this.numLayerHeight.Location = new System.Drawing.Point(112, 32);
            this.numLayerHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numLayerHeight.Name = "numLayerHeight";
            this.numLayerHeight.Size = new System.Drawing.Size(61, 20);
            this.numLayerHeight.TabIndex = 1;
            this.numLayerHeight.ValueChanged += new System.EventHandler(this.UILayerValueChanged);
            // 
            // numLayerWidth
            // 
            this.numLayerWidth.Location = new System.Drawing.Point(53, 32);
            this.numLayerWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numLayerWidth.Name = "numLayerWidth";
            this.numLayerWidth.Size = new System.Drawing.Size(60, 20);
            this.numLayerWidth.TabIndex = 0;
            this.numLayerWidth.ValueChanged += new System.EventHandler(this.UILayerValueChanged);
            // 
            // tbPercent
            // 
            this.tbPercent.LargeChange = 10;
            this.tbPercent.Location = new System.Drawing.Point(12, 606);
            this.tbPercent.Maximum = 100;
            this.tbPercent.Name = "tbPercent";
            this.tbPercent.Size = new System.Drawing.Size(776, 45);
            this.tbPercent.TabIndex = 11;
            this.tbPercent.Value = 50;
            this.tbPercent.ValueChanged += new System.EventHandler(this.tbPercent_ValueChanged);
            // 
            // cbLayerType
            // 
            this.cbLayerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLayerType.FormattingEnabled = true;
            this.cbLayerType.Items.AddRange(new object[] {
            "Static",
            "Tile",
            "Stretch",
            "StretchToValueX",
            "StretchToValueY",
            "PanX",
            "PanY",
            "Radial"});
            this.cbLayerType.Location = new System.Drawing.Point(53, 84);
            this.cbLayerType.Name = "cbLayerType";
            this.cbLayerType.Size = new System.Drawing.Size(120, 21);
            this.cbLayerType.TabIndex = 12;
            this.cbLayerType.SelectedIndexChanged += new System.EventHandler(this.UILayerValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Type";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "png";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Select UI Layer Image";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Max Size";
            // 
            // numUIElementSizeY
            // 
            this.numUIElementSizeY.Location = new System.Drawing.Point(155, 85);
            this.numUIElementSizeY.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numUIElementSizeY.Name = "numUIElementSizeY";
            this.numUIElementSizeY.Size = new System.Drawing.Size(61, 20);
            this.numUIElementSizeY.TabIndex = 12;
            this.numUIElementSizeY.ValueChanged += new System.EventHandler(this.UIElementValueChanged);
            // 
            // numUIElementSizeX
            // 
            this.numUIElementSizeX.Location = new System.Drawing.Point(95, 85);
            this.numUIElementSizeX.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numUIElementSizeX.Name = "numUIElementSizeX";
            this.numUIElementSizeX.Size = new System.Drawing.Size(61, 20);
            this.numUIElementSizeX.TabIndex = 11;
            this.numUIElementSizeX.ValueChanged += new System.EventHandler(this.UIElementValueChanged);
            // 
            // txtLayerName
            // 
            this.txtLayerName.Location = new System.Drawing.Point(53, 6);
            this.txtLayerName.Name = "txtLayerName";
            this.txtLayerName.Size = new System.Drawing.Size(120, 20);
            this.txtLayerName.TabIndex = 17;
            this.txtLayerName.TextChanged += new System.EventHandler(this.UILayerValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Name";
            // 
            // btnMoveLayerDown
            // 
            this.btnMoveLayerDown.Location = new System.Drawing.Point(49, 156);
            this.btnMoveLayerDown.Name = "btnMoveLayerDown";
            this.btnMoveLayerDown.Size = new System.Drawing.Size(40, 23);
            this.btnMoveLayerDown.TabIndex = 15;
            this.btnMoveLayerDown.Text = "v";
            this.btnMoveLayerDown.UseVisualStyleBackColor = true;
            this.btnMoveLayerDown.Click += new System.EventHandler(this.btnMoveLayerDown_Click);
            // 
            // btnMoveLayerUp
            // 
            this.btnMoveLayerUp.Location = new System.Drawing.Point(49, 127);
            this.btnMoveLayerUp.Name = "btnMoveLayerUp";
            this.btnMoveLayerUp.Size = new System.Drawing.Size(40, 23);
            this.btnMoveLayerUp.TabIndex = 14;
            this.btnMoveLayerUp.Text = "ʌ";
            this.btnMoveLayerUp.UseVisualStyleBackColor = true;
            this.btnMoveLayerUp.Click += new System.EventHandler(this.btnMoveLayerUp_Click);
            // 
            // UIEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 866);
            this.Controls.Add(this.pnlUILayer);
            this.Controls.Add(this.pnlUIElement);
            this.Controls.Add(this.tbPercent);
            this.Controls.Add(this.btnDeleteSelectedUIElements);
            this.Controls.Add(this.btnNewUIElement);
            this.Controls.Add(this.listUIElements);
            this.Controls.Add(this.pbExample);
            this.Name = "UIEditor";
            this.Text = "UIEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbExample)).EndInit();
            this.pnlUIElement.ResumeLayout(false);
            this.pnlUIElement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUIElementOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUIElementOffsetX)).EndInit();
            this.pnlUILayer.ResumeLayout(false);
            this.pnlUILayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLayerImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayerOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayerOffsetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayerHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLayerWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUIElementSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUIElementSizeX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbExample;
        private System.Windows.Forms.ListBox listUIElements;
        private System.Windows.Forms.Button btnNewUIElement;
        private System.Windows.Forms.Button btnDeleteSelectedUIElements;
        private System.Windows.Forms.Panel pnlUIElement;
        private System.Windows.Forms.Panel pnlUILayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUIName;
        private System.Windows.Forms.ComboBox cbUIElementAnchor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUILayerDelete;
        private System.Windows.Forms.Button btnUILayerAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listUILayers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numUIElementOffsetY;
        private System.Windows.Forms.NumericUpDown numUIElementOffsetX;
        private System.Windows.Forms.TrackBar tbPercent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbLayerAnchorPosition;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numLayerHeight;
        private System.Windows.Forms.NumericUpDown numLayerWidth;
        private System.Windows.Forms.PictureBox pbLayerImage;
        private System.Windows.Forms.Button btnLayerChangeImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numLayerOffsetY;
        private System.Windows.Forms.NumericUpDown numLayerOffsetX;
        private System.Windows.Forms.ComboBox cbLayerType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numUIElementSizeY;
        private System.Windows.Forms.NumericUpDown numUIElementSizeX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLayerName;
        private System.Windows.Forms.Button btnMoveLayerDown;
        private System.Windows.Forms.Button btnMoveLayerUp;
    }
}