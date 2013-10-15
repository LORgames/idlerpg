namespace CityTools.Components {
    partial class UILibraryElement {
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
            this.pbExample = new System.Windows.Forms.PictureBox();
            this.lblID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbExample)).BeginInit();
            this.SuspendLayout();
            // 
            // pbExample
            // 
            this.pbExample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbExample.Location = new System.Drawing.Point(0, 0);
            this.pbExample.Name = "pbExample";
            this.pbExample.Size = new System.Drawing.Size(146, 154);
            this.pbExample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbExample.TabIndex = 0;
            this.pbExample.TabStop = false;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(5, 5);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(16, 16);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "0";
            // 
            // UILibraryElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.pbExample);
            this.Name = "UILibraryElement";
            this.Size = new System.Drawing.Size(146, 154);
            ((System.ComponentModel.ISupportInitialize)(this.pbExample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox pbExample;
        internal System.Windows.Forms.Label lblID;

    }
}
