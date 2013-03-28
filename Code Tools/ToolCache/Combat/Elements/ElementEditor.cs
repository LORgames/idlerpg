using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolCache.Combat.Elements {
    public partial class ElementEditor : Form {
        private Boolean Updating = false;

        public ElementEditor() {
            InitializeComponent();

            DisplayData();
        }

        private void dgvElements_UserAddedRow(object sender, DataGridViewRowEventArgs e) {
            ElementManager.AddNew("");
            //e.Row.HeaderCell
        }

        private void DisplayData() {
            Updating = true;

            DataTable dt = new DataTable();

            dt.Columns.Add("V Atk, Def >");

            foreach (KeyValuePair<short, Element> kvp in ElementManager.Elements) {
                dt.Columns.Add(kvp.Key + "| " + kvp.Value.ElementName);
            }

            foreach (KeyValuePair<short, Element> kvp in ElementManager.Elements) {
                object[] vals = new object[dt.Columns.Count];
                vals[0] = kvp.Value.ElementName;

                for (int i = 1; i < dt.Columns.Count; i++) {
                    kvp.Value.GetMultiplier(short.Parse(dt.Columns[i].ColumnName.Split('|')[0]));
                }

                dt.Rows.Add(vals);
            }

            dgvElements.DataSource = dt;

            Updating = false;
        }

        private void dgvElements_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (!Updating) {
                if (e.ColumnIndex == 0) {
                    if ((dgvElements.DataSource as DataTable).Rows[e.RowIndex].ItemArray[0].ToString().IndexOf("|") == -1) {
                        //No idea what to do, they either deleted the element or something worse?
                    }
                }
            }
        }
    }
}
