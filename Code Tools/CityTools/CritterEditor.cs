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
            PopulateLootList();
        }

        private void FillGroups() {
            MessageBox.Show("Cannot run 'FillGroups' in CritterEditor.cs");
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

        private void CritterEditor_FormClosing(object sender, FormClosingEventArgs e) {
            CritterManager.SaveDatabase();
        }

        private void UpdateForm() {
            _updatingForm = true;

            txtMonsterName.Text = critter.Name;

            numExperience.Value = critter.ExperienceGain;
            numHealth.Value = critter.Health;

            PopulateLootList();

            sptFullForm.Panel2.Enabled = true;

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
            listGroups.Items.Add(cbAddGroup.SelectedText);
        }

        private void btnAddAIType_Click(object sender, EventArgs e) {
            if (cbAITypes.SelectedItem is AITypes) {
                MessageBox.Show("Has AI Type");
            }
        }
    }
}
