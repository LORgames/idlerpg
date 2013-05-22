using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting {
    public class Parser {

        public static void Parse(string script, ScriptInfo info) {
            if (info.ScriptType == ScriptTypes.Unknown) {
                info.Errors.Add("Script type is unknown!");
                return;
            }
        }

        public static List<ScriptCommand> CleanAndDivideScript(string script, ScriptInfo scriptInfo) {
            int i = 0;

            //Strip \r characters from the script
            script = script.Replace("\r", "");

            //Count the total events
            List<ScriptCommand> Commands = new List<ScriptCommand>();
            
            List<string> lines = script.Split('\n').ToList<string>(); //Each line is a new command

            for (i = 0; i < lines.Count; i++) {
                ScriptCommand Command = new ScriptCommand(lines[i], scriptInfo);

                if (Command.Trimmed.Length > 2) {
                    Commands.Add(Command);
                }
            }

            return Commands;
        }

        public static int GetEventCountAndFlags(List<ScriptCommand> Commands, ScriptInfo scriptInfo, out int flags) {
            int count = 0;
            flags = 0;

            for (int i = 0; i < Commands.Count; i++) {
                
            }

            return count;
        }

        public static void Error(string error, ScriptInfo info) {
            info.Errors.Add(error);
        }

    }
}
