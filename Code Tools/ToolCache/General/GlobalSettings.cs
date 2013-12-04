using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace ToolCache.General {
    public class GlobalSettings {
        public const string DATABASE = ".\\Database\\";
        public const string FILENAME = "GlobalSettings.ini";

        public static string GameName = "New Game";
        public static int GameFPS = 20;
        public static bool TilesEnabled = true;
        public static int TileSize = 48;
        public static float PerspectiveSkew = 0.85f;

        public static string VariablePressedWorldX = "";
        public static string VariablePressedWorldY = "";
        public static string VariablePressedLocalX = "";
        public static string VariablePressedLocalY = "";

        public static string VariableMusicVolume = "";
        public static string VariableSoundVolume = "";

        private static byte GIFColourR = 255;
        private static byte GIFColourG = 255;
        private static byte GIFColourB = 255;

        public static byte PlayerTotal = 2;         //Maximum critters in multiplayer
        public static byte PlayerCritters = 32;     //Maximum critters per player
        public static short PlayerTurnLength = 200; //Turn length minimum in milliseconds

        public static string MatchmakingServer = "";

        public static Color GIFColour {
            get { return Color.FromArgb(GIFColourR, GIFColourG, GIFColourB); }
            set { GIFColourR = value.R; GIFColourG = value.G; GIFColourB = value.B; }
        }

        public static string DefaultMap = "";

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
                        case "FPS": GameFPS = int.Parse(variableProperty); break;
                        case "PerspectiveSkew": PerspectiveSkew = float.Parse(variableProperty); break;
                        case "PressedWX": VariablePressedWorldX = variableProperty; break;
                        case "PressedWY": VariablePressedWorldY = variableProperty; break;
                        case "PressedLX": VariablePressedLocalX = variableProperty; break;
                        case "PressedLY": VariablePressedLocalY = variableProperty; break;
                        case "DefaultMap": DefaultMap = variableProperty; break;
                        case "GIFBackgroundR": GIFColourR = byte.Parse(variableProperty); break;
                        case "GIFBackgroundG": GIFColourG = byte.Parse(variableProperty); break;
                        case "GIFBackgroundB": GIFColourB = byte.Parse(variableProperty); break;
                        case "PlayersTotal": PlayerTotal = byte.Parse(variableProperty); break;
                        case "PlayersCritters": PlayerCritters = byte.Parse(variableProperty); break;
                        case "TurnLength": PlayerTurnLength = short.Parse(variableProperty); break;
                        case "MatchmakingServer": MatchmakingServer = variableProperty; break;
                        case "MusicVolume": VariableMusicVolume = variableProperty; break;
                        case "SoundVolume": VariableSoundVolume = variableProperty; break;
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
            lines.Add("FPS=" + GameFPS.ToString());
            lines.Add("PerspectiveSkew=" + PerspectiveSkew.ToString());

            lines.Add("PressedWX=" + VariablePressedWorldX.ToString());
            lines.Add("PressedWY=" + VariablePressedWorldY.ToString());
            lines.Add("PressedLX=" + VariablePressedLocalX.ToString());
            lines.Add("PressedLY=" + VariablePressedLocalY.ToString());

            lines.Add("DefaultMap=" + DefaultMap.ToString());

            lines.Add("GIFBackgroundR=" + GIFColourR.ToString());
            lines.Add("GIFBackgroundG=" + GIFColourG.ToString());
            lines.Add("GIFBackgroundB=" + GIFColourB.ToString());

            lines.Add("PlayersTotal=" + PlayerTotal);
            lines.Add("PlayersCritters=" + PlayerCritters);
            lines.Add("TurnLength=" + PlayerTurnLength);

            lines.Add("MatchmakingServer=" + MatchmakingServer);

            lines.Add("MusicVolume=" + VariableMusicVolume);
            lines.Add("SoundVolume=" + VariableSoundVolume);

            File.WriteAllLines(DATABASE + FILENAME, lines);
        }
    }
}
