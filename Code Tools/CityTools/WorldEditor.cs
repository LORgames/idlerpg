using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Map;
using ToolCache.Drawing;
using CityTools.Core;

namespace CityTools {
    public partial class WorldEditor : Form {
        private List<WorldData> Data = new List<WorldData>();
        private LBuffer buffer;

        private Point Offset = new Point();

        public WorldEditor() {
            InitializeComponent();

            foreach (MapPiece p in MapPieceCache.Pieces) {
                Data.Add(new WorldData(p));
            }

            buffer = new LBuffer(pbMainPanel.Size);
        }

        private void pbMainPanel_Paint(object sender, PaintEventArgs e) {
            buffer.gfx.Clear(Color.CornflowerBlue);

            foreach (WorldData d in Data) {
                d.Draw(buffer, Offset);
            }

            e.Graphics.DrawImage(buffer.bmp, Point.Empty);
        }

        private void WorldEditor_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (WorldData d in Data) {
                d.Dispose();
            }

            Data.Clear();
        }

        private void pbMainPanel_Resize(object sender, EventArgs e) {
            buffer.Dispose();
            buffer = new LBuffer(pbMainPanel.Size);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.W) {
                Offset.Y -= 5;
            } else if (keyData == Keys.S) {
                Offset.Y += 5;
            } else if (keyData == Keys.A) {
                Offset.X -= 5;
            } else if (keyData == Keys.D) {
                Offset.X += 5;
            }

            pbMainPanel.Invalidate();

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public class WorldData {
        private Image image;
        private Rectangle rect;

        private static Rectangle r;

        public WorldData(MapPiece piece) {
            image = Image.FromFile("Maps/Thumbs/" + piece.Name + ".png");
            rect = new Rectangle(piece.WorldPosition, image.Size);
        }

        public void Draw(LBuffer buffer, Point offset) {
            rect.X = r.X + offset.X;
            rect.Y = r.Y + offset.Y;
            rect.Width = r.Width;
            rect.Height = r.Height;

            buffer.gfx.DrawImage(image, rect);
        }

        public void Dispose() {
            image.Dispose();
            image = null;
        }
    }
}
