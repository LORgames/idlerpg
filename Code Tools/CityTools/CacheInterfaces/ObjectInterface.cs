using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Objects;
using CityTools.Components;
using System.IO;

namespace CityTools.CacheInterfaces {
    /// <summary>
    /// Responsible for interfacing with the object database in the ToolCache library.
    /// </summary>
    public class ObjectInterface {
        /// <summary>
        /// Initializes the object system by hooking into the GUI wherever may be required and loading any additional databases that might be required
        /// </summary>
        internal static void Initialize() {
            MainWindow.instance.pnlObjectScenicCache.Controls.Add(new ObjectCacheControl());

            UpdateObjectTab();
            UpdateObjectPage();
        }

        /// <summary>
        /// Updates the object tab to display any item groups that might have been added or modified
        /// </summary>
        public static void UpdateObjectTab() {
            MainWindow.instance.cbScenicCacheSelector.Items.Clear();
            List<String> groups = MapObjectCache.GetGroups();

            foreach (String s in groups) {
                MainWindow.instance.cbScenicCacheSelector.Items.Add(s);
            }
        }

        /// <summary>
        /// Updates the object tab to display any updated items that might not currently be displayed and to remove any older items that may have been deleted
        /// </summary>
        internal static void UpdateObjectPage() {
            (MainWindow.instance.pnlObjectScenicCache.Controls[0] as ObjectCacheControl).Deactivate();

            foreach (MapObject t in MapObjectCache.GetObjectsInGroup(MainWindow.instance.cbScenicCacheSelector.Text)) {
                if (t.Animation.Frames.Count > 0) {
                    CachedObject co = new CachedObject(t.Animation.Frames[0], (t.isSolid ? "S" : "P"), t.ObjectID.ToString());

                    (MainWindow.instance.pnlObjectScenicCache.Controls[0] as ObjectCacheControl).pnlInternal.Controls.Add(co);
                }
            }
        }

        /// <summary>
        /// Completely flushes the MapEditor GUI and recreates it from empty.
        /// </summary>
        internal static void ReloadAll() {
            UpdateObjectPage();
            UpdateObjectTab();
        }
    }
}
