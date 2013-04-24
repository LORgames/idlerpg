using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Combat.Elements;
using ToolCache.Map;
using ToolCache.Map.Tiles;

namespace CityTools {
    public partial class TileEditor : Form {
        private short tileID = 0;
        private bool Edited = false;

        public TileEditor() {
            InitializeComponent();
            ccAnimation.SetSaveLocation("Tiles");
            ccAnimation.ClearAnimation();

            UpdateElementNames();

            UpdateTileNames();
            ChangeTo(-1);
        }

        private void UpdateElementNames() {
            string[] elements = ElementManager.ElementNames();

            cbDamageElement.Items.Clear();

            foreach (String s in elements) {
                cbDamageElement.Items.Add(s);
            }
        }

        private void ChangeTo(short tileID) {
            if (ToolCache.Map.Tiles.TileCache.G(tileID) != null) {
                TileTemplate t = ToolCache.Map.Tiles.TileCache.G(tileID);
                ccAnimation.ChangeToAnimation(t.Animation);
                cbTileGroup.Text = t.TileGroup;
                txtTileName.Text = t.TileName;
                ckbIsWalkable.Checked = t.isWalkable;

                cbDamageElement.SelectedIndex = ElementManager.ElementIDToIndex(t.damageElement);
                numDamagePerSecond.Value = t.damagePerSecond;

                numMovementCost.Value = (Decimal)t.movementCost;
                cbSlideDirection.SelectedIndex = t.slidingDirection;

                this.tileID = tileID;
            } else {
                this.tileID = TileCache.NextID();
                ccAnimation.ClearAnimation();
                cbTileGroup.Text = "Unknown";
                txtTileName.Text = "<Unknown>";
                ckbIsWalkable.Checked = true;

                cbDamageElement.SelectedIndex = 0;
                numDamagePerSecond.Value = 0;

                numMovementCost.Value = 1.0M;
                cbSlideDirection.SelectedIndex = 0;
            }

            Edited = false;
            lblTileID.Text = "ID:" + this.tileID;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            TileTemplate t = ToolCache.Map.Tiles.TileCache.G(tileID);
            bool addAsNew = false;

            if (t == null) {
                addAsNew = true;
                t = new TileTemplate();
                t.TileID = tileID;
            }

            t.Animation = ccAnimation.GetAnimation();
            t.TileGroup = cbTileGroup.Text;
            t.TileName = txtTileName.Text;
            t.isWalkable = ckbIsWalkable.Checked;

            t.movementCost = (float)numMovementCost.Value;
            t.slidingDirection = (byte)cbSlideDirection.SelectedIndex;
            
            t.damageElement = ElementManager.GetElementIDFromName(cbDamageElement.Text);
            t.damagePerSecond = (short)numDamagePerSecond.Value;
            
            if(addAsNew) {
                TileCache.AddTile(t);
            }
        }

        private void btnDeleteTile_Click(object sender, EventArgs e) {
            TileCache.Delete(tileID);
            UpdateTileNames();
        }

        private void btnNewTile_Click(object sender, EventArgs e) {
            ChangeTo(-1);
            UpdateTileNames();
        }

        private void TileEditor_FormClosing(object sender, FormClosingEventArgs e) {
            TileCache.SaveDatabase();
        }

        private void UpdateTileNames() {
            cbTileNames.Items.Clear();
            cbTileGroup.Items.Clear();

            foreach (KeyValuePair<short, TileTemplate> kvp in TileCache.Tiles) {
                cbTileNames.Items.Add(kvp.Key + "| " + kvp.Value.TileName);
            }

            foreach (String groupName in TileCache.GetGroups()) {
                cbTileGroup.Items.Add(groupName);
            }
        }

        private void cbTileNames_SelectedIndexChanged(object sender, EventArgs e) {
            if (Edited) {
                if (MessageBox.Show("Do you want to save the current tile?", "Save?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                    btnSave_Click(null, null);
                }
            }

            if (cbTileNames.Text.IndexOf('|') > -1) {
                string txt = cbTileNames.Text.Split('|')[0];

                short value;

                if (short.TryParse(txt, out value)) {
                    if (TileCache.G(value) != null) {
                        ChangeTo(value);
                    }
                }
            }
        }

        private void ckbIsWalkable_CheckedChanged(object sender, EventArgs e) {
            Edited = true;
        }

        private void isEdited(object sender, EventArgs e) {
            Edited = true;
        }
    }
}
