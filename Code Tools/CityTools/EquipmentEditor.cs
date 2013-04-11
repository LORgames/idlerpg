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

namespace CityTools {
    public partial class EquipmentEditor : Form {
        private Direction currentDirection = Direction.Left;
        private EquipmentItem currentEquipment = new EquipmentItem();

        private Boolean _iE = false; //Is Edited
        private Boolean _new = false;
        private Boolean _updatingForm = false;

        private EquipmentItem body = EquipmentManager.TypeLists[EquipmentTypes.Body].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Body][0] : null;
        private EquipmentItem face = EquipmentManager.TypeLists[EquipmentTypes.Face].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Face][0] : null;
        private EquipmentItem head = EquipmentManager.TypeLists[EquipmentTypes.Hat].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Hat][0] : null;
        private EquipmentItem legs = EquipmentManager.TypeLists[EquipmentTypes.Legs].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Legs][0] : null;
        private EquipmentItem weap = EquipmentManager.TypeLists[EquipmentTypes.Weapon].Count > 0 ? EquipmentManager.TypeLists[EquipmentTypes.Weapon][0] : null;

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
            foreach (String s in Enum.GetNames(typeof(States))) {
                cbAnimationState.Items.Add(s);
            }
            cbAnimationState.SelectedIndex = 0;

            //TODO: Add Roots to treeview.
            if (!Directory.Exists("Equipment")) Directory.CreateDirectory("Equipment");

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

            ComboBox relCB = cbDispBody;

            foreach (KeyValuePair<EquipmentTypes, List<EquipmentItem>> kvp in EquipmentManager.TypeLists) {
                if (kvp.Key == EquipmentTypes.Body) relCB = cbDispBody;
                else if (kvp.Key == EquipmentTypes.Face) relCB = cbDispFace;
                else if (kvp.Key == EquipmentTypes.Hat) relCB = cbDispHeadgear;
                else if (kvp.Key == EquipmentTypes.Legs) relCB = cbDispPants;
                else if (kvp.Key == EquipmentTypes.Weapon) relCB = cbDispWeapon;

                foreach (EquipmentItem ei in kvp.Value) {
                    relCB.Items.Add(ei.Name);
                }
            }
        }
        
        private void UpdateForm() {
            _updatingForm = true;

            cbItemType.Text = Enum.GetName(typeof(EquipmentTypes), currentEquipment.Type);
            txtName.Text = currentEquipment.Name;
            ckbAvailableAtStart.Checked = currentEquipment.isAvailableAtStart;

            cbAnimationState.Text = Enum.GetName(typeof(States), States.Default);

            ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[States.Default].GetAnimation(currentDirection, 0));
            ccAnimationBack.ChangeToAnimation(currentEquipment.Animations[States.Default].GetAnimation(currentDirection, 1));

            pbSetupLinks.Invalidate();
            
            _updatingForm = false;
        }

        private void UpdateDirection() {
            lblDirection.Text = Enum.GetName(typeof(Direction), currentDirection);

            States s;

            if (!Enum.TryParse<States>(cbAnimationState.Text, out s)) {
                s = States.Default;
            }

            if (currentEquipment.Animations.ContainsKey(s)) {
                ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[s].GetAnimation(currentDirection, 0), FilenamePrefix(currentDirection));
                ccAnimationBack.ChangeToAnimation(currentEquipment.Animations[s].GetAnimation(currentDirection, 1), FilenamePrefix(currentDirection));
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

            States cState = (States)Enum.Parse(typeof(States), cbAnimationState.Text);

            //Draw 5 people :) [different directions, same gear]
            for (int i = 0; i < 4; i++) {
                Point p = new Point();
                p.X = pbEquipmentDisplay.Width / 5 * (i+1);
                p.Y = pbEquipmentDisplay.Height - 20;

                PersonDrawer.Draw(e.Graphics, p, (Direction)i, cState, head, face, body, legs, weap);
            }
        }

        private void pbSetupLinks_Paint(object sender, PaintEventArgs e) {
            TileTemplate tt = cbTileList.SelectedItem as TileTemplate;

            if (tt != null) {
                for (int x = 0; x < e.ClipRectangle.Width; x += TileTemplate.PIXELS_X) {
                    for (int y = 0; y < e.ClipRectangle.Width; y += TileTemplate.PIXELS_Y) {
                        tt.Animation.Draw(e.Graphics, x, y, 1);
                    }
                }
            }

            States cState = (States)Enum.Parse(typeof(States), cbAnimationState.Text);
            EquipmentTypes cType = (EquipmentTypes)Enum.Parse(typeof(EquipmentTypes), cbItemType.Text);

            Point centerPoint = new Point(pbSetupLinks.DisplayRectangle.Width / 2, pbSetupLinks.DisplayRectangle.Height / 2);
            
            Point layer0_center = currentEquipment.Animations[cState].GetAnimation(currentDirection, 0).Center;
            Point layer1_center = currentEquipment.Animations[cState].GetAnimation(currentDirection, 1).Center;

            Point drawLayer0At = Point.Empty;
            drawLayer0At.X = centerPoint.X - layer0_center.X;
            drawLayer0At.Y = centerPoint.Y - layer0_center.Y;

            Point drawLayer1At = Point.Empty;
            drawLayer1At.X = centerPoint.X - layer1_center.X;
            drawLayer1At.Y = centerPoint.Y - layer1_center.Y;

            if (cType == EquipmentTypes.Legs) {
                Point p = currentEquipment.GetLinkDown(currentDirection);

                drawLayer1At.X += p.X - layer0_center.X;
                drawLayer1At.Y += p.Y - layer0_center.Y;

                currentEquipment.Animations[cState].GetAnimation(currentDirection, 1).Draw(e.Graphics, drawLayer1At.X, drawLayer1At.Y, 1);
            } else {
                currentEquipment.Animations[cState].GetAnimation(currentDirection, 1).Draw(e.Graphics, drawLayer1At.X, drawLayer1At.Y, 1);
            }

            currentEquipment.Animations[cState].GetAnimation(currentDirection, 0).Draw(e.Graphics, drawLayer0At.X, drawLayer0At.Y, 1);

            e.Graphics.FillEllipse(Brushes.Yellow, new Rectangle(currentEquipment.GetLinkUp(currentDirection).X - 1 + drawLayer0At.X, currentEquipment.GetLinkUp(currentDirection).Y - 1 + drawLayer0At.Y, 3, 3));
            e.Graphics.FillEllipse(Brushes.Blue, new Rectangle(currentEquipment.GetLinkDown(currentDirection).X - 1 + drawLayer0At.X, currentEquipment.GetLinkDown(currentDirection).Y - 1 + drawLayer0At.Y, 3, 3));
        }

        private void cbTileList_SelectedIndexChanged(object sender, EventArgs e) {
            pbEquipmentDisplay.Invalidate();
            pbSetupLinks.Invalidate();
        }

        private void quickDrop_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
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
                                string nFilename = "Equipment/" + FilenamePrefix(x) + Path.GetFileNameWithoutExtension(filename) + ".png";

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

        private string FilenamePrefix(Direction x) {
            if (x == Direction.Left) {
                return "L_";
            } else if (x == Direction.Right) {
                return "R_";
            } else if (x == Direction.Up) {
                return "U_";
            } else if (x == Direction.Down) {
                return "D_";
            }

            return "X_";
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e) {
            //Needs to reload things most likely

            EquipmentTypes eType;

            if (Enum.TryParse<EquipmentTypes>(cbItemType.Text, out eType)) {
                switch (eType) {
                    case EquipmentTypes.Body:
                        ccAnimationBack.Enabled = true;

                        lblFrontAnimationName.Text = "BACK";
                        lblBackAnimationName.Text = "FRONT";
                        break;
                    case EquipmentTypes.Face:
                        ccAnimationBack.Enabled = false;

                        lblFrontAnimationName.Text = "FACE";
                        lblBackAnimationName.Text = "N/A";
                        break;
                    case EquipmentTypes.Hat:
                        ccAnimationBack.Enabled = false;

                        lblFrontAnimationName.Text = "HEADGEAR";
                        lblBackAnimationName.Text = "N/A";
                        break;
                    case EquipmentTypes.Legs:
                        ccAnimationBack.Enabled = true;

                        lblFrontAnimationName.Text = "LEGS";
                        lblBackAnimationName.Text = "SHADOW";
                        break;
                    case EquipmentTypes.Weapon:
                        ccAnimationBack.Enabled = true;

                        lblFrontAnimationName.Text = "FRONT";
                        lblBackAnimationName.Text = "BACK";
                        break;
                }
            } else {
                cbItemType.Text = Enum.GetName(typeof(EquipmentTypes), EquipmentTypes.Body);
            }
        }

        private void btnRotLeft_Click(object sender, EventArgs e) {
            switch (currentDirection) {
                case Direction.Left:
                    currentDirection = Direction.Up;
                    break;
                case Direction.Right:
                    currentDirection = Direction.Down;
                    break;
                case Direction.Up:
                    currentDirection = Direction.Right;
                    break;
                case Direction.Down:
                    currentDirection = Direction.Left;
                    break;
            }

            UpdateDirection();
        }

        private void btnRotRight_Click(object sender, EventArgs e) {
            switch (currentDirection) {
                case Direction.Left:
                    currentDirection = Direction.Down;
                    break;
                case Direction.Right:
                    currentDirection = Direction.Up;
                    break;
                case Direction.Up:
                    currentDirection = Direction.Left;
                    break;
                case Direction.Down:
                    currentDirection = Direction.Right;
                    break;
            }

            UpdateDirection();
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
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            pbSetupLinks.Invalidate();
            pbEquipmentDisplay.Invalidate();
        }

        private void pbSetupLinks_Click(object sender, EventArgs _e) {
            MouseEventArgs e = (MouseEventArgs)_e;

            States cState = (States)Enum.Parse(typeof(States), cbAnimationState.Text);

            Point p;

            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p = currentEquipment.GetLinkUp(currentDirection);
            } else {
                p = currentEquipment.GetLinkDown(currentDirection);
            }

            Point layer0_drawPoint = new Point(pbSetupLinks.DisplayRectangle.Width / 2, pbSetupLinks.DisplayRectangle.Height / 2);
            Point layer0_center = currentEquipment.Animations[cState].GetAnimation(currentDirection, 0).Center;

            Point m = Point.Empty;
            m.X = e.X - layer0_drawPoint.X + layer0_center.X;
            m.Y = e.Y - layer0_drawPoint.Y + layer0_center.Y;

            if ((ModifierKeys & Keys.Control) == Keys.Control) {
                int dX = Math.Abs(m.X - p.X);
                int dY = Math.Abs(m.Y - p.Y);

                if (dX > dY) {
                    if (m.X < p.X) p.X--;
                    if (m.X > p.X) p.X++;
                } else {
                    if (m.Y < p.Y) p.Y--;
                    if (m.Y > p.Y) p.Y++;
                }
            } else {
                p.X = m.X;
                p.Y = m.Y;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                currentEquipment.SetLinkUp(currentDirection, p);
            } else {
                currentEquipment.SetLinkDown(currentDirection, p);
            }
        }

        private void changeFullDisplay(object sender, EventArgs e) {
            body = UpdateEquipmentDisplaySetsHelper(cbDispBody.Text);
            face = UpdateEquipmentDisplaySetsHelper(cbDispFace.Text);
            head = UpdateEquipmentDisplaySetsHelper(cbDispHeadgear.Text);
            legs = UpdateEquipmentDisplaySetsHelper(cbDispPants.Text);
            weap = UpdateEquipmentDisplaySetsHelper(cbDispWeapon.Text);
        }

        private EquipmentItem UpdateEquipmentDisplaySetsHelper(string itemname) {
            if(EquipmentManager.Equipment.ContainsKey(itemname)) {
                return EquipmentManager.Equipment[itemname];
            }

            return null;
        }
    }
}
