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
        public static Dictionary<string, TreeNode> groupNodes = new Dictionary<string, TreeNode>();

        public static void Initialize() {
            foreach (string group in TileCache.GetGroups()) {
                groupNodes.Add(group, new TreeNode(group, -1, -1));
                foreach (TileTemplate tile in TileCache.GetTilesInGroup(group)) {
                    if (MainWindow.instance.treeTiles.ImageList == null) {
                        MainWindow.instance.treeTiles.ImageList = new ImageList();
                        MainWindow.instance.treeTiles.ImageList.ImageSize = new System.Drawing.Size(48, 48);
                        MainWindow.instance.treeTiles.ImageList.ColorDepth = ColorDepth.Depth32Bit;
                    }

                    if (tile.Animation.Frames.Count != 0) {
                        MainWindow.instance.treeTiles.ImageList.Images.Add(tile.Animation.Frames[0], ImageCache.RequestImage(tile.Animation.Frames[0]));
                        int imageIndex = MainWindow.instance.treeTiles.ImageList.Images.IndexOfKey(tile.Animation.Frames[0]);
                        if (groupNodes[group].ImageIndex == -1) {
                            groupNodes[group].ImageIndex = imageIndex;
                            groupNodes[group].SelectedImageIndex = imageIndex;
                        }
                        TreeNode temp = new TreeNode(tile.TileName, imageIndex, imageIndex);
                        temp.Tag = tile;
                        groupNodes[group].Nodes.Add(temp);
                    }
                }
                MainWindow.instance.treeTiles.Nodes.Add(groupNodes[group]);
                
            }
        }
    }
}
