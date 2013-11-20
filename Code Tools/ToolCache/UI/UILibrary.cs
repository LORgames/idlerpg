using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Storage;

namespace ToolCache.UI {
    public class UILibrary {
        public String Name { get; set; }
        public List<String> Images = new List<string>();

        public UILibrary(string name) {
            Name = name;
        }

        internal static UILibrary ReadFromBinaryIO(IStorage f) {
            UILibrary lib = new UILibrary(f.GetString());

            int i = f.GetShort();
 
            while (--i > -1) {
                lib.Images.Add(f.GetString());
            }

            return lib;
        }

        internal void WriteToBinaryIO(IStorage f) {
            f.AddString(Name);

            int i = 0;
            f.AddShort((short)Images.Count);

            for (i = 0; i < Images.Count; i++) {
                f.AddString(Images[i]);
            }
        }

        public override string ToString() {
            return Name;
        }
    }
}
