﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.General;

namespace CityTools {
    public partial class GlobalSettingsEditor : Form {
        private bool isEdited = false;

        public GlobalSettingsEditor() {
            InitializeComponent();

            txtGameName.Text = GlobalSettings.gameName;
            chkEnableTiles.Checked = GlobalSettings.enableTiles;
            nudTileSize.Value = GlobalSettings.tileSize;
            chkDisableCharacter.Checked = GlobalSettings.disableCharacter;
            numTargetFPS.Value = GlobalSettings.targetGameFPS;
        }

        private void Edited(object sender, EventArgs e) {
            isEdited = true;
        }

        private void SaveIfRequired() {
            if (isEdited) {
                GlobalSettings.gameName = txtGameName.Text;
                GlobalSettings.enableTiles = chkEnableTiles.Checked;
                GlobalSettings.tileSize = (int)nudTileSize.Value;
                GlobalSettings.disableCharacter = chkDisableCharacter.Checked;
                GlobalSettings.targetGameFPS = (int)numTargetFPS.Value;

                GlobalSettings.Save();
            }

            isEdited = false;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveIfRequired();
            this.Close();
        }
    }
}
