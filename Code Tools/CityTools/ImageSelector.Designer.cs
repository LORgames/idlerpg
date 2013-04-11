namespace CityTools {
    partial class ImageSelector {
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
            this.tsImageSelector = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.pnlImages = new System.Windows.Forms.FlowLayoutPanel();
            this.tsImageSelector.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsImageSelector
            // 
            this.tsImageSelector.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtSearch});
            this.tsImageSelector.Location = new System.Drawing.Point(0, 0);
            this.tsImageSelector.Name = "tsImageSelector";
            this.tsImageSelector.Size = new System.Drawing.Size(442, 25);
            this.tsImageSelector.TabIndex = 0;
            this.tsImageSelector.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(122, 22);
            this.toolStripLabel1.Text = "Search (If Applicable):";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 25);
            // 
            // pnlImages
            // 
            this.pnlImages.AutoScroll = true;
            this.pnlImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImages.Location = new System.Drawing.Point(0, 25);
            this.pnlImages.Name = "pnlImages";
            this.pnlImages.Size = new System.Drawing.Size(442, 405);
            this.pnlImages.TabIndex = 1;
            // 
            // ImageSelector
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 430);
            this.Controls.Add(this.pnlImages);
            this.Controls.Add(this.tsImageSelector);
            this.Name = "ImageSelector";
            this.Text = "ImageSelector";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.tsImageSelector_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.tsImageSelector_DragOver);
            this.tsImageSelector.ResumeLayout(false);
            this.tsImageSelector.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsImageSelector;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.FlowLayoutPanel pnlImages;
    }
}