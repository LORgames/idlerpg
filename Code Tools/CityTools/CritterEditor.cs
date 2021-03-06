﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Critters;
using CityTools.Properties;
using ToolCache.Items;
using ToolCache.Equipment;
using ToolCache.Drawing;
using System.IO;
using ToolCache.Map.Regions;
using ToolCache.Animation;
using ToolCache.General;

namespace CityTools {
    public partial class CritterEditor : Form {
        private Critter critter;
        private Direction direction = Direction.Left;

        private Boolean _isCritterEdited = false; //Is Edited
        private Boolean _isNewCritter = false;
        private Boolean _isUpdatingForm = false;

        private Dictionary<string, TreeNode> GroupNodes = new Dictionary<string, TreeNode>();

        public CritterEditor() {
            InitializeComponent();

            treeAllCritters.ImageList = new ImageList();
            treeAllCritters.ImageList.Images.Add(Resources.Humanoid);
            treeAllCritters.ImageList.Images.Add(Resources.Monster);

            ccBeastAnimations.SetSaveLocation("Critters");
            ccBeastAnimations.DisablePlaybackSpeed();

            sptFullForm.Panel2.Enabled = false;

            FillAITypes();
            FillItemBox();
            FillGroups();
            FillEquipmentBoxes();

            FillTree();
        }

        private void FillTree() {
            treeAllCritters.Nodes.Clear();
            GroupNodes.Clear();
            cbBaseGroup.Items.Clear();

            foreach (Critter c in CritterManager.Critters.Values) {
                //Create this critters node
                TreeNode node = new TreeNode(c.Name);

                node.ImageIndex = (int)c.CritterType;
                node.SelectedImageIndex = (int)c.CritterType;

                node.Tag = c;

                c.EditorNode = node;

                //Add the group node if it doesn't exist yet
                if (!GroupNodes.ContainsKey(c.NodeGroup)) {
                    GroupNodes.Add(c.NodeGroup, new TreeNode(c.NodeGroup));
                    treeAllCritters.Nodes.Add(GroupNodes[c.NodeGroup]);
                    GroupNodes[c.NodeGroup].Expand();
                    cbBaseGroup.Items.Add(c.NodeGroup);
                }

                //Yay theres a node now?
                GroupNodes[c.NodeGroup].Nodes.Add(node);
            }
        }

        private void FillGroups() {
            cbAddGroup.Items.Clear();

            foreach (String s in Factions.FactionNames()) {
                cbAddGroup.Items.Add(s);
            }
        }

        private void FillItemBox() {
            cbItemList.SuspendLayout();
            cbItemList.Items.Clear();

            foreach (Item i in ItemDatabase.Items) {
                cbItemList.Items.Add(i);
            }

            cbItemList.ResumeLayout();
        }

        private void FillAITypes() {
            foreach (AITypes ai in Enum.GetValues(typeof(AITypes))) {
                cbAITypes.Items.Add(ai);
            }
        }

        private void FillEquipmentBoxes() {
            EquipmentTypes[] types = { EquipmentTypes.Shadow, EquipmentTypes.Legs, EquipmentTypes.Body, EquipmentTypes.Head, EquipmentTypes.Headgear, EquipmentTypes.Weapon };
            ComboBox[] boxes = { cbHumanoidShadow, cbHumanoidPants, cbHumanoidBody, cbHumanoidFace, cbHumanoidHeadgear, cbHumanoidWeapon };

            if (types.Length == boxes.Length) {
                for (int i = 0; i < types.Length; i++) {
                    boxes[i].Items.AddRange(EquipmentManager.TypeLists[types[i]].ToArray());
                }
            } else {
                MessageBox.Show("CritterEditor.FillEquipmentBoxes() Hard code error: Types != Boxes.");
            }
        }

        private void CritterEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SaveIfRequired();

            CritterManager.SaveDatabase();
            Factions.SaveDatabase();
        }

        void listLoot_SubItemEndEditing(object sender, Components.SubItemEndEditingEventArgs e) {
            e.DisplayText = (e.Item.Tag as LootDrop).UpdateFromListView(e.Item, e.SubItem, e.DisplayText);
            _isCritterEdited = true;
        }

