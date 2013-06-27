using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.Drawing;
using ToolCache.Animation;

namespace ToolCache.Equipment {
    public class EquipmentItem {
        public DictionaryEx<String, EquipmentAnimationSet> Animations = new DictionaryEx<String, EquipmentAnimationSet>();
        public event EventHandler AnimationsChanged;

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

        public float AnimationSpeed = 0.2f;

        public string OnAttackScript = "";

        public EquipmentItem(bool initialize = true) {
            Animations.ItemsChanged += new EventHandler(Animations_ItemsChanged);

            if (initialize) {
                VerifyAnimationSets();
            }
        }

        public static EquipmentItem UnpackFromBinaryIO(BinaryIO f) {
            EquipmentItem t = new EquipmentItem(false);

            t.Name = f.GetString();
            t.Type = (EquipmentTypes)f.GetByte();

            byte bool_Settings = f.GetByte();

            t.isAvailableAtStart = (bool_Settings & 1) > 0;
            t.OffsetsLocked = (bool_Settings & 2) > 0;

            t.AnimationSpeed = f.GetFloat();
            short totalAnimationSets = f.GetShort();

            for (short i = 0; i < totalAnimationSets; i++) {
                EquipmentAnimationSet eas = EquipmentAnimationSet.LoadFromBinaryIO(f);

                if (eas == null) {
                    System.Diagnostics.Debug.WriteLine(t.Name + " failed to load an animation...");
                } else {
                    t.Animations.Add(eas.StateName, eas);
                }
            }

            t.OffsetX = f.GetShort();
            t.OffsetY = f.GetShort();

            if (!t.OffsetsLocked) {
                t.OffsetX_1 = f.GetShort();
                t.OffsetY_1 = f.GetShort();
                t.OffsetX_2 = f.GetShort();
                t.OffsetY_2 = f.GetShort();
                t.OffsetX_3 = f.GetShort();
                t.OffsetY_3 = f.GetShort();
            }

            t.OnAttackScript = f.GetString();

            t.VerifyAnimationSets();
            t.UpdateSpeed();

            return t;
        }

        public void VerifyAnimationSets() {
            List<string> removeKeys = new List<string>();

            foreach(KeyValuePair<String, EquipmentAnimationSet> kvp in Animations) {
                if (kvp.Value.StateName != "Default" && kvp.Value.TotalFrames() == 0) {
                    removeKeys.Add(kvp.Key);
                }
            }

            foreach (String s in removeKeys) {
                Animations.Remove(s);
            }

            if (!Animations.ContainsKey("Default")) {
                Animations.Add("Default", new EquipmentAnimationSet());
            }
        }

        public void PackIntoBinaryIO(BinaryIO f) {
            f.AddString(Name);
            f.AddByte((byte)Type);

            byte settings = 0;
            settings |= isAvailableAtStart ? (byte)1 : (byte)0;
            settings |= OffsetsLocked ? (byte)2 : (byte)0;

            f.AddByte(settings);

            f.AddFloat(AnimationSpeed);
            f.AddShort((short)Animations.Count);

            Animations["Default"].SaveToBinaryIO(f);
            foreach (EquipmentAnimationSet kvp in Animations.Values) {
                if (kvp.StateName != "Default") {
                    kvp.SaveToBinaryIO(f);
                }
            }

            f.AddShort((short)OffsetX);
            f.AddShort((short)OffsetY);

            if (!OffsetsLocked) {
                f.AddShort(OffsetX_1);
                f.AddShort(OffsetY_1);
                f.AddShort(OffsetX_2);
                f.AddShort(OffsetY_2);
                f.AddShort(OffsetX_3);
                f.AddShort(OffsetY_3);
            }

            f.AddString(OnAttackScript);
        }

        internal AnimatedObject DisplayAnimation(Direction d, int p) {
            return DisplayAnimation("Default", d, p);
        }

        public AnimatedObject DisplayAnimation(String s, Direction d, int layer) {
            if (Animations.ContainsKey(s)) {
                AnimatedObject anim = Animations[s].GetAnimation(d, layer);

                if (anim.Frames.Count > 0) {
                    return anim;
                }
            }

            return Animations["Default"].GetAnimation(d, layer);
        }

        void Animations_ItemsChanged(object sender, EventArgs e) {
            OnAnimationsChanged(sender, e);
        }

        private void OnAnimationsChanged(object o, EventArgs e) {
            if (AnimationsChanged != null) {
                AnimationsChanged(o, e);
            }
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

        internal Point GetCenter(Direction d, int layer = 2) {
            return GetCenter("Default", d, layer);
        }

        internal Point GetCenter(String s, Direction d, int layer = 2) {
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

        public void UpdateSpeed() {
            foreach (EquipmentAnimationSet eas in Animations.Values) {
                eas.UpdateSpeed(AnimationSpeed);
            }
        }

        public override string ToString() {
            return Name;
        }

        public EquipmentAnimationSet GetAnimation(string state) {
            if (Animations.ContainsKey(state)) {
                return Animations[state];
            }

            EquipmentAnimationSet eas = new EquipmentAnimationSet(true, state);
            Animations.Add(state, eas);
            return eas;
        }
    }
}
