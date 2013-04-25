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
        public const byte SLIDING_NONE = 0;
        public const byte SLIDING_LEFT = 1;
        public const byte SLIDING_RIGHT = 2;
        public const byte SLIDING_TOP = 3;
        public const byte SLIDING_BOTTOM = 4;
        public const byte SLIDING_DIRECTIONOFTRAVEL = 5;

        public const int PIXELS_X = 48; //The width of a single image block
        public const int PIXELS_Y = 48; //The height of a single image block

        //Editor Information
        public short TileID = 0;
        public string TileName = "Unknown";
        public string TileGroup = "Unknown";

        public List<Rectangle> Collision = new List<Rectangle>();

        //Animation Information
        public AnimatedObject Animation;

        //Gameplay Information
        public short damageElement = 0; // 0 = No damage, everything else is the ID of the damaging element (8 bits)
        public short damagePerSecond = 0;

        public float movementCost = 1; // 1 = normal, 2 = twice as slow, 0.5 = twice as fast (32 bits)
        public byte slidingDirection = SLIDING_NONE; //0=none, 1=left, 2=right, 3=top, 4=bottom, 5=direction of travel (3 bits)

        internal void LoadFromFile(General.BinaryIO f) {
            TileID = f.GetShort();
            TileName = f.GetString();
            TileGroup = f.GetString();

            Animation = AnimatedObject.UnpackFromBinaryIO(f);

            movementCost = f.GetFloat();
            slidingDirection = f.GetByte();
            
            damageElement = f.GetShort();
            damagePerSecond = f.GetShort();

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
            f.AddByte(slidingDirection);

            f.AddShort(damageElement);
            f.AddShort(damagePerSecond);

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