        void listLoot_SubItemClicked(object sender, Components.SubItemEventArgs e) {
            if (e.SubItem > 0) {
                if (e.SubItem == 1 || e.SubItem == 2) { //min and max numbers
                    numListViewHidden.DecimalPlaces = 0;
                    numListViewHidden.Minimum = 1;
                    numListViewHidden.Maximum = 255;
                    numListViewHidden.Increment = 1;
                } else if (e.SubItem == 3) { // Percentage chance
                    numListViewHidden.DecimalPlaces = 2;
                    numListViewHidden.Minimum = 0.01M;
                    numListViewHidden.Maximum = 100;
                    numListViewHidden.Increment = 5;
                } else if (e.SubItem == 4) { // set
                    numListViewHidden.DecimalPlaces = 0;
                    numListViewHidden.Minimum = 0;
                    numListViewHidden.Maximum = 255;
                    numListViewHidden.Increment = 1;
                }

                listLoot.StartEditing(numListViewHidden, e.Item, e.SubItem);
            }
        }

        private void PopulateLootList() {
            if (critter != null) {
                listLoot.SuspendLayout();

                listLoot.Items.Clear();

                foreach (LootDrop loot in critter.Loot) {
                    listLoot.Items.Add(loot.GetListViewItem());
                }

                listLoot.ResumeLayout();
            }
        }

        private void btnCreateHumanoidCritter_Click(object sender, EventArgs e) {
            SaveIfRequired();

            critter = new CritterHuman();
            _isNewCritter = true;
            _isCritterEdited = false;

            UpdateForm();
        }

        private void btnCreateBeastCritter_Click(object sender, EventArgs e) {
            SaveIfRequired();

            critter = new CritterBeast();
            _isNewCritter = true;
            _isCritterEdited = false;

            UpdateForm();
        }

        private void UpdateForm() {
            _isUpdatingForm = true;

            //Fill in the boxes
            txtMonsterName.Text = critter.Name;

            numExperience.Value = critter.ExperienceGain;
            numHealth.Value = critter.Health;
            numDefence.Value = critter.Defense;

            ckbOneOfAKind.Checked = critter.OneOfAKind;
            cbBaseGroup.Text = critter.NodeGroup;

            numMovementSpeed.Value = critter.MovementSpeed;
            numRange.Value = critter.AlertRange;
            numAttackRange.Value = critter.AttackRange;

            txtScript.Script = critter.AICommands;

            //Now we do groups
            listGroups.Items.Clear();
            listGroups.Items.AddRange(critter.Groups.ToArray());

            //Now we do AI (much more complex);
            listAIType.Items.Clear();

            int i = 32;
            while (--i > -1) {
                if ((critter.AIType & (0x1 << i)) > 0) {
                    
                    listAIType.Items.Add((AITypes)(0x1 << i));
                }
            }

            //Now we do the humanoid things
            if (critter.CritterType == CritterTypes.Humanoid) {
                CritterHuman human = (critter as CritterHuman);
                cbHumanoidShadow.Text = human.Shadow;
                cbHumanoidPants.Text = human.Legs;
                cbHumanoidBody.Text = human.Body;
                cbHumanoidFace.Text = human.Face;
                cbHumanoidHeadgear.Text = human.Headgear;
                cbHumanoidWeapon.Text = human.Weapon;

                pbPreviewDisplay.Invalidate();

                pnlHumanoid.Visible = true;
                pnlBeast.Visible = false;

                numBeastFPS.Value = (decimal)0.2;
                numBeastRectWidth.Value = 0;
                numBeastRectHeight.Value = 0;

                ccBeastAnimations.ClearAnimation();
                cbBeastState.Text = "";

                cbBeastState.Items.Clear();
            } else {
                CritterBeast beast = (critter as CritterBeast);
                cbBeastState.Text = "Default";
                ccBeastAnimations.ChangeToAnimation(beast.GetAnimation("Default").GetDirection(direction));
                numBeastFPS.Value = (decimal)beast.playbackSpeed;
                numBeastRectWidth.Value = (decimal)beast.rectWidth;
                numBeastRectHeight.Value = (decimal)beast.rectHeight;
                numBeastOffsetX.Value = (decimal)beast.rectOffsetX;
                numBeastOffsetY.Value = (decimal)beast.rectOffsetY;
                numBeastHeadHeight.Value = (decimal)beast.headHeight;

                cbBeastState.Items.Clear();

                foreach(String s in beast.AnimationNames()) {
                    cbBeastState.Items.Add(s);
                }

                pnlBeast.Visible = true;
                pnlHumanoid.Visible = false;

                cbHumanoidShadow.Text = "";
                cbHumanoidPants.Text = "";
                cbHumanoidBody.Text = "";
                cbHumanoidFace.Text = "";
                cbHumanoidHeadgear.Text = "";
                cbHumanoidWeapon.Text = "";
                pbPreviewDisplay.Invalidate();
            }

            PopulateLootList();

            sptFullForm.Panel2.Enabled = true;

            if (critter is CritterHuman) {
                pnlBeast.Enabled = false;
                pnlHumanoid.Enabled = true;
            } else {
                pnlBeast.Enabled = true;
                pnlHumanoid.Enabled = false;
            }

            _isUpdatingForm = false;
        }

