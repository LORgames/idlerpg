using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Scripting.Types;
using ToolCache.Storage;

namespace ToolCache.DataLibrary {
    public class DBCell {
        private Param myType = Param.Void;

        private short id = 0;
        private float _f = 0;

        private string label = "";

        public DBCell(Param myType) {
            this.myType = myType;
        }

        public void WriteToBinaryIO(IStorage f) {
            if (myType == Param.Integer) {
                f.AddShort(id);
            } else {
                f.AddString(label);
            }
        }

        internal void ReadFromBinaryIO(IStorage f) {
            if (myType == Param.Integer) {
                id = f.GetShort();
                label = id.ToString();
            } else if (myType == Param.Number) {
                _f = f.GetFloat();
                label = _f.ToString();
            } else {
                label = f.GetString();
            }
        }

        public override string ToString() {
            return label;
        }

        public void SetString(string p) {
            if (myType == Param.Integer) {
                if(short.TryParse(p, out id)) {
                    label = id.ToString();
                }
            } else if(myType == Param.Number) {
                if(float.TryParse(p, out _f)) {
                    label = _f.ToString();
                }
            } else {
                label = p;
            }
        }

        public void PackIntoOptimized(IStorage f) {
            if (myType == Param.Integer) {
                f.AddShort(id);
            } else if (myType == Param.String) {
                f.AddString(label);
            } else if (myType == Param.Number) {
                f.AddFloat(_f);
            } else {
                throw new Exception("Cannot encode this param type!");
            }
        }
    }
}
