using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using ToolCache.General;

namespace ToolCache.Map.Tiles {
    public class Tile {
        //Some constants
        public const byte ACCESS_LEFT = 1;
        public const byte ACCESS_RIGHT = 2;
        public const byte ACCESS_TOP = 4;
        public const byte ACCESS_BOTTOM = 8;

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

        //Animation Information
        public AnimatedObject Animation;

        //Gameplay Information
        public Boolean isWalkable = true; //(1 bit)
        public byte elementalDamage = 0; // 0 = No damage, everything else is the ID of the damaging element (8 bits)
        public float movementCost = 1; // 1 = normal, 2 = twice as slow, 0.5 = twice as fast (32 bits)
        public byte directionalAccess = 15; //Which directions tile can be accessed from bitwise LRTB order (4bits)
        public byte slidingDirection = 0; //0=none, 1=left, 2=right, 3=top, 4=bottom, 5=direction of travel (3 bits)

        internal void LoadFromFile(General.BinaryIO f) {
            TileID = f.GetShort();
            TileName = f.GetString();
            TileGroup = f.GetString();

            Animation = AnimatedObject.UnpackFromBinaryIO(f);

            isWalkable = f.GetByte() == 1;
            elementalDamage = f.GetByte();
            movementCost = f.GetFloat();
            directionalAccess = f.GetByte();
            slidingDirection = f.GetByte();
        }

        internal void SaveToFile(BinaryIO f) {
            f.AddShort(TileID);
            f.AddString(TileName);
            f.AddString(TileGroup);

            Animation.PackIntoBinaryIO(f);

            f.AddByte(isWalkable ? (byte)1 : (byte)0);
            f.AddByte(elementalDamage);
            f.AddFloat(movementCost);
            f.AddByte(directionalAccess);
            f.AddByte(slidingDirection);
        }
    }
}
