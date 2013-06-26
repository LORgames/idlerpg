using CityTools.Components;

namespace CityTools {
    partial class EffectEditor {
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
            this.treeView = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEffectName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbAnimations = new System.Windows.Forms.ComboBox();
            this.lblAnimPnlName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scriptEffect = new CityTools.Components.ScriptBox();
            this.animationList = new CityTools.Components.AnimationList();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.Location = new System.Drawing.Point(0, 25);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(211, 404);
            this.treeView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(915, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::CityTools.Properties.Resources.add;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Effect Name:";
            // 
            // txtEffectName
            // 
            this.txtEffectName.Location = new System.Drawing.Point(376, 38);
            this.txtEffectName.Name = "txtEffectName";
            this.txtEffectName.Size = new System.Drawing.Size(116, 20);
            this.txtEffectName.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.animationList);
            this.panel1.Controls.Add(this.cbAnimations);
            this.panel1.Controls.Add(this.lblAnimPnlName);
            this.panel1.Location = new System.Drawing.Point(217, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 142);
            this.panel1.TabIndex = 4;
            // 
            // cbAnimations
            // 
            this.cbAnimations.FormattingEnabled = true;
            this.cbAnimations.Location = new System.Drawing.Point(110, 9);
            this.cbAnimations.Name = "cbAnimations";
            this.cbAnimations.Size = new System.Drawing.Size(162, 21);
            this.cbAnimations.TabIndex = 1;
            // 
            // lblAnimPnlName
            // 
            this.lblAnimPnlName.AutoSize = true;
            this.lblAnimPnlName.Location = new System.Drawing.Point(46, 12);
            this.lblAnimPnlName.Name = "lblAnimPnlName";
            this.lblAnimPnlName.Size = new System.Drawing.Size(58, 13);
            this.lblAnimPnlName.TabIndex = 0;
            this.lblAnimPnlName.Text = "Animations";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(217, 248);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(275, 169);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(376, 64);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(116, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Effect Group:";
            // 
            // scriptEffect
            // 
            this.scriptEffect.Location = new System.Drawing.Point(498, 31);
            this.scriptEffect.Name = "scriptEffect";
            this.scriptEffect.Script = "";
            this.scriptEffect.ScriptType = ToolCache.Scripting.ScriptTypes.Effect;
            this.scriptEffect.Size = new System.Drawing.Size(406, 386);
            this.scriptEffect.TabIndex = 5;
            // 
            // animationList
            // 
            this.animationList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.animationList.Location = new System.Drawing.Point(3, 36);
            this.animationList.Name = "animationList";
            this.animationList.Size = new System.Drawing.Size(269, 100);
            this.animationList.TabIndex = 2;
            // 
            // EffectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 429);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.scriptEffect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtEffectName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "EffectEditor";
            this.Text = "EffectEditor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEffectName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbAnimations;
        private System.Windows.Forms.Label lblAnimPnlName;
        private AnimationList animationList;
        private ScriptBox scriptEffect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
    }
}