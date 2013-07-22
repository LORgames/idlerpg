using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Elements;
using ToolCache.Items;
using ToolCache.Equipment;
using ToolCache.Map.Objects;
using ToolCache.Map;
using ToolCache.Map.Tiles;
using ToolCache.Sound;
using ToolCache.Critters;
using ToolCache.UI;
using ToolCache.Effects;
using ToolCache.SaveSystem;

namespace ToolCache.General {
    public class Startup {
        public static void GoGoGadget() {
            //Tier 0 Loading:
            SoundDatabase.Initialize();
            ElementManager.Initialize();
            Factions.Initialize();
            UIManager.Initialize();
            EffectManager.Initialize();

            //Tier 1 Loading:
            MapObjectCache.Initialize();
            TileCache.Initialize();
            EquipmentManager.Initialize();

            //Tier 2 Loading:
            CritterManager.Initialize();
            ItemDatabase.Initialize();

            //Tier 3 Loading:
            MapPieceCache.Initialize();

            //Tier 4 Loading:
            SaveManager.Initialize();
        }
    }
}
