using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Map.Tiles;

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
                name += m.Tile.TileName + " to ";
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
            
            foreach (MergeStruct m in Items) {
                if (m.Tile != null) {
                    m.Tile.Animation.Draw(e.Graphics, 0, 0, 1);
                }
            }
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
