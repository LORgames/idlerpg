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
using ToolCache.Items;

namespace CityTools {
    public partial class EquipmentEditor : Form {
        private Direction currentDirection = Direction.Left;

        private EquipmentItem _ccEQ = new EquipmentItem(true);
        private EquipmentItem currentEquipment {
            get { return _ccEQ; }
        }

        private Boolean _hasEquipmentBeenEdited = false; //Is Edited
        private Boolean _isNewEquipmentItem = false;
        private Boolean _isCurrentUpdatingForm = false;

        private EquipmentItem body = EquipmentManager.TypeLists[EquipmentTypes.Body].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Body][0] : null;
        private EquipmentItem face = EquipmentManager.TypeLists[EquipmentTypes.Head].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Head][0] : null;
        private EquipmentItem head = EquipmentManager.TypeLists[EquipmentTypes.Headgear].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Headgear][0] : null;
        private EquipmentItem legs = EquipmentManager.TypeLists[EquipmentTypes.Legs].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Legs][0] : null;
        private EquipmentItem weap = EquipmentManager.TypeLists[EquipmentTypes.Weapon].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Weapon][0] : null;
        private EquipmentItem shad = EquipmentManager.TypeLists[EquipmentTypes.Shadow].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Shadow][0] : null;

        public EquipmentEditor() {
            InitializeComponent();

            Random r = new Random();

            //Add all tiles
            FillTileBox();
            
            //Add types to the equipment types
            FillTypesBoxes();

            //Setup the animations
            SetupAnimations();

            //Prepare Script Box
            txtScript.Setup(ToolCache.Scripting.ScriptTypes.Equipment);
            txtScript.BeforeParse += new EventHandler<Components.ScriptInfoArgs>(txtScript_BeforeParse);

            CreateNew();

            RefreshTree();

            timer1.Start();
        }

        private void SetupAnimations() {
            if (!Directory.Exists("Equipment")) Directory.CreateDirectory("Equipment");
            ccAnimationBack.SetSaveLocation("Equipment");
            ccAnimationFront.SetSaveLocation("Equipment");

            ccAnimationBack.DisablePlaybackSpeed();
            ccAnimationFront.DisablePlaybackSpeed();
        }

        private void FillTypesBoxes() {
            cbItemType.Items.Clear();
            foreach (String s in Enum.GetNames(typeof(EquipmentTypes))) {
                cbItemType.Items.Add(s);
            }
            cbItemType.SelectedIndex = 0;
        }

        private void FillStateBoxes() {
            cbAnimationState.Items.Clear();
            
            foreach (String s in currentEquipment.Animations.Keys) {
                cbAnimationState.Items.Add(s);
            }

            cbAnimationState.SelectedIndex = 0;
        }

        private void FillTileBox() {
            //Add all tiles to the tile list
            cbTileList.Items.Clear();
            foreach (KeyValuePair<short, TileTemplate> kvp in TileCache.Tiles) {
                cbTileList.Items.Add(kvp.Value);

                if (kvp.Value.TileName == "Grass") {
                    cbTileList.SelectedIndex = cbTileList.Items.Count - 1;
                }
            }
        }

        private void CreateNew() {
            SaveIfRequired();

            _isNewEquipmentItem = true;

            UnlinkCurrentEquipment(new EquipmentItem(true));
            UpdateForm();
        }

        //Unlinks the current equipment AND changes to another equipment
        private void UnlinkCurrentEquipment(EquipmentItem anim) {
            currentEquipment.AnimationsChanged -= new EventHandler(anim_AnimationsChanged);

            _ccEQ = anim;

            UpdateForm();

            anim.AnimationsChanged += new EventHandler(anim_AnimationsChanged);
        }

        void anim_AnimationsChanged(object sender, EventArgs e) {
            FillStateBoxes();
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
            _isCurrentUpdatingForm = true;

            cbItemType.Text = Enum.GetName(typeof(EquipmentTypes), currentEquipment.Type);
            txtName.Text = currentEquipment.Name;
            ckbAvailableAtStart.Checked = currentEquipment.isAvailableAtStart;

            cbAnimationState.Text = "Default";

            ccAnimationFront.ChangeToAnimation(currentEquipment.Animations["Default"].GetAnimation(currentDirection, 0));
            ccAnimationBack.ChangeToAnimation(currentEquipment.Animations["Default"].GetAnimation(currentDirection, 1));

            numOffsetX_0.Value = currentEquipment.OffsetX;
            numOffsetY_0.Value = currentEquipment.OffsetY;

            ckbLockOffsets.Checked = currentEquipment.OffsetsLocked;

            numAnimSpeed.Value = (decimal)currentEquipment.AnimationSpeed;

            txtScript.Text = currentEquipment.OnAttackScript;

            UpdateOffsets();
            FillStateBoxes();

            _isCurrentUpdatingForm = false;
        }

        private void UpdateDirection() {
            lblDirection.Text = Enum.GetName(typeof(Direction), currentDirection);

            String state = cbAnimationState.Text;

            if (currentEquipment.Animations.ContainsKey(state)) {
                ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[state].GetAnimation(currentDirection, 0));
                ccAnimationBack.ChangeToAnimation(currentEquipment.Animations[state].GetAnimation(currentDirection, 1));
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

            //Draw 5 people :) [different directions, same gear]
            for (int i = 0; i < 4; i++) {
                Point p = new Point();
                p.X = pbEquipmentDisplay.Width / 5 * (i+1);
                p.Y = pbEquipmentDisplay.Height - 40;

                //Need a better way to do this with the states?
                PersonDrawer.Draw(e.Graphics, p, (Direction)i, shad, head, face, body, legs, weap, ckbDrawWaist.Checked);
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
                                    String selectedState = cbAnimationState.Text;

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
            if(!_isCurrentUpdatingForm) _hasEquipmentBeenEdited = true;
        }

        private void cbAnimationState_SelectedIndexChanged(object sender, EventArgs e) {
            ccAnimationFront.ChangeToAnimation(currentEquipment.GetAnimation(cbAnimationState.Text).GetAnimation(currentDirection, 0));
            ccAnimationBack.ChangeToAnimation(currentEquipment.GetAnimation(cbAnimationState.Text).GetAnimation(currentDirection, 1));
        }

        private void EquipmentEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SaveIfRequired();

            EquipmentManager.SaveDatabase();
        }

        private void SaveIfRequired() {
            if (!_hasEquipmentBeenEdited) return;

            _hasEquipmentBeenEdited = false;

            currentEquipment.isAvailableAtStart = ckbAvailableAtStart.Checked;
            currentEquipment.Name = txtName.Text;
            currentEquipment.Type = (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), cbItemType.Text);

            currentEquipment.OnAttackScript = txtScript.Text;

            if (_isNewEquipmentItem) EquipmentManager.AddEquipment(currentEquipment);
            else EquipmentManager.Updated(currentEquipment);
            _isNewEquipmentItem = false;

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
                    UnlinkCurrentEquipment(ei);
                    _isNewEquipmentItem = false;
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
            if (_isCurrentUpdatingForm) return;

            _isCurrentUpdatingForm = true;

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

            _isCurrentUpdatingForm = false;

            _hasEquipmentBeenEdited = true;
        }

        private void btnSwapAnimations_Click(object sender, EventArgs e) {
            if (ccAnimationBack.Enabled && ccAnimationFront.Enabled) {
                if (currentEquipment.Animations.ContainsKey(cbAnimationState.Text)) {
                    currentEquipment.Animations[cbAnimationState.Text].SwapAnimations(currentDirection);
                    ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[cbAnimationState.Text].GetAnimation(currentDirection, 0));
                    ccAnimationBack.ChangeToAnimation(currentEquipment.Animations[cbAnimationState.Text].GetAnimation(currentDirection, 1));

                    _hasEquipmentBeenEdited = true;
                }
            }
        }

        private void ckbLockOffsets_CheckedChanged(object sender, EventArgs e) {
            if (_isCurrentUpdatingForm) return;

            currentEquipment.OffsetsLocked = ckbLockOffsets.Checked;

            UpdateOffsets(!currentEquipment.OffsetsLocked);
        }

        private void UpdateOffsets(bool justUnlocked = false) {
            _isCurrentUpdatingForm = true;

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

            _isCurrentUpdatingForm = false;
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
            if (_isCurrentUpdatingForm) return;

            currentEquipment.AnimationSpeed = (float)numAnimSpeed.Value;
            currentEquipment.UpdateSpeed();
        }

        private void btnExportMany_Click(object sender, EventArgs e) {
            int width = 256;
            int height = 256;
            int charSizeX = 35;
            int charSizeY = 58;

            int totalX = (width / charSizeX);

            int offsetX = (width - (totalX * charSizeX)) / 2;
            int offsetY = 60;

            LBuffer buffer = new LBuffer(new Size(width, height));

            int i = 28;

            EquipmentItem shadow = EquipmentManager.TypeLists[EquipmentTypes.Shadow][0];
            EquipmentItem legs = EquipmentManager.TypeLists[EquipmentTypes.Legs][0];

            Random r = new Random();

            while (--i > -1) {
                int id = r.Next(EquipmentManager.TypeLists[EquipmentTypes.Head].Count);
                EquipmentItem face = EquipmentManager.TypeLists[EquipmentTypes.Head][id];

                id = r.Next(EquipmentManager.TypeLists[EquipmentTypes.Body].Count);
                EquipmentItem body = EquipmentManager.TypeLists[EquipmentTypes.Body][id];

                id = r.Next(EquipmentManager.TypeLists[EquipmentTypes.Headgear].Count);
                EquipmentItem head = EquipmentManager.TypeLists[EquipmentTypes.Headgear][id];

                id = r.Next(EquipmentManager.TypeLists[EquipmentTypes.Weapon].Count);
                EquipmentItem weapon = EquipmentManager.TypeLists[EquipmentTypes.Weapon][id];

                int xPos = charSizeX * (i % totalX) + (charSizeX / 2) + offsetX;
                int yPos = charSizeY * (i / totalX) + offsetY;

                Direction d = (Direction)r.Next(4);

                PersonDrawer.Draw(buffer.gfx, new Point(xPos, yPos), d, shadow, head, face, body, legs, weapon, false);
            }

            buffer.gfx.Dispose();
            buffer.bmp.Save("Characters.png");
            buffer.Dispose();
        }

        private void cbAnimationState_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                cbAnimationState_SelectedIndexChanged(sender, e);
            }
        }

        void txtScript_BeforeParse(object sender, Components.ScriptInfoArgs e) {
            e.Info.AnimationNames.AddRange(currentEquipment.Animations.Keys);
        }

        private void btnCreateAsItem_Click(object sender, EventArgs e) {
            SaveIfRequired();

            Item i = new Item();

            i.ID = ItemDatabase.NextItemID;
            i.Name = currentEquipment.Name;
            i.Category = currentEquipment.Type.ToString();
            i.Description = "An amazing " + i.Name;
            i.MaxInStack = 1;
            i.ConsumeEffect = "Use\n\tequip " + i.Name + "\n";

            if (currentEquipment.GetAnimation("Default").GetAnimation(Direction.Down, 0).Frames.Count > 0) {
                Image temp = Image.FromFile(currentEquipment.GetAnimation("Default").GetAnimation(Direction.Down, 0).Frames[0]);

                if (temp != null) {
                    Bitmap bmp = new Bitmap(48, 48);
                    Graphics g = Graphics.FromImage(bmp);

                    g.DrawImage(temp, 0, 0, 48, 48);
                    g.Dispose();

                    Bitmap clone = new Bitmap(bmp);
                    bmp.Dispose();

                    clone.Save("Icons/" + i.Name + ".png");

                    i.IconName = "Icons/" + i.Name + ".png";
                }
            }

            ItemDatabase.AddItem(i);
            ItemDatabase.SaveDatabase();
        }
    }
}