        private void SaveIfRequired() {
            if (!_isCritterEdited) return;

            //Set the critter information
            critter.Name = txtMonsterName.Text;
            critter.ExperienceGain = (int)numExperience.Value;
            critter.Health = (int)numHealth.Value;
            critter.Defense = (int)numDefence.Value;
            critter.OneOfAKind = ckbOneOfAKind.Checked;

            critter.MovementSpeed = (short)numMovementSpeed.Value;
            critter.AlertRange = (short)numRange.Value;
            critter.AttackRange = (short)numAttackRange.Value;

            critter.NodeGroup = cbBaseGroup.Text;
            critter.AICommands = txtScript.Script;

            //Update the critters nodes
            if (critter.EditorNode == null) {
                //Create this critters node
                TreeNode node = new TreeNode(critter.Name);
                node.ImageIndex = (int)critter.CritterType;
                node.Tag = critter;

                critter.EditorNode = node;
            } else {
                critter.EditorNode.Name = critter.Name;
            }

            //Double check its group exists as well
            if (!GroupNodes.ContainsKey(critter.NodeGroup)) {
                GroupNodes.Add(critter.NodeGroup, new TreeNode(critter.NodeGroup));
                treeAllCritters.Nodes.Add(GroupNodes[critter.NodeGroup]);
                GroupNodes[critter.NodeGroup].Expand();
            }

            //Now double check the critter is in the right group
            if (critter.EditorNode.Parent != GroupNodes[critter.NodeGroup]) {
                if (critter.EditorNode.Parent != null) {
                    critter.EditorNode.Parent.Nodes.Remove(critter.EditorNode);
                }

                GroupNodes[critter.NodeGroup].Nodes.Add(critter.EditorNode);
            }

            //Add the groups to the critter
            critter.Groups.Clear();
            foreach (string o in listGroups.Items) critter.Groups.Add(o);

            //Add the AI types of the critter
            critter.AIType = 0;
            foreach (AITypes ai in listAIType.Items) {
                critter.AIType |= (int)ai;
            }

            //Set the humanoid things
            if (critter.CritterType == CritterTypes.Humanoid) {
                CritterHuman human = critter as CritterHuman;
                human.Shadow = (cbHumanoidShadow.SelectedItem is EquipmentItem) ? cbHumanoidShadow.Text : "";
                human.Legs = (cbHumanoidPants.SelectedItem is EquipmentItem) ? cbHumanoidPants.Text : "";
                human.Body = (cbHumanoidBody.SelectedItem is EquipmentItem) ? cbHumanoidBody.Text : "";
                human.Face = (cbHumanoidFace.SelectedItem is EquipmentItem) ? cbHumanoidFace.Text : "";
                human.Headgear = (cbHumanoidHeadgear.SelectedItem is EquipmentItem) ? cbHumanoidHeadgear.Text : "";
                human.Weapon = (cbHumanoidWeapon.SelectedItem is EquipmentItem) ? cbHumanoidWeapon.Text : "";
            } else {
                CritterBeast beast = critter as CritterBeast;
                beast.playbackSpeed = (float)numBeastFPS.Value;
                beast.rectWidth = (short)numBeastRectWidth.Value;
                beast.rectHeight = (short)numBeastRectHeight.Value;
                beast.rectOffsetX = (short)numBeastOffsetX.Value;
                beast.rectOffsetY = (short)numBeastOffsetY.Value;
                beast.headHeight = (short)numBeastHeadHeight.Value;
            }

            if (_isNewCritter) {
                CritterManager.AddCritter(critter);
            } else {
                CritterManager.UpdatedCritter(critter);
            }

            _isNewCritter = false;
            _isCritterEdited = false;
        }

