namespace CityTools {
    partial class ItemEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeItemHeirachy = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numEffectValue = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.cbEffectID = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.numStackSize = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numMonetarySell = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numMonetaryBuy = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numMonetaryValue = new System.Windows.Forms.NumericUpDown();
            this.sepVOR = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbRarity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sepValue = new System.Windows.Forms.Label();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbItemIcon = new System.Windows.Forms.PictureBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEffectValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStackSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetarySell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeItemHeirachy);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtName);
            this.splitContainer1.Panel2.Controls.Add(this.numEffectValue);
            this.splitContainer1.Panel2.Controls.Add(this.label15);
            this.splitContainer1.Panel2.Controls.Add(this.cbEffectID);
            this.splitContainer1.Panel2.Controls.Add(this.label14);
            this.splitContainer1.Panel2.Controls.Add(this.label13);
            this.splitContainer1.Panel2.Controls.Add(this.label12);
            this.splitContainer1.Panel2.Controls.Add(this.numStackSize);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.numMonetarySell);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.numMonetaryBuy);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.numMonetaryValue);
            this.splitContainer1.Panel2.Controls.Add(this.sepVOR);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.cbRarity);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.sepValue);
            this.splitContainer1.Panel2.Controls.Add(this.cbCategory);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.pbItemIcon);
            this.splitContainer1.Panel2.Controls.Add(this.txtDescription);
            this.splitContainer1.Size = new System.Drawing.Size(539, 452);
            this.splitContainer1.SplitterDistance = 179;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeItemHeirachy
            // 
            this.treeItemHeirachy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeItemHeirachy.Location = new System.Drawing.Point(0, 25);
            this.treeItemHeirachy.Name = "treeItemHeirachy";
            this.treeItemHeirachy.Size = new System.Drawing.Size(179, 427);
            this.treeItemHeirachy.TabIndex = 1;
            this.treeItemHeirachy.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeItemHeirachy_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddItem,
            this.toolStripLabel1,
            this.txtSearchBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(179, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "Tree Header";
            // 
            // btnAddItem
            // 
            this.btnAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(23, 22);
            this.btnAddItem.Text = "Create a New Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "Find:";
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(95, 23);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(35, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 20);
            this.txtName.TabIndex = 30;
            this.txtName.TextChanged += new System.EventHandler(this.FormEdited);
            // 
            // numEffectValue
            // 
            this.numEffectValue.Location = new System.Drawing.Point(13, 242);
            this.numEffectValue.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numEffectValue.Name = "numEffectValue";
            this.numEffectValue.Size = new System.Drawing.Size(151, 20);
            this.numEffectValue.TabIndex = 29;
            this.numEffectValue.ValueChanged += new System.EventHandler(this.FormEdited);
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(7, 188);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(158, 2);
            this.label15.TabIndex = 28;
            // 
            // cbEffectID
            // 
            this.cbEffectID.FormattingEnabled = true;
            this.cbEffectID.Location = new System.Drawing.Point(13, 215);
            this.cbEffectID.Name = "cbEffectID";
            this.cbEffectID.Size = new System.Drawing.Size(151, 21);
            this.cbEffectID.TabIndex = 27;
            this.cbEffectID.Text = "No Effect";
            this.cbEffectID.TextUpdate += new System.EventHandler(this.FormEdited);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 292);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Description:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 198);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Use Effect (Not Implemented?):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 196);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 26);
            this.label12.TabIndex = 24;
            this.label12.Text = "Item Tags Here!\r\n(Just Not Yet!)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numStackSize
            // 
            this.numStackSize.Location = new System.Drawing.Point(13, 157);
            this.numStackSize.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numStackSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStackSize.Name = "numStackSize";
            this.numStackSize.Size = new System.Drawing.Size(151, 20);
            this.numStackSize.TabIndex = 22;
            this.numStackSize.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStackSize.ValueChanged += new System.EventHandler(this.FormEdited);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 141);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Amount Per Stack:";
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(170, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(2, 143);
            this.label10.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(7, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(337, 2);
            this.label9.TabIndex = 19;
            // 
            // numMonetarySell
            // 
            this.numMonetarySell.Location = new System.Drawing.Point(261, 110);
            this.numMonetarySell.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numMonetarySell.Name = "numMonetarySell";
            this.numMonetarySell.Size = new System.Drawing.Size(70, 20);
            this.numMonetarySell.TabIndex = 18;
            this.numMonetarySell.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numValue2_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(201, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Sell Price:";
            // 
            // numMonetaryBuy
            // 
            this.numMonetaryBuy.Location = new System.Drawing.Point(261, 84);
            this.numMonetaryBuy.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numMonetaryBuy.Name = "numMonetaryBuy";
            this.numMonetaryBuy.Size = new System.Drawing.Size(70, 20);
            this.numMonetaryBuy.TabIndex = 16;
            this.numMonetaryBuy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numValue2_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(200, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Buy Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "OR";
            // 
            // numMonetaryValue
            // 
            this.numMonetaryValue.Location = new System.Drawing.Point(66, 96);
            this.numMonetaryValue.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numMonetaryValue.Name = "numMonetaryValue";
            this.numMonetaryValue.Size = new System.Drawing.Size(70, 20);
            this.numMonetaryValue.TabIndex = 13;
            this.numMonetaryValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numMonetaryValue_KeyUp);
            // 
            // sepVOR
            // 
            this.sepVOR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sepVOR.Location = new System.Drawing.Point(170, 82);
            this.sepVOR.Name = "sepVOR";
            this.sepVOR.Size = new System.Drawing.Size(2, 50);
            this.sepVOR.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Value:";
            // 
            // cbRarity
            // 
            this.cbRarity.FormattingEnabled = true;
            this.cbRarity.Items.AddRange(new object[] {
            "Common",
            "Uncommon",
            "Superior",
            "Rare",
            "Ultra Rare",
            "Mythical"});
            this.cbRarity.Location = new System.Drawing.Point(238, 45);
            this.cbRarity.Name = "cbRarity";
            this.cbRarity.Size = new System.Drawing.Size(93, 21);
            this.cbRarity.TabIndex = 10;
            this.cbRarity.TextUpdate += new System.EventHandler(this.FormEdited);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rarity:";
            // 
            // sepValue
            // 
            this.sepValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sepValue.Location = new System.Drawing.Point(10, 79);
            this.sepValue.Name = "sepValue";
            this.sepValue.Size = new System.Drawing.Size(337, 2);
            this.sepValue.TabIndex = 8;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(66, 45);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(93, 21);
            this.cbCategory.TabIndex = 7;
            this.cbCategory.TextUpdate += new System.EventHandler(this.FormEdited);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Category:";
            // 
            // pbItemIcon
            // 
            this.pbItemIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbItemIcon.Location = new System.Drawing.Point(13, 9);
            this.pbItemIcon.Name = "pbItemIcon";
            this.pbItemIcon.Size = new System.Drawing.Size(16, 16);
            this.pbItemIcon.TabIndex = 4;
            this.pbItemIcon.TabStop = false;
            this.pbItemIcon.Click += new System.EventHandler(this.pbItemIcon_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(10, 311);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(334, 129);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.FormEdited);
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 452);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ItemEditor";
            this.Text = "Item Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemEditor_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEffectValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStackSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetarySell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddItem;
        private System.Windows.Forms.TreeView treeItemHeirachy;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.PictureBox pbItemIcon;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbRarity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label sepValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numMonetarySell;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numMonetaryBuy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numMonetaryValue;
        private System.Windows.Forms.Label sepVOR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numStackSize;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numEffectValue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbEffectID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtSearchBox;
        private System.Windows.Forms.TextBox txtName;
    }
}