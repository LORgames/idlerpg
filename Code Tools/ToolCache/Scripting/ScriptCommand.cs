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
using ToolCache.Scripting.Types;

namespace ToolCache.Scripting {
    public class ScriptCommand {
        public string Trimmed = "";

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
            Trimmed = line.Trim();

            if (Trimmed.Length > 2) {
                if (Indent == 0) {
                    Match m = Regex.Match(Trimmed, "var\\s([A-Za-z][A-Za-z0-9_]*)\\s?=\\s?([0-9]+)");

                    if (m.Success) {
                        //Process this as a variable
                        ProcessVariable(info, m);
                    } else {
                        //Process this as an Event
                        ProcessEvent(info);
                    }
                } else {
                    //Process this as an action
                    ProcessAction(info);
                }
            }
        }

        private void ProcessVariable(ScriptInfo info, Match match) {
            string variablename = match.Groups[1].Value;
            short variableValue = short.Parse(match.Groups[2].Value);

            ScriptVariable s = new ScriptVariable();
            s.Name = variablename;
            s.InitialValue = variableValue;
            s.Index = (short)info.Variables.Count;

            info.Variables.Add(variablename, s);
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

            string validRegex = "([A-Za-z]+)\\(([A-Z,a-z0-9\\.\\(\\)\\s]*)\\)";
            Match match = Regex.Match(Trimmed, validRegex);

            if (match.Success && match.Index == 0) {
                Action = match.Groups[1].Value.ToLowerInvariant();
                Parameters = match.Groups[2].Value;

                if (!Commands.All.ContainsKey(Action)) {
                    info.Errors.Add("Cannot find any actions called: " + Action);
                } else {
                    ValidCommand vc = Commands.All[Action];
                    paramBits = Parameters.Split(',');

                    if (paramBits.Length >= vc.MinimumParams && paramBits.Length <= vc.MaximumParams) {
                        CommandID = vc.CommandID;

                        for (int i = 0; i < paramBits.Length; i++) {
                            Param thisParamType = vc.ExpectedParameters[i];
                            paramBits[i] = paramBits[i].Trim();

                            if ((thisParamType & Param.Optional) == Param.Optional) {
                                thisParamType = thisParamType ^ Param.Optional;
                            }

                            #region PARAMTYPES CALCULATIONS
                            switch (thisParamType) {
                                case Param.Void: break; //Obviously void does nothing
                                case Param.Number:
                                    if (!float.TryParse(paramBits[i], out fparam)) {
                                        info.Errors.Add("Cannot convert " + paramBits[i] + " into a number!");
                                    } else {
                                        if (fparam > 370 || fparam < -370) {
                                            info.Errors.Add("Floating point values are limited to the -370 to 370 range!");
                                        } else {
                                            AdditionalBytecode.Add((ushort)((short)(fparam * 100)));
                                        }
                                    } break;
                                case Param.Integer:
                                    if (!ushort.TryParse(paramBits[i], out param0)) {
                                        info.Errors.Add("Cannot convert '" + paramBits[i] + "' into an integer!");
                                    } else {
                                        this.AdditionalBytecode.Add(param0);
                                    } break;
                                case Param.Angle:
                                    if (!short.TryParse(paramBits[i], out sparam)) {
                                        info.Errors.Add("Cannot convert '" + paramBits[i] + "' into an angle!");
                                    } else {
                                        if (sparam < -359 || sparam > 359) info.Warnings.Add("Parameter should be between -359 and 359");
                                        this.AdditionalBytecode.Add((ushort)sparam);
                                    } break;
                                case Param.Boolean:
                                    bool isTrue = (Array.IndexOf(Commands.ValidBooleanNames, paramBits[i]) != -1);
                                    AdditionalBytecode.Add((ushort)(isTrue ? 1 : 0));
                                    break;
                                case Param.String:
                                    info.Errors.Add("Cannot Param.String yet!");
                                    break;
                                case Param.Direction:
                                    switch (paramBits[i].ToLower()) {
                                        case "left": AdditionalBytecode.Add((ushort)0); break;
                                        case "right": AdditionalBytecode.Add((ushort)1); break;
                                        case "up": AdditionalBytecode.Add((ushort)2); break;
                                        case "down": AdditionalBytecode.Add((ushort)3); break;
                                        default: info.Errors.Add("Invalid direction: '" + paramBits[i] + "'. Expected one of the following: 'Left', 'Right', 'Up', 'Down'"); break;
                                    } break;
                                case Param.CritterName:
                                    if (info.RemappedCritterIDs != null && info.RemappedCritterIDs.ContainsKey(paramBits[i])) {
                                        AdditionalBytecode.Add((ushort)info.RemappedCritterIDs[paramBits[i]]);
                                    } else if (!CritterManager.HasCritter(paramBits[i])) {
                                        info.Errors.Add("Cannot find Critter: " + paramBits[i]);
                                    } break;
                                case Param.EffectName:
                                    if (!EffectManager.Effects.ContainsKey(paramBits[i])) {
                                        info.Errors.Add("Cannot find an effect called: " + paramBits[i]);
                                        break;
                                    }

                                    if (info.RemappedEffectIDs != null) {
                                        if (info.RemappedEffectIDs.ContainsKey(paramBits[i])) {
                                            AdditionalBytecode.Add((ushort)info.RemappedEffectIDs[paramBits[i]]);
                                        } else {
                                            info.Errors.Add("Cannot find an effect called: " + paramBits[i] + ".\nEffects without animations are skipped when exporting make sure the effect has an animation as well as checking spelling.");
                                        }
                                    } break;
                                case Param.ObjectName:
                                    if (!MapObjectCache.HasObjectByName(paramBits[i])) {
                                        info.Errors.Add("Cannot find an object called: " + paramBits[i]);
                                        break;
                                    }

                                    if (info.RemappedObjectIDs != null) {
                                        if (info.RemappedObjectIDs.ContainsKey(paramBits[i])) {
                                            AdditionalBytecode.Add((ushort)info.RemappedObjectIDs[paramBits[i]]);
                                        } else {
                                            info.Errors.Add("Cannot find an object called: " + paramBits[i] + ".");
                                        }
                                    } break;
                                case Param.ItemName:
                                    info.Errors.Add("cannot use item name yet.");
                                    break;
                                case Param.EquipmentName:
                                    if (!EquipmentManager.Equipment.ContainsKey(Parameters)) {
                                        info.Errors.Add("Cannot find equipment item: '" + paramBits[i] + "'");
                                    } break;
                                case Param.SoundEffectName:
                                    if (!SoundDatabase.HasEffect(paramBits[i])) {
                                        info.Errors.Add("Cannot find sound effect: '" + paramBits[i] + "'");
                                    } break;
                                case Param.SoundEffectGroup:
                                    if (!SoundDatabase.EffectGroups.ContainsKey(paramBits[i])) {
                                        info.Errors.Add("Cannot find sound effect group: '" + paramBits[i] + "'");
                                    } else if (SoundDatabase.EffectGroups[paramBits[i]].Count == 0) {
                                        info.Errors.Add("Sound effect group '" + paramBits[i] + "' has no sound effects in it!");
                                    } else if (info.RemappedSoundEffectGroups != null) {
                                        AdditionalBytecode.Add((ushort)info.RemappedSoundEffectGroups[paramBits[i]]);
                                    } break;
                                case Param.MusicName:
                                    info.Errors.Add("Cannot Param.MusicName yet!");
                                    break;
                                case Param.Portrait:
                                    info.Errors.Add("Cannot Param.Portrait yet!");
                                    break;
                                case Param.FactionName:
                                    if (!Factions.Has(Parameters)) {
                                        info.Errors.Add("Could not find the faction: " + Parameters);
                                    } else {
                                        AdditionalBytecode.Add((ushort)Factions.GetID(Parameters));
                                    } break;
                                case Param.AnimationName:
                                    if (info.ScriptType == ScriptTypes.Item) {
                                        info.Errors.Add("Loop animation only applies to objects with state based animation.");
                                        break;
                                    }

                                    if (!info.AnimationNames.Contains(Parameters)) {
                                        info.Errors.Add("Cannot find animation: " + Parameters);
                                    } break;
                                case Param.ImageDatabase:
                                    info.Errors.Add("Cannot Param.ImageDatabase yet!");
                                    break;
                                default:
                                    info.Errors.Add("Unknown Param type: " + thisParamType); break;
                            }
                            #endregion
                        }

                        for (int i = paramBits.Length; i < vc.ExpectedParameters.Length; i++) {
                            Param thisParamType = vc.ExpectedParameters[i];

                            if ((thisParamType & Param.Optional) == Param.Optional) {
                                thisParamType = thisParamType ^ Param.Optional;
                            }

                            AdditionalBytecode.AddRange(Commands.DefaultValues[thisParamType]);
                        }
                    } else {
                        if (vc.MinimumParams == vc.MaximumParams) {
                            info.Errors.Add(Action + " expects " + vc.MinimumParams + " parameters but got " + paramBits.Length);
                        } else {
                            info.Errors.Add(Action + " expects between " + vc.MinimumParams + " and " + vc.MaximumParams + " parameters but got " + paramBits.Length);
                        }
                    }
                }
            } else {
                //Not a command probably :)
                Action = Trimmed;
                Parameters = "";
                if (Trimmed.IndexOf(' ') > -1) {
                    Action = Trimmed.Substring(0, Trimmed.IndexOf(' '));
                    Parameters = Trimmed.Substring(Trimmed.IndexOf(' ')+1);
                }

                switch (Action) {
                    case "if":
                        break;
                    case "else":
                        Parameters = ""; break;
                    case "foreach":
                        CommandID = 0x8002; break;
                    default:
                        //See if we have a decrement or increment line (and convert it to the longhand version :)
                        #region CHECK FOR INCREMENT/DECREMENT ++/--
                        Match m = Regex.Match(Trimmed, "([A-Za-z][A-Za-z0-9_]*)(\\+\\+|--)");

                        if (m.Success) {
                            string variableName = m.Groups[1].Value;
                            if (!info.Variables.ContainsKey(variableName)) {
                                info.Errors.Add("Cannot "+(m.Groups[2].Value=="++"?"Increment":"Decrement")+" a variable because cannot find: " + variableName);
                            }

                            if (m.Groups[2].Value == "++") {
                                Trimmed = m.Groups[1].Value + " = " + m.Groups[1].Value + " + 1";
                            } else {
                                Trimmed = m.Groups[1].Value + " = " + m.Groups[1].Value + " - 1";
                            }
                        }
                        #endregion

                        //Might be a variable line or something :)
                        m = Regex.Match(Trimmed, "([A-Za-z][A-Za-z0-9_]*)\\s?=\\s?([ A-Za-z0-9*+/\\-%]+)");

                        if (m.Success) {
                            #region PROCESS MATH BLOCK
                            //Its a variable assignment line
                            CommandID = 0xB000;

                            if (info.Variables.ContainsKey(m.Groups[1].Value)) {
                                AdditionalBytecode.Add(0xBFFD);
                                AdditionalBytecode.Add((ushort)info.Variables[m.Groups[1].Value].Index);
                            } else if (GlobalVariables.Variables.ContainsKey(m.Groups[1].Value)) {
                                //TODO: Update this possibly
                                AdditionalBytecode.Add(0xBFFE);
                                AdditionalBytecode.Add((ushort)GlobalVariables.Variables[m.Groups[1].Value].Index);
                            } else {
                                info.Errors.Add("No variable called: " + m.Groups[1].Value);
                            }

                            string mathblock = m.Groups[2].Value;

                            //First lets get rid of the 'and' and 'or' joins
                            MatchCollection mc = Regex.Matches(mathblock, "(\\+|-|/|\\*|%)");
                            List<string> mathblockBits = new List<string>();

                            int endOfLast = 0;
                            for (int i = 0; i < mc.Count; i++) {
                                Match mathPieceMatch = mc[i];
                                mathblockBits.Add(mathblock.Substring(endOfLast, mathPieceMatch.Index - endOfLast).Trim());
                                mathblockBits.Add(mathPieceMatch.Groups[0].Value.Trim());

                                endOfLast = mathPieceMatch.Index + mathPieceMatch.Length;
                            }

                            mathblockBits.Add(mathblock.Substring(endOfLast));

                            //Now we process the bits :D
                            foreach(string mathBit in mathblockBits) {
                                if (short.TryParse(mathBit, out sparam)) {
                                    AdditionalBytecode.Add(0xBFFF);
                                    AdditionalBytecode.Add((ushort)sparam);
                                } else {
                                    switch (mathBit) {
                                        case "+": AdditionalBytecode.Add(0xB001); break;
                                        case "-": AdditionalBytecode.Add(0xB002); break;
                                        case "*": AdditionalBytecode.Add(0xB003); break;
                                        case "/": AdditionalBytecode.Add(0xB004); break;
                                        case "%": AdditionalBytecode.Add(0xB005); break;
                                        default:
                                            if (VariableExists(mathBit, info)) {
                                                if (info.Variables.ContainsKey(mathBit)) {
                                                    AdditionalBytecode.Add(0xBFFD);
                                                    AdditionalBytecode.Add((ushort)info.Variables[mathBit].Index);
                                                } else if (GlobalVariables.Variables.ContainsKey(mathBit)) {
                                                    AdditionalBytecode.Add(0xBFFE);
                                                    AdditionalBytecode.Add((ushort)GlobalVariables.Variables[mathBit].Index);
                                                }
                                            } else {
                                                info.Errors.Add("Cannot find a variable called: " + mathBit[0]);
                                            } break;
                                    }
                                }
                            }

                            AdditionalBytecode.Add(0xBF01); //Close maths block
                            #endregion
                        } else {
                            if (Parameters != "") {
                                info.Errors.Add("Unknown command: " + Action + " & " + Parameters);
                            } else {
                                info.Errors.Add("Unknown command: " + Action);
                            }
                        }
                        break;
                }
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
            InternalTypes scriptType;
            if (!Enum.TryParse<InternalTypes>(typeName, out scriptType)) {
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
            short param0;

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
                        param0 = (short)Info.AnimationNames.IndexOf(additionalInfo);
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
                    case "isfaction":
                        AdditionalBytecode.Add(0x7008);
                        if (Factions.Has(additionalInfo)) {
                            AdditionalBytecode.Add((ushort)Factions.GetID(additionalInfo));
                        } else {
                            Info.Errors.Add("Could not find faction to compare against '"+additionalInfo+"'");
                        }
                        break;
                    default:
                        //Maybe a variable, lets see if we can find it
                        Match match = Regex.Match(trueCommand, "([A-Za-z][A-Za-z0-9_]*)\\s?(<=|>=|!=|<>|><|>|<|=)\\s?([A-Za-z][A-Za-z0-9]*|[0-9]+)");

                        if(match.Success) {
                            if(VariableExists(match.Groups[1].Value, Info)) {
                                AdditionalBytecode.Add(0x7009); //This is a variable lookup thing

                                //Add the variable information
                                if (Info.Variables.ContainsKey(match.Groups[1].Value)) {
                                    AdditionalBytecode.Add(0xBFFD); //Local variable
                                    AdditionalBytecode.Add((ushort)Info.Variables[match.Groups[1].Value].Index);
                                }

                                //Add the sign
                                switch (match.Groups[2].Value) {
                                    case "=": AdditionalBytecode.Add(0xBE00); break; //Equal To
                                    case "<": AdditionalBytecode.Add(0xBE01); break; //Less Than
                                    case ">": AdditionalBytecode.Add(0xBE02); break; //Greater Than
                                    case "<=":AdditionalBytecode.Add(0xBE03); break; //Less than or equal to
                                    case ">=":AdditionalBytecode.Add(0xBE04); break; //Greater than or equal to
                                    default:  AdditionalBytecode.Add(0xBE05); break; //Not equal to
                                }

                                //Add the other value to compare against
                                if (VariableExists(match.Groups[3].Value, Info)) {
                                    if (Info.Variables.ContainsKey(match.Groups[3].Value)) {
                                        AdditionalBytecode.Add(0xBFFD);
                                        AdditionalBytecode.Add((ushort)Info.Variables[match.Groups[3].Value].Index);
                                    }
                                } else {
                                    //its a number? :)
                                    if (short.TryParse(match.Groups[3].Value, out param0)) {
                                        AdditionalBytecode.Add(0xBFFF);
                                        AdditionalBytecode.Add((ushort)param0);
                                    } else {
                                        Info.Errors.Add("Cannot find a variable called '" + match.Groups[3].Value + "'");
                                    }
                                }
                            } else {
                                Info.Errors.Add(match.Groups[1].Value + " is not a variable.");
                            }
                        } else {
                            Info.Errors.Add("Cannot understand how to IF this bit " + trueCommand);
                        } break;
                }
            }

            //End the param block :)
            AdditionalBytecode.Add(0xF0FE); //End the parameter block
        }

        private bool VariableExists(string p, ScriptInfo Info) {
            return (Info.Variables.ContainsKey(p) || GlobalVariables.Variables.ContainsKey(p));
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
                string regex = "([A-Za-z]+)\\(([A-Za-z0-9,\\.\\s]*)\\)";
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
                        case "myarea":
                            this.AdditionalBytecode.Add((ushort)0x9003);
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