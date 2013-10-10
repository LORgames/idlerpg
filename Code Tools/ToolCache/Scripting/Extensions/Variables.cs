using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;
using ToolCache.Critters;
using System.Text.RegularExpressions;
using ToolCache.Scripting.Types;

namespace ToolCache.Scripting.Extensions {
    public class Variables {
        public static DictionaryEx<string, ScriptVariable> GlobalVariables = new DictionaryEx<string, ScriptVariable>();
        public static DictionaryEx<string, string> StringTable = new DictionaryEx<string, string>();
        public static DictionaryEx<string, ScriptFunction> FunctionTable = new DictionaryEx<string, ScriptFunction>();

        private static int nexthighestindex = 1;

        public static void Initialize() {
            GlobalVariables.Clear();
            StringTable.Clear();
            FunctionTable.Clear();

            LoadDatabase();
        }

        private static void LoadDatabase() {
            LoadGlobalVariables();
            LoadStringTable();
            LoadFunctions();
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

        private static void LoadFunctions() {
            if (File.Exists(Settings.Database + "GlobalFunctions.bin")) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(Settings.Database + "GlobalFunctions.bin"));

                short i = f.GetShort();

                while (--i > -1) {
                    ScriptFunction fun = new ScriptFunction();
                    fun.Name = f.GetString();
                    fun.OldName = fun.Name;
                    fun.Script = f.GetString();
                    FunctionTable.Add(fun.Name, fun);
                }

                f.Dispose();
            }
        }

        public static void SaveDatabase() {
            VerifyStats();
            SaveVariables();
            SaveStrings();
            SaveFunctions();
        }

        private static void SaveVariables() {
            List<string> keys = GlobalVariables.Keys.ToList<string>();
            keys.Sort();

            List<string> rows = new List<string>();

            for (int i = 0; i < keys.Count; i++) {
                rows.Add(keys[i] + "," + GlobalVariables[keys[i]].Index + "," + GlobalVariables[keys[i]].InitialValue);
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

        private static void SaveFunctions() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)FunctionTable.Count);

            foreach (KeyValuePair<string, ScriptFunction> kvp in FunctionTable) {
                f.AddString(kvp.Key);
                f.AddString(kvp.Value.Script);
            }

            f.Encode(Settings.Database + "GlobalFunctions.bin");
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

            GlobalVariables.Add(s.Name, s);
        }

        public static void UpdatedVariable(string key) {
            //TODO: this
        }

        public static void UpdatedFunction(ScriptFunction function) {
            if (function.OldName != function.Name) {
                //if(function.
                //FunctionTable.Remove(function.OldName);
                //FunctionTable.Add(function.Name);
            }
        }

        public static int HighestRequiredVariableIndex() {
            return nexthighestindex;
        }

        public static void VerifyStats() {
            foreach (Critter c in CritterManager.Critters.Values) {
                AddNewVariable("Stat_Deaths_" + c.Name);
                AddNewVariable("Stat_GroupDeaths_" + c.NodeGroup);
            }

            foreach (String groupName in Factions.FactionNames()) {
                AddNewVariable("Stat_GroupDeaths_" + groupName);
            }
        }

        public static void AddNewVariable(string variableName, short initialValue = 0) {
            variableName = FixVariableName(variableName);

            if (!GlobalVariables.ContainsKey(variableName)) {
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
