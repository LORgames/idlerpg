namespace ToolCache.Animation.Form {
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
            this.lblAnimation = new System.Windows.Forms.Label();
            this.numFramerate = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFramerate)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panelControls);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.DragDrop += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragDrop);
            this.splitContainer1.Panel2.DragEnter += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragEnter);
            this.splitContainer1.Panel2.DragOver += new System.Windows.Forms.DragEventHandler(this.splitContainer1_Panel2_DragOver);
            this.splitContainer1.Panel2.DragLeave += new System.EventHandler(this.splitContainer1_Panel2_DragLeave);
            this.splitContainer1.Size = new System.Drawing.Size(100, 400);
            this.splitContainer1.TabIndex = 2;
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.numFramerate);
            this.panelControls.Controls.Add(this.lblAnimation);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(100, 50);
            this.panelControls.TabIndex = 2;
            // 
            // lblAnimation
            // 
            this.lblAnimation.AutoSize = true;
            this.lblAnimation.Location = new System.Drawing.Point(4, 4);
            this.lblAnimation.Name = "lblAnimation";
            this.lblAnimation.Size = new System.Drawing.Size(54, 13);
            this.lblAnimation.TabIndex = 0;
            this.lblAnimation.Text = "Framerate";
            // 
            // numFramerate
            // 
            this.numFramerate.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numFramerate.Location = new System.Drawing.Point(4, 21);
            this.numFramerate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFramerate.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numFramerate.Name = "numFramerate";
            this.numFramerate.Size = new System.Drawing.Size(93, 20);
            this.numFramerate.TabIndex = 1;
            this.numFramerate.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // AnimationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "AnimationList";
            this.Size = new System.Drawing.Size(100, 400);
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
