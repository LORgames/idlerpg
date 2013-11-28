namespace CityTools.Components {
    partial class ScriptBox {
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
            this.components = new System.ComponentModel.Container();
            this.txtScript = new System.Windows.Forms.RichTextBox();
            this.scriptContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnParse = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnTSParse = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.equipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weaponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slashAttackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spearAttackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bootsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walkingScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crittersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleAttackInRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrowScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGlobalVariables = new System.Windows.Forms.ToolStripButton();
            this.lblLineNumber = new System.Windows.Forms.ToolStripLabel();
            this.scriptContextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtScript
            // 
            this.txtScript.AcceptsTab = true;
            this.txtScript.ContextMenuStrip = this.scriptContextMenu;
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(0, 25);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(406, 282);
            this.txtScript.TabIndex = 0;
            this.txtScript.Text = "";
            this.txtScript.WordWrap = false;
            this.txtScript.SelectionChanged += new System.EventHandler(this.txtScript_SelectionChanged);
            this.txtScript.TextChanged += new System.EventHandler(this.txtScript_TextChanged);
            this.txtScript.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScript_KeyDown);
            // 
            // scriptContextMenu
            // 
            this.scriptContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnParse});
            this.scriptContextMenu.Name = "scriptContextMenu";
            this.scriptContextMenu.Size = new System.Drawing.Size(113, 26);
            // 
            // btnParse
            // 
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(112, 22);
            this.btnParse.Text = "Parse";
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnTSParse,
            this.toolStripDropDownButton1,
            this.btnGlobalVariables,
            this.lblLineNumber});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(406, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel1.Text = "Script";
            // 
            // btnTSParse
            // 
            this.btnTSParse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTSParse.Image = global::CityTools.Properties.Resources.accept;
            this.btnTSParse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTSParse.Name = "btnTSParse";
            this.btnTSParse.Size = new System.Drawing.Size(23, 22);
            this.btnTSParse.Text = "Test Script";
            this.btnTSParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.equipmentToolStripMenuItem,
            this.crittersToolStripMenuItem,
            this.effectsToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::CityTools.Properties.Resources.arrow_merge;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "Quick Snippets";
            // 
            // equipmentToolStripMenuItem
            // 
            this.equipmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weaponsToolStripMenuItem,
            this.bootsToolStripMenuItem});
            this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
            this.equipmentToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.equipmentToolStripMenuItem.Text = "Equipment";
            // 
            // weaponsToolStripMenuItem
            // 
            this.weaponsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slashAttackToolStripMenuItem,
            this.spearAttackToolStripMenuItem});
            this.weaponsToolStripMenuItem.Name = "weaponsToolStripMenuItem";
            this.weaponsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.weaponsToolStripMenuItem.Text = "Weapons";
            // 
            // slashAttackToolStripMenuItem
            // 
            this.slashAttackToolStripMenuItem.Name = "slashAttackToolStripMenuItem";
            this.slashAttackToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.slashAttackToolStripMenuItem.Text = "Slash Attack";
            // 
            // spearAttackToolStripMenuItem
            // 
            this.spearAttackToolStripMenuItem.Name = "spearAttackToolStripMenuItem";
            this.spearAttackToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.spearAttackToolStripMenuItem.Text = "Spear Attack";
            // 
            // bootsToolStripMenuItem
            // 
            this.bootsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.walkingScriptToolStripMenuItem});
            this.bootsToolStripMenuItem.Name = "bootsToolStripMenuItem";
            this.bootsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.bootsToolStripMenuItem.Text = "Boots";
            // 
            // walkingScriptToolStripMenuItem
            // 
            this.walkingScriptToolStripMenuItem.Name = "walkingScriptToolStripMenuItem";
            this.walkingScriptToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.walkingScriptToolStripMenuItem.Text = "Walking Script";
            // 
            // crittersToolStripMenuItem
            // 
            this.crittersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beastToolStripMenuItem});
            this.crittersToolStripMenuItem.Name = "crittersToolStripMenuItem";
            this.crittersToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.crittersToolStripMenuItem.Text = "Critters";
            // 
            // beastToolStripMenuItem
            // 
            this.beastToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleAttackInRangeToolStripMenuItem});
            this.beastToolStripMenuItem.Name = "beastToolStripMenuItem";
            this.beastToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.beastToolStripMenuItem.Text = "Beast";
            // 
            // simpleAttackInRangeToolStripMenuItem
            // 
            this.simpleAttackInRangeToolStripMenuItem.Name = "simpleAttackInRangeToolStripMenuItem";
            this.simpleAttackInRangeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.simpleAttackInRangeToolStripMenuItem.Text = "Simple Attack In Range";
            // 
            // effectsToolStripMenuItem
            // 
            this.effectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrowScriptToolStripMenuItem});
            this.effectsToolStripMenuItem.Name = "effectsToolStripMenuItem";
            this.effectsToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.effectsToolStripMenuItem.Text = "Effects";
            // 
            // arrowScriptToolStripMenuItem
            // 
            this.arrowScriptToolStripMenuItem.Name = "arrowScriptToolStripMenuItem";
            this.arrowScriptToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.arrowScriptToolStripMenuItem.Text = "Arrow Script";
            // 
            // btnGlobalVariables
            // 
            this.btnGlobalVariables.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGlobalVariables.Image = global::CityTools.Properties.Resources.text_list_numbers;
            this.btnGlobalVariables.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGlobalVariables.Name = "btnGlobalVariables";
            this.btnGlobalVariables.Size = new System.Drawing.Size(23, 22);
            this.btnGlobalVariables.Text = "Global Variables";
            this.btnGlobalVariables.Click += new System.EventHandler(this.btnGlobalVariables_Click);
            // 
            // lblLineNumber
            // 
            this.lblLineNumber.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblLineNumber.Name = "lblLineNumber";
            this.lblLineNumber.Size = new System.Drawing.Size(13, 22);
            this.lblLineNumber.Text = "0";
            // 
            // ScriptBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtScript);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ScriptBox";
            this.Size = new System.Drawing.Size(406, 307);
            this.scriptContextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtScript;
        private System.Windows.Forms.ContextMenuStrip scriptContextMenu;
        private System.Windows.Forms.ToolStripMenuItem btnParse;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnTSParse;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem equipmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weaponsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slashAttackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spearAttackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bootsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walkingScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crittersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleAttackInRangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrowScriptToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnGlobalVariables;
        private System.Windows.Forms.ToolStripLabel lblLineNumber;
    }
}
