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
            this.pbMainPanel = new System.Windows.Forms.PictureBox();
            this.btnCreateNewMap = new System.Windows.Forms.Button();
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
            this.pbMainPanel.DoubleClick += new System.EventHandler(this.pbMainPanel_DoubleClick);
            this.pbMainPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMainPanel_MouseDown);
            this.pbMainPanel.MouseLeave += new System.EventHandler(this.pbMainPanel_MouseLeave);
            this.pbMainPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbMainPanel_MouseMove);
            this.pbMainPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMainPanel_MouseUp);
            this.pbMainPanel.Resize += new System.EventHandler(this.pbMainPanel_Resize);
            // 
            // btnCreateNewMap
            // 
            this.btnCreateNewMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateNewMap.Location = new System.Drawing.Point(609, 532);
            this.btnCreateNewMap.Name = "btnCreateNewMap";
            this.btnCreateNewMap.Size = new System.Drawing.Size(96, 23);
            this.btnCreateNewMap.TabIndex = 2;
            this.btnCreateNewMap.Text = "Create New Map";
            this.btnCreateNewMap.UseVisualStyleBackColor = true;
            this.btnCreateNewMap.Click += new System.EventHandler(this.btnCreateNewMap_Click);
            // 
            // WorldEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 555);
            this.Controls.Add(this.btnCreateNewMap);
            this.Controls.Add(this.pbMainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorldEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "World Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorldEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbMainPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMainPanel;
        private System.Windows.Forms.Button btnCreateNewMap;
    }
}