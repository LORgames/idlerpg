using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;

namespace ToolCache.Map.Tiles {
    public class TileCache {
        private const string DATABASE_NAME = "db_tiles.bin";
        private const string RESOLVED_NAME = Settings.CACHE + DATABASE_NAME;

        private static Dictionary<short, Tile> tiles = new Dictionary<short, Tile>();

        public static void Initialize() {
            tiles.Clear();
            ReadDatabase();
        }

        public static Tile G(short id) {
            if (tiles.ContainsKey(id)) {
                return tiles[id];
            }

            return null;
        }

        private static void ReadDatabase() {
            // Load object types from file
            if (File.Exists(RESOLVED_NAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(RESOLVED_NAME));

                int totalTilesInFile = f.GetShort();

                //This is where we load the BASIC information
                for (int i = 0; i < totalTilesInFile; i++) {
                    Tile t = new Tile();
                    t.LoadFromFile(f);
                }
            }
        }

    }
}
