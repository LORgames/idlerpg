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
using ToolCache.Scripting.Extensions;

namespace CityTools {
    public partial class UIEditor : Form {
        private UIPanel CurrentPanel = null;
        private UIElement CurrentElement = null;
        private UILayer CurrentLayer = null;

        private Image bgImage;

        private bool PanelSwitching = false;
        private bool ElementSwitching = false;
        private bool LayerSwitching = false;

        public UIEditor() {
            InitializeComponent();

            if (File.Exists("UI\\Background.png")) {
                bgImage = Image.FromFile("UI\\Background.png");
            } else {
                MessageBox.Show("You can place a preview image in at '.\\UI\\Background.png' to give a better example of the UI in action. Recommended size: 1024x588px.");
                bgImage = new Bitmap(1, 1);
            }

            foreach (UIPanel panel in UIManager.Panels) {
                listUIPanels.Items.Add(panel);
            }

            BindingList<ScriptVariable> variables = new BindingList<ScriptVariable>();

            ScriptVariable temp = new ScriptVariable();
            temp.Name = "";
            temp.Index = 0;
            temp.InitialValue = -1;
            temp.lvi = null;
            temp.TotalReferences = -1;

            variables.Add(temp);

            foreach (KeyValuePair<string, ScriptVariable> pair in Variables.GlobalVariables) {
                variables.Add(pair.Value);
            }

            cbValue.DataSource = variables;
            cbUILayerLibrary.DataSource = UIManager.Libraries;

            cbTextFontFamily.DataSource = UIManager.FontNames;

            if(listUIPanels.Items.Count > 0) listUIPanels.SelectedIndex = 0;
        }

        private void btnNewUIElement_Click(object sender, EventArgs e) {
            if (CurrentPanel != null) {
                UIElement newElement = new UIElement();
                CurrentPanel.Elements.Add(newElement);
                listUIElements.Items.Add(newElement);
                listUIElements.SelectedItem = newElement;
                SavePanel();
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

                SavePanel();
            }

            pbExample.Invalidate();
        }

        private void listUIElements_SelectedIndexChanged(object sender, EventArgs e) {
            SwitchElement();
        }

        private void SwitchPanel() {
            if (listUIPanels.SelectedItem != null && listUIPanels.SelectedItem is UIPanel) {
                CurrentPanel = (UIPanel)listUIPanels.SelectedItem;
                pnlUIPanel.Enabled = true;

                PanelSwitching = true;
                txtPanelName.Text = CurrentPanel.Name;
                ckbEnabled.Checked = CurrentPanel.Enabled;

                listUIElements.Items.Clear();
                foreach (UIElement element in CurrentPanel.Elements) {
                    listUIElements.Items.Add(element, true);
                }
                PanelSwitching = false;
            } else {
                pnlUIPanel.Enabled = false;
            }

            listUILayers.Items.Clear();

            pnlUILayer.Enabled = false;
            pnlUIElement.Enabled = false;

            CurrentElement = null;
            CurrentLayer = null;

            scriptUI.Text = "";

            pbExample.Invalidate();
        }

        private void SwitchElement() {
            if (listUIElements.SelectedItem != null) {
                ElementSwitching = true;

                CurrentElement = (UIElement)listUIElements.SelectedItem;
                pnlUIElement.Enabled = true;

                txtUIName.Text = CurrentElement.Name;
                cbUIElementAnchor.SelectedIndex = (int)CurrentElement.AnchorPoint;
                numUIElementOffsetX.Value = (decimal)CurrentElement.OffsetX;
                numUIElementOffsetY.Value = (decimal)CurrentElement.OffsetY;
                numUIElementSizeX.Value = (decimal)CurrentElement.SizeX; 
                numUIElementSizeY.Value = (decimal)CurrentElement.SizeY;
                scriptUI.Script = CurrentElement.Script;

                listUILayers.Items.Clear();
                foreach (UILayer layer in CurrentElement.Layers) {
                    listUILayers.Items.Add(layer);
                }

                ElementSwitching = false;
            } else {
                CurrentElement = null;
                pnlUIElement.Enabled = false;
            }

            pnlUILayer.Enabled = false;
            CurrentLayer = null;
        }

