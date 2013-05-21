using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;

namespace ToolCache.Map.Regions {
    public class SpawnRegion {
        public Rectangle Area = new Rectangle();
        public List<CritterSpawn> SpawnList = new List<CritterSpawn>();
        public string Name = "Unnamed Spawn";

        public short SpawnOnLoad = 1;
        public short MaxSpawn = 10;
        public short Timeout = 60;

        public static SpawnRegion LoadFromBinaryIO(BinaryIO f) {
            SpawnRegion s = new SpawnRegion();

            s.Name = f.GetString();

            s.SpawnOnLoad = f.GetShort();
            s.MaxSpawn = f.GetShort();
            s.Timeout = f.GetShort();

            s.Area.X = f.GetShort();
            s.Area.Y = f.GetShort();
            s.Area.Width = f.GetShort();
            s.Area.Height = f.GetShort();

            int totalSpawns = (int)f.GetByte();

            while (--totalSpawns > -1) {
                s.SpawnList.Add(CritterSpawn.LoadFromBinaryIO(f));
            }

            return s;
        }

        public void SaveToBinaryIO(BinaryIO f) {
            f.AddString(Name);

            f.AddShort(SpawnOnLoad);
            f.AddShort(MaxSpawn);
            f.AddShort(Timeout);

            f.AddShort((short)Area.X);
            f.AddShort((short)Area.Y);
            f.AddShort((short)Area.Width);
            f.AddShort((short)Area.Height);

            f.AddByte((byte)SpawnList.Count);

            foreach (CritterSpawn spawn in SpawnList) {
                spawn.WriteToBinaryIO(f);
            }
        }

        public override string ToString() {
            return Name;
        }
    }
}
