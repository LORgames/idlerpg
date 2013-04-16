namespace ToolToGameExporter {
    partial class MainForm {
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataFolderLocation = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.game_btn = new System.Windows.Forms.Button();
            this.convert_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data Folder Location:";
            // 
            // txtDataFolderLocation
            // 
            this.txtDataFolderLocation.Location = new System.Drawing.Point(12, 27);
            this.txtDataFolderLocation.Name = "txtDataFolderLocation";
            this.txtDataFolderLocation.ReadOnly = true;
            this.txtDataFolderLocation.Size = new System.Drawing.Size(121, 20);
            this.txtDataFolderLocation.TabIndex = 2;
            this.txtDataFolderLocation.Text = "../Game Source/bin/Data/";
            // 
            // game_btn
            // 
            this.game_btn.Location = new System.Drawing.Point(139, 27);
            this.game_btn.Name = "game_btn";
            this.game_btn.Size = new System.Drawing.Size(75, 23);
            this.game_btn.TabIndex = 4;
            this.game_btn.Text = "Browse";
            this.game_btn.UseVisualStyleBackColor = true;
            this.game_btn.Click += new System.EventHandler(this.game_btn_Click);
            // 
            // convert_btn
            // 
            this.convert_btn.Location = new System.Drawing.Point(12, 53);
            this.convert_btn.Name = "convert_btn";
            this.convert_btn.Size = new System.Drawing.Size(202, 23);
            this.convert_btn.TabIndex = 4;
            this.convert_btn.Text = "Convert For Game";
            this.convert_btn.UseVisualStyleBackColor = true;
            this.convert_btn.Click += new System.EventHandler(this.convert_btn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 86);
            this.Controls.Add(this.convert_btn);
            this.Controls.Add(this.game_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDataFolderLocation);
            this.Name = "MainForm";
            this.Text = "Exporter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataFolderLocation;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button game_btn;
        private System.Windows.Forms.Button convert_btn;
    }
}

