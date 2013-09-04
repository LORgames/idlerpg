namespace CityTools.Components {
    partial class SoundEditor_SoundPanel {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoundName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddToGroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Script Sound Name";
            // 
            // txtSoundName
            // 
            this.txtSoundName.Location = new System.Drawing.Point(6, 14);
            this.txtSoundName.Name = "txtSoundName";
            this.txtSoundName.Size = new System.Drawing.Size(141, 20);
            this.txtSoundName.TabIndex = 1;
            this.txtSoundName.TextChanged += new System.EventHandler(this.txtSoundName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filename";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(153, 14);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(115, 20);
            this.txtFilename.TabIndex = 3;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // btnPlay
            // 
            this.btnPlay.Image = global::CityTools.Properties.Resources.bell;
            this.btnPlay.Location = new System.Drawing.Point(274, 9);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(25, 25);
            this.btnPlay.TabIndex = 4;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::CityTools.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(305, 9);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 25);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddToGroup
            // 
            this.btnAddToGroup.Image = global::CityTools.Properties.Resources.add;
            this.btnAddToGroup.Location = new System.Drawing.Point(336, 9);
            this.btnAddToGroup.Name = "btnAddToGroup";
            this.btnAddToGroup.Size = new System.Drawing.Size(25, 25);
            this.btnAddToGroup.TabIndex = 6;
            this.btnAddToGroup.UseVisualStyleBackColor = true;
            this.btnAddToGroup.Click += new System.EventHandler(this.btnAddToGroup_Click);
            // 
            // SoundEditor_SoundPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddToGroup);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSoundName);
            this.Controls.Add(this.label1);
            this.Name = "SoundEditor_SoundPanel";
            this.Size = new System.Drawing.Size(367, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoundName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddToGroup;
    }
}
