using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map.Objects;
using CityTools.Components;
using System.IO;

namespace CityTools.CacheInterfaces {
    public class ObjectInterface {

        internal static void Initialize() {
            MainWindow.instance.pnlObjectScenicCache.Controls.Add(new ObjectCacheControl());
            TemplateCache.Initialize();

            UpdateObjectTab();
            UpdateObjectPage();
        }

        public static void UpdateObjectTab() {
            MainWindow.instance.cbScenicCacheSelector.Items.Clear();
            List<String> groups = TemplateCache.GetGroups();

            foreach (String s in groups) {
                MainWindow.instance.cbScenicCacheSelector.Items.Add(s);
            }
        }

        internal static void UpdateObjectPage() {
            (MainWindow.instance.pnlObjectScenicCache.Controls[0] as ObjectCacheControl).Deactivate();

            foreach (Template t in TemplateCache.GetObjectsInGroup(MainWindow.instance.cbScenicCacheSelector.Text)) {
                if (t.Animation.Frames.Count > 0) {
                    CachedObject co = new CachedObject(t.Animation.Frames[0], (t.isSolid ? "S" : "P"), t.ObjectID.ToString());

                    (MainWindow.instance.pnlObjectScenicCache.Controls[0] as ObjectCacheControl).pnlInternal.Controls.Add(co);
                }
            }
        }

        internal static void ReloadAll() {
            UpdateObjectPage();
            UpdateObjectTab();
        }
    }
}
