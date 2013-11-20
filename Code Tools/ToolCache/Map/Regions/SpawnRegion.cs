using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using System.Windows.Forms;
using ToolCache.Storage;

namespace ToolCache.Map.Regions {
    public class SpawnRegion : RegionBase {
        public List<CritterSpawn> SpawnList = new List<CritterSpawn>();
        
        public byte SpawnOnLoad = 1;
        public byte MaxSpawn = 10;
        public short Timeout = 60;
        public string Faction = "";

        public static SpawnRegion LoadFromBinaryIO(IStorage f) {
            SpawnRegion s = new SpawnRegion();

            UnpackNameAndAreas(f, s);

            s.SpawnOnLoad = f.GetByte();
            s.MaxSpawn = f.GetByte();
            s.Timeout = f.GetShort();
            s.Faction = f.GetString();

            int totalSpawns = (int)f.GetByte();

            while (--totalSpawns > -1) {
                s.SpawnList.Add(CritterSpawn.LoadFromBinaryIO(f));
            }

            return s;
        }

        public void SaveToBinaryIO(IStorage f) {
            WriteNameAndAreas(f);

            f.AddByte(SpawnOnLoad);
            f.AddByte(MaxSpawn);
            f.AddShort(Timeout);
            f.AddString(Faction);

            f.AddByte((byte)SpawnList.Count);

            foreach (CritterSpawn spawn in SpawnList) {
                spawn.WriteToBinaryIO(f);
            }
        }

        public bool FixSpawnRates() {
            float totalPercent = 0;

            foreach (CritterSpawn c in SpawnList) {
                totalPercent += c.spawnChance;
            }

            totalPercent /= 100;

            if (totalPercent != 100) {
                foreach (CritterSpawn c in SpawnList) {
                    c.spawnChance = c.spawnChance / totalPercent;
                }

                return true;
            } else {
                return false;
            }
        }
    }
}
