using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Sound;
using System.IO;
using System.Media;

namespace CityTools.Components {
    public partial class SoundEditor_SoundPanel : UserControl {
        internal SoundData Sound;
        internal SoundSelector_Panel Owner;

        public SoundEditor_SoundPanel() {
            InitializeComponent();
        }

        internal void SwitchTo(SoundData _Sound, SoundSelector_Panel owner) {
            Sound = _Sound;
            Owner = owner;


            txtFilename.Text = Path.GetFileName(Sound.Filename);
            txtSoundName.Text = Sound.Name;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            Owner.Sounds.Remove(Sound);
            Owner.Controls.Remove(this);
            Owner.UpdateBoxes();
        }

        private void txtSoundName_TextChanged(object sender, EventArgs e) {
            Sound.Name = txtSoundName.Text;
        }

        private void txtFilename_TextChanged(object sender, EventArgs e) {
            if (File.Exists(Owner.SaveLocation + "/" + txtFilename.Text)) {
                Sound.Filename = txtFilename.Text;
            } else if(!txtFilename.Focused) {
                txtFilename.Text = Sound.Filename;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e) {
            SoundEditor.I.player.URL = Owner.SaveLocation + "/" + Sound.Filename;
        }
    }
}
