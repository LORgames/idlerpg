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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbVariableLY = new System.Windows.Forms.ComboBox();
            this.cbVariableLX = new System.Windows.Forms.ComboBox();
            this.cbVariableWY = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numTargetFPS = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numPerspectiveSkew = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbVariableWX = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cbDefaultMap = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.pbGIFBackground = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numPlayers = new System.Windows.Forms.NumericUpDown();
            this.numCritters = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.numTurnSize = new System.Windows.Forms.NumericUpDown();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbVariableSoundVolume = new System.Windows.Forms.ComboBox();
            this.cbVariableMusicVolume = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtQuickMatchServer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudTileSize)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetFPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerspectiveSkew)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbGIFBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCritters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTurnSize)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtGameName
            // 
            this.txtGameName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGameName.Location = new System.Drawing.Point(114, 3);
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
            this.chkEnableTiles.Location = new System.Drawing.Point(114, 29);
            this.chkEnableTiles.Name = "chkEnableTiles";
            this.chkEnableTiles.Size = new System.Drawing.Size(15, 14);
            this.chkEnableTiles.TabIndex = 1;
            this.chkEnableTiles.UseVisualStyleBackColor = true;
            this.chkEnableTiles.CheckedChanged += new System.EventHandler(this.Edited);
            // 
            // nudTileSize
            // 
            this.nudTileSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTileSize.Location = new System.Drawing.Point(114, 49);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cbVariableLY, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbVariableLX, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cbVariableWY, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtGameName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.nudTileSize, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkEnableTiles, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.numTargetFPS, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numPerspectiveSkew, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbVariableWX, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.cbDefaultMap, 1, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(293, 259);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // cbVariableLY
            // 
            this.cbVariableLY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableLY.FormattingEnabled = true;
            this.cbVariableLY.Location = new System.Drawing.Point(114, 208);
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
            this.cbVariableLX.Location = new System.Drawing.Point(114, 181);
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
            this.cbVariableWY.Location = new System.Drawing.Point(114, 154);
            this.cbVariableWY.Name = "cbVariableWY";
            this.cbVariableWY.Size = new System.Drawing.Size(176, 21);
            this.cbVariableWY.Sorted = true;
            this.cbVariableWY.TabIndex = 18;
            this.cbVariableWY.SelectedIndexChanged += new System.EventHandler(this.Edited);
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
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Target FPS";
            // 
            // numTargetFPS
            // 
            this.numTargetFPS.Location = new System.Drawing.Point(114, 101);
            this.numTargetFPS.Name = "numTargetFPS";
            this.numTargetFPS.Size = new System.Drawing.Size(83, 20);
            this.numTargetFPS.TabIndex = 10;
            this.numTargetFPS.ValueChanged += new System.EventHandler(this.Edited);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Perspective Skew";
            // 
            // numPerspectiveSkew
            // 
            this.numPerspectiveSkew.DecimalPlaces = 2;
            this.numPerspectiveSkew.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numPerspectiveSkew.Location = new System.Drawing.Point(114, 75);
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
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Pressed World X Var";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Pressed World Y Var";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Pressed Local X Var";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 212);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Pressed Local Y Var";
            // 
            // cbVariableWX
            // 
            this.cbVariableWX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableWX.FormattingEnabled = true;
            this.cbVariableWX.Location = new System.Drawing.Point(114, 127);
            this.cbVariableWX.Name = "cbVariableWX";
            this.cbVariableWX.Size = new System.Drawing.Size(176, 21);
            this.cbVariableWX.Sorted = true;
            this.cbVariableWX.TabIndex = 17;
            this.cbVariableWX.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Default Map";
            // 
            // cbDefaultMap
            // 
            this.cbDefaultMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultMap.FormattingEnabled = true;
            this.cbDefaultMap.Location = new System.Drawing.Point(114, 235);
            this.cbDefaultMap.Name = "cbDefaultMap";
            this.cbDefaultMap.Size = new System.Drawing.Size(176, 21);
            this.cbDefaultMap.Sorted = true;
            this.cbDefaultMap.TabIndex = 22;
            this.cbDefaultMap.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(454, 243);
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
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "GIF Background";
            // 
            // pbGIFBackground
            // 
            this.pbGIFBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbGIFBackground.Location = new System.Drawing.Point(125, 3);
            this.pbGIFBackground.Name = "pbGIFBackground";
            this.pbGIFBackground.Size = new System.Drawing.Size(83, 21);
            this.pbGIFBackground.TabIndex = 24;
            this.pbGIFBackground.TabStop = false;
            this.pbGIFBackground.Click += new System.EventHandler(this.pbGIFBackground_Click);
            this.pbGIFBackground.Paint += new System.Windows.Forms.PaintEventHandler(this.pbGIFBackground_Paint);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Critters Per Player";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Maximum Players";
            // 
            // numPlayers
            // 
            this.numPlayers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numPlayers.Location = new System.Drawing.Point(125, 50);
            this.numPlayers.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numPlayers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPlayers.Name = "numPlayers";
            this.numPlayers.Size = new System.Drawing.Size(83, 20);
            this.numPlayers.TabIndex = 27;
            this.numPlayers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPlayers.ValueChanged += new System.EventHandler(this.Edited);
            // 
            // numCritters
            // 
            this.numCritters.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numCritters.Location = new System.Drawing.Point(125, 76);
            this.numCritters.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numCritters.Name = "numCritters";
            this.numCritters.Size = new System.Drawing.Size(83, 20);
            this.numCritters.TabIndex = 28;
            this.numCritters.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numCritters.ValueChanged += new System.EventHandler(this.Edited);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Turn Length (MIN (ms))";
            // 
            // numTurnSize
            // 
            this.numTurnSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numTurnSize.Location = new System.Drawing.Point(125, 102);
            this.numTurnSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numTurnSize.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTurnSize.Name = "numTurnSize";
            this.numTurnSize.Size = new System.Drawing.Size(83, 20);
            this.numTurnSize.TabIndex = 30;
            this.numTurnSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numTurnSize.ValueChanged += new System.EventHandler(this.Edited);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label17, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.pbGIFBackground, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.numPlayers, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.numCritters, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.numTurnSize, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label16, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.cbVariableSoundVolume, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.cbVariableMusicVolume, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.txtQuickMatchServer, 1, 5);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(312, 13);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 9;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(304, 232);
            this.tableLayoutPanel3.TabIndex = 9;
            // 
            // cbVariableSoundVolume
            // 
            this.cbVariableSoundVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableSoundVolume.FormattingEnabled = true;
            this.cbVariableSoundVolume.Location = new System.Drawing.Point(125, 208);
            this.cbVariableSoundVolume.Name = "cbVariableSoundVolume";
            this.cbVariableSoundVolume.Size = new System.Drawing.Size(176, 21);
            this.cbVariableSoundVolume.Sorted = true;
            this.cbVariableSoundVolume.TabIndex = 18;
            this.cbVariableSoundVolume.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // cbVariableMusicVolume
            // 
            this.cbVariableMusicVolume.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVariableMusicVolume.FormattingEnabled = true;
            this.cbVariableMusicVolume.Location = new System.Drawing.Point(125, 181);
            this.cbVariableMusicVolume.Name = "cbVariableMusicVolume";
            this.cbVariableMusicVolume.Size = new System.Drawing.Size(176, 21);
            this.cbVariableMusicVolume.Sorted = true;
            this.cbVariableMusicVolume.TabIndex = 18;
            this.cbVariableMusicVolume.SelectedIndexChanged += new System.EventHandler(this.Edited);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Music Volume Var";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 212);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "Sound Volume Var";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 131);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Quick Match Server";
            // 
            // txtQuickMatchServer
            // 
            this.txtQuickMatchServer.Location = new System.Drawing.Point(125, 128);
            this.txtQuickMatchServer.Name = "txtQuickMatchServer";
            this.txtQuickMatchServer.Size = new System.Drawing.Size(176, 20);
            this.txtQuickMatchServer.TabIndex = 34;
            this.txtQuickMatchServer.TextChanged += new System.EventHandler(this.Edited);
            // 
            // GlobalSettingsEditor
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(626, 304);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "GlobalSettingsEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Global Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlobalSettingsEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudTileSize)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetFPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerspectiveSkew)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbGIFBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCritters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTurnSize)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGameName;
        private System.Windows.Forms.CheckBox chkEnableTiles;
        private System.Windows.Forms.NumericUpDown nudTileSize;
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
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numPlayers;
        private System.Windows.Forms.NumericUpDown numCritters;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numTurnSize;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbVariableSoundVolume;
        private System.Windows.Forms.ComboBox cbVariableMusicVolume;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtQuickMatchServer;
    }
}