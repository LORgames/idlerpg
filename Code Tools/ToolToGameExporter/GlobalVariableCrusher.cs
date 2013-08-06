using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Scripting;

namespace ToolToGameExporter {
    internal class GlobalVariableCrusher {
        public static void Go() {
            BinaryIO f = new BinaryIO();

            List<ScriptVariable> ls = GlobalVariables.Variables.Values.ToList();
            ls.Sort((a,b) => a.Index.CompareTo(b.Index));

            f.AddShort((short)GlobalVariables.HighestRequiredIndex());

            int j = 0;
            for (int i = 0; i < GlobalVariables.HighestRequiredIndex(); i++) {
                if (ls[j].Index == i) {
                    f.AddShort(ls[j].InitialValue);
                    j++;
                } else {
                    f.AddShort(0);
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/Variables.bin");
        }
    }
}
