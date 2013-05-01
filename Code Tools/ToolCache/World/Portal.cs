using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using ToolCache.General;

namespace ToolCache.World {
    public class Portal {
        
        public short ID;
        public short ExitID; //Can be -1 if this portal doesn't link anywhere
        public byte Direction;

        public MapPiece Map;

        internal void Save(BinaryIO f) {
            f.AddShort(ID);
            f.AddShort(ExitID);
            f.AddByte(Direction);
        }
    }

    public class Portals {
        public static Dictionary<short, Portal> Data = new Dictionary<short, Portal>();
        private static short NextID = 0;

        public static Portal CreatePortal(MapPiece map) {
            Portal p = new Portal();

            p.Map = map;
            p.ID = NextID++;
            p.Direction = 0;

            return p;
        }

        public static Portal LoadPortal(MapPiece map, BinaryIO f) {
            Portal p = new Portal();
            p.Map = map;

            p.ID = f.GetShort();
            p.ExitID = f.GetShort();
            p.Direction = f.GetByte();

            return p;
        }
    }
}
