using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;

namespace ToolCache.NPC {
    public class PortraitManager {
        public static DictionaryEx<string, Portrait> Portraits = new DictionaryEx<string, Portrait>();

        internal static void Initialize() {
            Portraits.Clear();
            LoadFromBinaryIO();
        }

        private static void LoadFromBinaryIO() {
            if(File.Exists(Settings.Database + "Portraits.bin")) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(Settings.Database + "Portraits.bin"));

                short totalPortraits = f.GetShort();

                while (--totalPortraits > -1) {
                    Portrait p = Portrait.LoadFromBinaryIO(f);
                    Portraits.Add(p.Name, p);
                }
            }
        }

        public static void SaveToBinaryIO() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)Portraits.Count);

            foreach (Portrait p in Portraits.Values) {
                p.SaveToBinaryIO(f);
            }

            f.Encode(Settings.Database + "Portraits.bin");
        }
    }
}
