using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.Drawing;
using ToolCache.Animation;

namespace ToolCache.Equipment {
    public class EquipmentItem {
        public Dictionary<States, EquipmentAnimationSet> Animations = new Dictionary<States, EquipmentAnimationSet>();

        public EquipmentTypes Type = EquipmentTypes.Body;
        public EquipmentTypes OldType = EquipmentTypes.Body;

        public string Name = "Unnamed";

        public bool isAvailableAtStart = false;

        public Point LinkTop_Left = Point.Empty;
        public Point LinkTop_Right = Point.Empty;
        public Point LinkTop_Up = Point.Empty;
        public Point LinkTop_Down = Point.Empty;

        public Point LinkBottom_Left = Point.Empty;
        public Point LinkBottom_Right = Point.Empty;
        public Point LinkBottom_Up = Point.Empty;
        public Point LinkBottom_Down = Point.Empty;

        public Point LinkMiddle_Left = Point.Empty;
        public Point LinkMiddle_Right = Point.Empty;
        public Point LinkMiddle_Up = Point.Empty;
        public Point LinkMiddle_Down = Point.Empty;

        public EquipmentItem(bool initialize = true) {
            if(initialize) VerifyAnimationSets();
        }

        public static EquipmentItem UnpackFromBinaryIO(BinaryIO f) {
            EquipmentItem t = new EquipmentItem(false);

            t.Name = f.GetString();
            t.Type = (EquipmentTypes)f.GetByte();

            t.isAvailableAtStart = (f.GetByte() == (byte)1 ? true : false);

            short totalAnimationSets = f.GetShort();

            for (short i = 0; i < totalAnimationSets; i++) {
                EquipmentAnimationSet eas = EquipmentAnimationSet.LoadFromBinaryIO(f);

                try {
                    t.Animations.Add(eas.State, eas);
                } catch {
                    //TODO: should do something here
                }
            }

            t.LinkBottom_Left.X = f.GetShort();
            t.LinkBottom_Left.Y = f.GetShort();
            
            t.LinkBottom_Right.X = f.GetShort();
            t.LinkBottom_Right.Y = f.GetShort();
            
            t.LinkBottom_Up.X = f.GetShort();
            t.LinkBottom_Up.Y = f.GetShort();
            
            t.LinkBottom_Down.X = f.GetShort();
            t.LinkBottom_Down.Y = f.GetShort();
            
            t.LinkTop_Left.X = f.GetShort();
            t.LinkTop_Left.Y = f.GetShort();
            
            t.LinkTop_Right.X = f.GetShort();
            t.LinkTop_Right.Y = f.GetShort();
            
            t.LinkTop_Up.X = f.GetShort();
            t.LinkTop_Up.Y = f.GetShort();
            
            t.LinkTop_Down.X = f.GetShort();
            t.LinkTop_Down.Y = f.GetShort();

            t.LinkMiddle_Left.X = f.GetShort();
            t.LinkMiddle_Left.Y = f.GetShort();
            
            t.LinkMiddle_Right.X = f.GetShort();
            t.LinkMiddle_Right.Y = f.GetShort();
            
            t.LinkMiddle_Up.X = f.GetShort();
            t.LinkMiddle_Up.Y = f.GetShort();
            
            t.LinkMiddle_Down.X = f.GetShort();
            t.LinkMiddle_Down.Y = f.GetShort();

            t.VerifyAnimationSets();

            return t;
        }

        private void VerifyAnimationSets() {
            foreach (States s in Enum.GetValues(typeof(States))) {
                if (!Animations.ContainsKey(s)) {
                    Animations.Add(s, new EquipmentAnimationSet(true, s));
                }
            }
        }

