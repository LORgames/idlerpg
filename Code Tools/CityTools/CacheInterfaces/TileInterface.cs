using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Tiles;
using CityTools.Components;
using System.Windows.Forms;
using ToolCache.General;

namespace CityTools.CacheInterfaces {
    public class TileInterface {
        public static Dictionary<string, ListViewGroup> groupNodes = new Dictionary<string, ListViewGroup>();

        public static void Initialize() {
            groupNodes.Clear();

            if (MainWindow.instance.listTiles.LargeImageList == null) {
                MainWindow.instance.listTiles.LargeImageList = new ImageList();
                MainWindow.instance.listTiles.LargeImageList.ImageSize = new System.Drawing.Size(GlobalSettings.TileSize, GlobalSettings.TileSize);
                MainWindow.instance.listTiles.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
            }

            foreach (string group in TileCache.GetGroups()) {
                groupNodes.Add(group, new ListViewGroup(group));
                foreach (TileTemplate tile in TileCache.GetTilesInGroup(group)) {
                    if (tile.Animation.Frames.Count != 0) {
                        MainWindow.instance.listTiles.LargeImageList.Images.Add(tile.Animation.Frames[0], ImageCache.RequestImage(tile.Animation.Frames[0]));
                        int imageIndex = MainWindow.instance.listTiles.LargeImageList.Images.IndexOfKey(tile.Animation.Frames[0]);
                        /*if (groupNodes[group].ImageIndex == -1) {
                            groupNodes[group].ImageIndex = imageIndex;
                            groupNodes[group].SelectedImageIndex = imageIndex;
                        }*/
                        ListViewItem temp = new ListViewItem(tile.TileName, imageIndex, groupNodes[group]);
                        temp.Tag = tile;
                        MainWindow.instance.listTiles.Items.Add(temp);
                    }
                }
                MainWindow.instance.listTiles.Groups.Add(groupNodes[group]);
            }
        }

        internal static void ForceUpdate() {
            MainWindow.instance.listTiles.Groups.Clear();
            MainWindow.instance.listTiles.LargeImageList.Images.Clear();
            Initialize();
        }
    }
}
