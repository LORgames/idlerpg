using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.NPC;
using System.IO;
using ToolCache.General;

namespace CityTools {
    public partial class PortraitEditor : Form {
        private Portrait CurrentPortrait;

        private bool _isEdited = false;
        private bool _isNew = false;
        private bool _isCropping = false;
        private bool _isUpdating = false;

        private Rectangle CropArea = new Rectangle();

        EventHandler addedEvent;
        EventHandler removedEvent;

        public PortraitEditor() {
            InitializeComponent();

            addedEvent = new EventHandler(Portraits_ItemAdded);
            removedEvent = new EventHandler(Portraits_ItemRemoved);
            PortraitManager.Portraits.ItemAdded += addedEvent;
            PortraitManager.Portraits.ItemRemoved += removedEvent;

            UpdateForm();
        }

        void Portraits_ItemRemoved(object sender, EventArgs e) {
            listPortraits.Items.Remove(PortraitManager.Portraits[sender.ToString()]);
        }

        void Portraits_ItemAdded(object sender, EventArgs e) {
            listPortraits.Items.Add(PortraitManager.Portraits[sender.ToString()]);
        }

        private void pbDisplay_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(Color.White);

            if (CurrentPortrait != null && CurrentPortrait.Filename != "" && CurrentPortrait.Filename.Length > 3) {
                Image im = ImageCache.RequestImage(CurrentPortrait.Filename);

                e.Graphics.DrawImage(im, e.ClipRectangle);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e) {
            SaveIfRequired();
            _isNew = true;
            CurrentPortrait = new Portrait();
            UpdateForm();
        }

        private void btnDeleteSelected_Click (object sender, EventArgs e) {
            //TODO: Implement this.
            SaveIfRequired();

            List<string> keys = new List<string>();

            foreach (object o in listPortraits.SelectedItems) {
                keys.Add(o.ToString());
            }

            foreach (String s in keys) {
                PortraitManager.Portraits.Remove(s);
            }

            keys.Clear();
            keys = null;
        }

        private void PortraitEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SaveIfRequired();
            PortraitManager.SaveToBinaryIO();

            PortraitManager.Portraits.ItemAdded -= addedEvent;
            PortraitManager.Portraits.ItemRemoved -= removedEvent;
        }

        private void listPortraits_SelectedIndexChanged(object sender, EventArgs e) {
            SaveIfRequired();
            CurrentPortrait = (listPortraits.SelectedItem as Portrait);
            UpdateForm();
        }

        private void UpdateForm() {
            if (CurrentPortrait == null) {
                splitMain.Panel2.Enabled = false;
            } else {
                splitMain.Panel2.Enabled = true;
            }

            _isUpdating = true;
            txtPortraitName.Text = CurrentPortrait == null ? "" : CurrentPortrait.Name;
            pbDisplay.Invalidate();
            _isUpdating = false;
        }

        private void SaveIfRequired() {
            if (_isEdited) {
                CurrentPortrait.Name = txtPortraitName.Text;

                if (_isNew) {
                    PortraitManager.Portraits.Add(txtPortraitName.Text, CurrentPortrait);
                }
            }
        }

        private void pbDisplay_DragEnter(object sender, DragEventArgs e) {
            if (CurrentPortrait != null) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void pbDisplay_DragDrop(object sender, DragEventArgs e) {
            if (CurrentPortrait == null) {
                return;
            }

            if (!Directory.Exists("Portraits")) Directory.CreateDirectory("Portraits");

            //First put the files in the cache list
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (data != null) {
                    for (int i = 0; i < data.Length; i++) {
                        if (data.GetValue(i) is String) {
                            string filename = ((string[])data)[i];
                            string ext = Path.GetExtension(filename).ToLower();
                            if (ext == ".png") {
                                //Add animation
                                string nFilename = "Portraits/" + Path.GetFileNameWithoutExtension(filename) + ".png";

                                if (Path.GetFullPath(nFilename) == Path.GetFullPath(filename)) {
                                    //Do nothing :)
                                } else if (!File.Exists(nFilename)) {
                                    File.Copy(filename, nFilename);
                                } else if (MessageBox.Show("Overwrite " + nFilename + "?", "Overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                    File.Copy(filename, nFilename, true);
                                } else {
                                    //Keep adding _1, _2, _3 etc until we find a filename we can use.
                                    int nextFilenameAttempt = 1;
                                    while (File.Exists(nFilename)) {
                                        nFilename = "Portraits/" + Path.GetFileNameWithoutExtension(filename) + "_" + nextFilenameAttempt + ".png";
                                        nextFilenameAttempt++;
                                    }

                                    File.Copy(filename, nFilename);
                                }

                                //Now we add it to critters animations
                                CurrentPortrait.Filename = nFilename;
                                Edited();
                                ImageCache.ForceCache(nFilename);
                                LoadPortraitImage();
                            }
                        }
                    }
                }
            }
        }

        private void LoadPortraitImage() {
            pbDisplay.Invalidate();
        }

        private void Edited(object sender = null, EventArgs e = null) {
            _isEdited = true;
        }

        private void pbDisplay_MouseMove(object sender, MouseEventArgs e) {
            Cursor.Current = Cursors.SizeAll;
        }

        private void pbDisplay_MouseDown(object sender, MouseEventArgs e) {

        }

        private void pbDisplay_MouseUp(object sender, MouseEventArgs e) {

        }

        private void pbDisplay_MouseLeave(object sender, EventArgs e) {

        }
    }
}
