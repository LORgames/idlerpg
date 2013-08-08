using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ToolCache.UI;
using ToolCache.General;
using System.Drawing.Drawing2D;

namespace CityTools {
    public partial class UIEditor : Form {
        private UIElement CurrentElement = null;
        private UILayer CurrentLayer = null;

        private Image bgImage;

        private bool ElementSwitching = false;
        private bool ElementModified = false;
        private bool LayerSwitching = false;
        private bool LayerModified = false;

        public UIEditor() {
            InitializeComponent();

            if (File.Exists("UI\\Background.png")) {
                bgImage = Image.FromFile("UI\\Background.png");
            } else {
                MessageBox.Show("You can place a preview image in at '.\\UI\\Background.png' to give a better example of the UI in action. Recommended size: 1024x588px.");
                bgImage = new Bitmap(1, 1);
            }

            foreach (UIElement element in UIManager.Elements) {
                listUIElements.Items.Add(element);
            }
        }

        private void btnNewUIElement_Click(object sender, EventArgs e) {
            UIElement newElement = new UIElement();
            UIManager.Elements.Add(newElement);
            listUIElements.Items.Add(newElement);
            listUIElements.SelectedItem = newElement;
        }

        private void btnDeleteSelectedUIElements_Click(object sender, EventArgs e) {
            int x = listUIElements.SelectedItems.Count;
            while (--x > -1) {
                UIElement ui = (UIElement)listUIElements.SelectedItems[x];
                UIManager.Elements.Remove(ui);
                listUIElements.Items.Remove(ui);
            }
        }

        private void listUIElements_SelectedIndexChanged(object sender, EventArgs e) {
            SwitchElement();
        }

        private void SwitchElement() {
            SaveElementIfRequired();

            if (listUIElements.SelectedItem != null) {
                CurrentElement = (UIElement)listUIElements.SelectedItem;
                pnlUIElement.Enabled = true;

                ElementSwitching = true;
                txtUIName.Text = CurrentElement.Name;
                cbUIElementAnchor.SelectedIndex = (int)CurrentElement.AnchorPoint;
                numUIElementOffsetX.Value = (decimal)CurrentElement.OffsetX;
                numUIElementOffsetY.Value = (decimal)CurrentElement.OffsetY;
                numUIElementSizeX.Value = (decimal)CurrentElement.SizeX; 
                numUIElementSizeY.Value = (decimal)CurrentElement.SizeY;

                listUILayers.Items.Clear();
                foreach (UILayer layer in CurrentElement.Layers) {
                    listUILayers.Items.Add(layer);
                }

                ElementSwitching = false;
            } else {
                pnlUIElement.Enabled = false;
            }

            pnlUILayer.Enabled = false;
        }

        private void SwitchLayer() {
            SaveLayerIfRequired();

            if (CurrentElement != null && listUILayers.SelectedItem != null) {
                CurrentLayer = (UILayer)listUILayers.SelectedItem;
                pnlUILayer.Enabled = true;

                LayerSwitching = true;
                numLayerWidth.Value = (decimal)CurrentLayer.SizeX;
                numLayerHeight.Value = (decimal)CurrentLayer.SizeY;
                numLayerOffsetX.Value = (decimal)CurrentLayer.OffsetX;
                numLayerOffsetY.Value = (decimal)CurrentLayer.OffsetY;
                cbLayerAnchorPosition.SelectedIndex = (int)CurrentLayer.AnchorPoint;
                cbLayerType.SelectedIndex = (int)CurrentLayer.MyType;
                txtLayerName.Text = CurrentLayer.Name;

                if (CurrentLayer.ImageFilename != "") {
                    pbLayerImage.Load(CurrentLayer.ImageFilename);
                } else {
                    pbLayerImage.Image = null;
                }
                LayerSwitching = false;
            }
        }

        private void SaveLayerIfRequired() {
            if (CurrentLayer != null) {
                if (LayerModified) {
                    CurrentLayer.SizeX = (short)numLayerWidth.Value;
                    CurrentLayer.SizeY = (short)numLayerHeight.Value;
                    CurrentLayer.OffsetX = (short)numLayerOffsetX.Value;
                    CurrentLayer.OffsetY = (short)numLayerOffsetY.Value;
                    CurrentLayer.AnchorPoint = (UIAnchorPoint)cbLayerAnchorPosition.SelectedIndex;
                    CurrentLayer.MyType = (UILayerType)cbLayerType.SelectedIndex;
                    CurrentLayer.Name = txtLayerName.Text;
                }
            }
        }

