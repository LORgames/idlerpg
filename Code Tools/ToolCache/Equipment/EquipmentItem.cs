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
        public string OldName = "Unnamed";

        public bool isAvailableAtStart = false;

        public bool OffsetsLocked = true;
        public short OffsetX = 0;
        public short OffsetY = 0;
        public short OffsetX_1 = 0;
        public short OffsetY_1 = 0;
        public short OffsetX_2 = 0;
        public short OffsetY_2 = 0;
        public short OffsetX_3 = 0;
        public short OffsetY_3 = 0;

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

            t.OffsetX = f.GetShort();
            t.OffsetY = f.GetShort();

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

            f.AddShort((short)OffsetX);
            f.AddShort((short)OffsetY);
        }

        public AnimatedObject DisplayAnimation(States s, Direction d, int layer) {
            AnimatedObject anim = Animations[s].GetAnimation(d, layer);
            
            if (anim.Frames.Count > 0) {
                return anim;
            }

            return Animations[States.Default].GetAnimation(d, layer);
        }

        private Point _p = new Point();
        public Point Offset(Direction d) {
            if (OffsetsLocked || d == Direction.Left) {
                _p.X = OffsetX;
                _p.Y = OffsetY;
            } else {
                if (d == Direction.Right) {
                    _p.X = OffsetX_1;
                    _p.Y = OffsetY_1;
                } else if (d == Direction.Up) {
                    _p.X = OffsetX_2;
                    _p.Y = OffsetY_2;
                } else {
                    _p.X = OffsetX_3;
                    _p.Y = OffsetY_3;
                }
            }

            return _p;
        }

        internal Point GetCenter(States s, Direction d, int layer = 2) {
            if (layer == 2) {
                Point c0 = DisplayAnimation(s, d, 0).Center;

                if (c0.X < 0 || c0.Y < 0) {
                    c0 = DisplayAnimation(s, d, 1).Center;
                }

                return c0;
            } else {
                return DisplayAnimation(s, d, layer).Center;
            }
        }
    }
}
