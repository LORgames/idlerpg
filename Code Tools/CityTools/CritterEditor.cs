using System;
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

namespace CityTools {
    public partial class CritterEditor : Form {
        private Critter critter;
        
        private Boolean _iE = false; //Is Edited
        private Boolean _new = false;
        private Boolean _updatingForm = false;

        private Dictionary<string, TreeNode> GroupNodes = new Dictionary<string, TreeNode>();

        public CritterEditor() {
            InitializeComponent();

            treeAllCritters.ImageList = new ImageList();
            treeAllCritters.ImageList.Images.Add(Resources.HumanIcon);
            treeAllCritters.ImageList.Images.Add(Resources.DoggyIcon);

            sptFullForm.Panel2.Enabled = false;

            lblTreeInformation.Text = "Ready.";

            FillAITypes();
            FillItemBox();
            FillGroups();
            FillEquipmentBoxes();

            FillTree();
        }

        private void FillTree() {
            treeAllCritters.Nodes.Clear();
            GroupNodes.Clear();

            foreach (Critter c in CritterManager.Critters.Values) {
                //Create this critters node
                TreeNode node = new TreeNode(c.Name);
                node.ImageIndex = (int)c.CritterType;
                node.Tag = c;

                c.EditorNode = node;

                //Add the group node if it doesn't exist yet
                if (!GroupNodes.ContainsKey(c.NodeGroup)) {
                    GroupNodes.Add(c.NodeGroup, new TreeNode(c.NodeGroup));
                    treeAllCritters.Nodes.Add(GroupNodes[c.NodeGroup]);
                    GroupNodes[c.NodeGroup].Expand();
                }

                //Yay theres a node now?
                GroupNodes[c.NodeGroup].Nodes.Add(node);
            }
        }

        private void FillGroups() {
            cbAddGroup.Items.Clear();

            foreach (String s in Factions.AllFactions) {
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
            _new = true;
            _iE = false;

            UpdateForm();
        }

        private void btnCreateBeastCritter_Click(object sender, EventArgs e) {
            SaveIfRequired();

            critter = new CritterBeast();
            _new = true;
            _iE = false;

            UpdateForm();
        }

        private void UpdateForm() {
            _updatingForm = true;

            //Fill in the boxes
            txtMonsterName.Text = critter.Name;

            numExperience.Value = critter.ExperienceGain;
            numHealth.Value = critter.Health;

            ckbOneOfAKind.Checked = critter.OneOfAKind;
            cbBaseGroup.Text = critter.NodeGroup;

            txtScript.Text = critter.AICommands;

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

                pbHumanoidDisplay.Invalidate();
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

            _updatingForm = false;
        }

        private void SaveIfRequired() {
            if (!_iE) return;

            //Set the critter information
            critter.Name = txtMonsterName.Text;
            critter.ExperienceGain = (int)numExperience.Value;
            critter.Health = (int)numHealth.Value;
            critter.OneOfAKind = ckbOneOfAKind.Checked;

            critter.NodeGroup = cbBaseGroup.Text;
            critter.AICommands = txtScript.Text;

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
            }

            if (_new) {
                CritterManager.AddCritter(critter);
            } else {
                CritterManager.UpdatedCritter(critter);
            }

            _new = false;
            _iE = false;
        }

        private void btnAddLoot_Click(object sender, EventArgs e) {
            if (cbItemList.SelectedItem is Item) {
                LootDrop loot = LootDrop.GenerateEmpty(cbItemList.SelectedItem as Item);

                critter.Loot.Add(loot);

                listLoot.Items.Add(loot.GetListViewItem());
                _iE = true;
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e) {
            if (cbAddGroup.Text.Length > 2) {
                if (!Factions.AllFactions.Contains(cbAddGroup.Text)) {
                    Factions.AllFactions.Add(cbAddGroup.Text);
                    cbAddGroup.Items.Add(cbAddGroup.Text);
                }

                listGroups.Items.Add(cbAddGroup.Text);
                _iE = true;
            }
        }

        private void btnAddAIType_Click(object sender, EventArgs e) {
            if (cbAITypes.SelectedItem is AITypes) {
                listAIType.Items.Add(cbAITypes.SelectedItem);
                _iE = true;
            }
        }

        private void pbHumanoidDisplay_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(Color.Beige);

            PersonDrawer.Draw(e.Graphics, new Point(e.ClipRectangle.Width / 2, e.ClipRectangle.Height - 20), Direction.Down, States.Walking,
                cbHumanoidShadow.SelectedItem as EquipmentItem,
                cbHumanoidHeadgear.SelectedItem as EquipmentItem,
                cbHumanoidFace.SelectedItem as EquipmentItem,
                cbHumanoidBody.SelectedItem as EquipmentItem,
                cbHumanoidPants.SelectedItem as EquipmentItem,
                cbHumanoidWeapon.SelectedItem as EquipmentItem,
                false);
        }

        private void ChangedEquipment(object sender, EventArgs e) {
            if (_updatingForm) return;

            _iE = true;
            pbHumanoidDisplay.Invalidate();
        }

        private void ValueChanged(object sender, EventArgs e) {
            if (_updatingForm) return;

            _iE = true;
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

                    _iE = true;
                }
            }
        }
    }
}
