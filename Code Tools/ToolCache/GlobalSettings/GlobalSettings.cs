using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace ToolCache.GlobalSettings {
    public class GlobalSettings {
        public const string DATABASE = ".\\Database\\";
        public const string FILENAME = "GlobalSettings.ini";

        public string gameName = "";
        public bool enableTiles = true;
        public uint tileSize = 100;
        public bool disableCharacter = false;

        public GlobalSettings() {
            if (File.Exists(DATABASE + FILENAME)) {
                Load();
            }
        }

        public void Load() {
            string[] lines = File.ReadAllLines(DATABASE + FILENAME);

            foreach (string line in lines) {
                if (line[0] != ';') { // ';' is the comment character for .ini files
                    string variableName = line.Split('=')[0];
                    string variableProperty = line.Substring(line.IndexOf('=') + 1);

                    switch (variableName) {
                        case "gamename": gameName = variableProperty; break;
                        case "enabletiles": enableTiles = (variableProperty == "True"); break;
                        case "tilesize": tileSize = uint.Parse(variableProperty); break;
                        case "disablecharacter": disableCharacter = (variableProperty == "True"); break;
                        default:
                            MessageBox.Show("Unknown variable '" + variableName + "' in global settings");
                            break;
                    }
                }
            }
        }

        public void Save() {
            List<string> lines = new List<string>();
            lines.Add("gamename=" + gameName);
            lines.Add("enabletiles=" + enableTiles.ToString());
            lines.Add("tilesize=" + tileSize);
            lines.Add("disablecharacter=" + disableCharacter.ToString());

            File.WriteAllLines(DATABASE + FILENAME, lines);
        }

        public override string ToString() {
            return Path.GetFileName(DATABASE + FILENAME);
        }
    }
}
