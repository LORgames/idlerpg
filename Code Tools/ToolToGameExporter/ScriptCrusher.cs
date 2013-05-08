using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Equipment;

namespace ToolToGameExporter {
    public class ScriptCrusher {

        internal static void ProcessScript(string scriptname, string s, BinaryIO f, List<string> snippets = null) {
            if (s.Length == 0 && snippets == null) {
                f.AddUnsignedShort(0xF0FF);
                return;
            }

            //Storage for snippets
            bool isSnippet = true;
            if (snippets == null) {
                snippets = new List<string>();
                isSnippet = false;
            }

            ///////////////////////////////////////////////////////////////////////////////////
            /////// PRECOMPILER
            ///////////////////////////////////////////////////////////////////////////////////

            //Check for balanced brackets in s
            if (s.Count(c => c == '(') != s.Count(c => c == ')')) {
                Error("Unbalanced brackets. Cannot generate snippets.", scriptname, f);
                return;
            }

            List<int> nextIndex = new List<int>();

            while (s.Contains('(')) {
                int nextOpen = s.IndexOf('(');
                int nextClose = s.IndexOf(')');
                
                int open1UP = s.IndexOf('(', nextOpen+1);

                if (open1UP < nextClose && open1UP != -1) {
                    nextIndex.Add(nextOpen);
                } else {
                    //Get the little snippet, needs a +1 to get the close bracket
                    string snippet = s.Substring(nextOpen, nextClose-nextOpen+1);

                    //Remove the snippet from the script and replace it with the snippet block
                    //  => gets recompiled back in later by the compiler

                    int snippetID = snippets.Count;
                    s = s.Replace(snippet, "snippet " + snippetID + ";");

                    //Just trim the snippet to remove the brackets
                    snippet = snippet.Substring(1, snippet.Length - 2);

                    snippets.Add(snippet);
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////
            /////// COMPILER
            ///////////////////////////////////////////////////////////////////////////////////

            string[] commands = s.Split(';'); //Outdated, will need a better way to do this...

            for(int i = 0; i < commands.Length; i++) {
                //Get the next command?
                string command = commands[i];

                //Clean up the commands
                command = command.Trim();
                if (command.Length < 2) continue;

                //Figure out what I was trying to do...
                string action = command.Substring(0, command.IndexOf(' '));
                string paras = command.Substring(command.IndexOf(' ')+1);

                switch(action) {
                    case "playsound":
                        if (SoundCrusher.EffectConversions.ContainsKey(paras)) {
                            f.AddUnsignedShort(0x0001);
                            f.AddShort(SoundCrusher.EffectConversions[paras]);
                        } else {
                            Error("Cannot find sound effect: '" + paras + "'", scriptname, f);
                        } break;
                    case "equip":
                        if (EquipmentManager.Equipment.ContainsKey(paras)) {
                            f.AddUnsignedShort(0x3001);
                            f.AddShort((short)Array.IndexOf(EquipmentCrusher.equipmenttypes, EquipmentManager.Equipment[paras].Type));
                            f.AddShort(EquipmentCrusher.MappedEquipmentIDs[paras]);
                        } else {
                            Error("Cannot find equipment item: '" + paras + "'", scriptname, f);
                        } break;
                    case "snippet":
                        int snippetID;
                        if (int.TryParse(paras, out snippetID)) {
                            if (snippets.Count > snippetID) {
                                ProcessScript(scriptname + ":Snippet:" + snippetID, snippets[snippetID], f, snippets);
                            } else {
                                Error("There are not that many snippets available.", scriptname, f);
                            }
                        } else {
                            Error("Cannot parse snippet UUID: " + paras, scriptname, f);
                        }
                        break;
                    default:
                        Error("Unknown command: " + command, scriptname, f);
                        break;
                }
            }

            //End the script loader
            if(!isSnippet) f.AddUnsignedShort(0xF0FF);
        }

        private static void Error(string message, string scriptname, BinaryIO f) {
            Processor.Errors.Add("Script:" + scriptname + " " + message);
            f.AddUnsignedShort(0x0000);
        }

    }
}
