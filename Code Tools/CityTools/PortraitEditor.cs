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

namespace CityTools {
    public partial class PortraitEditor : Form {
        private Portrait CurrentPortrait;

        private const int NOTHING = 0;
        private const int CROPPING = 0;
        private const int PANNING = 0;

        private bool _isEdited = false;
        private bool _isNew = false;
        private bool _isUpdating = false;


        private int _MouseAction = NOTHING;
        private Point p0 = Point.Empty;
        private Point p1 = Point.Empty;
        private Rectangle CropArea = Rectangle.Empty;

        EventHandler addedEvent;
        EventHandler removedEvent;

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
        }

        void Portraits_ItemRemoved(object sender, EventArgs e) {
            listPortraits.Items.Remove(PortraitManager.Portraits[sender.ToString()]);
        }

        void Portraits_ItemAdded(object sender, EventArgs e) {
            listPortraits.Items.Add(PortraitManager.Portraits[sender.ToString()]);
        }

        private void pbDisplay_Paint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;

            g.Clear(Color.White);

            if (CurrentPortrait != null && CurrentPortrait.Filename != "" && CurrentPortrait.Filename.Length > 3) {
                Image im = ImageCache.RequestImage(CurrentPortrait.Filename);

                float scale = Math.Min((float)pbDisplay.DisplayRectangle.Width / im.Width, (float)pbDisplay.DisplayRectangle.Height / im.Height);
                Rectangle r = new Rectangle(0, 0, (int)(im.Width * scale), (int)(im.Height * scale));

                if(im.Width != 256 || im.Height != 512) {
                    g.DrawString("The portrait is not 256x512,\nClick and Drag on the image to select the correct area!", SystemFonts.DefaultFont, Brushes.Red, PointF.Empty);
                }

                g.DrawImage(im, r);

                if (CropArea != Rectangle.Empty) {
                    g.DrawRectangle(Pens.Red, CropArea);
                }
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
            if (_isEdited) {
                CurrentPortrait.Name = txtPortraitName.Text;

                if (_isNew) {
                    PortraitManager.Portraits.Add(txtPortraitName.Text, CurrentPortrait);
                    _isNew = false;
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
                                string expectedName = GlobalVariables.FixVariableName(CurrentPortrait.Name);
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
            _isEdited = true;
        }


        private void FixCropAreaPosition() {
            if (CropArea.Width < 0) {
                CropArea.X += CropArea.Width;
                CropArea.Width = -CropArea.Width;
            }

            if (CropArea.Height < 0) {
                CropArea.Y += CropArea.Height;
                CropArea.Height = -CropArea.Height;
            }
        }

        private void FixCropAreaSize() {
            CropArea.X = Math.Min(p0.X, p1.X);
            CropArea.Y = Math.Min(p0.Y, p1.Y);
            CropArea.Width = Math.Abs(p1.X - p0.X);
            CropArea.Height = Math.Abs(p1.Y - p0.Y);

            int difference = CropArea.Width * 2 - CropArea.Height;

            if (difference < 0) {
                //Remember is negative so subtract it.
                CropArea.X += difference / 4;
                CropArea.Width -= difference/2;
            } else {
                CropArea.Y -= difference / 2;
                CropArea.Height += difference;
            }
        }

        private void pbDisplay_MouseMove(object sender, MouseEventArgs e) {
            if (_MouseAction == CROPPING) {
                p1.X = e.X;
                p1.Y = e.Y;

                FixCropAreaSize();
                pbDisplay.Invalidate();
            }
        }

        private void pbDisplay_MouseDown(object sender, MouseEventArgs e) {
            if (CurrentPortrait != null && e.X > 0 && e.Y > 0) {
                if (_MouseAction == NOTHING && e.Button == System.Windows.Forms.MouseButtons.Left) {
                    Image im = ImageCache.RequestImage(CurrentPortrait.Filename);
                    if (im.Size.Width > 256 || im.Size.Height > 512) {
                        _MouseAction = CROPPING;

                        p0.X = e.X;
                        p0.Y = e.Y;
                        p1.X = p0.X;
                        p1.Y = p1.Y;

                        CropArea.X = e.X;
                        CropArea.Y = e.Y;
                        CropArea.Width = 0;
                        CropArea.Height = 0;

                        pbDisplay.Invalidate();
                    }
                }
            }
        }

        private void pbDisplay_MouseUp(object sender, MouseEventArgs e) {
            if (_MouseAction == CROPPING) {
                _MouseAction = NOTHING;
                btnAcceptResize.Visible = true;

                p1.X = e.X;
                p1.Y = e.Y;

                FixCropAreaSize();
                FixCropAreaPosition();
                
                ImageCache.ForceCache(CurrentPortrait.Filename);
                pbDisplay.Invalidate();
            }
        }

        private void pbDisplay_MouseLeave(object sender, EventArgs e) {
            if (_MouseAction != NOTHING) {
                _MouseAction = NOTHING;
                pbDisplay.Invalidate();
            }
        }

        private void pbDisplay_Resize(object sender, EventArgs e) {
            pbDisplay.Invalidate();
        }
    }
}
