using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CityTools.Components;
using CityTools.Core;

namespace CityTools.Terrain {
    public class MapCache {
        public const string MAP_FILENAME = Program.CACHE + "map.db";
        public const string TILE_DIRECTORY = ".\\Tiles\\";

        public const int TILE_SIZE_X = 48; //The width of a single image block
        public const int TILE_SIZE_Y = 48; //The height of a single image block

        public static int TILE_TOTAL_X = 1; //How many image blocks across
        public static int TILE_TOTAL_Y = 1; //How many image blocks down

        public static Dictionary<short, Tile> tileTable = new Dictionary<short, Tile>();

        public static short[,] tiles;

        public static void VerifyCacheFiles() {
            // Create the map thing
            foreach (string file in Directory.GetFiles(TILE_DIRECTORY, "*.png", SearchOption.AllDirectories)) {
                short tileIndex = TerrainHelper.StripTileIDFromPath(file);

                if (tileTable.ContainsKey(tileIndex)) {
                    tileTable[tileIndex].isAnimated = true;
                    tileTable[tileIndex].TilesImages.Add(file);
                } else {
                    Tile newTile = new Tile();
                    newTile.TileID = tileIndex;
                    newTile.TilesImages.Add(file);

                    tileTable.Add(tileIndex, newTile);
                }
            }

            CreateMapFromNothing();

            return;
        }

        public static void CreateMapFromNothing() {
            TILE_TOTAL_X = 50;
            TILE_TOTAL_Y = 50;

            tiles = new short[TILE_TOTAL_X, TILE_TOTAL_Y];

            for (int i = 0; i < TILE_TOTAL_X; i++) {
                for (int j = 0; j < TILE_TOTAL_Y; j++) {
                    tiles[i, j] = 0;
                }
            }
        }

        public static void LoadMapFromFile(BinaryIO mapFile) {
            TILE_TOTAL_X = mapFile.GetInt();
            TILE_TOTAL_Y = mapFile.GetInt();

            tiles = new short[TILE_TOTAL_X, TILE_TOTAL_Y];

            for (int i = 0; i < TILE_TOTAL_X; i++) {
                for (int j = 0; j < TILE_TOTAL_Y; j++) {
                    tiles[i, j] = mapFile.GetShort();
                }
            }

            MainWindow.instance.txtMapSizeX.Text = TILE_TOTAL_X.ToString();
            MainWindow.instance.txtMapSizeY.Text = TILE_TOTAL_Y.ToString();
        }

        public static void SaveMap(BinaryIO mapFile) {
            mapFile.AddInt(TILE_TOTAL_X);
            mapFile.AddInt(TILE_TOTAL_Y);

            for (int i = 0; i < TILE_TOTAL_X; i++) {
                for (int j = 0; j < TILE_TOTAL_Y; j++) {
                    mapFile.AddShort(tiles[i, j]);
                }
            }
        }

        public static void TerrainChangeSizeTo(int newSizeW, int newSizeH) {
            short[,] newTiles = new short[newSizeW, newSizeH];

            int oldTotalTilesX = TILE_TOTAL_X;
            int oldTotalTilesY = TILE_TOTAL_Y;
            
            TILE_TOTAL_X = newSizeW;
            TILE_TOTAL_Y = newSizeH;

            int extendX = MainWindow.instance.cbMapExtendX.SelectedIndex;
            int extendY = MainWindow.instance.cbMapExtendY.SelectedIndex;

            int effectiveX = 0;
            int effectiveY = 0;

            int sizeDifX = newSizeW - oldTotalTilesX;
            int sizeDifY = newSizeH - oldTotalTilesY;

            for (int i = 0; i < newSizeW; i++) {
                for (int j = 0; j < newSizeH; j++) {
                    effectiveX = (extendX==0)?i:(extendX==2?i-(oldTotalTilesX-1):i-sizeDifX/2);
                    effectiveY = (extendY==0)?j:(extendY==2?j-(oldTotalTilesY-1):j-sizeDifY/2);

                    System.Diagnostics.Debug.WriteLine("XY: " + sizeDifX + ", " + sizeDifY + " => " + effectiveX + ", " + effectiveY + " && " + oldTotalTilesX + ", " + oldTotalTilesY);

                    if (effectiveX >= 0 && effectiveX < oldTotalTilesX && effectiveY >= 0 && effectiveY < oldTotalTilesY) {
                        newTiles[i, j] = tiles[effectiveX, effectiveY];
                    } else {
                        newTiles[i, j] = 0;
                    }
                }
            }

            tiles = newTiles;
        }

        public class Tile {
            public short TileID = 0;
            public List<String> TilesImages = new List<string>();
            public bool isAnimated = false;
        }
    }
}
