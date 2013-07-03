using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;

namespace ToolCache.UI {
    public class UIManager {
        private const string name = General.Settings.Database + "UserInterface.bin";

        public static List<UIElement> Elements = new List<UIElement>();

        public static void Initialize() {
            Elements.Clear();
            ReadDatabase();
        }

        internal static void ReadDatabase() {
            if (File.Exists(name)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(name));
                short totalElements = f.GetShort();

                while (--totalElements > -1) {
                    AddElement(UIElement.ReadFromBinaryIO(f));
                }
            }
        }

        public static void AddElement(UIElement uiElement) {
            Elements.Add(uiElement);
        }

        public static void WriteDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)Elements.Count);

            foreach (UIElement element in Elements) {
                element.WriteToBinaryIO(f);
            }

            f.Encode(name);
        }
    }
}