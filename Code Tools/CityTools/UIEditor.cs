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
using ToolCache.Scripting;
using ToolCache.Scripting.Types;

namespace CityTools {
    public partial class UIEditor : Form {
        private UIPanel CurrentPanel = null;
        private UIElement CurrentElement = null;
        private UILayer CurrentLayer = null;

        private Image bgImage;

        private bool PanelSwitching = false;
        private bool PanelModified = false;
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

            foreach (UIPanel panel in UIManager.Panels) {
                cbUIPanels.Items.Add(panel);
            }

            BindingList<ScriptVariable> variables = new BindingList<ScriptVariable>();

            ScriptVariable temp = new ScriptVariable();
            temp.Name = "";
            temp.Index = 0;
            temp.InitialValue = -1;
            temp.lvi = null;
            temp.TotalReferences = -1;

            variables.Add(temp);

            foreach (KeyValuePair<string, ScriptVariable> pair in GlobalVariables.Variables) {
                variables.Add(pair.Value);
            }

            cbValue.DataSource = variables;

            if(cbUIPanels.Items.Count > 0) cbUIPanels.SelectedIndex = 0;
        }

        private void btnNewUIElement_Click(object sender, EventArgs e) {
            if (CurrentPanel != null) {
                UIElement newElement = new UIElement();
                CurrentPanel.Elements.Add(newElement);
                listUIElements.Items.Add(newElement);
                listUIElements.SelectedItem = newElement;
                PanelModified = true;
            }
        }

        private void btnDeleteSelectedUIElements_Click(object sender, EventArgs e) {
            if (CurrentPanel != null) {
                int x = listUIElements.SelectedItems.Count;
                while (--x > -1) {
                    UIElement ui = (UIElement)listUIElements.SelectedItems[x];
                    CurrentPanel.Elements.Remove(ui);
                    listUIElements.Items.Remove(ui);
                }
                PanelModified = true;
            }
        }

        private void listUIElements_SelectedIndexChanged(object sender, EventArgs e) {
            SwitchElement();
        }

        private void SwitchPanel() {
            SavePanelIfRequired();

            if (cbUIPanels.SelectedItem != null && cbUIPanels.SelectedItem is UIPanel) {
                CurrentPanel = (UIPanel)cbUIPanels.SelectedItem;
                pnlUIPanel.Enabled = true;

                PanelSwitching = true;
                txtPanelName.Text = CurrentPanel.Name;

                listUIElements.Items.Clear();
                foreach (UIElement element in CurrentPanel.Elements) {
                    listUIElements.Items.Add(element);
                }
                PanelSwitching = false;
            } else {
                pnlUIPanel.Enabled = false;
            }

            pbExample.Invalidate();
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

                for (int i = 0; i < cbValue.Items.Count; i++) {
                    if (((ScriptVariable)cbValue.Items[i]).Index == CurrentLayer.GlobalVariable) {
                        cbValue.SelectedIndex = i;
                        break;
                    }
                }

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
                    CurrentLayer.GlobalVariable = ((ScriptVariable)cbValue.SelectedItem).Index;
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

        private void SavePanelIfRequired() {
            if (CurrentPanel != null) {
                if (PanelModified) {
                    CurrentPanel.Name = txtPanelName.Text;
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
            if (cbLayerType.SelectedIndex != -1) {
                if (cbLayerType.Items[cbLayerType.SelectedIndex].ToString() == "StretchToValueX" ||
                    cbLayerType.Items[cbLayerType.SelectedIndex].ToString() == "StretchToValueXNeg" ||
                    cbLayerType.Items[cbLayerType.SelectedIndex].ToString() == "StretchToValueY" ||
                    cbLayerType.Items[cbLayerType.SelectedIndex].ToString() == "StretchToValueYNeg" ||
                    cbLayerType.Items[cbLayerType.SelectedIndex].ToString() == "PanX" ||
                    cbLayerType.Items[cbLayerType.SelectedIndex].ToString() == "PanXNeg" ||
                    cbLayerType.Items[cbLayerType.SelectedIndex].ToString() == "PanY" ||
                    cbLayerType.Items[cbLayerType.SelectedIndex].ToString() == "PanYNeg") {
                    lblValue.Visible = true;
                    cbValue.Visible = true;
                } else {
                    lblValue.Visible = false;
                    cbValue.Visible = false;
                }
            }

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
                ElementModified = true;
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

            if (CurrentPanel != null) {
                foreach (UIElement element in CurrentPanel.Elements) {
                    element.Draw(e.Graphics, e.ClipRectangle, percent);
                }
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

        private void UIEditor_Activated(object sender, EventArgs e) {
            pbExample.Invalidate();
            pbLayerImage.Invalidate();
        }

        private void UIEditor_Resize(object sender, EventArgs e) {
            pbExample.Invalidate();
            pbLayerImage.Invalidate();
        }

        private void cbUIPanels_SelectedIndexChanged(object sender, EventArgs e) {
            SwitchPanel();
        }

        private void UIPanelValueChanged(object sender, EventArgs e) {
            if (PanelSwitching) return;
            PanelModified = true;

            SavePanelIfRequired();

            pbExample.Invalidate();
        }

        private void btnAddPanel_Click(object sender, EventArgs e) {
            UIPanel uip = new UIPanel();
            UIManager.AddPanel(uip);
            cbUIPanels.Items.Add(uip);
            if (cbUIPanels.Items.Count > 0) cbUIPanels.SelectedIndex = cbUIPanels.Items.Count - 1;
        }

        private void btnDelPanel_Click(object sender, EventArgs e) {
            if (cbUIPanels.SelectedItem != null && cbUIPanels.SelectedItem is UIPanel) {
                UIManager.DeletePanel(cbUIPanels.SelectedItem as UIPanel);
                cbUIPanels.Items.Remove(cbUIPanels.SelectedItem);
                if (cbUIPanels.Items.Count > 0) cbUIPanels.SelectedIndex = 0;
            }
        }
    }
}
