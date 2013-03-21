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
            this.combo_mappieces = new System.Windows.Forms.ToolStripComboBox();
            this.newPieceBtn = new System.Windows.Forms.ToolStripButton();
            this.deleteBtn = new System.Windows.Forms.ToolStripButton();
            this.duplicateBtn = new System.Windows.Forms.ToolStripButton();
            this.savePieceBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtPieceName = new System.Windows.Forms.ToolStripTextBox();
            this.lblFilename = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.mapTileWidth = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.mapHeight = new System.Windows.Forms.ToolStripTextBox();
            this.mapViewPanel = new System.Windows.Forms.PictureBox();
            this.toolpanel_splitter = new System.Windows.Forms.SplitContainer();
            this.first_level_tabControl = new System.Windows.Forms.TabControl();
            this.terrain_tab = new System.Windows.Forms.TabPage();
            this.tilesPanel = new System.Windows.Forms.Panel();
            this.tilesCB = new System.Windows.Forms.ComboBox();
            this.palette_tab = new System.Windows.Forms.TabPage();
            this.tool_tabs = new System.Windows.Forms.TabControl();
            this.objects_tab = new System.Windows.Forms.TabPage();
            this.obj_splitter = new System.Windows.Forms.SplitContainer();
            this.obj_select_btn = new System.Windows.Forms.Button();
            this.obj_rot = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.obj_scenary_objs = new System.Windows.Forms.Panel();
            this.obj_scenary_cache_CB = new System.Windows.Forms.ComboBox();
            this.physics_tab = new System.Windows.Forms.TabPage();
            this.phys_delete = new System.Windows.Forms.Button();
            this.phys_add_edge = new System.Windows.Forms.Button();
            this.phys_add_ellipse = new System.Windows.Forms.Button();
            this.phys_add_rect = new System.Windows.Forms.Button();
            this.places_tab = new System.Windows.Forms.TabPage();
            this.places_selector_btn = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSendBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBringForward = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSendToBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmBringToFront = new System.Windows.Forms.ToolStripMenuItem();
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
            this.first_level_tabControl.SuspendLayout();
            this.terrain_tab.SuspendLayout();
            this.palette_tab.SuspendLayout();
            this.tool_tabs.SuspendLayout();
            this.objects_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obj_splitter)).BeginInit();
            this.obj_splitter.Panel1.SuspendLayout();
            this.obj_splitter.Panel2.SuspendLayout();
            this.obj_splitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obj_rot)).BeginInit();
            this.physics_tab.SuspendLayout();
            this.places_tab.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.main_splitter.Size = new System.Drawing.Size(853, 461);
            this.main_splitter.SplitterDistance = 618;
            this.main_splitter.TabIndex = 0;
            // 
            // mapViewPanel_c
            // 
            this.mapViewPanel_c.Controls.Add(this.toolStrip1);
            this.mapViewPanel_c.Controls.Add(this.mapViewPanel);
            this.mapViewPanel_c.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewPanel_c.Location = new System.Drawing.Point(0, 0);
            this.mapViewPanel_c.Name = "mapViewPanel_c";
            this.mapViewPanel_c.Size = new System.Drawing.Size(618, 461);
            this.mapViewPanel_c.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combo_mappieces,
            this.newPieceBtn,
            this.deleteBtn,
            this.duplicateBtn,
            this.savePieceBtn,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtPieceName,
            this.lblFilename,
            this.toolStripLabel3,
            this.mapTileWidth,
            this.toolStripLabel2,
            this.mapHeight});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(618, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // combo_mappieces
            // 
            this.combo_mappieces.Name = "combo_mappieces";
            this.combo_mappieces.Size = new System.Drawing.Size(121, 25);
            // 
            // newPieceBtn
            // 
            this.newPieceBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newPieceBtn.Image = ((System.Drawing.Image)(resources.GetObject("newPieceBtn.Image")));
            this.newPieceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newPieceBtn.Name = "newPieceBtn";
            this.newPieceBtn.Size = new System.Drawing.Size(23, 22);
            this.newPieceBtn.Text = "New Map Piece";
            this.newPieceBtn.Click += new System.EventHandler(this.newPieceBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteBtn.Image")));
            this.deleteBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(23, 22);
            this.deleteBtn.Text = "Delete Piece";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // duplicateBtn
            // 
            this.duplicateBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.duplicateBtn.Image = ((System.Drawing.Image)(resources.GetObject("duplicateBtn.Image")));
            this.duplicateBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.duplicateBtn.Name = "duplicateBtn";
            this.duplicateBtn.Size = new System.Drawing.Size(23, 22);
            this.duplicateBtn.Text = "Duplicate Piece";
            this.duplicateBtn.Click += new System.EventHandler(this.duplicateBtn_Click);
            // 
            // savePieceBtn
            // 
            this.savePieceBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.savePieceBtn.Image = ((System.Drawing.Image)(resources.GetObject("savePieceBtn.Image")));
            this.savePieceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.savePieceBtn.Name = "savePieceBtn";
            this.savePieceBtn.Size = new System.Drawing.Size(23, 22);
            this.savePieceBtn.Text = "Save Map Piece";
            this.savePieceBtn.Click += new System.EventHandler(this.savePieceClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabel1.Text = "Piece Name:";
            // 
            // txtPieceName
            // 
            this.txtPieceName.Name = "txtPieceName";
            this.txtPieceName.Size = new System.Drawing.Size(100, 25);
            // 
            // lblFilename
            // 
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(53, 22);
            this.lblFilename.Text = "<Empty>";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel3.Text = "Size:";
            // 
            // mapTileWidth
            // 
            this.mapTileWidth.MaxLength = 6;
            this.mapTileWidth.Name = "mapTileWidth";
            this.mapTileWidth.Size = new System.Drawing.Size(30, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel2.Text = "x";
            // 
            // mapHeight
            // 
            this.mapHeight.Name = "mapHeight";
            this.mapHeight.Size = new System.Drawing.Size(30, 25);
            // 
            // mapViewPanel
            // 
            this.mapViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapViewPanel.Location = new System.Drawing.Point(0, 0);
            this.mapViewPanel.Name = "mapViewPanel";
            this.mapViewPanel.Size = new System.Drawing.Size(618, 461);
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
            this.toolpanel_splitter.Panel2.Controls.Add(this.first_level_tabControl);
            this.toolpanel_splitter.Size = new System.Drawing.Size(231, 461);
            this.toolpanel_splitter.SplitterDistance = 25;
            this.toolpanel_splitter.TabIndex = 0;
            // 
            // first_level_tabControl
            // 
            this.first_level_tabControl.Controls.Add(this.terrain_tab);
            this.first_level_tabControl.Controls.Add(this.palette_tab);
            this.first_level_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.first_level_tabControl.Location = new System.Drawing.Point(0, 0);
            this.first_level_tabControl.Name = "first_level_tabControl";
            this.first_level_tabControl.SelectedIndex = 0;
            this.first_level_tabControl.Size = new System.Drawing.Size(231, 461);
            this.first_level_tabControl.TabIndex = 0;
            // 
            // terrain_tab
            // 
            this.terrain_tab.Controls.Add(this.tilesPanel);
            this.terrain_tab.Controls.Add(this.tilesCB);
            this.terrain_tab.Location = new System.Drawing.Point(4, 22);
            this.terrain_tab.Name = "terrain_tab";
            this.terrain_tab.Padding = new System.Windows.Forms.Padding(3);
            this.terrain_tab.Size = new System.Drawing.Size(223, 435);
            this.terrain_tab.TabIndex = 2;
            this.terrain_tab.Text = "Terrain";
            this.terrain_tab.UseVisualStyleBackColor = true;
            // 
            // tilesPanel
            // 
            this.tilesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilesPanel.Location = new System.Drawing.Point(3, 24);
            this.tilesPanel.Name = "tilesPanel";
            this.tilesPanel.Size = new System.Drawing.Size(217, 408);
            this.tilesPanel.TabIndex = 1;
            // 
            // tilesCB
            // 
            this.tilesCB.Dock = System.Windows.Forms.DockStyle.Top;
            this.tilesCB.FormattingEnabled = true;
            this.tilesCB.Location = new System.Drawing.Point(3, 3);
            this.tilesCB.Name = "tilesCB";
            this.tilesCB.Size = new System.Drawing.Size(217, 21);
            this.tilesCB.TabIndex = 0;
            this.tilesCB.SelectedIndexChanged += new System.EventHandler(this.tilesCB_SelectedIndexChanged);
            // 
            // palette_tab
            // 
            this.palette_tab.Controls.Add(this.tool_tabs);
            this.palette_tab.Location = new System.Drawing.Point(4, 22);
            this.palette_tab.Margin = new System.Windows.Forms.Padding(0);
            this.palette_tab.Name = "palette_tab";
            this.palette_tab.Size = new System.Drawing.Size(223, 435);
            this.palette_tab.TabIndex = 1;
            this.palette_tab.Text = "Objects";
            this.palette_tab.UseVisualStyleBackColor = true;
            // 
            // tool_tabs
            // 
            this.tool_tabs.Controls.Add(this.objects_tab);
            this.tool_tabs.Controls.Add(this.physics_tab);
            this.tool_tabs.Controls.Add(this.places_tab);
            this.tool_tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tool_tabs.Location = new System.Drawing.Point(0, 0);
            this.tool_tabs.Margin = new System.Windows.Forms.Padding(0);
            this.tool_tabs.Name = "tool_tabs";
            this.tool_tabs.SelectedIndex = 0;
            this.tool_tabs.Size = new System.Drawing.Size(223, 435);
            this.tool_tabs.TabIndex = 1;
            // 
            // objects_tab
            // 
            this.objects_tab.Controls.Add(this.obj_splitter);
            this.objects_tab.Location = new System.Drawing.Point(4, 22);
            this.objects_tab.Margin = new System.Windows.Forms.Padding(0);
            this.objects_tab.Name = "objects_tab";
            this.objects_tab.Size = new System.Drawing.Size(215, 409);
            this.objects_tab.TabIndex = 1;
            this.objects_tab.Text = "Scenary";
            this.objects_tab.UseVisualStyleBackColor = true;
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
            this.obj_splitter.Panel1.Controls.Add(this.obj_select_btn);
            this.obj_splitter.Panel1.Controls.Add(this.obj_rot);
            this.obj_splitter.Panel1.Controls.Add(this.label2);
            // 
            // obj_splitter.Panel2
            // 
            this.obj_splitter.Panel2.Controls.Add(this.obj_scenary_objs);
            this.obj_splitter.Panel2.Controls.Add(this.obj_scenary_cache_CB);
            this.obj_splitter.Size = new System.Drawing.Size(215, 409);
            this.obj_splitter.SplitterDistance = 30;
            this.obj_splitter.TabIndex = 0;
            // 
            // obj_select_btn
            // 
            this.obj_select_btn.Location = new System.Drawing.Point(136, 4);
            this.obj_select_btn.Name = "obj_select_btn";
            this.obj_select_btn.Size = new System.Drawing.Size(75, 23);
            this.obj_select_btn.TabIndex = 4;
            this.obj_select_btn.Text = "Selectorerer";
            this.obj_select_btn.UseVisualStyleBackColor = true;
            this.obj_select_btn.Click += new System.EventHandler(this.obj_select_btn_Click);
            // 
            // obj_rot
            // 
            this.obj_rot.Increment = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.obj_rot.Location = new System.Drawing.Point(53, 4);
            this.obj_rot.Maximum = new decimal(new int[] {
            315,
            0,
            0,
            0});
            this.obj_rot.Name = "obj_rot";
            this.obj_rot.Size = new System.Drawing.Size(45, 20);
            this.obj_rot.TabIndex = 2;
            this.obj_rot.ValueChanged += new System.EventHandler(this.obj_settings_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rotation";
            // 
            // obj_scenary_objs
            // 
            this.obj_scenary_objs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.obj_scenary_objs.Location = new System.Drawing.Point(0, 21);
            this.obj_scenary_objs.Name = "obj_scenary_objs";
            this.obj_scenary_objs.Size = new System.Drawing.Size(215, 354);
            this.obj_scenary_objs.TabIndex = 1;
            // 
            // obj_scenary_cache_CB
            // 
            this.obj_scenary_cache_CB.Dock = System.Windows.Forms.DockStyle.Top;
            this.obj_scenary_cache_CB.FormattingEnabled = true;
            this.obj_scenary_cache_CB.Location = new System.Drawing.Point(0, 0);
            this.obj_scenary_cache_CB.Name = "obj_scenary_cache_CB";
            this.obj_scenary_cache_CB.Size = new System.Drawing.Size(215, 21);
            this.obj_scenary_cache_CB.TabIndex = 0;
            this.obj_scenary_cache_CB.SelectedIndexChanged += new System.EventHandler(this.obj_scenary_cache_CB_SelectionChangeCommitted);
            // 
            // physics_tab
            // 
            this.physics_tab.Controls.Add(this.phys_delete);
            this.physics_tab.Controls.Add(this.phys_add_edge);
            this.physics_tab.Controls.Add(this.phys_add_ellipse);
            this.physics_tab.Controls.Add(this.phys_add_rect);
            this.physics_tab.Location = new System.Drawing.Point(4, 22);
            this.physics_tab.Name = "physics_tab";
            this.physics_tab.Size = new System.Drawing.Size(215, 409);
            this.physics_tab.TabIndex = 2;
            this.physics_tab.Text = "Physics";
            this.physics_tab.UseVisualStyleBackColor = true;
            // 
            // phys_delete
            // 
            this.phys_delete.Location = new System.Drawing.Point(4, 93);
            this.phys_delete.Name = "phys_delete";
            this.phys_delete.Size = new System.Drawing.Size(207, 23);
            this.phys_delete.TabIndex = 3;
            this.phys_delete.Text = "Delete Physics";
            this.phys_delete.UseVisualStyleBackColor = true;
            this.phys_delete.Click += new System.EventHandler(this.phys_add_shape);
            // 
            // phys_add_edge
            // 
            this.phys_add_edge.Location = new System.Drawing.Point(4, 64);
            this.phys_add_edge.Name = "phys_add_edge";
            this.phys_add_edge.Size = new System.Drawing.Size(207, 23);
            this.phys_add_edge.TabIndex = 2;
            this.phys_add_edge.Text = "Draw Physics Edge";
            this.phys_add_edge.UseVisualStyleBackColor = true;
            this.phys_add_edge.Click += new System.EventHandler(this.phys_add_shape);
            // 
            // phys_add_ellipse
            // 
            this.phys_add_ellipse.Location = new System.Drawing.Point(4, 34);
            this.phys_add_ellipse.Name = "phys_add_ellipse";
            this.phys_add_ellipse.Size = new System.Drawing.Size(207, 23);
            this.phys_add_ellipse.TabIndex = 1;
            this.phys_add_ellipse.Text = "Draw Physics Circle";
            this.phys_add_ellipse.UseVisualStyleBackColor = true;
            this.phys_add_ellipse.Click += new System.EventHandler(this.phys_add_shape);
            // 
            // phys_add_rect
            // 
            this.phys_add_rect.Location = new System.Drawing.Point(4, 4);
            this.phys_add_rect.Name = "phys_add_rect";
            this.phys_add_rect.Size = new System.Drawing.Size(207, 23);
            this.phys_add_rect.TabIndex = 0;
            this.phys_add_rect.Text = "Draw Physics Rectangle";
            this.phys_add_rect.UseVisualStyleBackColor = true;
            this.phys_add_rect.Click += new System.EventHandler(this.phys_add_shape);
            // 
            // places_tab
            // 
            this.places_tab.Controls.Add(this.places_selector_btn);
            this.places_tab.Location = new System.Drawing.Point(4, 22);
            this.places_tab.Name = "places_tab";
            this.places_tab.Size = new System.Drawing.Size(215, 409);
            this.places_tab.TabIndex = 4;
            this.places_tab.Text = "Places";
            this.places_tab.UseVisualStyleBackColor = true;
            // 
            // places_selector_btn
            // 
            this.places_selector_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.places_selector_btn.Location = new System.Drawing.Point(0, 0);
            this.places_selector_btn.Name = "places_selector_btn";
            this.places_selector_btn.Size = new System.Drawing.Size(215, 23);
            this.places_selector_btn.TabIndex = 0;
            this.places_selector_btn.Text = "Places Selector";
            this.places_selector_btn.UseVisualStyleBackColor = true;
            this.places_selector_btn.Click += new System.EventHandler(this.places_select_btn_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSendBack,
            this.tsmBringForward,
            this.tsmSendToBack,
            this.tsmBringToFront});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // tsmSendBack
            // 
            this.tsmSendBack.Name = "tsmSendBack";
            this.tsmSendBack.Size = new System.Drawing.Size(152, 22);
            this.tsmSendBack.Text = "Send Back";
            this.tsmSendBack.Click += new System.EventHandler(this.tsmSendBack_Click);
            // 
            // tsmBringForward
            // 
            this.tsmBringForward.Name = "tsmBringForward";
            this.tsmBringForward.Size = new System.Drawing.Size(152, 22);
            this.tsmBringForward.Text = "Bring Forward";
            this.tsmBringForward.Click += new System.EventHandler(this.tsmBringForward_Click);
            // 
            // tsmSendToBack
            // 
            this.tsmSendToBack.Name = "tsmSendToBack";
            this.tsmSendToBack.Size = new System.Drawing.Size(152, 22);
            this.tsmSendToBack.Text = "Send to Back";
            this.tsmSendToBack.Click += new System.EventHandler(this.tsmSendToBack_Click);
            // 
            // tsmBringToFront
            // 
            this.tsmBringToFront.Name = "tsmBringToFront";
            this.tsmBringToFront.Size = new System.Drawing.Size(152, 22);
            this.tsmBringToFront.Text = "Bring to Front";
            this.tsmBringToFront.Click += new System.EventHandler(this.tsmBringToFront_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 461);
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
            this.first_level_tabControl.ResumeLayout(false);
            this.terrain_tab.ResumeLayout(false);
            this.palette_tab.ResumeLayout(false);
            this.tool_tabs.ResumeLayout(false);
            this.objects_tab.ResumeLayout(false);
            this.obj_splitter.Panel1.ResumeLayout(false);
            this.obj_splitter.Panel1.PerformLayout();
            this.obj_splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.obj_splitter)).EndInit();
            this.obj_splitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.obj_rot)).EndInit();
            this.physics_tab.ResumeLayout(false);
            this.places_tab.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer main_splitter;
        private System.Windows.Forms.Panel mapViewPanel_c;
        internal System.Windows.Forms.PictureBox mapViewPanel;
        private System.Windows.Forms.ToolStripMenuItem tsmSendBack;
        private System.Windows.Forms.ToolStripMenuItem tsmBringForward;
        private System.Windows.Forms.ToolStripMenuItem tsmSendToBack;
        private System.Windows.Forms.ToolStripMenuItem tsmBringToFront;
        internal System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SplitContainer toolpanel_splitter;
        private System.Windows.Forms.TabControl first_level_tabControl;
        private System.Windows.Forms.TabPage palette_tab;
        private System.Windows.Forms.TabControl tool_tabs;
        private System.Windows.Forms.TabPage objects_tab;
        private System.Windows.Forms.SplitContainer obj_splitter;
        private System.Windows.Forms.Button obj_select_btn;
        internal System.Windows.Forms.NumericUpDown obj_rot;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Panel obj_scenary_objs;
        private System.Windows.Forms.ComboBox obj_scenary_cache_CB;
        private System.Windows.Forms.TabPage physics_tab;
        private System.Windows.Forms.Button phys_delete;
        private System.Windows.Forms.Button phys_add_edge;
        private System.Windows.Forms.Button phys_add_ellipse;
        private System.Windows.Forms.Button phys_add_rect;
        private System.Windows.Forms.TabPage places_tab;
        private System.Windows.Forms.Button places_selector_btn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        internal System.Windows.Forms.ToolStripComboBox combo_mappieces;
        private System.Windows.Forms.ToolStripButton newPieceBtn;
        private System.Windows.Forms.ToolStripButton savePieceBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        internal System.Windows.Forms.ToolStripTextBox txtPieceName;
        private System.Windows.Forms.ToolStripButton deleteBtn;
        private System.Windows.Forms.ToolStripButton duplicateBtn;
        internal System.Windows.Forms.ToolStripLabel lblFilename;
        private System.Windows.Forms.ToolStripTextBox mapTileWidth;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox mapHeight;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.TabPage terrain_tab;
        private System.Windows.Forms.Panel tilesPanel;
        private System.Windows.Forms.ComboBox tilesCB;
    }
}

