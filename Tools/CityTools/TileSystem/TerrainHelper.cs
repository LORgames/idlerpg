﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CityTools.Core;
using System.Drawing;
using System.IO;
using CityTools.Components;

namespace CityTools.Terrain {
    public class TerrainHelper {

        private static byte currentTile = 0;
        private static Image currentTileIm = null;

        private static int drawSize = 1;

        public static void InitializeTerrainSystem(ComboBox cb, Panel objPanel) {
            if (!Directory.Exists(MapCache.TILE_DIRECTORY)) Directory.CreateDirectory(MapCache.TILE_DIRECTORY);

            List<String> dark = new List<string>();
            dark.InsertRange(0, Directory.GetDirectories(MapCache.TILE_DIRECTORY));

            if (dark.Count > 0) {
                objPanel.Controls.Add(new ObjectCacheControl(dark[0], false));
            }

            cb.DataSource = dark;
        }

        public static bool MouseMoveOrDown(MouseEventArgs e, LBuffer input_buffer) {
            input_buffer.gfx.Clear(Color.Transparent);

            Point m = e.Location;

            Point tilePos = Point.Empty;
            tilePos.X = (int)((Camera.Offset.X + m.X / Camera.ZoomLevel) / MapCache.TILE_SIZE_X);
            tilePos.Y = (int)((Camera.Offset.Y + m.Y / Camera.ZoomLevel) / MapCache.TILE_SIZE_Y);

            input_buffer.gfx.DrawImage(currentTileIm, new RectangleF((tilePos.X * MapCache.TILE_SIZE_X - Camera.Offset.X) * Camera.ZoomLevel, (tilePos.Y * MapCache.TILE_SIZE_Y - Camera.Offset.Y) * Camera.ZoomLevel, MapCache.TILE_SIZE_X * Camera.ZoomLevel, MapCache.TILE_SIZE_Y * Camera.ZoomLevel));

            if (e.Button == MouseButtons.Left) {
                bool updated = false;
                for (int i = 0; i < drawSize; i++) {
                    for (int j = 0; j < drawSize; j++) {
                        try {
                            byte ct = MapCache.tiles[tilePos.X + i, tilePos.Y + j];

                            if (ct != currentTile) {
                                MapCache.tiles[tilePos.X + i, tilePos.Y + j] = currentTile;
                                updated = true;
                            }
                        } catch { }
                    }
                }

                if (updated) {
                    MapPieces.MapPieceCache.CurrentPiece.Edited();
                    return true;
                }
            } else if (e.Button == MouseButtons.Middle) {
                byte ct = MapCache.tiles[tilePos.X, tilePos.Y];
                SetCurrentTile(ct);
            }

            return false;
        }

        public static void DrawTerrain(LBuffer buffer) {
            if (MapCache.tiles == null) return;

            int LeftEdge = (int)(Camera.Offset.X / MapCache.TILE_SIZE_X);
            int TopEdge = (int)(Camera.Offset.Y / MapCache.TILE_SIZE_Y);

            int RightEdge = (int)Math.Ceiling(Camera.ViewArea.Right / MapCache.TILE_SIZE_X);
            int BottomEdge = (int)Math.Ceiling(Camera.ViewArea.Bottom / MapCache.TILE_SIZE_Y);

            for (int i = LeftEdge; i < RightEdge; i++) {
                for (int j = TopEdge; j < BottomEdge; j++) {
                    if (i < 0 || i >= MapCache.TILE_TOTAL_X) continue;
                    if (j < 0 || j >= MapCache.TILE_TOTAL_Y) continue;

                    byte f = MapCache.tiles[i, j];

                    if(f != 0){
                        buffer.gfx.DrawImage(ImageCache.RequestImage(MapCache.tileTable[f]), new Rectangle((int)Math.Floor((i * MapCache.TILE_SIZE_X - Camera.Offset.X) * Camera.ZoomLevel), (int)Math.Floor((j * MapCache.TILE_SIZE_Y - Camera.Offset.Y) * Camera.ZoomLevel), (int)Math.Ceiling(MapCache.TILE_SIZE_X * Camera.ZoomLevel), (int)Math.Ceiling(MapCache.TILE_SIZE_Y * Camera.ZoomLevel)));
                    }
                }
            }
        }

        public static void SetCurrentTile(byte newTile) {
            currentTile = newTile;
            currentTileIm = ImageCache.RequestImage(MapCache.tileTable[newTile]);
        }

        internal static byte StripTileIDFromPath(string pathName) {
            int i1 = pathName.LastIndexOf('\\');
            int i2 = pathName.LastIndexOf('.');

            string ttt = pathName.Substring(i1 + 1, i2 - i1 - 1);
            return byte.Parse(ttt);
        }
    }
}
