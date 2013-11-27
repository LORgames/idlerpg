using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolCache.Scripting.Types {
    public class ScriptVariable {
        public string Name;
        public int Index;
        public short InitialValue;

        public ListViewItem lvi;
        public short TotalReferences;

        public override string ToString() {
            return Name;
        }
    }
}
