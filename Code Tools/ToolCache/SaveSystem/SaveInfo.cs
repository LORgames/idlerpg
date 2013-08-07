using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ToolCache.General;

namespace ToolCache.SaveSystem {
    public class SaveInfo {
        //GENERAL
        public bool disablePlayer = false;
        public string filename = "";
        public string name = "Adventurer";
        public string title = "Farmhand";
        public uint experienceAmount = 0;

        //EQUIPMENT
        public string shadow = "Shadow";
        public string legs = "Loincloth";
        public string body = "Rags";
        public string face = "_UNKNOWN";
        public string headgear = "";
        public string weapon = "";

        //Inventory
        public SaveInfo(string myFilename = "") {
            filename = myFilename;

            if (filename == "") {
                int saveID = 0;

                while (File.Exists(SaveManager.SaveFolder + "/Slot_" + saveID + ".sva")) {
                    saveID++;
                }

                filename = SaveManager.SaveFolder + "/Slot_" + saveID + ".sva";

                if (File.Exists(SaveManager.DefaultFile)) {
                    File.Copy(SaveManager.DefaultFile, filename);
                } else {
                    this.SaveASCII();
                }
            }

            if (Path.GetExtension(filename) == ".sva") {
                LoadASCII();
            } else if (Path.GetExtension(filename) == "svb") {
                LoadBinary();
            }
        }

        private void LoadBinary() {
            throw new NotImplementedException("Cannot load a binary save file yet!");
        }


        private void LoadASCII() {
            string[] lines = File.ReadAllLines(filename);
            string set = ""; //TODO: When global variables are in, will need to extend saves

            foreach(string line in lines) {
                string variableName = line.Split('=')[0];
                string variableInfo = line.Substring(line.IndexOf('=')+1);

                switch (variableName) {
                    case "Name": name = variableInfo; break;
                    case "Title": title = variableInfo; break;
                    case "Experience": experienceAmount = uint.Parse(variableInfo); break;
                    case "Shadow": shadow = variableInfo; break;
                    case "Legs": legs = variableInfo; break;
                    case "Body": body = variableInfo; break;
                    case "Face": face = variableInfo; break;
                    case "Headgear": headgear = variableInfo; break;
                    case "Weapon": weapon = variableInfo; break;
                    case "DisablePlayer": disablePlayer = (uint.Parse(variableInfo)==1); break;
                    default:
                        MessageBox.Show("Unknown variable '"+variableName+"' in save file: " + filename);
                        break;
                }
            }
        }

        public static SaveInfo LoadFromFile(string filename) {
            return new SaveInfo(filename);
        }

        public void Save() {
            if (Path.GetExtension(filename) == ".sva") {
                SaveASCII();
            } else if (Path.GetExtension(filename) == "svb") {
                SaveBinary();
            }
        }

        internal void SaveASCII() {
            List<string> Lines = new List<string>();
            Lines.Add("Name=" + name);
            Lines.Add("Title=" + title);
            Lines.Add("Experience=" + experienceAmount);
            Lines.Add("Shadow=" + shadow);
            Lines.Add("Legs=" + legs);
            Lines.Add("Body=" + body);
            Lines.Add("Face=" + face);
            Lines.Add("Headgear=" + headgear);
            Lines.Add("Weapon=" + weapon);
            Lines.Add("DisablePlayer=" + (disablePlayer?1:0).ToString());

            File.WriteAllLines(filename, Lines);
        }

        internal void SaveBinary() {
            throw new NotImplementedException("Binary is not YET supported.");
        }

        public override string ToString() {
            return Path.GetFileName(filename);
        }

        public bool IsDefault() {
            return filename == SaveManager.DefaultFile;
        }
    }
}
