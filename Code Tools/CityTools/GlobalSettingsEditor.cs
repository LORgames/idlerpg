using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.GlobalSettings;

namespace CityTools
{
    public partial class GlobalSettingsEditor : Form
    {
        private GlobalSettings currentInfo;
        private bool isEdited = false;

        public GlobalSettingsEditor()
        {
            InitializeComponent();

            currentInfo = new GlobalSettings();
            txtGameName.Text = currentInfo.gameName;
            chkEnableTiles.Checked = currentInfo.enableTiles;
            nudTileSize.Value = currentInfo.tileSize;
            chkDisableCharacter.Checked = currentInfo.disableCharacter;
        }

        private void Edited(object sender, EventArgs e) {
            isEdited = true;
        }

        private void SaveIfRequired() {
            if (currentInfo != null && isEdited) {
                currentInfo.gameName = txtGameName.Text;
                currentInfo.enableTiles = chkEnableTiles.Checked;
                currentInfo.tileSize = (uint)nudTileSize.Value;
                currentInfo.disableCharacter = chkDisableCharacter.Checked;

                currentInfo.Save();
            }

            isEdited = false;
        }

        private void GlobalSettings_FormClosing(object sender, FormClosingEventArgs e) {
            SaveIfRequired();
        }
    }
}
