using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;

namespace ToolCache.Combat.Elements {
    public class ElementManager {
        public const string RESOLVED_DATABASE_FILENAME = Settings.CACHE + "db_elements.bin";

        public static Dictionary<short, Element> Elements = new Dictionary<short, Element>();

        public static short NextElementID = 0;

        public static void Initialize() {
            Elements.Clear();

            NextElementID = 0;
            ReadDatabase();
        }

        private static void ReadDatabase() {
            // Load object types from file
            if (File.Exists(RESOLVED_DATABASE_FILENAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(RESOLVED_DATABASE_FILENAME));

                int totalObjects = f.GetInt();

                //This is where we load the BASIC information
                for (int i = 0; i < totalObjects; i++) {
                    Element e = Element.UnpackFromBinaryIO(f);

                    Elements.Add(e.ElementID, e);

                    if (NextElementID <= e.ElementID) {
                        NextElementID = e.ElementID;
                        NextElementID++;
                    }
                }
            }
        }

        internal static void WriteDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddInt(Elements.Count);

            foreach (KeyValuePair<short, Element> kvp in Elements) {
                kvp.Value.PackIntoBinaryIO(f);
            }

            f.Encode(RESOLVED_DATABASE_FILENAME);
        }

    }
}
