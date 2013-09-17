using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CityTools.Core;
using System.Drawing;
using System.IO;
using CityTools.Components;
using ToolCache.Drawing;
using ToolCache.Map.Tiles;
using ToolCache.Map;
using ToolCache.General;

namespace CityTools.Terrain {
    public class TerrainHelper {
        private static short currentTile = 0;
        private static int drawSize = 1;

        private static Brush NotWalkable = new SolidBrush(Color.FromArgb(128, Color.Red));
        private static Brush Walkable = new SolidBrush(Color.FromArgb(128, Color.LimeGreen));

        public static bool MouseMoveOrDown(MouseEventArgs e, LBuffer input_buffer) {
            drawSize = (int)MainWindow.instance.numBrushSize.Value;
            input_buffer.gfx.Clear(Color.Transparent);

            Point m = e.Location;

            Point tilePos = Point.Empty;
            tilePos.X = (int)((Camera.Offset.X + m.X / Camera.ZoomLevel) / TileTemplate.PIXELS);
            tilePos.Y = (int)((Camera.Offset.Y + m.Y / Camera.ZoomLevel) / TileTemplate.PIXELS);

            for (int i = 0; i < drawSize; i++) {
                for (int j = 0; j < drawSize; j++) {
                    TileCache.G(currentTile).Animation.Draw(input_buffer.gfx, ((tilePos.X + i) * TileTemplate.PIXELS - Camera.Offset.X) * Camera.ZoomLevel, ((tilePos.Y + j) * TileTemplate.PIXELS - Camera.Offset.Y) * Camera.ZoomLevel, Camera.ZoomLevel);
                }
            }

            if (e.Button == MouseButtons.Left) {
                bool updated = false;
                for (int i = 0; i < drawSize; i++) {
                    for (int j = 0; j < drawSize; j++) {
                        try {
                            short ct = MapPieceCache.CurrentPiece.Tiles[tilePos.X + i, tilePos.Y + j];

                            if (ct != currentTile) {
                                MapPieceCache.CurrentPiece.Tiles[tilePos.X + i, tilePos.Y + j] = currentTile;
                                updated = true;
                            }
                        } catch { }
                    }
                }

                if (updated) {
                    MapPieceCache.CurrentPiece.Edited();
                    return true;
                }
            } else if (e.Button == MouseButtons.Middle) {
                short ct = MapPieceCache.CurrentPiece.Tiles[tilePos.X, tilePos.Y];
                SetCurrentTile(ct);
            }

            return false;
        }

        public static void DrawTerrain(LBuffer buffer) {
            if (MapPieceCache.CurrentPiece.Tiles == null) return;

            int LeftEdge = (int)(Camera.Offset.X / TileTemplate.PIXELS);
            int TopEdge = (int)(Camera.Offset.Y / TileTemplate.PIXELS);

            int RightEdge = (int)Math.Ceiling(Camera.ViewArea.Right / TileTemplate.PIXELS);
            int BottomEdge = (int)Math.Ceiling(Camera.ViewArea.Bottom / TileTemplate.PIXELS) + 1;

            if (LeftEdge < 0) LeftEdge = 0;
            if (TopEdge < 0) TopEdge = 0;
            if (RightEdge >= MapPieceCache.CurrentPiece.Tiles.numTilesX) RightEdge = MapPieceCache.CurrentPiece.Tiles.numTilesX;
            if (BottomEdge >= MapPieceCache.CurrentPiece.Tiles.numTilesY) BottomEdge = MapPieceCache.CurrentPiece.Tiles.numTilesY;

            for (int i = LeftEdge; i < RightEdge; i++) {
                for (int j = TopEdge; j < BottomEdge; j++) {
                    short f = MapPieceCache.CurrentPiece.Tiles[i, j];

                    if (TileCache.G(f) != null) {
                        int x = (int)Math.Floor((i * TileTemplate.PIXELS - Camera.Offset.X) * Camera.ZoomLevel);
                        int y = (int)Math.Floor((j * TileTemplate.PIXELS - Camera.Offset.Y) * Camera.ZoomLevel);

                        if (MainWindow.instance.ckbShowTileBases.Checked) {
                            List<Rectangle> rects = TileCache.G(f).Collision;

                            foreach (Rectangle b in rects) {
                                Rectangle r = new Rectangle();

                                r.X = (int)(x + b.X * Camera.ZoomLevel);
                                r.Y = (int)(y + b.Y * Camera.ZoomLevel);
                                r.Width = (int)(b.Width * Camera.ZoomLevel);
                                r.Height = (int)(b.Height * Camera.ZoomLevel);

                                buffer.gfx.FillRectangle(Brushes.Magenta, r);
                            }

                            TileCache.G(f).Animation.Draw(buffer.gfx, x, y, Camera.ZoomLevel, 0.33f);
                        } else {
                            TileCache.G(f).Animation.Draw(buffer.gfx, x, y, Camera.ZoomLevel);
                        }
                    }
                }
            }

            if (MainWindow.instance.ckbShowTileGrid.Checked) {
                for (int i = LeftEdge; i < RightEdge; i++) {
                    int xPos = (int)Math.Floor((i * TileTemplate.PIXELS - Camera.Offset.X) * Camera.ZoomLevel);
                    buffer.gfx.DrawLine(Pens.Beige, xPos, 0, xPos, buffer.bmp.Height);
                }

                for (int j = TopEdge; j < BottomEdge; j++) {
                    int yPos = (int)Math.Floor((j * TileTemplate.PIXELS - Camera.Offset.Y) * Camera.ZoomLevel);
                    buffer.gfx.DrawLine(Pens.Beige, 0, yPos, buffer.bmp.Width, yPos);
                }
            }
        }

        private static void CopyRectangleWithOffset(ref Rectangle r, Rectangle c) {
            r.X = c.X - (int)Camera.Offset.X;
            r.Y = c.Y - (int)Camera.Offset.Y;
            r.Width = c.Width;
            r.Height = c.Height;
        }

        public static void SetCurrentTile(short newTile) {
            currentTile = newTile;
        }

        internal static short GetCurrentTile() {
            return currentTile;
        }

        internal static short StripTileIDFromPath(string pathName) {
            int i1 = pathName.LastIndexOf('\\');
            int i2 = pathName.LastIndexOf('.');

            string ttt = pathName.Substring(i1 + 1, i2 - i1 - 1);

            if (ttt.Split('_').Length > 1) {
                ttt = ttt.Split('_')[0];
            }

            return short.Parse(ttt);
        }
    }
}
