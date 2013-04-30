namespace CityTools
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
            this.components = new System.ComponentModel.Container();
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
            this.btnViewMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuShowGrids = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbShowTileGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbShowObjectBases = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbShowTileBases = new System.Windows.Forms.ToolStripMenuItem();
            this.viewportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbViewportEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.txtViewportWidth = new System.Windows.Forms.ToolStripTextBox();
            this.txtViewportHeight = new System.Windows.Forms.ToolStripTextBox();
            this.btnOtherToolsMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnTileEditorTool = new System.Windows.Forms.ToolStripMenuItem();
            this.btnObjectEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnElementalEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnItemEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEquipmentEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCritterEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSoundEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.mapViewPanel = new System.Windows.Forms.PictureBox();
            this.toolpanel_splitter = new System.Windows.Forms.SplitContainer();
            this.tabFirstLevel = new System.Windows.Forms.TabControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.cbMapMusic = new System.Windows.Forms.ComboBox();
            this.lblMusic = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnMapResize = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMapExtendY = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbMapExtendX = new System.Windows.Forms.ComboBox();
            this.txtMapSizeX = new System.Windows.Forms.TextBox();
            this.txtMapSizeY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.border_1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPieceName = new System.Windows.Forms.TextBox();
            this.tabTerrain = new System.Windows.Forms.TabPage();
            this.pnlTiles = new System.Windows.Forms.Panel();
            this.cbTileGroups = new System.Windows.Forms.ComboBox();
            this.tabPalette = new System.Windows.Forms.TabPage();
            this.tabObjectTools = new System.Windows.Forms.TabControl();
            this.tabObjects = new System.Windows.Forms.TabPage();
            this.obj_splitter = new System.Windows.Forms.SplitContainer();
            this.btnObjectSelector = new System.Windows.Forms.Button();
            this.pnlObjectScenicCache = new System.Windows.Forms.Panel();
            this.cbScenicCacheSelector = new System.Windows.Forms.ComboBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnWorldEditor = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tabOptions.SuspendLayout();
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
            this.main_splitter.TabStop = false;
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
            this.btnOtherToolsMenu,
            this.toolStripSeparator2,
            this.btnExport,
            this.toolStripSeparator3,
            this.btnViewMenu});
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
            // btnViewMenu
            // 
            this.btnViewMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnViewMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowGrids,
            this.viewportToolStripMenuItem});
            this.btnViewMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnViewMenu.Image")));
            this.btnViewMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewMenu.Name = "btnViewMenu";
            this.btnViewMenu.Size = new System.Drawing.Size(45, 22);
            this.btnViewMenu.Text = "View";
            // 
            // mnuShowGrids
            // 
            this.mnuShowGrids.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ckbShowTileGrid,
            this.ckbShowObjectBases,
            this.ckbShowTileBases});
            this.mnuShowGrids.Name = "mnuShowGrids";
            this.mnuShowGrids.Size = new System.Drawing.Size(152, 22);
            this.mnuShowGrids.Text = "Grids";
            // 
            // ckbShowTileGrid
            // 
            this.ckbShowTileGrid.CheckOnClick = true;
            this.ckbShowTileGrid.Name = "ckbShowTileGrid";
            this.ckbShowTileGrid.Size = new System.Drawing.Size(190, 22);
            this.ckbShowTileGrid.Text = "Show Outlines (1)";
            // 
            // ckbShowObjectBases
            // 
            this.ckbShowObjectBases.CheckOnClick = true;
            this.ckbShowObjectBases.Name = "ckbShowObjectBases";
            this.ckbShowObjectBases.Size = new System.Drawing.Size(190, 22);
            this.ckbShowObjectBases.Text = "Show Object Bases (2)";
            // 
            // ckbShowTileBases
            // 
            this.ckbShowTileBases.CheckOnClick = true;
            this.ckbShowTileBases.Name = "ckbShowTileBases";
            this.ckbShowTileBases.Size = new System.Drawing.Size(190, 22);
            this.ckbShowTileBases.Text = "Show Tile Bases (3)";
            // 
            // viewportToolStripMenuItem
            // 
            this.viewportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ckbViewportEnabled,
            this.txtViewportWidth,
            this.txtViewportHeight});
            this.viewportToolStripMenuItem.Name = "viewportToolStripMenuItem";
            this.viewportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewportToolStripMenuItem.Text = "Viewport";
            // 
            // ckbViewportEnabled
            // 
            this.ckbViewportEnabled.CheckOnClick = true;
            this.ckbViewportEnabled.Name = "ckbViewportEnabled";
            this.ckbViewportEnabled.Size = new System.Drawing.Size(160, 22);
            this.ckbViewportEnabled.Text = "Enabled";
            // 
            // txtViewportWidth
            // 
            this.txtViewportWidth.AutoToolTip = true;
            this.txtViewportWidth.Name = "txtViewportWidth";
            this.txtViewportWidth.Size = new System.Drawing.Size(100, 23);
            this.txtViewportWidth.Text = "800";
            this.txtViewportWidth.ToolTipText = "Viewport Width";
            // 
            // txtViewportHeight
            // 
            this.txtViewportHeight.Name = "txtViewportHeight";
            this.txtViewportHeight.Size = new System.Drawing.Size(100, 23);
            this.txtViewportHeight.Text = "600";
            this.txtViewportHeight.ToolTipText = "Viewport Height";
            // 
            // btnOtherToolsMenu
            // 
            this.btnOtherToolsMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOtherToolsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOtherToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTileEditorTool,
            this.btnObjectEditor,
            this.btnElementalEditor,
            this.btnItemEditor,
            this.btnEquipmentEditor,
            this.btnCritterEditor,
            this.btnSoundEditor,
            this.btnWorldEditor});
            this.btnOtherToolsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOtherToolsMenu.Name = "btnOtherToolsMenu";
            this.btnOtherToolsMenu.Size = new System.Drawing.Size(82, 22);
            this.btnOtherToolsMenu.Text = "Other Tools";
            // 
            // btnTileEditorTool
            // 
            this.btnTileEditorTool.Name = "btnTileEditorTool";
            this.btnTileEditorTool.Size = new System.Drawing.Size(216, 22);
            this.btnTileEditorTool.Text = "Tile Editor (T)";
            this.btnTileEditorTool.Click += new System.EventHandler(this.btnTileEditorTool_Click);
            // 
            // btnObjectEditor
            // 
            this.btnObjectEditor.Name = "btnObjectEditor";
            this.btnObjectEditor.Size = new System.Drawing.Size(216, 22);
            this.btnObjectEditor.Text = "Object Template Editor (O)";
            this.btnObjectEditor.Click += new System.EventHandler(this.btnObjectEditor_Click);
            // 
            // btnElementalEditor
            // 
            this.btnElementalEditor.Name = "btnElementalEditor";
            this.btnElementalEditor.Size = new System.Drawing.Size(216, 22);
            this.btnElementalEditor.Text = "Elemental Editor (R)";
            this.btnElementalEditor.Click += new System.EventHandler(this.btnElementalEditor_Click);
            // 
            // btnItemEditor
            // 
            this.btnItemEditor.Name = "btnItemEditor";
            this.btnItemEditor.Size = new System.Drawing.Size(216, 22);
            this.btnItemEditor.Text = "Item Editor (I)";
            this.btnItemEditor.Click += new System.EventHandler(this.btnItemEditor_Click);
            // 
            // btnEquipmentEditor
            // 
            this.btnEquipmentEditor.Name = "btnEquipmentEditor";
            this.btnEquipmentEditor.Size = new System.Drawing.Size(216, 22);
            this.btnEquipmentEditor.Text = "Equipment Editor (U)";
            this.btnEquipmentEditor.Click += new System.EventHandler(this.btnEquipmentEditor_Click);
            // 
            // btnCritterEditor
            // 
            this.btnCritterEditor.Name = "btnCritterEditor";
            this.btnCritterEditor.Size = new System.Drawing.Size(216, 22);
            this.btnCritterEditor.Text = "Critter Editor (C)";
            this.btnCritterEditor.Click += new System.EventHandler(this.btnCritterEditor_Click);
            // 
            // btnSoundEditor
            // 
            this.btnSoundEditor.Name = "btnSoundEditor";
            this.btnSoundEditor.Size = new System.Drawing.Size(216, 22);
            this.btnSoundEditor.Text = "Sound Editor (Z)";
            this.btnSoundEditor.Click += new System.EventHandler(this.btnSoundEditor_Click);
            // 
            // btnExport
            // 
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(56, 22);
            this.btnExport.Text = "Test (F5)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            this.tabFirstLevel.Controls.Add(this.tabOptions);
            this.tabFirstLevel.Controls.Add(this.tabTerrain);
            this.tabFirstLevel.Controls.Add(this.tabPalette);
            this.tabFirstLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFirstLevel.Location = new System.Drawing.Point(0, 0);
            this.tabFirstLevel.Name = "tabFirstLevel";
            this.tabFirstLevel.SelectedIndex = 0;
            this.tabFirstLevel.Size = new System.Drawing.Size(231, 461);
            this.tabFirstLevel.TabIndex = 0;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.cbMapMusic);
            this.tabOptions.Controls.Add(this.lblMusic);
            this.tabOptions.Controls.Add(this.label8);
            this.tabOptions.Controls.Add(this.btnMapResize);
            this.tabOptions.Controls.Add(this.label7);
            this.tabOptions.Controls.Add(this.cbMapExtendY);
            this.tabOptions.Controls.Add(this.label6);
            this.tabOptions.Controls.Add(this.cbMapExtendX);
            this.tabOptions.Controls.Add(this.txtMapSizeX);
            this.tabOptions.Controls.Add(this.txtMapSizeY);
            this.tabOptions.Controls.Add(this.label5);
            this.tabOptions.Controls.Add(this.label4);
            this.tabOptions.Controls.Add(this.label3);
            this.tabOptions.Controls.Add(this.border_1);
            this.tabOptions.Controls.Add(this.txtFilename);
            this.tabOptions.Controls.Add(this.label2);
            this.tabOptions.Controls.Add(this.label1);
            this.tabOptions.Controls.Add(this.txtPieceName);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(223, 435);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // cbMapMusic
            // 
            this.cbMapMusic.FormattingEnabled = true;
            this.cbMapMusic.Location = new System.Drawing.Point(78, 229);
            this.cbMapMusic.Name = "cbMapMusic";
            this.cbMapMusic.Size = new System.Drawing.Size(131, 21);
            this.cbMapMusic.TabIndex = 17;
            // 
            // lblMusic
            // 
            this.lblMusic.AutoSize = true;
            this.lblMusic.Location = new System.Drawing.Point(34, 232);
            this.lblMusic.Name = "lblMusic";
            this.lblMusic.Size = new System.Drawing.Size(38, 13);
            this.lblMusic.TabIndex = 16;
            this.lblMusic.Text = "Music:";
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(11, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 1);
            this.label8.TabIndex = 15;
            // 
            // btnMapResize
            // 
            this.btnMapResize.Location = new System.Drawing.Point(120, 190);
            this.btnMapResize.Name = "btnMapResize";
            this.btnMapResize.Size = new System.Drawing.Size(89, 23);
            this.btnMapResize.TabIndex = 14;
            this.btnMapResize.Text = "Resize";
            this.btnMapResize.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Resize Y:";
            // 
            // cbMapExtendY
            // 
            this.cbMapExtendY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbMapExtendY.FormattingEnabled = true;
            this.cbMapExtendY.Items.AddRange(new object[] {
            "Anchor Top",
            "Anchor Middle",
            "Anchor Bottom"});
            this.cbMapExtendY.Location = new System.Drawing.Point(78, 163);
            this.cbMapExtendY.Name = "cbMapExtendY";
            this.cbMapExtendY.Size = new System.Drawing.Size(131, 21);
            this.cbMapExtendY.TabIndex = 12;
            this.cbMapExtendY.Text = "Anchor Middle";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Resize X:";
            // 
            // cbMapExtendX
            // 
            this.cbMapExtendX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbMapExtendX.FormattingEnabled = true;
            this.cbMapExtendX.Items.AddRange(new object[] {
            "Anchor Left",
            "Anchor Center",
            "Anchor Right"});
            this.cbMapExtendX.Location = new System.Drawing.Point(78, 136);
            this.cbMapExtendX.Name = "cbMapExtendX";
            this.cbMapExtendX.Size = new System.Drawing.Size(131, 21);
            this.cbMapExtendX.TabIndex = 10;
            this.cbMapExtendX.Text = "Anchor Center";
            // 
            // txtMapSizeX
            // 
            this.txtMapSizeX.Location = new System.Drawing.Point(78, 87);
            this.txtMapSizeX.Name = "txtMapSizeX";
            this.txtMapSizeX.Size = new System.Drawing.Size(131, 20);
            this.txtMapSizeX.TabIndex = 9;
            // 
            // txtMapSizeY
            // 
            this.txtMapSizeY.Location = new System.Drawing.Point(78, 110);
            this.txtMapSizeY.Name = "txtMapSizeY";
            this.txtMapSizeY.Size = new System.Drawing.Size(131, 20);
            this.txtMapSizeY.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Map Size (Tiles)";
            // 
            // border_1
            // 
            this.border_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.border_1.Location = new System.Drawing.Point(9, 59);
            this.border_1.Name = "border_1";
            this.border_1.Size = new System.Drawing.Size(200, 1);
            this.border_1.TabIndex = 4;
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(78, 32);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(131, 20);
            this.txtFilename.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filename:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map Name:";
            // 
            // txtPieceName
            // 
            this.txtPieceName.Location = new System.Drawing.Point(78, 6);
            this.txtPieceName.Name = "txtPieceName";
            this.txtPieceName.Size = new System.Drawing.Size(131, 20);
            this.txtPieceName.TabIndex = 0;
            // 
            // tabTerrain
            // 
            this.tabTerrain.Controls.Add(this.pnlTiles);
            this.tabTerrain.Controls.Add(this.cbTileGroups);
            this.tabTerrain.Location = new System.Drawing.Point(4, 22);
            this.tabTerrain.Name = "tabTerrain";
            this.tabTerrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerrain.Size = new System.Drawing.Size(223, 435);
            this.tabTerrain.TabIndex = 2;
            this.tabTerrain.Text = "Terrain";
            this.tabTerrain.UseVisualStyleBackColor = true;
            // 
            // pnlTiles
            // 
            this.pnlTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTiles.Location = new System.Drawing.Point(3, 24);
            this.pnlTiles.Name = "pnlTiles";
            this.pnlTiles.Size = new System.Drawing.Size(217, 408);
            this.pnlTiles.TabIndex = 1;
            // 
            // cbTileGroups
            // 
            this.cbTileGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbTileGroups.FormattingEnabled = true;
            this.cbTileGroups.Location = new System.Drawing.Point(3, 3);
            this.cbTileGroups.Name = "cbTileGroups";
            this.cbTileGroups.Size = new System.Drawing.Size(217, 21);
            this.cbTileGroups.TabIndex = 0;
            this.cbTileGroups.SelectedIndexChanged += new System.EventHandler(this.cbTile_SelectedIndexChanged);
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
            // timerRefresh
            // 
            this.timerRefresh.Interval = 50;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnWorldEditor
            // 
            this.btnWorldEditor.Name = "btnWorldEditor";
            this.btnWorldEditor.Size = new System.Drawing.Size(216, 22);
            this.btnWorldEditor.Text = "World Editor (X)";
            this.btnWorldEditor.Click += new System.EventHandler(this.btnWorldEditor_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 461);
            this.Controls.Add(this.main_splitter);
            this.Name = "MainWindow";
            this.Text = "RED: Rpg EDitor";
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
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton btnDeletePiece;
        private System.Windows.Forms.ToolStripButton btnDuplicate;
        private System.Windows.Forms.TabPage tabTerrain;
        private System.Windows.Forms.TabControl tabObjectTools;
        private System.Windows.Forms.TabPage tabObjects;
        private System.Windows.Forms.SplitContainer obj_splitter;
        private System.Windows.Forms.Button btnObjectSelector;
        internal System.Windows.Forms.Panel pnlObjectScenicCache;
        internal System.Windows.Forms.ComboBox cbTileGroups;
        private System.Windows.Forms.Timer timerRefresh;
        internal System.Windows.Forms.Panel pnlTiles;
        private System.Windows.Forms.ToolStripDropDownButton btnViewMenu;
        internal System.Windows.Forms.ToolStripMenuItem mnuShowGrids;
        private System.Windows.Forms.ToolStripMenuItem viewportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckbViewportEnabled;
        private System.Windows.Forms.ToolStripTextBox txtViewportWidth;
        private System.Windows.Forms.ToolStripTextBox txtViewportHeight;
        private System.Windows.Forms.ToolStripDropDownButton btnOtherToolsMenu;
        private System.Windows.Forms.ToolStripMenuItem btnTileEditorTool;
        private System.Windows.Forms.ToolStripMenuItem btnObjectEditor;
        internal System.Windows.Forms.ComboBox cbScenicCacheSelector;
        private System.Windows.Forms.ToolStripMenuItem btnElementalEditor;
        internal System.Windows.Forms.ToolStripMenuItem ckbShowTileGrid;
        internal System.Windows.Forms.ToolStripMenuItem ckbShowObjectBases;
        private System.Windows.Forms.ToolStripMenuItem btnItemEditor;
        private System.Windows.Forms.ToolStripMenuItem btnEquipmentEditor;
        private System.Windows.Forms.ToolStripMenuItem btnCritterEditor;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.ToolStripMenuItem ckbShowTileBases;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripMenuItem btnSoundEditor;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.Label border_1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtPieceName;
        internal System.Windows.Forms.TextBox txtFilename;
        internal System.Windows.Forms.TextBox txtMapSizeX;
        internal System.Windows.Forms.TextBox txtMapSizeY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cbMapExtendY;
        internal System.Windows.Forms.ComboBox cbMapExtendX;
        private System.Windows.Forms.Label lblMusic;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox cbMapMusic;
        internal System.Windows.Forms.Button btnMapResize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem btnWorldEditor;
    }
}

