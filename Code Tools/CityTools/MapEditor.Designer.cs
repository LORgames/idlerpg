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
            this.btnOtherToolsMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCritterEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShadowTool = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEffectEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEquipmentEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnItemEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnObjectEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSoundEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTileEditorTool = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTileMerger = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUIEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWorldEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripSplitButton();
            this.ckbExportDebugRender = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbExportShowFPS = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbExportMusicEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuShowGrids = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbShowTileGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbShowObjectBases = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbShowTileBases = new System.Windows.Forms.ToolStripMenuItem();
            this.viewportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ckbViewportEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.txtViewportWidth = new System.Windows.Forms.ToolStripTextBox();
            this.txtViewportHeight = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblHighlightedCell = new System.Windows.Forms.ToolStripLabel();
            this.mapViewPanel = new System.Windows.Forms.PictureBox();
            this.toolpanel_splitter = new System.Windows.Forms.SplitContainer();
            this.tabFirstLevel = new System.Windows.Forms.TabControl();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.btnSpawnRegionClearAreas = new System.Windows.Forms.Button();
            this.btnChangeBackground = new System.Windows.Forms.Button();
            this.numSpawnLoad = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.cbBackgroundType = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.numSpawnTimer = new System.Windows.Forms.NumericUpDown();
            this.numSpawnMax = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnRegionResize = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRegionName = new System.Windows.Forms.TextBox();
            this.cbDrawRegions = new System.Windows.Forms.CheckBox();
            this.btnDeleteRegion = new System.Windows.Forms.Button();
            this.btnAddRegion = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.listRegions = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnResetWorldPosition = new System.Windows.Forms.Button();
            this.btnPortalExit = new System.Windows.Forms.Button();
            this.btnPortalEntry = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPortalName = new System.Windows.Forms.TextBox();
            this.ckbDrawPortals = new System.Windows.Forms.CheckBox();
            this.btnDeletePortals = new System.Windows.Forms.Button();
            this.btnAddPortal = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.listPortals = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.treeTiles = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numBrushSize = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPalette = new System.Windows.Forms.TabPage();
            this.tabObjectTools = new System.Windows.Forms.TabControl();
            this.tabObjects = new System.Windows.Forms.TabPage();
            this.obj_splitter = new System.Windows.Forms.SplitContainer();
            this.pnlObjectScenicCache = new System.Windows.Forms.Panel();
            this.cbScenicCacheSelector = new System.Windows.Forms.ComboBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.timerRedrawAll = new System.Windows.Forms.Timer(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.cbExportSave = new System.Windows.Forms.ToolStripComboBox();
            this.listCritterSpawns = new CityTools.Components.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnMax)).BeginInit();
            this.tabTerrain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrushSize)).BeginInit();
            this.tabPalette.SuspendLayout();
            this.tabObjectTools.SuspendLayout();
            this.tabObjects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obj_splitter)).BeginInit();
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
            this.main_splitter.Size = new System.Drawing.Size(925, 769);
            this.main_splitter.SplitterDistance = 634;
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
            this.mapViewPanel_c.Size = new System.Drawing.Size(634, 769);
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
            this.btnViewMenu,
            this.toolStripSeparator4,
            this.lblHighlightedCell});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(634, 25);
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
            // btnOtherToolsMenu
            // 
            this.btnOtherToolsMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOtherToolsMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOtherToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCritterEditor,
            this.btnEffectEditor,
            this.btnEquipmentEditor,
            this.btnItemEditor,
            this.btnObjectEditor,
            this.btnSaveEditor,
            this.btnSoundEditor,
            this.btnTileEditorTool,
            this.btnUIEditor,
            this.btnWorldEditor});
            this.btnOtherToolsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOtherToolsMenu.Name = "btnOtherToolsMenu";
            this.btnOtherToolsMenu.Size = new System.Drawing.Size(76, 22);
            this.btnOtherToolsMenu.Text = "Other Tools";
            // 
            // btnCritterEditor
            // 
            this.btnCritterEditor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShadowTool});
            this.btnCritterEditor.Name = "btnCritterEditor";
            this.btnCritterEditor.Size = new System.Drawing.Size(214, 22);
            this.btnCritterEditor.Text = "Critter Editor (C)";
            // 
            // btnShadowTool
            // 
            this.btnShadowTool.Name = "btnShadowTool";
            this.btnShadowTool.Size = new System.Drawing.Size(146, 22);
            this.btnShadowTool.Text = "Shadow Tool";
            // 
            // btnEffectEditor
            // 
            this.btnEffectEditor.Name = "btnEffectEditor";
            this.btnEffectEditor.Size = new System.Drawing.Size(214, 22);
            this.btnEffectEditor.Text = "Effect Editor (F)";
            // 
            // btnEquipmentEditor
            // 
            this.btnEquipmentEditor.Name = "btnEquipmentEditor";
            this.btnEquipmentEditor.Size = new System.Drawing.Size(214, 22);
            this.btnEquipmentEditor.Text = "Equipment Editor (E)";
            // 
            // btnItemEditor
            // 
            this.btnItemEditor.Name = "btnItemEditor";
            this.btnItemEditor.Size = new System.Drawing.Size(214, 22);
            this.btnItemEditor.Text = "Item Editor (I)";
            // 
            // btnObjectEditor
            // 
            this.btnObjectEditor.Name = "btnObjectEditor";
            this.btnObjectEditor.Size = new System.Drawing.Size(214, 22);
            this.btnObjectEditor.Text = "Object Template Editor (O)";
            // 
            // btnSaveEditor
            // 
            this.btnSaveEditor.Name = "btnSaveEditor";
            this.btnSaveEditor.Size = new System.Drawing.Size(214, 22);
            this.btnSaveEditor.Text = "Save File Editor (V)";
            // 
            // btnSoundEditor
            // 
            this.btnSoundEditor.Name = "btnSoundEditor";
            this.btnSoundEditor.Size = new System.Drawing.Size(214, 22);
            this.btnSoundEditor.Text = "Sound Editor (Z)";
            // 
            // btnTileEditorTool
            // 
            this.btnTileEditorTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTileMerger});
            this.btnTileEditorTool.Name = "btnTileEditorTool";
            this.btnTileEditorTool.Size = new System.Drawing.Size(214, 22);
            this.btnTileEditorTool.Text = "Tile Editor (T)";
            // 
            // btnTileMerger
            // 
            this.btnTileMerger.Name = "btnTileMerger";
            this.btnTileMerger.Size = new System.Drawing.Size(138, 22);
            this.btnTileMerger.Text = "Tile Merger";
            // 
            // btnUIEditor
            // 
            this.btnUIEditor.Name = "btnUIEditor";
            this.btnUIEditor.Size = new System.Drawing.Size(214, 22);
            this.btnUIEditor.Text = "UI Editor (U)";
            // 
            // btnWorldEditor
            // 
            this.btnWorldEditor.Name = "btnWorldEditor";
            this.btnWorldEditor.Size = new System.Drawing.Size(214, 22);
            this.btnWorldEditor.Text = "World Editor (X)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ckbExportDebugRender,
            this.ckbExportShowFPS,
            this.ckbExportMusicEnabled,
            this.cbExportSave});
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 22);
            this.btnExport.Text = "Test (F5)";
            // 
            // ckbExportDebugRender
            // 
            this.ckbExportDebugRender.CheckOnClick = true;
            this.ckbExportDebugRender.Name = "ckbExportDebugRender";
            this.ckbExportDebugRender.Size = new System.Drawing.Size(181, 22);
            this.ckbExportDebugRender.Text = "Debug Render";
            this.ckbExportDebugRender.ToolTipText = "Draw Debug Rectangles?";
            // 
            // ckbExportShowFPS
            // 
            this.ckbExportShowFPS.Checked = true;
            this.ckbExportShowFPS.CheckOnClick = true;
            this.ckbExportShowFPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbExportShowFPS.Name = "ckbExportShowFPS";
            this.ckbExportShowFPS.Size = new System.Drawing.Size(181, 22);
            this.ckbExportShowFPS.Text = "Show FPS";
            this.ckbExportShowFPS.ToolTipText = "Show an FPS Display in the Top Left corner?";
            // 
            // ckbExportMusicEnabled
            // 
            this.ckbExportMusicEnabled.Checked = true;
            this.ckbExportMusicEnabled.CheckOnClick = true;
            this.ckbExportMusicEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbExportMusicEnabled.Name = "ckbExportMusicEnabled";
            this.ckbExportMusicEnabled.Size = new System.Drawing.Size(181, 22);
            this.ckbExportMusicEnabled.Text = "Music Enabled";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            this.btnViewMenu.Size = new System.Drawing.Size(42, 22);
            this.btnViewMenu.Text = "View";
            // 
            // mnuShowGrids
            // 
            this.mnuShowGrids.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ckbShowTileGrid,
            this.ckbShowObjectBases,
            this.ckbShowTileBases});
            this.mnuShowGrids.Name = "mnuShowGrids";
            this.mnuShowGrids.Size = new System.Drawing.Size(127, 22);
            this.mnuShowGrids.Text = "Grids";
            // 
            // ckbShowTileGrid
            // 
            this.ckbShowTileGrid.CheckOnClick = true;
            this.ckbShowTileGrid.Name = "ckbShowTileGrid";
            this.ckbShowTileGrid.Size = new System.Drawing.Size(194, 22);
            this.ckbShowTileGrid.Text = "Show Outlines (1)";
            // 
            // ckbShowObjectBases
            // 
            this.ckbShowObjectBases.CheckOnClick = true;
            this.ckbShowObjectBases.Name = "ckbShowObjectBases";
            this.ckbShowObjectBases.Size = new System.Drawing.Size(194, 22);
            this.ckbShowObjectBases.Text = "Show Object Bases (2)";
            // 
            // ckbShowTileBases
            // 
            this.ckbShowTileBases.CheckOnClick = true;
            this.ckbShowTileBases.Name = "ckbShowTileBases";
            this.ckbShowTileBases.Size = new System.Drawing.Size(194, 22);
            this.ckbShowTileBases.Text = "Show Tile Bases (3)";
            // 
            // viewportToolStripMenuItem
            // 
            this.viewportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ckbViewportEnabled,
            this.txtViewportWidth,
            this.txtViewportHeight});
            this.viewportToolStripMenuItem.Name = "viewportToolStripMenuItem";
            this.viewportToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
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
            this.txtViewportWidth.Size = new System.Drawing.Size(100, 21);
            this.txtViewportWidth.Text = "800";
            this.txtViewportWidth.ToolTipText = "Viewport Width";
            // 
            // txtViewportHeight
            // 
            this.txtViewportHeight.Name = "txtViewportHeight";
            this.txtViewportHeight.Size = new System.Drawing.Size(100, 21);
            this.txtViewportHeight.Text = "600";
            this.txtViewportHeight.ToolTipText = "Viewport Height";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblHighlightedCell
            // 
            this.lblHighlightedCell.Name = "lblHighlightedCell";
            this.lblHighlightedCell.Size = new System.Drawing.Size(24, 22);
            this.lblHighlightedCell.Text = "Cell";
            // 
            // mapViewPanel
            // 
            this.mapViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewPanel.Location = new System.Drawing.Point(0, 0);
            this.mapViewPanel.Name = "mapViewPanel";
            this.mapViewPanel.Size = new System.Drawing.Size(634, 769);
            this.mapViewPanel.TabIndex = 0;
            this.mapViewPanel.TabStop = false;
            this.mapViewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mapViewPanel_Paint);
            this.mapViewPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseDown);
            this.mapViewPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseMove);
            this.mapViewPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseUp);
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
            this.toolpanel_splitter.Size = new System.Drawing.Size(287, 769);
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
            this.tabFirstLevel.Size = new System.Drawing.Size(287, 769);
            this.tabFirstLevel.TabIndex = 0;
            // 
            // tabOptions
            // 
            this.tabOptions.AutoScroll = true;
            this.tabOptions.Controls.Add(this.btnSpawnRegionClearAreas);
            this.tabOptions.Controls.Add(this.btnChangeBackground);
            this.tabOptions.Controls.Add(this.numSpawnLoad);
            this.tabOptions.Controls.Add(this.label21);
            this.tabOptions.Controls.Add(this.cbBackgroundType);
            this.tabOptions.Controls.Add(this.label20);
            this.tabOptions.Controls.Add(this.label19);
            this.tabOptions.Controls.Add(this.numSpawnTimer);
            this.tabOptions.Controls.Add(this.numSpawnMax);
            this.tabOptions.Controls.Add(this.label18);
            this.tabOptions.Controls.Add(this.label17);
            this.tabOptions.Controls.Add(this.listCritterSpawns);
            this.tabOptions.Controls.Add(this.label16);
            this.tabOptions.Controls.Add(this.btnRegionResize);
            this.tabOptions.Controls.Add(this.label15);
            this.tabOptions.Controls.Add(this.txtRegionName);
            this.tabOptions.Controls.Add(this.cbDrawRegions);
            this.tabOptions.Controls.Add(this.btnDeleteRegion);
            this.tabOptions.Controls.Add(this.btnAddRegion);
            this.tabOptions.Controls.Add(this.label14);
            this.tabOptions.Controls.Add(this.listRegions);
            this.tabOptions.Controls.Add(this.label13);
            this.tabOptions.Controls.Add(this.btnResetWorldPosition);
            this.tabOptions.Controls.Add(this.btnPortalExit);
            this.tabOptions.Controls.Add(this.btnPortalEntry);
            this.tabOptions.Controls.Add(this.label12);
            this.tabOptions.Controls.Add(this.label11);
            this.tabOptions.Controls.Add(this.txtPortalName);
            this.tabOptions.Controls.Add(this.ckbDrawPortals);
            this.tabOptions.Controls.Add(this.btnDeletePortals);
            this.tabOptions.Controls.Add(this.btnAddPortal);
            this.tabOptions.Controls.Add(this.label10);
            this.tabOptions.Controls.Add(this.listPortals);
            this.tabOptions.Controls.Add(this.label9);
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
            this.tabOptions.Size = new System.Drawing.Size(279, 743);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // btnSpawnRegionClearAreas
            // 
            this.btnSpawnRegionClearAreas.Location = new System.Drawing.Point(162, 508);
            this.btnSpawnRegionClearAreas.Name = "btnSpawnRegionClearAreas";
            this.btnSpawnRegionClearAreas.Size = new System.Drawing.Size(47, 23);
            this.btnSpawnRegionClearAreas.TabIndex = 52;
            this.btnSpawnRegionClearAreas.Text = "Clear";
            this.btnSpawnRegionClearAreas.UseVisualStyleBackColor = true;
            // 
            // btnChangeBackground
            // 
            this.btnChangeBackground.Location = new System.Drawing.Point(109, 704);
            this.btnChangeBackground.Name = "btnChangeBackground";
            this.btnChangeBackground.Size = new System.Drawing.Size(100, 23);
            this.btnChangeBackground.TabIndex = 51;
            this.btnChangeBackground.Text = "Change";
            this.btnChangeBackground.UseVisualStyleBackColor = true;
            this.btnChangeBackground.Click += new System.EventHandler(this.btnChangeBackground_Click);
            // 
            // numSpawnLoad
            // 
            this.numSpawnLoad.Location = new System.Drawing.Point(85, 550);
            this.numSpawnLoad.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numSpawnLoad.Name = "numSpawnLoad";
            this.numSpawnLoad.Size = new System.Drawing.Size(59, 20);
            this.numSpawnLoad.TabIndex = 50;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(82, 534);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 13);
            this.label21.TabIndex = 49;
            this.label21.Text = "Load Count";
            // 
            // cbBackgroundType
            // 
            this.cbBackgroundType.FormattingEnabled = true;
            this.cbBackgroundType.Items.AddRange(new object[] {
            "Solid"});
            this.cbBackgroundType.Location = new System.Drawing.Point(14, 706);
            this.cbBackgroundType.Name = "cbBackgroundType";
            this.cbBackgroundType.Size = new System.Drawing.Size(89, 21);
            this.cbBackgroundType.TabIndex = 48;
            this.cbBackgroundType.Text = "Solid";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(10, 690);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 13);
            this.label20.TabIndex = 47;
            this.label20.Text = "Map Background";
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Silver;
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label19.Location = new System.Drawing.Point(36, 686);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(150, 1);
            this.label19.TabIndex = 46;
            // 
            // numSpawnTimer
            // 
            this.numSpawnTimer.Location = new System.Drawing.Point(14, 550);
            this.numSpawnTimer.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
            this.numSpawnTimer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpawnTimer.Name = "numSpawnTimer";
            this.numSpawnTimer.Size = new System.Drawing.Size(65, 20);
            this.numSpawnTimer.TabIndex = 45;
            this.numSpawnTimer.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numSpawnMax
            // 
            this.numSpawnMax.Location = new System.Drawing.Point(150, 550);
            this.numSpawnMax.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numSpawnMax.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSpawnMax.Name = "numSpawnMax";
            this.numSpawnMax.Size = new System.Drawing.Size(59, 20);
            this.numSpawnMax.TabIndex = 44;
            this.numSpawnMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(147, 534);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 13);
            this.label18.TabIndex = 43;
            this.label18.Text = "Max Critters";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 534);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 42;
            this.label17.Text = "Timeout (sec)";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Silver;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(36, 490);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(150, 1);
            this.label16.TabIndex = 40;
            // 
            // btnRegionResize
            // 
            this.btnRegionResize.Location = new System.Drawing.Point(120, 508);
            this.btnRegionResize.Name = "btnRegionResize";
            this.btnRegionResize.Size = new System.Drawing.Size(37, 23);
            this.btnRegionResize.TabIndex = 38;
            this.btnRegionResize.Text = "Add";
            this.btnRegionResize.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 495);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Spawn Region Name";
            // 
            // txtRegionName
            // 
            this.txtRegionName.Location = new System.Drawing.Point(14, 511);
            this.txtRegionName.Name = "txtRegionName";
            this.txtRegionName.Size = new System.Drawing.Size(100, 20);
            this.txtRegionName.TabIndex = 36;
            // 
            // cbDrawRegions
            // 
            this.cbDrawRegions.AutoSize = true;
            this.cbDrawRegions.Location = new System.Drawing.Point(120, 456);
            this.cbDrawRegions.Name = "cbDrawRegions";
            this.cbDrawRegions.Size = new System.Drawing.Size(65, 17);
            this.cbDrawRegions.TabIndex = 35;
            this.cbDrawRegions.Text = "Draw All";
            this.cbDrawRegions.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRegion
            // 
            this.btnDeleteRegion.Location = new System.Drawing.Point(162, 427);
            this.btnDeleteRegion.Name = "btnDeleteRegion";
            this.btnDeleteRegion.Size = new System.Drawing.Size(47, 23);
            this.btnDeleteRegion.TabIndex = 34;
            this.btnDeleteRegion.Text = "Delete";
            this.btnDeleteRegion.UseVisualStyleBackColor = true;
            // 
            // btnAddRegion
            // 
            this.btnAddRegion.Location = new System.Drawing.Point(120, 427);
            this.btnAddRegion.Name = "btnAddRegion";
            this.btnAddRegion.Size = new System.Drawing.Size(37, 23);
            this.btnAddRegion.TabIndex = 33;
            this.btnAddRegion.Text = "Add";
            this.btnAddRegion.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 411);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Spawns";
            // 
            // listRegions
            // 
            this.listRegions.FormattingEnabled = true;
            this.listRegions.Location = new System.Drawing.Point(13, 427);
            this.listRegions.Name = "listRegions";
            this.listRegions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listRegions.Size = new System.Drawing.Size(101, 56);
            this.listRegions.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Location = new System.Drawing.Point(11, 400);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(200, 1);
            this.label13.TabIndex = 30;
            // 
            // btnResetWorldPosition
            // 
            this.btnResetWorldPosition.Location = new System.Drawing.Point(23, 190);
            this.btnResetWorldPosition.Name = "btnResetWorldPosition";
            this.btnResetWorldPosition.Size = new System.Drawing.Size(91, 23);
            this.btnResetWorldPosition.TabIndex = 29;
            this.btnResetWorldPosition.Text = "Reset Location";
            this.btnResetWorldPosition.UseVisualStyleBackColor = true;
            this.btnResetWorldPosition.Click += new System.EventHandler(this.btnResetWorldPosition_Click);
            // 
            // btnPortalExit
            // 
            this.btnPortalExit.Location = new System.Drawing.Point(165, 368);
            this.btnPortalExit.Name = "btnPortalExit";
            this.btnPortalExit.Size = new System.Drawing.Size(44, 23);
            this.btnPortalExit.TabIndex = 28;
            this.btnPortalExit.Text = "Exit";
            this.btnPortalExit.UseVisualStyleBackColor = true;
            // 
            // btnPortalEntry
            // 
            this.btnPortalEntry.Location = new System.Drawing.Point(120, 368);
            this.btnPortalEntry.Name = "btnPortalEntry";
            this.btnPortalEntry.Size = new System.Drawing.Size(44, 23);
            this.btnPortalEntry.TabIndex = 27;
            this.btnPortalEntry.Text = "Entry";
            this.btnPortalEntry.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Silver;
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label12.Location = new System.Drawing.Point(36, 351);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 1);
            this.label12.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Portal Name";
            // 
            // txtPortalName
            // 
            this.txtPortalName.Location = new System.Drawing.Point(14, 371);
            this.txtPortalName.Name = "txtPortalName";
            this.txtPortalName.Size = new System.Drawing.Size(100, 20);
            this.txtPortalName.TabIndex = 24;
            // 
            // ckbDrawPortals
            // 
            this.ckbDrawPortals.AutoSize = true;
            this.ckbDrawPortals.Location = new System.Drawing.Point(120, 318);
            this.ckbDrawPortals.Name = "ckbDrawPortals";
            this.ckbDrawPortals.Size = new System.Drawing.Size(65, 17);
            this.ckbDrawPortals.TabIndex = 23;
            this.ckbDrawPortals.Text = "Draw All";
            this.ckbDrawPortals.UseVisualStyleBackColor = true;
            // 
            // btnDeletePortals
            // 
            this.btnDeletePortals.Location = new System.Drawing.Point(162, 289);
            this.btnDeletePortals.Name = "btnDeletePortals";
            this.btnDeletePortals.Size = new System.Drawing.Size(47, 23);
            this.btnDeletePortals.TabIndex = 22;
            this.btnDeletePortals.Text = "Delete";
            this.btnDeletePortals.UseVisualStyleBackColor = true;
            // 
            // btnAddPortal
            // 
            this.btnAddPortal.Location = new System.Drawing.Point(120, 289);
            this.btnAddPortal.Name = "btnAddPortal";
            this.btnAddPortal.Size = new System.Drawing.Size(37, 23);
            this.btnAddPortal.TabIndex = 21;
            this.btnAddPortal.Text = "Add";
            this.btnAddPortal.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Portals";
            // 
            // listPortals
            // 
            this.listPortals.FormattingEnabled = true;
            this.listPortals.Location = new System.Drawing.Point(13, 289);
            this.listPortals.Name = "listPortals";
            this.listPortals.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listPortals.Size = new System.Drawing.Size(101, 56);
            this.listPortals.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(11, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 1);
            this.label9.TabIndex = 18;
            // 
            // cbMapMusic
            // 
            this.cbMapMusic.FormattingEnabled = true;
            this.cbMapMusic.Location = new System.Drawing.Point(78, 233);
            this.cbMapMusic.Name = "cbMapMusic";
            this.cbMapMusic.Size = new System.Drawing.Size(131, 21);
            this.cbMapMusic.TabIndex = 17;
            // 
            // lblMusic
            // 
            this.lblMusic.AutoSize = true;
            this.lblMusic.Location = new System.Drawing.Point(34, 236);
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
            this.tabTerrain.Controls.Add(this.treeTiles);
            this.tabTerrain.Controls.Add(this.panel1);
            this.tabTerrain.Location = new System.Drawing.Point(4, 22);
            this.tabTerrain.Name = "tabTerrain";
            this.tabTerrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerrain.Size = new System.Drawing.Size(279, 743);
            this.tabTerrain.TabIndex = 2;
            this.tabTerrain.Text = "Terrain";
            this.tabTerrain.UseVisualStyleBackColor = true;
            // 
            // treeTiles
            // 
            this.treeTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTiles.Location = new System.Drawing.Point(3, 36);
            this.treeTiles.Name = "treeTiles";
            this.treeTiles.Size = new System.Drawing.Size(273, 704);
            this.treeTiles.TabIndex = 3;
            this.treeTiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeTiles_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numBrushSize);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 33);
            this.panel1.TabIndex = 2;
            // 
            // numBrushSize
            // 
            this.numBrushSize.Location = new System.Drawing.Point(93, 6);
            this.numBrushSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBrushSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBrushSize.Name = "numBrushSize";
            this.numBrushSize.Size = new System.Drawing.Size(129, 20);
            this.numBrushSize.TabIndex = 1;
            this.numBrushSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(3, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "Paint Brush Size";
            // 
            // tabPalette
            // 
            this.tabPalette.Controls.Add(this.tabObjectTools);
            this.tabPalette.Location = new System.Drawing.Point(4, 22);
            this.tabPalette.Margin = new System.Windows.Forms.Padding(0);
            this.tabPalette.Name = "tabPalette";
            this.tabPalette.Size = new System.Drawing.Size(279, 743);
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
            this.tabObjectTools.Size = new System.Drawing.Size(279, 743);
            this.tabObjectTools.TabIndex = 1;
            // 
            // tabObjects
            // 
            this.tabObjects.Controls.Add(this.obj_splitter);
            this.tabObjects.Location = new System.Drawing.Point(4, 22);
            this.tabObjects.Margin = new System.Windows.Forms.Padding(0);
            this.tabObjects.Name = "tabObjects";
            this.tabObjects.Size = new System.Drawing.Size(271, 717);
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
            // obj_splitter.Panel2
            // 
            this.obj_splitter.Panel2.Controls.Add(this.pnlObjectScenicCache);
            this.obj_splitter.Panel2.Controls.Add(this.cbScenicCacheSelector);
            this.obj_splitter.Size = new System.Drawing.Size(271, 717);
            this.obj_splitter.SplitterDistance = 30;
            this.obj_splitter.TabIndex = 0;
            // 
            // pnlObjectScenicCache
            // 
            this.pnlObjectScenicCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlObjectScenicCache.Location = new System.Drawing.Point(0, 21);
            this.pnlObjectScenicCache.Name = "pnlObjectScenicCache";
            this.pnlObjectScenicCache.Size = new System.Drawing.Size(271, 662);
            this.pnlObjectScenicCache.TabIndex = 1;
            // 
            // cbScenicCacheSelector
            // 
            this.cbScenicCacheSelector.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbScenicCacheSelector.FormattingEnabled = true;
            this.cbScenicCacheSelector.Location = new System.Drawing.Point(0, 0);
            this.cbScenicCacheSelector.Name = "cbScenicCacheSelector";
            this.cbScenicCacheSelector.Size = new System.Drawing.Size(271, 21);
            this.cbScenicCacheSelector.TabIndex = 0;
            this.cbScenicCacheSelector.SelectedIndexChanged += new System.EventHandler(this.obj_scenary_cache_CB_SelectionChangeCommitted);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 50;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // timerRedrawAll
            // 
            this.timerRedrawAll.Tick += new System.EventHandler(this.timerRedraw_Tick);
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            this.colorDialog.SolidColorOnly = true;
            // 
            // cbExportSave
            // 
            this.cbExportSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportSave.Items.AddRange(new object[] {
            "No Save"});
            this.cbExportSave.Name = "cbExportSave";
            this.cbExportSave.Size = new System.Drawing.Size(121, 21);
            // 
            // listCritterSpawns
            // 
            this.listCritterSpawns.AllowColumnReorder = true;
            this.listCritterSpawns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listCritterSpawns.DoubleClickActivation = false;
            this.listCritterSpawns.FullRowSelect = true;
            this.listCritterSpawns.Location = new System.Drawing.Point(14, 576);
            this.listCritterSpawns.Name = "listCritterSpawns";
            this.listCritterSpawns.Size = new System.Drawing.Size(195, 103);
            this.listCritterSpawns.TabIndex = 41;
            this.listCritterSpawns.UseCompatibleStateImageBehavior = false;
            this.listCritterSpawns.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Critter";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Spawn%";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 769);
            this.Controls.Add(this.main_splitter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnMax)).EndInit();
            this.tabTerrain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrushSize)).EndInit();
            this.tabPalette.ResumeLayout(false);
            this.tabObjectTools.ResumeLayout(false);
            this.tabObjects.ResumeLayout(false);
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
        internal System.Windows.Forms.Panel pnlObjectScenicCache;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.ToolStripDropDownButton btnViewMenu;
        internal System.Windows.Forms.ToolStripMenuItem mnuShowGrids;
        private System.Windows.Forms.ToolStripMenuItem viewportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ckbViewportEnabled;
        private System.Windows.Forms.ToolStripTextBox txtViewportWidth;
        private System.Windows.Forms.ToolStripTextBox txtViewportHeight;
        private System.Windows.Forms.ToolStripDropDownButton btnOtherToolsMenu;
        internal System.Windows.Forms.ToolStripMenuItem btnTileEditorTool;
        internal System.Windows.Forms.ToolStripMenuItem btnObjectEditor;
        internal System.Windows.Forms.ComboBox cbScenicCacheSelector;
        internal System.Windows.Forms.ToolStripMenuItem ckbShowTileGrid;
        internal System.Windows.Forms.ToolStripMenuItem ckbShowObjectBases;
        internal System.Windows.Forms.ToolStripMenuItem btnItemEditor;
        internal System.Windows.Forms.ToolStripMenuItem btnEquipmentEditor;
        internal System.Windows.Forms.ToolStripMenuItem btnCritterEditor;
        private System.Windows.Forms.Timer timerRedrawAll;
        internal System.Windows.Forms.ToolStripMenuItem ckbShowTileBases;
        internal System.Windows.Forms.ToolStripMenuItem btnSoundEditor;
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
        internal System.Windows.Forms.ToolStripMenuItem btnWorldEditor;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Button btnDeletePortals;
        internal System.Windows.Forms.Button btnAddPortal;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ListBox listPortals;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.TextBox txtPortalName;
        internal System.Windows.Forms.Button btnPortalExit;
        internal System.Windows.Forms.Button btnPortalEntry;
        internal System.Windows.Forms.CheckBox ckbDrawPortals;
        private System.Windows.Forms.Button btnResetWorldPosition;
        internal System.Windows.Forms.CheckBox cbDrawRegions;
        internal System.Windows.Forms.Button btnDeleteRegion;
        internal System.Windows.Forms.Button btnAddRegion;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ListBox listRegions;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Button btnRegionResize;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txtRegionName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        internal System.Windows.Forms.NumericUpDown numSpawnTimer;
        internal System.Windows.Forms.NumericUpDown numSpawnMax;
        internal Components.ListViewEx listCritterSpawns;
        internal System.Windows.Forms.NumericUpDown numSpawnLoad;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.ComboBox cbBackgroundType;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnChangeBackground;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblHighlightedCell;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.NumericUpDown numBrushSize;
        internal System.Windows.Forms.Button btnSpawnRegionClearAreas;
        internal System.Windows.Forms.TreeView treeTiles;
        internal System.Windows.Forms.ToolStripMenuItem btnTileMerger;
        internal System.Windows.Forms.ToolStripMenuItem btnShadowTool;
        internal System.Windows.Forms.ToolStripSplitButton btnExport;
        internal System.Windows.Forms.ToolStripMenuItem ckbExportDebugRender;
        internal System.Windows.Forms.ToolStripMenuItem ckbExportShowFPS;
        internal System.Windows.Forms.ToolStripMenuItem btnUIEditor;
        internal System.Windows.Forms.ToolStripMenuItem btnEffectEditor;
        internal System.Windows.Forms.ToolStripMenuItem ckbExportMusicEnabled;
        internal System.Windows.Forms.ToolStripMenuItem btnSaveEditor;
        internal System.Windows.Forms.ToolStripComboBox cbExportSave;
    }
}

