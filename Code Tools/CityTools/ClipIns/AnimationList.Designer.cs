namespace CityTools.ClipIns {
    partial class AnimationList {
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelControls = new System.Windows.Forms.Panel();
            this.numFramerate = new System.Windows.Forms.NumericUpDown();
            this.lblAnimation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFramerate)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelControls);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.AutoScrollMargin = new System.Drawing.Size(100, 0);
            this.splitContainer1.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragDrop);
            this.splitContainer1.Panel2.DragOver += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragOver);
            this.splitContainer1.Size = new System.Drawing.Size(500, 100);
            this.splitContainer1.SplitterDistance = 55;
            this.splitContainer1.TabIndex = 2;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.numFramerate);
            this.panelControls.Controls.Add(this.lblAnimation);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(53, 98);
            this.panelControls.TabIndex = 2;
            // 
            // numFramerate
            // 
            this.numFramerate.DecimalPlaces = 2;
            this.numFramerate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numFramerate.Location = new System.Drawing.Point(3, 16);
            this.numFramerate.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numFramerate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numFramerate.Name = "numFramerate";
            this.numFramerate.Size = new System.Drawing.Size(44, 20);
            this.numFramerate.TabIndex = 1;
            this.numFramerate.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numFramerate.ValueChanged += new System.EventHandler(this.numFramerate_ValueChanged);
            // 
            // lblAnimation
            // 
            this.lblAnimation.AutoSize = true;
            this.lblAnimation.Location = new System.Drawing.Point(4, 0);
            this.lblAnimation.Name = "lblAnimation";
            this.lblAnimation.Size = new System.Drawing.Size(27, 13);
            this.lblAnimation.TabIndex = 0;
            this.lblAnimation.Text = "FPS";
            // 
            // AnimationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AnimationList";
            this.Size = new System.Drawing.Size(500, 100);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFramerate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.NumericUpDown numFramerate;
        private System.Windows.Forms.Label lblAnimation;

    }
}
