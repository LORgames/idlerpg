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
        }

        private void SoundEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SoundDatabase.SaveDatabase();
            player.Ctlcontrols.stop();
            I = null;
        }
    }
}
