using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Scripting.Types;

namespace ToolCache.DataLibrary {
    public class DBRow {
        public List<DBCell> Cells = new List<DBCell>();
        private DBLibrary myLib = null;

        internal DBRow(DBLibrary lib) {
            myLib = lib;

            for (int i = 0; i < lib.Column_Types.Count; i++) {
                Cells.Add(new DBCell(lib.Column_Types[i]));
            }
        }

        internal void ReadFromBinaryIO(BinaryIO f) {
            for (int i = 0; i < Cells.Count; i++) {
                Cells[i].ReadFromBinaryIO(f);
            }
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            for (int i = 0; i < Cells.Count; i++) {
                Cells[i].WriteToBinaryIO(f);
            }
        }
    }
}
