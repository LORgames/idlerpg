
using ToolCache.Animation.Form;

namespace ToolCache.Map.Tiles {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TileEditor));
            this.txtTileName = new System.Windows.Forms.TextBox();
            this.cbTileGroup = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbTileNames = new System.Windows.Forms.ToolStripComboBox();
            this.btnNewTile = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteTile = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.lblTileID = new System.Windows.Forms.ToolStripLabel();
            this.lblTileName = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblAnimation = new System.Windows.Forms.Label();
            this.ckbIsWalkable = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDamagePerSecond = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDamageElement = new System.Windows.Forms.ComboBox();
            this.lblDamage = new System.Windows.Forms.Label();
            this.ckbDown = new System.Windows.Forms.CheckBox();
            this.ckbUp = new System.Windows.Forms.CheckBox();
            this.ckbRight = new System.Windows.Forms.CheckBox();
            this.ckbLeft = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ccAnimation = new ToolCache.Animation.Form.AnimationList();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTileName
            // 
            this.txtTileName.Location = new System.Drawing.Point(15, 50);
            this.txtTileName.Name = "txtTileName";
            this.txtTileName.Size = new System.Drawing.Size(169, 20);
            this.txtTileName.TabIndex = 2;
            this.txtTileName.Text = "<Unnamed>";
            // 
            // cbTileGroup
            // 
            this.cbTileGroup.FormattingEnabled = true;
            this.cbTileGroup.Location = new System.Drawing.Point(190, 49);
            this.cbTileGroup.Name = "cbTileGroup";
            this.cbTileGroup.Size = new System.Drawing.Size(169, 21);
            this.cbTileGroup.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbTileNames,
            this.btnNewTile,
            this.btnDeleteTile,
            this.btnSave,
            this.lblTileID});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(371, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbTileNames
            // 
            this.cbTileNames.Name = "cbTileNames";
            this.cbTileNames.Size = new System.Drawing.Size(169, 25);
            this.cbTileNames.SelectedIndexChanged += new System.EventHandler(this.cbTileNames_SelectedIndexChanged);
            // 
            // btnNewTile
            // 
            this.btnNewTile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewTile.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTile.Image")));
            this.btnNewTile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewTile.Name = "btnNewTile";
            this.btnNewTile.Size = new System.Drawing.Size(23, 22);
            this.btnNewTile.Text = "toolStripButton1";
            this.btnNewTile.Click += new System.EventHandler(this.btnNewTile_Click);
            // 
            // btnDeleteTile
            // 
            this.btnDeleteTile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteTile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTile.Image")));
            this.btnDeleteTile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteTile.Name = "btnDeleteTile";
            this.btnDeleteTile.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteTile.Text = "toolStripButton2";
            this.btnDeleteTile.Click += new System.EventHandler(this.btnDeleteTile_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.lblTileName.Location = new System.Drawing.Point(12, 34);
            this.lblTileName.Name = "lblTileName";
            this.lblTileName.Size = new System.Drawing.Size(58, 13);
            this.lblTileName.TabIndex = 5;
            this.lblTileName.Text = "Tile Name:";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(191, 33);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(59, 13);
            this.lblGroup.TabIndex = 6;
            this.lblGroup.Text = "Tile Group:";
            // 
            // lblAnimation
            // 
            this.lblAnimation.AutoSize = true;
            this.lblAnimation.Location = new System.Drawing.Point(15, 249);
            this.lblAnimation.Name = "lblAnimation";
            this.lblAnimation.Size = new System.Drawing.Size(44, 13);
            this.lblAnimation.TabIndex = 7;
            this.lblAnimation.Text = "Display:";
            // 
            // ckbIsWalkable
            // 
            this.ckbIsWalkable.AutoSize = true;
            this.ckbIsWalkable.Checked = true;
            this.ckbIsWalkable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsWalkable.Location = new System.Drawing.Point(4, 7);
            this.ckbIsWalkable.Name = "ckbIsWalkable";
            this.ckbIsWalkable.Size = new System.Drawing.Size(71, 17);
            this.ckbIsWalkable.TabIndex = 8;
            this.ckbIsWalkable.Text = "Walkable";
            this.ckbIsWalkable.UseVisualStyleBackColor = true;
            this.ckbIsWalkable.CheckedChanged += new System.EventHandler(this.ckbIsWalkable_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDamagePerSecond);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbDamageElement);
            this.panel1.Controls.Add(this.lblDamage);
            this.panel1.Location = new System.Drawing.Point(190, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 78);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "DPS:";
            // 
            // txtDamagePerSecond
            // 
            this.txtDamagePerSecond.Location = new System.Drawing.Point(64, 49);
            this.txtDamagePerSecond.Name = "txtDamagePerSecond";
            this.txtDamagePerSecond.Size = new System.Drawing.Size(100, 20);
            this.txtDamagePerSecond.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Element:";
            // 
            // cbDamageElement
            // 
            this.cbDamageElement.FormattingEnabled = true;
            this.cbDamageElement.Location = new System.Drawing.Point(64, 21);
            this.cbDamageElement.Name = "cbDamageElement";
            this.cbDamageElement.Size = new System.Drawing.Size(100, 21);
            this.cbDamageElement.TabIndex = 1;
            // 
            // lblDamage
            // 
            this.lblDamage.AutoSize = true;
            this.lblDamage.Location = new System.Drawing.Point(4, 4);
            this.lblDamage.Name = "lblDamage";
            this.lblDamage.Size = new System.Drawing.Size(55, 13);
            this.lblDamage.TabIndex = 0;
            this.lblDamage.Text = "Damaging";
            // 
            // ckbDown
            // 
            this.ckbDown.AutoSize = true;
            this.ckbDown.Checked = true;
            this.ckbDown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDown.Location = new System.Drawing.Point(84, 53);
            this.ckbDown.Name = "ckbDown";
            this.ckbDown.Size = new System.Drawing.Size(82, 17);
            this.ckbDown.TabIndex = 10;
            this.ckbDown.Text = "Walk Down";
            this.ckbDown.UseVisualStyleBackColor = true;
            // 
            // ckbUp
            // 
            this.ckbUp.AutoSize = true;
            this.ckbUp.Checked = true;
            this.ckbUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbUp.Location = new System.Drawing.Point(5, 53);
            this.ckbUp.Name = "ckbUp";
            this.ckbUp.Size = new System.Drawing.Size(68, 17);
            this.ckbUp.TabIndex = 11;
            this.ckbUp.Text = "Walk Up";
            this.ckbUp.UseVisualStyleBackColor = true;
            // 
            // ckbRight
            // 
            this.ckbRight.AutoSize = true;
            this.ckbRight.Checked = true;
            this.ckbRight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbRight.Location = new System.Drawing.Point(84, 30);
            this.ckbRight.Name = "ckbRight";
            this.ckbRight.Size = new System.Drawing.Size(79, 17);
            this.ckbRight.TabIndex = 12;
            this.ckbRight.Text = "Walk Right";
            this.ckbRight.UseVisualStyleBackColor = true;
            // 
            // ckbLeft
            // 
            this.ckbLeft.AutoSize = true;
            this.ckbLeft.Checked = true;
            this.ckbLeft.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbLeft.Location = new System.Drawing.Point(4, 30);
            this.ckbLeft.Name = "ckbLeft";
            this.ckbLeft.Size = new System.Drawing.Size(72, 17);
            this.ckbLeft.TabIndex = 13;
            this.ckbLeft.Text = "Walk Left";
            this.ckbLeft.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ckbIsWalkable);
            this.panel2.Controls.Add(this.ckbLeft);
            this.panel2.Controls.Add(this.ckbDown);
            this.panel2.Controls.Add(this.ckbRight);
            this.panel2.Controls.Add(this.ckbUp);
            this.panel2.Location = new System.Drawing.Point(15, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 78);
            this.panel2.TabIndex = 14;
            // 
            // ccAnimation
            // 
            this.ccAnimation.AllowDrop = true;
            this.ccAnimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimation.Location = new System.Drawing.Point(15, 268);
            this.ccAnimation.Name = "ccAnimation";
            this.ccAnimation.Size = new System.Drawing.Size(344, 100);
            this.ccAnimation.TabIndex = 1;
            // 
            // TileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 380);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAnimation);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblTileName);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cbTileGroup);
            this.Controls.Add(this.txtTileName);
            this.Controls.Add(this.ccAnimation);
            this.Name = "TileEditor";
            this.Text = "TED: Tile EDitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TileEditor_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnimationList ccAnimation;
        private System.Windows.Forms.TextBox txtTileName;
        private System.Windows.Forms.ComboBox cbTileGroup;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbTileNames;
        private System.Windows.Forms.ToolStripButton btnNewTile;
        private System.Windows.Forms.ToolStripButton btnDeleteTile;
        private System.Windows.Forms.Label lblTileName;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblAnimation;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripLabel lblTileID;
        private System.Windows.Forms.CheckBox ckbIsWalkable;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDamagePerSecond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDamageElement;
        private System.Windows.Forms.Label lblDamage;
        private System.Windows.Forms.CheckBox ckbDown;
        private System.Windows.Forms.CheckBox ckbUp;
        private System.Windows.Forms.CheckBox ckbRight;
        private System.Windows.Forms.CheckBox ckbLeft;
        private System.Windows.Forms.Panel panel2;
    }
}