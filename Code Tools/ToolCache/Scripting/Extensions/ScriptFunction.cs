using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Extensions {
    public class ScriptFunction {
        public string Name;
        public string Script;

        public string OldName;

        public override string ToString() {
            return Name;
        }
    }
}
