namespace CityTools.Components {
    partial class ObjectCacheControl {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pnlInternal = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pnlInternal
            // 
            this.pnlInternal.AutoScroll = true;
            this.pnlInternal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInternal.Location = new System.Drawing.Point(0, 0);
            this.pnlInternal.Name = "pnlInternal";
            this.pnlInternal.Size = new System.Drawing.Size(209, 170);
            this.pnlInternal.TabIndex = 0;
            // 
            // ObjectCacheControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlInternal);
            this.Name = "ObjectCacheControl";
            this.Size = new System.Drawing.Size(209, 170);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.FlowLayoutPanel pnlInternal;
    }
}
