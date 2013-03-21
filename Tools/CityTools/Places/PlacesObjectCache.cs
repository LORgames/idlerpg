using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CityTools.Core;
using System.Windows.Forms;
using CityTools.Physics;
using System.Drawing;

namespace CityTools.Places {
    public class PlacesObjectCache {
        public const string PLACES_TYPEFILE = Program.CACHE + "places_types.bin";
        public const string PLACES_FOLDER = ".\\Places";

        private static int _highestTypeIndex = 0;

        public static Dictionary<int, int> ObjectUsageCountsAtLoad = new Dictionary<int, int>();

        public static Dictionary<int, PlacesType> s_objectTypes = new Dictionary<int, PlacesType>();
        public static Dictionary<string, int> s_StringToInt = new Dictionary<string, int>();

        public static void InitializeCache() {
            if (!Directory.Exists(PLACES_FOLDER)) {
                Directory.CreateDirectory(PLACES_FOLDER);
            }

            // Load object types from file
            if (File.Exists(PLACES_TYPEFILE)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(PLACES_TYPEFILE));

                int totalShapes = f.GetInt();
                _highestTypeIndex = f.GetInt();

                //This is where we load the BASIC information
                for (int i = 0; i < totalShapes; i++) {
                    int type_id = f.GetInt();
                    string source = f.GetString();

                    ObjectUsageCountsAtLoad.Add(type_id, 0);

                    s_objectTypes.Add(type_id, new PlacesType(type_id, source));
                    s_StringToInt.Add(source, type_id);
                }
            }

            //Scan for new objects
            foreach (string filename in Directory.GetFiles(PLACES_FOLDER, "*.png", SearchOption.AllDirectories)) {
                if (!ImageCache.HasCached(filename)) {
                    _highestTypeIndex++;
                    s_objectTypes.Add(_highestTypeIndex, new PlacesType(_highestTypeIndex, filename));
                    s_StringToInt.Add(filename, _highestTypeIndex);

                    ObjectUsageCountsAtLoad.Add(_highestTypeIndex, 0);
                }
            }
        }

        public static void SaveTypes() {
            //Count physics objects first...
            BinaryIO f = new BinaryIO();
            f.AddInt(s_objectTypes.Count);
            f.AddInt(_highestTypeIndex);

            foreach (KeyValuePair<int, PlacesType> kvp in s_objectTypes) {
                f.AddInt(kvp.Key);
                f.AddString(kvp.Value.ImageName);
            }

            f.Encode(PLACES_TYPEFILE);
        }
    }
}
