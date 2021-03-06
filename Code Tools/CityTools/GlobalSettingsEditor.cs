﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.General;
using ToolCache.Scripting;
using ToolCache.Scripting.Extensions;
using ToolCache.Map;

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
            numTargetFPS.Value = GlobalSettings.GameFPS;
            numPerspectiveSkew.Value = (decimal)GlobalSettings.PerspectiveSkew;

            int i = 0;
            foreach (string s in Variables.GlobalVariables.Keys) {
                cbVariableWX.Items.Add(s);
                cbVariableWY.Items.Add(s);
                cbVariableLX.Items.Add(s);
                cbVariableLY.Items.Add(s);
                cbVariableMute.Items.Add(s);
                cbVariableMusicVolume.Items.Add(s);
                cbVariableSoundVolume.Items.Add(s);
                cbVariablePlayerID.Items.Add(s);

                if (GlobalSettings.VariablePressedWorldX == s) cbVariableWX.SelectedIndex = i;
                if (GlobalSettings.VariablePressedWorldY == s) cbVariableWY.SelectedIndex = i;
                if (GlobalSettings.VariablePressedLocalX == s) cbVariableLX.SelectedIndex = i;
                if (GlobalSettings.VariablePressedLocalY == s) cbVariableLY.SelectedIndex = i;
                if (GlobalSettings.VariableMute == s) cbVariableMute.SelectedIndex = i;
                if (GlobalSettings.VariableMusicVolume == s) cbVariableMusicVolume.SelectedIndex = i;
                if (GlobalSettings.VariableSoundVolume == s) cbVariableSoundVolume.SelectedIndex = i;
                if (GlobalSettings.VariablePlayerID == s) cbVariablePlayerID.SelectedIndex = i;

                i++;
            }

            foreach (MapPiece m in MapPieceCache.Pieces) {
                cbDefaultMap.Items.Add(m.Name);
                if (m.Name == GlobalSettings.DefaultMap) {
                    cbDefaultMap.SelectedItem = m.Name;
                }
            }

            cbVariableWX.SelectedText = GlobalSettings.VariablePressedWorldX;
            cbVariableWY.SelectedText = GlobalSettings.VariablePressedWorldY;
            cbVariableLX.SelectedText = GlobalSettings.VariablePressedLocalX;
            cbVariableLY.SelectedText = GlobalSettings.VariablePressedLocalY;
            cbVariableMute.SelectedText = GlobalSettings.VariableMute;
            cbVariableMusicVolume.SelectedText = GlobalSettings.VariableMusicVolume;
            cbVariableSoundVolume.SelectedText = GlobalSettings.VariableSoundVolume;


            numPlayers.Value = GlobalSettings.PlayerTotal;
            numCritters.Value = GlobalSettings.PlayerCritters;
            numTurnSize.Value = GlobalSettings.PlayerTurnLength;
            txtQuickMatchServer.Text = GlobalSettings.MatchmakingServer;
            cbVariablePlayerID.SelectedText = GlobalSettings.VariablePlayerID;

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
                GlobalSettings.GameFPS = (int)numTargetFPS.Value;
                GlobalSettings.PerspectiveSkew = (float)numPerspectiveSkew.Value;

                GlobalSettings.VariablePressedWorldX = cbVariableWX.SelectedItem==null?"":cbVariableWX.SelectedItem.ToString();
                GlobalSettings.VariablePressedWorldY = cbVariableWY.SelectedItem==null?"":cbVariableWY.SelectedItem.ToString();
                GlobalSettings.VariablePressedLocalX = cbVariableLX.SelectedItem==null?"":cbVariableLX.SelectedItem.ToString();
                GlobalSettings.VariablePressedLocalY = cbVariableLY.SelectedItem==null?"":cbVariableLY.SelectedItem.ToString();

                GlobalSettings.PlayerTotal = (byte)numPlayers.Value;
                GlobalSettings.PlayerCritters = (byte)numCritters.Value;
                GlobalSettings.PlayerTurnLength = (short)numTurnSize.Value;
                GlobalSettings.MatchmakingServer = txtQuickMatchServer.Text;
                GlobalSettings.VariablePlayerID = cbVariablePlayerID.SelectedItem == null ? "" : cbVariablePlayerID.SelectedItem.ToString();

                GlobalSettings.VariableMute = cbVariableMute.SelectedItem == null ? "" : cbVariableMute.SelectedItem.ToString();
                GlobalSettings.VariableMusicVolume = cbVariableMusicVolume.SelectedItem == null ? "" : cbVariableMusicVolume.SelectedItem.ToString();
                GlobalSettings.VariableSoundVolume = cbVariableSoundVolume.SelectedItem == null ? "" : cbVariableSoundVolume.SelectedItem.ToString();

                GlobalSettings.DefaultMap = cbDefaultMap.SelectedItem.ToString();

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

        private void pbGIFBackground_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(GlobalSettings.GIFColour);
        }

        private void pbGIFBackground_Click(object sender, EventArgs e) {
            colorPicker.Color = GlobalSettings.GIFColour;
            if (colorPicker.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                GlobalSettings.GIFColour = colorPicker.Color;
                pbGIFBackground.Invalidate();
            }
            Edited(null, null);
        }
    }
}
