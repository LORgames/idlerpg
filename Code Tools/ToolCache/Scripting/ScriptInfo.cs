using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting {
    public class ScriptInfo {
        public string ScriptName = "";
        public List<String> Errors = new List<string>();

        public int EventFlags = 0;
        public int EventCount = 0;
        public ScriptTypes ScriptType = ScriptTypes.Unknown;

        public ScriptInfo(string Name, ScriptTypes ScriptType) {
            ScriptName = Name;
            this.ScriptType = ScriptType;
        }
    }
}
