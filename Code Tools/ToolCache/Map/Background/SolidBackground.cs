using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;

namespace ToolCache.Map.Background {
    public class SolidBackground : IBackground {
        public Color myColour = Color.Black;

        public SolidBackground(Color colour) {
            myColour = colour;
        }

        public SolidBackground(BinaryIO f) {
            LoadFromBinary(f);
        }

        public void LoadFromBinary(BinaryIO f) {
            int colourARGB = f.GetInt();
            myColour = Color.FromArgb(colourARGB);
        }

        public void SaveToBinary(BinaryIO f) {
            f.AddByte((byte)BackgroundTypes.Solid);
            f.AddInt(myColour.ToArgb());
        }

        public void Draw(Graphics gfx, Rectangle r) {
            gfx.FillRectangle(new SolidBrush(myColour), r);
        }
    }
}
