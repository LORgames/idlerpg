using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Elements;
using ToolCache.Map;
using ToolCache.Map.Tiles;
using ToolCache.General;
using CityTools.Components;

namespace CityTools {
    public partial class TileEditor : Form {
        private short tileID = 0;

        Point p0 = Point.Empty;
        Point p1 = Point.Empty;

        List<Rectangle> _bases = new List<Rectangle>();

        Boolean _iE = false; //is edited
        Boolean _new = false; //Is it new?
        Boolean _updating = false; //is it updating?

        public TileEditor() {
            InitializeComponent();
            ccAnimation.SetSaveLocation("Tiles");
            ccAnimation.ClearAnimation();
            ccAnimation.AnimationChanged += AnimationChanged;

            UpdateTileNames();
            ChangeTo(-1);

            timer1.Start();
        }

        private void ChangeTo(short tileID) {
            if (_iE) {
                if (_new && MessageBox.Show("Do you want to keep this object?", "Caption?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Save();
                } else if (!_new) {
                    Save();
                }
            }

            _updating = true;

            if (ToolCache.Map.Tiles.TileCache.G(tileID) != null) {
                _new = false;
                TileTemplate t = ToolCache.Map.Tiles.TileCache.G(tileID);
                ccAnimation.ChangeToAnimation(t.Animation);
                cbTileGroup.Text = t.TileGroup;
                txtTileName.Text = t.TileName;

                numMovementCost.Value = (Decimal)t.movementCost;

                _bases = t.Collision;

                this.tileID = tileID;
            } else {
                _new = true;
                this.tileID = TileCache.NextID();
                ccAnimation.ClearAnimation();
                cbTileGroup.Text = "Unknown";
                txtTileName.Text = "<Unknown>";

                _bases = new List<Rectangle>();

                numMovementCost.Value = 1.0M;
            }

            lblTileID.Text = "ID:" + this.tileID;

            _updating = false;
            _iE = false;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Save();
        }

        private void Save() {
            TileTemplate t = ToolCache.Map.Tiles.TileCache.G(tileID);

            if (_new) {
                t = new TileTemplate();
                t.TileID = tileID;
            }

            t.Animation = ccAnimation.GetAnimation();
            t.TileGroup = cbTileGroup.Text;
            t.TileName = txtTileName.Text;

            t.movementCost = (float)numMovementCost.Value;

            t.Collision = _bases;

            if (_new) {
                TileCache.AddTile(t);
            }

            _new = false;
            _iE = false;

            UpdateTileNames();
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
            if (_iE) {
                if (_new && MessageBox.Show("Do you want to keep this tile?", "Save Tile?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Save();
                } else if (!_new) {
                    Save();
                }
            }

            TileCache.SaveDatabase();
        }

        private void UpdateTileNames() {
            treeAllTiles.Nodes.Clear();
            cbTileGroup.Items.Clear();

            Dictionary<string, TreeNode> rootNodes = new Dictionary<string, TreeNode>();
            List<string> groups = TileCache.GetGroups();

            foreach (String groupName in groups) {
                rootNodes.Add(groupName, new TreeNode(groupName));
                treeAllTiles.Nodes.Add(rootNodes[groupName]);

                cbTileGroup.Items.Add(groupName);
            }

            foreach (KeyValuePair<short, TileTemplate> kvp in TileCache.Tiles) {
                TreeNode node = new TreeNode(kvp.Value.TileName);
                node.Tag = kvp.Key;

                rootNodes[kvp.Value.TileGroup].Nodes.Add(node);
            }

            treeAllTiles.ExpandAll();
        }

        private void treeAllTiles_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeAllTiles.SelectedNode.Tag != null) {
                ChangeTo((short)treeAllTiles.SelectedNode.Tag);
            }
        }

        private void ValueChanged(object sender, EventArgs e) {
            if (!_updating) _iE = true;
        }

        private void AnimationChanged(object sender, EventArgs e) {
            if (!_updating) _iE = true;

            foreach (String s in ccAnimation.GetAnimation().Frames) {
                ImageCache.ForceCache(s);
            }
        }

        private void btnRemoveBoxes_Click(object sender, EventArgs e) {
            _bases.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            pbDisplay.Invalidate();
        }

        private void pbDisplay_Paint(object sender, PaintEventArgs e) {
            if (ccAnimation.GetAnimation().Frames.Count > 0) {
                ccAnimation.GetAnimation().Draw(e.Graphics, 26, 26, 1);
            } else {
                e.Graphics.FillRectangle(Brushes.Beige, 26, 26, GlobalSettings.TileSize, GlobalSettings.TileSize);
            }

            if (ckbShowCollisions.Checked) {
                foreach (Rectangle r in _bases) {
                    e.Graphics.DrawRectangle(Pens.White, r.X + 26, r.Y + 26, r.Width, r.Height);
                }
            }
        }

        private void pbDisplay_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p0 = e.Location;
                p1 = e.Location;
            }
        }

        private void pbDisplay_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p1 = e.Location;

                if (p0.X < 26) p0.X = 26;
                if (p0.Y < 26) p0.Y = 26;
                if (p1.X < 26) p1.X = 26;
                if (p1.Y < 26) p1.Y = 26;
                if (p0.X > 74) p0.X = 74;
                if (p0.Y > 74) p0.Y = 74;
                if (p1.X > 74) p1.X = 74;
                if (p1.Y > 74) p1.Y = 74;

                Rectangle r = new Rectangle();
                r.X = Math.Min(p0.X, p1.X);
                r.Y = Math.Min(p0.Y, p1.Y);
                r.Width = Math.Abs(p1.X - p0.X);
                r.Height = Math.Abs(p1.Y - p0.Y);

                r.Offset(-26, -26);

                _bases.Add(r);
            }
        }

        private void pbDisplay_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p1 = e.Location;
            }
        }

        private void btnMerge_Click(object sender, EventArgs e) {
            TileMergeDialog tmd = new TileMergeDialog();
            tmd.ShowDialog();
        }

        private void TileEditor_Load(object sender, EventArgs e) {
            pbDisplay.Width = GlobalSettings.TileSize + 50;
            pbDisplay.Height = GlobalSettings.TileSize + 50;
        }
    }
}
