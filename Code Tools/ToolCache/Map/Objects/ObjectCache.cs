using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;
using ToolCache.Animation;
using System.Drawing;

namespace ToolCache.Map.Objects {
    public class ObjectCache {
        public const string RESOLVED_DATABASE_FILENAME = Settings.CACHE + "db_objects.bin";

        private static int _highestTypeIndex = 0;
        public static Dictionary<short, ObjectTemplate> ObjectTypes = new Dictionary<short, ObjectTemplate>();

        public static void InitializeCache() {
            // Load object types from file
            if (File.Exists(RESOLVED_DATABASE_FILENAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(RESOLVED_DATABASE_FILENAME));

                int totalShapes = f.GetInt();
                _highestTypeIndex = f.GetInt();

                //This is where we load the BASIC information
                for (int i = 0; i < totalShapes; i++) {
                    short type_id = f.GetShort();
                    AnimatedObject animation = AnimatedObject.UnpackFromBinaryIO(f);

                    int BaseLeft = f.GetInt();
                    int BaseTop = f.GetInt();
                    int BaseWidth = f.GetInt();
                    int BaseHeight = f.GetInt();

                    Rectangle _base = new Rectangle(BaseLeft, BaseTop, BaseWidth, BaseHeight);

                    ObjectTypes.Add(type_id, new ObjectTemplate(type_id, animation, _base));
                }
            }
        }

        public static void SaveTypes() {
            BinaryIO f = new BinaryIO();
            f.AddInt(ObjectTypes.Count);
            f.AddInt(_highestTypeIndex);

            foreach (KeyValuePair<short, ObjectTemplate> kvp in ObjectTypes) {
                f.AddShort(kvp.Key);
                kvp.Value.Animation.PackIntoBinaryIO(f);

                f.AddInt(kvp.Value.Base.Left);
                f.AddInt(kvp.Value.Base.Top);
                f.AddInt(kvp.Value.Base.Width);
                f.AddInt(kvp.Value.Base.Height);
            }

            f.Encode(RESOLVED_DATABASE_FILENAME);
        }
    }
}
