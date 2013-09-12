using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ToolCache.General;

namespace ToolCache.UI {
    public class UIManager {
        private const string name = General.Settings.Database + "UserInterface.bin";

        public static List<UIPanel> Panels = new List<UIPanel>();

        public static void Initialize() {
            Panels.Clear();
            ReadDatabase();
        }

        internal static void ReadDatabase() {
            if (File.Exists(name)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(name));
                short totalPanels = f.GetShort();

                while (--totalPanels > -1) {
                    AddPanel(UIPanel.ReadFromBinaryIO(f));
                }
            }
        }

        public static void AddPanel(UIPanel uiPanel) {
            Panels.Add(uiPanel);
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