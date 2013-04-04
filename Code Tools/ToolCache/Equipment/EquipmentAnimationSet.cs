using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Animation;
using ToolCache.General;
using System.Drawing;

namespace ToolCache.Equipment {
    public class EquipmentAnimationSet {
        public States State = States.Default;

        public AnimatedObject Left_0;
        public AnimatedObject Right_0;
        public AnimatedObject Up_0;
        public AnimatedObject Down_0;

        public AnimatedObject Left_1;
        public AnimatedObject Right_1;
        public AnimatedObject Up_1;
        public AnimatedObject Down_1;

        public Point LinkTop_Left = Point.Empty;
        public Point LinkTop_Right = Point.Empty;
        public Point LinkTop_Up = Point.Empty;
        public Point LinkTop_Down = Point.Empty;

        public Point LinkBottom_Left = Point.Empty;
        public Point LinkBottom_Right = Point.Empty;
        public Point LinkBottom_Up = Point.Empty;
        public Point LinkBottom_Down = Point.Empty;

        public EquipmentAnimationSet(bool initialize = true) {
            if (initialize) {
                Left_0 = new AnimatedObject();
                Right_0 = new AnimatedObject();
                Up_0 = new AnimatedObject();
                Down_0 = new AnimatedObject();

                Left_1 = new AnimatedObject();
                Right_1 = new AnimatedObject();
                Up_1 = new AnimatedObject();
                Down_1 = new AnimatedObject();
            }
        }

        public AnimatedObject GetAnimation(Direction d, int layer) {
            switch (d) {
                case Direction.Left:
                    return (layer == 0 ? Left_0 : Left_1);
                case Direction.Right:
                    return (layer == 0 ? Right_0 : Right_1);
                case Direction.Up:
                    return (layer == 0 ? Up_0 : Up_1);
                default:
                    return (layer == 0 ? Down_0 : Down_1);
            }
        }

        internal static EquipmentAnimationSet LoadFromBinaryIO(BinaryIO f) {
            EquipmentAnimationSet eas = new EquipmentAnimationSet(false);

            //Set information
            eas.State = (States)f.GetByte();

            //Unpack animations
            eas.Left_0 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Right_0 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Up_0 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Down_0 = AnimatedObject.UnpackFromBinaryIO(f);

            eas.Left_1 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Right_1 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Up_1 = AnimatedObject.UnpackFromBinaryIO(f);
            eas.Down_1 = AnimatedObject.UnpackFromBinaryIO(f);

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
            f.AddByte((byte)State);

            //Unpack animations
            Left_0.PackIntoBinaryIO(f);
            Right_0.PackIntoBinaryIO(f);
            Up_0.PackIntoBinaryIO(f);
            Down_0.PackIntoBinaryIO(f);

            Left_1.PackIntoBinaryIO(f);
            Right_1.PackIntoBinaryIO(f);
            Up_1.PackIntoBinaryIO(f);
            Down_1.PackIntoBinaryIO(f);

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
