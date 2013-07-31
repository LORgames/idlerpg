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

        public Dictionary<String, ScriptVariable> Variables = new Dictionary<string, ScriptVariable>();
        public List<string> AnimationNames = new List<string>();

        //This is a list of the exporter defined remappings
        public Dictionary<string, short> RemappedEquipmentIDs;
        public Dictionary<string, short> RemappedEffectIDs;
        public Dictionary<string, short> RemappedObjectIDs;
        public Dictionary<string, short> RemappedSoundEffectIDs;
        public Dictionary<string, short> RemappedCritterIDs;

        public ScriptInfo(string Name, ScriptTypes ScriptType) {
            ScriptName = Name;
            this.ScriptType = ScriptType;
        }
    }
}