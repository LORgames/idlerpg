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

        private bool isMouseDown = false;
        private WorldData selectedObject = null;
        private Point p0 = Point.Empty;
        private Point p1 = Point.Empty;

        public WorldEditor() {
            InitializeComponent();

            foreach (MapPiece p in MapPieceCache.Pieces) {
                Data.Add(new WorldData(p));
            }

            buffer = new LBuffer(pbMainPanel.Size);
        }

        private void pbMainPanel_Paint(object sender, PaintEventArgs e) {
            buffer.gfx.Clear(Color.Beige);

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
                Offset.Y += 25;
            } else if (keyData == Keys.S) {
                Offset.Y -= 25;
            } else if (keyData == Keys.A) {
                Offset.X += 25;
            } else if (keyData == Keys.D) {
                Offset.X -= 25;
            }

            pbMainPanel.Invalidate();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pbMainPanel_MouseDown(object sender, MouseEventArgs e) {
            isMouseDown = true;

            p0.X = e.X - Offset.X;
            p0.Y = e.Y - Offset.Y;

            selectedObject = null;

            foreach (WorldData d in Data) {
                if (d.rect.Contains(p0)) {
                    selectedObject = d;
                    break;
                }
            }

            if (selectedObject == null) isMouseDown = false;
        }

        private void pbMainPanel_MouseMove(object sender, MouseEventArgs e) {
            if (isMouseDown) {
                p1.X = e.X - Offset.X;
                p1.Y = e.Y - Offset.Y;

                int dx = p1.X - p0.X;
                int dy = p1.Y - p0.Y;

                selectedObject.rect.Offset(new Point(dx, dy));

                p0.X = p1.X;
                p0.Y = p1.Y;

                pbMainPanel.Invalidate();
            }
        }

        private void pbMainPanel_MouseUp(object sender, MouseEventArgs e) {
            isMouseDown = false;
            pbMainPanel.Invalidate();
        }

        private void pbMainPanel_MouseLeave(object sender, EventArgs e) {
            isMouseDown = false;
        }
    }

    public class WorldData {
        private Image image;
        
        public Rectangle rect;
        public Rectangle ScrolledAABB = new Rectangle();

        public MapPiece myPiece;

        public WorldData(MapPiece piece) {
            image = Image.FromFile("Maps/Thumbs/" + piece.Name + ".png");
            rect = new Rectangle(piece.WorldPosition, image.Size);

            myPiece = piece;

            if (!piece.isLoaded) {
                piece.Load(true);
            }
        }

        public void Draw(LBuffer buffer, Point offset) {
            ScrolledAABB.X = rect.X + offset.X;
            ScrolledAABB.Y = rect.Y + offset.Y;
            ScrolledAABB.Width = rect.Width;
            ScrolledAABB.Height = rect.Height;

            buffer.gfx.DrawImage(image, ScrolledAABB);
            buffer.gfx.DrawRectangle(Pens.Black, ScrolledAABB);
        }

        public void Dispose() {
            if (myPiece.WorldPosition.X != rect.X || myPiece.WorldPosition.Y != rect.Y) {
                myPiece.WorldPosition.X = rect.X;
                myPiece.WorldPosition.Y = rect.Y;

                myPiece.Save();
            }

            image.Dispose();
            image = null;
        }
    }
}
