namespace ToolCache.Animation.Form {
    partial class AnimationFrame {
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
            this.pbThisFrame = new System.Windows.Forms.PictureBox();
            this.btnDeleteFrame = new System.Windows.Forms.Button();
            this.btnShiftFrameLeft = new System.Windows.Forms.Button();
            this.btnShiftFrameRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbThisFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // pbThisFrame
            // 
            this.pbThisFrame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbThisFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbThisFrame.Location = new System.Drawing.Point(0, 0);
            this.pbThisFrame.Name = "pbThisFrame";
            this.pbThisFrame.Size = new System.Drawing.Size(78, 78);
            this.pbThisFrame.TabIndex = 0;
            this.pbThisFrame.TabStop = false;
            // 
            // btnDeleteFrame
            // 
            this.btnDeleteFrame.Image = global::ToolCache.Properties.Resources.delete;
            this.btnDeleteFrame.Location = new System.Drawing.Point(52, 0);
            this.btnDeleteFrame.Name = "btnDeleteFrame";
            this.btnDeleteFrame.Size = new System.Drawing.Size(26, 23);
            this.btnDeleteFrame.TabIndex = 1;
            this.btnDeleteFrame.UseVisualStyleBackColor = true;
            this.btnDeleteFrame.Click += new System.EventHandler(this.btnDeleteFrame_Click);
            // 
            // btnShiftFrameLeft
            // 
            this.btnShiftFrameLeft.Location = new System.Drawing.Point(4, 52);
            this.btnShiftFrameLeft.Name = "btnShiftFrameLeft";
            this.btnShiftFrameLeft.Size = new System.Drawing.Size(17, 23);
            this.btnShiftFrameLeft.TabIndex = 2;
            this.btnShiftFrameLeft.Text = "<";
            this.btnShiftFrameLeft.UseVisualStyleBackColor = true;
            this.btnShiftFrameLeft.Click += new System.EventHandler(this.btnShiftFrameLeft_Click);
            // 
            // btnShiftFrameRight
            // 
            this.btnShiftFrameRight.Location = new System.Drawing.Point(58, 52);
            this.btnShiftFrameRight.Name = "btnShiftFrameRight";
            this.btnShiftFrameRight.Size = new System.Drawing.Size(17, 23);
            this.btnShiftFrameRight.TabIndex = 3;
            this.btnShiftFrameRight.Text = ">";
            this.btnShiftFrameRight.UseVisualStyleBackColor = true;
            this.btnShiftFrameRight.Click += new System.EventHandler(this.btnShiftFrameRight_Click);
            // 
            // AnimationFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnShiftFrameRight);
            this.Controls.Add(this.btnShiftFrameLeft);
            this.Controls.Add(this.btnDeleteFrame);
            this.Controls.Add(this.pbThisFrame);
            this.Name = "AnimationFrame";
            this.Size = new System.Drawing.Size(78, 78);
            ((System.ComponentModel.ISupportInitialize)(this.pbThisFrame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbThisFrame;
        private System.Windows.Forms.Button btnDeleteFrame;
        private System.Windows.Forms.Button btnShiftFrameLeft;
        private System.Windows.Forms.Button btnShiftFrameRight;
    }
}
