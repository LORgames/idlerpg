using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Scripting;
using ToolCache.Scripting.Types;
using ToolCache.Scripting.Extensions;
using ToolCache.Storage;

namespace ToolToGameExporter {
    internal class GlobalVariableCrusher {
        public static Dictionary<string, short> RemappedFunctionNames = new Dictionary<string, short>();
        public static Dictionary<string, short> MappedStringTable = new Dictionary<string, short>();
        
        internal static void Precrush() {
            ExportCrushers.MappedFunctionIDs = RemappedFunctionNames;
            RemappedFunctionNames.Clear();

            List<ScriptFunction> ls = Variables.FunctionTable.Values.ToList<ScriptFunction>();
            for (int i = 0; i < ls.Count; i++) {
                RemappedFunctionNames.Add(ls[i].Name, (short)i);
                System.Diagnostics.Debug.WriteLine("FUNCTION=" + ls[i].Name + " => id." + i);
            }

            ExportCrushers.MappedStringTable = MappedStringTable;
            MappedStringTable.Clear();

            List<String> stk = Variables.StringTable.Keys.ToList<string>();
            for (int i = 0; i < stk.Count; i++) {
                MappedStringTable.Add(stk[i], (short)i);
            }

            ExportVariables();
            ExportStrings();
            ExportStringVariables();
        }

        public static void Go() {
            ExportFunctions();
        }

        private static void ExportVariables() {
            BinaryIO f = new BinaryIO();

            List<ScriptVariable> ls = Variables.GlobalVariables.Values.ToList();
            ls.Sort((a, b) => a.Index.CompareTo(b.Index));

            f.AddShort((short)Variables.DatabaseIDForVariables);
            f.AddShort((short)Variables.HighestRequiredVariableIndex());

            List<int> IndicesToSave = new List<int>();
            List<String> _tVarsToSave = new List<string>();
            int i = 0; int j = 0;
            for (i = 0; i < Variables.HighestRequiredVariableIndex(); i++) {
                System.Diagnostics.Debug.WriteLine("J=" + j + ", I=" + i + ", ls.Count=" + ls.Count + ", ls[j].Index=" + ls[j].Index);

                if (ls.Count >= j && ls[j].Index == i) {
                    System.Diagnostics.Debug.WriteLine("\tFound Var. Name=" + ls[j].Name);

                    f.AddShort(ls[j].InitialValue);

                    if (ls[j].Saveable) {
                        IndicesToSave.Add(ls[j].Index);
                        _tVarsToSave.Add(ls[j].Name);
                    }

                    j++;
                } else {
                    f.AddShort(0);
                }
            }

            f.AddShort((short)IndicesToSave.Count);

            for(i = 0; i < IndicesToSave.Count; i++) {
                f.AddShort((short)IndicesToSave[i]);
            }


            f.Encode(Global.EXPORT_DIRECTORY + "/Variables.bin");
        }

        private static void ExportStringVariables() {
            BinaryIO f = new BinaryIO();

            List<StringVariable> ls = Variables.StringVariables.Values.ToList();
            ls.Sort((a, b) => a.Index.CompareTo(b.Index));

            f.AddShort((short)Variables.DatabaseIDForStrings);
            f.AddShort((short)Variables.HighestRequiredStringVariableIndex());

            List<int> IndicesToSave = new List<int>();
            int i = 0; int j = 0;
            for (i = 0; i < Variables.HighestRequiredStringVariableIndex(); i++) {
                if (ls.Count > j && ls[j].Index == i) {
                    f.AddString(ls[j].InitialValue);

                    if (ls[j].Saveable) {
                        IndicesToSave.Add(ls[j].Index);
                    }

                    j++;
                } else {
                    f.AddString("");
                }
            }

            f.AddShort((short)IndicesToSave.Count);

            for (i = 0; i < IndicesToSave.Count; i++) {
                f.AddShort((short)IndicesToSave[i]);
            }


            f.Encode(Global.EXPORT_DIRECTORY + "/StringVariables.bin");
        }

        private static void ExportStrings() {
            BinaryIO f = new BinaryIO();

            List<String> ls = Variables.StringTable.Values.ToList();
            f.AddShort((short)ls.Count);

            for (int i = 0; i < ls.Count; i++) {
                f.AddString(ls[i]);
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/Strings.bin");
        }

        private static void ExportFunctions() {
            BinaryIO f = new BinaryIO();

            List<ScriptFunction> ls = Variables.FunctionTable.Values.ToList<ScriptFunction>();
            f.AddShort((short)ls.Count);

            for (int i = 0; i < ls.Count; i++) {
                ScriptInfo info = new ScriptInfo("FUNCTION." + ls[i].Name, ScriptTypes.Function);
                ScriptCrusher.ProcessScript(info, ls[i].Script, f);
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/Functions.bin");
        }
    }
}
