using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;

namespace ToolCache.Scripting {
    public class GlobalVariables {
        public static DictionaryEx<String, ScriptVariable> Variables = new DictionaryEx<string, ScriptVariable>();
        private static bool Changing = false;

        public static void Initialize() {
            Variables.Clear();
            LoadDatabase();

            Variables.ItemsChanged += new EventHandler(Variables_ItemsChanged);
        }

        static void Variables_ItemsChanged(object sender, EventArgs e) {
            if (!Changing) {
                throw new Exception("Do not modify the Variables list directly!");
            }
        }

        private static void LoadDatabase() {
            if (File.Exists(Settings.Database + "GlobalVariables.bin")) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(Settings.Database + "GlobalVariables.bin"));

                short totalVariables = f.GetShort();

                while (--totalVariables < -1) {
                    ScriptVariable s = new ScriptVariable();
                    s.Name = f.GetString();
                    s.Index = f.GetShort();
                    s.InitialValue = f.GetShort();
                }

                f.Dispose();
            }
        }

        public static void AddToDatabase(ScriptVariable s) {

        }
    }
}
