
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.btnNewTile = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteTile = new System.Windows.Forms.ToolStripButton();
            this.lblTileName = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.ccAnimation = new ToolCache.Animation.Form.AnimationList();
            this.lblAnimation = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(190, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(169, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1,
            this.btnNewTile,
            this.btnDeleteTile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(371, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(169, 25);
            // 
            // btnNewTile
            // 
            this.btnNewTile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewTile.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTile.Image")));
            this.btnNewTile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewTile.Name = "btnNewTile";
            this.btnNewTile.Size = new System.Drawing.Size(23, 22);
            this.btnNewTile.Text = "toolStripButton1";
            // 
            // btnDeleteTile
            // 
            this.btnDeleteTile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteTile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTile.Image")));
            this.btnDeleteTile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteTile.Name = "btnDeleteTile";
            this.btnDeleteTile.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteTile.Text = "toolStripButton2";
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
            // ccAnimation
            // 
            this.ccAnimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimation.Location = new System.Drawing.Point(15, 96);
            this.ccAnimation.Name = "ccAnimation";
            this.ccAnimation.Size = new System.Drawing.Size(344, 64);
            this.ccAnimation.TabIndex = 1;
            // 
            // lblAnimation
            // 
            this.lblAnimation.AutoSize = true;
            this.lblAnimation.Location = new System.Drawing.Point(15, 77);
            this.lblAnimation.Name = "lblAnimation";
            this.lblAnimation.Size = new System.Drawing.Size(44, 13);
            this.lblAnimation.TabIndex = 7;
            this.lblAnimation.Text = "Display:";
            // 
            // TileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 172);
            this.Controls.Add(this.lblAnimation);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblTileName);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtTileName);
            this.Controls.Add(this.ccAnimation);
            this.Name = "TileEditor";
            this.Text = "Tile Editor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AnimationList ccAnimation;
        private System.Windows.Forms.TextBox txtTileName;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripButton btnNewTile;
        private System.Windows.Forms.ToolStripButton btnDeleteTile;
        private System.Windows.Forms.Label lblTileName;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblAnimation;
    }
}