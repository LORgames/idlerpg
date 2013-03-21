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

        public static Dictionary<byte, string> tileTable = new Dictionary<byte, string>();

        public static byte[,] tiles;

        public static void VerifyCacheFiles() {
            // Create the map thing
            foreach (string file in Directory.GetFiles(TILE_DIRECTORY, "*.png", SearchOption.AllDirectories)) {
                byte tileIndex = TerrainHelper.StripTileIDFromPath(file);

                if (tileTable.ContainsKey(tileIndex)) {
                    MessageBox.Show("Both " + tileTable[tileIndex] + " and " + file + " are tile #" + tileIndex + "\n\nIgnoring: " + file);
                } else {
                    tileTable.Add(tileIndex, file);
                }
            }

            CreateMapFromNothing();

            return;
        }

        public static void CreateMapFromNothing() {
            TILE_TOTAL_X = 20;
            TILE_TOTAL_Y = 20;

            tiles = new byte[TILE_TOTAL_X, TILE_TOTAL_Y];

            for (int i = 0; i < TILE_TOTAL_X; i++) {
                for (int j = 0; j < TILE_TOTAL_Y; j++) {
                    tiles[i, j] = 1;
                }
            }
        }

        public static void LoadMapFromFile(BinaryIO mapFile) {
            TILE_TOTAL_X = mapFile.GetInt();
            TILE_TOTAL_Y = mapFile.GetInt();

            tiles = new byte[TILE_TOTAL_X, TILE_TOTAL_Y];

            for (int i = 0; i < TILE_TOTAL_X; i++) {
                for (int j = 0; j < TILE_TOTAL_Y; j++) {
                    tiles[i, j] = mapFile.GetByte();
                }
            }
        }

        public static void SaveMap(BinaryIO mapFile) {
            mapFile.AddInt(TILE_TOTAL_X);
            mapFile.AddInt(TILE_TOTAL_Y);

            for (int i = 0; i < TILE_TOTAL_X; i++) {
                for (int j = 0; j < TILE_TOTAL_Y; j++) {
                    mapFile.AddByte(tiles[i, j]);
                }
            }
        }
    }
}
