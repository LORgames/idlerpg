using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;
using ToolCache.Critters;
using System.Text.RegularExpressions;

namespace ToolCache.Scripting {
    public class GlobalVariables {
        public static DictionaryEx<string, ScriptVariable> Variables = new DictionaryEx<string, ScriptVariable>();
        public static DictionaryEx<string, string> StringTable = new DictionaryEx<string, string>();

        private static int nexthighestindex = 1;

        public static void Initialize() {
            Variables.Clear();
            StringTable.Clear();

            LoadDatabase();
        }

        private static void LoadDatabase() {
            LoadGlobalVariables();
            LoadStringTable();
        }
        private static void LoadGlobalVariables() {
            //Load the variables from the variable CSV
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

                    AddVariableToDatabase(s);
                }
            }
        }
        private static void LoadStringTable() {
            //Load the strings from the string table
            if (File.Exists(Settings.Database + "StringTable.csv")) {
                string[] lines = File.ReadAllLines(Settings.Database + "StringTable.csv");

                foreach (String line in lines) {
                    string[] lineBits = line.Trim().Split('\t');

                    if (lineBits.Length != 2) {
                        continue;
                    }

                    StringTable.Add(lineBits[0], lineBits[1]);
                }
            }
        }

        public static void SaveDatabase() {
            VerifyStats();
            SaveVariables();
            SaveStrings();
        }
        private static void SaveVariables() {
            List<string> keys = Variables.Keys.ToList<string>();
            keys.Sort();

            List<string> rows = new List<string>();

            for (int i = 0; i < keys.Count; i++) {
                rows.Add(keys[i] + "," + Variables[keys[i]].Index + "," + Variables[keys[i]].InitialValue);
            }

            File.WriteAllLines(Settings.Database + "GlobalVariables.csv", rows);
        }
        private static void SaveStrings() {
            List<string> keys = StringTable.Keys.ToList<string>();
            keys.Sort();

            List<string> rows = new List<string>();

            for (int i = 0; i < keys.Count; i++) {
                rows.Add(keys[i] + "\t" + StringTable[keys[i]]);
            }

            File.WriteAllLines(Settings.Database + "StringTable.csv", rows);
        }

        public static void AddVariableToDatabase(ScriptVariable s) {
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
        public static int HighestRequiredVariableIndex() {
            return nexthighestindex;
        }

        public static void VerifyStats() {
            foreach (Critter c in CritterManager.Critters.Values) {
                AddNewVariable("Stat_Deaths_" + c.Name);
                AddNewVariable("Stat_GroupDeaths_" + c.NodeGroup);
            }

            foreach (String groupName in Factions.AllFactions) {
                AddNewVariable("Stat_GroupDeaths_" + groupName);
            }
        }

        public static void AddNewVariable(string variableName, short initialValue = 0) {
            variableName = FixVariableName(variableName);

            if (!Variables.ContainsKey(variableName)) {
                ScriptVariable sv = new ScriptVariable();
                sv.Name = variableName;
                sv.InitialValue = initialValue;
                AddVariableToDatabase(sv);
            }
        }

        public static string FixVariableName(string attemptedName) {
            return Regex.Replace(attemptedName, "[^\\w]", "_");
        }
    }
}
