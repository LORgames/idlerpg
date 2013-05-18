using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting {
    public class Parser {

        public static string Parse(string script, ScriptTypes ScriptType) {
            if (ScriptType == ScriptTypes.Unknown) {
                return "Script type is unknown!";
            }

            return "Could not parse. Parser is not fully implemented yet!";
        }

    }
}
