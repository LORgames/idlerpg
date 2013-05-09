using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;

namespace ToolCache.Critters {
    public class CritterManager {
        public const string DATABASE_FILENAME = Settings.Database + "/Critters.bin";

        public static Dictionary<short, Critter> Critters = new Dictionary<short, Critter>();
        public static short NextCritterID = 0;

        public static List<string> BaseGroups = new List<string>();

        public static void Initialize() {
            Critters.Clear();

            NextCritterID = 0;
            ReadDatabase();
        }

        private static void ReadDatabase() {
            // Load object types from file
            if (File.Exists(DATABASE_FILENAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(DATABASE_FILENAME));

                short totalObjects = f.GetShort();

                for (int i = 0; i < totalObjects; i++) {
                    CritterTypes peakedType = (CritterTypes)f.GetByte();
                    Critter _Critter = null;

                    switch (peakedType) {
                        case CritterTypes.Humanoid:
                            _Critter = CritterHuman.LoadHumanoid(f); break;
                        case CritterTypes.NonHumanoid:
                            _Critter = CritterBeast.LoadBeastoid(f); break;
                    }

                    AddCritter(_Critter);
                }

                f.Dispose();
            }
        }

        public static void SaveDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)Critters.Count);

            foreach (Critter c in Critters.Values) {
                c.PackIntoBinaryIO(f);
            }

            f.Encode(DATABASE_FILENAME);
            f.Dispose();
        }

        public static void AddCritter(Critter critter) {
            if (critter != null) {
                if (critter.NodeGroup == "") critter.NodeGroup = "NoGroup";

                if (critter.ID == -1) {
                    critter.ID = NextCritterID;
                }

                Critters.Add(critter.ID, critter);

                if (!BaseGroups.Contains(critter.NodeGroup)) {
                    BaseGroups.Contains(critter.NodeGroup);
                }

                if (critter.ID >= NextCritterID) {
                    NextCritterID = critter.ID;
                    NextCritterID++;
                }
            }
        }

        public static void UpdatedCritter(Critter critter) {
            if (critter != null) {
                if (critter.NodeGroup == "") critter.NodeGroup = "NoGroup";

                if (!BaseGroups.Contains(critter.NodeGroup)) {
                    BaseGroups.Contains(critter.NodeGroup);
                }
            }
        }
    }
}
