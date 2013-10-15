using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;

namespace ToolCache.UI {
    public class UIManager {
        private const string name = General.Settings.Database + "UserInterface.bin";

        public static List<UIPanel> Panels = new List<UIPanel>();
        public static List<UILibrary> Libraries = new List<UILibrary>();

        public static BindingList<FontFamily> Fonts = new BindingList<FontFamily>();

        public static void Initialize() {
            InstallFonts();
            Panels.Clear();
            ReadDatabase();
        }

        private static void InstallFonts() {
            Fonts.Clear();

            AddFont("Arial");
            AddFont("Verdana");
            AddFont("Calibri");
            AddFont("Bangers");
            AddFont("Comic Sans MS");//AddFont("Jing Jing"); //SHOULD be JingJing
            AddFont("Visitor TT1 BRK");
        }

        private static void AddFont(string p) {
            FontFamily f = new FontFamily(p);

            if (f.Name == p) {
                Fonts.Add(f);
            } else {
                Fonts.Add(new FontFamily(GenericFontFamilies.Serif));
            }
        }

        internal static void ReadDatabase() {
            if (File.Exists(name)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(name));
                short totalPanels = f.GetShort();

                while (--totalPanels > -1) {
                    AddPanel(UIPanel.ReadFromBinaryIO(f));
                }

                if (!f.IsEndOfFile()) {
                    short totalLibraries = f.GetShort();

                    while (--totalLibraries > -1) {
                        AddLibrary(UILibrary.ReadFromBinaryIO(f));
                    }
                }
            }
        }

        public static void AddPanel(UIPanel uiPanel) {
            Panels.Add(uiPanel);
        }

        public static void AddLibrary(UILibrary uiLib) {
            Libraries.Add(uiLib);
        }

        public static void DeletePanel(UIPanel p) {
            if (Panels.Contains(p)) {
                Panels.Remove(p);
            }
        }

        public static void WriteDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)Panels.Count);

            foreach (UIPanel panel in Panels) {
                panel.WriteToBinaryIO(f);
            }

            f.AddShort((short)Libraries.Count);

            foreach (UILibrary lib in Libraries) {
                lib.WriteToBinaryIO(f);
            }

            f.Encode(name);
        }

        internal static int GetPanelID(string p) {
            int i = Panels.Count;
            string pl = p.ToLower();

            while (--i > -1) {
                if (Panels[i].Name.ToLower() == pl) {
                    return i;
                }
            }

            return -1;
        }

        internal static int GetElementID(string p, UIPanel uIPanel) {
            int i = uIPanel.Elements.Count;
            string pl = p.ToLower();

            while (--i > -1) {
                if (uIPanel.Elements[i].Name.ToLower() == pl) {
                    return i;
                }
            }

            return -1;
        }

        internal static int GetPanelID(string p, UIElement uIElement) {
            int i = uIElement.Layers.Count;
            string pl = p.ToLower();

            while (--i > -1) {
                if (uIElement.Layers[i].Name.ToLower() == pl) {
                    return i;
                }
            }

            return -1;
        }
    }
}