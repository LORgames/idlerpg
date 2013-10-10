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
using ToolCache.Scripting;
using System.Drawing.Imaging;
using ToolCache.Scripting.Extensions;

namespace CityTools {
    public partial class PortraitEditor : Form {
        private Portrait CurrentPortrait;

        private bool _isEdited = false;
        private bool _isNew = false;
        private bool _isUpdating = false;

        EventHandler addedEvent;
        EventHandler removedEvent;

        Image background;

        public PortraitEditor() {
            InitializeComponent();

            addedEvent = new EventHandler(Portraits_ItemAdded);
            removedEvent = new EventHandler(Portraits_ItemRemoved);
            PortraitManager.Portraits.ItemAdded += addedEvent;
            PortraitManager.Portraits.ItemRemoved += removedEvent;

            foreach (Portrait p in PortraitManager.Portraits.Values) {
                listPortraits.Items.Add(p);
            }

            UpdateForm();

            // Load background image
            if (File.Exists(@".\UI\background.png")) {
                background = Image.FromFile(@".\UI\background.png");
            } else {
                MessageBox.Show("Yo nigga no background image");
                background = new Bitmap(1, 1);
            }

            // Set form up
            numMarginLeft.Value = PortraitManager.MarginLeft;
            numMarginRight.Value = PortraitManager.MarginRight;
            numMarginBottom.Value = PortraitManager.MarginBottom;
            numHeight.Value = PortraitManager.Height;
            colorDialog1.Color = PortraitManager.BackgroundColour;
            numAlpha.Value = PortraitManager.Transparency;
        }

        void Portraits_ItemRemoved(object sender, EventArgs e) {
            Portrait removedPortrait = PortraitManager.Portraits[sender.ToString()];
            File.Delete(removedPortrait.Filename);
            listPortraits.Items.Remove(removedPortrait);
        }

        void Portraits_ItemAdded(object sender, EventArgs e) {
            listPortraits.Items.Add(PortraitManager.Portraits[sender.ToString()]);
        }

        private void pbDisplay_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;

            g.Clear(Color.White);

            if (CurrentPortrait != null && CurrentPortrait.Filename != "" && CurrentPortrait.Filename.Length > 3) {
                g.DrawImage(background, Point.Empty);

                Image im = ImageCache.RequestImage(CurrentPortrait.Filename);

                Rectangle r = new Rectangle(0, background.Height - im.Height, im.Width, im.Height);

                g.DrawImage(im, r);

                Rectangle textBackground = new Rectangle((int)numMarginLeft.Value, 
                    background.Height - (int)numMarginBottom.Value - (int)numHeight.Value,
                    background.Width - (int)numMarginLeft.Value - (int)numMarginRight.Value,
                    (int)numHeight.Value);

                g.DrawRectangle(new Pen(Brushes.Black), textBackground);
                g.FillRectangle(new SolidBrush(Color.FromArgb((int)numAlpha.Value, colorDialog1.Color)), textBackground);
            } else {
                g.DrawString("No portrait is available!", SystemFonts.DefaultFont, Brushes.Black, PointF.Empty);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e) {
            SaveIfRequired();
            _isNew = true;
            CurrentPortrait = new Portrait();
            UpdateForm();
        }

        private void btnDeleteSelected_Click (object sender, EventArgs e) {
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
            btnAcceptResize.Visible = false;
            _isUpdating = false;
        }

        private void SaveIfRequired() {
            if (_isEdited && txtPortraitName.Text != "") {
                CurrentPortrait.Name = txtPortraitName.Text;

                if (_isNew) {
                    PortraitManager.Portraits.Add(txtPortraitName.Text, CurrentPortrait);
                    _isNew = false;
                }
            }

            PortraitManager.MarginLeft = numMarginLeft.Value;
            PortraitManager.MarginRight = numMarginRight.Value;
            PortraitManager.MarginBottom = numMarginBottom.Value;
            PortraitManager.Height = numHeight.Value;
            PortraitManager.BackgroundColour = colorDialog1.Color;
            PortraitManager.Transparency = numAlpha.Value;
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
                                string expectedName = Variables.FixVariableName(txtPortraitName.Text);
                                string nFilename = "Portraits/" + expectedName + ".png";

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
                                        nFilename = "Portraits/" + expectedName + "_" + nextFilenameAttempt + ".png";
                                        nextFilenameAttempt++;
                                    }

                                    File.Copy(filename, nFilename);
                                }

                                // resize image to 512x512
                                Image temp = Image.FromFile(nFilename);
                                Bitmap temp2 = new Bitmap(temp, 512, 512);
                                temp.Dispose();
                                temp2.Save(nFilename, ImageFormat.Png);

                                //Now we add it to critters animations
                                CurrentPortrait.Filename = nFilename;
                                Edited();
                                ImageCache.ForceCache(nFilename);
                                pbDisplay.Invalidate();
                            }
                        }
                    }
                }
            }
        }

        private void Edited(object sender = null, EventArgs e = null) {
            if(!_isUpdating) {
                _isEdited = true;
            }
        }

        private void pbDisplay_Resize(object sender, EventArgs e) {
            pbDisplay.Invalidate();
        }

        private void numMarginLeft_ValueChanged(object sender, EventArgs e) {
            pbDisplay.Invalidate();
        }

        private void numMarginRight_ValueChanged(object sender, EventArgs e) {
            pbDisplay.Invalidate();
        }

        private void numMarginBottom_ValueChanged(object sender, EventArgs e) {
            pbDisplay.Invalidate();
        }

        private void numHeight_ValueChanged(object sender, EventArgs e) {
            pbDisplay.Invalidate();
        }

        private void pbColour_Click(object sender, EventArgs e) {

            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                pbDisplay.Invalidate();
                pbColour.Invalidate();
            }
        }

        private void pbColour_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(Color.White);

            Brush c = new SolidBrush(Color.FromArgb((int)numAlpha.Value, colorDialog1.Color));
            e.Graphics.FillRectangle(c, e.ClipRectangle);
        }

        private void numAlpha_ValueChanged(object sender, EventArgs e) {
            pbDisplay.Invalidate();
            pbColour.Invalidate();
        }
    }
}
