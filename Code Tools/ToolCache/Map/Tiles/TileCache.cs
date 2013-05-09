using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;

namespace ToolCache.Map.Tiles {
    public class TileCache {
        private const string FILENAME = Settings.Database + "Tiles.bin";

        private static Dictionary<short, TileTemplate> tiles = new Dictionary<short, TileTemplate>();
        private static Dictionary<string, List<short>> GroupsToTileUUIDS = new Dictionary<string, List<short>>();

        private static short nextTileID = 0;

        public static Dictionary<short, TileTemplate> Tiles {
            get { return tiles; }
        }

        public static void Initialize() {
            tiles.Clear();
            GroupsToTileUUIDS.Clear();

            nextTileID = 0;

            ReadDatabase();
        }

        public static TileTemplate G(short id) {
            if (tiles.ContainsKey(id)) {
                return tiles[id];
            }

            return null;
        }

        private static void ReadDatabase() {
            // Load object types from file
            if (File.Exists(FILENAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(FILENAME));

                int totalTilesInFile = f.GetShort();

                //This is where we load the BASIC information
                for (int i = 0; i < totalTilesInFile; i++) {
                    TileTemplate t = new TileTemplate();
                    t.LoadFromFile(f);

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
            }
        }

        public static void SaveDatabase() {
            // Load object types from file
            BinaryIO f = new BinaryIO();

            f.AddShort((short)tiles.Count);

            //This is where we load the BASIC information
            foreach(KeyValuePair<short, TileTemplate> kvp in tiles) {
                kvp.Value.SaveToFile(f);
            }

            f.Encode(FILENAME);
        }

        public static void AddTile(TileTemplate t) {
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

        public static void Delete(short tileID) {
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

        public static List<TileTemplate> GetTilesInGroup(string p) {
            List<TileTemplate> retList = new List<TileTemplate>();

            if (GroupsToTileUUIDS.ContainsKey(p)) {
                foreach (short id in GroupsToTileUUIDS[p]) {
                    retList.Add(tiles[id]);
                }
            }

            return retList;
        }
    }
}
