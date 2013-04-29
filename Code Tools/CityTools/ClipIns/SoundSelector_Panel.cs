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

namespace CityTools.ClipIns {
    public partial class SoundSelector_Panel : UserControl {
        public List<SoundData> Sounds;
        internal string SaveLocation = "";

        public SoundSelector_Panel() {
            InitializeComponent();
        }

        public void ChangeSoundList(List<SoundData> _Sounds, string _Directory) {
            Sounds = _Sounds;
            SaveLocation = _Directory;

            UpdateBoxes();
        }

        internal void UpdateBoxes() {
            pnlContent.SuspendLayout();
            pnlContent.Controls.Clear();

            for (int i = 0; i < Sounds.Count; i++) {
                SoundEditor_SoundPanel sp = new SoundEditor_SoundPanel();
                sp.SwitchTo(Sounds[i], this);

                pnlContent.Controls.Add(sp);
            }

            pnlContent.ResumeLayout();
        }

        private void pnlContent_DragDrop(object sender, DragEventArgs e) {
            if (!Directory.Exists(SaveLocation)) Directory.CreateDirectory(SaveLocation);

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (data != null) {
                    for (int i = 0; i < data.Length; i++) {
                        if (data.GetValue(i) is String) {
                            string filename = ((string[])data)[i];
                            string ext = Path.GetExtension(filename).ToLower();
                            if (ext == ".mp3") {
                                //Add animation
                                string nFilename = SaveLocation + "/" + Path.GetFileNameWithoutExtension(filename) + ".mp3";

                                if (Path.GetFullPath(nFilename) == Path.GetFullPath(filename)) {
                                    //Don't need to do anything, its the same file
                                } else if (!File.Exists(nFilename)) {
                                    File.Copy(filename, nFilename);
                                } else if (MessageBox.Show("Overwrite " + nFilename + "?", "Overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                    File.Copy(filename, nFilename, true);
                                }

                                Sounds.Add(new SoundData(filename, Path.GetFileNameWithoutExtension(filename)));
                            }
                        }
                    }
                }
            }

            UpdateBoxes();
        }

        private void pnlContent_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