        public void PackIntoBinaryIO(BinaryIO f) {
            f.AddString(Name);
            f.AddByte((byte)Type);
            f.AddByte(isAvailableAtStart ? (byte)1 : (byte)0);

            f.AddShort((short)Animations.Count);

            foreach (EquipmentAnimationSet kvp in Animations.Values) {
                kvp.SaveToBinaryIO(f);
            }

            f.AddShort((short)LinkBottom_Left.X);
            f.AddShort((short)LinkBottom_Left.Y);

            f.AddShort((short)LinkBottom_Right.X);
            f.AddShort((short)LinkBottom_Right.Y);

            f.AddShort((short)LinkBottom_Up.X);
            f.AddShort((short)LinkBottom_Up.Y);

            f.AddShort((short)LinkBottom_Down.X);
            f.AddShort((short)LinkBottom_Down.Y);

            f.AddShort((short)LinkTop_Left.X);
            f.AddShort((short)LinkTop_Left.Y);
                                  
            f.AddShort((short)LinkTop_Right.X);
            f.AddShort((short)LinkTop_Right.Y);
                                  
            f.AddShort((short)LinkTop_Up.X);
            f.AddShort((short)LinkTop_Up.Y);
                                  
            f.AddShort((short)LinkTop_Down.X);
            f.AddShort((short)LinkTop_Down.Y);

            f.AddShort((short)LinkMiddle_Left.X);
            f.AddShort((short)LinkMiddle_Left.Y);
            
            f.AddShort((short)LinkMiddle_Right.X);
            f.AddShort((short)LinkMiddle_Right.Y);
            
            f.AddShort((short)LinkMiddle_Up.X);
            f.AddShort((short)LinkMiddle_Up.Y);
            
            f.AddShort((short)LinkMiddle_Down.X);
            f.AddShort((short)LinkMiddle_Down.Y);
        }

        public Point GetLinkDown(Direction d) {
            if (d == Direction.Left) {
                return LinkBottom_Left;
            } else if (d == Direction.Right) {
                return LinkBottom_Right;
            } else if (d == Direction.Up) {
                return LinkBottom_Up;
            }

            return LinkBottom_Down;
        }

        public Point GetLinkUp(Direction d) {
            if (d == Direction.Left) {
                return LinkTop_Left;
            } else if (d == Direction.Right) {
                return LinkTop_Right;
            } else if (d == Direction.Up) {
                return LinkTop_Up;
            }

            return LinkTop_Down;
        }

        public Point GetLinkMiddle(Direction d) {
            if (d == Direction.Left) {
                return LinkMiddle_Left;
            } else if (d == Direction.Right) {
                return LinkMiddle_Right;
            } else if (d == Direction.Up) {
                return LinkMiddle_Up;
            }

            return LinkMiddle_Down;
        }

        public void SetLinkDown(Direction d, Point p) {
            if (d == Direction.Left) {
                LinkBottom_Left.X = p.X;
                LinkBottom_Left.Y = p.Y;
            } else if (d == Direction.Right) {
                LinkBottom_Right.X = p.X;
                LinkBottom_Right.Y = p.Y;
            } else if (d == Direction.Up) {
                LinkBottom_Up.X = p.X;
                LinkBottom_Up.Y = p.Y;
            } else {
                LinkBottom_Down.X = p.X;
                LinkBottom_Down.Y = p.Y;
            }
        }

        public void SetLinkUp(Direction d, Point p) {
            if (d == Direction.Left) {
                LinkTop_Left.X = p.X;
                LinkTop_Left.Y = p.Y;
            } else if (d == Direction.Right) {
                LinkTop_Right.X = p.X;
                LinkTop_Right.Y = p.Y;
            } else if (d == Direction.Up) {
                LinkTop_Up.X = p.X;
                LinkTop_Up.Y = p.Y;
            } else {
                LinkTop_Down.X = p.X;
                LinkTop_Down.Y = p.Y;
            }
        }

        public void SetLinkMiddle(Direction d, Point p) {
            if (d == Direction.Left) {
                LinkMiddle_Left.X = p.X;
                LinkMiddle_Left.Y = p.Y;
            } else if (d == Direction.Right) {
                LinkMiddle_Right.X = p.X;
                LinkMiddle_Right.Y = p.Y;
            } else if (d == Direction.Up) {
                LinkMiddle_Up.X = p.X;
                LinkMiddle_Up.Y = p.Y;
            } else {
                LinkMiddle_Down.X = p.X;
                LinkMiddle_Down.Y = p.Y;
            }
        }

        public AnimatedObject DisplayAnimation(States s, Direction d, int layer) {
            AnimatedObject anim = Animations[s].GetAnimation(d, layer);
            
            if (anim.Frames.Count > 0) {
                return anim;
            }

            return Animations[States.Default].GetAnimation(d, layer);
        }
    }
}
