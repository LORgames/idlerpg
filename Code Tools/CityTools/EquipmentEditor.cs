using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ToolCache.Map.Tiles;
using System.IO;
using ToolCache.Drawing;
using ToolCache.Equipment;
using ToolCache.Animation;

namespace CityTools {
    public partial class EquipmentEditor : Form {
        private Direction currentDirection = Direction.Left;
        private EquipmentItem currentEquipment = new EquipmentItem();

        private Boolean _iE = false; //Is Edited
        private Boolean _new = false;
        private Boolean _updatingForm = false;

        private EquipmentItem body = EquipmentManager.TypeLists[EquipmentTypes.Body].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Body][0] : null;
        private EquipmentItem face = EquipmentManager.TypeLists[EquipmentTypes.Head].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Head][0] : null;
        private EquipmentItem head = EquipmentManager.TypeLists[EquipmentTypes.Headgear].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Headgear][0] : null;
        private EquipmentItem legs = EquipmentManager.TypeLists[EquipmentTypes.Legs].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Legs][0] : null;
        private EquipmentItem weap = EquipmentManager.TypeLists[EquipmentTypes.Weapon].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Weapon][0] : null;
        private EquipmentItem shad = EquipmentManager.TypeLists[EquipmentTypes.Shadow].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Shadow][0] : null;

        public EquipmentEditor() {
            InitializeComponent();

            Random r = new Random();

            //Add all tiles to the tile list
            cbTileList.Items.Clear();
            foreach(KeyValuePair<short, TileTemplate> kvp in TileCache.Tiles) {
                if (kvp.Value.isWalkable && kvp.Value.directionalAccess == TileTemplate.ACCESS_ALL) {
                    cbTileList.Items.Add(kvp.Value);

                    if (kvp.Value.TileName == "Grass") {
                        cbTileList.SelectedIndex = cbTileList.Items.Count - 1;
                    }
                }
            }
            

            //Add types to the equipment types
            cbItemType.Items.Clear();
            foreach(String s in Enum.GetNames(typeof(EquipmentTypes))) {
                cbItemType.Items.Add(s);
            }
            cbItemType.SelectedIndex = 0;

            //Add states to the state box thing
            cbAnimationState.Items.Clear();
            cbPreviewState.Items.Clear();
            foreach (String s in Enum.GetNames(typeof(States))) {
                cbAnimationState.Items.Add(s);
                cbPreviewState.Items.Add(s);
            }
            cbAnimationState.SelectedIndex = 0;
            cbPreviewState.SelectedIndex = 0;


            //TODO: Add Roots to treeview.
            if (!Directory.Exists("Equipment")) Directory.CreateDirectory("Equipment");
            ccAnimationBack.SetSaveLocation("Equipment");
            ccAnimationFront.SetSaveLocation("Equipment");

            ccAnimationBack.DisablePlaybackSpeed();
            ccAnimationFront.DisablePlaybackSpeed();

            CreateNew();

            RefreshTree();

            timer1.Start();
        }

        private void CreateNew() {
            SaveIfRequired();

            _new = true;
            currentEquipment = new EquipmentItem();
            UpdateForm();
        }

        private void RefreshTree() {
            treeEquipmentList.Nodes.Clear();

            foreach (EquipmentTypes s in Enum.GetValues(typeof(EquipmentTypes))) {
                TreeNode n = new TreeNode(Enum.GetName(typeof(EquipmentTypes), s));

                foreach (EquipmentItem ei in EquipmentManager.TypeLists[s]) {
                    TreeNode m = new TreeNode(ei.Name);
                    m.Tag = ei;
                    n.Nodes.Add(m);
                }

                treeEquipmentList.Nodes.Add(n);
            }

            treeEquipmentList.ExpandAll();

            cbDispBody.Items.Clear();
            cbDispFace.Items.Clear();
            cbDispHeadgear.Items.Clear();
            cbDispPants.Items.Clear();
            cbDispWeapon.Items.Clear();
            cbDispShadow.Items.Clear();

            ComboBox relCB = cbDispBody;

            cbDispBody.SuspendLayout();
            cbDispFace.SuspendLayout();
            cbDispHeadgear.SuspendLayout();
            cbDispPants.SuspendLayout();
            cbDispWeapon.SuspendLayout();
            cbDispShadow.SuspendLayout();

            foreach (KeyValuePair<EquipmentTypes, List<EquipmentItem>> kvp in EquipmentManager.TypeLists) {
                if (kvp.Key == EquipmentTypes.Body) relCB = cbDispBody;
                else if (kvp.Key == EquipmentTypes.Head) relCB = cbDispFace;
                else if (kvp.Key == EquipmentTypes.Headgear) relCB = cbDispHeadgear;
                else if (kvp.Key == EquipmentTypes.Legs) relCB = cbDispPants;
                else if (kvp.Key == EquipmentTypes.Weapon) relCB = cbDispWeapon;
                else if (kvp.Key == EquipmentTypes.Shadow) relCB = cbDispShadow;

                foreach (EquipmentItem ei in kvp.Value) {
                    relCB.Items.Add(ei.Name);
                }
            }

            if (body == null) cbDispBody.Text = EquipmentManager.TypeLists[EquipmentTypes.Body].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Body][0].Name : "";
            else cbDispBody.Text = body.Name;
            
            if (face == null) cbDispFace.Text = EquipmentManager.TypeLists[EquipmentTypes.Head].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Head][0].Name : "";
            else cbDispFace.Text = face.Name;
            
            if (head == null) cbDispHeadgear.Text = EquipmentManager.TypeLists[EquipmentTypes.Headgear].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Headgear][0].Name : "";
            else cbDispHeadgear.Text = head.Name;
            
            if (legs == null) cbDispPants.Text = EquipmentManager.TypeLists[EquipmentTypes.Legs].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Legs][0].Name : "";
            else cbDispPants.Text = legs.Name;
            
            if (weap == null) cbDispWeapon.Text = EquipmentManager.TypeLists[EquipmentTypes.Weapon].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Weapon][0].Name : "";
            else cbDispWeapon.Text = weap.Name;

            if (shad == null) cbDispShadow.Text = EquipmentManager.TypeLists[EquipmentTypes.Shadow].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Shadow][0].Name : "";
            else cbDispShadow.Text = shad.Name;

            cbDispBody.ResumeLayout();
            cbDispFace.ResumeLayout();
            cbDispHeadgear.ResumeLayout();
            cbDispPants.ResumeLayout();
            cbDispWeapon.ResumeLayout();
            cbDispShadow.ResumeLayout();
        }
        
        private void UpdateForm() {
            _updatingForm = true;

            cbItemType.Text = Enum.GetName(typeof(EquipmentTypes), currentEquipment.Type);
            txtName.Text = currentEquipment.Name;
            ckbAvailableAtStart.Checked = currentEquipment.isAvailableAtStart;

            cbAnimationState.Text = Enum.GetName(typeof(States), States.Default);

            ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[States.Default].GetAnimation(currentDirection, 0));
            ccAnimationBack.ChangeToAnimation(currentEquipment.Animations[States.Default].GetAnimation(currentDirection, 1));

            numOffsetX_0.Value = currentEquipment.OffsetX;
            numOffsetY_0.Value = currentEquipment.OffsetY;

            ckbLockOffsets.Checked = currentEquipment.OffsetsLocked;

            numAnimSpeed.Value = (decimal)currentEquipment.AnimationSpeed;

            UpdateOffsets();

            _updatingForm = false;
        }

        private void UpdateDirection() {
            lblDirection.Text = Enum.GetName(typeof(Direction), currentDirection);

            States s;

            if (!Enum.TryParse<States>(cbAnimationState.Text, out s)) {
                s = States.Default;
            }

            if (currentEquipment.Animations.ContainsKey(s)) {
                ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[s].GetAnimation(currentDirection, 0));
                ccAnimationBack.ChangeToAnimation(currentEquipment.Animations[s].GetAnimation(currentDirection, 1));
            }
        }

        private void pbEquipmentDisplay_Paint(object sender, PaintEventArgs e) {
            TileTemplate tt = cbTileList.SelectedItem as TileTemplate;

            if (tt != null) {
                for (int x = 0; x < e.ClipRectangle.Width; x += TileTemplate.PIXELS_X) {
                    for (int y = 0; y < e.ClipRectangle.Width; y += TileTemplate.PIXELS_Y) {
                        tt.Animation.Draw(e.Graphics, x, y, 1);
                    }
                }
            }

            States cState = (States)Enum.Parse(typeof(States), cbPreviewState.Text);

            //Draw 5 people :) [different directions, same gear]
            for (int i = 0; i < 4; i++) {
                Point p = new Point();
                p.X = pbEquipmentDisplay.Width / 5 * (i+1);
                p.Y = pbEquipmentDisplay.Height - 40;

                PersonDrawer.Draw(e.Graphics, p, (Direction)i, cState, shad, head, face, body, legs, weap, ckbDrawWaist.Checked);
            }
        }

        private void cbTileList_SelectedIndexChanged(object sender, EventArgs e) {
            pbEquipmentDisplay.Invalidate();
        }

        private void quickDrop_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;

            if (sender == drpDown) {
                currentDirection = Direction.Down;
            } else if (sender == drpLeft) {
                currentDirection = Direction.Left;
            } else if (sender == drpRight) {
                currentDirection = Direction.Right;
            } else if (sender == drpUp) {
                currentDirection = Direction.Up;
            }

            UpdateDirection();
        }

        private void quickDrop_DragDrop(object sender, DragEventArgs e) {
            bool layer2 = false;
            
            if ((e.KeyState & 4) == 4 && ccAnimationBack.Enabled) { //Shift=4
                layer2 = true;
            }

            Direction x = Direction.Left;

            if (sender == drpDown) x = Direction.Down;
            else if (sender == drpRight) x = Direction.Right;
            else if (sender == drpUp) x = Direction.Up;

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
                                string nFilename = "Equipment/" + Path.GetFileNameWithoutExtension(filename) + ".png";

                                bool copied = false;

                                if (Path.GetFullPath(nFilename) == Path.GetFullPath(filename)) {
                                    copied = true;
                                } else if (!File.Exists(nFilename)) {
                                    File.Copy(filename, nFilename);
                                    copied = true;
                                } else if (MessageBox.Show("Overwrite " + nFilename + "?", "Overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                    File.Copy(filename, nFilename, true);
                                    copied = true;
                                } else {
                                    //find a new name?
                                }

                                if (copied) {
                                    States selectedState = (States)Enum.Parse(typeof(States), cbAnimationState.Text);

                                    if (layer2) {
                                        currentEquipment.Animations[selectedState].GetAnimation(x, 1).Frames.Add(nFilename);
                                    } else {
                                        currentEquipment.Animations[selectedState].GetAnimation(x, 0).Frames.Add(nFilename);
                                    }

                                    if (currentDirection == x) {
                                        ccAnimationBack.UpdateBoxes();
                                        ccAnimationFront.UpdateBoxes();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e) {
            //Needs to reload things most likely

            EquipmentTypes eType;

            if (Enum.TryParse<EquipmentTypes>(cbItemType.Text, out eType)) {
                switch (eType) {
                    case EquipmentTypes.Body:
                        ccAnimationBack.Enabled = true;

                        lblFrontAnimationName.Text = "FRONT";
                        lblBackAnimationName.Text = "BACK";
                        break;
                    case EquipmentTypes.Head:
                        ccAnimationBack.Enabled = false;

                        lblFrontAnimationName.Text = "FACE";
                        lblBackAnimationName.Text = "N/A";
                        break;
                    case EquipmentTypes.Headgear:
                        ccAnimationBack.Enabled = false;

                        lblFrontAnimationName.Text = "HEADGEAR";
                        lblBackAnimationName.Text = "N/A";
                        break;
                    case EquipmentTypes.Legs:
                        ccAnimationBack.Enabled = false;

                        lblFrontAnimationName.Text = "LEGS";
                        lblBackAnimationName.Text = "N/A";
                        break;
                    case EquipmentTypes.Weapon:
                        ccAnimationBack.Enabled = true;

                        lblFrontAnimationName.Text = "FRONT";
                        lblBackAnimationName.Text = "BACK";
                        break;
                    case EquipmentTypes.Shadow:
                        ccAnimationBack.Enabled = false;

                        lblFrontAnimationName.Text = "SHADOW";
                        lblBackAnimationName.Text = "N/A";
                        break;
                }
            } else {
                cbItemType.Text = Enum.GetName(typeof(EquipmentTypes), EquipmentTypes.Body);
            }
        }

        private void ValueChanged(object sender, EventArgs e) {
            if(!_updatingForm) _iE = true;
        }

        private void cbAnimationState_SelectedIndexChanged(object sender, EventArgs e) {
            States eType;

            if (Enum.TryParse<States>(cbAnimationState.Text, out eType)) {
                ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[eType].GetAnimation(currentDirection, 0));
                ccAnimationBack.ChangeToAnimation(currentEquipment.Animations[eType].GetAnimation(currentDirection, 1));
            } else {
                cbAnimationState.Text = Enum.GetName(typeof(States), States.Default);
            }
        }

        private void cbPreviewState_SelectedIndexChanged(object sender, EventArgs e) {
            States eType;

            if (Enum.TryParse<States>(cbPreviewState.Text, out eType)) {
                pbEquipmentDisplay.Invalidate();
            } else {
                cbPreviewState.Text = Enum.GetName(typeof(States), States.Default);
            }
        }

        private void EquipmentEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SaveIfRequired();

            EquipmentManager.SaveDatabase();
        }

        private void SaveIfRequired() {
            if (!_iE) return;

            _iE = false;

            currentEquipment.isAvailableAtStart = ckbAvailableAtStart.Checked;
            currentEquipment.Name = txtName.Text;
            currentEquipment.Type = (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), cbItemType.Text);

            if (_new) EquipmentManager.AddEquipment(currentEquipment);
            else EquipmentManager.Updated(currentEquipment);
            _new = false;

            RefreshTree();
        }

        private void btnCreateNew_Click(object sender, EventArgs e) {
            CreateNew();
        }

        private void treeEquipmentList_AfterSelect(object sender, TreeViewEventArgs e) {
            EquipmentItem ei = e.Node.Tag as EquipmentItem;

            if (ei != null) {
                if (ei != currentEquipment) {
                    SaveIfRequired();
                    currentEquipment = ei;
                    _new = false;
                    UpdateForm();
                }

                if (ei.Type == EquipmentTypes.Body) cbDispBody.Text = ei.Name;
                if (ei.Type == EquipmentTypes.Head) cbDispFace.Text = ei.Name;
                if (ei.Type == EquipmentTypes.Headgear) cbDispHeadgear.Text = ei.Name;
                if (ei.Type == EquipmentTypes.Legs) cbDispPants.Text = ei.Name;
                if (ei.Type == EquipmentTypes.Weapon) cbDispWeapon.Text = ei.Name;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            pbEquipmentDisplay.Invalidate();
        }

        private void changeFullDisplay(object sender, EventArgs e) {
            body = UpdateEquipmentDisplaySetsHelper(cbDispBody.Text);
            face = UpdateEquipmentDisplaySetsHelper(cbDispFace.Text);
            head = UpdateEquipmentDisplaySetsHelper(cbDispHeadgear.Text);
            legs = UpdateEquipmentDisplaySetsHelper(cbDispPants.Text);
            weap = UpdateEquipmentDisplaySetsHelper(cbDispWeapon.Text);
            shad = UpdateEquipmentDisplaySetsHelper(cbDispShadow.Text);
        }

        private EquipmentItem UpdateEquipmentDisplaySetsHelper(string itemname) {
            if(EquipmentManager.Equipment.ContainsKey(itemname)) {
                return EquipmentManager.Equipment[itemname];
            }

            return null;
        }

        private void numOffset_ValueChanged(object sender, EventArgs e) {
            if (_updatingForm) return;

            _updatingForm = true;

            if (ckbLockOffsets.Checked) {
                currentEquipment.OffsetX = (short)numOffsetX_0.Value;
                currentEquipment.OffsetY = (short)numOffsetY_0.Value;
            } else {
                if (sender == numOffsetX_0) {
                    currentEquipment.OffsetX = (short)numOffsetX_0.Value;
                } else if (sender == numOffsetX_1) {
                    currentEquipment.OffsetX_1 = (short)numOffsetX_1.Value;
                } else if (sender == numOffsetX_2) {
                    currentEquipment.OffsetX_2 = (short)numOffsetX_2.Value;
                } else if (sender == numOffsetX_3) {
                    currentEquipment.OffsetX_3 = (short)numOffsetX_3.Value;
                } else if (sender == numOffsetY_0) {
                    currentEquipment.OffsetY = (short)numOffsetY_0.Value;
                } else if (sender == numOffsetY_1) {
                    currentEquipment.OffsetY_1 = (short)numOffsetY_1.Value;
                } else if (sender == numOffsetY_2) {
                    currentEquipment.OffsetY_2 = (short)numOffsetY_2.Value;
                } else if (sender == numOffsetY_3) {
                    currentEquipment.OffsetY_3 = (short)numOffsetY_3.Value;
                }
            }

            _updatingForm = false;

            _iE = true;
        }

        private void btnSwapAnimations_Click(object sender, EventArgs e) {
            if (ccAnimationBack.Enabled && ccAnimationFront.Enabled) {
                States eType;

                if (!Enum.TryParse<States>(cbAnimationState.Text, out eType)) {
                    return;
                }

                currentEquipment.Animations[eType].SwapAnimations(currentDirection);
                ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[eType].GetAnimation(currentDirection, 0));
                ccAnimationBack.ChangeToAnimation(currentEquipment.Animations[eType].GetAnimation(currentDirection, 1));

                _iE = true;
            }
        }

        private void ckbLockOffsets_CheckedChanged(object sender, EventArgs e) {
            if (_updatingForm) return;

            currentEquipment.OffsetsLocked = ckbLockOffsets.Checked;

            UpdateOffsets(!currentEquipment.OffsetsLocked);
        }

        private void UpdateOffsets(bool justUnlocked = false) {
            _updatingForm = true;

            if (justUnlocked) {
                currentEquipment.OffsetX_1 = currentEquipment.OffsetX;
                currentEquipment.OffsetX_2 = currentEquipment.OffsetX;
                currentEquipment.OffsetX_3 = currentEquipment.OffsetX;
                currentEquipment.OffsetY_1 = currentEquipment.OffsetY;
                currentEquipment.OffsetY_2 = currentEquipment.OffsetY;
                currentEquipment.OffsetY_3 = currentEquipment.OffsetY;
            }

            if (currentEquipment.OffsetsLocked) {
                LockOffsets(numOffsetX_1, numOffsetY_1);
                LockOffsets(numOffsetX_2, numOffsetY_2);
                LockOffsets(numOffsetX_3, numOffsetY_3);
            } else {
                UnlockOffsets(numOffsetX_1, numOffsetY_1, currentEquipment.OffsetX_1, currentEquipment.OffsetY_1);
                UnlockOffsets(numOffsetX_2, numOffsetY_2, currentEquipment.OffsetX_2, currentEquipment.OffsetY_2);
                UnlockOffsets(numOffsetX_3, numOffsetY_3, currentEquipment.OffsetX_3, currentEquipment.OffsetY_3);
            }

            _updatingForm = false;
        }

        private void LockOffsets(NumericUpDown _x, NumericUpDown _y) {
            _x.Enabled = false;
            _y.Enabled = false;

            _x.Value = 0;
            _y.Value = 0;
        }

        private void UnlockOffsets(NumericUpDown _x, NumericUpDown _y, short _x2, short _y2) {
            _x.Enabled = true;
            _y.Enabled = true;

            _x.Value = _x2;
            _y.Value = _y2;
        }

        private void rotDrp_MouseOver(object sender, EventArgs e) {
            if (sender == drpDown) {
                currentDirection = Direction.Down;
            } else if (sender == drpLeft) {
                currentDirection = Direction.Left;
            } else if (sender == drpRight) {
                currentDirection = Direction.Right;
            } else if (sender == drpUp) {
                currentDirection = Direction.Up;
            }

            UpdateDirection();
        }

        private void numAnimSpeed_ValueChanged(object sender, EventArgs e) {
            if (_updatingForm) return;

            currentEquipment.AnimationSpeed = (float)numAnimSpeed.Value;
            currentEquipment.UpdateSpeed();
        }
    }
}
