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

            CleanAndDivideScript(script, info);
        }

        public static void CleanAndDivideScript(string script, ScriptInfo scriptInfo) {
            int i = 0;

            //Strip \r characters from the script
            script = script.Replace("\r", "");

            //Count the total events
            List<string> lines = script.Split('\n').ToList<string>(); //Each line is a new command

            for (i = 0; i < lines.Count; i++) {
                ScriptCommand Command = new ScriptCommand(lines[i], scriptInfo);

                if (Command.Trimmed.Length > 2) {
                    scriptInfo.Commands.Add(Command);
                }
            }

            foreach (ScriptCommand comm in scriptInfo.Commands) {
                comm.Parse(scriptInfo);
            }
        }

    }
}
