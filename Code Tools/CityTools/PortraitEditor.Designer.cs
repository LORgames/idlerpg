namespace CityTools {
    partial class PortraitEditor {
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.numAlpha = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.pbColour = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numMarginBottom = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numMarginRight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numMarginLeft = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.listPortraits = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteSelected = new System.Windows.Forms.ToolStripButton();
            this.btnAcceptResize = new System.Windows.Forms.Button();
            this.pbDisplay = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPortraitName = new System.Windows.Forms.ToolStripTextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginLeft)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.pnlControls);
            this.splitMain.Panel1.Controls.Add(this.listPortraits);
            this.splitMain.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.AllowDrop = true;
            this.splitMain.Panel2.Controls.Add(this.btnAcceptResize);
            this.splitMain.Panel2.Controls.Add(this.pbDisplay);
            this.splitMain.Panel2.Controls.Add(this.menuStrip1);
            this.splitMain.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbDisplay_DragDrop);
            this.splitMain.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbDisplay_DragEnter);
            this.splitMain.Size = new System.Drawing.Size(1251, 625);
            this.splitMain.SplitterDistance = 247;
            this.splitMain.TabIndex = 0;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.numAlpha);
            this.pnlControls.Controls.Add(this.label6);
            this.pnlControls.Controls.Add(this.pbColour);
            this.pnlControls.Controls.Add(this.label5);
            this.pnlControls.Controls.Add(this.numHeight);
            this.pnlControls.Controls.Add(this.label4);
            this.pnlControls.Controls.Add(this.numMarginBottom);
            this.pnlControls.Controls.Add(this.label3);
            this.pnlControls.Controls.Add(this.numMarginRight);
            this.pnlControls.Controls.Add(this.label2);
            this.pnlControls.Controls.Add(this.numMarginLeft);
            this.pnlControls.Controls.Add(this.label1);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlControls.Location = new System.Drawing.Point(0, 458);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(247, 167);
            this.pnlControls.TabIndex = 3;
            // 
            // numAlpha
            // 
            this.numAlpha.Location = new System.Drawing.Point(138, 136);
            this.numAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numAlpha.Name = "numAlpha";
            this.numAlpha.Size = new System.Drawing.Size(51, 20);
            this.numAlpha.TabIndex = 11;
            this.numAlpha.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numAlpha.ValueChanged += new System.EventHandler(this.numAlpha_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Transparency";
            // 
            // pbColour
            // 
            this.pbColour.Location = new System.Drawing.Point(138, 110);
            this.pbColour.Name = "pbColour";
            this.pbColour.Size = new System.Drawing.Size(51, 20);
            this.pbColour.TabIndex = 9;
            this.pbColour.TabStop = false;
            this.pbColour.Click += new System.EventHandler(this.pbColour_Click);
            this.pbColour.Paint += new System.Windows.Forms.PaintEventHandler(this.pbColour_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Colour";
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(138, 84);
            this.numHeight.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(51, 20);
            this.numHeight.TabIndex = 7;
            this.numHeight.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Height";
            // 
            // numMarginBottom
            // 
            this.numMarginBottom.Location = new System.Drawing.Point(138, 58);
            this.numMarginBottom.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMarginBottom.Name = "numMarginBottom";
            this.numMarginBottom.Size = new System.Drawing.Size(51, 20);
            this.numMarginBottom.TabIndex = 5;
            this.numMarginBottom.ValueChanged += new System.EventHandler(this.numMarginBottom_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Margin Bottom";
            // 
            // numMarginRight
            // 
            this.numMarginRight.Location = new System.Drawing.Point(138, 32);
            this.numMarginRight.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numMarginRight.Name = "numMarginRight";
            this.numMarginRight.Size = new System.Drawing.Size(51, 20);
            this.numMarginRight.TabIndex = 3;
            this.numMarginRight.ValueChanged += new System.EventHandler(this.numMarginRight_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Margin Right";
            // 
            // numMarginLeft
            // 
            this.numMarginLeft.Location = new System.Drawing.Point(138, 6);
            this.numMarginLeft.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numMarginLeft.Name = "numMarginLeft";
            this.numMarginLeft.Size = new System.Drawing.Size(51, 20);
            this.numMarginLeft.TabIndex = 1;
            this.numMarginLeft.ValueChanged += new System.EventHandler(this.numMarginLeft_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Margin Left";
            // 
            // listPortraits
            // 
            this.listPortraits.Dock = System.Windows.Forms.DockStyle.Top;
            this.listPortraits.FormattingEnabled = true;
            this.listPortraits.Location = new System.Drawing.Point(0, 25);
            this.listPortraits.Name = "listPortraits";
            this.listPortraits.Size = new System.Drawing.Size(247, 433);
            this.listPortraits.TabIndex = 2;
            this.listPortraits.SelectedIndexChanged += new System.EventHandler(this.listPortraits_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNew,
            this.btnDeleteSelected});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(247, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddNew
            // 
            this.btnAddNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNew.Image = global::CityTools.Properties.Resources.add;
            this.btnAddNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(23, 22);
            this.btnAddNew.Text = "Add A New Portrait";
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteSelected.Image = global::CityTools.Properties.Resources.delete;
            this.btnDeleteSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnAcceptResize
            // 
            this.btnAcceptResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptResize.Image = global::CityTools.Properties.Resources.accept;
            this.btnAcceptResize.Location = new System.Drawing.Point(885, 599);
            this.btnAcceptResize.Name = "btnAcceptResize";
            this.btnAcceptResize.Size = new System.Drawing.Size(112, 23);
            this.btnAcceptResize.TabIndex = 2;
            this.btnAcceptResize.Text = "Accept Changes";
            this.btnAcceptResize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAcceptResize.UseVisualStyleBackColor = true;
            this.btnAcceptResize.Visible = false;
            // 
            // pbDisplay
            // 
            this.pbDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDisplay.Location = new System.Drawing.Point(0, 25);
            this.pbDisplay.Name = "pbDisplay";
            this.pbDisplay.Size = new System.Drawing.Size(1000, 600);
            this.pbDisplay.TabIndex = 1;
            this.pbDisplay.TabStop = false;
            this.pbDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDisplay_Paint);
            this.pbDisplay.Resize += new System.EventHandler(this.pbDisplay_Resize);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.txtPortraitName});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(50, 21);
            this.nameToolStripMenuItem.Text = "Name:";
            // 
            // txtPortraitName
            // 
            this.txtPortraitName.Name = "txtPortraitName";
            this.txtPortraitName.Size = new System.Drawing.Size(100, 21);
            // 
            // PortraitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 625);
            this.Controls.Add(this.splitMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PortraitEditor";
            this.Text = "PortraitEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PortraitEditor_FormClosing);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMarginLeft)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddNew;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtPortraitName;
        private System.Windows.Forms.ListBox listPortraits;
        private System.Windows.Forms.ToolStripButton btnDeleteSelected;
        private System.Windows.Forms.Button btnAcceptResize;
        internal System.Windows.Forms.PictureBox pbDisplay;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numMarginBottom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numMarginRight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMarginLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numAlpha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbColour;
    }
}