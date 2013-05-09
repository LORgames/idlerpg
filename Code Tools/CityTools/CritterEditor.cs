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

namespace CityTools {
    public partial class CritterEditor : Form {
        private Critter critter;
        
        private Boolean _iE = false; //Is Edited
        private Boolean _new = false;
        private Boolean _updatingForm = false;

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
                MessageBox.Show("Hard code error: Types != Boxes.");
            }
        }

        private void CritterEditor_FormClosing(object sender, FormClosingEventArgs e) {
            CritterManager.SaveDatabase();
            Factions.SaveDatabase();
        }

        private void UpdateForm() {
            _updatingForm = true;

            txtMonsterName.Text = critter.Name;

            numExperience.Value = critter.ExperienceGain;
            numHealth.Value = critter.Health;

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
            UpdateForm();
        }

        private void btnCreateBeastCritter_Click(object sender, EventArgs e) {
            SaveIfRequired();

            critter = new CritterBeast();
            UpdateForm();
        }

        private void SaveIfRequired() {
            _new = false;
            _iE = false;
        }

        private void btnAddLoot_Click(object sender, EventArgs e) {
            if (cbItemList.SelectedItem is Item) {
                LootDrop loot = LootDrop.GenerateEmpty(cbItemList.SelectedItem as Item);

                critter.Loot.Add(loot);

                listLoot.Items.Add(loot.GetListViewItem());
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e) {
            if (cbAddGroup.Text.Length > 2) {
                if (!Factions.AllFactions.Contains(cbAddGroup.Text)) {
                    Factions.AllFactions.Add(cbAddGroup.Text);
                    cbAddGroup.Items.Add(cbAddGroup.Text);
                }

                listGroups.Items.Add(cbAddGroup.Text);
            }
        }

        private void btnAddAIType_Click(object sender, EventArgs e) {
            if (cbAITypes.SelectedItem is AITypes) {
                listAIType.Items.Add(cbAITypes.SelectedItem);
            }
        }
    }
}
