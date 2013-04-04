using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ToolCache.Animation.Form;
using ToolCache.Map.Tiles;
using System.IO;

namespace ToolCache.Equipment {
    public partial class EquipmentEditor : Form {
        private Direction currentDirection = Direction.Left;
        private EquipmentItem currentEquipment = new EquipmentItem();

        private Boolean _iE = false; //Is Edited

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

            UpdateForm();
        }

        private void UpdateForm() {
            cbItemType.SelectedValue = currentEquipment.Type;
            txtName.Text = currentEquipment.Name;
            ckbAvailableAtStart.Checked = currentEquipment.isAvailableAtStart;

            cbAnimationState.SelectedItem = States.Default;

            ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[States.Default].GetAnimation(currentDirection, 0));
            ccAnimationFront.ChangeToAnimation(currentEquipment.Animations[States.Default].GetAnimation(currentDirection, 1));
        }

        private void UpdateDirection() {
            lblDirection.Text = Enum.GetName(typeof(Direction), currentDirection);

            States s;

            if (!Enum.TryParse<States>(cbAnimationState.SelectedText, out s)) {
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
                                }

                                if (copied) {
                                    if (layer2) {
                                        ccAnimationBack.GetAnimation().Frames.Add(nFilename);
                                    } else {
                                        ccAnimationFront.GetAnimation().Frames.Add(nFilename);
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
            _iE = true;
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
    }
}
