using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Tiles;
using CityTools.Components;

namespace CityTools.CacheInterfaces {
    public class TileInterface {

        public static void UpdateTileTab() {
            MainWindow.instance.cbTileGroups.Controls.Clear();
            List<String> groups = TileCache.GetGroups();
        }


        internal static void UpdateTilePage() {
            (MainWindow.instance.pnlTiles.Controls[0] as ObjectCacheControl).Deactivate();

            foreach(Tile t in TileCache.GetTilesInGroup(MainWindow.instance.cbTileGroups.Text)) {
                if(t.Animation.Frames.Count > 0) {
                    CachedObject co = new CachedObject(t.Animation.Frames[0], (t.isWalkable?"W":"S"), t.TileID.ToString());
                    
                    (MainWindow.instance.pnlTiles.Controls[0] as ObjectCacheControl).pnlInternal.Controls.Add(co);
                }
            }
        }

        internal static void ReloadAll() {
            UpdateTilePage();
            UpdateTileTab();
        }
    }
}
