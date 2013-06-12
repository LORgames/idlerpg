using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Map.Tiles;
using ToolCache.Animation;

namespace CityTools.Components {
    public partial class TileMergeDialog : Form {
        private BindingList<MergeStruct> Items = new BindingList<MergeStruct>();

        public TileMergeDialog() {
            InitializeComponent();
            FillGroups();

            listLayers.DisplayMember = "Tile";
            listLayers.DataSource = Items;
        }

        private void FillGroups() {
            cbTileGroup.Items.Clear();

            foreach (String s in TileCache.GetGroups()) {
                cbTileGroup.Items.Add(s);
            }
        }

        private void cbTileGroup_SelectedIndexChanged(object sender, EventArgs e) {
            cbTileName.Items.Clear();

            foreach (TileTemplate t in TileCache.GetTilesInGroup(cbTileGroup.SelectedItem.ToString())) {
                cbTileName.Items.Add(t);
            }
        }

        private void cbTileName_SelectedIndexChanged(object sender, EventArgs e) {
            (listLayers.SelectedItem as MergeStruct).Tile = (cbTileName.SelectedItem as TileTemplate);
            TileRedraw();
        }

        private void TileRedraw() {
            pbDisplay.Invalidate();

            String name = "";
            foreach (MergeStruct m in Items) {
                if (m.Tile != null) {
                    name += m.Tile.TileName + " to ";
                } else {
                    name += "null to ";
                }
            }

            name = name.Substring(0, name.Length - 4);
            txtName.Text = name;

            listLayers.DisplayMember = "";
        }

        private void btnAddLayer_Click(object sender, EventArgs e) {
            Items.Add(new MergeStruct());
        }

        private void pbDisplay_Paint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.Magenta, e.ClipRectangle);
            DrawAllTiles(e.Graphics);
        }

        private void DrawAllTiles(Graphics g) {
            foreach (MergeStruct m in Items) {
                if (m.Tile != null) {
                    m.Tile.Animation.Draw(g, 0, 0, 1);
                }
            }
        }

        private void btnMerge_Click(object sender, EventArgs e) {
            if (txtName.Text.Length < 3) {
                MessageBox.Show("Name needs to be longer than 2 characters!");
                return;
            }

            List<MergeStruct> ItemsToDelete = new List<MergeStruct>();

            foreach(MergeStruct m in Items) {
                if (m.Tile == null) {
                    ItemsToDelete.Add(m);
                }

                if(m.Tile.Animation.Frames.Count > 1) {
                    //TODO: Allow animations in the merger
                    MessageBox.Show("Cannot currently merge tiles with animations. Sorry!");
                    return;
                }

                if (m.Tile.Animation.Frames.Count == 0) {
                    ItemsToDelete.Add(m);
                }
            }

            foreach(MergeStruct m in ItemsToDelete) {
                Items.Remove(m);
            }
            ItemsToDelete.Clear();
            ItemsToDelete = null;

            if (Items.Count < 2) {
                MessageBox.Show("You need at least 2 tiles to merge.");
                return;
            }

            Bitmap bmp = new Bitmap(Items[0].Tile.Animation.Frames[0]);
            Graphics g = Graphics.FromImage(bmp);
            DrawAllTiles(g);
            g.Dispose();

            Bitmap bmp2 = new Bitmap(bmp);
            bmp.Dispose();

            bmp2.Save("Tiles/" + txtName.Text + ".png");

            TileTemplate t = new TileTemplate();
            t.Animation = new AnimatedObject();
            t.Animation.Frames.Add("Tiles/" + txtName.Text + ".png");
            t.TileName = txtName.Text;
            t.TileGroup = "Unknown";
            t.TileID = TileCache.NextID();

            TileCache.AddTile(t);
            TileCache.SaveDatabase();
        }
    }

    public class MergeStruct {
        public TileTemplate Tile;

        public override string ToString() {
            if(Tile != null)
                return Tile.TileGroup + "." + Tile.TileName;

            return "Not Selected";
        }
    }
}
