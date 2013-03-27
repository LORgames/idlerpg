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

        public static void InitializeTerrainSystem(ComboBox cb, Panel objPanel) {
            //TODO: Get groups 
            cb.Items.Clear();

            short id = TileCache.NextID();

            foreach(string cache in TileCache.GetGroups()) {
                cb.Items.Add(cache);
            }

            objPanel.Controls.Add(new ObjectCacheControl("", false, true));
        }

        public static bool MouseMoveOrDown(MouseEventArgs e, LBuffer input_buffer) {
            input_buffer.gfx.Clear(Color.Transparent);

            Point m = e.Location;

            Point tilePos = Point.Empty;
            tilePos.X = (int)((Camera.Offset.X + m.X / Camera.ZoomLevel) / Tile.PIXELS_X);
            tilePos.Y = (int)((Camera.Offset.Y + m.Y / Camera.ZoomLevel) / Tile.PIXELS_Y);

            TileCache.G(currentTile).Animation.Draw(input_buffer, (tilePos.X * Tile.PIXELS_X - Camera.Offset.X) * Camera.ZoomLevel, (tilePos.Y * Tile.PIXELS_X - Camera.Offset.Y) * Camera.ZoomLevel, Camera.ZoomLevel);

            if (e.Button == MouseButtons.Left) {
                bool updated = false;
                for (int i = 0; i < drawSize; i++) {
                    for (int j = 0; j < drawSize; j++) {
                        try {
                            short ct = MapPieceCache.CurrentPiece.Tiles.Data[tilePos.X + i, tilePos.Y + j];

                            if (ct != currentTile) {
                                MapPieceCache.CurrentPiece.Tiles.Data[tilePos.X + i, tilePos.Y + j] = currentTile;
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
                short ct = MapPieceCache.CurrentPiece.Tiles.Data[tilePos.X, tilePos.Y];
                SetCurrentTile(ct);
            }

            return false;
        }

        public static void DrawTerrain(LBuffer buffer) {
            if (MapPieceCache.CurrentPiece.Tiles == null) return;

            int LeftEdge = (int)(Camera.Offset.X / Tile.PIXELS_X);
            int TopEdge = (int)(Camera.Offset.Y / Tile.PIXELS_Y);

            int RightEdge = (int)Math.Ceiling(Camera.ViewArea.Right / Tile.PIXELS_X);
            int BottomEdge = (int)Math.Ceiling(Camera.ViewArea.Bottom / Tile.PIXELS_Y);

            if (LeftEdge < 0) LeftEdge = 0;
            if (TopEdge < 0) TopEdge = 0;
            if (RightEdge >= MapPieceCache.CurrentPiece.Tiles.numTilesX) RightEdge = MapPieceCache.CurrentPiece.Tiles.numTilesX;
            if (BottomEdge >= MapPieceCache.CurrentPiece.Tiles.numTilesY) BottomEdge = MapPieceCache.CurrentPiece.Tiles.numTilesY;

            buffer.gfx.FillRectangle(Brushes.CornflowerBlue, new Rectangle((int)Math.Floor((LeftEdge * Tile.PIXELS_X - Camera.Offset.X) * Camera.ZoomLevel), (int)Math.Floor((TopEdge * Tile.PIXELS_Y - Camera.Offset.Y) * Camera.ZoomLevel), (int)Math.Ceiling(Tile.PIXELS_X * Camera.ZoomLevel * (RightEdge - LeftEdge)), (int)Math.Ceiling(Tile.PIXELS_Y * Camera.ZoomLevel * (BottomEdge - TopEdge))));

            for (int i = LeftEdge; i < RightEdge; i++) {
                for (int j = TopEdge; j < BottomEdge; j++) {
                    short f = MapPieceCache.CurrentPiece.Tiles.Data[i, j];

                    if(TileCache.G(f) != null)
                        TileCache.G(f).Animation.Draw(buffer, (int)Math.Floor((i * Tile.PIXELS_X - Camera.Offset.X) * Camera.ZoomLevel), (int)Math.Floor((j * Tile.PIXELS_Y - Camera.Offset.Y) * Camera.ZoomLevel), Camera.ZoomLevel);
                }
            }
        }

        public static void SetCurrentTile(short newTile) {
            currentTile = newTile;
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
