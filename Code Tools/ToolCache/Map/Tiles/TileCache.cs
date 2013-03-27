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
        private static Dictionary<string, List<short>> GroupsToTileUUIDS = new Dictionary<string, List<short>>();

        private static short nextTileID = 0;

        internal static Dictionary<short, Tile> Tiles {
            get { return tiles; }
        }

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

                    tiles.Add(t.TileID, t);

                    if (t.TileID >= nextTileID) {
                        nextTileID = t.TileID;
                        nextTileID++;
                    }
                }
            }
        }

        internal static void SaveDatabase() {
            // Load object types from file
            BinaryIO f = new BinaryIO();

            f.AddShort((short)tiles.Count);

            //This is where we load the BASIC information
            foreach(KeyValuePair<short, Tile> kvp in tiles) {
                kvp.Value.SaveToFile(f);
            }

            f.Encode(RESOLVED_NAME);
        }

        internal static void AddTile(Tile t) {
            if (tiles.ContainsKey(t.TileID)) {
                GroupsToTileUUIDS[tiles[t.TileID].TileGroup].Remove(t.TileID);

                if (GroupsToTileUUIDS[tiles[t.TileID].TileGroup].Count == 0) {
                    GroupsToTileUUIDS.Remove(tiles[t.TileID].TileGroup);
                }
            }

            tiles.Add(t.TileID, t);

            if (!GroupsToTileUUIDS.ContainsKey(t.TileGroup)) {
                GroupsToTileUUIDS.Add(t.TileGroup, new List<short>());
            }

            GroupsToTileUUIDS[t.TileGroup].Add(t.TileID);

            if (t.TileID >= nextTileID) {
                nextTileID = t.TileID;
                nextTileID++;
            }
        }

        public static List<string> GetGroups() {
            return GroupsToTileUUIDS.Keys.ToList<String>();
        }

        public static short NextID() {
            return nextTileID;
        }

        internal static void Delete(short tileID) {
            if (tiles.ContainsKey(tileID)) {
                if (GroupsToTileUUIDS.ContainsKey(tiles[tileID].TileGroup)) {
                    GroupsToTileUUIDS[tiles[tileID].TileGroup].Remove(tileID);

                    if (GroupsToTileUUIDS[tiles[tileID].TileGroup].Count == 0) {
                        GroupsToTileUUIDS.Remove(tiles[tileID].TileGroup);
                    }
                }

                tiles.Remove(tileID);
            }
        }
    }
}
