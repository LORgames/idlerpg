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
using ToolCache.UI;
using ToolCache.Map;
using ToolCache.Scripting.Extensions;
using ToolCache.DataLibrary;

namespace ToolCache.Scripting {
    public class ScriptCommand {
        public const string VARIABLE_REGEX = "[A-Za-z][A-Za-z0-9_]*";

        public string Trimmed = "";

        public byte Indent = 0;
        public byte ExpectedIndent = 0;

        private int LineNumber = 0;
        public ushort CommandID = 0xFFFF;
        public List<ushort> AdditionalBytecode = new List<ushort>();

        public string Action = "";
        public string Parameters = "";

        public ValidCommand vc;
        private bool FurtherParsing = false;

        public ScriptCommand(ushort[] bytecode, byte indent, int lineNumber = -1) {
            this.LineNumber = -lineNumber;
            this.Indent = indent;
            this.ExpectedIndent = indent; //TODO: Make sure this can't ever be wrong?

            this.CommandID = bytecode[0];

            for(int i = 1; i < bytecode.Length; i++) {
                AdditionalBytecode.Add(bytecode[i]);
            }
        }

        public ScriptCommand(string line, ScriptInfo info, int lineNumber = -1) {
            this.LineNumber = lineNumber;

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
                    Match m = Regex.Match(Trimmed, "(var|int|float)\\s("+VARIABLE_REGEX+")\\s?=\\s?([0-9]+(\\.[0-9]+)?)");

                    if (m.Success) {
                        //Process this as a variable
                        ProcessVariable(info, m);
                    } else {
                        if (info.ScriptType != ScriptTypes.Function) {
                            //Process this as an Event
                            ProcessEvent(info);
                        } else {
                            ProcessAction(info);
                        }
                    }
                } else {
                    //Process this as an action
                    ProcessAction(info);
                }
            }
        }

        private void ProcessVariable(ScriptInfo info, Match match) {
            string variablename = match.Groups[2].Value;

            if (match.Groups[1].Value == "var" || match.Groups[1].Value == "int") {
                short variableValue = short.Parse(match.Groups[3].Value);

                ScriptVariable s = new ScriptVariable();
                s.Name = variablename;
                s.InitialValue = variableValue;
                s.Index = (short)info.IntegerVariables.Count;

                info.IntegerVariables.Add(variablename, s);
            } else {
                float variableValue = float.Parse(match.Groups[3].Value);

                FloatVariable s = new FloatVariable();
                s.Name = variablename;
                s.InitialValue = variableValue;
                s.Index = (short)info.FloatingVariables.Count;

                info.FloatingVariables.Add(variablename, s);
            }
        }

        public void ProcessEvent(ScriptInfo info) {
            ValidEvents EventID;

            if (!Enum.TryParse<ValidEvents>(Trimmed, out EventID)) {
                info.Errors.Add("Invalid event: " + Trimmed+ ErrorEnding()+ ErrorEnding());
            } else {
                CommandID = (ushort)EventID;
                info.EventFlags |= (0x1 << CommandID);
                info.EventCount++;
            }
        }

        public void ProcessAction(ScriptInfo info) {
            string validRegex = "([A-Za-z]+)\\(([A-Z,a-z0-9_~\\-\\.\\(\\)\\s>\"!@#\\$%\\^&\\*\\(\\){}]*)\\)";
            Match match = Regex.Match(Trimmed, validRegex);

            if (match.Success && match.Index == 0) {
                Action = match.Groups[1].Value.ToLowerInvariant();
                Parameters = match.Groups[2].Value;

                if (!Commands.All.ContainsKey(Action)) {
                    info.Errors.Add("Cannot find any actions called: " + Action+ ErrorEnding()+ ErrorEnding());
                } else {
                    vc = Commands.All[Action];
                    CommandID = vc.CommandID;
                    ProcessParams(info, vc, Parameters);
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
                    case "witheach":
                        CommandID = 0x8002; break;
                    default:
                        //See if we have a decrement or increment line (and convert it to the longhand version :)
                        #region CHECK FOR INCREMENT/DECREMENT ++/--
                        Match m = Regex.Match(Trimmed, "(" + VARIABLE_REGEX + ")(\\+\\+|--)");

                        if (m.Success) {
                            string variableName = m.Groups[1].Value;
                            if (!VariableExists(variableName, info)) {
                                info.Errors.Add("Cannot " + (m.Groups[2].Value == "++" ? "Increment" : "Decrement") + " a variable because cannot find one called '" + variableName + "'"+ ErrorEnding());
                            }

                            if (m.Groups[2].Value == "++") {
                                Trimmed = m.Groups[1].Value + " = " + m.Groups[1].Value + " + 1";
                            } else {
                                Trimmed = m.Groups[1].Value + " = " + m.Groups[1].Value + " - 1";
                            }
                        }
                        #endregion

                        //Might be a variable line or something :)
                        m = Regex.Match(Trimmed, "(" + VARIABLE_REGEX + ")\\s?=(.+)");
                        Regex mathcomreg = new Regex("([A-Za-z0-9]+)\\((.+)\\)");

                        if (m.Success) {
                            #region PROCESS MATH BLOCK
                            //Its a variable assignment line
                            CommandID = 0xB000;

                            if (!WriteVariableIfExists(m.Groups[1].Value, info, false)) {
                                info.Errors.Add("No variable called: " + m.Groups[1].Value + ErrorEnding());
                            }

                            string mathblock = m.Groups[2].Value.Trim();

                            //Find all the maths symbols :)
                            MatchCollection mc = Regex.Matches(mathblock, "(\\+|-|/|\\*|%|\\||&|\\^|~|{|})");
                            List<string> mathblockBits = new List<string>();

                            int endOfLast = 0;
                            for (int i = 0; i < mc.Count; i++) {
                                Match mathPieceMatch = mc[i];
                                mathblockBits.Add(mathblock.Substring(endOfLast, mathPieceMatch.Index - endOfLast).Trim());
                                mathblockBits.Add(mathPieceMatch.Groups[0].Value.Trim());

                                endOfLast = mathPieceMatch.Index + mathPieceMatch.Length;
                            }

                            mathblockBits.Add(mathblock.Substring(endOfLast).Trim());

                            //Now we process the bits :D
                            foreach(string mathBit in mathblockBits) {
                                switch (mathBit) {
                                    case "+": AdditionalBytecode.Add(0xB001); break;    //Add
                                    case "-": AdditionalBytecode.Add(0xB002); break;    //Subtract
                                    case "*": AdditionalBytecode.Add(0xB003); break;    //Multiply
                                    case "/": AdditionalBytecode.Add(0xB004); break;    //Divide
                                    case "%": AdditionalBytecode.Add(0xB005); break;    //Modulo
                                    case "|": AdditionalBytecode.Add(0xB006); break;    //Bitwise OR
                                    case "&": AdditionalBytecode.Add(0xB007); break;    //Bitwise AND
                                    case "^": AdditionalBytecode.Add(0xB008); break;    //Bitwise XOR
                                    case "~": AdditionalBytecode.Add(0xB009); break;    //Bitwise NOT
                                    case "{": AdditionalBytecode.Add(0xB00A); break;    //Bitwise SHIFT LEFT
                                    case "}": AdditionalBytecode.Add(0xB00B); break;    //Bitwise SHIFT RIGHT
                                    default:
                                        if (!WriteVariableIfExists(mathBit, info)) {
                                            //Hopefully we have a math command :)
                                            Match mathcommatch = mathcomreg.Match(mathBit);

                                            if (mathcommatch.Success) {
                                                if(Commands.MathFunctions.ContainsKey(mathcommatch.Groups[1].Value.ToLower())) {
                                                    ValidCommand vcp = Commands.MathFunctions[mathcommatch.Groups[1].Value.ToLower()];
                                                    AdditionalBytecode.Add(0xBFFC);
                                                    AdditionalBytecode.Add(vcp.CommandID);
                                                    ProcessParams(info, vcp, mathcommatch.Groups[2].Value);
                                                } else {
                                                    info.Errors.Add("Cannot find a math command called: " + mathcommatch.Groups[1].Value + ErrorEnding());
                                                }
                                            } else {
                                                info.Errors.Add("Cannot find a variable called: '" + mathBit + "'" + ErrorEnding());
                                            }
                                        } break;
                                }
                            }

                            AdditionalBytecode.Add(0xBF01); //Close maths block
                            #endregion
                        } else {
                            if (Parameters != "") {
                                info.Errors.Add("Unknown command: " + Action + " " + Parameters + ErrorEnding());
                            } else {
                                info.Errors.Add("Unknown command: " + Action + ErrorEnding());
                            }
                        }
                        break;
                }
            }
        }

        private void ProcessParams(ScriptInfo info, ValidCommand vcp, string ParamString) {
            short sparam;
            float fparam;
            string[] paramBits = ParamString.Split(',');

            if (paramBits.Length >= vcp.MinimumParams && paramBits.Length <= vcp.MaximumParams) {
                for (int i = 0; i < paramBits.Length; i++) {
                    Param thisParamType = vcp.ExpectedParameters[i];
                    paramBits[i] = paramBits[i].Trim();

                    if ((thisParamType & Param.Optional) == Param.Optional) {
                        thisParamType = thisParamType ^ Param.Optional;
                    }

                    if (paramBits[i].Length > 5 && paramBits[i][0] == '~') {
                        if (LinkDatabase(paramBits[i], info, thisParamType)) {
                            continue;
                        }
                    }

                    switch (thisParamType) {
                        case Param.Void: break; //Obviously void does nothing
                        case Param.Number: case Param.Integer:
                            if (!WriteVariableIfExists(paramBits[i], info)) {
                                info.Errors.Add("Cannot convert '" + paramBits[i] + "' into an number!" + ErrorEnding());
                            } break;
                        case Param.Angle:
                            if (!short.TryParse(paramBits[i], out sparam)) {
                                info.Errors.Add("Cannot convert '" + paramBits[i] + "' into an angle!" + ErrorEnding());
                            } else {
                                if (sparam < -359 || sparam > 359) info.Warnings.Add("Parameter should be between -359 and 359" + ErrorEnding());
                                this.AdditionalBytecode.Add((ushort)0xBFFF); //Static number indicator
                                this.AdditionalBytecode.Add((ushort)sparam);
                            } break;
                        case Param.Boolean:
                            bool isTrue = (Array.IndexOf(Commands.ValidBooleanNames, paramBits[i]) != -1);
                            AdditionalBytecode.Add((ushort)(isTrue ? 1 : 0));
                            break;
                        case Param.String:
                            Match strM = Regex.Match(paramBits[i], "\"([A-Za-z 0-9\\.\\(\\)!@#\\$%\\^&\\*<>'{}_\\-]*)\"");

                            if (Variables.StringVariables.ContainsKey(paramBits[i])) {
                                AdditionalBytecode.Add(0x2); //Variable String
                                AdditionalBytecode.Add((ushort)Variables.StringVariables[paramBits[i]].Index);
                            } else if (Variables.StringTable.ContainsKey(paramBits[i])) {
                                AdditionalBytecode.Add(0x0); //Static String

                                if (ExportCrushers.MappedStringTable != null && ExportCrushers.MappedStringTable.ContainsKey(paramBits[i])) {
                                    AdditionalBytecode.Add((ushort)ExportCrushers.MappedStringTable[paramBits[i]]);
                                } else {
                                    info.Errors.Add("String table kind of broke!!" + ErrorEnding());
                                }
                            } else if(strM.Success) {
                                AdditionalBytecode.Add(0x1); //Encoded String

                                Byte[] encoded = Encoding.UTF8.GetBytes(StringMagic.PrepareString(strM.Groups[1].Value, true));
                                AdditionalBytecode.Add((ushort)encoded.Length);

                                for(int z = 0; z < encoded.Length; z = z+2) {
                                    int z0 = encoded[z + 0];
                                    int z1 = encoded.Length == z+1 ? 0 : encoded[z + 1];

                                    ushort y = (ushort)((z0 << 8) | z1);
                                    AdditionalBytecode.Add(y);
                                }
                            } else {
                                info.Errors.Add("String does not suit the requirements for encoding! (or could not find that string?)" + ErrorEnding());
                            } break;
                        case Param.Direction:
                            switch (paramBits[i].ToLower()) { 
                                case "left": AdditionalBytecode.Add((ushort)0); break;
                                case "right": AdditionalBytecode.Add((ushort)1); break;
                                case "up": AdditionalBytecode.Add((ushort)2); break;
                                case "down": AdditionalBytecode.Add((ushort)3); break;
                                default: info.Errors.Add("Invalid direction: '" + paramBits[i] + "'. Expected one of the following: 'Left', 'Right', 'Up', 'Down'" + ErrorEnding()); break;
                            } break;
                        case Param.CritterName:
                            if (ExportCrushers.MappedCritterIDs != null && ExportCrushers.MappedCritterIDs.ContainsKey(paramBits[i])) {
                                AdditionalBytecode.Add((ushort)ExportCrushers.MappedCritterIDs[paramBits[i]]);
                            } else if (!CritterManager.HasCritter(paramBits[i])) {
                                info.Errors.Add("Cannot find Critter: " + paramBits[i] + ErrorEnding());
                            } break;
                        case Param.EffectName:
                            if (!EffectManager.Effects.ContainsKey(paramBits[i])) {
                                info.Errors.Add("Cannot find an effect called: " + paramBits[i] + ErrorEnding());
                                break;
                            }

                            if (ExportCrushers.MappedEffectIDs != null) {
                                if (ExportCrushers.MappedEffectIDs.ContainsKey(paramBits[i])) {
                                    AdditionalBytecode.Add((ushort)ExportCrushers.MappedEffectIDs[paramBits[i]]);
                                } else {
                                    info.Errors.Add("Cannot find an effect called: " + paramBits[i] + ".\nEffects without animations are skipped when exporting make sure the effect has an animation as well as checking spelling." + ErrorEnding());
                                }
                            } break;
                        case Param.ObjectName:
                            if (!MapObjectCache.HasObjectByName(paramBits[i])) {
                                info.Errors.Add("Cannot find an object called: " + paramBits[i] + ErrorEnding());
                                break;
                            }

                            if (ExportCrushers.MappedObjectIDs != null) {
                                if (ExportCrushers.MappedObjectIDs.ContainsKey(paramBits[i])) {
                                    AdditionalBytecode.Add((ushort)ExportCrushers.MappedObjectIDs[paramBits[i]]);
                                } else {
                                    info.Errors.Add("Cannot find an object called: " + paramBits[i] + "." + ErrorEnding());
                                }
                            } break;
                        case Param.ItemName:
                            info.Errors.Add("Cannot use item name yet." + ErrorEnding());
                            break;
                        case Param.EquipmentName:
                            if (!EquipmentManager.Equipment.ContainsKey(Parameters)) {
                                info.Errors.Add("Cannot find equipment item: '" + paramBits[i] + "'" + ErrorEnding());
                            } else {
                                if (ExportCrushers.MappedEquipmentIDs != null) {
                                    AdditionalBytecode.Add((ushort)EquipmentManager.Equipment[paramBits[i]].Type);
                                    AdditionalBytecode.Add((ushort)ExportCrushers.MappedEquipmentIDs[paramBits[i]]);
                                }
                            } break;
                        case Param.SoundEffectName:
                            if (!SoundDatabase.HasEffect(paramBits[i])) {
                                info.Errors.Add("Cannot find sound effect: '" + paramBits[i] + "'" + ErrorEnding());
                            } else {
                                if (ExportCrushers.MappedSoundEffectIDs != null) {
                                    AdditionalBytecode.Add((ushort)ExportCrushers.MappedSoundEffectIDs[paramBits[i]]);
                                }
                            } break;
                        case Param.SoundEffectGroup:
                            if (!SoundDatabase.EffectGroups.ContainsKey(paramBits[i])) {
                                info.Errors.Add("Cannot find sound effect group: '" + paramBits[i] + "'" + ErrorEnding());
                            } else if (SoundDatabase.EffectGroups[paramBits[i]].Count == 0) {
                                info.Errors.Add("Sound effect group '" + paramBits[i] + "' has no sound effects in it!" + ErrorEnding());
                            } else if (ExportCrushers.MappedSoundEffectGroups != null) {
                                AdditionalBytecode.Add((ushort)ExportCrushers.MappedSoundEffectGroups[paramBits[i]]);
                            } break;
                        case Param.MusicName:
                            info.Errors.Add("Cannot Param.MusicName yet!" + ErrorEnding());
                            break;
                        case Param.Portrait:
                            info.Errors.Add("Cannot Param.Portrait yet!" + ErrorEnding());
                            break;
                        case Param.FactionName:
                            if (!Factions.Has(paramBits[i])) {
                                info.Errors.Add("Could not find the faction: " + paramBits[i] + ErrorEnding());
                            } else {
                                AdditionalBytecode.Add((ushort)Factions.GetID(paramBits[i]));
                            } break;
                        case Param.AnimationName:
                            short param0 = (short)info.AnimationNames.IndexOf(paramBits[i]);
                            AdditionalBytecode.Add((ushort)(param0 > -1 ? param0 : 0x0));
                            if (param0 < 0) info.Errors.Add("Animation does not exist: " + paramBits[i] + ErrorEnding());
                            break;
                        case Param.AIType:
                            if (!AITypesHelper.StringLowerToValue.ContainsKey(paramBits[i].ToLower())) {
                                info.Errors.Add("Cannot find AIType: " + paramBits[i] + ErrorEnding());
                                break;
                            }

                            AdditionalBytecode.Add(AITypesHelper.StringLowerToValue[paramBits[i].ToLower()]); break;
                        case Param.AIEventType:
                            if (EventsHelper.AIScriptEvents.ContainsKey(paramBits[i].ToLower())) {
                                AdditionalBytecode.Add(0xBFFF); //Static number
                                AdditionalBytecode.Add(EventsHelper.AIScriptEvents[paramBits[i].ToLower()]);
                            } else {
                                info.Errors.Add("Cannot find an AIEvent called: " + paramBits[i] + ErrorEnding());
                            } break;
                        case Param.UIPanel:
                            if (UIManager.GetPanelID(paramBits[i]) > -1) {
                                AdditionalBytecode.Add((ushort)UIManager.GetPanelID(paramBits[i]));
                            } else {
                                info.Errors.Add("Cannot find a UIPanel called " + paramBits[i] + ErrorEnding());
                            } break;
                        case Param.UIElement:
                            if (paramBits[i].Count(c => c == '>') == 1) {
                                int panelID = UIManager.GetPanelID(paramBits[i].Split('>')[0]);

                                if (panelID > -1) {
                                    AdditionalBytecode.Add((ushort)panelID);

                                    int elementID = UIManager.GetElementID(paramBits[i].Split('>')[1], UIManager.Panels[panelID]);

                                    if (elementID > -1) {
                                        AdditionalBytecode.Add((ushort)elementID);
                                    } else {
                                        info.Errors.Add("Cannot find a UIElement called " + paramBits[i].Split('>')[1] + ErrorEnding());
                                    }
                                } else {
                                    info.Errors.Add("Cannot find a UIPanel called " + paramBits[i].Split('>')[0] + ErrorEnding());
                                }
                            } else {
                                info.Errors.Add("Expecting both a UIPanel and a UIElement but didn't find a '>' seperation character!" + ErrorEnding());
                            } break;
                        case Param.UILayer:
                            if (paramBits[i].Count(c => c == '>') == 2) {
                                int panelID = UIManager.GetPanelID(paramBits[i].Split('>')[0]);

                                if (panelID > -1) {
                                    AdditionalBytecode.Add((ushort)panelID);

                                    int elementID = UIManager.GetElementID(paramBits[i].Split('>')[1], UIManager.Panels[panelID]);

                                    if (elementID > -1) {
                                        AdditionalBytecode.Add((ushort)elementID);

                                        int layerID = UIManager.GetPanelID(paramBits[i].Split('>')[2], UIManager.Panels[panelID].Elements[elementID]);

                                        if (layerID > -1) {
                                            AdditionalBytecode.Add((ushort)layerID);
                                        } else {
                                            info.Errors.Add("Cannot find a UILayer called " + paramBits[i].Split('>')[2] + ErrorEnding());
                                        }
                                    } else {
                                        info.Errors.Add("Cannot find a UIElement called " + paramBits[i].Split('>')[1] + ErrorEnding());
                                    }
                                } else {
                                    info.Errors.Add("Cannot find a UIPanel called " + paramBits[i].Split('>')[0] + ErrorEnding());
                                }
                            } else {
                                info.Errors.Add("Expecting a UIPanel, a UIElement and a UILayer but didn't find 2x '>' seperation characters!" + ErrorEnding());
                            } break;
                        case Param.ScriptTarget:
                            if (Commands.ScriptTargets.ContainsKey(paramBits[i].ToLower())) {
                                AdditionalBytecode.Add(Commands.ScriptTargets[paramBits[i].ToLower()]);
                            } else {
                                info.Errors.Add("Cannot find a script target called '" + paramBits[i] + "'" + ErrorEnding());
                            } break;
                        case Param.MapName:
                            if (MapPieceCache.GetMapByName(paramBits[i]) != null) {
                                if (ExportCrushers.MappedMapIDs != null) {
                                    AdditionalBytecode.Add((ushort)ExportCrushers.MappedMapIDs[paramBits[i]]);
                                }
                            } else {
                                info.Errors.Add("Cannot find a map called '" + paramBits[i] + "', capitalization matters with map names! " + ErrorEnding());
                            } break;
                        case Param.SpawnRegion:
                            if (info.ScriptType == ScriptTypes.Map && ExportCrushers.CurrentMap != null) {
                                int z = -1;

                                for (int y = 0; y < ExportCrushers.CurrentMap.Spawns.Count; y++) {
                                    if (ExportCrushers.CurrentMap.Spawns[y].Name == paramBits[i]) {
                                        z = y;
                                        break;
                                    }
                                }
                                
                                if(z > -1) {
                                    AdditionalBytecode.Add((ushort)z);
                                } else {
                                    info.Errors.Add("Cannot find a spawn region called " + paramBits[i] + ErrorEnding());
                                }
                            } else {
                                info.Errors.Add("Only Map Scripts can control spawn regions!" + ErrorEnding());
                            } break;
                        case Param.NetworkType:
                            if (Commands.NetworkTypes.ContainsKey(paramBits[i].ToLower())) {
                                AdditionalBytecode.Add(Commands.NetworkTypes[paramBits[i].ToLower()]);
                            } else {
                                info.Errors.Add("Cannot find a network type called '" + paramBits[i] + "' perhaps its unsupported at the moment."+ErrorEnding());
                            } break;
                        case Param.Function:
                            if (Variables.FunctionTable.ContainsKey(paramBits[i])) {
                                if (ExportCrushers.MappedFunctionIDs != null) {
                                    AdditionalBytecode.Add((ushort)ExportCrushers.MappedFunctionIDs[paramBits[i]]);
                                }
                            } else {
                                info.Errors.Add("Cannot find a function called '" + paramBits[i] + "' perhaps the capitalization is wrong. It matters with functions!" + ErrorEnding());
                            } break;
                        case Param.Buff:
                            if (BuffManager.HasBuff(paramBits[i])) {
                                if (ExportCrushers.MappedBuffIDs != null) {
                                    if (ExportCrushers.MappedBuffIDs.ContainsKey(paramBits[i])) {
                                        AdditionalBytecode.Add((ushort)ExportCrushers.MappedBuffIDs[paramBits[i]]);
                                    } else {
                                        info.Errors.Add("Buff '" + paramBits[i] + "' was not exported correctly?" + ErrorEnding());
                                    }
                                }
                            } else {
                                info.Errors.Add("There isn't a buff called '" + paramBits[i] + "'." + ErrorEnding());
                            } break;
                        case Param.ObjectType:
                            InternalTypes scriptType;
                            if (!Enum.TryParse<InternalTypes>(paramBits[i], out scriptType)) {
                                info.Errors.Add(paramBits[i] + " is not a valid scripting type!" + ErrorEnding());
                            } else {
                                AdditionalBytecode.Add((ushort)scriptType);
                            }
                            break;
                        default:
                            info.Errors.Add("Unknown Param type: " + thisParamType + ErrorEnding()); break;
                    }
                }

                for (int i = paramBits.Length; i < vcp.ExpectedParameters.Length; i++) {
                    Param thisParamType = vcp.ExpectedParameters[i];

                    if ((thisParamType & Param.Optional) == Param.Optional) {
                        thisParamType = thisParamType ^ Param.Optional;
                    }

                    AdditionalBytecode.AddRange(Commands.DefaultValues[thisParamType]);
                }
            } else {
                if (vcp.MinimumParams == vcp.MaximumParams) {
                    info.Errors.Add(Action + " expects " + vcp.MinimumParams + " parameters but got " + paramBits.Length + ErrorEnding());
                } else {
                    info.Errors.Add(Action + " expects between " + vcp.MinimumParams + " and " + vcp.MaximumParams + " parameters but got " + paramBits.Length + ErrorEnding());
                }
            }

            if (vcp.WillIndent) {
                FurtherParsing = true;
            }
        }

        private bool LinkDatabase(string databaseIdentifier, ScriptInfo info, Param expectedType) {
            if (databaseIdentifier[0] != '~') {
                info.Errors.Add("Database identifiers always begin with a '~' character!" + ErrorEnding());
                return false;
            }

            if (databaseIdentifier.Length < 6) {
                info.Errors.Add("Database identifiers must be at least 5 characters long!" + ErrorEnding());
                return false;
            }

            string[] subParamBits = databaseIdentifier.Substring(1).Split('>');
            short sparam;
            bool useVar;

            if (subParamBits.Length == 3) {
                string database = subParamBits[0];
                string column = subParamBits[1];
                string row = subParamBits[2];

                DataLibrary.DBLibrary lib = DataLibrary.DBLibraryManager.GetLibrary(database);

                if (lib == null) {
                    info.Errors.Add("Cannot find a database named '" + database + "'" + ErrorEnding());
                } else {
                    if (ExportCrushers.MappedDatabaseNames != null) {
                        if (ExportCrushers.MappedDatabaseNames.ContainsKey(database)) {
                            AdditionalBytecode.Add((ushort)ExportCrushers.MappedDatabaseNames[database]);
                        } else {
                            info.Errors.Add("The database was not compiled for exporting. Perhaps it is empty?" + ErrorEnding());
                        }
                    }

                    sparam = 0;
                    useVar = false;

                    //Now find the column
                    if (!short.TryParse(column, out sparam)) {
                        if (!VariableExists(column, info)) {
                            sparam = (short)lib.GetColumnID(column);
                            if (sparam == -1) {
                                info.Errors.Add("Cannot find a column called '" + column + "'" + ErrorEnding());
                                return false;
                            }
                        } else {
                            useVar = true;
                        }
                    }

                    if (!useVar && lib.Column_Names.Count <= sparam) {
                        info.Errors.Add("Database '" + database + "' does not have " + sparam + " columns!" + ErrorEnding());
                        return false;
                    }

                    //Now that we have the column, lets make sure its valid
                    if (lib.GetColumnType(sparam) == expectedType) {
                        //Put the column id into the bytecode
                        if (useVar) {
                            WriteVariableIfExists(column, info);
                        } else {
                            WriteVariableIfExists(sparam.ToString(), info);
                        }
                    } else {
                        info.Errors.Add("Cannot turn a " + lib.GetColumnType(sparam) + " into an "+expectedType+"!" + ErrorEnding());
                    }

                    //Now find the row
                    sparam = 0;
                    useVar = false;

                    if (!WriteVariableIfExists(row, info)) {
                        info.Errors.Add("Sorry, we don't yet support named rows!" + ErrorEnding());
                    }

                    if (lib.Rows.Count > sparam) {
                        AdditionalBytecode.Add((ushort)sparam);
                    } else {
                        info.Errors.Add("Database '" + database + "' does not have " + sparam + " rows!" + ErrorEnding());
                        return false;
                    }
                }
            } else {
                info.Errors.Add("Cannot extract parameter data!" + ErrorEnding());
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds an ending section to error and warning messages
        /// </summary>
        /// <returns>The line ending for messages</returns>
        private string ErrorEnding() {
            return " (on line " + LineNumber + ")";
        }

        private bool WriteVariableIfExists(string mathBit, ScriptInfo info, bool allowShorts = true) {
            short sparam; float fparam;

            if (allowShorts && short.TryParse(mathBit, out sparam)) {
                AdditionalBytecode.Add(0xBFFF);
                AdditionalBytecode.Add((ushort)sparam);
                return true;
            } else if (info.IntegerVariables.ContainsKey(mathBit)) {
                AdditionalBytecode.Add(0xBFFD);
                AdditionalBytecode.Add((ushort)info.IntegerVariables[mathBit].Index);
                return true;
            } else if (Variables.GlobalVariables.ContainsKey(mathBit)) {
                AdditionalBytecode.Add(0xBFFE);
                AdditionalBytecode.Add((ushort)Variables.GlobalVariables[mathBit].Index);
                return true;
            } else if (info.FloatingVariables.ContainsKey(mathBit)) {
                AdditionalBytecode.Add(0xBFFA);
                AdditionalBytecode.Add((ushort)info.FloatingVariables[mathBit].Index);
                return true;
            } else if (float.TryParse(mathBit, out fparam)) {
                AdditionalBytecode.Add(0xBFFB);
                byte[] floatBytes = BitConverter.GetBytes(fparam);
                if (BitConverter.IsLittleEndian) { Array.Reverse(floatBytes); }

                sparam = (short)((floatBytes[0] << 8) | floatBytes[1]); AdditionalBytecode.Add((ushort)sparam);
                sparam = (short)((floatBytes[2] << 8) | floatBytes[3]); AdditionalBytecode.Add((ushort)sparam);

                return true;
            }
            
            return false;
        }

        internal void Parse(ScriptInfo Info) {
            int index = Info.Commands.IndexOf(this);
            int i2 = 0;

            if (Indent != ExpectedIndent) {
                Info.Errors.Add("Unexpected Indent! " + Trimmed + " Expected=" + ExpectedIndent + " IndentActual=" + Indent + ErrorEnding());
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

                        if (Parameters == "") Info.Errors.Add("Empty if"+ ErrorEnding());
                        ProcessParametersOfIf(Info);
                        
                        break;
                    case "else":
                        CommandID = 0x8003;
                        if (Parameters == "") Info.Errors.Add("Unpaired else!"+ ErrorEnding());
                        IndentBelow(Info, index);
                        break;
                    case "witheach":
                        if (Parameters == "") Info.Errors.Add("Empty witheach " + ErrorEnding());

                        string[] bits = Regex.Split(Parameters, " in ");

                        if (bits.Length == 2) {
                            //Process the type first
                            ProcessScriptType(Info, bits[0]);

                            //Process the other stuff
                            ProcessArrayParametersOfWithEach(bits[1], Info);
                        } else {
                            Info.Errors.Add("witheach should be:- witheach <type> in <array/set>"+ ErrorEnding());
                        }

                        //Indent stuff
                        IndentBelow(Info, index);

                        break;
                    default:
                        if(FurtherParsing) {
                            if(vc.WillIndent) {
                                i2 = IndentBelow(Info, index);
                                if (Info.Commands.Count > i2 && vc.EndIndent != null) {
                                    Info.Commands.Insert(i2, new ScriptCommand(vc.EndIndent, Indent, LineNumber));
                                }
                            }
                        } break;
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
                Info.Errors.Add(typeName + " is not a valid scripting type!"+ ErrorEnding());
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

                String trueCommand = pb; string oriCommand = pb;
                String additionalInfo = "";

                if (trueCommand.IndexOf('(') > -1) {
                    trueCommand = pb.Substring(0, pb.IndexOf('('));
                    additionalInfo = pb.Substring(pb.IndexOf('(') + 1, pb.Length - (pb.LastIndexOf('(') + 2));
                }

                if (Commands.IfFunctions.ContainsKey(trueCommand.ToLower())) {
                    ValidCommand vc = Commands.IfFunctions[trueCommand.ToLower()];
                    AdditionalBytecode.Add(vc.CommandID);
                    ProcessParams(Info, vc, additionalInfo);
                } else {
                    switch (trueCommand) {
                        case "and": AdditionalBytecode.Add(0x7000); break;
                        case "or": AdditionalBytecode.Add(0x7001); break;
                        case "not": AdditionalBytecode.Add(0x7002); break;
                        default:
                            //Maybe a variable, lets see if we can find it
                            Match match = Regex.Match(oriCommand, "(" + VARIABLE_REGEX + ")\\s?(<=|>=|!=|<>|><|>|<|=)\\s?(" + VARIABLE_REGEX + "|-?[0-9]+)");

                            if (match.Success) {
                                if (VariableExists(match.Groups[1].Value, Info)) {
                                    AdditionalBytecode.Add(0x7009); //This is a variable lookup thing

                                    //Add the variable information
                                    WriteVariableIfExists(match.Groups[1].Value, Info, false);

                                    //Add the sign
                                    switch (match.Groups[2].Value) {
                                        case "=": AdditionalBytecode.Add(0xBE00); break; //Equal To
                                        case "<": AdditionalBytecode.Add(0xBE01); break; //Less Than
                                        case ">": AdditionalBytecode.Add(0xBE02); break; //Greater Than
                                        case "<=": AdditionalBytecode.Add(0xBE03); break; //Less than or equal to
                                        case ">=": AdditionalBytecode.Add(0xBE04); break; //Greater than or equal to
                                        default: AdditionalBytecode.Add(0xBE05); break; //Not equal to
                                    }

                                    //Add the other value to compare against
                                    if (!WriteVariableIfExists(match.Groups[3].Value, Info)) {
                                        Info.Errors.Add("Cannot find a variable called '" + match.Groups[3].Value + "'" + ErrorEnding());
                                    }
                                } else {
                                    Info.Errors.Add(match.Groups[1].Value + " is not a variable." + ErrorEnding());
                                }
                            } else {
                                Info.Errors.Add("Cannot understand how to IF this bit " + trueCommand + ErrorEnding());
                            } break;
                    }
                }
            }

            //End the param block :)
            AdditionalBytecode.Add(0xF0FE); //End the parameter block
        }

        /// <summary>
        /// Check to make sure a variable exists
        /// </summary>
        /// <param name="p">The name of the variable</param>
        /// <param name="Info">The current info object</param>
        /// <returns>True if the variable exists, false otherwise</returns>
        private bool VariableExists(string p, ScriptInfo Info) {
            return (Info.IntegerVariables.ContainsKey(p) || Variables.GlobalVariables.ContainsKey(p));
        }

        /// <summary>
        /// Parses the array part of a FOREACH command and optionally injects it into a binaryio
        /// </summary>
        /// <param name="p">The substring after 'in' in foreach [type] in [this function]"/></param>
        /// <param name="Info">The ScriptInfo object for the entire script to pass errors and the like back into</param>
        private void ProcessArrayParametersOfWithEach(string p, ScriptInfo Info) {
            string l = p.ToLower();

            string regex = "([A-Za-z]+)\\(([A-Za-z0-9,\\.\\s_]*)\\)";
            Match m = Regex.Match(p, regex);

            if (!m.Success) {
                Info.Errors.Add("Poorly structured WITHEACH: " + p+ ErrorEnding());
            } else {
                string arrayValue = m.Groups[1].Value.ToLower();
                string arrayParam = m.Groups[2].Value;

                if (Commands.ZoneFunctions.ContainsKey(arrayValue)) {
                    ValidCommand vc = Commands.ZoneFunctions[arrayValue];
                    AdditionalBytecode.Add(vc.CommandID);
                    ProcessParams(Info, vc, arrayParam);
                } else {
                    Info.Errors.Add("Unknown Array Type: " + arrayValue + ErrorEnding());
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
                Info.Errors.Add("Expecting " + expectedFloats + " values but got " + values.Length + ErrorEnding());
                return;
            }

            foreach (string s in values) {
                if (!short.TryParse(s, out value)) {
                    Info.Errors.Add("Cannot turn " + s + " into a number."+ ErrorEnding());
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
                Info.Commands[i2].ExpectedIndent++;
                i2++;
            }
            return i2;
        }
    }
}