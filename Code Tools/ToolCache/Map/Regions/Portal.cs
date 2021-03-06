﻿using System;
using System.Collections.Generic;
using System.Drawing;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.Map.Regions {
    public class Portal : IComparable<Portal> {
        public string Name;

        public short ID;
        public short ExitID; //Can be -1 if this portal doesn't link anywhere
        public byte Direction;

        public Point EntryPoint = Point.Empty;
        public Size EntrySize = Size.Empty;

        public MapPiece Map;

        internal void Save(IStorage f) {
            f.AddString(Name);
            f.AddShort(ID);
            f.AddShort(ExitID);
            f.AddByte(Direction);

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

        public static Portal LoadPortal(MapPiece map, IStorage f) {
            Portal p = new Portal();
            p.Map = map;

            p.Name = f.GetString();
            p.ID = f.GetShort();
            p.ExitID = f.GetShort();
            p.Direction = f.GetByte();

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

        internal static short GetNextID() {
            return NextID++;
        }
    }
}
