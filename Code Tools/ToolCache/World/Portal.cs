using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using ToolCache.General;
using System.Drawing;

namespace ToolCache.World {
    public class Portal : IComparable<Portal> {

        public string Name;

        public short ID;
        public short ExitID; //Can be -1 if this portal doesn't link anywhere
        public byte Direction;

        public Point ExitPoint = Point.Empty;
        public Point EntryPoint = Point.Empty;
        public Size EntrySize = Size.Empty;

        public MapPiece Map;

        internal void Save(BinaryIO f) {
            f.AddString(Name);
            f.AddShort(ID);
            f.AddShort(ExitID);
            f.AddByte(Direction);

            f.AddShort((short)ExitPoint.X);
            f.AddShort((short)ExitPoint.Y);
            f.AddShort((short)EntryPoint.X);
            f.AddShort((short)EntryPoint.Y);
            f.AddShort((short)EntrySize.Width);
            f.AddShort((short)EntrySize.Height);
        }

        public override string ToString() {
            return Name + " (" + ID + ")";
        }

        public int CompareTo(Portal other) {
            return this.ID.CompareTo(other.ID);
        }

        public void Move(int x, int y) {
            ExitPoint.Offset(x, y);
            EntryPoint.Offset(x, y);
        }
    }

    public class Portals {
        public static Dictionary<short, Portal> Data = new Dictionary<short, Portal>();
        private static short NextID = 0;

        public static Portal CreatePortal(MapPiece map) {
            Portal p = new Portal();

            p.Name = "Unnamed Portal";
            p.Map = map;
            
            p.ID = NextID++;
            p.ExitID = p.ID;

            p.Direction = 0;

            p.Map.Portals.Add(p);
            p.Map.Edited();

            Portals.Data.Add(p.ID, p);

            return p;
        }

        public static Portal LoadPortal(MapPiece map, BinaryIO f) {
            Portal p = new Portal();
            p.Map = map;

            p.Name = f.GetString();
            p.ID = f.GetShort();
            p.ExitID = f.GetShort();
            p.Direction = f.GetByte();

            p.ExitPoint.X = f.GetShort();
            p.ExitPoint.Y = f.GetShort();
            p.EntryPoint.X = f.GetShort();
            p.EntryPoint.Y = f.GetShort();
            p.EntrySize.Width = f.GetShort();
            p.EntrySize.Height = f.GetShort();

            p.Map.Portals.Add(p);

            while (p.ID >= NextID) {
                NextID = p.ID;
                NextID++;
            }

            if (Portals.Data.ContainsKey(p.ID)) {
                Portals.Data[p.ID] = p;
            } else {
                Portals.Data.Add(p.ID, p);
            }

            return p;
        }
    }
}
