using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;

namespace ToolCache.Scripting {
    public class GlobalVariables {
        public static DictionaryEx<string, ScriptVariable> Variables = new DictionaryEx<string, ScriptVariable>();
        private static int nexthighestindex = 1;

        public static void Initialize() {
            Variables.Clear();
            LoadDatabase();
        }

        private static void LoadDatabase() {
            if (File.Exists(Settings.Database + "GlobalVariables.csv")) {
                string[] lines = File.ReadAllLines(Settings.Database + "GlobalVariables.csv");

                foreach (String line in lines) {
                    ScriptVariable s = new ScriptVariable();
                    string[] lineBits = line.Trim().Split(',');

                    if (lineBits.Length != 3) {
                        continue;
                    }
                    
                    s.Name = lineBits[0];
                    int.TryParse(lineBits[1], out s.Index);
                    short.TryParse(lineBits[2], out s.InitialValue);

                    AddToDatabase(s);
                }
            }
        }

        public static void SaveDatabase() {
            List<string> keys = Variables.Keys.ToList<string>();
            keys.Sort();

            List<string> rows = new List<string>();

            for (int i = 0; i < keys.Count; i++) {
                rows.Add(keys[i] + "," + Variables[keys[i]].Index + "," + Variables[keys[i]].InitialValue);
            }

            File.WriteAllLines(Settings.Database + "GlobalVariables.csv", rows);
        }

        public static void AddToDatabase(ScriptVariable s) {
            if (s.lvi == null) {
                s.lvi = new System.Windows.Forms.ListViewItem();
                s.lvi.Text = s.Name;
                s.lvi.Tag = s;
                s.lvi.SubItems.Add(s.InitialValue.ToString());
            }

            if (s.Index == 0) {
                s.Index = nexthighestindex;
            }

            if (s.Index >= nexthighestindex) {
                nexthighestindex = s.Index + 1;
            }

            Variables.Add(s.Name, s);
        }

        public static void UpdatedVariable(string key) {
            //TODO: this
        }

        public static int HighestRequiredIndex() {
            return nexthighestindex;
        }
    }
}
