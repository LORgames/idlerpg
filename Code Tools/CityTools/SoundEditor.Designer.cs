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
            this.tabAmbience = new System.Windows.Forms.TabPage();
            this.tabEffects = new System.Windows.Forms.TabPage();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.sndMusic = new CityTools.Components.SoundSelector_Panel();
            this.sndAmbience = new CityTools.Components.SoundSelector_Panel();
            this.splitEffects = new System.Windows.Forms.SplitContainer();
            this.sndEffects = new CityTools.Components.SoundSelector_Panel();
            this.listEffectGroupItems = new System.Windows.Forms.ListBox();
            this.cbEffectGroups = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabMusic.SuspendLayout();
            this.tabAmbience.SuspendLayout();
            this.tabEffects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitEffects)).BeginInit();
            this.splitEffects.Panel1.SuspendLayout();
            this.splitEffects.Panel2.SuspendLayout();
            this.splitEffects.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(587, 407);
            this.tabControl1.TabIndex = 0;
            // 
            // tabMusic
            // 
            this.tabMusic.Controls.Add(this.sndMusic);
            this.tabMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMusic.Location = new System.Drawing.Point(4, 22);
            this.tabMusic.Name = "tabMusic";
            this.tabMusic.Padding = new System.Windows.Forms.Padding(3);
            this.tabMusic.Size = new System.Drawing.Size(562, 381);
            this.tabMusic.TabIndex = 0;
            this.tabMusic.Text = "Music";
            this.tabMusic.UseVisualStyleBackColor = true;
            // 
            // tabAmbience
            // 
            this.tabAmbience.Controls.Add(this.sndAmbience);
            this.tabAmbience.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabAmbience.Location = new System.Drawing.Point(4, 22);
            this.tabAmbience.Name = "tabAmbience";
            this.tabAmbience.Padding = new System.Windows.Forms.Padding(3);
            this.tabAmbience.Size = new System.Drawing.Size(562, 381);
            this.tabAmbience.TabIndex = 1;
            this.tabAmbience.Text = "Ambience";
            this.tabAmbience.UseVisualStyleBackColor = true;
            // 
            // tabEffects
            // 
            this.tabEffects.Controls.Add(this.splitEffects);
            this.tabEffects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEffects.Location = new System.Drawing.Point(4, 22);
            this.tabEffects.Name = "tabEffects";
            this.tabEffects.Size = new System.Drawing.Size(579, 381);
            this.tabEffects.TabIndex = 2;
            this.tabEffects.Text = "Effects";
            this.tabEffects.UseVisualStyleBackColor = true;
            // 
            // player
            // 
            this.player.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(0, 407);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(587, 46);
            this.player.TabIndex = 1;
            // 
            // sndMusic
            // 
            this.sndMusic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sndMusic.Location = new System.Drawing.Point(3, 3);
            this.sndMusic.Name = "sndMusic";
            this.sndMusic.Size = new System.Drawing.Size(556, 375);
            this.sndMusic.TabIndex = 0;
            // 
            // sndAmbience
            // 
            this.sndAmbience.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sndAmbience.Location = new System.Drawing.Point(3, 3);
            this.sndAmbience.Name = "sndAmbience";
            this.sndAmbience.Size = new System.Drawing.Size(556, 375);
            this.sndAmbience.TabIndex = 0;
            // 
            // splitEffects
            // 
            this.splitEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEffects.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitEffects.Location = new System.Drawing.Point(0, 0);
            this.splitEffects.Name = "splitEffects";
            // 
            // splitEffects.Panel1
            // 
            this.splitEffects.Panel1.Controls.Add(this.sndEffects);
            // 
            // splitEffects.Panel2
            // 
            this.splitEffects.Panel2.Controls.Add(this.listEffectGroupItems);
            this.splitEffects.Panel2.Controls.Add(this.cbEffectGroups);
            this.splitEffects.Size = new System.Drawing.Size(579, 381);
            this.splitEffects.SplitterDistance = 397;
            this.splitEffects.TabIndex = 1;
            // 
            // sndEffects
            // 
            this.sndEffects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sndEffects.Location = new System.Drawing.Point(0, 0);
            this.sndEffects.Name = "sndEffects";
            this.sndEffects.Size = new System.Drawing.Size(397, 381);
            this.sndEffects.TabIndex = 0;
            // 
            // listEffectGroupItems
            // 
            this.listEffectGroupItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listEffectGroupItems.FormattingEnabled = true;
            this.listEffectGroupItems.Location = new System.Drawing.Point(0, 21);
            this.listEffectGroupItems.Name = "listEffectGroupItems";
            this.listEffectGroupItems.Size = new System.Drawing.Size(178, 360);
            this.listEffectGroupItems.TabIndex = 0;
            // 
            // cbEffectGroups
            // 
            this.cbEffectGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbEffectGroups.FormattingEnabled = true;
            this.cbEffectGroups.Location = new System.Drawing.Point(0, 0);
            this.cbEffectGroups.Name = "cbEffectGroups";
            this.cbEffectGroups.Size = new System.Drawing.Size(178, 21);
            this.cbEffectGroups.TabIndex = 1;
            this.cbEffectGroups.TextChanged += new System.EventHandler(this.cbEffectGroups_TextChanged);
            // 
            // SoundEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 453);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.player);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SoundEditor";
            this.Text = "SoundEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SoundEditor_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabMusic.ResumeLayout(false);
            this.tabAmbience.ResumeLayout(false);
            this.tabEffects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.splitEffects.Panel1.ResumeLayout(false);
            this.splitEffects.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitEffects)).EndInit();
            this.splitEffects.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMusic;
        private System.Windows.Forms.TabPage tabAmbience;
        private System.Windows.Forms.TabPage tabEffects;
        private Components.SoundSelector_Panel sndMusic;
        private Components.SoundSelector_Panel sndAmbience;
        private Components.SoundSelector_Panel sndEffects;
        public AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.SplitContainer splitEffects;
        private System.Windows.Forms.ListBox listEffectGroupItems;
        private System.Windows.Forms.ComboBox cbEffectGroups;
    }
}