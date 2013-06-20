namespace CityTools {
    partial class SaveFileEditor {
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
            this.equipmentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // equipmentPanel
            // 
            this.equipmentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.equipmentPanel.Location = new System.Drawing.Point(428, 12);
            this.equipmentPanel.Name = "equipmentPanel";
            this.equipmentPanel.Size = new System.Drawing.Size(192, 200);
            this.equipmentPanel.TabIndex = 0;
            // 
            // SaveFileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 500);
            this.Controls.Add(this.equipmentPanel);
            this.Name = "SaveFileEditor";
            this.Text = "SaveFileEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel equipmentPanel;
    }
}