using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.Map.Background {
    public class SolidBackground : IBackground {
        public Color myColour = Color.Black;

        public SolidBackground(Color colour) {
            myColour = colour;
        }

        public SolidBackground(IStorage f) {
            LoadFromBinary(f);
        }

        public void LoadFromBinary(IStorage f) {
            int colourARGB = f.GetInt();
            myColour = Color.FromArgb(colourARGB);
        }

        public void SaveToBinary(IStorage f) {
            f.AddByte((byte)BackgroundTypes.Solid);
            f.AddInt(myColour.ToArgb());
        }

        public void Draw(Graphics gfx, Rectangle r) {
            gfx.FillRectangle(new SolidBrush(myColour), r);
        }
    }
}
