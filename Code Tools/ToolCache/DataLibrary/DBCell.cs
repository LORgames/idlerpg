using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Scripting.Types;

namespace ToolCache.DataLibrary {
    public class DBCell {
        private Param myType = Param.Void;

        private short id = 0;
        private string label = "";

        public DBCell(Param myType) {
            this.myType = myType;
        }

        public void WriteToBinaryIO(BinaryIO f) {
            if (myType == Param.Integer) {
                f.AddShort(id);
            } else {
                f.AddString(label);
            }
        }

        internal void ReadFromBinaryIO(BinaryIO f) {
            if (myType == Param.Integer) {
                id = f.GetShort();
                label = id.ToString();
            } else {
                label = f.GetString();
            }
        }

        public override string ToString() {
            return label;
        }
    }
}
