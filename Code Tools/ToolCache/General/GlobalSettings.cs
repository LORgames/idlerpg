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

        public static string GameName = "New Game";
        public static int GameFPS = 20;
        public static bool TilesEnabled = true;
        public static int TileSize = 48;
        public static bool CharacterDisabled = false;
        public static float PerspectiveSkew = 0.85f;

        public static string VariablePressedWorldX = "";
        public static string VariablePressedWorldY = "";
        public static string VariablePressedLocalX = "";
        public static string VariablePressedLocalY = "";

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
                        case "Name": GameName = variableProperty; break;
                        case "TilesEnabled": TilesEnabled = (variableProperty == "True"); break;
                        case "Tilesize": TileSize = int.Parse(variableProperty); break;
                        case "CharacterDisabled": CharacterDisabled = (variableProperty == "True"); break;
                        case "FPS": GameFPS = int.Parse(variableProperty); break;
                        case "PerspectiveSkew": PerspectiveSkew = float.Parse(variableProperty); break;
                        case "PressedWX": VariablePressedWorldX = variableProperty; break;
                        case "PressedWY": VariablePressedWorldY = variableProperty; break;
                        case "PressedLX": VariablePressedLocalX = variableProperty; break;
                        case "PressedLY": VariablePressedLocalY = variableProperty; break;
                        default:
                            MessageBox.Show("Unknown variable '" + variableName + "' in global settings");
                            break;
                    }
                }
            }
        }

        public static void Save() {
            List<string> lines = new List<string>();
            lines.Add("Name=" + GameName);
            lines.Add("TilesEnabled=" + TilesEnabled.ToString());
            lines.Add("Tilesize=" + TileSize);
            lines.Add("CharacterDisabled=" + CharacterDisabled.ToString());
            lines.Add("FPS=" + GameFPS.ToString());
            lines.Add("PerspectiveSkew=" + PerspectiveSkew.ToString());

            lines.Add("PressedWX=" + VariablePressedWorldX.ToString());
            lines.Add("PressedWY=" + VariablePressedWorldY.ToString());
            lines.Add("PressedLX=" + VariablePressedLocalX.ToString());
            lines.Add("PressedLY=" + VariablePressedLocalY.ToString());

            File.WriteAllLines(DATABASE + FILENAME, lines);
        }
    }
}
