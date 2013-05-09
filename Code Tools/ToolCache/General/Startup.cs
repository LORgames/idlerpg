using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Combat.Elements;
using ToolCache.Items;
using ToolCache.Equipment;
using ToolCache.Map.Objects;
using ToolCache.Map;
using ToolCache.Map.Tiles;
using ToolCache.Sound;
using ToolCache.Critters;

namespace ToolCache.General {
    public class Startup {
        public static void GoGoGadget() {
            //Tier 0 Loading:
            SoundDatabase.Initialize();
            ElementManager.Initialize();

            //Tier 1 Loading:
            TemplateCache.Initialize();
            TileCache.Initialize();
            EquipmentManager.Initialize();

            //Tier 2 Loading:
            CritterManager.Initialize();
            ItemDatabase.Initialize();

            //Tier 3 Loading:
            MapPieceCache.Initialize();
        }
    }
}
