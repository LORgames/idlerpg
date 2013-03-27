namespace ToolCache.Map.Objects.Tool {
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
            this.cbTemplateNames = new System.Windows.Forms.ToolStripComboBox();
            this.btnNewTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.lblTemplateID = new System.Windows.Forms.ToolStripLabel();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cbTemplateGroup = new System.Windows.Forms.ComboBox();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.ccAnimation = new ToolCache.Animation.Form.AnimationList();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbExampleBase)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbExampleBase
            // 
            this.pbExampleBase.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbExampleBase.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbExampleBase.Location = new System.Drawing.Point(272, 29);
            this.pbExampleBase.Name = "pbExampleBase";
            this.pbExampleBase.Size = new System.Drawing.Size(500, 500);
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
            this.cbTemplateNames,
            this.btnNewTemplate,
            this.btnDeleteTemplate,
            this.btnSave,
            this.lblTemplateID});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbTemplateNames
            // 
            this.cbTemplateNames.Name = "cbTemplateNames";
            this.cbTemplateNames.Size = new System.Drawing.Size(169, 25);
            this.cbTemplateNames.SelectedIndexChanged += new System.EventHandler(this.cbTemplateNames_SelectedIndexChanged);
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
            this.lblTemplateID.Size = new System.Drawing.Size(41, 22);
            this.lblTemplateID.Text = "<TID>";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(12, 67);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(73, 13);
            this.lblGroup.TabIndex = 10;
            this.lblGroup.Text = "Object Group:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 28);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(72, 13);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Object Name:";
            // 
            // cbTemplateGroup
            // 
            this.cbTemplateGroup.FormattingEnabled = true;
            this.cbTemplateGroup.Location = new System.Drawing.Point(15, 83);
            this.cbTemplateGroup.Name = "cbTemplateGroup";
            this.cbTemplateGroup.Size = new System.Drawing.Size(251, 21);
            this.cbTemplateGroup.TabIndex = 8;
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Location = new System.Drawing.Point(15, 44);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(251, 20);
            this.txtTemplateName.TabIndex = 7;
            this.txtTemplateName.Text = "<Unnamed>";
            // 
            // ccAnimation
            // 
            this.ccAnimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ccAnimation.Location = new System.Drawing.Point(15, 110);
            this.ccAnimation.Name = "ccAnimation";
            this.ccAnimation.Size = new System.Drawing.Size(251, 100);
            this.ccAnimation.TabIndex = 11;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TemplateEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 541);
            this.Controls.Add(this.ccAnimation);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cbTemplateGroup);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pbExampleBase);
            this.Name = "TemplateEditor";
            this.Text = "Object Template Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemplateEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbExampleBase)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbExampleBase;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbTemplateNames;
        private System.Windows.Forms.ToolStripButton btnNewTemplate;
        private System.Windows.Forms.ToolStripButton btnDeleteTemplate;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripLabel lblTemplateID;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbTemplateGroup;
        private System.Windows.Forms.TextBox txtTemplateName;
        private Animation.Form.AnimationList ccAnimation;
        private System.Windows.Forms.Timer timer1;
    }
}