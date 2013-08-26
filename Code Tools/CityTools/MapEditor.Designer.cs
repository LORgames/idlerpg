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
            this.btnGlobalSettingsEditor = new System.Windows.Forms.ToolStripButton();
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
            this.btnPortraitEditor = new System.Windows.Forms.ToolStripMenuItem();
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
            this.cbExportSave = new System.Windows.Forms.ToolStripComboBox();
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
            this.btnChangeBackground = new System.Windows.Forms.Button();
            this.cbBackgroundType = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbMapMusic = new System.Windows.Forms.ComboBox();
            this.lblMusic = new System.Windows.Forms.Label();
            this.btnMapResize = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMapExtendY = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbMapExtendX = new System.Windows.Forms.ComboBox();
            this.txtMapSizeX = new System.Windows.Forms.TextBox();
            this.txtMapSizeY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPieceName = new System.Windows.Forms.TextBox();
            this.tabTerrain = new System.Windows.Forms.TabPage();
            this.listTiles = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numBrushSize = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPalette = new System.Windows.Forms.TabPage();
            this.listObjects = new System.Windows.Forms.ListView();
            this.tabMapScript = new System.Windows.Forms.TabPage();
            this.tabMapRegions = new System.Windows.Forms.TabPage();
            this.btnScriptRegionAreaClear = new System.Windows.Forms.Button();
            this.btnScriptRegionAreaAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtScriptRegionName = new System.Windows.Forms.TextBox();
            this.ckbDrawScriptRegions = new System.Windows.Forms.CheckBox();
            this.btnScriptRegionDelete = new System.Windows.Forms.Button();
            this.btnScriptRegionAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listScriptRegions = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNormalizeSpawnRegion = new System.Windows.Forms.Button();
            this.numSpawnChance = new System.Windows.Forms.NumericUpDown();
            this.btnSpawnAreaClear = new System.Windows.Forms.Button();
            this.numSpawnLoad = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.numSpawnTimer = new System.Windows.Forms.NumericUpDown();
            this.numSpawnMax = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSpawnAreaAdd = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSpawnName = new System.Windows.Forms.TextBox();
            this.ckbDrawSpawns = new System.Windows.Forms.CheckBox();
            this.btnSpawnDelete = new System.Windows.Forms.Button();
            this.btnSpawnAdd = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.listSpawns = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnPortalEntry = new System.Windows.Forms.Button();
            this.txtPortalName = new System.Windows.Forms.TextBox();
            this.ckbDrawPortals = new System.Windows.Forms.CheckBox();
            this.btnPortalDelete = new System.Windows.Forms.Button();
            this.btnPortalAdd = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.listPortals = new System.Windows.Forms.ListBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.timerRedrawAll = new System.Windows.Forms.Timer(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.scriptScriptRegion = new CityTools.Components.ScriptBox();
            this.listSpawnCritters = new CityTools.Components.ListViewEx();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scriptMap = new CityTools.Components.ScriptBox();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrushSize)).BeginInit();
            this.tabPalette.SuspendLayout();
            this.tabMapScript.SuspendLayout();
            this.tabMapRegions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnChance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnMax)).BeginInit();
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
            this.main_splitter.Size = new System.Drawing.Size(925, 811);
            this.main_splitter.SplitterDistance = 605;
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
            this.mapViewPanel_c.Size = new System.Drawing.Size(605, 811);
            this.mapViewPanel_c.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGlobalSettingsEditor,
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
            this.toolStrip1.Size = new System.Drawing.Size(605, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGlobalSettingsEditor
            // 
            this.btnGlobalSettingsEditor.Image = global::CityTools.Properties.Resources.Monster;
            this.btnGlobalSettingsEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGlobalSettingsEditor.Name = "btnGlobalSettingsEditor";
            this.btnGlobalSettingsEditor.Size = new System.Drawing.Size(125, 22);
            this.btnGlobalSettingsEditor.Text = "Global Settings (G)";
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
            this.btnPortraitEditor,
            this.btnSaveEditor,
            this.btnSoundEditor,
            this.btnTileEditorTool,
            this.btnUIEditor,
            this.btnWorldEditor});
            this.btnOtherToolsMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOtherToolsMenu.Name = "btnOtherToolsMenu";
            this.btnOtherToolsMenu.Size = new System.Drawing.Size(82, 22);
            this.btnOtherToolsMenu.Text = "Other Tools";
            // 
            // btnCritterEditor
            // 
            this.btnCritterEditor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShadowTool});
            this.btnCritterEditor.Image = global::CityTools.Properties.Resources.Monster;
            this.btnCritterEditor.Name = "btnCritterEditor";
            this.btnCritterEditor.Size = new System.Drawing.Size(216, 22);
            this.btnCritterEditor.Text = "Critter Editor (C)";
            // 
            // btnShadowTool
            // 
            this.btnShadowTool.Name = "btnShadowTool";
            this.btnShadowTool.Size = new System.Drawing.Size(143, 22);
            this.btnShadowTool.Text = "Shadow Tool";
            // 
            // btnEffectEditor
            // 
            this.btnEffectEditor.Image = global::CityTools.Properties.Resources.bomb;
            this.btnEffectEditor.Name = "btnEffectEditor";
            this.btnEffectEditor.Size = new System.Drawing.Size(216, 22);
            this.btnEffectEditor.Text = "Effect Editor (F)";
            // 
            // btnEquipmentEditor
            // 
            this.btnEquipmentEditor.Image = global::CityTools.Properties.Resources.mouse;
            this.btnEquipmentEditor.Name = "btnEquipmentEditor";
            this.btnEquipmentEditor.Size = new System.Drawing.Size(216, 22);
            this.btnEquipmentEditor.Text = "Equipment Editor (E)";
            // 
            // btnItemEditor
            // 
            this.btnItemEditor.Image = global::CityTools.Properties.Resources.bell;
            this.btnItemEditor.Name = "btnItemEditor";
            this.btnItemEditor.Size = new System.Drawing.Size(216, 22);
            this.btnItemEditor.Text = "Item Editor (I)";
            // 
            // btnObjectEditor
            // 
            this.btnObjectEditor.Image = global::CityTools.Properties.Resources.attach;
            this.btnObjectEditor.Name = "btnObjectEditor";
            this.btnObjectEditor.Size = new System.Drawing.Size(216, 22);
            this.btnObjectEditor.Text = "Object Template Editor (O)";
            // 
            // btnPortraitEditor
            // 
            this.btnPortraitEditor.Image = global::CityTools.Properties.Resources.Humanoid;
            this.btnPortraitEditor.Name = "btnPortraitEditor";
            this.btnPortraitEditor.Size = new System.Drawing.Size(216, 22);
            this.btnPortraitEditor.Text = "Portrait Editor (P)";
            // 
            // btnSaveEditor
            // 
            this.btnSaveEditor.Image = global::CityTools.Properties.Resources.disk;
            this.btnSaveEditor.Name = "btnSaveEditor";
            this.btnSaveEditor.Size = new System.Drawing.Size(216, 22);
            this.btnSaveEditor.Text = "Save File Editor (V)";
            // 
            // btnSoundEditor
            // 
            this.btnSoundEditor.Image = global::CityTools.Properties.Resources.music;
            this.btnSoundEditor.Name = "btnSoundEditor";
            this.btnSoundEditor.Size = new System.Drawing.Size(216, 22);
            this.btnSoundEditor.Text = "Sound Editor (Z)";
            // 
            // btnTileEditorTool
            // 
            this.btnTileEditorTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTileMerger});
            this.btnTileEditorTool.Image = global::CityTools.Properties.Resources.application_double;
            this.btnTileEditorTool.Name = "btnTileEditorTool";
            this.btnTileEditorTool.Size = new System.Drawing.Size(216, 22);
            this.btnTileEditorTool.Text = "Tile Editor (T)";
            // 
            // btnTileMerger
            // 
            this.btnTileMerger.Name = "btnTileMerger";
            this.btnTileMerger.Size = new System.Drawing.Size(134, 22);
            this.btnTileMerger.Text = "Tile Merger";
            // 
            // btnUIEditor
            // 
            this.btnUIEditor.Image = global::CityTools.Properties.Resources.application_view_gallery;
            this.btnUIEditor.Name = "btnUIEditor";
            this.btnUIEditor.Size = new System.Drawing.Size(216, 22);
            this.btnUIEditor.Text = "UI Editor (U)";
            // 
            // btnWorldEditor
            // 
            this.btnWorldEditor.Image = global::CityTools.Properties.Resources.world;
            this.btnWorldEditor.Name = "btnWorldEditor";
            this.btnWorldEditor.Size = new System.Drawing.Size(216, 22);
            this.btnWorldEditor.Text = "World Editor (X)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnExport
            // 
            this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ckbExportDebugRender,
            this.ckbExportShowFPS,
            this.ckbExportMusicEnabled,
            this.cbExportSave});
            this.btnExport.Image = global::CityTools.Properties.Resources.bug;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 22);
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
            // cbExportSave
            // 
            this.cbExportSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExportSave.Items.AddRange(new object[] {
            "No Save"});
            this.cbExportSave.Name = "cbExportSave";
            this.cbExportSave.Size = new System.Drawing.Size(121, 23);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblHighlightedCell
            // 
            this.lblHighlightedCell.Name = "lblHighlightedCell";
            this.lblHighlightedCell.Size = new System.Drawing.Size(27, 15);
            this.lblHighlightedCell.Text = "Cell";
            // 
            // mapViewPanel
            // 
            this.mapViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewPanel.Location = new System.Drawing.Point(0, 0);
            this.mapViewPanel.Name = "mapViewPanel";
            this.mapViewPanel.Size = new System.Drawing.Size(605, 811);
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
            this.toolpanel_splitter.Size = new System.Drawing.Size(316, 811);
            this.toolpanel_splitter.SplitterDistance = 25;
            this.toolpanel_splitter.TabIndex = 0;
            // 
            // tabFirstLevel
            // 
            this.tabFirstLevel.Controls.Add(this.tabOptions);
            this.tabFirstLevel.Controls.Add(this.tabTerrain);
            this.tabFirstLevel.Controls.Add(this.tabPalette);
            this.tabFirstLevel.Controls.Add(this.tabMapRegions);
            this.tabFirstLevel.Controls.Add(this.tabMapScript);
            this.tabFirstLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFirstLevel.Location = new System.Drawing.Point(0, 0);
            this.tabFirstLevel.Name = "tabFirstLevel";
            this.tabFirstLevel.SelectedIndex = 0;
            this.tabFirstLevel.Size = new System.Drawing.Size(316, 811);
            this.tabFirstLevel.TabIndex = 0;
            // 
            // tabOptions
            // 
            this.tabOptions.AutoScroll = true;
            this.tabOptions.Controls.Add(this.btnChangeBackground);
            this.tabOptions.Controls.Add(this.cbBackgroundType);
            this.tabOptions.Controls.Add(this.label20);
            this.tabOptions.Controls.Add(this.cbMapMusic);
            this.tabOptions.Controls.Add(this.lblMusic);
            this.tabOptions.Controls.Add(this.btnMapResize);
            this.tabOptions.Controls.Add(this.label7);
            this.tabOptions.Controls.Add(this.cbMapExtendY);
            this.tabOptions.Controls.Add(this.label6);
            this.tabOptions.Controls.Add(this.cbMapExtendX);
            this.tabOptions.Controls.Add(this.txtMapSizeX);
            this.tabOptions.Controls.Add(this.txtMapSizeY);
            this.tabOptions.Controls.Add(this.label5);
            this.tabOptions.Controls.Add(this.label4);
            this.tabOptions.Controls.Add(this.label1);
            this.tabOptions.Controls.Add(this.txtPieceName);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(308, 785);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // btnChangeBackground
            // 
            this.btnChangeBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChangeBackground.Location = new System.Drawing.Point(169, 221);
            this.btnChangeBackground.Name = "btnChangeBackground";
            this.btnChangeBackground.Size = new System.Drawing.Size(131, 23);
            this.btnChangeBackground.TabIndex = 51;
            this.btnChangeBackground.Text = "Change Background";
            this.btnChangeBackground.UseVisualStyleBackColor = true;
            this.btnChangeBackground.Click += new System.EventHandler(this.btnChangeBackground_Click);
            // 
            // cbBackgroundType
            // 
            this.cbBackgroundType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBackgroundType.FormattingEnabled = true;
            this.cbBackgroundType.Items.AddRange(new object[] {
            "Solid"});
            this.cbBackgroundType.Location = new System.Drawing.Point(169, 194);
            this.cbBackgroundType.Name = "cbBackgroundType";
            this.cbBackgroundType.Size = new System.Drawing.Size(131, 21);
            this.cbBackgroundType.TabIndex = 48;
            this.cbBackgroundType.Text = "Solid";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(74, 197);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 13);
            this.label20.TabIndex = 47;
            this.label20.Text = "Map Background";
            // 
            // cbMapMusic
            // 
            this.cbMapMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMapMusic.FormattingEnabled = true;
            this.cbMapMusic.Location = new System.Drawing.Point(169, 167);
            this.cbMapMusic.Name = "cbMapMusic";
            this.cbMapMusic.Size = new System.Drawing.Size(131, 21);
            this.cbMapMusic.TabIndex = 17;
            // 
            // lblMusic
            // 
            this.lblMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMusic.AutoSize = true;
            this.lblMusic.Location = new System.Drawing.Point(125, 170);
            this.lblMusic.Name = "lblMusic";
            this.lblMusic.Size = new System.Drawing.Size(38, 13);
            this.lblMusic.TabIndex = 16;
            this.lblMusic.Text = "Music:";
            // 
            // btnMapResize
            // 
            this.btnMapResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapResize.Location = new System.Drawing.Point(169, 138);
            this.btnMapResize.Name = "btnMapResize";
            this.btnMapResize.Size = new System.Drawing.Size(131, 23);
            this.btnMapResize.TabIndex = 14;
            this.btnMapResize.Text = "Resize";
            this.btnMapResize.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Resize Y:";
            // 
            // cbMapExtendY
            // 
            this.cbMapExtendY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMapExtendY.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbMapExtendY.FormattingEnabled = true;
            this.cbMapExtendY.Items.AddRange(new object[] {
            "Anchor Top",
            "Anchor Middle",
            "Anchor Bottom"});
            this.cbMapExtendY.Location = new System.Drawing.Point(169, 111);
            this.cbMapExtendY.Name = "cbMapExtendY";
            this.cbMapExtendY.Size = new System.Drawing.Size(131, 21);
            this.cbMapExtendY.TabIndex = 12;
            this.cbMapExtendY.Text = "Anchor Middle";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Resize X:";
            // 
            // cbMapExtendX
            // 
            this.cbMapExtendX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMapExtendX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbMapExtendX.FormattingEnabled = true;
            this.cbMapExtendX.Items.AddRange(new object[] {
            "Anchor Left",
            "Anchor Center",
            "Anchor Right"});
            this.cbMapExtendX.Location = new System.Drawing.Point(169, 84);
            this.cbMapExtendX.Name = "cbMapExtendX";
            this.cbMapExtendX.Size = new System.Drawing.Size(131, 21);
            this.cbMapExtendX.TabIndex = 10;
            this.cbMapExtendX.Text = "Anchor Center";
            // 
            // txtMapSizeX
            // 
            this.txtMapSizeX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapSizeX.Location = new System.Drawing.Point(169, 32);
            this.txtMapSizeX.Name = "txtMapSizeX";
            this.txtMapSizeX.Size = new System.Drawing.Size(131, 20);
            this.txtMapSizeX.TabIndex = 9;
            // 
            // txtMapSizeY
            // 
            this.txtMapSizeY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMapSizeY.Location = new System.Drawing.Point(169, 58);
            this.txtMapSizeY.Name = "txtMapSizeY";
            this.txtMapSizeY.Size = new System.Drawing.Size(131, 20);
            this.txtMapSizeY.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Tile Height:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(105, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tile Width:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map Name:";
            // 
            // txtPieceName
            // 
            this.txtPieceName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPieceName.Location = new System.Drawing.Point(169, 6);
            this.txtPieceName.Name = "txtPieceName";
            this.txtPieceName.Size = new System.Drawing.Size(131, 20);
            this.txtPieceName.TabIndex = 0;
            // 
            // tabTerrain
            // 
            this.tabTerrain.Controls.Add(this.listTiles);
            this.tabTerrain.Controls.Add(this.panel1);
            this.tabTerrain.Location = new System.Drawing.Point(4, 22);
            this.tabTerrain.Name = "tabTerrain";
            this.tabTerrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerrain.Size = new System.Drawing.Size(308, 785);
            this.tabTerrain.TabIndex = 2;
            this.tabTerrain.Text = "Tiles";
            this.tabTerrain.UseVisualStyleBackColor = true;
            // 
            // listTiles
            // 
            this.listTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listTiles.Location = new System.Drawing.Point(3, 36);
            this.listTiles.Name = "listTiles";
            this.listTiles.Size = new System.Drawing.Size(302, 746);
            this.listTiles.TabIndex = 3;
            this.listTiles.UseCompatibleStateImageBehavior = false;
            this.listTiles.SelectedIndexChanged += new System.EventHandler(this.listTiles_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numBrushSize);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 33);
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
            this.tabPalette.Controls.Add(this.listObjects);
            this.tabPalette.Location = new System.Drawing.Point(4, 22);
            this.tabPalette.Margin = new System.Windows.Forms.Padding(0);
            this.tabPalette.Name = "tabPalette";
            this.tabPalette.Size = new System.Drawing.Size(308, 785);
            this.tabPalette.TabIndex = 1;
            this.tabPalette.Text = "Objects";
            this.tabPalette.UseVisualStyleBackColor = true;
            // 
            // listObjects
            // 
            this.listObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listObjects.Location = new System.Drawing.Point(0, 0);
            this.listObjects.Name = "listObjects";
            this.listObjects.Size = new System.Drawing.Size(308, 785);
            this.listObjects.TabIndex = 0;
            this.listObjects.UseCompatibleStateImageBehavior = false;
            this.listObjects.SelectedIndexChanged += new System.EventHandler(this.listObjects_SelectedIndexChanged);
            // 
            // tabMapScript
            // 
            this.tabMapScript.Controls.Add(this.scriptMap);
            this.tabMapScript.Location = new System.Drawing.Point(4, 22);
            this.tabMapScript.Name = "tabMapScript";
            this.tabMapScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabMapScript.Size = new System.Drawing.Size(308, 785);
            this.tabMapScript.TabIndex = 4;
            this.tabMapScript.Text = "Scripting";
            this.tabMapScript.UseVisualStyleBackColor = true;
            // 
            // tabMapRegions
            // 
            this.tabMapRegions.Controls.Add(this.scriptScriptRegion);
            this.tabMapRegions.Controls.Add(this.btnScriptRegionAreaClear);
            this.tabMapRegions.Controls.Add(this.btnScriptRegionAreaAdd);
            this.tabMapRegions.Controls.Add(this.label3);
            this.tabMapRegions.Controls.Add(this.txtScriptRegionName);
            this.tabMapRegions.Controls.Add(this.ckbDrawScriptRegions);
            this.tabMapRegions.Controls.Add(this.btnScriptRegionDelete);
            this.tabMapRegions.Controls.Add(this.btnScriptRegionAdd);
            this.tabMapRegions.Controls.Add(this.label8);
            this.tabMapRegions.Controls.Add(this.listScriptRegions);
            this.tabMapRegions.Controls.Add(this.label2);
            this.tabMapRegions.Controls.Add(this.btnNormalizeSpawnRegion);
            this.tabMapRegions.Controls.Add(this.numSpawnChance);
            this.tabMapRegions.Controls.Add(this.btnSpawnAreaClear);
            this.tabMapRegions.Controls.Add(this.numSpawnLoad);
            this.tabMapRegions.Controls.Add(this.label21);
            this.tabMapRegions.Controls.Add(this.numSpawnTimer);
            this.tabMapRegions.Controls.Add(this.numSpawnMax);
            this.tabMapRegions.Controls.Add(this.label18);
            this.tabMapRegions.Controls.Add(this.label17);
            this.tabMapRegions.Controls.Add(this.listSpawnCritters);
            this.tabMapRegions.Controls.Add(this.label16);
            this.tabMapRegions.Controls.Add(this.btnSpawnAreaAdd);
            this.tabMapRegions.Controls.Add(this.label15);
            this.tabMapRegions.Controls.Add(this.txtSpawnName);
            this.tabMapRegions.Controls.Add(this.ckbDrawSpawns);
            this.tabMapRegions.Controls.Add(this.btnSpawnDelete);
            this.tabMapRegions.Controls.Add(this.btnSpawnAdd);
            this.tabMapRegions.Controls.Add(this.label14);
            this.tabMapRegions.Controls.Add(this.listSpawns);
            this.tabMapRegions.Controls.Add(this.label11);
            this.tabMapRegions.Controls.Add(this.btnPortalEntry);
            this.tabMapRegions.Controls.Add(this.txtPortalName);
            this.tabMapRegions.Controls.Add(this.ckbDrawPortals);
            this.tabMapRegions.Controls.Add(this.btnPortalDelete);
            this.tabMapRegions.Controls.Add(this.btnPortalAdd);
            this.tabMapRegions.Controls.Add(this.label10);
            this.tabMapRegions.Controls.Add(this.listPortals);
            this.tabMapRegions.Location = new System.Drawing.Point(4, 22);
            this.tabMapRegions.Name = "tabMapRegions";
            this.tabMapRegions.Size = new System.Drawing.Size(308, 785);
            this.tabMapRegions.TabIndex = 5;
            this.tabMapRegions.Text = "Regions";
            this.tabMapRegions.UseVisualStyleBackColor = true;
            // 
            // btnScriptRegionAreaClear
            // 
            this.btnScriptRegionAreaClear.Location = new System.Drawing.Point(100, 524);
            this.btnScriptRegionAreaClear.Name = "btnScriptRegionAreaClear";
            this.btnScriptRegionAreaClear.Size = new System.Drawing.Size(78, 23);
            this.btnScriptRegionAreaClear.TabIndex = 85;
            this.btnScriptRegionAreaClear.Text = "Clear Areas";
            this.btnScriptRegionAreaClear.UseVisualStyleBackColor = true;
            // 
            // btnScriptRegionAreaAdd
            // 
            this.btnScriptRegionAreaAdd.Location = new System.Drawing.Point(18, 524);
            this.btnScriptRegionAreaAdd.Name = "btnScriptRegionAreaAdd";
            this.btnScriptRegionAreaAdd.Size = new System.Drawing.Size(78, 23);
            this.btnScriptRegionAreaAdd.TabIndex = 84;
            this.btnScriptRegionAreaAdd.Text = "Add Areas";
            this.btnScriptRegionAreaAdd.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 83;
            this.label3.Text = "Name:";
            // 
            // txtScriptRegionName
            // 
            this.txtScriptRegionName.Location = new System.Drawing.Point(63, 498);
            this.txtScriptRegionName.Name = "txtScriptRegionName";
            this.txtScriptRegionName.Size = new System.Drawing.Size(114, 20);
            this.txtScriptRegionName.TabIndex = 80;
            // 
            // ckbDrawScriptRegions
            // 
            this.ckbDrawScriptRegions.AutoSize = true;
            this.ckbDrawScriptRegions.Location = new System.Drawing.Point(205, 465);
            this.ckbDrawScriptRegions.Name = "ckbDrawScriptRegions";
            this.ckbDrawScriptRegions.Size = new System.Drawing.Size(65, 17);
            this.ckbDrawScriptRegions.TabIndex = 79;
            this.ckbDrawScriptRegions.Text = "Draw All";
            this.ckbDrawScriptRegions.UseVisualStyleBackColor = true;
            // 
            // btnScriptRegionDelete
            // 
            this.btnScriptRegionDelete.Image = global::CityTools.Properties.Resources.delete;
            this.btnScriptRegionDelete.Location = new System.Drawing.Point(234, 436);
            this.btnScriptRegionDelete.Name = "btnScriptRegionDelete";
            this.btnScriptRegionDelete.Size = new System.Drawing.Size(23, 23);
            this.btnScriptRegionDelete.TabIndex = 78;
            this.btnScriptRegionDelete.UseVisualStyleBackColor = true;
            // 
            // btnScriptRegionAdd
            // 
            this.btnScriptRegionAdd.Image = global::CityTools.Properties.Resources.add;
            this.btnScriptRegionAdd.Location = new System.Drawing.Point(205, 436);
            this.btnScriptRegionAdd.Name = "btnScriptRegionAdd";
            this.btnScriptRegionAdd.Size = new System.Drawing.Size(23, 23);
            this.btnScriptRegionAdd.TabIndex = 77;
            this.btnScriptRegionAdd.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 76;
            this.label8.Text = "Script Regions";
            // 
            // listScriptRegions
            // 
            this.listScriptRegions.FormattingEnabled = true;
            this.listScriptRegions.Location = new System.Drawing.Point(18, 436);
            this.listScriptRegions.Name = "listScriptRegions";
            this.listScriptRegions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listScriptRegions.Size = new System.Drawing.Size(181, 56);
            this.listScriptRegions.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(17, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 1);
            this.label2.TabIndex = 74;
            // 
            // btnNormalizeSpawnRegion
            // 
            this.btnNormalizeSpawnRegion.Location = new System.Drawing.Point(17, 383);
            this.btnNormalizeSpawnRegion.Name = "btnNormalizeSpawnRegion";
            this.btnNormalizeSpawnRegion.Size = new System.Drawing.Size(89, 23);
            this.btnNormalizeSpawnRegion.TabIndex = 73;
            this.btnNormalizeSpawnRegion.Text = "Fix Spawn%";
            this.btnNormalizeSpawnRegion.UseVisualStyleBackColor = true;
            // 
            // numSpawnChance
            // 
            this.numSpawnChance.Location = new System.Drawing.Point(131, 340);
            this.numSpawnChance.Name = "numSpawnChance";
            this.numSpawnChance.Size = new System.Drawing.Size(48, 20);
            this.numSpawnChance.TabIndex = 72;
            this.numSpawnChance.TabStop = false;
            this.numSpawnChance.Visible = false;
            // 
            // btnSpawnAreaClear
            // 
            this.btnSpawnAreaClear.Location = new System.Drawing.Point(194, 383);
            this.btnSpawnAreaClear.Name = "btnSpawnAreaClear";
            this.btnSpawnAreaClear.Size = new System.Drawing.Size(76, 23);
            this.btnSpawnAreaClear.TabIndex = 71;
            this.btnSpawnAreaClear.Text = "Clear Areas";
            this.btnSpawnAreaClear.UseVisualStyleBackColor = true;
            // 
            // numSpawnLoad
            // 
            this.numSpawnLoad.Location = new System.Drawing.Point(104, 248);
            this.numSpawnLoad.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numSpawnLoad.Name = "numSpawnLoad";
            this.numSpawnLoad.Size = new System.Drawing.Size(80, 20);
            this.numSpawnLoad.TabIndex = 70;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(101, 232);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(62, 13);
            this.label21.TabIndex = 69;
            this.label21.Text = "Load Count";
            // 
            // numSpawnTimer
            // 
            this.numSpawnTimer.Location = new System.Drawing.Point(17, 248);
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
            this.numSpawnTimer.Size = new System.Drawing.Size(80, 20);
            this.numSpawnTimer.TabIndex = 68;
            this.numSpawnTimer.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numSpawnMax
            // 
            this.numSpawnMax.Location = new System.Drawing.Point(190, 248);
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
            this.numSpawnMax.Size = new System.Drawing.Size(80, 20);
            this.numSpawnMax.TabIndex = 67;
            this.numSpawnMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(187, 232);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 13);
            this.label18.TabIndex = 66;
            this.label18.Text = "Max Critters";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 232);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 65;
            this.label17.Text = "Timeout (sec)";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Silver;
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label16.Location = new System.Drawing.Point(14, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(260, 1);
            this.label16.TabIndex = 63;
            // 
            // btnSpawnAreaAdd
            // 
            this.btnSpawnAreaAdd.Location = new System.Drawing.Point(112, 383);
            this.btnSpawnAreaAdd.Name = "btnSpawnAreaAdd";
            this.btnSpawnAreaAdd.Size = new System.Drawing.Size(76, 23);
            this.btnSpawnAreaAdd.TabIndex = 62;
            this.btnSpawnAreaAdd.Text = "Add Areas";
            this.btnSpawnAreaAdd.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 13);
            this.label15.TabIndex = 61;
            this.label15.Text = "Name:";
            // 
            // txtSpawnName
            // 
            this.txtSpawnName.Location = new System.Drawing.Point(58, 205);
            this.txtSpawnName.Name = "txtSpawnName";
            this.txtSpawnName.Size = new System.Drawing.Size(117, 20);
            this.txtSpawnName.TabIndex = 60;
            // 
            // ckbDrawSpawns
            // 
            this.ckbDrawSpawns.AutoSize = true;
            this.ckbDrawSpawns.Location = new System.Drawing.Point(205, 172);
            this.ckbDrawSpawns.Name = "ckbDrawSpawns";
            this.ckbDrawSpawns.Size = new System.Drawing.Size(65, 17);
            this.ckbDrawSpawns.TabIndex = 59;
            this.ckbDrawSpawns.Text = "Draw All";
            this.ckbDrawSpawns.UseVisualStyleBackColor = true;
            // 
            // btnSpawnDelete
            // 
            this.btnSpawnDelete.Image = global::CityTools.Properties.Resources.delete;
            this.btnSpawnDelete.Location = new System.Drawing.Point(234, 143);
            this.btnSpawnDelete.Name = "btnSpawnDelete";
            this.btnSpawnDelete.Size = new System.Drawing.Size(23, 23);
            this.btnSpawnDelete.TabIndex = 58;
            this.btnSpawnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSpawnAdd
            // 
            this.btnSpawnAdd.Image = global::CityTools.Properties.Resources.add;
            this.btnSpawnAdd.Location = new System.Drawing.Point(205, 143);
            this.btnSpawnAdd.Name = "btnSpawnAdd";
            this.btnSpawnAdd.Size = new System.Drawing.Size(23, 23);
            this.btnSpawnAdd.TabIndex = 57;
            this.btnSpawnAdd.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "Spawns";
            // 
            // listSpawns
            // 
            this.listSpawns.FormattingEnabled = true;
            this.listSpawns.Location = new System.Drawing.Point(16, 143);
            this.listSpawns.Name = "listSpawns";
            this.listSpawns.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listSpawns.Size = new System.Drawing.Size(183, 56);
            this.listSpawns.TabIndex = 55;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Name:";
            // 
            // btnPortalEntry
            // 
            this.btnPortalEntry.Location = new System.Drawing.Point(181, 84);
            this.btnPortalEntry.Name = "btnPortalEntry";
            this.btnPortalEntry.Size = new System.Drawing.Size(89, 20);
            this.btnPortalEntry.TabIndex = 36;
            this.btnPortalEntry.Text = "Change Area";
            this.btnPortalEntry.UseVisualStyleBackColor = true;
            // 
            // txtPortalName
            // 
            this.txtPortalName.Location = new System.Drawing.Point(58, 84);
            this.txtPortalName.Name = "txtPortalName";
            this.txtPortalName.Size = new System.Drawing.Size(117, 20);
            this.txtPortalName.TabIndex = 34;
            // 
            // ckbDrawPortals
            // 
            this.ckbDrawPortals.AutoSize = true;
            this.ckbDrawPortals.Location = new System.Drawing.Point(205, 51);
            this.ckbDrawPortals.Name = "ckbDrawPortals";
            this.ckbDrawPortals.Size = new System.Drawing.Size(65, 17);
            this.ckbDrawPortals.TabIndex = 33;
            this.ckbDrawPortals.Text = "Draw All";
            this.ckbDrawPortals.UseVisualStyleBackColor = true;
            // 
            // btnPortalDelete
            // 
            this.btnPortalDelete.Image = global::CityTools.Properties.Resources.delete;
            this.btnPortalDelete.Location = new System.Drawing.Point(234, 22);
            this.btnPortalDelete.Name = "btnPortalDelete";
            this.btnPortalDelete.Size = new System.Drawing.Size(23, 23);
            this.btnPortalDelete.TabIndex = 32;
            this.btnPortalDelete.UseVisualStyleBackColor = true;
            // 
            // btnPortalAdd
            // 
            this.btnPortalAdd.Image = global::CityTools.Properties.Resources.add;
            this.btnPortalAdd.Location = new System.Drawing.Point(205, 22);
            this.btnPortalAdd.Name = "btnPortalAdd";
            this.btnPortalAdd.Size = new System.Drawing.Size(23, 23);
            this.btnPortalAdd.TabIndex = 31;
            this.btnPortalAdd.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Portals";
            // 
            // listPortals
            // 
            this.listPortals.FormattingEnabled = true;
            this.listPortals.Location = new System.Drawing.Point(13, 22);
            this.listPortals.Name = "listPortals";
            this.listPortals.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listPortals.Size = new System.Drawing.Size(186, 56);
            this.listPortals.TabIndex = 29;
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
            // scriptScriptRegion
            // 
            this.scriptScriptRegion.Location = new System.Drawing.Point(3, 552);
            this.scriptScriptRegion.Name = "scriptScriptRegion";
            this.scriptScriptRegion.Script = "";
            this.scriptScriptRegion.ScriptType = ToolCache.Scripting.ScriptTypes.Region;
            this.scriptScriptRegion.Size = new System.Drawing.Size(297, 225);
            this.scriptScriptRegion.TabIndex = 86;
            // 
            // listSpawnCritters
            // 
            this.listSpawnCritters.AllowColumnReorder = true;
            this.listSpawnCritters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listSpawnCritters.DoubleClickActivation = false;
            this.listSpawnCritters.FullRowSelect = true;
            this.listSpawnCritters.Location = new System.Drawing.Point(17, 274);
            this.listSpawnCritters.Name = "listSpawnCritters";
            this.listSpawnCritters.Size = new System.Drawing.Size(253, 103);
            this.listSpawnCritters.TabIndex = 64;
            this.listSpawnCritters.UseCompatibleStateImageBehavior = false;
            this.listSpawnCritters.View = System.Windows.Forms.View.Details;
            this.listSpawnCritters.SubItemClicked += new CityTools.Components.SubItemEventHandler(this.listCritterSpawns_SubItemClicked);
            this.listSpawnCritters.SubItemEndEditing += new CityTools.Components.SubItemEndEditingEventHandler(this.listCritterSpawns_SubItemEndEditing);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Critter";
            this.columnHeader1.Width = 181;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Spawn%";
            // 
            // scriptMap
            // 
            this.scriptMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptMap.Location = new System.Drawing.Point(3, 3);
            this.scriptMap.Name = "scriptMap";
            this.scriptMap.Script = "";
            this.scriptMap.ScriptType = ToolCache.Scripting.ScriptTypes.Map;
            this.scriptMap.Size = new System.Drawing.Size(302, 779);
            this.scriptMap.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 811);
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
            this.tabTerrain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBrushSize)).EndInit();
            this.tabPalette.ResumeLayout(false);
            this.tabMapScript.ResumeLayout(false);
            this.tabMapRegions.ResumeLayout(false);
            this.tabMapRegions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnChance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpawnMax)).EndInit();
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
        internal System.Windows.Forms.ToolStripMenuItem ckbShowTileGrid;
        internal System.Windows.Forms.ToolStripMenuItem ckbShowObjectBases;
        internal System.Windows.Forms.ToolStripMenuItem btnItemEditor;
        internal System.Windows.Forms.ToolStripMenuItem btnEquipmentEditor;
        internal System.Windows.Forms.ToolStripMenuItem btnCritterEditor;
        private System.Windows.Forms.Timer timerRedrawAll;
        internal System.Windows.Forms.ToolStripMenuItem ckbShowTileBases;
        internal System.Windows.Forms.ToolStripMenuItem btnSoundEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        internal System.Windows.Forms.ToolStripMenuItem btnWorldEditor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblHighlightedCell;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label22;
        internal System.Windows.Forms.NumericUpDown numBrushSize;
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
        internal System.Windows.Forms.ListView listTiles;
        private System.Windows.Forms.TabPage tabMapScript;
        internal Components.ScriptBox scriptMap;
        internal System.Windows.Forms.ToolStripMenuItem btnPortraitEditor;
        internal System.Windows.Forms.ToolStripButton btnGlobalSettingsEditor;
        private System.Windows.Forms.TabPage tabOptions;
        internal System.Windows.Forms.ComboBox cbMapMusic;
        private System.Windows.Forms.Label lblMusic;
        internal System.Windows.Forms.Button btnMapResize;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox cbMapExtendY;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cbMapExtendX;
        internal System.Windows.Forms.TextBox txtMapSizeX;
        internal System.Windows.Forms.TextBox txtMapSizeY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtPieceName;
        private System.Windows.Forms.TabPage tabMapRegions;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Button btnPortalEntry;
        internal System.Windows.Forms.TextBox txtPortalName;
        internal System.Windows.Forms.CheckBox ckbDrawPortals;
        internal System.Windows.Forms.Button btnPortalDelete;
        internal System.Windows.Forms.Button btnPortalAdd;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ListBox listPortals;
        private System.Windows.Forms.Button btnNormalizeSpawnRegion;
        private System.Windows.Forms.NumericUpDown numSpawnChance;
        internal System.Windows.Forms.Button btnSpawnAreaClear;
        internal System.Windows.Forms.NumericUpDown numSpawnLoad;
        private System.Windows.Forms.Label label21;
        internal System.Windows.Forms.NumericUpDown numSpawnTimer;
        internal System.Windows.Forms.NumericUpDown numSpawnMax;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        internal Components.ListViewEx listSpawnCritters;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label16;
        internal System.Windows.Forms.Button btnSpawnAreaAdd;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txtSpawnName;
        internal System.Windows.Forms.CheckBox ckbDrawSpawns;
        internal System.Windows.Forms.Button btnSpawnDelete;
        internal System.Windows.Forms.Button btnSpawnAdd;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ListBox listSpawns;
        internal System.Windows.Forms.ComboBox cbBackgroundType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnChangeBackground;
        internal System.Windows.Forms.ListView listObjects;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtScriptRegionName;
        internal System.Windows.Forms.CheckBox ckbDrawScriptRegions;
        internal System.Windows.Forms.Button btnScriptRegionDelete;
        internal System.Windows.Forms.Button btnScriptRegionAdd;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ListBox listScriptRegions;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnScriptRegionAreaClear;
        internal System.Windows.Forms.Button btnScriptRegionAreaAdd;
        internal Components.ScriptBox scriptScriptRegion;
    }
}

