using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.Map.Regions {
    public class RegionBase {
        public List<Rectangle> Areas = new List<Rectangle>();
        public string Name = "Unnamed Region";

        protected static void UnpackNameAndAreas(IStorage f, RegionBase s) {
            s.Name = f.GetString();
            
            int totalAreas = f.GetByte(); //How many rectangles

            while (--totalAreas > -1) {
                Rectangle area = new Rectangle();
                area.X = f.GetShort();
                area.Y = f.GetShort();
                area.Width = f.GetShort();
                area.Height = f.GetShort();
                s.Areas.Add(area);
            }
        }

        protected void WriteNameAndAreas(IStorage f) {
            f.AddString(Name);

            CleanUpAreas();
            f.AddByte((byte)Areas.Count); //How many rectangles?

            foreach (Rectangle r in Areas) {
                f.AddShort((short)r.X);
                f.AddShort((short)r.Y);
                f.AddShort((short)r.Width);
                f.AddShort((short)r.Height);
            }
        }

        private void CleanUpAreas() {
            int i = Areas.Count;
            while (--i > -1) {
                if (Areas[i].Width == 0 || Areas[i].Height == 0) {
                    Areas.RemoveAt(i);
                }
            }
        }

        public override string ToString() {
            return Name;
        }

        public void Move(int x, int y) {
            foreach (Rectangle Area in Areas) {
                Area.Offset(x, y);
            }
        }
    }
}
