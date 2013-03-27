using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Tiles;

namespace CityTools.CacheInterfaces {
    public class TileInterface {

        public static void UpdateTileTab() {
            MainWindow.instance.cbTileGroups.Controls.Clear();

            List<String> groups = TileCache.GetGroups();
        }

    }
}
