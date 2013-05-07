using CityTools.ClipIns;

namespace CityTools {
    partial class TemplateEditor {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateEditor));
            this.pbExampleBase = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.lblTemplateID = new System.Windows.Forms.ToolStripLabel();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cbTemplateGroup = new System.Windows.Forms.ComboBox();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.ccAnimation = new CityTools.ClipIns.AnimationList();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.numOffsetHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbDrawOffset = new System.Windows.Forms.CheckBox();
            this.ckbDrawRectangles = new System.Windows.Forms.CheckBox();
            this.btnRemoveBoxes = new System.Windows.Forms.Button();
            this.ckbIsSolid = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeTemplateNames = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pbExampleBase)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbExampleBase
            // 
            this.pbExampleBase.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbExampleBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbExampleBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbExampleBase.Location = new System.Drawing.Point(0, 0);
            this.pbExampleBase.Name = "pbExampleBase";
            this.pbExampleBase.Size = new System.Drawing.Size(519, 417);
            this.pbExampleBase.TabIndex = 0;
            this.pbExampleBase.TabStop = false;
            this.pbExampleBase.Paint += new System.Windows.Forms.PaintEventHandler(this.pbExampleBase_Paint);
            this.pbExampleBase.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbExampleBase_MouseDown);
            this.pbExampleBase.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbExampleBase_MouseMove);
            this.pbExampleBase.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbExampleBase_MouseUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewTemplate,
            this.btnDeleteTemplate,
            this.btnSave,
            this.lblTemplateID});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(261, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewTemplate
            // 
            this.btnNewTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTemplate.Image")));
            this.btnNewTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewTemplate.Name = "btnNewTemplate";
            this.btnNewTemplate.Size = new System.Drawing.Size(23, 22);
            this.btnNewTemplate.Text = "New Template";
            this.btnNewTemplate.Click += new System.EventHandler(this.btnNewTemplate_Click);
            // 
            // btnDeleteTemplate
            // 
            this.btnDeleteTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteTemplate.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteTemplate.Image")));
            this.btnDeleteTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteTemplate.Name = "btnDeleteTemplate";
            this.btnDeleteTemplate.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteTemplate.Text = "Delete Currently Selected Template";
            this.btnDeleteTemplate.Click += new System.EventHandler(this.btnDeleteTemplate_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(23, 22);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTemplateID
            // 
            this.lblTemplateID.Name = "lblTemplateID";
            this.lblTemplateID.Size = new System.Drawing.Size(40, 22);
            this.lblTemplateID.Text = "<TID>";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(125, 9);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(73, 13);
            this.lblGroup.TabIndex = 10;
            this.lblGroup.Text = "Object Group:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Object Name:";
            // 
            // cbTemplateGroup
            // 
            this.cbTemplateGroup.FormattingEnabled = true;
            this.cbTemplateGroup.Location = new System.Drawing.Point(128, 24);
            this.cbTemplateGroup.Name = "cbTemplateGroup";
            this.cbTemplateGroup.Size = new System.Drawing.Size(121, 21);
            this.cbTemplateGroup.TabIndex = 8;
            this.cbTemplateGroup.TextChanged += new System.EventHandler(this.ValueChanged);
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Location = new System.Drawing.Point(6, 25);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(121, 20);
            this.txtTemplateName.TabIndex = 7;
            this.txtTemplateName.Text = "<Unnamed>";
            // 
            // ccAnimation
            // 
            this.ccAnimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccAnimation.Location = new System.Drawing.Point(0, 0);
            this.ccAnimation.Name = "ccAnimation";
            this.ccAnimation.Size = new System.Drawing.Size(261, 120);
            this.ccAnimation.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // numOffsetHeight
            // 
            this.numOffsetHeight.Location = new System.Drawing.Point(182, 50);
            this.numOffsetHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numOffsetHeight.Name = "numOffsetHeight";
            this.numOffsetHeight.Size = new System.Drawing.Size(67, 20);
            this.numOffsetHeight.TabIndex = 12;
            this.numOffsetHeight.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Offset";
            // 
            // ckbDrawOffset
            // 
            this.ckbDrawOffset.AutoSize = true;
            this.ckbDrawOffset.Checked = true;
            this.ckbDrawOffset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDrawOffset.Location = new System.Drawing.Point(6, 76);
            this.ckbDrawOffset.Name = "ckbDrawOffset";
            this.ckbDrawOffset.Size = new System.Drawing.Size(82, 17);
            this.ckbDrawOffset.TabIndex = 14;
            this.ckbDrawOffset.Text = "Draw Offset";
            this.ckbDrawOffset.UseVisualStyleBackColor = true;
            // 
            // ckbDrawRectangles
            // 
            this.ckbDrawRectangles.AutoSize = true;
            this.ckbDrawRectangles.Checked = true;
            this.ckbDrawRectangles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDrawRectangles.Location = new System.Drawing.Point(6, 99);
            this.ckbDrawRectangles.Name = "ckbDrawRectangles";
            this.ckbDrawRectangles.Size = new System.Drawing.Size(108, 17);
            this.ckbDrawRectangles.TabIndex = 15;
            this.ckbDrawRectangles.Text = "Draw Rectangles";
            this.ckbDrawRectangles.UseVisualStyleBackColor = true;
            // 
            // btnRemoveBoxes
            // 
            this.btnRemoveBoxes.Location = new System.Drawing.Point(120, 93);
            this.btnRemoveBoxes.Name = "btnRemoveBoxes";
            this.btnRemoveBoxes.Size = new System.Drawing.Size(129, 23);
            this.btnRemoveBoxes.TabIndex = 16;
            this.btnRemoveBoxes.Text = "Remove Boxes";
            this.btnRemoveBoxes.UseVisualStyleBackColor = true;
            this.btnRemoveBoxes.Click += new System.EventHandler(this.btnRemoveBoxes_Click);
            // 
            // ckbIsSolid
            // 
            this.ckbIsSolid.AutoSize = true;
            this.ckbIsSolid.Checked = true;
            this.ckbIsSolid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsSolid.Location = new System.Drawing.Point(6, 53);
            this.ckbIsSolid.Name = "ckbIsSolid";
            this.ckbIsSolid.Size = new System.Drawing.Size(94, 17);
            this.ckbIsSolid.TabIndex = 17;
            this.ckbIsSolid.Text = "Is Object Solid";
            this.ckbIsSolid.UseVisualStyleBackColor = true;
            this.ckbIsSolid.CheckedChanged += new System.EventHandler(this.ValueChanged);
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
            this.splitContainer1.Panel1.Controls.Add(this.treeTemplateNames);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(784, 541);
            this.splitContainer1.SplitterDistance = 261;
            this.splitContainer1.TabIndex = 18;
            // 
            // treeTemplateNames
            // 
            this.treeTemplateNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTemplateNames.Location = new System.Drawing.Point(0, 25);
            this.treeTemplateNames.Name = "treeTemplateNames";
            this.treeTemplateNames.Size = new System.Drawing.Size(261, 516);
            this.treeTemplateNames.TabIndex = 6;
            this.treeTemplateNames.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeTemplateNames_AfterSelect);
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
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pbExampleBase);
            this.splitContainer2.Size = new System.Drawing.Size(519, 541);
            this.splitContainer2.SplitterDistance = 120;
            this.splitContainer2.TabIndex = 18;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lblGroup);
            this.splitContainer3.Panel1.Controls.Add(this.lblName);
            this.splitContainer3.Panel1.Controls.Add(this.numOffsetHeight);
            this.splitContainer3.Panel1.Controls.Add(this.ckbIsSolid);
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.ckbDrawOffset);
            this.splitContainer3.Panel1.Controls.Add(this.btnRemoveBoxes);
            this.splitContainer3.Panel1.Controls.Add(this.cbTemplateGroup);
            this.splitContainer3.Panel1.Controls.Add(this.txtTemplateName);
            this.splitContainer3.Panel1.Controls.Add(this.ckbDrawRectangles);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.ccAnimation);
            this.splitContainer3.Size = new System.Drawing.Size(519, 120);
            this.splitContainer3.SplitterDistance = 254;
            this.splitContainer3.TabIndex = 0;
            // 
            // TemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 541);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TemplateEditor";
            this.Text = "Object Template Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemplateEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbExampleBase)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffsetHeight)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbExampleBase;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewTemplate;
        private System.Windows.Forms.ToolStripButton btnDeleteTemplate;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripLabel lblTemplateID;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbTemplateGroup;
        private System.Windows.Forms.TextBox txtTemplateName;
        private AnimationList ccAnimation;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown numOffsetHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbDrawOffset;
        private System.Windows.Forms.CheckBox ckbDrawRectangles;
        private System.Windows.Forms.Button btnRemoveBoxes;
        private System.Windows.Forms.CheckBox ckbIsSolid;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TreeView treeTemplateNames;
    }
}