        private void SwitchLayer() {
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

                pnlImageStuff.Visible = false;
                pnlTextStuff.Visible = false;
                pnlUILayerLibrary.Visible = false;

                if (CurrentLayer is UILayerImage) {
                    UILayerImage CurrentLayerIM = (UILayerImage)CurrentLayer;

                    for (int i = 0; i < cbValue.Items.Count; i++) {
                        if (((ScriptVariable)cbValue.Items[i]).Index == CurrentLayerIM.GlobalVariable) {
                            cbValue.SelectedIndex = i;
                            break;
                        }
                    }

                    pnlImageStuff.Visible = true;

                    if (CurrentLayerIM.ImageFilename != "UI\\" && CurrentLayerIM.ImageFilename != "") {
                        pbLayerImage.Load(CurrentLayerIM.ImageFilename);
                    } else {
                        pbLayerImage.Image = null;
                    }
                } else if (CurrentLayer is UILayerText) {
                    UILayerText CurrentLayerTX = (UILayerText)CurrentLayer;
                    txtTextMessage.Text = CurrentLayerTX.Message;

                    cbTextAlign.SelectedIndex = (int)CurrentLayerTX.Align;
                    cbTextFontFamily.SelectedIndex = CurrentLayerTX.FontFamily;
                    numTextSize.Value = CurrentLayerTX.FontSize;
                    ckbTextWordWrap.Checked = CurrentLayerTX.WordWrap;
                    cbTextInputType.SelectedIndex = CurrentLayerTX.InputType;
                    cbTextJustify.SelectedIndex = CurrentLayerTX.Justification;

                    pbTextColour.Invalidate();

                    pnlTextStuff.Visible = true;
                } else if (CurrentLayer is UILayerLibrary) {
                    UILayerLibrary CurrentLayerLI = (UILayerLibrary)CurrentLayer;

                    if (CurrentLayerLI.LibraryName == "" && UIManager.Libraries.Count > 0) {
                        CurrentLayerLI.LibraryName = UIManager.Libraries[0].Name;
                    }

                    cbUILayerLibrary.Text = CurrentLayerLI.LibraryName;
                    numUILayerLibraryIndex.Value = CurrentLayerLI.DefaultIndex;

                    pnlUILayerLibrary.Visible = true;
                } else {
                    throw new Exception("Unknown Layer TYPE!");
                }


                LayerSwitching = false;
            }

            pbLayerImage.Visible = pnlImageStuff.Visible;
        }

        private void SaveLayer() {
            if (CurrentLayer != null) {
                CurrentLayer.SizeX = (short)numLayerWidth.Value;
                CurrentLayer.SizeY = (short)numLayerHeight.Value;
                CurrentLayer.OffsetX = (short)numLayerOffsetX.Value;
                CurrentLayer.OffsetY = (short)numLayerOffsetY.Value;
                CurrentLayer.AnchorPoint = (UIAnchorPoint)cbLayerAnchorPosition.SelectedIndex;
                CurrentLayer.MyType = (UILayerType)cbLayerType.SelectedIndex;
                CurrentLayer.Name = txtLayerName.Text;

                if (CurrentLayer is UILayerImage) {
                    (CurrentLayer as UILayerImage).GlobalVariable = ((ScriptVariable)cbValue.SelectedItem).Index;
                } else if (CurrentLayer is UILayerText) {
                    (CurrentLayer as UILayerText).Message = txtTextMessage.Text;
                    (CurrentLayer as UILayerText).Align = (UIAnchorPoint)cbTextAlign.SelectedIndex; ;
                    (CurrentLayer as UILayerText).FontFamily = cbTextFontFamily.SelectedIndex;
                    (CurrentLayer as UILayerText).FontSize = (int)numTextSize.Value;
                    (CurrentLayer as UILayerText).WordWrap = ckbTextWordWrap.Checked;
                    (CurrentLayer as UILayerText).InputType = (byte)cbTextInputType.SelectedIndex;
                    (CurrentLayer as UILayerText).Justification = (byte)cbTextJustify.SelectedIndex;
                } else if (CurrentLayer is UILayerLibrary) {
                    (CurrentLayer as UILayerLibrary).LibraryName = cbUILayerLibrary.Text;
                    (CurrentLayer as UILayerLibrary).DefaultIndex = (int)numUILayerLibraryIndex.Value;
                } else {
                    throw new Exception("Unknown Layer Type!");
                }
            }
        }