        private void btnAddLoot_Click(object sender, EventArgs e) {
            if (cbItemList.SelectedItem is Item) {
                LootDrop loot = LootDrop.GenerateEmpty(cbItemList.SelectedItem as Item);

                critter.Loot.Add(loot);

                listLoot.Items.Add(loot.GetListViewItem());
                _isCritterEdited = true;
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e) {
            if (cbAddGroup.Text.Length > 2) {
                if (!Factions.Has(cbAddGroup.Text)) {
                    Factions.AddFaction(cbAddGroup.Text);
                    cbAddGroup.Items.Add(cbAddGroup.Text);
                }

                if (!listGroups.Items.Contains(cbAddGroup.Text)) {
                    listGroups.Items.Add(cbAddGroup.Text);
                }

                _isCritterEdited = true;
            }
        }

        private void btnAddAIType_Click(object sender, EventArgs e) {
            if (cbAITypes.SelectedItem is AITypes) {
                if (!listAIType.Items.Contains(cbAITypes.SelectedItem)) {
                    listAIType.Items.Add(cbAITypes.SelectedItem);
                }
                _isCritterEdited = true;
            }
        }

        private void pbPreviewDisplay_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(Color.Beige);
            e.Graphics.DrawString("Preview: Final FPS Will Differ", new Font("Verdana", 10), Brushes.Black, Point.Empty);

            if (critter is CritterHuman) {
                PersonDrawer.Draw(e.Graphics, new Point(e.ClipRectangle.Width / 2, e.ClipRectangle.Height - 20), Direction.Down,
                    cbHumanoidShadow.SelectedItem as EquipmentItem,
                    cbHumanoidHeadgear.SelectedItem as EquipmentItem,
                    cbHumanoidFace.SelectedItem as EquipmentItem,
                    cbHumanoidBody.SelectedItem as EquipmentItem,
                    cbHumanoidPants.SelectedItem as EquipmentItem,
                    cbHumanoidWeapon.SelectedItem as EquipmentItem,
                    false);

                    e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Width / 2 - (int)numAttackRange.Value, e.ClipRectangle.Height - 20 - (int)((float)numAttackRange.Value * GlobalSettings.PerspectiveSkew) - (int)numBeastOffsetY.Value, (int)numAttackRange.Value * 2, (int)((float)numAttackRange.Value * 2 * GlobalSettings.PerspectiveSkew));
                    e.Graphics.DrawRectangle(Pens.Green, e.ClipRectangle.Width / 2 - (int)numRange.Value, e.ClipRectangle.Height - 20 - (int)((float)numRange.Value * GlobalSettings.PerspectiveSkew) - (int)numBeastOffsetY.Value, (int)numRange.Value * 2, (int)((float)numRange.Value * 2 * GlobalSettings.PerspectiveSkew));
            } else if (critter is CritterBeast) {
                CritterBeast cb = (critter as CritterBeast);

                if (cb.GetAnimation(cbBeastState.Text) != null) {
                    if (cb.GetAnimation(cbBeastState.Text).GetDirection(direction) != null) {
                        AnimatedObject anim = cb.GetAnimation(cbBeastState.Text).GetDirection(direction);

                        float xPos = e.ClipRectangle.Width/2 - anim.Center.X;
                        float yPos = e.ClipRectangle.Height - 20 - (anim.Center.Y*2);
                        float hPos = e.ClipRectangle.Height - 20 - (int)numBeastHeadHeight.Value - (int)numBeastOffsetY.Value;

                        if (direction == Direction.Left) {
                            xPos -= (int)numBeastOffsetX.Value;
                        } else if (direction == Direction.Right) {
                            xPos += (int)numBeastOffsetX.Value;
                        }

                        anim.Draw(e.Graphics, xPos, yPos, 1);

                        e.Graphics.DrawRectangle(Pens.Red, (e.ClipRectangle.Width - (int)numBeastRectWidth.Value) / 2, e.ClipRectangle.Height - 20 - ((int)numBeastRectHeight.Value) - (int)numBeastOffsetY.Value, (int)numBeastRectWidth.Value, (int)numBeastRectHeight.Value);

                        e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Width / 2 - (int)numAttackRange.Value, e.ClipRectangle.Height - 20 - ((int)numBeastRectHeight.Value/2) - (int)((float)numAttackRange.Value * GlobalSettings.PerspectiveSkew) - (int)numBeastOffsetY.Value, (int)numAttackRange.Value * 2, (int)((float)numAttackRange.Value * 2 * GlobalSettings.PerspectiveSkew));
                        e.Graphics.DrawRectangle(Pens.Green, e.ClipRectangle.Width / 2 - (int)numRange.Value, e.ClipRectangle.Height - 20 - ((int)numBeastRectHeight.Value/2) - (int)((float)numRange.Value * GlobalSettings.PerspectiveSkew) - (int)numBeastOffsetY.Value, (int)numRange.Value * 2, (int)((float)numRange.Value * 2 * GlobalSettings.PerspectiveSkew));

                        if((critter.AIType & (int)AITypes.HidePanel) == 0) //Don't draw the panel if the AIType hides the panel
                            e.Graphics.FillRectangle(Brushes.YellowGreen, e.ClipRectangle.Width/2 - 32, hPos-16, 64, 16);
                    }
                }
            }
        }

        private void ChangedEquipment(object sender, EventArgs e) {
            if (_isUpdatingForm) return;

            _isCritterEdited = true;
            pbPreviewDisplay.Invalidate();
        }

        private void ValueChanged(object sender, EventArgs e) {
            if (_isUpdatingForm) return;
            _isCritterEdited = true;
        }

        private void treeAllCritters_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeAllCritters.SelectedNode.Tag is Critter) {
                SaveIfRequired();

                critter = (treeAllCritters.SelectedNode.Tag as Critter);
                UpdateForm();
            }
        }

        private void listAIType_KeyDown(object sender, KeyEventArgs e) {
            ListBox lv = sender as ListBox;

            if (lv != null && e.KeyData == Keys.Delete) {
                if (lv.SelectedIndices.Count > 0) {
                    int[] array = new int[lv.SelectedIndices.Count];
                    lv.SelectedIndices.CopyTo(array, 0);

                    Array.Sort(array);

                    int i = lv.SelectedIndices.Count;

                    while (--i > -1) {
                        lv.Items.RemoveAt(array[i]);
                    }

                    _isCritterEdited = true;
                }
            }
        }

        void ccBeastAnimations_AnimationChanged(object sender, EventArgs e) {
            if (_isUpdatingForm) return;

            _isCritterEdited = true;
        }

        private void btnBeastDirection_MouseEnter(object sender, EventArgs e) {
            if (sender == btnBeastLeft) {
                direction = Direction.Left;
            } else if (sender == btnBeastRight) {
                direction = Direction.Right;
            } else if (sender == btnBeastUp) {
                direction = Direction.Up;
            } else if (sender == btnBeastDown) {
                direction = Direction.Down;
            }

            DirectionUpdated();
        }

        private void DirectionUpdated() {
            lblBeastDirection.Text = direction.ToString();

            if (critter is CritterBeast) {
                CritterAnimationSet animSet = (critter as CritterBeast).GetAnimation(cbBeastState.Text);
                AnimatedObject animObj = animSet.GetDirection(direction);
                animObj.PlaybackSpeed = (float)numBeastFPS.Value;
                ccBeastAnimations.ChangeToAnimation(animObj);
            }

            pbPreviewDisplay.Invalidate();
        }

        private void btnBeastDirection_DragEnter(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;

            if (sender == btnBeastDown) {
                direction = Direction.Down;
            } else if (sender == btnBeastLeft) {
                direction = Direction.Left;
            } else if (sender == btnBeastRight) {
                direction = Direction.Right;
            } else if (sender == btnBeastUp) {
                direction = Direction.Up;
            }

            DirectionUpdated();
        }

        private void btnBeastDirection_DragDrop(object sender, DragEventArgs e) {
            if (!(critter is CritterBeast)) return;

            if (!Directory.Exists("Critters")) Directory.CreateDirectory("Critters");

            Direction x = Direction.Left;

            if (sender == btnBeastDown) x = Direction.Down;
            else if (sender == btnBeastRight) x = Direction.Right;
            else if (sender == btnBeastUp) x = Direction.Up;

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
                                string nFilename = "Critters/" + Path.GetFileNameWithoutExtension(filename) + ".png";

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
                                    //Keep adding _1, _2, _3 etc until we find a filename we can use.
                                    int nextFilenameAttempt = 1;
                                    while (File.Exists(nFilename)) {
                                        nFilename = "Critters/" + Path.GetFileNameWithoutExtension(filename) + "_" + nextFilenameAttempt + ".png";
                                        nextFilenameAttempt++;
                                    }

                                    File.Copy(filename, nFilename);
                                    copied = true;
                                }

                                //Now we add it to critters animations
                                if (copied) {
                                    String state = cbBeastState.Text;

                                    (critter as CritterBeast).GetAnimation(state).GetDirection(x).Frames.Add(nFilename);
                                    _isCritterEdited = true;

                                    if (direction == x) {
                                        ccBeastAnimations.UpdateBoxes();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnAddToSpawnList_Click(object sender, EventArgs e) {
            if (MainWindow.instance.listSpawns.SelectedItems.Count == 1) {
                (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).SpawnList.Add(new CritterSpawn(critter.ID));
                CacheInterfaces.SpawnRegionInterface.UpdateGUI();
                ToolCache.Map.MapPieceCache.CurrentPiece.Edited();
            }
        }

        private void btnDuplicate_Click(object sender, EventArgs e) {
            if (critter != null && treeAllCritters.SelectedNode.Tag != null) {
                SaveIfRequired();

                critter = critter.Clone();
                CritterManager.AddCritter(critter);


                //Double check its group exists as well
                if (!GroupNodes.ContainsKey(critter.NodeGroup)) {
                    GroupNodes.Add(critter.NodeGroup, new TreeNode(critter.NodeGroup));
                    treeAllCritters.Nodes.Add(GroupNodes[critter.NodeGroup]);
                    GroupNodes[critter.NodeGroup].Expand();
                }

                //Now double check the critter is in the right group
                if (critter.EditorNode.Parent != GroupNodes[critter.NodeGroup]) {
                    if (critter.EditorNode.Parent != null) {
                        critter.EditorNode.Parent.Nodes.Remove(critter.EditorNode);
                    }

                    GroupNodes[critter.NodeGroup].Nodes.Add(critter.EditorNode);
                }

                UpdateForm();

                treeAllCritters.SelectedNode = critter.EditorNode;
            }
        }

        private void BeastRectValueChanged(object sender, EventArgs e) {
            pbPreviewDisplay.Invalidate();
            ValueChanged(sender, e);
        }

        private void txtScript_BeforeParse(object sender, Components.ScriptInfoArgs e) {
            if(critter is CritterBeast) {
                e.Info.AnimationNames = (critter as CritterBeast).AnimationNames();
            }
        }

        private void redrawTimer_Tick(object sender, EventArgs e) {
            pbPreviewDisplay.Invalidate();
        }
    }
}
