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

        public static void WriteDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddInt(Elements.Count);

            foreach (KeyValuePair<short, Element> kvp in Elements) {
                kvp.Value.PackIntoBinaryIO(f);
            }

            f.Encode(RESOLVED_DATABASE_FILENAME);
        }


        public static String[] ElementNames() {
            List<String> retVal = new List<string>();
            
            foreach (KeyValuePair<short, Element> kvp in Elements) {
                retVal.Add(kvp.Value.ElementName);
            }

            return retVal.ToArray();
        }

        public static void AddNew(string ElementName) {
            Element e = new Element();
            e.ElementID = NextElementID;
            e.ElementName = ElementName;
            NextElementID++;

            Elements.Add(e.ElementID, e);
        }

        public static void Remove(string p) {
            short internalID = -1;

            foreach(KeyValuePair<short, Element> kvp in Elements) {
                if (kvp.Value.ElementName == p) {
                    internalID = kvp.Key;
                    break;
                }
            }

            if (internalID >= 0) {
                foreach (KeyValuePair<short, Element> kvp in Elements) {
                    kvp.Value.RemoveMultiplier(internalID);
                }

                Elements.Remove(internalID);
            }
        }

        public static short GetElementIDFromName(string p) {
            foreach (KeyValuePair<short, Element> kvp in Elements) {
                if (kvp.Value.ElementName == p) {
                    return kvp.Key;
                }
            }

            return -1;
        }

        public static int ElementIDToIndex(short p) {
            int i = 0;

            foreach (KeyValuePair<short, Element> kvp in Elements) {
                if (kvp.Key == p) {
                    return i;
                }

                i++;
            }

            return 0;
        }
    }
}
