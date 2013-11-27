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
            this.nudTileSize = new System.Windows.Forms.NumericUpDown();
            this.chkDisableCharacter = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbVariableLY = new System.Windows.Forms.ComboBox();
            this.cbVariableLX = new System.Windows.Forms.ComboBox();
            this.cbVariableWY = new System.Windows.Forms.ComboBox();
            this.numTargetFPS = new System.Windows.Forms.NumericUpDown();
            this.numPerspectiveSkew = new System.Windows.Forms.NumericUpDown();
            this.cbVariableWX = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbDefaultMap = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pbGIFBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileSize)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerspectiveSkew)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGIFBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // txtGameName
            // 
            this.txtGameName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGameName.Location = new System.Drawing.Point(126, 3);
            this.txtGameName.Name = "txtGameName";
            this.txtGameName.Size = new System.Drawing.Size(176, 20);
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
            this.tableLayoutPanel1.Controls.Add(this.cbVariableLY, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbVariableLX, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbVariableWY, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.chkDisableCharacter, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtGameName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudTileSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkEnableTiles, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numTargetFPS, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.numPerspectiveSkew, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbVariableWX, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.cbDefaultMap, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.pbGIFBackground, 1, 12);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 361);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // cbVariableLY
            // 
            this.cbVariableLY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableLY.FormattingEnabled = true;
            this.cbVariableLY.Location = new System.Drawing.Point(126, 228);
            this.cbVariableLY.Name = "cbVariableLY";
            this.cbVariableLY.Size = new System.Drawing.Size(176, 21);
            this.cbVariableLY.Sorted = true;
            this.cbVariableLY.TabIndex = 20;
            this.cbVariableLY.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // cbVariableLX
            // 
            this.cbVariableLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableLX.FormattingEnabled = true;
            this.cbVariableLX.Location = new System.Drawing.Point(126, 201);
            this.cbVariableLX.Name = "cbVariableLX";
            this.cbVariableLX.Size = new System.Drawing.Size(176, 21);
            this.cbVariableLX.Sorted = true;
            this.cbVariableLX.TabIndex = 19;
            this.cbVariableLX.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // cbVariableWY
            // 
            this.cbVariableWY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableWY.FormattingEnabled = true;
            this.cbVariableWY.Location = new System.Drawing.Point(126, 174);
            this.cbVariableWY.Name = "cbVariableWY";
            this.cbVariableWY.Size = new System.Drawing.Size(176, 21);
            this.cbVariableWY.Sorted = true;
            this.cbVariableWY.TabIndex = 18;
            this.cbVariableWY.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // numTargetFPS
            // 
            this.numTargetFPS.Location = new System.Drawing.Point(126, 121);
            this.numTargetFPS.Name = "numTargetFPS";
            this.numTargetFPS.Size = new System.Drawing.Size(83, 20);
            this.numTargetFPS.TabIndex = 10;
            this.numTargetFPS.ValueChanged += new System.EventHandler(this.Edited);
            // 
            // numPerspectiveSkew
            // 
            this.numPerspectiveSkew.DecimalPlaces = 2;
            this.numPerspectiveSkew.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPerspectiveSkew.Location = new System.Drawing.Point(126, 95);
            this.numPerspectiveSkew.Name = "numPerspectiveSkew";
            this.numPerspectiveSkew.Size = new System.Drawing.Size(83, 20);
            this.numPerspectiveSkew.TabIndex = 12;
            this.numPerspectiveSkew.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPerspectiveSkew.ValueChanged += new System.EventHandler(this.Edited);
            // 
            // cbVariableWX
            // 
            this.cbVariableWX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableWX.FormattingEnabled = true;
            this.cbVariableWX.Location = new System.Drawing.Point(126, 147);
            this.cbVariableWX.Name = "cbVariableWX";
            this.cbVariableWX.Size = new System.Drawing.Size(176, 21);
            this.cbVariableWX.Sorted = true;
            this.cbVariableWX.TabIndex = 17;
            this.cbVariableWX.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(140, 329);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 29);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cbDefaultMap
            // 
            this.cbDefaultMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultMap.FormattingEnabled = true;
            this.cbDefaultMap.Location = new System.Drawing.Point(126, 255);
            this.cbDefaultMap.Name = "cbDefaultMap";
            this.cbDefaultMap.Size = new System.Drawing.Size(176, 21);
            this.cbDefaultMap.Sorted = true;
            this.cbDefaultMap.TabIndex = 22;
            this.cbDefaultMap.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Default Map";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Pressed Local Y Var";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Pressed Local X Var";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Pressed World Y Var";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Pressed World X Var";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Perspective Skew";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Target FPS";
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
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 306);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "GIF Background";
            // 
            // pbGIFBackground
            // 
            this.pbGIFBackground.Location = new System.Drawing.Point(126, 302);
            this.pbGIFBackground.Name = "pbGIFBackground";
            this.pbGIFBackground.Size = new System.Drawing.Size(176, 21);
            this.pbGIFBackground.TabIndex = 24;
            this.pbGIFBackground.TabStop = false;
            // 
            // GlobalSettingsEditor
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(326, 456);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GlobalSettingsEditor";
            this.Text = "Global Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlobalSettingsEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudTileSize)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerspectiveSkew)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGIFBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.CheckBox chkEnableTiles;
        private System.Windows.Forms.NumericUpDown nudTileSize;
        private System.Windows.Forms.CheckBox chkDisableCharacter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numTargetFPS;
        private System.Windows.Forms.NumericUpDown numPerspectiveSkew;
        private System.Windows.Forms.ComboBox cbVariableLY;
        private System.Windows.Forms.ComboBox cbVariableLX;
        private System.Windows.Forms.ComboBox cbVariableWY;
        private System.Windows.Forms.ComboBox cbVariableWX;
        private System.Windows.Forms.ComboBox cbDefaultMap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pbGIFBackground;
    }
}