using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Scripting.Types;
using ToolCache.Map;

namespace ToolCache.Scripting {
    public class ScriptInfo {
        public string ScriptName = "";
        public List<String> Errors = new List<string>();
        public List<String> Warnings = new List<string>();

        public List<ScriptCommand> Commands = new List<ScriptCommand>();
        public List<ScriptCommand> Unparsed = new List<ScriptCommand>();

        public int EventFlags = 0;
        public int EventCount = 0;
        public ScriptTypes ScriptType = ScriptTypes.Unknown;

        public Dictionary<String, ScriptVariable> IntegerVariables = new Dictionary<string, ScriptVariable>();
        public Dictionary<String, FloatVariable> FloatingVariables = new Dictionary<string, FloatVariable>();
        public List<string> AnimationNames = new List<string>();

        public ScriptInfo(string Name, ScriptTypes ScriptType) {
            ScriptName = Name;
            this.ScriptType = ScriptType;
        }
    }
}