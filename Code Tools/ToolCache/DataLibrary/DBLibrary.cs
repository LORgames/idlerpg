using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Scripting.Types;
using ToolCache.General;

namespace ToolCache.DataLibrary {
    public class DBLibrary {
        internal List<String> Column_Names = new List<string>();
        internal List<Param> Column_Types = new List<Param>();
        
        public List<DBRow> Rows = new List<DBRow>();

        public string Name;

        public DBLibrary(string name) {
            Name = name;
        }

        internal void ReadFromBinaryIO(BinaryIO f) {
            short totalColumns = f.GetShort();

            for (int i = 0; i < totalColumns; i++) {
                string cName = f.GetString();
                byte paramType = f.GetByte(); //128 is highest param type and thats 'optional' in any case
                AddColumn(cName, (Param)paramType);
            }

            short totalRows = f.GetShort();

            for (int i = 0; i < totalRows; i++) {
                DBRow r = InsertEmptyRow();
                r.ReadFromBinaryIO(f);
            }
        }

        internal void WriteToBinaryIO(BinaryIO f) {
            f.AddShort((short)Column_Names.Count);

            for (int i = 0; i < Column_Names.Count; i++) {
                f.AddString(Column_Names[i]);
                f.AddByte((byte)Column_Types[i]);
            }

            f.AddShort((short)Rows.Count);

            for (int i = 0; i < Rows.Count; i++) {
                Rows[i].WriteToBinaryIO(f);
            }
        }

        public DBRow InsertEmptyRow() {
            DBRow r = new DBRow(this);
            Rows.Add(r);
            return r;
        }

        public void AddColumn(string name, Param type) {
            Column_Names.Add(name);
            Column_Types.Add(type);

            foreach (DBRow r in Rows) {
                r.Cells.Add(new DBCell(type));
            }
        }

        public void RemoveColumn(string name) {
            if (Column_Names.IndexOf(name) > -1) {
                RemoveColumn(Column_Names.IndexOf(name));
            }
        }

        public void RemoveColumn(int index) {
            if (Column_Names.Count > index) {
                Column_Names.RemoveAt(index);
                Column_Types.RemoveAt(index);

                foreach (DBRow r in Rows) {
                    r.Cells.RemoveAt(index);
                }
            }
        }

        public override string ToString() {
            return Name;
        }

        public string[] GetColumnNames() {
            return Column_Names.ToArray();
        }

        public Param GetColumnType(int p) {
            return Column_Types[p];
        }

        internal int GetColumnID(string column) {
            string _name = column.ToLower();

            for(int i = 0; i < Column_Names.Count; i++) {
                if (Column_Names[i].ToLower() == _name) {
                    return i;
                }
            }

            return -1;
        }
    }
}
