namespace ArenaTest {
    partial class EntityEditor {
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
            this.txtCharacter = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numStr = new System.Windows.Forms.NumericUpDown();
            this.numVit = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numDex = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numDef = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.Label();
            this.txtUnused = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassiveStats = new System.Windows.Forms.RichTextBox();
            this.numLuk = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numAgi = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numStr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAgi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCharacter
            // 
            this.txtCharacter.AutoSize = true;
            this.txtCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharacter.Location = new System.Drawing.Point(4, 4);
            this.txtCharacter.Name = "txtCharacter";
            this.txtCharacter.Size = new System.Drawing.Size(134, 31);
            this.txtCharacter.TabIndex = 0;
            this.txtCharacter.Text = "Character";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(116, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(92, 20);
            this.txtName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Strength:";
            // 
            // numStr
            // 
            this.numStr.Location = new System.Drawing.Point(116, 175);
            this.numStr.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numStr.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStr.Name = "numStr";
            this.numStr.Size = new System.Drawing.Size(92, 20);
            this.numStr.TabIndex = 4;
            this.numStr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStr.ValueChanged += new System.EventHandler(this.Governed_ValueChanged);
            // 
            // numVit
            // 
            this.numVit.Location = new System.Drawing.Point(116, 201);
            this.numVit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numVit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVit.Name = "numVit";
            this.numVit.Size = new System.Drawing.Size(92, 20);
            this.numVit.TabIndex = 6;
            this.numVit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numVit.ValueChanged += new System.EventHandler(this.Governed_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Vitality:";
            // 
            // numDex
            // 
            this.numDex.Location = new System.Drawing.Point(116, 227);
            this.numDex.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDex.Name = "numDex";
            this.numDex.Size = new System.Drawing.Size(92, 20);
            this.numDex.TabIndex = 8;
            this.numDex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDex.ValueChanged += new System.EventHandler(this.Governed_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Dexterity:";
            // 
            // numDef
            // 
            this.numDef.Location = new System.Drawing.Point(116, 360);
            this.numDef.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numDef.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDef.Name = "numDef";
            this.numDef.Size = new System.Drawing.Size(92, 20);
            this.numDef.TabIndex = 12;
            this.numDef.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Defence (Equips):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Governed Stats";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Ungoverned Stats";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Level:";
            // 
            // txtLevel
            // 
            this.txtLevel.AutoSize = true;
            this.txtLevel.Location = new System.Drawing.Point(116, 89);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(65, 13);
            this.txtLevel.TabIndex = 16;
            this.txtLevel.Text = "<Unknown>";
            // 
            // txtUnused
            // 
            this.txtUnused.AutoSize = true;
            this.txtUnused.Location = new System.Drawing.Point(116, 110);
            this.txtUnused.Name = "txtUnused";
            this.txtUnused.Size = new System.Drawing.Size(65, 13);
            this.txtUnused.TabIndex = 18;
            this.txtUnused.Text = "<Unknown>";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Unused Stat Points:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Passive Stats";
            // 
            // txtPassiveStats
            // 
            this.txtPassiveStats.Location = new System.Drawing.Point(10, 414);
            this.txtPassiveStats.Name = "txtPassiveStats";
            this.txtPassiveStats.Size = new System.Drawing.Size(194, 170);
            this.txtPassiveStats.TabIndex = 20;
            this.txtPassiveStats.Text = "";
            // 
            // numLuk
            // 
            this.numLuk.Location = new System.Drawing.Point(116, 277);
            this.numLuk.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numLuk.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLuk.Name = "numLuk";
            this.numLuk.Size = new System.Drawing.Size(92, 20);
            this.numLuk.TabIndex = 24;
            this.numLuk.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLuk.ValueChanged += new System.EventHandler(this.Governed_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 284);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Luck:";
            // 
            // numAgi
            // 
            this.numAgi.Location = new System.Drawing.Point(116, 251);
            this.numAgi.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numAgi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAgi.Name = "numAgi";
            this.numAgi.Size = new System.Drawing.Size(92, 20);
            this.numAgi.TabIndex = 22;
            this.numAgi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAgi.ValueChanged += new System.EventHandler(this.Governed_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 258);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Agility:";
            // 
            // EntityEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.numLuk);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numAgi);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPassiveStats);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUnused);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtLevel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numDef);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numDex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numVit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numStr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCharacter);
            this.Name = "EntityEditor";
            this.Size = new System.Drawing.Size(209, 587);
            this.Load += new System.EventHandler(this.EntityEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numStr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLuk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAgi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtCharacter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numStr;
        private System.Windows.Forms.NumericUpDown numVit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numDex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numDef;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label txtLevel;
        private System.Windows.Forms.Label txtUnused;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtPassiveStats;
        private System.Windows.Forms.NumericUpDown numLuk;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numAgi;
        private System.Windows.Forms.Label label13;
    }
}
