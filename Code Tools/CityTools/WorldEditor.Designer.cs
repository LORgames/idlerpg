namespace CityTools {
    partial class WorldEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnMoveMode = new System.Windows.Forms.ToolStripButton();
            this.btnLinkAdd = new System.Windows.Forms.ToolStripButton();
            this.btnLinkBreak = new System.Windows.Forms.ToolStripButton();
            this.pbMainPanel = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnMoveMode,
            this.btnLinkAdd,
            this.btnLinkBreak});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(705, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnMoveMode
            // 
            this.btnMoveMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveMode.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveMode.Image")));
            this.btnMoveMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveMode.Name = "btnMoveMode";
            this.btnMoveMode.Size = new System.Drawing.Size(23, 22);
            this.btnMoveMode.Text = "Move Pieces";
            // 
            // btnLinkAdd
            // 
            this.btnLinkAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkAdd.Image")));
            this.btnLinkAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkAdd.Name = "btnLinkAdd";
            this.btnLinkAdd.Size = new System.Drawing.Size(23, 22);
            this.btnLinkAdd.Text = "Add Portal Links";
            // 
            // btnLinkBreak
            // 
            this.btnLinkBreak.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLinkBreak.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkBreak.Image")));
            this.btnLinkBreak.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkBreak.Name = "btnLinkBreak";
            this.btnLinkBreak.Size = new System.Drawing.Size(23, 22);
            this.btnLinkBreak.Text = "Break Portal Links";
            // 
            // pbMainPanel
            // 
            this.pbMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMainPanel.Location = new System.Drawing.Point(0, 25);
            this.pbMainPanel.Name = "pbMainPanel";
            this.pbMainPanel.Size = new System.Drawing.Size(705, 530);
            this.pbMainPanel.TabIndex = 1;
            this.pbMainPanel.TabStop = false;
            this.pbMainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMainPanel_Paint);
            this.pbMainPanel.Resize += new System.EventHandler(this.pbMainPanel_Resize);
            // 
            // WorldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 555);
            this.Controls.Add(this.pbMainPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "WorldEditor";
            this.Text = "World Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorldEditor_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnMoveMode;
        private System.Windows.Forms.ToolStripButton btnLinkAdd;
        private System.Windows.Forms.PictureBox pbMainPanel;
        private System.Windows.Forms.ToolStripButton btnLinkBreak;
    }
}