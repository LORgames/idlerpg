using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Equipment;
using ToolCache.Sound;
using ToolCache.Critters;
using System.Text.RegularExpressions;

namespace ToolCache.Scripting {
    public class ScriptCommand {
        public string Trimmed = "";
        public string Default = "";

        public byte Indent = 0;
        public byte ExpectedIndent = 0;

        public ushort CommandID = 0xFFFF;

        public string Action = "";
        public string Parameters = "";
        
        public ScriptCommand(string line, ScriptInfo info) {
            string trimmedStart = line.TrimStart('\t');
            Indent = (byte)(line.Length - trimmedStart.Length);

            //Truncate comments
            if (line.IndexOf("//") > -1) {
                line = line.Substring(0, line.IndexOf("//"));
            }

            //Continue processing
            Default = line;
            Trimmed = line.Trim();

            if (Trimmed.Length > 2) {
                if (Indent == 0) {
                    //Process this as an Event
                    ProcessEvent(info);
                } else {
                    //Process this as an action
                    ProcessAction(info);
                }
            }
        }

        public void ProcessEvent(ScriptInfo info) {
            ValidEvents EventID;

            if (!Enum.TryParse<ValidEvents>(Trimmed, out EventID)) {
                info.Errors.Add("Invalid event: " + Trimmed);
            } else {
                CommandID = (ushort)EventID;
                info.EventFlags |= (0x1 << CommandID);
                info.EventCount++;
            }
        }

        public void ProcessAction(ScriptInfo info) {
            short param0;
            short param1;
            string paramPiece;

            //Figure out what this command does...
            if (Trimmed.IndexOf(' ') > -1) {
                Action = Trimmed.Substring(0, Trimmed.IndexOf(' ')).ToLowerInvariant();
                Parameters = Trimmed.Substring(Trimmed.IndexOf(' ') + 1);
            } else {
                Action = Trimmed.ToLowerInvariant();
                Parameters = "";
            }

            
            switch (Action) {
                case "playsound":
                    CommandID = 0x1001;

                    if (!SoundDatabase.HasEffect(Parameters)) {
                        info.Errors.Add("Cannot find sound effect: '" + Parameters + "'");
                    } break;
                case "spawn":
                    CommandID = 0x1002;

                    if (!CritterManager.HasCritter(Parameters)) {
                        info.Errors.Add("Cannot find Critter: " + Parameters);
                    } break;
                case "damage":
                    CommandID = 0x1003;

                    if (!short.TryParse(Parameters, out param0)) {
                        info.Errors.Add("Cannot convert '" + Parameters + "' into a number.");
                    } break;
                case "knockback":
                    CommandID = 0x1004;

                    if (!short.TryParse(Parameters, out param0)) {
                        info.Errors.Add("Cannot convert '" + Parameters + "' into a number.");
                    } break;
                case "damagepercent":
                    CommandID = 0x1005;

                    if (!short.TryParse(Parameters, out param0)) {
                        info.Errors.Add("Cannot convert '" + Parameters + "' into a number.");
                    } break;
                case "dot":
                    CommandID = 0x1006;

                    if (Parameters.Split(' ').Length == 2) {
                        if (!short.TryParse(Parameters.Split(' ')[0], out param0)) {
                            info.Errors.Add("Cannot convert '" + Parameters + "' into a number.");
                        } else if (!short.TryParse(Parameters.Split(' ')[1], out param1)) {
                            info.Errors.Add("Cannot convert '" + Parameters + "' into a number.");
                        }
                    } else {
                        info.Errors.Add("Requires both damage per second and total seconds (1 tick per second).");
                    } break;
                case "equip":
                    CommandID = 0x4001;

                    if (!EquipmentManager.Equipment.ContainsKey(Parameters)) {
                        info.Errors.Add("Cannot find equipment item: '" + Parameters + "'");
                    } break;
                case "playanimation":
                    CommandID = 0x6000;

                    if (!info.AnimationNames.Contains(Parameters)) {
                        info.Errors.Add("Cannot find animation: " + Parameters);
                    } break;
                case "loopanimation":
                    CommandID = 0x6001;

                    if (!info.AnimationNames.Contains(Parameters)) {
                        info.Errors.Add("Cannot find animation: " + Parameters);
                    } break;
                case "if":
                    break;
                case "else":
                    Parameters = ""; break;
                case "foreach":
                    CommandID = 0x8002;
                    break;
                default:
                    if (Parameters != "") {
                        info.Errors.Add("Unknown command: " + Action + " & " + Parameters);
                    } else {
                        info.Errors.Add("Unknown command: " + Action);
                    }

                    break;
            }
        }

        internal void Parse(ScriptInfo Info) {
            int index = Info.Commands.IndexOf(this);
            int i2 = 0;

            if (Indent != ExpectedIndent) {
                Info.Errors.Add("Unexpected Indent! " + Trimmed);
            }

            if (Action != "") {
                switch (Action) {
                    case "if":
                        i2 = IndentBelow(Info, index);
                        if (Info.Commands.Count > i2 && Info.Commands[i2].Action == "else") {
                            CommandID = 0x8001;
                            Info.Commands[i2].Parameters = "PAIRED";
                        } else {
                            CommandID = 0x8000;
                        } break;
                    case "else":
                        if (Parameters != "") Info.Errors.Add("Unpaired else!");
                        break;
                    case "foreach":
                        if (Parameters == "") Info.Errors.Add("Empty foreach");

                        string[] bits = Regex.Split(Parameters, " in ");

                        if (bits.Length == 2) {
                            //Process the type first
                            ValidTypes scriptType;
                            if (!Enum.TryParse<ValidTypes>(bits[0], out scriptType)) {
                                Info.Errors.Add(bits[0] + " is not a valid scripting type!");
                            }

                            //Process the other stuff
                            //Process
                        } else {
                            Info.Errors.Add("foreach should be:- foreach <type> in <set>");
                        }

                        //Indent stuff
                        IndentBelow(Info, index);

                        break;
                }
            } else if (Indent == 0) {
                i2 = index + 1;
                while (Info.Commands.Count > i2 && Info.Commands[i2].Indent > 0) {
                    Info.Commands[i2].ExpectedIndent = (byte)1;
                    i2++;
                }
            }
        }

        private int IndentBelow(ScriptInfo Info, int index) {
            int i2 = index + 1;
            while (Info.Commands.Count > i2 && Info.Commands[i2].Indent > Indent) {
                Info.Commands[i2].ExpectedIndent = (byte)(Indent + 1);
                i2++;
            }

            return i2;
        }
    }
}