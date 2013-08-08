using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;

namespace ToolCache.NPC {
    public class Portrait {
        public string Name = "";
        public string Filename = "";

        public static Portrait LoadFromBinaryIO(BinaryIO f) {
            Portrait p = new Portrait();

            p.Name = f.GetString();
            p.Filename = f.GetString();

            return p;
        }

        internal void SaveToBinaryIO(BinaryIO f) {
            f.AddString(Name);
            f.AddString(Filename);
        }
    }
}
