using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace ToolCache.SaveSystem {
    public class SaveManager {
        internal const string SaveFolder = "Saves";
        internal const string DefaultFile = SaveManager.SaveFolder + "/Default.sva";

        public static BindingList<SaveInfo> Saves = new BindingList<SaveInfo>();

        internal static void Initialize() {
            Saves.Clear();
            LoadSaves();
        }

        private static void LoadSaves() {
            if (!Directory.Exists(SaveFolder)) Directory.CreateDirectory(SaveFolder);

            string[] SaveFiles = Directory.GetFiles(SaveFolder, "*.sva");

            foreach (string file in SaveFiles) {
                Saves.Add(SaveInfo.LoadFromFile(file));
            }
        }

        public static void WriteDatabase() {
            foreach (SaveInfo save in Saves) {
                save.SaveASCII();
            }
        }
    }
}
