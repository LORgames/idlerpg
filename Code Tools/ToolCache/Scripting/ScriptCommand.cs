using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Equipment;
using ToolCache.Sound;
using ToolCache.Critters;
using System.Text.RegularExpressions;
using ToolCache.General;

namespace ToolCache.Scripting {
    public class ScriptCommand {
        public string Trimmed = "";
        public string Default = "";

        public byte Indent = 0;
        public byte ExpectedIndent = 0;

        public ushort CommandID = 0xFFFF;
        public List<ushort> AdditionalBytecode = new List<ushort>();

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
            ushort param0;
            ushort param1;
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
                    CommandID = 0x1003; CheckUnsignedShortParameter(info); break;
                case "knockback":
                    CommandID = 0x1004; CheckUnsignedShortParameter(info); break;
                case "damagepercent":
                    CommandID = 0x1005; CheckUnsignedShortParameter(info); break;
                case "dot":
                    CommandID = 0x1006;

                    if (Parameters.Split(' ').Length == 2) {
                        if (!ushort.TryParse(Parameters.Split(' ')[0], out param0)) {
                            info.Errors.Add("Cannot convert '" + Parameters + "' into a number.");
                        } else if (!ushort.TryParse(Parameters.Split(' ')[1], out param1)) {
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

        private void CheckUnsignedShortParameter(ScriptInfo info) {
            ushort param0;

            if (!ushort.TryParse(Parameters, out param0)) {
                info.Errors.Add("Cannot convert '" + Parameters + "' into a number.");
            } else {
                this.AdditionalBytecode.Add(param0);
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
                            ProcessScriptType(Info, bits[0]);

                            //Process the other stuff
                            ProcessArrayParametersOfForEach(bits[1], Info);
                        } else {
                            Info.Errors.Add("foreach should be:- foreach <type> in <array/set>");
                        }

                        //Indent stuff
                        IndentBelow(Info, index);

                        //Add the character to start a block
                        AdditionalBytecode.Add(0xF0FD);

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

        /// <summary>
        /// Reads a string with the expected script type and gives an error or adds the type to the bytecode for this command.
        /// </summary>
        /// <param name="Info">The global script object</param>
        /// <param name="typeName">The string containing the expected type. E.g. "Attackable"</param>
        private void ProcessScriptType(ScriptInfo Info, string typeName) {
            ValidTypes scriptType;
            if (!Enum.TryParse<ValidTypes>(typeName, out scriptType)) {
                Info.Errors.Add(typeName + " is not a valid scripting type!");
            } else {
                AdditionalBytecode.Add((ushort)scriptType);
            }
        }

        /// <summary>
        /// Parses the array part of a FOREACH command and optionally injects it into a binaryio
        /// </summary>
        /// <param name="p">The substring after 'in' in foreach [type] in [this function]"/></param>
        /// <param name="Info">The ScriptInfo object for the entire script to pass errors and the like back into</param>
        private void ProcessArrayParametersOfForEach(string p, ScriptInfo Info) {
            string l = p.ToLower();

            if (l.Contains(" and ") || l.Contains(" or ")) {
                Info.Errors.Add("FOREACH does not currently support joins AND or OR");
            } else {
                string regex = "([A-Za-z]+)\\(([A-Za-z0-9,\\.\\s]+)\\)";
                Match m = Regex.Match(p, regex);

                if (!m.Success) {
                    Info.Errors.Add("Unknown command: " + p);
                } else {
                    string arrayValue = m.Groups[1].Value.ToLower();
                    string arrayParam = m.Groups[2].Value.ToLower();

                    switch (arrayValue) {
                        case "front":
                            this.AdditionalBytecode.Add((ushort)0x9000);
                            VerifyCommaSeperatedShorts(arrayParam, 2, Info);
                            break;
                        case "aoe":
                            this.AdditionalBytecode.Add((ushort)0x9001);
                            VerifyCommaSeperatedShorts(arrayParam, 1, Info);
                            break;
                        default:
                            Info.Errors.Add("Unknown Array Type: " + arrayValue);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks a list in the format "a, b, c, d" that all the values are valid shorts 
        /// </summary>
        /// <param name="csvShorts">The list of shorts to process</param>
        /// <param name="expectedFloats">How many shorts we're expecting to find</param>
        /// <param name="Info">The scriptinfo object to inject the shorts into.</param>
        private bool VerifyCommaSeperatedShorts(string csvShorts, int expectedFloats, ScriptInfo Info) {
            string[] values = csvShorts.Split(',');
            short value;

            if (values.Length != expectedFloats) {
                Info.Errors.Add("Expecting " + expectedFloats + " values but got " + values.Length);
                return false;
            }

            foreach (string s in values) {
                if (!short.TryParse(s, out value)) {
                    Info.Errors.Add("Cannot turn " + s + " into a number.");
                    return false;
                } else {
                    this.AdditionalBytecode.Add((ushort)value);
                }
            }

            return true;
        }

        /// <summary>
        /// Marks all the lines that are supposed to be indented below this command
        /// until the next non-indented line or the end of the file, whichever comes first
        /// </summary>
        /// <param name="Info">The command that starts the indent, if, else, foreach, event, etc</param>
        /// <param name="index">The line number of the current commands=</param>
        /// <returns></returns>
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