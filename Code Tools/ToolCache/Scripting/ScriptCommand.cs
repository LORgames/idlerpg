using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Equipment;
using ToolCache.Sound;
using ToolCache.Critters;
using System.Text.RegularExpressions;
using ToolCache.General;
using ToolCache.Effects;
using ToolCache.Map.Objects;

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
            short sparam;
            string paramPiece;
            string[] paramBits;
            float fparam;

            //Figure out what this command does...
            if (Trimmed.IndexOf(' ') > -1) {
                Action = Trimmed.Substring(0, Trimmed.IndexOf(' ')).ToLowerInvariant();
                Parameters = Trimmed.Substring(Trimmed.IndexOf(' ') + 1);
            } else {
                Action = Trimmed.ToLowerInvariant();
                Parameters = "";
            }

            
            switch (Action) {
                case "soundplay":
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

                    paramBits = Parameters.Split(' ');

                    if (paramBits.Length == 2) {
                        if (!ushort.TryParse(paramBits[0], out param0)) {
                            info.Errors.Add("Cannot convert '" + Parameters + "' into a number.");
                        } else if (!ushort.TryParse(paramBits[1], out param1)) {
                            info.Errors.Add("Cannot convert '" + Parameters + "' into a number.");
                        }
                    } else {
                        info.Errors.Add("Requires both damage per second and total seconds (1 tick per second).");
                    } break;
                case "destroy":
                    CommandID = 0x1007;
                    break;
                case "effectspawn":
                    CommandID = 0x1008;

                    paramBits = Parameters.Split(' ');

                    if (paramBits.Length >= 1 && paramBits.Length <= 3) {
                        if (!EffectManager.Effects.ContainsKey(paramBits[0])) {
                            info.Errors.Add("Cannot find an effect called: " + paramBits[0]);
                            break;
                        }

                        if (info.RemappedEffectIDs != null) {
                            if (info.RemappedEffectIDs.ContainsKey(paramBits[0])) {
                                AdditionalBytecode.Add((ushort)info.RemappedEffectIDs[paramBits[0]]);
                            } else {
                                info.Errors.Add("Cannot find an effect called: " + paramBits[0] + ".\nEffects without animations are skipped when exporting make sure the effect has an animation as well as checking spelling.");
                            }
                        }

                        if(paramBits.Length >= 2) {
                            if (short.TryParse(paramBits[1], out sparam)) {
                                AdditionalBytecode.Add((ushort)sparam);
                            } else { info.Errors.Add("No idea how to convert: " + paramBits[1] + " into a number?"); }
                        } else { AdditionalBytecode.Add(0x0); }

                        if (paramBits.Length == 3) {
                            if (short.TryParse(paramBits[2], out sparam)) {
                                AdditionalBytecode.Add((ushort)sparam);
                            } else { info.Errors.Add("No idea how to convert: " + paramBits[2] + " into a number?"); }
                        } else { AdditionalBytecode.Add(0x0); }
                    } else {
                        info.Errors.Add("EffectSpawn expects 1-3 parameters, '<Effect Name> <[OPTIONAL]Offset Forwards> <[OPTIONAL]Offset Sideways>'. NB. Effect name do NOT have spaces in them.");
                    } break;
                case "objectspawn":
                    CommandID = 0x100B;

                    paramBits = Parameters.Split(' ');

                    if (paramBits.Length >= 1 && paramBits.Length <= 3) {
                        if (!MapObjectCache.HasObjectByName(paramBits[0])) {
                            info.Errors.Add("Cannot find an object called: " + paramBits[0]);
                            break;
                        }

                        if (info.RemappedObjectIDs != null) {
                            if (info.RemappedObjectIDs.ContainsKey(paramBits[0])) {
                                AdditionalBytecode.Add((ushort)info.RemappedObjectIDs[paramBits[0]]);
                            } else {
                                info.Errors.Add("Cannot find an object called: " + paramBits[0] + ".");
                            }
                        }

                        if (paramBits.Length >= 2) {
                            if (short.TryParse(paramBits[1], out sparam)) {
                                AdditionalBytecode.Add((ushort)sparam);
                            } else { info.Errors.Add("No idea how to convert: " + paramBits[1] + " into a number?"); }
                        } else { AdditionalBytecode.Add(0x0); }

                        if (paramBits.Length == 3) {
                            if (short.TryParse(paramBits[2], out sparam)) {
                                AdditionalBytecode.Add((ushort)sparam);
                            } else { info.Errors.Add("No idea how to convert: " + paramBits[2] + " into a number?"); }
                        } else { AdditionalBytecode.Add(0x0); }
                    } else {
                        info.Errors.Add("ObjectSpawn expects 1-3 parameters, '<Object Name> <[OPTIONAL]Offset Forwards> <[OPTIONAL]Offset Sideways>'. NB. Another object might share this name or you may have mistyped it. Remember object names are case sensitive!");
                    } break;
                case "equip":
                    CommandID = 0x4001;

                    if (!EquipmentManager.Equipment.ContainsKey(Parameters)) {
                        info.Errors.Add("Cannot find equipment item: '" + Parameters + "'");
                    } break;
                case "animationplay":
                    CommandID = 0x6000;

                    if (info.ScriptType == ScriptTypes.Item) {
                        info.Errors.Add("Loop animation only applies to objects with state based animation.");
                        break;
                    } else if (info.ScriptType == ScriptTypes.Object) {
                        info.Errors.Add("Loop animation only applies to objects with state based animation. Use AnimationRange for objects.");
                        break;
                    }

                    if (!info.AnimationNames.Contains(Parameters)) {
                        info.Errors.Add("Cannot find animation: " + Parameters);
                    } break;
                case "animationloop":
                    CommandID = 0x6001;

                    if (info.ScriptType == ScriptTypes.Item) {
                        info.Errors.Add("Loop animation only applies to objects with state based animation.");
                        break;
                    } else if (info.ScriptType == ScriptTypes.Object) {
                        info.Errors.Add("Loop animation only applies to objects with state based animation. Use AnimationRange for objects.");
                        break;
                    }

                    if (!info.AnimationNames.Contains(Parameters)) {
                        info.Errors.Add("Cannot find animation: " + Parameters);
                    } break;
                case "animationspeed":
                    CommandID = 0x6002;

                    if (info.ScriptType != ScriptTypes.Equipment && info.ScriptType != ScriptTypes.Critter && info.ScriptType != ScriptTypes.Object && info.ScriptType != ScriptTypes.Effect) {
                        info.Errors.Add("AnimationSpeed only applies to objects with direct control of thier animations.");
                        break;
                    }

                    if (float.TryParse(Parameters, out fparam)) {
                        if (fparam > 0.049) {
                            AdditionalBytecode.Add((ushort)(fparam * 20));
                        } else {
                            info.Errors.Add("Expected a value above 0.05 after AnimationSpeed");
                        }
                    } else {
                        info.Errors.Add("Expected a value above 0.05 after AnimationSpeed");
                    } break;
                case "animationrangeloop":
                case "animationrangeplay":
                    if (Action == "animationrangeloop") {
                        CommandID = 0x6004;
                    } else {
                        CommandID = 0x6003;
                    }

                    if (info.ScriptType != ScriptTypes.Object) {
                        info.Errors.Add("AnimationRange[Loop/Play] only apply to Map Objects. Other scripts should use the state based solution: AnimationPlay or AnimationLoop.");
                        break;
                    }

                    paramBits = Parameters.Split(' ');

                    if (paramBits.Length == 2) {
                        if (ushort.TryParse(paramBits[0], out param0) && ushort.TryParse(paramBits[1], out param1)) {
                            AdditionalBytecode.Add(param0);
                            AdditionalBytecode.Add(param1);
                        } else {
                            info.Errors.Add("Could not convert '" + Parameters + "' to 2 positive values.");
                        }
                    } else {
                        info.Errors.Add("Expecting 2 positive integers to represent the frame range.");
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
                        }

                        if (Parameters == "") Info.Errors.Add("Empty if");
                        ProcessParametersOfIf(Info);
                        
                        break;
                    case "else":
                        CommandID = 0x8003;
                        if (Parameters == "") Info.Errors.Add("Unpaired else!");
                        IndentBelow(Info, index);
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
        /// Processes the advanced conditional types of foreach
        /// </summary>
        /// <param name="Info">The global script object</param>
        private void ProcessParametersOfIf(ScriptInfo Info) {
            List<String> paramBits = new List<string>();
            int param0;

            //First lets get rid of the 'and' and 'or' joins
            string regex = "( or )|( and )|(not )";
            MatchCollection mc = Regex.Matches(Parameters, regex);

            int endOfLast = 0;
            for (int i = 0; i < mc.Count; i++) {
                Match m = mc[i];
                paramBits.Add(Parameters.Substring(endOfLast, m.Index - endOfLast).Trim());
                paramBits.Add(m.Groups[0].Value.Trim());

                endOfLast = m.Index + m.Length;
            }

            paramBits.Add(Parameters.Substring(endOfLast));

            AdditionalBytecode.Add(0xF0FD); //Start the param block

            //Now we process each component
            foreach (String pb in paramBits) {
                if (pb.Trim().Length == 0) continue;

                String trueCommand = pb;
                String additionalInfo = "";

                if (trueCommand.IndexOf('(') > -1) {
                    trueCommand = pb.Substring(0, pb.IndexOf('('));
                    additionalInfo = pb.Substring(pb.IndexOf('(') + 1, pb.Length - (pb.IndexOf('(') + 2));
                }
                trueCommand = trueCommand.ToLower();

                switch (trueCommand) {
                    case "and": AdditionalBytecode.Add(0x7000); break;
                    case "or": AdditionalBytecode.Add(0x7001); break;
                    case "not": AdditionalBytecode.Add(0x7002); break;
                    case "random":
                        AdditionalBytecode.Add(0x7003);
                        VerifyCommaSeperatedShorts(additionalInfo, 1, Info);
                        break;
                    case "isalive": AdditionalBytecode.Add(0x7004); break;
                    case "equipped":
                        AdditionalBytecode.Add(0x7005);
                        string unknownError = "Could not find any equipment called:" + additionalInfo;

                        if (Info.RemappedEquipmentIDs != null) {
                            if (Info.RemappedEquipmentIDs.ContainsKey(additionalInfo)) {
                                AdditionalBytecode.Add((ushort)EquipmentManager.Equipment[additionalInfo].Type);
                                AdditionalBytecode.Add((ushort)Info.RemappedEquipmentIDs[additionalInfo]);
                            } else {
                                Info.Errors.Add(unknownError);
                            }
                        } else if (!EquipmentManager.Equipment.ContainsKey(additionalInfo)) {
                            Info.Errors.Add(unknownError);
                        } break;
                    case "animation":
                        param0 = Info.AnimationNames.IndexOf(additionalInfo);
                        AdditionalBytecode.Add(0x7006);
                        AdditionalBytecode.Add((ushort)(param0 > -1 ? param0 : 0x0));
                        if (param0 < 0) Info.Errors.Add("Animation does not exist: " + additionalInfo);
                        break;
                    case "direction":
                        AdditionalBytecode.Add(0x7007);
                        if (additionalInfo.Length == 0) {
                            Info.Errors.Add("No direction specified!");
                            break;
                        }
                        char dl = additionalInfo.ToLower()[0];
                        switch (dl) {
                            case 'l': AdditionalBytecode.Add(0x0); break;
                            case 'r': AdditionalBytecode.Add(0x1); break;
                            case 'u': AdditionalBytecode.Add(0x2); break;
                            case 'd': AdditionalBytecode.Add(0x3); break;
                            default: Info.Errors.Add("Unknown direction: " + additionalInfo); break;
                        } break;
                    case "currentframe":
                        AdditionalBytecode.Add(0x7008);
                        VerifyCommaSeperatedShorts(additionalInfo, 1, Info);
                        break;
                    default:
                        Info.Errors.Add("IF param unknown: " + trueCommand); break;
                }
            }

            //End the param block :)
            AdditionalBytecode.Add(0xF0FE); //End the parametre block
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
                            int totalBits = arrayParam.Split(',').Length;
                            if (totalBits == 2) {
                                this.AdditionalBytecode.Add((ushort)0x9000);
                                VerifyCommaSeperatedShorts(arrayParam, 2, Info);
                            } else if (totalBits == 3) {
                                this.AdditionalBytecode.Add((ushort)0x9002);
                                VerifyCommaSeperatedShorts(arrayParam, 3, Info);
                            }
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
        private void VerifyCommaSeperatedShorts(string csvShorts, int expectedFloats, ScriptInfo Info) {
            string[] values = csvShorts.Split(',');
            short value;

            if (values.Length != expectedFloats) {
                Info.Errors.Add("Expecting " + expectedFloats + " values but got " + values.Length);
                return;
            }

            foreach (string s in values) {
                if (!short.TryParse(s, out value)) {
                    Info.Errors.Add("Cannot turn " + s + " into a number.");
                    return;
                } else {
                    this.AdditionalBytecode.Add((ushort)value);
                }
            }
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