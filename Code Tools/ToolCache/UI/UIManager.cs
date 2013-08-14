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

        public static void WriteDatabase() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)Panels.Count);

            foreach (UIPanel panel in Panels) {
                panel.WriteToBinaryIO(f);
            }

            f.Encode(name);
        }
    }
}