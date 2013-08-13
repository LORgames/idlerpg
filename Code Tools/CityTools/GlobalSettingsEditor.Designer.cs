namespace CityTools
{
    partial class GlobalSettingsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtGameName = new System.Windows.Forms.TextBox();
            this.chkEnableTiles = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudTileSize = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkDisableCharacter = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileSize)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGameName
            // 
            this.txtGameName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGameName.Location = new System.Drawing.Point(126, 3);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(334, 20);
            this.txtGameName.TabIndex = 0;
            this.txtGameName.TextChanged += new System.EventHandler(this.Edited);
            // 
            // chkEnableTiles
            // 
            this.chkEnableTiles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkEnableTiles.AutoSize = true;
            this.chkEnableTiles.Checked = true;
            this.chkEnableTiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableTiles.Location = new System.Drawing.Point(126, 29);
            this.chkEnableTiles.Name = "chkEnableTiles";
            this.chkEnableTiles.Size = new System.Drawing.Size(15, 14);
            this.chkEnableTiles.TabIndex = 1;
            this.chkEnableTiles.UseVisualStyleBackColor = true;
            this.chkEnableTiles.CheckedChanged += new System.EventHandler(this.Edited);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Game Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enable Tiles";
            // 
            // nudTileSize
            // 
            this.nudTileSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTileSize.Location = new System.Drawing.Point(126, 49);
            this.nudTileSize.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudTileSize.Name = "nudTileSize";
            this.nudTileSize.Size = new System.Drawing.Size(83, 20);
            this.nudTileSize.TabIndex = 4;
            this.nudTileSize.ValueChanged += new System.EventHandler(this.Edited);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tile Size";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Disable Main Character";
            // 
            // chkDisableCharacter
            // 
            this.chkDisableCharacter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkDisableCharacter.AutoSize = true;
            this.chkDisableCharacter.Checked = true;
            this.chkDisableCharacter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisableCharacter.Location = new System.Drawing.Point(126, 75);
            this.chkDisableCharacter.Name = "chkDisableCharacter";
            this.chkDisableCharacter.Size = new System.Drawing.Size(15, 14);
            this.chkDisableCharacter.TabIndex = 7;
            this.chkDisableCharacter.UseVisualStyleBackColor = true;
            this.chkDisableCharacter.CheckedChanged += new System.EventHandler(this.Edited);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.chkDisableCharacter, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtGameName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudTileSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkEnableTiles, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(463, 92);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // GlobalSettingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 118);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GlobalSettingsEditor";
            this.Text = "Global Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlobalSettings_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudTileSize)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.CheckBox chkEnableTiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudTileSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDisableCharacter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}