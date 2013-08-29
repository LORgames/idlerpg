using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Objects;
using CityTools.Components;
using System.IO;
using System.Windows.Forms;
using ToolCache.General;
using System.Drawing;

namespace CityTools.CacheInterfaces {
    /// <summary>
    /// Responsible for interfacing with the object database in the ToolCache library.
    /// </summary>
    public class ObjectInterface {
        private const int ICON_SIZE = 48;
        public static Dictionary<string, ListViewGroup> groupNodes = new Dictionary<string, ListViewGroup>();

        /// <summary>
        /// Initializes the object system by hooking into the GUI wherever may be required and loading any additional databases that might be required
        /// </summary>
        internal static void Initialize() {
            groupNodes.Clear();

            if (MainWindow.instance.listObjects.LargeImageList == null) {
                MainWindow.instance.listObjects.LargeImageList = new ImageList();
                MainWindow.instance.listObjects.LargeImageList.ImageSize = new System.Drawing.Size(ICON_SIZE, ICON_SIZE);
                MainWindow.instance.listObjects.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
            }

            foreach (string group in MapObjectCache.GetGroups()) {
                groupNodes.Add(group, new ListViewGroup(group));
                foreach (MapObject mapobj in MapObjectCache.GetObjectsInGroup(group)) {
                    if (mapobj.Animations["Default"].Frames.Count != 0) {
                        ProcessIcon(mapobj.Animations["Default"].Frames[0]);
                        
                        int imageIndex = MainWindow.instance.listObjects.LargeImageList.Images.IndexOfKey(mapobj.Animations["Default"].Frames[0]);
                        /*if (groupNodes[group].ImageIndex == -1) {
                            groupNodes[group].ImageIndex = imageIndex;
                            groupNodes[group].SelectedImageIndex = imageIndex;
                        }*/
                        ListViewItem temp = new ListViewItem(mapobj.ObjectName, imageIndex, groupNodes[group]);
                        temp.Tag = mapobj;
                        MainWindow.instance.listObjects.Items.Add(temp);
                    }
                }
                MainWindow.instance.listObjects.Groups.Add(groupNodes[group]);
            }
        }

        private static void ProcessIcon(string imagefilename) {
            Image im = ImageCache.RequestImage(imagefilename);
            Bitmap bmp = new Bitmap(im, ICON_SIZE, ICON_SIZE);

            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            Rectangle r = new Rectangle(0, 0, ICON_SIZE, ICON_SIZE);

            if (im.Height <= ICON_SIZE && im.Width <= ICON_SIZE) {
                r.Width = im.Width;
                r.Height = im.Height;
            } else if (im.Width < im.Height) {
                float scale = (float)im.Width / im.Height;
                r.Width = (int)(ICON_SIZE * scale);
            } else if (im.Width > im.Height) {
                float scale = (float)im.Height / im.Width;
                r.Height = (int)(ICON_SIZE * scale);
            }

            r.X = (ICON_SIZE - r.Width) / 2;
            r.Y = (ICON_SIZE - r.Height) / 2;
            g.DrawImage(im, r);

            g.Dispose();

            MainWindow.instance.listObjects.LargeImageList.Images.Add(imagefilename, bmp);
        }

        /// <summary>
        /// Completely flushes the MapEditor GUI and recreates it from empty.
        /// </summary>
        internal static void ReloadAll() {
            MainWindow.instance.listObjects.Groups.Clear();
            MainWindow.instance.listObjects.LargeImageList.Images.Clear();
            Initialize();
        }
    }
}
