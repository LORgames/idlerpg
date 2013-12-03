using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;
using ToolCache.Critters;
using System.Text.RegularExpressions;
using ToolCache.Scripting.Types;
using ToolCache.Storage;

namespace ToolCache.Scripting.Extensions {
    public class Variables {
        private const string DATABASE_FILENAME = "GlobalFunctions";

        public static DictionaryEx<string, ScriptVariable> GlobalVariables = new DictionaryEx<string, ScriptVariable>();
        public static DictionaryEx<string, string> StringTable = new DictionaryEx<string, string>();
        public static DictionaryEx<string, ScriptFunction> FunctionTable = new DictionaryEx<string, ScriptFunction>();

        public static int DatabaseIDForVariables = 0;

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

                if (lines.Length > 0 && lines[0].IndexOf("#VERSION ") == 0) {
                    int.TryParse(lines[0].Substring(9), out DatabaseIDForVariables);
                    System.Diagnostics.Debug.WriteLine("Variable DatabaseID=" + DatabaseIDForVariables);
                }

                foreach (String line in lines) {
                    if (line[0] == '#') continue;
                    
                    ScriptVariable s = new ScriptVariable();
                    string[] lineBits = line.Trim().Split(',');

                    if (lineBits.Length != 3 && lineBits.Length != 4) {
                        continue;
                    }

                    s.Name = lineBits[0];
                    int.TryParse(lineBits[1], out s.Index);
                    short.TryParse(lineBits[2], out s.InitialValue);

                    byte b = 0;
                    if (lineBits.Length == 4) byte.TryParse(lineBits[3], out b);
                    if (b == 1) s.Saveable = true;

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
            IStorage f = StorageHelper.LoadStorage(DATABASE_FILENAME, StorageTypes.UTF);

            if (f != null) {
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
            SaveVariables();
            SaveStrings();
            SaveFunctions();
        }

        private static void SaveVariables() {
            List<string> keys = GlobalVariables.Keys.ToList<string>();
            keys.Sort();

            List<string> rows = new List<string>();

            rows.Add("#VERSION " + DatabaseIDForVariables);

            for (int i = 0; i < keys.Count; i++) {
                rows.Add(keys[i] + "," + GlobalVariables[keys[i]].Index + "," + GlobalVariables[keys[i]].InitialValue + "," + (GlobalVariables[keys[i]].Saveable?1:0));
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
            IStorage f = StorageHelper.WriteStorage(StorageTypes.UTF);

            f.AddShort((short)FunctionTable.Count);

            foreach (KeyValuePair<string, ScriptFunction> kvp in FunctionTable) {
                f.AddString(kvp.Key);
                f.AddString(kvp.Value.Script);
            }

            StorageHelper.Save(f, DATABASE_FILENAME);

            f.Dispose();
        }

        public static void AddVariableToDatabase(ScriptVariable s) {
            if (s.lvi == null) {
                s.lvi = new System.Windows.Forms.ListViewItem();
                s.lvi.Checked = s.Saveable;
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

        public static void RepackVariables() {
            //Performs 2 passes, first pass moves all the variables requiring saving to the top, second pass repacks everything else after that
            List<string> keys = GlobalVariables.Keys.ToList<string>();
            keys.Sort();

            int newIndex = 1;

            //Pass 1
            for (int i = 0; i < keys.Count; i++) {
                if(GlobalVariables[keys[i]].Saveable) {
                    GlobalVariables[keys[i]].Index = newIndex;
                    newIndex++;
                }
            }

            //Pass 2
            for (int i = 0; i < keys.Count; i++) {
                if (!GlobalVariables[keys[i]].Saveable) {
                    GlobalVariables[keys[i]].Index = newIndex;
                    newIndex++;
                }
            }

            DatabaseIDForVariables++;
            SaveVariables();
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
