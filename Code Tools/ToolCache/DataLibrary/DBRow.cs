using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using ToolCache.Scripting.Types;
using System.Windows.Forms;
using ToolCache.Storage;

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

        internal void ReadFromBinaryIO(IStorage f) {
            for (int i = 0; i < Cells.Count; i++) {
                Cells[i].ReadFromBinaryIO(f);
            }
        }

        internal void WriteToBinaryIO(IStorage f) {
            for (int i = 0; i < Cells.Count; i++) {
                Cells[i].WriteToBinaryIO(f);
            }
        }

        public ListViewItem GetListViewItem() {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = this;

            if (Cells.Count > 0) {
                lvi.Name = Cells[0].ToString();
                lvi.Text = lvi.Name;

                for (int i = 1; i < Cells.Count; i++) {
                    lvi.SubItems.Add(Cells[i].ToString());
                }
            }

            return lvi;
        }
    }
}
