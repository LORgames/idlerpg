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
using ToolCache.General;
using CityTools.Components.GIFSupport;

namespace CityTools.Components {
    public partial class AnimationList : UserControl {

        internal AnimatedObject _anim;
        internal string location = "objcache";

        internal string filenamePrefix = "";
        public event ChangedEventHandler AnimationChanged;

        public AnimationList() {
            InitializeComponent();
        }

        public void OnAnimationChanged(object o, EventArgs e) {
            if (AnimationChanged != null) {
                AnimationChanged(o, e);
            }
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

                                if (Path.GetFullPath(nFilename) == Path.GetFullPath(filename)) {
                                    //Don't need to do anything, its the same file
                                } else if (!File.Exists(nFilename)) {
                                    File.Copy(filename, nFilename);
                                } else if (MessageBox.Show("Overwrite " + nFilename + "?", "Overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                    File.Copy(filename, nFilename, true);
                                }

                                OnAnimationChanged(this, null);
                                ImageCache.ForceCache(nFilename);
                                _anim.Frames.Add(nFilename);
                            }
                        }
                    }
                }
            }

            UpdateBoxes();
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

            OnAnimationChanged(this, null);
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

            OnAnimationChanged(this, null);
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

            OnAnimationChanged(this, null);
            UpdateBoxes();
        }

        private void numFramerate_ValueChanged(object sender, EventArgs e) {
            _anim.PlaybackSpeed = (float)numFramerate.Value;
            OnAnimationChanged(this, null);
        }

        internal void DisablePlaybackSpeed() {
            numFramerate.Enabled = false;
            numFramerate.Visible = false;
            lblAnimation.Text = "ANIM:";
        }

        private void btnSaveGIF_Click(object sender, EventArgs e) {
            if (_anim != null && _anim.Frames.Count > 1) {
                if (saveDialogue.ShowDialog() == DialogResult.OK) {
                    String[] imageFilePaths = _anim.Frames.ToArray();
                    AnimatedGifEncoder encoder = new AnimatedGifEncoder();

                    List<Image> cleanupList = new List<Image>();

                    encoder.Start(saveDialogue.FileName);
                    encoder.SetDelay((int)(1000 * _anim.PlaybackSpeed));
                    encoder.SetRepeat(0); //-1:no repeat,0:always repeat
                    //encoder.SetTransparent();

                    for (int i = 0; i < _anim.Frames.Count; i++) {
                        Image bmp = GIFImageHelper.RequestGIFSuitableImage(_anim.Frames[i]);
                        encoder.AddFrame(bmp);
                        cleanupList.Add(bmp);
                    }
                    encoder.Finish();

                    while (cleanupList.Count > 0) {
                        cleanupList[0].Dispose();
                        cleanupList.RemoveAt(0);
                    }

                    cleanupList.Clear();
                    cleanupList = null;
                }
            } else {
                MessageBox.Show("The animation requires at least 2 frames to be exported as an animation!");
            }
        }
    }
}
