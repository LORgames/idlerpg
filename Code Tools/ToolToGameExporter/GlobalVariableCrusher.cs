using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Scripting;

namespace ToolToGameExporter {
    internal class GlobalVariableCrusher {
        public static void Go() {
            ExportVariables();
            ExportStrings();
        }

        private static void ExportVariables() {
            BinaryIO f = new BinaryIO();

            List<ScriptVariable> ls = GlobalVariables.Variables.Values.ToList();
            ls.Sort((a, b) => a.Index.CompareTo(b.Index));

            f.AddShort((short)GlobalVariables.HighestRequiredVariableIndex());

            int j = 0;
            for (int i = 0; i < GlobalVariables.HighestRequiredVariableIndex(); i++) {
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

            List<String> ls = GlobalVariables.StringTable.Values.ToList();
            f.AddShort((short)ls.Count);

            for (int i = 0; i < ls.Count; i++) {
                f.AddString(ls[i]);
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/Strings.bin");
        }
    }
}
