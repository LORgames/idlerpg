using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolCache.Scripting.Types {
    public class StringVariable {
        public string Name;
        public int Index;
        public string InitialValue;

        public bool Saveable = false;

        public ListViewItem lvi;
        public short TotalReferences;

        public override string ToString() {
            return Name;
        }
    }
}
