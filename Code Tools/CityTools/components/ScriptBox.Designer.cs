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
            this.scriptContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtScript
            // 
            this.txtScript.AcceptsTab = true;
            this.txtScript.ContextMenuStrip = this.scriptContextMenu;
            this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScript.Location = new System.Drawing.Point(0, 0);
            this.txtScript.Name = "txtScript";
            this.txtScript.Size = new System.Drawing.Size(406, 307);
            this.txtScript.TabIndex = 0;
            this.txtScript.Text = "";
            this.txtScript.WordWrap = false;
            // 
            // scriptContextMenu
            // 
            this.scriptContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnParse});
            this.scriptContextMenu.Name = "scriptContextMenu";
            this.scriptContextMenu.Size = new System.Drawing.Size(153, 48);
            // 
            // btnParse
            // 
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(152, 22);
            this.btnParse.Text = "Parse";
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // ScriptBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtScript);
            this.Name = "ScriptBox";
            this.Size = new System.Drawing.Size(406, 307);
            this.scriptContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtScript;
        private System.Windows.Forms.ContextMenuStrip scriptContextMenu;
        private System.Windows.Forms.ToolStripMenuItem btnParse;
    }
}
