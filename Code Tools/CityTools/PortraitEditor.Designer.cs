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
            this.listPortraits = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNew = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteSelected = new System.Windows.Forms.ToolStripButton();
            this.pbDisplay = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPortraitName = new System.Windows.Forms.ToolStripTextBox();
            this.lblID = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
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
            this.splitMain.Panel1.Controls.Add(this.listPortraits);
            this.splitMain.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.AllowDrop = true;
            this.splitMain.Panel2.Controls.Add(this.pbDisplay);
            this.splitMain.Panel2.Controls.Add(this.menuStrip1);
            this.splitMain.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbDisplay_DragDrop);
            this.splitMain.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbDisplay_DragEnter);
            this.splitMain.Size = new System.Drawing.Size(743, 485);
            this.splitMain.SplitterDistance = 247;
            this.splitMain.TabIndex = 0;
            // 
            // listPortraits
            // 
            this.listPortraits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listPortraits.FormattingEnabled = true;
            this.listPortraits.Location = new System.Drawing.Point(0, 25);
            this.listPortraits.Name = "listPortraits";
            this.listPortraits.Size = new System.Drawing.Size(247, 460);
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
            // pbDisplay
            // 
            this.pbDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDisplay.Location = new System.Drawing.Point(0, 25);
            this.pbDisplay.Name = "pbDisplay";
            this.pbDisplay.Size = new System.Drawing.Size(492, 460);
            this.pbDisplay.TabIndex = 1;
            this.pbDisplay.TabStop = false;
            this.pbDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDisplay_Paint);
            this.pbDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDisplay_MouseDown);
            this.pbDisplay.MouseLeave += new System.EventHandler(this.pbDisplay_MouseLeave);
            this.pbDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDisplay_MouseMove);
            this.pbDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDisplay_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.txtPortraitName,
            this.lblID});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(492, 25);
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
            // lblID
            // 
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(34, 21);
            this.lblID.Text = "ID:";
            // 
            // PortraitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 485);
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
        private System.Windows.Forms.PictureBox pbDisplay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtPortraitName;
        private System.Windows.Forms.ToolStripMenuItem lblID;
        private System.Windows.Forms.ListBox listPortraits;
        private System.Windows.Forms.ToolStripButton btnDeleteSelected;
    }
}