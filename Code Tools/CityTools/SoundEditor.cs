using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Sound;

namespace CityTools {
    public partial class SoundEditor : Form {
        public static SoundEditor I;

        public SoundEditor() {
            I = this;
            InitializeComponent();

            sndMusic.ChangeSoundList(SoundDatabase.Music, "Sound/Music");
            sndAmbience.ChangeSoundList(SoundDatabase.Ambience, "Sound/Ambience");
            sndEffects.ChangeSoundList(SoundDatabase.Effects, "Sound/Effects");

            foreach (String s in SoundDatabase.EffectGroups.Keys) {
                cbEffectGroups.Items.Add(s);
                cbEffectGroups.SelectedIndex = 0;
            }
        }

        private void SoundEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SoundDatabase.SaveDatabase();
            player.Ctlcontrols.stop();
            I = null;
        }

        private void cbEffectGroups_TextChanged(object sender, EventArgs e) {
            listEffectGroupItems.Items.Clear();

            if (SoundDatabase.GetEffectGroup(cbEffectGroups.Text) != null) {
                foreach (SoundData s in SoundDatabase.GetEffectGroup(cbEffectGroups.Text)) {
                    listEffectGroupItems.Items.Add(s);
                }
            }
        }

        internal void AddToGroup(SoundData Sound) {
            if (tabControl1.SelectedTab == tabEffects) {
                if (SoundDatabase.GetEffectGroup(cbEffectGroups.Text) == null) {
                    SoundDatabase.EffectGroups.Add(cbEffectGroups.Text, new List<SoundData>());
                    cbEffectGroups.Items.Add(cbEffectGroups.Text);
                }

                if (!SoundDatabase.GetEffectGroup(cbEffectGroups.Text).Contains(Sound)) {
                    SoundDatabase.GetEffectGroup(cbEffectGroups.Text).Add(Sound);
                    listEffectGroupItems.Items.Add(Sound);
                }
            }
        }
    }
}
