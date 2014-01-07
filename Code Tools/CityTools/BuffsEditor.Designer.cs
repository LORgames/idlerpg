namespace CityTools {
    partial class BuffsEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuffsEditor));
            this.listBuffs = new System.Windows.Forms.ListBox();
            this.toolsMainTools = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnDuplicate = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ckbShowIcon = new System.Windows.Forms.CheckBox();
            this.ckbIsDebuff = new System.Windows.Forms.CheckBox();
            this.btnOpenLibrary = new System.Windows.Forms.Button();
            this.numIconID = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pbIconDisplay = new System.Windows.Forms.PictureBox();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scriptBox1 = new CityTools.Components.ScriptBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolsMainTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numIconID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // listBuffs
            // 
            this.listBuffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBuffs.FormattingEnabled = true;
            this.listBuffs.Location = new System.Drawing.Point(0, 25);
            this.listBuffs.Name = "listBuffs";
            this.listBuffs.Size = new System.Drawing.Size(290, 461);
            this.listBuffs.Sorted = true;
            this.listBuffs.TabIndex = 0;
            this.listBuffs.SelectedIndexChanged += new System.EventHandler(this.listBuffs_SelectedIndexChanged);
            // 
            // toolsMainTools
            // 
            this.toolsMainTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnDelete,
            this.btnDuplicate});
            this.toolsMainTools.Location = new System.Drawing.Point(0, 0);
            this.toolsMainTools.Name = "toolsMainTools";
            this.toolsMainTools.Size = new System.Drawing.Size(290, 25);
            this.toolsMainTools.TabIndex = 1;
            this.toolsMainTools.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::CityTools.Properties.Resources.add;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(23, 22);
            this.btnAdd.Text = "Create a new buff";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::CityTools.Properties.Resources.delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "Delete the selected buffs";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDuplicate.Image = ((System.Drawing.Image)(resources.GetObject("btnDuplicate.Image")));
            this.btnDuplicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(23, 22);
            this.btnDuplicate.Text = "Duplicate the selected buff";
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBuffs);
            this.splitContainer1.Panel1.Controls.Add(this.toolsMainTools);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(871, 486);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ckbShowIcon);
            this.splitContainer2.Panel1.Controls.Add(this.ckbIsDebuff);
            this.splitContainer2.Panel1.Controls.Add(this.btnOpenLibrary);
            this.splitContainer2.Panel1.Controls.Add(this.numIconID);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.pbIconDisplay);
            this.splitContainer2.Panel1.Controls.Add(this.numDuration);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.txtName);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.scriptBox1);
            this.splitContainer2.Size = new System.Drawing.Size(577, 486);
            this.splitContainer2.SplitterDistance = 103;
            this.splitContainer2.TabIndex = 0;
            // 
            // ckbShowIcon
            // 
            this.ckbShowIcon.AutoSize = true;
            this.ckbShowIcon.Checked = true;
            this.ckbShowIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShowIcon.Location = new System.Drawing.Point(385, 35);
            this.ckbShowIcon.Name = "ckbShowIcon";
            this.ckbShowIcon.Size = new System.Drawing.Size(138, 17);
            this.ckbShowIcon.TabIndex = 9;
            this.ckbShowIcon.Text = "Show Icon Over Critters";
            this.ckbShowIcon.UseVisualStyleBackColor = true;
            this.ckbShowIcon.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // ckbIsDebuff
            // 
            this.ckbIsDebuff.AutoSize = true;
            this.ckbIsDebuff.Location = new System.Drawing.Point(289, 35);
            this.ckbIsDebuff.Name = "ckbIsDebuff";
            this.ckbIsDebuff.Size = new System.Drawing.Size(79, 17);
            this.ckbIsDebuff.TabIndex = 8;
            this.ckbIsDebuff.Text = "Is A Debuff";
            this.ckbIsDebuff.UseVisualStyleBackColor = true;
            this.ckbIsDebuff.CheckedChanged += new System.EventHandler(this.ValueChanged);
            // 
            // btnOpenLibrary
            // 
            this.btnOpenLibrary.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenLibrary.Location = new System.Drawing.Point(157, 32);
            this.btnOpenLibrary.Name = "btnOpenLibrary";
            this.btnOpenLibrary.Size = new System.Drawing.Size(71, 20);
            this.btnOpenLibrary.TabIndex = 7;
            this.btnOpenLibrary.Text = "Open Library";
            this.btnOpenLibrary.UseVisualStyleBackColor = true;
            // 
            // numIconID
            // 
            this.numIconID.Location = new System.Drawing.Point(93, 32);
            this.numIconID.Name = "numIconID";
            this.numIconID.Size = new System.Drawing.Size(58, 20);
            this.numIconID.TabIndex = 6;
            this.numIconID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numIconID.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Icon";
            // 
            // pbIconDisplay
            // 
            this.pbIconDisplay.Location = new System.Drawing.Point(67, 32);
            this.pbIconDisplay.Name = "pbIconDisplay";
            this.pbIconDisplay.Size = new System.Drawing.Size(20, 20);
            this.pbIconDisplay.TabIndex = 4;
            this.pbIconDisplay.TabStop = false;
            // 
            // numDuration
            // 
            this.numDuration.DecimalPlaces = 2;
            this.numDuration.Location = new System.Drawing.Point(446, 6);
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(77, 20);
            this.numDuration.TabIndex = 3;
            this.numDuration.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duration (seconds, 0 is forever)";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(135, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // scriptBox1
            // 
            this.scriptBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptBox1.Location = new System.Drawing.Point(0, 0);
            this.scriptBox1.Name = "scriptBox1";
            this.scriptBox1.Script = "";
            this.scriptBox1.ScriptType = ToolCache.Scripting.Types.ScriptTypes.Buff;
            this.scriptBox1.Size = new System.Drawing.Size(577, 379);
            this.scriptBox1.TabIndex = 0;
            this.scriptBox1.ScriptUpdated += new System.EventHandler<System.EventArgs>(this.ValueChanged);
            // 
            // BuffsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 486);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BuffsEditor";
            this.Text = "Buffs Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BuffsEditor_FormClosing);
            this.toolsMainTools.ResumeLayout(false);
            this.toolsMainTools.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numIconID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBuffs;
        private System.Windows.Forms.ToolStrip toolsMainTools;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnDuplicate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private Components.ScriptBox scriptBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.NumericUpDown numIconID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbIconDisplay;
        private System.Windows.Forms.Button btnOpenLibrary;
        private System.Windows.Forms.CheckBox ckbIsDebuff;
        private System.Windows.Forms.CheckBox ckbShowIcon;
    }
}