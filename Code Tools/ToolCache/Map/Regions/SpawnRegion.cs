using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using System.Windows.Forms;

namespace ToolCache.Map.Regions {
    public class SpawnRegion {
        public List<Rectangle> Areas = new List<Rectangle>();
        public List<CritterSpawn> SpawnList = new List<CritterSpawn>();
        public string Name = "Unnamed Spawn";

        public byte SpawnOnLoad = 1;
        public byte MaxSpawn = 10;
        public short Timeout = 60;

        public static SpawnRegion LoadFromBinaryIO(BinaryIO f) {
            SpawnRegion s = new SpawnRegion();

            s.Name = f.GetString();

            s.SpawnOnLoad = f.GetByte();
            s.MaxSpawn = f.GetByte();
            s.Timeout = f.GetShort();

            int totalAreas = f.GetByte(); //How many rectangles

            while (--totalAreas > -1) {
                Rectangle area = new Rectangle();
                area.X = f.GetShort();
                area.Y = f.GetShort();
                area.Width = f.GetShort();
                area.Height = f.GetShort();
                s.Areas.Add(area);
            }

            int totalSpawns = (int)f.GetByte();

            while (--totalSpawns > -1) {
                s.SpawnList.Add(CritterSpawn.LoadFromBinaryIO(f));
            }

            return s;
        }

        public void SaveToBinaryIO(BinaryIO f) {
            f.AddString(Name);

            f.AddByte(SpawnOnLoad);
            f.AddByte(MaxSpawn);
            f.AddShort(Timeout);

            CleanUpAreas();

            f.AddByte((byte)Areas.Count); //How many rectangles?

            foreach (Rectangle r in Areas) {
                f.AddShort((short)r.X);
                f.AddShort((short)r.Y);
                f.AddShort((short)r.Width);
                f.AddShort((short)r.Height);
            }

            f.AddByte((byte)SpawnList.Count);

            foreach (CritterSpawn spawn in SpawnList) {
                spawn.WriteToBinaryIO(f);
            }
        }

        private void CleanUpAreas() {
            int i = Areas.Count;
            while (--i > -1) {
                if (Areas[i].Width == 0 || Areas[i].Height == 0) {
                    Areas.RemoveAt(i);
                }
            }
        }

        public override string ToString() {
            return Name;
        }

        public void Move(int x, int y) {
            foreach (Rectangle Area in Areas) {
                Area.Offset(x, y);
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
