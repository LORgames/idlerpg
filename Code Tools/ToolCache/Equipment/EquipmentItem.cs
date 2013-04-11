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

        public short OffsetX = 0;
        public short OffsetY = 0;

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

            t.LinkOffset = f.GetShort();

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

            f.AddShort((short)LinkOffset);
        }

        public AnimatedObject DisplayAnimation(States s, Direction d, int layer) {
            AnimatedObject anim = Animations[s].GetAnimation(d, layer);
            
            if (anim.Frames.Count == 0 && s == States.Default) {
                anim = Animations[s].GetAnimation(d, layer == 0 ? 1 : 0);
            }
            
            if (anim.Frames.Count > 0) {
                return anim;
            }

            return Animations[States.Default].GetAnimation(d, layer);
        }

        private Point _p;
        public Point Offset { get; set; }
    }
}
