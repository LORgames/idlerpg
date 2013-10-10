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
        public bool Enabled = false;

        public static UIPanel ReadFromBinaryIO(BinaryIO f) {
            UIPanel ui = new UIPanel();

            ui.Name = f.GetString();
            ui.Enabled = f.GetByte() == 1;

            short totalElements = f.GetShort();
            while (--totalElements > -1) {
                ui.Elements.Add(UIElement.ReadFromBinaryIO(f));
            }

            return ui;
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddString(Name);
            f.AddByte((byte)(Enabled ? 1 : 0));

            f.AddShort((short)Elements.Count);
            foreach (UIElement element in Elements) {
                element.WriteToBinaryIO(f);
            }
        }

        public void Draw(Graphics gfx, Rectangle canvasArea, float displayValue, bool drawRect) {
            foreach (UIElement element in Elements) {
                element.Draw(gfx, canvasArea, displayValue, drawRect);
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
