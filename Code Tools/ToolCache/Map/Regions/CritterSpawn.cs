using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Map.Regions {
    public class CritterSpawn {
        public short critterID = -1;
        public byte minCritters = 1;
        public byte maxCritters = 1;
        public float spawnChance = 100.0f;

        internal static CritterSpawn LoadFromBinaryIO(BinaryIO f) {
            CritterSpawn c = new CritterSpawn();

            c.critterID = f.GetShort();
            c.minCritters = f.GetByte();
            c.maxCritters = f.GetByte();
            c.spawnChance = f.GetFloat();

            return c;
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddShort(critterID);
            f.AddByte(minCritters);
            f.AddByte(maxCritters);
            f.AddFloat(spawnChance);
        }
    }
}
