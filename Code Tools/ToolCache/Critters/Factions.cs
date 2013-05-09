using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;

namespace ToolCache.Critters {
    public class Factions {
        private const string FILENAME = Settings.Database + "/Factions.bin";
        public static List<String> AllFactions = new List<String>();

        internal static void Initialize() {
            AllFactions.Clear();
            ReadDatabase();
        }

        private static void ReadDatabase() {
            BinaryIO b = new BinaryIO(File.ReadAllBytes(FILENAME));

            short totalFactions = b.GetShort();

            while (--totalFactions > -1) {
                AllFactions.Add(b.GetString());
            }

            b.Dispose();
        }

        public static void SaveDatabase() {
            BinaryIO b = new BinaryIO();

            b.AddShort((short)AllFactions.Count);

            foreach (String s in AllFactions) {
                b.AddString(s);
            }

            b.Encode(FILENAME);
            b.Dispose();
        }

    }
}
