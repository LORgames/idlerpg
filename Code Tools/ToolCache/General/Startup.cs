using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Combat.Elements;
using ToolCache.Items;
using ToolCache.Equipment;

namespace ToolCache.General {
    public class Startup {
        public static void GoGoGadget() {
            ElementManager.Initialize();
            ItemDatabase.Initialize();
            EquipmentManager.Initialize();
        }
    }
}
