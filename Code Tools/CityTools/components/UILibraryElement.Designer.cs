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
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblSize = new System.Windows.Forms.Label();
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
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(27, 131);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(55, 16);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "(Index)";
            // 
            // btnDown
            // 
            this.btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDown.Location = new System.Drawing.Point(3, 128);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(18, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "<";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUp.Location = new System.Drawing.Point(125, 128);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(18, 23);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = ">";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::CityTools.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(118, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 24);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(3, 3);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(33, 13);
            this.lblSize.TabIndex = 5;
            this.lblSize.Text = "(Size)";
            // 
            // UILibraryElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
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
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblSize;

    }
}
