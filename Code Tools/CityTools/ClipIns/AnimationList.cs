using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ToolCache.Animation;

namespace CityTools.ClipIns {
    public partial class AnimationList : UserControl {

        internal AnimatedObject _anim;
        internal string location = "objcache";

        internal string filenamePrefix = "";

        public AnimationList() {
            InitializeComponent();

            splitContainer1.Panel2.AutoScroll = false;
            splitContainer1.Panel2.HorizontalScroll.Enabled = true;
            splitContainer1.Panel2.HorizontalScroll.Visible = true;
            splitContainer1.Panel2.VerticalScroll.Enabled = false;
            splitContainer1.Panel2.VerticalScroll.Visible = false;
        }

        public void SetSaveLocation(string directory) {
            location = directory;
        }

        public void ClearAnimation(string prefix = "") {
            _anim = new AnimatedObject();
            UpdateBoxes();

            filenamePrefix = prefix;
        }

        public void ChangeToAnimation(AnimatedObject anim, string prefix = "") {
            _anim = anim;
            UpdateBoxes();

            filenamePrefix = prefix;
        }

        private void splitContainer1_Panel2_DragDrop(object sender, DragEventArgs e) {
            if (!Directory.Exists(location)) Directory.CreateDirectory(location);

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (data != null) {
                    for (int i = 0; i < data.Length; i++) {
                        if (data.GetValue(i) is String) {
                            string filename = ((string[])data)[i];
                            string ext = Path.GetExtension(filename).ToLower();
                            if (ext == ".png") {
                                //Add animation
                                string nFilename = location + "/" + filenamePrefix + Path.GetFileNameWithoutExtension(filename) + ".png";

                                bool copied = false;

                                if (Path.GetFullPath(nFilename) == Path.GetFullPath(filename)) {
                                    copied = true;
                                } else if (!File.Exists(nFilename)) {
                                    File.Copy(filename, nFilename);
                                    copied = true;
                                } else if(MessageBox.Show("Overwrite " + nFilename + "?", "Overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                    File.Copy(filename, nFilename, true);
                                    copied = true;
                                }

                                if (copied) {
                                    _anim.Frames.Add(nFilename);
                                    UpdateBoxes();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void splitContainer1_Panel2_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        public void UpdateBoxes() {
            splitContainer1.SuspendLayout();

            numFramerate.Value = (decimal)_anim.PlaybackSpeed;

            while (splitContainer1.Panel2.Controls.Count > 0) {
                splitContainer1.Panel2.Controls.Clear();
            }

            for (var i = 0; i < _anim.Frames.Count; i++) {
                AnimationFrame af = new AnimationFrame(this);
                af.SetFrame(_anim.Frames[i]);
                af.Left = 83 * i;
                splitContainer1.Panel2.Controls.Add(af);
            }

            splitContainer1.ResumeLayout();
        }

        internal AnimatedObject GetAnimation() {
            return _anim;
        }

        internal void DeleteFrame(AnimationFrame animationFrame) {
            for (int i = 0; i < splitContainer1.Panel2.Controls.Count; i++) {
                if (splitContainer1.Panel2.Controls[i] == animationFrame) {
                    splitContainer1.Panel2.Controls.RemoveAt(i);
                    _anim.Frames.RemoveAt(i);
                    break;
                }
            }

            UpdateBoxes();
        }

        internal void ShiftLeft(AnimationFrame animationFrame) {
            for (int i = 0; i < splitContainer1.Panel2.Controls.Count; i++) {
                if (splitContainer1.Panel2.Controls[i] == animationFrame) {
                    if (i > 0) {
                        String _t = _anim.Frames[i - 1];
                        _anim.Frames[i - 1] = _anim.Frames[i];
                        _anim.Frames[i] = _t;
                        break;
                    }
                }
            }

            UpdateBoxes();
        }

        internal void ShiftRight(AnimationFrame animationFrame) {
            for (int i = 0; i < splitContainer1.Panel2.Controls.Count; i++) {
                if (splitContainer1.Panel2.Controls[i] == animationFrame) {
                    if (i < _anim.Frames.Count-1) {
                        String _t = _anim.Frames[i + 1];
                        _anim.Frames[i + 1] = _anim.Frames[i];
                        _anim.Frames[i] = _t;
                        break;
                    }
                }
            }

            UpdateBoxes();
        }

        private void numFramerate_ValueChanged(object sender, EventArgs e) {
            _anim.PlaybackSpeed = (float)numFramerate.Value;
        }
    }
}
