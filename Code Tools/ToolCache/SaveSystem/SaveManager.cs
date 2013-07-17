using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ToolCache.SaveSystem {
    public class SaveManager {
        internal static string SaveFolder = "Saves";
        public static Dictionary<string, SaveInfo> Saves = new Dictionary<string, SaveInfo>();

        internal static void Initialize() {
            Saves.Clear();
        }

        private static void LoadSaves() {
            if (!Directory.Exists(SaveFolder)) Directory.CreateDirectory("Saves");

            string[] SaveFiles = Directory.GetFiles("*.sva");

            foreach (string file in SaveFiles) {
                SaveInfo s = SaveInfo.LoadASCIISaveFile(file);
                Saves.Add(s.playername, s);
            }
        }

        public static void SaveSaves() {
            foreach (SaveInfo save in Saves.Values) {
                save.Save();
            }
        }
    }
}
