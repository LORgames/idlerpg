using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting {
    public class ScriptInfo {
        public string ScriptName = "";
        public List<String> Errors = new List<string>();

        public List<ScriptCommand> Commands = new List<ScriptCommand>();
        public List<ScriptCommand> Unparsed = new List<ScriptCommand>();

        public int EventFlags = 0;
        public int EventCount = 0;
        public ScriptTypes ScriptType = ScriptTypes.Unknown;

        public List<string> AnimationNames = new List<string>();
        public Dictionary<string, short> RemappedEquipmentIDs;
        public Dictionary<string, short> RemappedEffectIDs;
        public Dictionary<string, short> RemappedObjectIDs;

        public ScriptInfo(string Name, ScriptTypes ScriptType) {
            ScriptName = Name;
            this.ScriptType = ScriptType;
        }
    }
}
