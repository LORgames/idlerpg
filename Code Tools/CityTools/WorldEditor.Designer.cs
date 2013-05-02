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
            this.pbMainPanel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMainPanel
            // 
            this.pbMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMainPanel.Location = new System.Drawing.Point(0, 0);
            this.pbMainPanel.Name = "pbMainPanel";
            this.pbMainPanel.Size = new System.Drawing.Size(705, 555);
            this.pbMainPanel.TabIndex = 1;
            this.pbMainPanel.TabStop = false;
            this.pbMainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMainPanel_Paint);
            this.pbMainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMainPanel_MouseDown);
            this.pbMainPanel.MouseLeave += new System.EventHandler(this.pbMainPanel_MouseLeave);
            this.pbMainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMainPanel_MouseMove);
            this.pbMainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMainPanel_MouseUp);
            this.pbMainPanel.Resize += new System.EventHandler(this.pbMainPanel_Resize);
            // 
            // WorldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 555);
            this.Controls.Add(this.pbMainPanel);
            this.Name = "WorldEditor";
            this.Text = "World Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorldEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMainPanel;
    }
}