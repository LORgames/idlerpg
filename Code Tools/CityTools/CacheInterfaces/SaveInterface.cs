using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.SaveSystem;

namespace CityTools.CacheInterfaces {
    public class SaveInterface {
        public static void Initialize() {
            SaveManager.Saves.ListChanged += new System.ComponentModel.ListChangedEventHandler(Saves_ListChanged);
            RemapExportSaves();
        }

        static void Saves_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e) {
            RemapExportSaves();
        }

        private static void RemapExportSaves() {
            MainWindow.instance.cbExportSave.Items.Clear();
            MainWindow.instance.cbExportSave.Items.Add("No Save");
            MainWindow.instance.cbExportSave.Items.AddRange(SaveManager.Saves.ToArray<SaveInfo>());
        }
    }
}
