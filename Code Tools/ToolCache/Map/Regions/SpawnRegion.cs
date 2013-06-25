﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;

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

        public override string ToString() {
            return Name;
        }

        public void Move(int x, int y) {
            foreach (Rectangle Area in Areas) {
                Area.Offset(x, y);
            }
        }
    }
}
