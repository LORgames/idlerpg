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

            lblTreeInformation.Text = "Ready.";
        }

        private void CritterEditor_FormClosing(object sender, FormClosingEventArgs e) {
            CritterManager.SaveDatabase();
        }

        private void UpdateForm() {
            _updatingForm = true;

            cbCritterType.SelectedIndex = (int)critter.CritterType;
            txtMonsterName.Text = critter.Name;

            numExperience.Value = critter.ExperienceGain;
            numHealth.Value = critter.Health;

            _updatingForm = false;
        }
    }
}
