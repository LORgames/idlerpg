using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.Equipment {
    public class EquipmentItem {
        public Dictionary<States, EquipmentAnimationSet> Animations = new Dictionary<States, EquipmentAnimationSet>();

        public EquipmentTypes Type = EquipmentTypes.Body;
        public string Name = "Unnamed";

        public bool isAvailableAtStart = false;

        public EquipmentItem() {
            Animations.Add(States.Default, new EquipmentAnimationSet());
        }

        public static EquipmentItem UnpackFromBinaryIO(BinaryIO f) {
            EquipmentItem t = new EquipmentItem();

            t.Name = f.GetString();
            t.Type = (EquipmentTypes)f.GetByte();

            t.isAvailableAtStart = (f.GetByte() == (byte)1 ? true : false);

            short totalAnimationSets = f.GetShort();

            for (int i = 0; i < totalAnimationSets; i++) {
                EquipmentAnimationSet eas = EquipmentAnimationSet.LoadFromBinaryIO(f);

                t.Animations.Add(eas.State, eas);
            }

            return t;
        }

        public void PackIntoBinaryIO(BinaryIO f) {
            f.AddString(Name);
            f.AddByte((byte)Type);
            f.AddByte(isAvailableAtStart ? (byte)1 : (byte)0);

            f.AddShort((short)Animations.Count);

            foreach (EquipmentAnimationSet kvp in Animations.Values) {
                kvp.SaveToBinaryIO(f);
            }
        }
    }
}
