using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Tiles;
using CityTools.Components;

namespace CityTools.CacheInterfaces {
    public class TileInterface {

        public static void Initialize() {
            MainWindow.instance.pnlTiles.Controls.Add(new ObjectCacheControl());
            ReloadAll();
        }

        public static void UpdateTileTab() {
            MainWindow.instance.cbTileGroups.Items.Clear();

            short id = TileCache.NextID();

            foreach (string cache in TileCache.GetGroups()) {
                MainWindow.instance.cbTileGroups.Items.Add(cache);
            }
        }

        internal static void UpdateTilePage() {
            (MainWindow.instance.pnlTiles.Controls[0] as ObjectCacheControl).Deactivate();

            foreach(TileTemplate t in TileCache.GetTilesInGroup(MainWindow.instance.cbTileGroups.Text)) {
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
