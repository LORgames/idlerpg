﻿namespace CityTools
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.main_splitter = new System.Windows.Forms.SplitContainer();
            this.mapViewPanel_c = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbMapPieces = new System.Windows.Forms.ToolStripComboBox();
            this.btnNewPiece = new System.Windows.Forms.ToolStripButton();
            this.btnDeletePiece = new System.Windows.Forms.ToolStripButton();
            this.btnDuplicate = new System.Windows.Forms.ToolStripButton();
            this.btnSavePiece = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPieceName = new System.Windows.Forms.ToolStripLabel();
            this.txtPieceName = new System.Windows.Forms.ToolStripTextBox();
            this.lblFilename = new System.Windows.Forms.ToolStripLabel();
            this.menuMapSizing = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblMapWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMapSizeX = new System.Windows.Forms.ToolStripTextBox();
            this.lblMapHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMapSizeY = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cbMapExtendX = new System.Windows.Forms.ToolStripComboBox();
            this.cbMapExtendY = new System.Windows.Forms.ToolStripComboBox();
            this.btnMapSizeChange = new System.Windows.Forms.ToolStripMenuItem();
            this.mapViewPanel = new System.Windows.Forms.PictureBox();
            this.toolpanel_splitter = new System.Windows.Forms.SplitContainer();
            this.tabFirstLevel = new System.Windows.Forms.TabControl();
            this.tabTerrain = new System.Windows.Forms.TabPage();
            this.panelTiles = new System.Windows.Forms.Panel();
            this.tilesCB = new System.Windows.Forms.ComboBox();
            this.tabPalette = new System.Windows.Forms.TabPage();
            this.tabObjectTools = new System.Windows.Forms.TabControl();
            this.tabObjects = new System.Windows.Forms.TabPage();
            this.obj_splitter = new System.Windows.Forms.SplitContainer();
            this.btnObjectSelector = new System.Windows.Forms.Button();
            this.pnlObjectScenicCache = new System.Windows.Forms.Panel();
            this.cbScenicCacheSelector = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.main_splitter)).BeginInit();
            this.main_splitter.Panel1.SuspendLayout();
            this.main_splitter.Panel2.SuspendLayout();
            this.main_splitter.SuspendLayout();
            this.mapViewPanel_c.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapViewPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolpanel_splitter)).BeginInit();
            this.toolpanel_splitter.Panel2.SuspendLayout();
            this.toolpanel_splitter.SuspendLayout();
            this.tabFirstLevel.SuspendLayout();
            this.tabTerrain.SuspendLayout();
            this.tabPalette.SuspendLayout();
            this.tabObjectTools.SuspendLayout();
            this.tabObjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obj_splitter)).BeginInit();
            this.obj_splitter.Panel1.SuspendLayout();
            this.obj_splitter.Panel2.SuspendLayout();
            this.obj_splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_splitter
            // 
            this.main_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.main_splitter.Location = new System.Drawing.Point(0, 0);
            this.main_splitter.Name = "main_splitter";
            // 
            // main_splitter.Panel1
            // 
            this.main_splitter.Panel1.Controls.Add(this.mapViewPanel_c);
            // 
            // main_splitter.Panel2
            // 
            this.main_splitter.Panel2.Controls.Add(this.toolpanel_splitter);
            this.main_splitter.Size = new System.Drawing.Size(897, 461);
            this.main_splitter.SplitterDistance = 662;
            this.main_splitter.TabIndex = 0;
            // 
            // mapViewPanel_c
            // 
            this.mapViewPanel_c.Controls.Add(this.toolStrip1);
            this.mapViewPanel_c.Controls.Add(this.mapViewPanel);
            this.mapViewPanel_c.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewPanel_c.Location = new System.Drawing.Point(0, 0);
            this.mapViewPanel_c.Name = "mapViewPanel_c";
            this.mapViewPanel_c.Size = new System.Drawing.Size(662, 461);
            this.mapViewPanel_c.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbMapPieces,
            this.btnNewPiece,
            this.btnDeletePiece,
            this.btnDuplicate,
            this.btnSavePiece,
            this.toolStripSeparator1,
            this.lblPieceName,
            this.txtPieceName,
            this.lblFilename,
            this.menuMapSizing});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(662, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbMapPieces
            // 
            this.cbMapPieces.Name = "cbMapPieces";
            this.cbMapPieces.Size = new System.Drawing.Size(121, 25);
            // 
            // btnNewPiece
            // 
            this.btnNewPiece.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewPiece.Image = ((System.Drawing.Image)(resources.GetObject("btnNewPiece.Image")));
            this.btnNewPiece.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewPiece.Name = "btnNewPiece";
            this.btnNewPiece.Size = new System.Drawing.Size(23, 22);
            this.btnNewPiece.Text = "New Map Piece";
            this.btnNewPiece.Click += new System.EventHandler(this.newPieceBtn_Click);
            // 
            // btnDeletePiece
            // 
            this.btnDeletePiece.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeletePiece.Image = ((System.Drawing.Image)(resources.GetObject("btnDeletePiece.Image")));
            this.btnDeletePiece.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeletePiece.Name = "btnDeletePiece";
            this.btnDeletePiece.Size = new System.Drawing.Size(23, 22);
            this.btnDeletePiece.Text = "Delete Piece";
            this.btnDeletePiece.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDuplicate.Image = ((System.Drawing.Image)(resources.GetObject("btnDuplicate.Image")));
            this.btnDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(23, 22);
            this.btnDuplicate.Text = "Duplicate Piece";
            this.btnDuplicate.Click += new System.EventHandler(this.duplicateBtn_Click);
            // 
            // btnSavePiece
            // 
            this.btnSavePiece.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSavePiece.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePiece.Image")));
            this.btnSavePiece.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSavePiece.Name = "btnSavePiece";
            this.btnSavePiece.Size = new System.Drawing.Size(23, 22);
            this.btnSavePiece.Text = "Save Map Piece";
            this.btnSavePiece.Click += new System.EventHandler(this.savePieceClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblPieceName
            // 
            this.lblPieceName.Name = "lblPieceName";
            this.lblPieceName.Size = new System.Drawing.Size(73, 22);
            this.lblPieceName.Text = "Piece Name:";
            // 
            // txtPieceName
            // 
            this.txtPieceName.Name = "txtPieceName";
            this.txtPieceName.Size = new System.Drawing.Size(100, 25);
            // 
            // lblFilename
            // 
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(57, 22);
            this.lblFilename.Text = "<Empty>";
            // 
            // menuMapSizing
            // 
            this.menuMapSizing.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuMapSizing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMapWidth,
            this.txtMapSizeX,
            this.lblMapHeight,
            this.txtMapSizeY,
            this.toolStripSeparator2,
            this.cbMapExtendX,
            this.cbMapExtendY,
            this.btnMapSizeChange});
            this.menuMapSizing.Image = ((System.Drawing.Image)(resources.GetObject("menuMapSizing.Image")));
            this.menuMapSizing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuMapSizing.Name = "menuMapSizing";
            this.menuMapSizing.Size = new System.Drawing.Size(42, 22);
            this.menuMapSizing.Text = "SIZE";
            // 
            // lblMapWidth
            // 
            this.lblMapWidth.Enabled = false;
            this.lblMapWidth.Name = "lblMapWidth";
            this.lblMapWidth.Size = new System.Drawing.Size(181, 22);
            this.lblMapWidth.Text = "Width";
            // 
            // txtMapSizeX
            // 
            this.txtMapSizeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMapSizeX.Name = "txtMapSizeX";
            this.txtMapSizeX.Size = new System.Drawing.Size(100, 23);
            this.txtMapSizeX.Text = "100";
            // 
            // lblMapHeight
            // 
            this.lblMapHeight.Name = "lblMapHeight";
            this.lblMapHeight.Size = new System.Drawing.Size(181, 22);
            this.lblMapHeight.Text = "Height";
            // 
            // txtMapSizeY
            // 
            this.txtMapSizeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMapSizeY.Name = "txtMapSizeY";
            this.txtMapSizeY.Size = new System.Drawing.Size(100, 23);
            this.txtMapSizeY.Text = "100";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // cbMapExtendX
            // 
            this.cbMapExtendX.Items.AddRange(new object[] {
            "Anchor Left",
            "Anchor Center",
            "Anchor Right"});
            this.cbMapExtendX.Name = "cbMapExtendX";
            this.cbMapExtendX.Size = new System.Drawing.Size(121, 23);
            this.cbMapExtendX.Text = "Anchor Center";
            // 
            // cbMapExtendY
            // 
            this.cbMapExtendY.Items.AddRange(new object[] {
            "Anchor Top",
            "Anchor Middle",
            "Anchor Bottom"});
            this.cbMapExtendY.Name = "cbMapExtendY";
            this.cbMapExtendY.Size = new System.Drawing.Size(121, 23);
            this.cbMapExtendY.Text = "Anchor Middle";
            // 
            // btnMapSizeChange
            // 
            this.btnMapSizeChange.Name = "btnMapSizeChange";
            this.btnMapSizeChange.Size = new System.Drawing.Size(181, 22);
            this.btnMapSizeChange.Text = "CLICK TO CHANGE";
            // 
            // mapViewPanel
            // 
            this.mapViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewPanel.Location = new System.Drawing.Point(0, 0);
            this.mapViewPanel.Name = "mapViewPanel";
            this.mapViewPanel.Size = new System.Drawing.Size(662, 461);
            this.mapViewPanel.TabIndex = 0;
            this.mapViewPanel.TabStop = false;
            this.mapViewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mapViewPanel_Paint);
            this.mapViewPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_ME_down);
            this.mapViewPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_ME_move);
            this.mapViewPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanel_ME_up);
            this.mapViewPanel.Resize += new System.EventHandler(this.mapViewPanel_Resize);
            // 
            // toolpanel_splitter
            // 
            this.toolpanel_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolpanel_splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.toolpanel_splitter.Location = new System.Drawing.Point(0, 0);
            this.toolpanel_splitter.Name = "toolpanel_splitter";
            this.toolpanel_splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolpanel_splitter.Panel1Collapsed = true;
            this.toolpanel_splitter.Panel1MinSize = 0;
            // 
            // toolpanel_splitter.Panel2
            // 
            this.toolpanel_splitter.Panel2.Controls.Add(this.tabFirstLevel);
            this.toolpanel_splitter.Size = new System.Drawing.Size(231, 461);
            this.toolpanel_splitter.SplitterDistance = 25;
            this.toolpanel_splitter.TabIndex = 0;
            // 
            // tabFirstLevel
            // 
            this.tabFirstLevel.Controls.Add(this.tabTerrain);
            this.tabFirstLevel.Controls.Add(this.tabPalette);
            this.tabFirstLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFirstLevel.Location = new System.Drawing.Point(0, 0);
            this.tabFirstLevel.Name = "tabFirstLevel";
            this.tabFirstLevel.SelectedIndex = 0;
            this.tabFirstLevel.Size = new System.Drawing.Size(231, 461);
            this.tabFirstLevel.TabIndex = 0;
            // 
            // tabTerrain
            // 
            this.tabTerrain.Controls.Add(this.panelTiles);
            this.tabTerrain.Controls.Add(this.tilesCB);
            this.tabTerrain.Location = new System.Drawing.Point(4, 22);
            this.tabTerrain.Name = "tabTerrain";
            this.tabTerrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerrain.Size = new System.Drawing.Size(223, 435);
            this.tabTerrain.TabIndex = 2;
            this.tabTerrain.Text = "Terrain";
            this.tabTerrain.UseVisualStyleBackColor = true;
            // 
            // panelTiles
            // 
            this.panelTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTiles.Location = new System.Drawing.Point(3, 24);
            this.panelTiles.Name = "panelTiles";
            this.panelTiles.Size = new System.Drawing.Size(217, 408);
            this.panelTiles.TabIndex = 1;
            // 
            // tilesCB
            // 
            this.tilesCB.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilesCB.FormattingEnabled = true;
            this.tilesCB.Location = new System.Drawing.Point(3, 3);
            this.tilesCB.Name = "tilesCB";
            this.tilesCB.Size = new System.Drawing.Size(217, 21);
            this.tilesCB.TabIndex = 0;
            this.tilesCB.SelectedIndexChanged += new System.EventHandler(this.cbTile_SelectedIndexChanged);
            // 
            // tabPalette
            // 
            this.tabPalette.Controls.Add(this.tabObjectTools);
            this.tabPalette.Location = new System.Drawing.Point(4, 22);
            this.tabPalette.Margin = new System.Windows.Forms.Padding(0);
            this.tabPalette.Name = "tabPalette";
            this.tabPalette.Size = new System.Drawing.Size(223, 435);
            this.tabPalette.TabIndex = 1;
            this.tabPalette.Text = "Objects";
            this.tabPalette.UseVisualStyleBackColor = true;
            // 
            // tabObjectTools
            // 
            this.tabObjectTools.Controls.Add(this.tabObjects);
            this.tabObjectTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabObjectTools.Location = new System.Drawing.Point(0, 0);
            this.tabObjectTools.Margin = new System.Windows.Forms.Padding(0);
            this.tabObjectTools.Name = "tabObjectTools";
            this.tabObjectTools.SelectedIndex = 0;
            this.tabObjectTools.Size = new System.Drawing.Size(223, 435);
            this.tabObjectTools.TabIndex = 1;
            // 
            // tabObjects
            // 
            this.tabObjects.Controls.Add(this.obj_splitter);
            this.tabObjects.Location = new System.Drawing.Point(4, 22);
            this.tabObjects.Margin = new System.Windows.Forms.Padding(0);
            this.tabObjects.Name = "tabObjects";
            this.tabObjects.Size = new System.Drawing.Size(215, 409);
            this.tabObjects.TabIndex = 1;
            this.tabObjects.Text = "Scenary";
            this.tabObjects.UseVisualStyleBackColor = true;
            // 
            // obj_splitter
            // 
            this.obj_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.obj_splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.obj_splitter.IsSplitterFixed = true;
            this.obj_splitter.Location = new System.Drawing.Point(0, 0);
            this.obj_splitter.Margin = new System.Windows.Forms.Padding(0);
            this.obj_splitter.Name = "obj_splitter";
            this.obj_splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // obj_splitter.Panel1
            // 
            this.obj_splitter.Panel1.Controls.Add(this.btnObjectSelector);
            // 
            // obj_splitter.Panel2
            // 
            this.obj_splitter.Panel2.Controls.Add(this.pnlObjectScenicCache);
            this.obj_splitter.Panel2.Controls.Add(this.cbScenicCacheSelector);
            this.obj_splitter.Size = new System.Drawing.Size(215, 409);
            this.obj_splitter.SplitterDistance = 30;
            this.obj_splitter.TabIndex = 0;
            // 
            // btnObjectSelector
            // 
            this.btnObjectSelector.Location = new System.Drawing.Point(3, 0);
            this.btnObjectSelector.Name = "btnObjectSelector";
            this.btnObjectSelector.Size = new System.Drawing.Size(209, 23);
            this.btnObjectSelector.TabIndex = 4;
            this.btnObjectSelector.Text = "Selectorerer";
            this.btnObjectSelector.UseVisualStyleBackColor = true;
            this.btnObjectSelector.Click += new System.EventHandler(this.obj_select_btn_Click);
            // 
            // pnlObjectScenicCache
            // 
            this.pnlObjectScenicCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObjectScenicCache.Location = new System.Drawing.Point(0, 21);
            this.pnlObjectScenicCache.Name = "pnlObjectScenicCache";
            this.pnlObjectScenicCache.Size = new System.Drawing.Size(215, 354);
            this.pnlObjectScenicCache.TabIndex = 1;
            // 
            // cbScenicCacheSelector
            // 
            this.cbScenicCacheSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbScenicCacheSelector.FormattingEnabled = true;
            this.cbScenicCacheSelector.Location = new System.Drawing.Point(0, 0);
            this.cbScenicCacheSelector.Name = "cbScenicCacheSelector";
            this.cbScenicCacheSelector.Size = new System.Drawing.Size(215, 21);
            this.cbScenicCacheSelector.TabIndex = 0;
            this.cbScenicCacheSelector.SelectedIndexChanged += new System.EventHandler(this.obj_scenary_cache_CB_SelectionChangeCommitted);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 461);
            this.Controls.Add(this.main_splitter);
            this.Name = "MainWindow";
            this.Text = "Runner Builder";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.main_splitter.Panel1.ResumeLayout(false);
            this.main_splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_splitter)).EndInit();
            this.main_splitter.ResumeLayout(false);
            this.mapViewPanel_c.ResumeLayout(false);
            this.mapViewPanel_c.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapViewPanel)).EndInit();
            this.toolpanel_splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.toolpanel_splitter)).EndInit();
            this.toolpanel_splitter.ResumeLayout(false);
            this.tabFirstLevel.ResumeLayout(false);
            this.tabTerrain.ResumeLayout(false);
            this.tabPalette.ResumeLayout(false);
            this.tabObjectTools.ResumeLayout(false);
            this.tabObjects.ResumeLayout(false);
            this.obj_splitter.Panel1.ResumeLayout(false);
            this.obj_splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.obj_splitter)).EndInit();
            this.obj_splitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer main_splitter;
        private System.Windows.Forms.Panel mapViewPanel_c;
        internal System.Windows.Forms.PictureBox mapViewPanel;
        private System.Windows.Forms.SplitContainer toolpanel_splitter;
        private System.Windows.Forms.TabControl tabFirstLevel;
        private System.Windows.Forms.TabPage tabPalette;
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripComboBox cbMapPieces;
        private System.Windows.Forms.ToolStripButton btnNewPiece;
        private System.Windows.Forms.ToolStripButton btnSavePiece;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblPieceName;
        internal System.Windows.Forms.ToolStripTextBox txtPieceName;
        private System.Windows.Forms.ToolStripButton btnDeletePiece;
        private System.Windows.Forms.ToolStripButton btnDuplicate;
        internal System.Windows.Forms.ToolStripLabel lblFilename;
        private System.Windows.Forms.TabPage tabTerrain;
        private System.Windows.Forms.Panel panelTiles;
        private System.Windows.Forms.ComboBox tilesCB;
        private System.Windows.Forms.ToolStripMenuItem lblMapWidth;
        internal System.Windows.Forms.ToolStripTextBox txtMapSizeX;
        private System.Windows.Forms.ToolStripMenuItem lblMapHeight;
        internal System.Windows.Forms.ToolStripTextBox txtMapSizeY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        internal System.Windows.Forms.ToolStripComboBox cbMapExtendX;
        internal System.Windows.Forms.ToolStripDropDownButton menuMapSizing;
        internal System.Windows.Forms.ToolStripComboBox cbMapExtendY;
        internal System.Windows.Forms.ToolStripMenuItem btnMapSizeChange;
        private System.Windows.Forms.TabControl tabObjectTools;
        private System.Windows.Forms.TabPage tabObjects;
        private System.Windows.Forms.SplitContainer obj_splitter;
        private System.Windows.Forms.Button btnObjectSelector;
        internal System.Windows.Forms.Panel pnlObjectScenicCache;
        private System.Windows.Forms.ComboBox cbScenicCacheSelector;
    }
}
