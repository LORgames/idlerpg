using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;
using ToolCache.Storage;

namespace ToolCache.Critters {
    public class Factions {
        private const string DATABASE_FILENAME = "Factions";
        
        private static Dictionary<String, short> FactionNameToID = new Dictionary<string, short>();
        private static Dictionary<short, Faction> AllFactions = new Dictionary<short, Faction>();
        private static short NextID = 0;

        internal static void Initialize() {
            FactionNameToID.Clear();
            AllFactions.Clear();
            NextID = 0;

            ReadDatabase();
        }

        public static List<String> FactionNames() {
            return FactionNameToID.Keys.ToList<string>();
        }

        public static void AddFaction(string factionName) {
            if (FactionNameToID.Count >= 31) {
                System.Windows.Forms.MessageBox.Show("Cannot surpass 32 factions!");
                return;
            }

            if (!FactionNameToID.ContainsKey(factionName)) {
                FactionNameToID.Add(factionName, NextID);
                AllFactions.Add(NextID, new Faction(factionName, NextID));
                NextID++;
            }
        }

        public static void RemoveFaction(string factionName) {
            if (FactionNameToID.ContainsKey(factionName)) {
                AllFactions.Remove(FactionNameToID[factionName]);
                FactionNameToID.Remove(factionName);
            }
        }

        public static bool Has(string factionName) {
            return FactionNameToID.ContainsKey(factionName);
        }

        private static void ReadDatabase() {
            IStorage f = StorageHelper.LoadStorage(DATABASE_FILENAME, StorageTypes.UTF);

            if (f != null) {
                short totalFactions = f.GetShort();

                while (--totalFactions > -1) {
                    AddFaction(f.GetString());
                }

                short totalFriends = f.GetShort();
                short totalEnemies = f.GetShort();

                while (--totalFriends > -1) {
                    SetRelationship(f.GetShort(), f.GetShort(), 1);
                }

                while (--totalEnemies > -1) {
                    SetRelationship(f.GetShort(), f.GetShort(), 2);
                }

                f.Dispose();
            }
        }

        public static void SaveDatabase() {
            IStorage f = StorageHelper.WriteStorage(StorageTypes.UTF);

            List<short[]> FriendsPairs = new List<short[]>();
            List<short[]> EnemiesPairs = new List<short[]>();

            f.AddShort((short)AllFactions.Count);  //Repack from id 0 as well :)

            //Repacking ID's as required...
            Dictionary<int, int> RepackedIDs = new Dictionary<int, int>();
            int nextID = 0;

            foreach (KeyValuePair<short, Faction> kvp in AllFactions) {
                RepackedIDs.Add(kvp.Value.ID, nextID);
                nextID++;

                f.AddString(kvp.Value.Name);
            }


            foreach (Faction faction in AllFactions.Values) {
                foreach (short i in faction.Friends) {
                    if (faction.ID < i) {
                        FriendsPairs.Add(new short[] { faction.ID, i });
                    }
                }

                foreach (short i in faction.Enemies) {
                    if (faction.ID < i) {
                        EnemiesPairs.Add(new short[] { faction.ID, i });
                    }
                }
            }

            f.AddShort((short)FriendsPairs.Count); // 0 Allied Factions
            f.AddShort((short)EnemiesPairs.Count); // 0 Enemy Factions

            foreach (short[] ray in FriendsPairs) {
                f.AddShort(ray[0]);
                f.AddShort(ray[1]);
            }

            foreach (short[] ray in EnemiesPairs) {
                f.AddShort(ray[0]);
                f.AddShort(ray[1]);
            }

            StorageHelper.Save(f, DATABASE_FILENAME);

            f.Dispose();

            Initialize(); //Dump everything and load it back up to reset the numbers
        }

        public static int GetRelationship(string faction1, string faction2) {
            if (FactionNameToID.ContainsKey(faction1) && FactionNameToID.ContainsKey(faction2)) {
                short factionX = FactionNameToID[faction1];
                short factionY = FactionNameToID[faction2];

                return GetRelationship(factionX, factionY);
            }

            return 0;
        }

        private static int GetRelationship(short faction1, short faction2) {
            if (faction1 == faction2 || AllFactions[faction1].Friends.Contains(faction2)) {
                return 1;
            } else if (AllFactions[faction1].Enemies.Contains(faction2)) {
                return 2;
            }

            return 0;
        }

        public static void SetRelationship(string faction1, string faction2, int newRelationship) {
            if (FactionNameToID.ContainsKey(faction1) && FactionNameToID.ContainsKey(faction2)) {
                short factionX = FactionNameToID[faction1];
                short factionY = FactionNameToID[faction2];

                SetRelationship(factionX, factionY, newRelationship);
            }
        }


        private static void SetRelationship(short faction1, short faction2, int newRelationship) {
            int currentRelationship = GetRelationship(faction1, faction2);

            if (currentRelationship == newRelationship) return;

            if (currentRelationship == 1) { //Friends
                AllFactions[faction1].Friends.Remove(faction2);
                AllFactions[faction2].Friends.Remove(faction1);
            } else if (currentRelationship == 2) { //Enemies
                AllFactions[faction1].Enemies.Remove(faction2);
                AllFactions[faction2].Enemies.Remove(faction1);
            }

            if (newRelationship == 1) { //Friends
                AllFactions[faction1].Friends.Add(faction2);
                AllFactions[faction2].Friends.Add(faction1);
            } else if (newRelationship == 2) { //Enemies
                AllFactions[faction1].Enemies.Add(faction2);
                AllFactions[faction2].Enemies.Add(faction1);
            }
        }

        public static short GetID(string factionName) {
            if(FactionNameToID.ContainsKey(factionName)) return FactionNameToID[factionName];
            return -1;
        }
    }

    internal class Faction {
        public short ID = 0;
        public string Name = "";

        public List<short> Enemies = new List<short>();
        public List<short> Friends = new List<short>();

        public Faction(string factionName, short myID) {
            Name = factionName;
            ID = myID;
        }
    }
}
