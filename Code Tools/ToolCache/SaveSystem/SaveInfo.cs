using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ToolCache.General;

namespace ToolCache.SaveSystem {
    public class SaveInfo {
        //GENERAL
        public string filename = "";
        public string playername = "$_CHOOSE";
        public string playerclass = "$_CHOOSE";
        public uint experienceAmount = 0;

        //EQUIPMENT
        public string shadow = "$_CHOOSE";
        public string legs = "$_CHOOSE";
        public string body = "$_CHOOSE";
        public string face = "$_CHOOSE";
        public string headgear = "$_CHOOSE";
        public string weapon = "$_CHOOSE";

        //Inventory


        public static SaveInfo LoadASCIISaveFile(string filename) {
            SaveInfo save = new SaveInfo();

            string[] lines = File.ReadAllLines(filename);
            string set = ""; //TODO: When global variables are in, will need to extend saves

            foreach(string line in lines) {
                string variableName = line.Split('=')[0];
                string variableInfo = line.Substring(line.IndexOf('=')+1);

                switch (variableName) {
                    case "Name": save.playername = variableInfo; break;
                    case "Class": save.playerclass = variableInfo; break;
                    case "Experience": save.experienceAmount = uint.Parse(variableInfo); break;
                    case "Shadow": save.shadow = variableInfo; break;
                    case "Legs": save.legs = variableInfo; break;
                    case "Body": save.body = variableInfo; break;
                    case "Face": save.face = variableInfo; break;
                    case "Headgear": save.headgear = variableInfo; break;
                    case "Weapon": save.weapon = variableInfo; break;
                    default:
                        MessageBox.Show("Unknown variables "+variableName+" in save file: " + filename);
                        break;
                }
            }

            return save;
        }

        internal void Save() {
            if (filename == "") {
                int saveID = 0;

                while (File.Exists(SaveManager.SaveFolder + "/" + Environment.UserName + "_" + saveID + ".sva")) {
                    saveID++;
                }

                filename = SaveManager.SaveFolder + "/" + Environment.UserName + "_" + saveID + ".sva"'
            }

            BinaryIO f = new BinaryIO();



            f.Encode(filename);
        }
    }
}
