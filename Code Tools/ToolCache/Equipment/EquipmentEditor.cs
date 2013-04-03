using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ToolCache.Animation.Form;
using ToolCache.Map.Tiles;

namespace ToolCache.Equipment {
    public partial class EquipmentEditor : Form {
        Direction currentDirection = Direction.Left;

        public EquipmentEditor() {
            InitializeComponent();

            Random r = new Random();

            //Add all tiles to the tile list
            cbTileList.Items.Clear();
            foreach(KeyValuePair<short, TileTemplate> kvp in TileCache.Tiles) {
                if (kvp.Value.isWalkable && kvp.Value.directionalAccess == TileTemplate.ACCESS_ALL) {
                    cbTileList.Items.Add(kvp.Value);

                    if (kvp.Value.TileName == "Grass") {
                        cbTileList.SelectedIndex = cbTileList.Items.Count - 1;
                    }
                }
            }
            

            //Add types to the equipment types
            cbItemType.Items.Clear();
            foreach(String s in Enum.GetNames(typeof(EquipmentTypes))) {
                cbItemType.Items.Add(s);
            }
            cbItemType.SelectedIndex = 0;

            //Add Roots to treeview.
        }

        private void pbEquipmentDisplay_Paint(object sender, PaintEventArgs e) {
            TileTemplate tt = cbTileList.SelectedItem as TileTemplate;

            if (tt != null) {
                for (int x = 0; x < e.ClipRectangle.Width; x += TileTemplate.PIXELS_X) {
                    for (int y = 0; y < e.ClipRectangle.Width; y += TileTemplate.PIXELS_Y) {
                        tt.Animation.Draw(e.Graphics, x, y, 1);
                    }
                }
            }
        }

        private void pbSetupLinks_Paint(object sender, PaintEventArgs e) {
            TileTemplate tt = cbTileList.SelectedItem as TileTemplate;

            if (tt != null) {
                for (int x = 0; x < e.ClipRectangle.Width; x += TileTemplate.PIXELS_X) {
                    for (int y = 0; y < e.ClipRectangle.Width; y += TileTemplate.PIXELS_Y) {
                        tt.Animation.Draw(e.Graphics, x, y, 1);
                    }
                }
            }
        }

        private void cbTileList_SelectedIndexChanged(object sender, EventArgs e) {
            pbEquipmentDisplay.Invalidate();
            pbSetupLinks.Invalidate();
        }

        private void quickDrop_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void quickDrop_DragDrop(object sender, DragEventArgs e) {

        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void btnRotLeft_Click(object sender, EventArgs e) {
            currentDirection -= 1;
        }

        private void btnRotRight_Click(object sender, EventArgs e) {
            currentDirection += 1;
        }
    }
}
