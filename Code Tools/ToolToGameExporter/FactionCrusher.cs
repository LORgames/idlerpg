using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Critters;
using System.IO;
using ToolCache.General;

namespace ToolToGameExporter {
    internal class FactionCrusher {
        public static Dictionary<string, int> RemappedFactionIDs = new Dictionary<string, int>();

        public static void Go() {
            RemappedFactionIDs.Clear();

            List<String> factions = Factions.FactionNames();

            if (factions.Count > 32) { //32 because using 32bit ints to store the data.
                Processor.Errors.Add(new ProcessingError("Factions", "All", "Currently only supporting 32 total factions."));
                return;
            }

            BinaryIO b = new BinaryIO();

            b.AddByte((byte)factions.Count);

            for (int i = 0; i < factions.Count; i++) {
                String f1 = factions[i];
                int myFriends = 0;
                int myEnemies = 0;

                RemappedFactionIDs.Add(f1, i);

                for (int j = 0; j < factions.Count; j++) {
                    String f2 = factions[j];
                    int type = Factions.GetRelationship(f1, f2);
                    if (type == 1) { //Friends
                        myFriends |= 0x1 << j;
                    } else if (type == 2) { //Enemies
                        myEnemies |= 0x1 << i;
                    }
                }

                b.AddInt(myFriends);
                b.AddInt(myEnemies);
            }

            b.Encode(Global.EXPORT_DIRECTORY + "/Factions.bin");
        }
    }
}
