using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Elements;

namespace CityTools {
    public partial class ElementEditor : Form {
        private Boolean Updating = false;
        private DataTable dt;

        public ElementEditor() {
            InitializeComponent();

            DisplayData();
        }

        private void DisplayData() {
            Updating = true;

            dt = new DataTable();

            dt.Columns.Add("Atk <, Def >");

            foreach (KeyValuePair<short, Element> kvp in ElementManager.Elements) {
                dt.Columns.Add(kvp.Key + "| " + kvp.Value.ElementName);
            }

            foreach (KeyValuePair<short, Element> kvp in ElementManager.Elements) {
                object[] vals = new object[dt.Columns.Count];
                vals[0] = kvp.Value.ElementName;

                for (int i = 1; i < dt.Columns.Count; i++) {
                    vals[i] = kvp.Value.GetMultiplier(short.Parse(dt.Columns[i].ColumnName.Split('|')[0]));
                }

                dt.Rows.Add(vals);
            }

            dgvElements.DataSource = dt;

            for (int i = 0; i < dgvElements.ColumnCount; i++) {
                dgvElements.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            Updating = false;
        }

        private void dgvElements_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            if (!Updating) {
                if (e.ColumnIndex == 0) {
                    ElementManager.Elements[short.Parse(dt.Columns[e.RowIndex + 1].ColumnName.Split('|')[0])].ElementName = dt.Rows[e.RowIndex].ItemArray[0].ToString();
                    DisplayData();
                } else {
                    float newValue = 0;

                    short element0 = short.Parse(dt.Columns[e.RowIndex +1].ColumnName.Split('|')[0]);
                    short element1 = short.Parse(dt.Columns[e.ColumnIndex].ColumnName.Split('|')[0]);

                    if (float.TryParse(dt.Rows[e.RowIndex].ItemArray[e.ColumnIndex].ToString(), out newValue)) {
                        ElementManager.Elements[element0].SetMultiplier(element1, newValue);
                    } else {
                        MessageBox.Show("Multiplier must be a decimal value!");
                        dt.Rows[e.RowIndex].ItemArray[e.ColumnIndex] = ElementManager.Elements[element0].GetMultiplier(element1);
                    }
                }
            }
        }

        private void btnElementAdd_Click(object sender, EventArgs e) {
            if (txtElementAddName.Text.Length > 2) {
                if (Array.IndexOf(ElementManager.ElementNames(), txtElementAddName.Text) < 0) {
                    ElementManager.AddNew(txtElementAddName.Text);
                    DisplayData();
                } else {
                    MessageBox.Show("Element name already exists!");
                }
            } else {
                MessageBox.Show("Element name must be at least 2 characters!");
            }
        }

        private void btnElementDelete_Click(object sender, EventArgs e) {
            if (cbElementDeleteName.Text.Length > 2) {
                if (Array.IndexOf(ElementManager.ElementNames(), cbElementDeleteName.Text) >= 0) {
                    ElementManager.Remove(cbElementDeleteName.Text);
                    DisplayData();
                } else {
                    MessageBox.Show("Element doesn't exist, cannot delete what doesn't exist!");
                }
            } else {
                MessageBox.Show("Element name must be at least 2 characters! How to delete?");
            }
        }

        private void ElementEditor_FormClosing(object sender, FormClosingEventArgs e) {
            ElementManager.WriteDatabase();
        }

        private void btnRedraw_Click(object sender, EventArgs e) {
            DisplayData();
        }
    }
}
