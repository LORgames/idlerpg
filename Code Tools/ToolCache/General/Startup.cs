using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Combat.Elements;
using ToolCache.Items;
using ToolCache.Equipment;
using ToolCache.Map.Objects;
using ToolCache.Map;

namespace ToolCache.General {
    public class Startup {
        public static void GoGoGadget() {
            TemplateCache.Initialize();
            MapPieceCache.Initialize();

            ElementManager.Initialize();
            ItemDatabase.Initialize();
            EquipmentManager.Initialize();
        }
    }
}
