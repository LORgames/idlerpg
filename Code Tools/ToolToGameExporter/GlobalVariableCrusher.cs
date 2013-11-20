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
        
        internal static void Precrush() {
            ExportCrushers.RemappedFunctionIDs = RemappedFunctionNames;
            RemappedFunctionNames.Clear();

            List<ScriptFunction> ls = Variables.FunctionTable.Values.ToList<ScriptFunction>();
            for (int i = 0; i < ls.Count; i++) {
                RemappedFunctionNames.Add(ls[i].Name, (short)i);
            }

            ExportVariables();
            ExportStrings();
        }

        public static void Go() {
            ExportFunctions();
        }

        private static void ExportVariables() {
            BinaryIO f = new BinaryIO();

            List<ScriptVariable> ls = Variables.GlobalVariables.Values.ToList();
            ls.Sort((a, b) => a.Index.CompareTo(b.Index));

            f.AddShort((short)Variables.HighestRequiredVariableIndex());

            int j = 0;
            for (int i = 0; i < Variables.HighestRequiredVariableIndex(); i++) {
                if (ls.Count > j && ls[j].Index == i) {
                    f.AddShort(ls[j].InitialValue);
                    j++;
                } else {
                    f.AddShort(0);
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/Variables.bin");
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
