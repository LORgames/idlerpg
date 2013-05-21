using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Equipment;

namespace ToolToGameExporter {
    public class ScriptCrusher {

        internal static void ProcessScript(string scriptname, string script, BinaryIO f) {
            //Some variables
            int i = 0;

            ///////////////////////////////////////////////////////////////////////////////////
            /////// PRECOMPILER
            ///////////////////////////////////////////////////////////////////////////////////
            
            //Strip \r characters from the script
            script = script.Replace("\r", "");

            //Count the total events
            List<string> commands = script.Split('\n').ToList<string>(); //Each line is a new command

            for (i = 0; i < commands.Count; i++) {
                string trimmedCommand = commands[i].TrimStart('\t');

                if (trimmedCommand.Length < 2) {
                    commands.RemoveAt(i);
                    i--;
                    continue;
                }

                int indentLevel = commands[i].Length - trimmedCommand.Length;

                if (indentLevel == 0) {
                    if (!ToolCache.Scripting.ValidEventList.ValidEvents.Contains(commands[i].Trim())) {
                        Error("Invalid event: " + commands[i].Trim(), scriptname, f);
                        return;
                    }
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////
            /////// COMPILER
            ///////////////////////////////////////////////////////////////////////////////////

            for(i = 0; i < commands.Count; i++) {
                //Get the next command?
                string command = commands[i];

                //Clean up the commands
                command = command.Trim();
                if (command.Length < 2) continue;

                //Figure out what I was trying to do...
                string action; string parameters;

                if (command.IndexOf(' ') > -1) {
                    action = command.Substring(0, command.IndexOf(' '));
                    parameters = command.Substring(command.IndexOf(' ') + 1);
                } else {
                    action = command;
                    parameters = "";
                }

                switch(action) {
                    case "playsound":
                        if (SoundCrusher.EffectConversions.ContainsKey(parameters)) {
                            f.AddUnsignedShort(0x0001);
                            f.AddShort(SoundCrusher.EffectConversions[parameters]);
                        } else {
                            Error("Cannot find sound effect: '" + parameters + "'", scriptname, f);
                        } break;
                    case "equip":
                        if (EquipmentManager.Equipment.ContainsKey(parameters)) {
                            f.AddUnsignedShort(0x3001);
                            f.AddShort((short)Array.IndexOf(EquipmentCrusher.equipmenttypes, EquipmentManager.Equipment[parameters].Type));
                            f.AddShort(EquipmentCrusher.MappedEquipmentIDs[parameters]);
                        } else {
                            Error("Cannot find equipment item: '" + parameters + "'", scriptname, f);
                        } break;
                    default:
                        Error("Unknown command: " + command, scriptname, f);
                        break;
                }
            }
        }

        private static void Error(string message, string scriptname, BinaryIO f) {
            Processor.Errors.Add("Script:" + scriptname + " " + message);
            f.AddUnsignedShort(0x0000);
        }
    }
}
