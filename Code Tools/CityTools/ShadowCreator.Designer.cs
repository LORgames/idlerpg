namespace CityTools {
    partial class ShadowCreator {
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
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listShadows = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlShadowInfo = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.numAlpha = new System.Windows.Forms.NumericUpDown();
            this.previewColor = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numOffsetY = new System.Windows.Forms.NumericUpDown();
            this.numOffsetX = new System.Windows.Forms.NumericUpDown();
            this.btnNewShadow = new System.Windows.Forms.Button();
            this.btnClearShadows = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.numExpandB = new System.Windows.Forms.NumericUpDown();
            this.numExpandT = new System.Windows.Forms.NumericUpDown();
            this.numExpandR = new System.Windows.Forms.NumericUpDown();
            this.numExpandL = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            this.pnlShadowInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExpandB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpandT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpandR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpandL)).BeginInit();
            this.SuspendLayout();
            // 
            // previewBox
            // 
            this.previewBox.Location = new System.Drawing.Point(282, 25);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(366, 241);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            this.previewBox.Paint += new System.Windows.Forms.PaintEventHandler(this.previewBox_Paint);
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(12, 25);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(264, 355);
            this.listFiles.TabIndex = 1;
            this.listFiles.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Drop Files You Want Shadowed Below";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 386);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear List";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(156, 386);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(120, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate Shadows";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // numWidth
            // 
            this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numWidth.Location = new System.Drawing.Point(119, 6);
            this.numWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(52, 20);
            this.numWidth.TabIndex = 5;
            this.numWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.ValueChanged += new System.EventHandler(this.ShadowValueChanged);
            // 
            // numHeight
            // 
            this.numHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numHeight.Location = new System.Drawing.Point(119, 32);
            this.numHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(52, 20);
            this.numHeight.TabIndex = 6;
            this.numHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.ShadowValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Shadow Width";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Shadow Height";
            // 
            // listShadows
            // 
            this.listShadows.FormattingEnabled = true;
            this.listShadows.Location = new System.Drawing.Point(282, 285);
            this.listShadows.Name = "listShadows";
            this.listShadows.Size = new System.Drawing.Size(184, 147);
            this.listShadows.TabIndex = 9;
            this.listShadows.SelectedIndexChanged += new System.EventHandler(this.listShadows_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(282, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Shadows";
            // 
            // pnlShadowInfo
            // 
            this.pnlShadowInfo.Controls.Add(this.label8);
            this.pnlShadowInfo.Controls.Add(this.numAlpha);
            this.pnlShadowInfo.Controls.Add(this.previewColor);
            this.pnlShadowInfo.Controls.Add(this.label7);
            this.pnlShadowInfo.Controls.Add(this.label6);
            this.pnlShadowInfo.Controls.Add(this.label5);
            this.pnlShadowInfo.Controls.Add(this.numOffsetY);
            this.pnlShadowInfo.Controls.Add(this.numOffsetX);
            this.pnlShadowInfo.Controls.Add(this.numWidth);
            this.pnlShadowInfo.Controls.Add(this.numHeight);
            this.pnlShadowInfo.Controls.Add(this.label2);
            this.pnlShadowInfo.Controls.Add(this.label3);
            this.pnlShadowInfo.Enabled = false;
            this.pnlShadowInfo.Location = new System.Drawing.Point(472, 285);
            this.pnlShadowInfo.Name = "pnlShadowInfo";
            this.pnlShadowInfo.Size = new System.Drawing.Size(176, 169);
            this.pnlShadowInfo.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Shadow Alpha";
            // 
            // numAlpha
            // 
            this.numAlpha.Location = new System.Drawing.Point(119, 136);
            this.numAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numAlpha.Name = "numAlpha";
            this.numAlpha.Size = new System.Drawing.Size(52, 20);
            this.numAlpha.TabIndex = 15;
            this.numAlpha.ValueChanged += new System.EventHandler(this.ShadowValueChanged);
            // 
            // previewColor
            // 
            this.previewColor.Location = new System.Drawing.Point(119, 110);
            this.previewColor.Name = "previewColor";
            this.previewColor.Size = new System.Drawing.Size(52, 20);
            this.previewColor.TabIndex = 14;
            this.previewColor.TabStop = false;
            this.previewColor.Click += new System.EventHandler(this.previewColor_Click);
            this.previewColor.Paint += new System.Windows.Forms.PaintEventHandler(this.previewColor_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Shadow Color";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Offset Y From Bottom";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Offset X From Middle";
            // 
            // numOffsetY
            // 
            this.numOffsetY.Location = new System.Drawing.Point(119, 84);
            this.numOffsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numOffsetY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numOffsetY.Name = "numOffsetY";
            this.numOffsetY.Size = new System.Drawing.Size(52, 20);
            this.numOffsetY.TabIndex = 10;
            this.numOffsetY.ValueChanged += new System.EventHandler(this.ShadowValueChanged);
            // 
            // numOffsetX
            // 
            this.numOffsetX.Location = new System.Drawing.Point(119, 58);
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
            this.numOffsetX.Size = new System.Drawing.Size(52, 20);
            this.numOffsetX.TabIndex = 9;
            this.numOffsetX.ValueChanged += new System.EventHandler(this.ShadowValueChanged);
            // 
            // btnNewShadow
            // 
            this.btnNewShadow.Location = new System.Drawing.Point(282, 438);
            this.btnNewShadow.Name = "btnNewShadow";
            this.btnNewShadow.Size = new System.Drawing.Size(81, 23);
            this.btnNewShadow.TabIndex = 12;
            this.btnNewShadow.Text = "New Shadow";
            this.btnNewShadow.UseVisualStyleBackColor = true;
            this.btnNewShadow.Click += new System.EventHandler(this.btnNewShadow_Click);
            // 
            // btnClearShadows
            // 
            this.btnClearShadows.Location = new System.Drawing.Point(369, 438);
            this.btnClearShadows.Name = "btnClearShadows";
            this.btnClearShadows.Size = new System.Drawing.Size(97, 23);
            this.btnClearShadows.TabIndex = 13;
            this.btnClearShadows.Text = "Clear Shadows";
            this.btnClearShadows.UseVisualStyleBackColor = true;
            this.btnClearShadows.Click += new System.EventHandler(this.btnClearShadows_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.numExpandB);
            this.panel1.Controls.Add(this.numExpandT);
            this.panel1.Controls.Add(this.numExpandR);
            this.panel1.Controls.Add(this.numExpandL);
            this.panel1.Location = new System.Drawing.Point(12, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 46);
            this.panel1.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(198, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Expansions, Left, Right, Top and Bottom";
            // 
            // numExpandB
            // 
            this.numExpandB.Location = new System.Drawing.Point(199, 21);
            this.numExpandB.Name = "numExpandB";
            this.numExpandB.Size = new System.Drawing.Size(58, 20);
            this.numExpandB.TabIndex = 3;
            this.numExpandB.ValueChanged += new System.EventHandler(this.SidesChanged);
            // 
            // numExpandT
            // 
            this.numExpandT.Location = new System.Drawing.Point(135, 21);
            this.numExpandT.Name = "numExpandT";
            this.numExpandT.Size = new System.Drawing.Size(58, 20);
            this.numExpandT.TabIndex = 2;
            this.numExpandT.ValueChanged += new System.EventHandler(this.SidesChanged);
            // 
            // numExpandR
            // 
            this.numExpandR.Location = new System.Drawing.Point(71, 21);
            this.numExpandR.Name = "numExpandR";
            this.numExpandR.Size = new System.Drawing.Size(58, 20);
            this.numExpandR.TabIndex = 1;
            this.numExpandR.ValueChanged += new System.EventHandler(this.SidesChanged);
            // 
            // numExpandL
            // 
            this.numExpandL.Location = new System.Drawing.Point(7, 21);
            this.numExpandL.Name = "numExpandL";
            this.numExpandL.Size = new System.Drawing.Size(58, 20);
            this.numExpandL.TabIndex = 0;
            this.numExpandL.ValueChanged += new System.EventHandler(this.SidesChanged);
            // 
            // ShadowCreator
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 466);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClearShadows);
            this.Controls.Add(this.btnNewShadow);
            this.Controls.Add(this.pnlShadowInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listShadows);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.previewBox);
            this.Name = "ShadowCreator";
            this.Text = "ShadowCreator";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.ShadowCreator_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.ShadowCreator_DragOver);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            this.pnlShadowInfo.ResumeLayout(false);
            this.pnlShadowInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetX)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numExpandB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpandT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpandR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numExpandL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox previewBox;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listShadows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlShadowInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numOffsetY;
        private System.Windows.Forms.NumericUpDown numOffsetX;
        private System.Windows.Forms.Button btnNewShadow;
        private System.Windows.Forms.Button btnClearShadows;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numAlpha;
        private System.Windows.Forms.PictureBox previewColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numExpandB;
        private System.Windows.Forms.NumericUpDown numExpandT;
        private System.Windows.Forms.NumericUpDown numExpandR;
        private System.Windows.Forms.NumericUpDown numExpandL;
        private System.Windows.Forms.Label label9;
    }
}