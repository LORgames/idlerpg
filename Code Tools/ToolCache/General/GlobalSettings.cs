using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ToolCache.General {
    public class GlobalSettings {
        public const string DATABASE = ".\\Database\\";
        public const string FILENAME = "GlobalSettings.ini";

        public static string gameName = "New Game";
        public static bool enableTiles = true;
        public static int tileSize = 48;
        public static bool disableCharacter = false;
        public static int targetGameFPS = 20;
        public static float perspectiveSkew = 0.85f;

        internal static void Initialize() {
            if (File.Exists(DATABASE + FILENAME)) {
                Load();
            }
        }

        public static void Load() {
            string[] lines = File.ReadAllLines(DATABASE + FILENAME);

            foreach (string line in lines) {
                if (line[0] != ';') { // ';' is the comment character for .ini files
                    string variableName = line.Split('=')[0];
                    string variableProperty = line.Substring(line.IndexOf('=') + 1);

                    switch (variableName) {
                        case "gamename": gameName = variableProperty; break;
                        case "enabletiles": enableTiles = (variableProperty == "True"); break;
                        case "tilesize": tileSize = int.Parse(variableProperty); break;
                        case "disablecharacter": disableCharacter = (variableProperty == "True"); break;
                        case "targetGameFPS": targetGameFPS = int.Parse(variableProperty); break;
                        case "perspectiveskew": perspectiveSkew = float.Parse(variableProperty); break;
                        default:
                            MessageBox.Show("Unknown variable '" + variableName + "' in global settings");
                            break;
                    }
                }
            }
        }

        public static void Save() {
            List<string> lines = new List<string>();
            lines.Add("gamename=" + gameName);
            lines.Add("enabletiles=" + enableTiles.ToString());
            lines.Add("tilesize=" + tileSize);
            lines.Add("disablecharacter=" + disableCharacter.ToString());
            lines.Add("targetGameFPS=" + targetGameFPS.ToString());
            lines.Add("perspectiveskew=" + perspectiveSkew.ToString());

            File.WriteAllLines(DATABASE + FILENAME, lines);
        }
    }
}
