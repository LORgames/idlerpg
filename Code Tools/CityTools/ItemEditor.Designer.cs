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
            this.btnDuplicateItem = new System.Windows.Forms.ToolStripButton();
            this.txtSearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.scriptConsumeEffect = new CityTools.Components.ScriptBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.numStackSize = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.tabScripts = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStackSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetarySell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.tabScripts.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(652, 359);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeItemHeirachy
            // 
            this.treeItemHeirachy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeItemHeirachy.Location = new System.Drawing.Point(0, 25);
            this.treeItemHeirachy.Name = "treeItemHeirachy";
            this.treeItemHeirachy.Size = new System.Drawing.Size(280, 334);
            this.treeItemHeirachy.TabIndex = 1;
            this.treeItemHeirachy.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeItemHeirachy_AfterSelect);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddItem,
            this.btnDuplicateItem,
            this.txtSearchBox});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(280, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "Tree Header";
            // 
            // btnAddItem
            // 
            this.btnAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddItem.Image = global::CityTools.Properties.Resources.add;
            this.btnAddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(23, 22);
            this.btnAddItem.Text = "Create a New Item";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDuplicateItem
            // 
            this.btnDuplicateItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDuplicateItem.Image = global::CityTools.Properties.Resources.arrow_divide;
            this.btnDuplicateItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDuplicateItem.Name = "btnDuplicateItem";
            this.btnDuplicateItem.Size = new System.Drawing.Size(23, 22);
            this.btnDuplicateItem.Text = "Duplicate Current Item";
            this.btnDuplicateItem.Click += new System.EventHandler(this.btnDuplicateItem_Click);
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(95, 25);
            // 
            // scriptConsumeEffect
            // 
            this.scriptConsumeEffect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptConsumeEffect.Location = new System.Drawing.Point(3, 3);
            this.scriptConsumeEffect.Name = "scriptConsumeEffect";
            this.scriptConsumeEffect.Script = "";
            this.scriptConsumeEffect.ScriptType = ToolCache.Scripting.Types.ScriptTypes.Item;
            this.scriptConsumeEffect.Size = new System.Drawing.Size(354, 327);
            this.scriptConsumeEffect.TabIndex = 31;
            this.scriptConsumeEffect.TextChanged += new System.EventHandler(this.FormEdited);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(61, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(127, 20);
            this.txtName.TabIndex = 30;
            this.txtName.TextChanged += new System.EventHandler(this.FormEdited);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Description / Tooltip:";
            // 
            // numStackSize
            // 
            this.numStackSize.Location = new System.Drawing.Point(73, 81);
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
            this.numStackSize.Size = new System.Drawing.Size(115, 20);
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
            this.label11.Location = new System.Drawing.Point(6, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Stack Size:";
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(202, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 1);
            this.label9.TabIndex = 19;
            // 
            // numMonetarySell
            // 
            this.numMonetarySell.Location = new System.Drawing.Point(270, 98);
            this.numMonetarySell.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numMonetarySell.Name = "numMonetarySell";
            this.numMonetarySell.Size = new System.Drawing.Size(70, 20);
            this.numMonetarySell.TabIndex = 18;
            this.numMonetarySell.ValueChanged += new System.EventHandler(this.numValue2_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(210, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Sell Price:";
            // 
            // numMonetaryBuy
            // 
            this.numMonetaryBuy.Location = new System.Drawing.Point(270, 72);
            this.numMonetaryBuy.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numMonetaryBuy.Name = "numMonetaryBuy";
            this.numMonetaryBuy.Size = new System.Drawing.Size(70, 20);
            this.numMonetaryBuy.TabIndex = 16;
            this.numMonetaryBuy.ValueChanged += new System.EventHandler(this.numValue2_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Buy Price:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(259, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "OR";
            // 
            // numMonetaryValue
            // 
            this.numMonetaryValue.Location = new System.Drawing.Point(261, 18);
            this.numMonetaryValue.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numMonetaryValue.Name = "numMonetaryValue";
            this.numMonetaryValue.Size = new System.Drawing.Size(70, 20);
            this.numMonetaryValue.TabIndex = 13;
            this.numMonetaryValue.ValueChanged += new System.EventHandler(this.numMonetaryValue_KeyUp);
            // 
            // sepVOR
            // 
            this.sepVOR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sepVOR.Location = new System.Drawing.Point(352, 5);
            this.sepVOR.Name = "sepVOR";
            this.sepVOR.Size = new System.Drawing.Size(2, 125);
            this.sepVOR.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Value:";
            // 
            // cbRarity
            // 
            this.cbRarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRarity.FormattingEnabled = true;
            this.cbRarity.Items.AddRange(new object[] {
            "Common",
            "Uncommon",
            "Superior",
            "Rare",
            "Ultra Rare",
            "Mythical"});
            this.cbRarity.Location = new System.Drawing.Point(73, 107);
            this.cbRarity.Name = "cbRarity";
            this.cbRarity.Size = new System.Drawing.Size(115, 21);
            this.cbRarity.TabIndex = 10;
            this.cbRarity.TextUpdate += new System.EventHandler(this.FormEdited);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rarity:";
            // 
            // sepValue
            // 
            this.sepValue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sepValue.Location = new System.Drawing.Point(194, 5);
            this.sepValue.Name = "sepValue";
            this.sepValue.Size = new System.Drawing.Size(2, 123);
            this.sepValue.TabIndex = 8;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(73, 54);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(115, 21);
            this.cbCategory.TabIndex = 7;
            this.cbCategory.TextUpdate += new System.EventHandler(this.FormEdited);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Category:";
            // 
            // pbItemIcon
            // 
            this.pbItemIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbItemIcon.Location = new System.Drawing.Point(6, 6);
            this.pbItemIcon.Name = "pbItemIcon";
            this.pbItemIcon.Size = new System.Drawing.Size(48, 48);
            this.pbItemIcon.TabIndex = 4;
            this.pbItemIcon.TabStop = false;
            this.pbItemIcon.Click += new System.EventHandler(this.pbItemIcon_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(3, 151);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(351, 176);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.FormEdited);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInfo);
            this.tabControl1.Controls.Add(this.tabScripts);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(368, 359);
            this.tabControl1.TabIndex = 32;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.label6);
            this.tabInfo.Controls.Add(this.pbItemIcon);
            this.tabInfo.Controls.Add(this.txtDescription);
            this.tabInfo.Controls.Add(this.label14);
            this.tabInfo.Controls.Add(this.txtName);
            this.tabInfo.Controls.Add(this.label9);
            this.tabInfo.Controls.Add(this.label3);
            this.tabInfo.Controls.Add(this.numMonetarySell);
            this.tabInfo.Controls.Add(this.cbCategory);
            this.tabInfo.Controls.Add(this.label8);
            this.tabInfo.Controls.Add(this.numStackSize);
            this.tabInfo.Controls.Add(this.numMonetaryBuy);
            this.tabInfo.Controls.Add(this.label4);
            this.tabInfo.Controls.Add(this.label7);
            this.tabInfo.Controls.Add(this.label11);
            this.tabInfo.Controls.Add(this.cbRarity);
            this.tabInfo.Controls.Add(this.numMonetaryValue);
            this.tabInfo.Controls.Add(this.sepVOR);
            this.tabInfo.Controls.Add(this.sepValue);
            this.tabInfo.Controls.Add(this.label5);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(360, 333);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Information";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // tabScripts
            // 
            this.tabScripts.Controls.Add(this.scriptConsumeEffect);
            this.tabScripts.Location = new System.Drawing.Point(4, 22);
            this.tabScripts.Name = "tabScripts";
            this.tabScripts.Padding = new System.Windows.Forms.Padding(3);
            this.tabScripts.Size = new System.Drawing.Size(360, 333);
            this.tabScripts.TabIndex = 1;
            this.tabScripts.Text = "Scripts";
            this.tabScripts.UseVisualStyleBackColor = true;
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 359);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItemEditor";
            this.Text = "Item Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemEditor_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStackSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetarySell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonetaryValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbItemIcon)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.tabInfo.PerformLayout();
            this.tabScripts.ResumeLayout(false);
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
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripTextBox txtSearchBox;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ToolStripButton btnDuplicateItem;
        private Components.ScriptBox scriptConsumeEffect;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabScripts;
    }
}