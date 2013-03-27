using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
                ccAnimation.ChangeToAnimation(Tiles.TileCache.G(tileID).Animation);
                cbTileGroup.Text = Tiles.TileCache.G(tileID).TileGroup;
                txtTileName.Text = Tiles.TileCache.G(tileID).TileName;
                this.tileID = tileID;
            } else {
                this.tileID = TileCache.NextID();
                ccAnimation.ClearAnimation();
                cbTileGroup.Text = "Unknown";
                txtTileName.Text = "<Unknown>";
            }

            lblTileID.Text = "N:" + this.tileID;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (Tiles.TileCache.G(tileID) != null) {
                Tiles.TileCache.G(tileID).Animation = ccAnimation.GetAnimation();
                Tiles.TileCache.G(tileID).TileGroup = cbTileGroup.Text;
                Tiles.TileCache.G(tileID).TileName = txtTileName.Text;
            } else {
                Tile t = new Tile();
                t.TileID = tileID;
                t.Animation = ccAnimation.GetAnimation();
                t.TileGroup = cbTileGroup.Text;
                t.TileName = txtTileName.Text;
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

            foreach (KeyValuePair<short, Tile> kvp in TileCache.Tiles) {
                cbTileNames.Items.Add(kvp.Key + "| " + kvp.Value.TileName);
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
    }
}