        private void SaveElementIfRequired() {
            if (CurrentElement != null) {
                if (ElementModified) {
                    CurrentElement.Name = txtUIName.Text;
                    CurrentElement.AnchorPoint = (UIAnchorPoint)cbUIElementAnchor.SelectedIndex;
                    CurrentElement.OffsetX = (short)numUIElementOffsetX.Value;
                    CurrentElement.OffsetY = (short)numUIElementOffsetY.Value;
                    CurrentElement.SizeX = (short)numUIElementSizeX.Value;
                    CurrentElement.SizeY = (short)numUIElementSizeY.Value;
                }
            }
        }

        private void UIEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SaveElementIfRequired();
            UIManager.WriteDatabase();
        }

        private void UIElementValueChanged(object sender, EventArgs e) {
            if (ElementSwitching) return;
            ElementModified = true;

            SaveElementIfRequired();

            pbExample.Invalidate();
        }

        private void UILayerValueChanged(object sender, EventArgs e) {
            if (LayerSwitching) return;
            LayerModified = true;

            SaveLayerIfRequired();

            pbExample.Invalidate();
        }

        private void btnUILayerAdd_Click(object sender, EventArgs e) {
            if (CurrentElement != null) {
                UILayer newLayer = new UILayer();
                CurrentElement.Layers.Add(newLayer);
                listUILayers.Items.Add(newLayer);
                ElementModified = true;
            }
        }

        private void btnUILayerDelete_Click(object sender, EventArgs e) {
            if (CurrentElement != null) {
                int x = listUILayers.SelectedItems.Count;
                while (--x > -1) {
                    UILayer layer = (UILayer)listUILayers.SelectedItems[x];
                    CurrentElement.Layers.Remove(layer);
                    listUILayers.Items.Remove(layer);
                }
            }
        }

        private void btnLayerChangeImage_Click(object sender, EventArgs e) {
            string dir = Directory.GetCurrentDirectory();

            if(CurrentLayer != null) {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    Directory.SetCurrentDirectory(dir);

                    CurrentLayer.ImageFilename = ".\\UI\\" + Path.GetFileName(openFileDialog1.FileName);
                    File.Copy(openFileDialog1.FileName, CurrentLayer.ImageFilename, true);
                    ImageCache.ForceCache(CurrentLayer.ImageFilename);
                    pbLayerImage.Image = ImageCache.RequestImage(CurrentLayer.ImageFilename);
                    LayerModified = true;
                } else {
                    Directory.SetCurrentDirectory(dir);
                }
            }
        }

        private void listUILayers_SelectedIndexChanged(object sender, EventArgs e) {
            SwitchLayer();
        }

        private void pbExample_Paint(object sender, PaintEventArgs e) {
            float percent = (float)tbPercent.Value / 100.0f;

            e.Graphics.DrawImage(bgImage, Point.Empty);

            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;

            foreach (UIElement element in UIManager.Elements) {
                element.Draw(e.Graphics, e.ClipRectangle, percent);
            }
        }

        private void tbPercent_ValueChanged(object sender, EventArgs e) {
            pbExample.Invalidate();
        }

        private void SwapCurrentLayerBy(int delta) {
            if (CurrentElement != null && CurrentLayer != null) {
                int nDex0 = listUILayers.SelectedIndex;
                int nDex1 = nDex0 + delta;

                if (nDex1 >= 0 && nDex1 < CurrentElement.Layers.Count) {
                    CurrentElement.Layers.RemoveAt(nDex0);
                    CurrentElement.Layers.Insert(nDex1, CurrentLayer);

                    listUILayers.Items.RemoveAt(nDex0);
                    listUILayers.Items.Insert(nDex1, CurrentLayer);
                }

                pbExample.Invalidate();
            }
        }

        private void btnMoveLayerUp_Click(object sender, EventArgs e) {
            SwapCurrentLayerBy(-1);
        }

        private void btnMoveLayerDown_Click(object sender, EventArgs e) {
            SwapCurrentLayerBy(1);
        }
    }
}
