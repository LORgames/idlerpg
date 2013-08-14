using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.Drawing;

namespace ToolCache.UI {
    public class UIPanel {
        public List<UIElement> Elements = new List<UIElement>();
        public string Name = "";

        public static UIPanel ReadFromBinaryIO(BinaryIO f) {
            UIPanel ui = new UIPanel();

            ui.Name = f.GetString();

            short totalElements = f.GetShort();
            while (--totalElements > -1) {
                ui.Elements.Add(UIElement.ReadFromBinaryIO(f));
            }

            return ui;
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddString(Name);

            f.AddShort((short)Elements.Count);
            foreach (UIElement element in Elements) {
                element.WriteToBinaryIO(f);
            }
        }

        public void Draw(Graphics gfx, Rectangle canvasArea, float displayValue) {
            foreach (UIElement element in Elements) {
                element.Draw(gfx, canvasArea, displayValue);
            }
        }

        public override string ToString() {
            if (Name != "") {
                return Name;
            }

            return "[UNNAMED]";
        }
    }
}
