using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using ToolCache.General;
using System.Drawing;

namespace ToolCache.Equipment {
    public class EquipmentAnimationSet {
        public string SetName = "Default";

        public AnimatedObject Left;
        public AnimatedObject Right;
        public AnimatedObject Up;
        public AnimatedObject Down;

        public Point LinkTop_Left = Point.Empty;
        public Point LinkTop_Right = Point.Empty;
        public Point LinkTop_Up = Point.Empty;
        public Point LinkTop_Down = Point.Empty;

        public Point LinkBottom_Left = Point.Empty;
        public Point LinkBottom_Right = Point.Empty;
        public Point LinkBottom_Up = Point.Empty;
        public Point LinkBottom_Down = Point.Empty;

        public AnimatedObject GetAnimation(Direction d) {
            switch (d) {
                case Direction.Left:
                    return Left;
                case Direction.Right:
                    return Right;
                case Direction.Up:
                    return Up;
                default:
                    return Down;
            }
        }

        internal static EquipmentAnimationSet LoadFromBinaryIO(BinaryIO f) {
            EquipmentAnimationSet eas = new EquipmentAnimationSet();

            //Set information
            eas.SetName = f.GetString();

            //Unpack animations
            eas.Left = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Right = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Up = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Down = AnimatedObject.UnpackFromBinaryIO(f);

            //LOAD TOP LINKS
            eas.LinkTop_Left.X = f.GetShort();
            eas.LinkTop_Left.Y = f.GetShort();

            eas.LinkTop_Right.X = f.GetShort();
            eas.LinkTop_Right.Y = f.GetShort();

            eas.LinkTop_Up.X = f.GetShort();
            eas.LinkTop_Up.Y = f.GetShort();

            eas.LinkTop_Down.X = f.GetShort();
            eas.LinkTop_Down.Y = f.GetShort();
            
            //LOAD BOTTOM LINKS
            eas.LinkBottom_Left.X = f.GetShort();
            eas.LinkBottom_Left.Y = f.GetShort();

            eas.LinkBottom_Right.X = f.GetShort();
            eas.LinkBottom_Right.Y = f.GetShort();

            eas.LinkBottom_Up.X = f.GetShort();
            eas.LinkBottom_Up.Y = f.GetShort();

            eas.LinkBottom_Down.X = f.GetShort();
            eas.LinkBottom_Down.Y = f.GetShort();

            return eas;
        }

        internal void SaveToBinaryIO(BinaryIO f) {
            //Set information
            f.AddString(SetName);

            //Unpack animations
            Left.PackIntoBinaryIO(f);
            Right.PackIntoBinaryIO(f);
            Up.PackIntoBinaryIO(f);
            Down.PackIntoBinaryIO(f);

            //LOAD TOP LINKS
            f.AddShort((short)LinkTop_Left.X);
            f.AddShort((short)LinkTop_Left.Y);

            f.AddShort((short)LinkTop_Right.X);
            f.AddShort((short)LinkTop_Right.Y);

            f.AddShort((short)LinkTop_Up.X);
            f.AddShort((short)LinkTop_Up.Y);

            f.AddShort((short)LinkTop_Down.X);
            f.AddShort((short)LinkTop_Down.Y);

            //LOAD BOTTOM LINKS
            f.AddShort((short)LinkBottom_Left.X);
            f.AddShort((short)LinkBottom_Left.Y);

            f.AddShort((short)LinkBottom_Right.X);
            f.AddShort((short)LinkBottom_Right.Y);

            f.AddShort((short)LinkBottom_Up.X);
            f.AddShort((short)LinkBottom_Up.Y);

            f.AddShort((short)LinkBottom_Down.X);
            f.AddShort((short)LinkBottom_Down.Y);
        }

    }
}
