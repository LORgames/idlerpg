namespace CityTools {
    partial class SoundEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundEditor));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMusic = new System.Windows.Forms.TabPage();
            this.sndMusic = new CityTools.ClipIns.SoundSelector_Panel();
            this.tabAmbience = new System.Windows.Forms.TabPage();
            this.sndAmbience = new CityTools.ClipIns.SoundSelector_Panel();
            this.tabEffects = new System.Windows.Forms.TabPage();
            this.sndEffects = new CityTools.ClipIns.SoundSelector_Panel();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.tabControl1.SuspendLayout();
            this.tabMusic.SuspendLayout();
            this.tabAmbience.SuspendLayout();
            this.tabEffects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMusic);
            this.tabControl1.Controls.Add(this.tabAmbience);
            this.tabControl1.Controls.Add(this.tabEffects);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(491, 453);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMusic
            // 
            this.tabMusic.Controls.Add(this.sndMusic);
            this.tabMusic.Location = new System.Drawing.Point(4, 22);
            this.tabMusic.Name = "tabMusic";
            this.tabMusic.Padding = new System.Windows.Forms.Padding(3);
            this.tabMusic.Size = new System.Drawing.Size(483, 427);
            this.tabMusic.TabIndex = 0;
            this.tabMusic.Text = "Music";
            this.tabMusic.UseVisualStyleBackColor = true;
            // 
            // sndMusic
            // 
            this.sndMusic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sndMusic.Location = new System.Drawing.Point(3, 3);
            this.sndMusic.Name = "sndMusic";
            this.sndMusic.Size = new System.Drawing.Size(477, 421);
            this.sndMusic.TabIndex = 0;
            // 
            // tabAmbience
            // 
            this.tabAmbience.Controls.Add(this.sndAmbience);
            this.tabAmbience.Location = new System.Drawing.Point(4, 22);
            this.tabAmbience.Name = "tabAmbience";
            this.tabAmbience.Padding = new System.Windows.Forms.Padding(3);
            this.tabAmbience.Size = new System.Drawing.Size(483, 427);
            this.tabAmbience.TabIndex = 1;
            this.tabAmbience.Text = "Ambience";
            this.tabAmbience.UseVisualStyleBackColor = true;
            // 
            // sndAmbience
            // 
            this.sndAmbience.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sndAmbience.Location = new System.Drawing.Point(3, 3);
            this.sndAmbience.Name = "sndAmbience";
            this.sndAmbience.Size = new System.Drawing.Size(477, 421);
            this.sndAmbience.TabIndex = 0;
            // 
            // tabEffects
            // 
            this.tabEffects.Controls.Add(this.sndEffects);
            this.tabEffects.Location = new System.Drawing.Point(4, 22);
            this.tabEffects.Name = "tabEffects";
            this.tabEffects.Size = new System.Drawing.Size(483, 427);
            this.tabEffects.TabIndex = 2;
            this.tabEffects.Text = "Effects";
            this.tabEffects.UseVisualStyleBackColor = true;
            // 
            // sndEffects
            // 
            this.sndEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sndEffects.Location = new System.Drawing.Point(0, 0);
            this.sndEffects.Name = "sndEffects";
            this.sndEffects.Size = new System.Drawing.Size(483, 427);
            this.sndEffects.TabIndex = 0;
            // 
            // player
            // 
            this.player.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(0, 407);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(491, 46);
            this.player.TabIndex = 1;
            // 
            // SoundEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 453);
            this.Controls.Add(this.player);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoundEditor";
            this.Text = "SoundEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SoundEditor_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabMusic.ResumeLayout(false);
            this.tabAmbience.ResumeLayout(false);
            this.tabEffects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMusic;
        private System.Windows.Forms.TabPage tabAmbience;
        private System.Windows.Forms.TabPage tabEffects;
        private ClipIns.SoundSelector_Panel sndMusic;
        private ClipIns.SoundSelector_Panel sndAmbience;
        private ClipIns.SoundSelector_Panel sndEffects;
        public AxWMPLib.AxWindowsMediaPlayer player;
    }
}