using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Equipment {
    public class EquipmentItem {
        public Dictionary<String, EquipmentAnimationSet> Animations = new Dictionary<string, EquipmentAnimationSet>();

        public EquipmentTypes Type = EquipmentTypes.Body;
        public string Name = "Unnamed";

        public bool isAvailableAtStart = false;
    }
}
