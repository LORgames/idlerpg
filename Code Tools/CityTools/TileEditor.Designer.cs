
using CityTools.Components;

namespace CityTools {
    partial class TileEditor {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileEditor));
            this.txtTileName = new System.Windows.Forms.TextBox();
            this.cbTileGroup = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewTile = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteTile = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnMerge = new System.Windows.Forms.ToolStripButton();
            this.lblTileID = new System.Windows.Forms.ToolStripLabel();
            this.lblTileName = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeAllTiles = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnClearCollisions = new System.Windows.Forms.Button();
            this.ckbShowCollisions = new System.Windows.Forms.CheckBox();
            this.pbDisplay = new System.Windows.Forms.PictureBox();
            this.ccAnimation = new CityTools.Components.AnimationList();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.numMovementCost = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovementCost)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTileName
            // 
            this.txtTileName.Location = new System.Drawing.Point(6, 22);
            this.txtTileName.Name = "txtTileName";
            this.txtTileName.Size = new System.Drawing.Size(169, 20);
            this.txtTileName.TabIndex = 2;
            this.txtTileName.Text = "<Unnamed>";
            this.txtTileName.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // cbTileGroup
            // 
            this.cbTileGroup.FormattingEnabled = true;
            this.cbTileGroup.Location = new System.Drawing.Point(217, 21);
            this.cbTileGroup.Name = "cbTileGroup";
            this.cbTileGroup.Size = new System.Drawing.Size(169, 21);
            this.cbTileGroup.TabIndex = 3;
            this.cbTileGroup.SelectedIndexChanged += new System.EventHandler(this.ValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewTile,
            this.btnDeleteTile,
            this.btnSave,
            this.btnMerge,
            this.lblTileID});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(222, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewTile
            // 
            this.btnNewTile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewTile.Image = global::CityTools.Properties.Resources.add;
            this.btnNewTile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewTile.Name = "btnNewTile";
            this.btnNewTile.Size = new System.Drawing.Size(23, 22);
            this.btnNewTile.Text = "toolStripButton1";
            this.btnNewTile.Click += new System.EventHandler(this.btnNewTile_Click);
            // 
            // btnDeleteTile
            // 
            this.btnDeleteTile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteTile.Image = global::CityTools.Properties.Resources.delete;
            this.btnDeleteTile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteTile.Name = "btnDeleteTile";
            this.btnDeleteTile.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteTile.Text = "toolStripButton2";
            this.btnDeleteTile.Click += new System.EventHandler(this.btnDeleteTile_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::CityTools.Properties.Resources.disk;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMerge
            // 
            this.btnMerge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMerge.Image = global::CityTools.Properties.Resources.arrow_merge;
            this.btnMerge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(23, 22);
            this.btnMerge.Text = "Merge";
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // lblTileID
            // 
            this.lblTileID.Name = "lblTileID";
            this.lblTileID.Size = new System.Drawing.Size(41, 22);
            this.lblTileID.Text = "<TID>";
            // 
            // lblTileName
            // 
            this.lblTileName.AutoSize = true;
            this.lblTileName.Location = new System.Drawing.Point(3, 5);
            this.lblTileName.Name = "lblTileName";
            this.lblTileName.Size = new System.Drawing.Size(58, 13);
            this.lblTileName.TabIndex = 5;
            this.lblTileName.Text = "Tile Name:";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(214, 5);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(59, 13);
            this.lblGroup.TabIndex = 6;
            this.lblGroup.Text = "Tile Group:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeAllTiles);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(619, 380);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 11;
            // 
            // treeAllTiles
            // 
            this.treeAllTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAllTiles.Location = new System.Drawing.Point(0, 25);
            this.treeAllTiles.Name = "treeAllTiles";
            this.treeAllTiles.Size = new System.Drawing.Size(222, 355);
            this.treeAllTiles.TabIndex = 5;
            this.treeAllTiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeAllTiles_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.numMovementCost);
            this.splitContainer2.Panel1.Controls.Add(this.btnClearCollisions);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.ckbShowCollisions);
            this.splitContainer2.Panel1.Controls.Add(this.pbDisplay);
            this.splitContainer2.Panel1.Controls.Add(this.lblTileName);
            this.splitContainer2.Panel1.Controls.Add(this.cbTileGroup);
            this.splitContainer2.Panel1.Controls.Add(this.lblGroup);
            this.splitContainer2.Panel1.Controls.Add(this.txtTileName);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ccAnimation);
            this.splitContainer2.Size = new System.Drawing.Size(393, 380);
            this.splitContainer2.SplitterDistance = 236;
            this.splitContainer2.TabIndex = 11;
            // 
            // btnClearCollisions
            // 
            this.btnClearCollisions.Location = new System.Drawing.Point(112, 71);
            this.btnClearCollisions.Name = "btnClearCollisions";
            this.btnClearCollisions.Size = new System.Drawing.Size(99, 23);
            this.btnClearCollisions.TabIndex = 12;
            this.btnClearCollisions.Text = "Clear Collisions";
            this.btnClearCollisions.UseVisualStyleBackColor = true;
            this.btnClearCollisions.Click += new System.EventHandler(this.btnRemoveBoxes_Click);
            // 
            // ckbShowCollisions
            // 
            this.ckbShowCollisions.AutoSize = true;
            this.ckbShowCollisions.Checked = true;
            this.ckbShowCollisions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShowCollisions.Location = new System.Drawing.Point(112, 48);
            this.ckbShowCollisions.Name = "ckbShowCollisions";
            this.ckbShowCollisions.Size = new System.Drawing.Size(99, 17);
            this.ckbShowCollisions.TabIndex = 11;
            this.ckbShowCollisions.Text = "Show Collisions";
            this.ckbShowCollisions.UseVisualStyleBackColor = true;
            // 
            // pbDisplay
            // 
            this.pbDisplay.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbDisplay.Location = new System.Drawing.Point(6, 48);
            this.pbDisplay.Name = "pbDisplay";
            this.pbDisplay.Size = new System.Drawing.Size(100, 100);
            this.pbDisplay.TabIndex = 0;
            this.pbDisplay.TabStop = false;
            this.pbDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDisplay_Paint);
            this.pbDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDisplay_MouseDown);
            this.pbDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDisplay_MouseMove);
            this.pbDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDisplay_MouseUp);
            // 
            // ccAnimation
            // 
            this.ccAnimation.AllowDrop = true;
            this.ccAnimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccAnimation.Location = new System.Drawing.Point(0, 0);
            this.ccAnimation.Name = "ccAnimation";
            this.ccAnimation.Size = new System.Drawing.Size(393, 140);
            this.ccAnimation.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Movement Cost:";
            // 
            // numMovementCost
            // 
            this.numMovementCost.DecimalPlaces = 2;
            this.numMovementCost.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numMovementCost.Location = new System.Drawing.Point(240, 68);
            this.numMovementCost.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            131072});
            this.numMovementCost.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numMovementCost.Name = "numMovementCost";
            this.numMovementCost.Size = new System.Drawing.Size(100, 20);
            this.numMovementCost.TabIndex = 6;
            this.numMovementCost.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMovementCost.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // TileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 380);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TileEditor";
            this.Text = "TED: Tile EDitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TileEditor_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMovementCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AnimationList ccAnimation;
        private System.Windows.Forms.TextBox txtTileName;
        private System.Windows.Forms.ComboBox cbTileGroup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewTile;
        private System.Windows.Forms.ToolStripButton btnDeleteTile;
        private System.Windows.Forms.Label lblTileName;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripLabel lblTileID;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pbDisplay;
        private System.Windows.Forms.TreeView treeAllTiles;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox ckbShowCollisions;
        private System.Windows.Forms.Button btnClearCollisions;
        private System.Windows.Forms.ToolStripButton btnMerge;
        private System.Windows.Forms.NumericUpDown numMovementCost;
        private System.Windows.Forms.Label label4;
    }
}