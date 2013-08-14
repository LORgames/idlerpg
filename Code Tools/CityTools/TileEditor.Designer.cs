
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbDisplay = new System.Windows.Forms.PictureBox();
            this.btnClearCollisions = new System.Windows.Forms.Button();
            this.ckbShowCollisions = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.numMovementCost = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ccAnimation = new CityTools.Components.AnimationList();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMovementCost)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTileName
            // 
            this.txtTileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTileName.Location = new System.Drawing.Point(3, 16);
            this.txtTileName.Name = "txtTileName";
            this.txtTileName.Size = new System.Drawing.Size(169, 20);
            this.txtTileName.TabIndex = 2;
            this.txtTileName.Text = "<Unnamed>";
            this.txtTileName.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // cbTileGroup
            // 
            this.cbTileGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbTileGroup.FormattingEnabled = true;
            this.cbTileGroup.Location = new System.Drawing.Point(178, 16);
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
            this.lblTileName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTileName.AutoSize = true;
            this.lblTileName.Location = new System.Drawing.Point(3, 0);
            this.lblTileName.Name = "lblTileName";
            this.lblTileName.Size = new System.Drawing.Size(58, 13);
            this.lblTileName.TabIndex = 5;
            this.lblTileName.Text = "Tile Name:";
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(178, 0);
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
            this.splitContainer1.Size = new System.Drawing.Size(643, 440);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 11;
            // 
            // treeAllTiles
            // 
            this.treeAllTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeAllTiles.Location = new System.Drawing.Point(0, 25);
            this.treeAllTiles.Name = "treeAllTiles";
            this.treeAllTiles.Size = new System.Drawing.Size(222, 415);
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
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ccAnimation);
            this.splitContainer2.Size = new System.Drawing.Size(417, 440);
            this.splitContainer2.SplitterDistance = 296;
            this.splitContainer2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(356, 158);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // pbDisplay
            // 
            this.pbDisplay.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbDisplay.Location = new System.Drawing.Point(3, 3);
            this.pbDisplay.Name = "pbDisplay";
            this.pbDisplay.Size = new System.Drawing.Size(100, 100);
            this.pbDisplay.TabIndex = 0;
            this.pbDisplay.TabStop = false;
            this.pbDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDisplay_Paint);
            this.pbDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDisplay_MouseDown);
            this.pbDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDisplay_MouseMove);
            this.pbDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDisplay_MouseUp);
            // 
            // btnClearCollisions
            // 
            this.btnClearCollisions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClearCollisions.Location = new System.Drawing.Point(3, 65);
            this.btnClearCollisions.Name = "btnClearCollisions";
            this.btnClearCollisions.Size = new System.Drawing.Size(99, 23);
            this.btnClearCollisions.TabIndex = 12;
            this.btnClearCollisions.Text = "Clear Collisions";
            this.btnClearCollisions.UseVisualStyleBackColor = true;
            this.btnClearCollisions.Click += new System.EventHandler(this.btnRemoveBoxes_Click);
            // 
            // ckbShowCollisions
            // 
            this.ckbShowCollisions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ckbShowCollisions.AutoSize = true;
            this.ckbShowCollisions.Checked = true;
            this.ckbShowCollisions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShowCollisions.Location = new System.Drawing.Point(3, 42);
            this.ckbShowCollisions.Name = "ckbShowCollisions";
            this.ckbShowCollisions.Size = new System.Drawing.Size(99, 17);
            this.ckbShowCollisions.TabIndex = 11;
            this.ckbShowCollisions.Text = "Show Collisions";
            this.ckbShowCollisions.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.numMovementCost, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnClearCollisions, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.ckbShowCollisions, 0, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(109, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(106, 91);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Movement Cost:";
            // 
            // numMovementCost
            // 
            this.numMovementCost.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numMovementCost.DecimalPlaces = 2;
            this.numMovementCost.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numMovementCost.Location = new System.Drawing.Point(3, 16);
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
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.pbDisplay, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(218, 106);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.cbTileGroup, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtTileName, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblGroup, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblTileName, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(350, 40);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // ccAnimation
            // 
            this.ccAnimation.AllowDrop = true;
            this.ccAnimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccAnimation.Location = new System.Drawing.Point(0, 0);
            this.ccAnimation.Name = "ccAnimation";
            this.ccAnimation.Size = new System.Drawing.Size(417, 140);
            this.ccAnimation.TabIndex = 1;
            // 
            // TileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(643, 440);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TileEditor";
            this.Text = "TED: Tile EDitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TileEditor_FormClosing);
            this.Load += new System.EventHandler(this.TileEditor_Load);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMovementCost)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}