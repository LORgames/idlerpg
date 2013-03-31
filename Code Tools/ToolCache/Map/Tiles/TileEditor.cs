using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Combat.Elements;

namespace ToolCache.Map.Tiles {
    public partial class TileEditor : Form {
        private short tileID = 0;

        public TileEditor() {
            InitializeComponent();
            ccAnimation.SetSaveLocation("Tiles");
            ccAnimation.ClearAnimation();

            UpdateTileNames();
            ChangeTo(-1);
        }

        private void ChangeTo(short tileID) {
            if (Tiles.TileCache.G(tileID) != null) {
                TileTemplate t = Tiles.TileCache.G(tileID);
                ccAnimation.ChangeToAnimation(t.Animation);
                cbTileGroup.Text = t.TileGroup;
                txtTileName.Text = t.TileName;
                ckbIsWalkable.Checked = t.isWalkable;

                ckbLeft.Checked = (t.directionalAccess&TileTemplate.ACCESS_LEFT)>0?true:false;
                ckbRight.Checked = (t.directionalAccess & TileTemplate.ACCESS_RIGHT) > 0 ? true : false;
                ckbUp.Checked = (t.directionalAccess & TileTemplate.ACCESS_TOP) > 0 ? true : false;
                ckbDown.Checked = (t.directionalAccess & TileTemplate.ACCESS_BOTTOM) > 0 ? true : false;

                this.tileID = tileID;
            } else {
                this.tileID = TileCache.NextID();
                ccAnimation.ClearAnimation();
                cbTileGroup.Text = "Unknown";
                txtTileName.Text = "<Unknown>";
                ckbIsWalkable.Checked = true;

                ckbLeft.Checked = true;
                ckbRight.Checked = true;
                ckbUp.Checked = true;
                ckbDown.Checked = true;
            }

            lblTileID.Text = "N:" + this.tileID;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            TileTemplate t = Tiles.TileCache.G(tileID);
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

            t.directionalAccess = TileTemplate.ACCESS_NONE;
            t.directionalAccess |= (ckbLeft.Checked ? TileTemplate.ACCESS_LEFT : (byte)0);
            t.directionalAccess |= (ckbRight.Checked ? TileTemplate.ACCESS_RIGHT : (byte)0);
            t.directionalAccess |= (ckbUp.Checked ? TileTemplate.ACCESS_TOP : (byte)0);
            t.directionalAccess |= (ckbDown.Checked ? TileTemplate.ACCESS_BOTTOM : (byte)0);

            t.damageElement = ElementManager.GetElementIDFromName(cbDamageElement.Text);

            short dps = 0;
            if(short.TryParse(txtDamagePerSecond.Text, out dps)) {
                t.damagePerSecond = dps;
            }
            
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
            MapPieceCache.CurrentPiece.RecalculateWalkable();
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
            if (!ckbIsWalkable.Checked) {
                ckbLeft.Enabled = false;
                ckbRight.Enabled = false;
                ckbUp.Enabled = false;
                ckbDown.Enabled = false;
            } else {
                ckbLeft.Enabled = true;
                ckbRight.Enabled = true;
                ckbUp.Enabled = true;
                ckbDown.Enabled = true;
            }
        }
    }
}
