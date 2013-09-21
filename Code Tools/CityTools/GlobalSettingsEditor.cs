using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.General;
using ToolCache.Scripting;

namespace CityTools {
    public partial class GlobalSettingsEditor : Form {
        private bool isEdited = false;
        private bool isUpdating = false;

        public GlobalSettingsEditor() {
            InitializeComponent();

            isUpdating = true;

            txtGameName.Text = GlobalSettings.GameName;
            chkEnableTiles.Checked = GlobalSettings.TilesEnabled;
            nudTileSize.Value = GlobalSettings.TileSize;
            chkDisableCharacter.Checked = GlobalSettings.CharacterDisabled;
            numTargetFPS.Value = GlobalSettings.GameFPS;
            numPerspectiveSkew.Value = (decimal)GlobalSettings.PerspectiveSkew;

            int i = 0;
            foreach (string s in GlobalVariables.Variables.Keys) {
                cbVariableWX.Items.Add(s);
                cbVariableWY.Items.Add(s);
                cbVariableLX.Items.Add(s);
                cbVariableLY.Items.Add(s);

                if (GlobalSettings.VariablePressedWorldX == s) cbVariableWX.SelectedIndex = i;
                if (GlobalSettings.VariablePressedWorldY == s) cbVariableWY.SelectedIndex = i;
                if (GlobalSettings.VariablePressedLocalX == s) cbVariableLX.SelectedIndex = i;
                if (GlobalSettings.VariablePressedLocalY == s) cbVariableLY.SelectedIndex = i;

                i++;
            }

            cbVariableWX.SelectedText = GlobalSettings.VariablePressedWorldX;
            cbVariableWY.SelectedText = GlobalSettings.VariablePressedWorldY;
            cbVariableLX.SelectedText = GlobalSettings.VariablePressedLocalX;
            cbVariableLY.SelectedText = GlobalSettings.VariablePressedLocalY;
            
            isUpdating = false;
        }

        private void Edited(object sender, EventArgs e) {
            if (isUpdating) return;
            isEdited = true;
        }

        private void SaveIfRequired() {
            if (isEdited) {
                GlobalSettings.GameName = txtGameName.Text;
                GlobalSettings.TilesEnabled = chkEnableTiles.Checked;
                GlobalSettings.TileSize = (int)nudTileSize.Value;
                GlobalSettings.CharacterDisabled = chkDisableCharacter.Checked;
                GlobalSettings.GameFPS = (int)numTargetFPS.Value;
                GlobalSettings.PerspectiveSkew = (float)numPerspectiveSkew.Value;

                GlobalSettings.VariablePressedWorldX = cbVariableWX.SelectedItem==null?"":cbVariableWX.SelectedItem.ToString();
                GlobalSettings.VariablePressedWorldY = cbVariableWY.SelectedItem==null?"":cbVariableWY.SelectedItem.ToString();
                GlobalSettings.VariablePressedLocalX = cbVariableLX.SelectedItem==null?"":cbVariableLX.SelectedItem.ToString();
                GlobalSettings.VariablePressedLocalY = cbVariableLY.SelectedItem==null?"":cbVariableLY.SelectedItem.ToString();

                GlobalSettings.Save();
            }

            isEdited = false;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            SaveIfRequired();
            this.Close();
        }

        private void GlobalSettingsEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (isEdited) {
                if (MessageBox.Show("Do you want to save your changes?", "Save?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                    SaveIfRequired();
                }
            }
        }
    }
}
