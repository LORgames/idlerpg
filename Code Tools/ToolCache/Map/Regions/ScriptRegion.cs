using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using ToolCache.General;

namespace ToolCache.Map.Regions {
    public class ScriptRegion : RegionBase {
        public string Script = "";

        public static ScriptRegion LoadFromBinaryIO(BinaryIO f) {
            ScriptRegion s = new ScriptRegion();

            UnpackNameAndAreas(f, s);
            s.Script = f.GetString();

            return s;
        }

        public void SaveToBinaryIO(BinaryIO f) {
            WriteNameAndAreas(f);
            f.AddString(Script);
        }
    }
}
