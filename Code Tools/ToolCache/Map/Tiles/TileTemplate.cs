using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using ToolCache.General;
using ToolCache.Map.Objects;
using System.Drawing;

namespace ToolCache.Map.Tiles {
    public class TileTemplate {
        //Some constants
        public const int PIXELS = 48;

        //Editor Information
        public short TileID = 0;
        public string TileName = "Unknown";
        public string TileGroup = "Unknown";

        public List<Rectangle> Collision = new List<Rectangle>();

        //Animation Information
        public AnimatedObject Animation;

        //Gameplay Information
        public float movementCost = 1; // 1 = normal, 2 = twice as slow, 0.5 = twice as fast (32 bits)

        internal void LoadFromFile(General.BinaryIO f) {
            TileID = f.GetShort();
            TileName = f.GetString();
            TileGroup = f.GetString();

            Animation = AnimatedObject.UnpackFromBinaryIO(f);

            movementCost = f.GetFloat();

            int i = f.GetByte();
            while (--i > -1) {
                Collision.Add(new Rectangle(f.GetShort(), f.GetShort(), f.GetShort(), f.GetShort()));
            }
        }

        internal void SaveToFile(BinaryIO f) {
            f.AddShort(TileID);
            f.AddString(TileName);
            f.AddString(TileGroup);

            Animation.PackIntoBinaryIO(f);

            f.AddFloat(movementCost);

            f.AddByte((byte)Collision.Count);
            foreach (Rectangle r in Collision) {
                f.AddShort((short)r.X);
                f.AddShort((short)r.Y);
                f.AddShort((short)r.Width);
                f.AddShort((short)r.Height);
            }
        }

        public override string ToString() {
            return TileName + " (" + TileID + ")";
        }

    }
}
