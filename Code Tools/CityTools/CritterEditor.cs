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
            listLoot.Clear();

            listLoot.Columns.Add("Item");
            listLoot.Columns.Add("Min#");
            listLoot.Columns.Add("Max#");
            listLoot.Columns.Add("Drop%");
            listLoot.Columns.Add("Set");

            if (critter != null) {
                foreach (LootDrop loot in critter.Loot) {
                    listLoot.Items.Add(loot.GetListViewItem());
                }
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
    }
}
