namespace CityTools.Components {
    partial class TileMergeDialog {
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
            this.listLayers = new System.Windows.Forms.ListBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTileName = new System.Windows.Forms.ComboBox();
            this.cbTileGroup = new System.Windows.Forms.ComboBox();
            this.btnAddLayer = new System.Windows.Forms.Button();
            this.pbDisplay = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // listLayers
            // 
            this.listLayers.FormattingEnabled = true;
            this.listLayers.Location = new System.Drawing.Point(3, 3);
            this.listLayers.Name = "listLayers";
            this.listLayers.Size = new System.Drawing.Size(146, 82);
            this.listLayers.TabIndex = 1;
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(66, 40);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(178, 20);
            this.btnMerge.TabIndex = 2;
            this.btnMerge.Text = "K Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbTileName);
            this.panel1.Controls.Add(this.cbTileGroup);
            this.panel1.Controls.Add(this.listLayers);
            this.panel1.Controls.Add(this.btnAddLayer);
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 92);
            this.panel1.TabIndex = 3;
            // 
            // cbTileName
            // 
            this.cbTileName.FormattingEnabled = true;
            this.cbTileName.Location = new System.Drawing.Point(155, 62);
            this.cbTileName.Name = "cbTileName";
            this.cbTileName.Size = new System.Drawing.Size(165, 21);
            this.cbTileName.TabIndex = 6;
            this.cbTileName.SelectedIndexChanged += new System.EventHandler(this.cbTileName_SelectedIndexChanged);
            // 
            // cbTileGroup
            // 
            this.cbTileGroup.FormattingEnabled = true;
            this.cbTileGroup.Location = new System.Drawing.Point(155, 35);
            this.cbTileGroup.Name = "cbTileGroup";
            this.cbTileGroup.Size = new System.Drawing.Size(165, 21);
            this.cbTileGroup.TabIndex = 5;
            this.cbTileGroup.SelectedIndexChanged += new System.EventHandler(this.cbTileGroup_SelectedIndexChanged);
            // 
            // btnAddLayer
            // 
            this.btnAddLayer.Location = new System.Drawing.Point(155, 6);
            this.btnAddLayer.Name = "btnAddLayer";
            this.btnAddLayer.Size = new System.Drawing.Size(165, 23);
            this.btnAddLayer.TabIndex = 4;
            this.btnAddLayer.Text = "Add Layer";
            this.btnAddLayer.UseVisualStyleBackColor = true;
            this.btnAddLayer.Click += new System.EventHandler(this.btnAddLayer_Click);
            // 
            // pbDisplay
            // 
            this.pbDisplay.Location = new System.Drawing.Point(12, 12);
            this.pbDisplay.Name = "pbDisplay";
            this.pbDisplay.Size = new System.Drawing.Size(48, 48);
            this.pbDisplay.TabIndex = 0;
            this.pbDisplay.TabStop = false;
            this.pbDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDisplay_Paint);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(66, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(178, 20);
            this.txtName.TabIndex = 4;
            // 
            // TileMergeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 165);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMerge);
            this.Controls.Add(this.pbDisplay);
            this.Name = "TileMergeDialog";
            this.Text = "TileMergeDialog";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDisplay;
        private System.Windows.Forms.ListBox listLayers;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTileName;
        private System.Windows.Forms.ComboBox cbTileGroup;
        private System.Windows.Forms.Button btnAddLayer;
        private System.Windows.Forms.TextBox txtName;
    }
}