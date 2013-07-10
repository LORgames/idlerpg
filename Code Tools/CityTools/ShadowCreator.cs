using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ToolCache.General;

namespace CityTools {
    public partial class ShadowCreator : Form {
        private BindingList<String> FilesToShadow = new BindingList<string>();
        private BindingList<ShadowInfo> Shadows = new BindingList<ShadowInfo>();
        private bool Changing = false;

        public ShadowCreator() {
            InitializeComponent();

            listShadows.DataSource = Shadows;
            listFiles.DataSource = FilesToShadow;
        }

        private void previewBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
            e.Graphics.DrawString("Preview", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.White, PointF.Empty);

            if (listFiles.SelectedItem != null) {
                Image im = ImageCache.RequestImage(listFiles.SelectedItem as String);
                if(im != null) {
                    Point imOffset = new Point((e.ClipRectangle.Width-im.Width)/2, (e.ClipRectangle.Height-im.Height)/2);
                    DrawShadows(e.Graphics, e.ClipRectangle.Width/2, (e.ClipRectangle.Height+im.Height)/2);
                    e.Graphics.DrawImage(im, imOffset);

                    int lEdge = imOffset.X - (int)numExpandL.Value;
                    int rEdge = imOffset.X + im.Width + (int)numExpandR.Value;
                    int tEdge = imOffset.Y - (int)numExpandT.Value;
                    int bEdge = imOffset.Y + im.Height + (int)numExpandB.Value;

                    e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(0, 0, lEdge, e.ClipRectangle.Height));
                    e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(lEdge, 0, rEdge - lEdge, tEdge));
                    e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(rEdge, 0, e.ClipRectangle.Width-rEdge, e.ClipRectangle.Height));
                    e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(lEdge, bEdge, rEdge - lEdge, e.ClipRectangle.Height-bEdge));
                }
            }
        }

        private void DrawShadows(Graphics gfx, int offsetX, int offsetY) {

            foreach (ShadowInfo si in Shadows) {
                Brush shadow = new SolidBrush(Color.FromArgb(si.Alpha, si.Red, si.Green, si.Blue));
                gfx.FillEllipse(shadow, offsetX - si.Width/2 + si.OffsetX, offsetY - si.Height/2 - si.OffsetY, si.Width, si.Height);
            }
        }

        private void UpdateListBox() {
            previewBox.Invalidate();
        }

        private void ShadowCreator_DragDrop(object sender, DragEventArgs e) {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (data != null) {
                    for (int i = 0; i < data.Length; i++) {
                        if (data.GetValue(i) is String) {
                            string filename = ((string[])data)[i];
                            string ext = Path.GetExtension(filename).ToLower();
                            if (ext == ".png") {
                                FilesToShadow.Add(filename);
                            } else if (Directory.Exists(filename)) {
                                foreach (string s in Directory.GetFiles(filename, "*.png", SearchOption.AllDirectories)) {
                                    FilesToShadow.Add(s);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void ShadowCreator_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            previewBox.Invalidate();
        }

        private void btnClear_Click(object sender, EventArgs e) {
            FilesToShadow.Clear();
        }

        private void btnGenerate_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Warning, this will override all of the files above!\n\n", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                GenerateShadows();
            }
        }

        private void GenerateShadows() {
            foreach(String s in FilesToShadow) {
                Image im = ImageCache.RequestImage(s);
                Size size = im.Size;

                Graphics g2 = Graphics.FromImage(im);
                Bitmap tempBmp = new Bitmap(size.Width+(int)(numExpandL.Value+numExpandR.Value), size.Height+(int)(numExpandT.Value+numExpandB.Value), g2);
                g2.Dispose();

                Graphics gfx = Graphics.FromImage(tempBmp);

                Point imOffset = new Point((int)(numExpandL.Value), (int)(numExpandT.Value));
                DrawShadows(gfx, im.Width/2+(int)numExpandL.Value, im.Height+(int)numExpandT.Value);
                gfx.DrawImage(im, imOffset);

                gfx.Dispose();
                ImageCache.Release(s);

                Bitmap saveOut = new Bitmap(tempBmp);
                tempBmp.Dispose();

                //string testname = Path.GetDirectoryName(s) + "\\TEST_" + Path.GetFileName(s);
                saveOut.Save(s);
                saveOut.Dispose();

                ImageCache.ForceCache(s);
            }
        }

        private void listShadows_SelectedIndexChanged(object sender, EventArgs e) {
            if (listShadows.SelectedItem != null) {
                UpdateShadowInfo();
            }
        }

        private void UpdateShadowInfo() {
            Changing = true;

            if (listShadows.SelectedItems.Count == 1) {
                pnlShadowInfo.Enabled = true;
                numWidth.Value = (listShadows.SelectedItem as ShadowInfo).Width;
                numHeight.Value = (listShadows.SelectedItem as ShadowInfo).Height;
                numOffsetX.Value = (listShadows.SelectedItem as ShadowInfo).OffsetX;
                numOffsetY.Value = (listShadows.SelectedItem as ShadowInfo).OffsetY;
                numAlpha.Value = (listShadows.SelectedItem as ShadowInfo).Alpha;
                previewColor.Invalidate();
            } else {
                pnlShadowInfo.Enabled = false;
            }

            Changing = false;
        }

        private void btnClearShadows_Click(object sender, EventArgs e) {
            Shadows.Clear();
        }

        private void btnNewShadow_Click(object sender, EventArgs e) {
            ShadowInfo si = new ShadowInfo();
            Shadows.Add(si);
            listShadows.SelectedItem = si;
        }

        private void ShadowValueChanged(object sender, EventArgs e) {
            if (Changing) return;

            if (listShadows.SelectedItem != null) {
                (listShadows.SelectedItem as ShadowInfo).Width = (int)numWidth.Value;
                (listShadows.SelectedItem as ShadowInfo).Height = (int)numHeight.Value;
                (listShadows.SelectedItem as ShadowInfo).OffsetX = (int)numOffsetX.Value;
                (listShadows.SelectedItem as ShadowInfo).OffsetY = (int)numOffsetY.Value;
                (listShadows.SelectedItem as ShadowInfo).Alpha = (int)numAlpha.Value;

                previewBox.Invalidate();
            }
        }

        private void previewColor_Click(object sender, EventArgs e) {
            if (listShadows.SelectedItem != null) {
                ShadowInfo si = (listShadows.SelectedItem as ShadowInfo);
                colorDialog1.Color = Color.FromArgb(si.Red, si.Green, si.Blue);

                if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    si.Red = colorDialog1.Color.R;
                    si.Green = colorDialog1.Color.G;
                    si.Blue = colorDialog1.Color.B;
                    previewBox.Invalidate();
                    previewColor.Invalidate();
                }
            }
        }

        private void previewColor_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(Color.White);

            if (listShadows.SelectedItem != null) {
                ShadowInfo si = (listShadows.SelectedItem as ShadowInfo);
                Brush c = new SolidBrush(Color.FromArgb(si.Alpha, si.Red, si.Blue, si.Blue));
                e.Graphics.FillRectangle(c, e.ClipRectangle);
            }
        }

        private void SidesChanged(object sender, EventArgs e) {
            previewBox.Invalidate();
        }
    }

    internal class ShadowInfo {
        public int Width = 31;
        public int Height = 14;
        public int OffsetX = 0;
        public int OffsetY = 4;
        public int Alpha = 102;
        public int Red = 32;
        public int Green = 32;
        public int Blue = 32;

        public override string ToString() {
 	        return Width + "x" + Height + " @" + OffsetX + ", " + OffsetY;
        }
    }
}
