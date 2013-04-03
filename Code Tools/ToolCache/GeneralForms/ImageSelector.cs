using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.GeneralForms.ClipIns;
using System.IO;

namespace ToolCache.GeneralForms {
    public partial class ImageSelector : Form {
        private Func<string, int> afterCompletion;

        private List<string> Files = new List<string>();
        private string location = "";

        public ImageSelector(Func<string, int> callback, string[] files, string location) {
            InitializeComponent();

            Files.AddRange(files);

            this.location = location;
            afterCompletion = callback;

            UpdateBoxes();
        }

        internal void Clicked(ImageSelector_ImagePnl imageSelector_ImagePnl) {
            afterCompletion(imageSelector_ImagePnl.displayedImage);

            this.Close();
        }

        private void UpdateBoxes() {
            pnlImages.SuspendLayout();

            pnlImages.Controls.Clear();

            foreach (string s in Files) {
                ImageSelector_ImagePnl _is = new ImageSelector_ImagePnl();
                _is.LinkToSelector(this, s);

                pnlImages.Controls.Add(_is);
            }

            pnlImages.ResumeLayout();
        }

        private void tsImageSelector_DragDrop(object sender, DragEventArgs e) {
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
                                string nFilename = location + "/" + Path.GetFileNameWithoutExtension(filename) + ".png";

                                bool copied = false;

                                if (Path.GetFullPath(nFilename) == Path.GetFullPath(filename)) {
                                    copied = true;
                                } else if (!File.Exists(nFilename)) {
                                    File.Copy(filename, nFilename);
                                    copied = true;
                                } else if (MessageBox.Show("Overwrite " + nFilename + "?", "Overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                    File.Copy(filename, nFilename, true);
                                    copied = true;
                                }

                                if (!copied) {
                                    if (!Files.Contains(nFilename)) {
                                        Files.Add(nFilename);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            UpdateBoxes();
        }

        private void tsImageSelector_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