        private void SaveElement() {
            if (CurrentElement != null) {
                CurrentElement.Name = txtUIName.Text;
                CurrentElement.Script = scriptUI.Script;
                CurrentElement.AnchorPoint = (UIAnchorPoint)cbUIElementAnchor.SelectedIndex;
                CurrentElement.OffsetX = (short)numUIElementOffsetX.Value;
                CurrentElement.OffsetY = (short)numUIElementOffsetY.Value;
                CurrentElement.SizeX = (short)numUIElementSizeX.Value;
                CurrentElement.SizeY = (short)numUIElementSizeY.Value;
            }
        }

        private void SavePanel() {
            if (CurrentPanel != null) {
                CurrentPanel.Name = txtPanelName.Text;
                CurrentPanel.Enabled = ckbEnabled.Checked;
            }
        }

        private void UIEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SaveElement();
            UIManager.WriteDatabase();
        }

        private void UIElementValueChanged(object sender, EventArgs e) {
            if (ElementSwitching) return;

            SaveElement();

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

            SaveLayer();

            pbExample.Invalidate();
        }

        private void btnUILayerAdd_Click(object sender, EventArgs e) {
            if (CurrentElement != null) {
                UILayerImage newLayer = new UILayerImage();
                CurrentElement.Layers.Add(newLayer);
                listUILayers.Items.Add(newLayer);
                SaveElement();
            }
        }


        private void btnUILayerAddText_Click(object sender, EventArgs e) {
            if (CurrentElement != null) {
                UILayerText newLayer = new UILayerText();
                CurrentElement.Layers.Add(newLayer);
                listUILayers.Items.Add(newLayer);

                SaveElement();
            }
        }

        private void btnUILayerAddDatabase_Click(object sender, EventArgs e) {
            if (CurrentElement != null) {
                UILayerLibrary newLayer = new UILayerLibrary();
                CurrentElement.Layers.Add(newLayer);
                listUILayers.Items.Add(newLayer);
                SaveElement();
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

                SaveElement();
            }
        }

        private void btnLayerChangeImage_Click(object sender, EventArgs e) {
            if (!(CurrentLayer is UILayerImage)) return;
            string dir = Directory.GetCurrentDirectory();

            if(CurrentLayer != null) {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    Directory.SetCurrentDirectory(dir);

                    (CurrentLayer as UILayerImage).ImageFilename = ".\\UI\\" + Path.GetFileName(openFileDialog1.FileName);
                    (CurrentLayer as UILayerImage).ImageFilename = Path.GetFullPath((CurrentLayer as UILayerImage).ImageFilename);
                    string tFN = Path.GetFullPath(openFileDialog1.FileName);

                    if (tFN != (CurrentLayer as UILayerImage).ImageFilename) {
                        File.Copy(tFN, (CurrentLayer as UILayerImage).ImageFilename, true);
                    }

                    ImageCache.ForceCache((CurrentLayer as UILayerImage).ImageFilename);
                    pbLayerImage.Image = ImageCache.RequestImage((CurrentLayer as UILayerImage).ImageFilename);

                    SaveLayer();
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

            foreach (Object x in listUIPanels.CheckedItems) {
                UIPanel p = (UIPanel)x;

                if (p != null && p != CurrentPanel) {
                    foreach (UIElement element in p.Elements) {
                        element.Draw(e.Graphics, e.ClipRectangle, percent, ckbDrawDebug.Checked);
                    }
                }
            }

            if (CurrentPanel != null) {
                foreach (Object obj in listUIElements.CheckedItems) {
                    if (obj is UIElement) {
                        (obj as UIElement).Draw(e.Graphics, e.ClipRectangle, percent, ckbDrawDebug.Checked);
                    }
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

        private void SwapCurrentElementBy(int delta) {
            if (CurrentElement != null && CurrentPanel != null) {
                int nDex0 = listUIElements.SelectedIndex;
                int nDex1 = nDex0 + delta;

                if (nDex1 >= 0 && nDex1 < CurrentPanel.Elements.Count) {
                    CurrentPanel.Elements.RemoveAt(nDex0);
                    CurrentPanel.Elements.Insert(nDex1, CurrentElement);

                    listUIElements.Items.RemoveAt(nDex0);
                    listUIElements.Items.Insert(nDex1, CurrentElement);
                }

                pbExample.Invalidate();
            }
        }

        private void btnMoveElementUp_Click(object sender, EventArgs e) {
            SwapCurrentElementBy(-1);
        }

        private void btnMoveElementDown_Click(object sender, EventArgs e) {
            SwapCurrentElementBy(1);
        }

        private void UIEditor_Activated(object sender, EventArgs e) {
            pbExample.Invalidate();
            pbLayerImage.Invalidate();
        }

        private void UIEditor_Resize(object sender, EventArgs e) {
            pbExample.Invalidate();
            pbLayerImage.Invalidate();
        }

        private void listUIPanels_SelectedIndexChanged(object sender, EventArgs e) {
            SwitchPanel();
        }

        private void UIPanelValueChanged(object sender, EventArgs e) {
            if (PanelSwitching) return;

            SavePanel();

            pbExample.Invalidate();
        }

        private void btnAddPanel_Click(object sender, EventArgs e) {
            UIPanel uip = new UIPanel();
            UIManager.AddPanel(uip);
            listUIPanels.Items.Add(uip);
            if (listUIPanels.Items.Count > 0) listUIPanels.SelectedIndex = listUIPanels.Items.Count - 1;
        }

        private void btnDelPanel_Click(object sender, EventArgs e) {
            if (listUIPanels.SelectedItem != null && listUIPanels.SelectedItem is UIPanel) {
                UIManager.DeletePanel(listUIPanels.SelectedItem as UIPanel);
                listUIPanels.Items.Remove(listUIPanels.SelectedItem);
                if (listUIPanels.Items.Count > 0) listUIPanels.SelectedIndex = 0;
            }

            pbExample.Invalidate();
        }

        private void pbTextColour_Click(object sender, EventArgs e) {
            if (CurrentLayer is UILayerText) {
                colorDialog1.Color = ((UILayerText)CurrentLayer).Colour;
                colorDialog1.ShowDialog();
                ((UILayerText)CurrentLayer).Colour = colorDialog1.Color;
                pbTextColour.Invalidate();
            }
        }

        private void pbTextColour_Paint(object sender, PaintEventArgs e) {
            if (CurrentLayer is UILayerText) {
                Color x = ((UILayerText)CurrentLayer).Colour;

                e.Graphics.Clear(x);
            }
        }

        private void ckbDrawDebug_CheckedChanged(object sender, EventArgs e) {
            pbExample.Invalidate();
        }

        private void SwapCurrentPanelBy(int delta) {
            if (CurrentPanel != null) {
                int nDex0 = listUIPanels.SelectedIndex;
                int nDex1 = nDex0 + delta;

                if (nDex1 >= 0 && nDex1 < UIManager.Panels.Count) {
                    UIManager.Panels.RemoveAt(nDex0);
                    UIManager.Panels.Insert(nDex1, CurrentPanel);

                    listUIPanels.Items.RemoveAt(nDex0);
                    listUIPanels.Items.Insert(nDex1, CurrentPanel);
                }

                pbExample.Invalidate();
            }
        }

        private void btnMoveSelectedPanelUp_Click(object sender, EventArgs e) {
            SwapCurrentPanelBy(-1);
        }

        private void btnMoveSelectedPanelDown_Click(object sender, EventArgs e) {
            SwapCurrentPanelBy(1);
        }

        private void cbResizeWidth_DropDown(object sender, EventArgs e) {
            ComboBox senderComboBox = (ComboBox)sender;

            if (senderComboBox == null) return;

            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;

            for (int i = 0; i < senderComboBox.Items.Count; i++) {
                string s = senderComboBox.Items[i].ToString();
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth) {
                    width = newWidth;
                }
            }

            senderComboBox.DropDownWidth = width;
        }

        private void listUIElements_ItemCheck(object sender, ItemCheckEventArgs e) {
            pbExample.Invalidate();
        }
    }
}
