using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.DataLibrary;
using ToolCache.Scripting.Types;

namespace CityTools.Components.DatabaseEditing {
    public partial class DatabaseEditor : UserControl {
        private DBLibrary CurrentDatabase;

        public DatabaseEditor() {
            InitializeComponent();

            txtNewDatabaseName.KeyDown += new KeyEventHandler(txtNewDatabaseName_KeyDown);

            DBLibrary[] libraries = DBLibraryManager.GetLibraries();
            foreach(DBLibrary lib in libraries) {
                listDatabases.Items.Add(lib);
            }

            //string[] names = Enum.GetNames(typeof(Param));
            string[] names = new string[] { "Integer", "String", "Number" };
            foreach (string s in names) {
                cbAddDatabaseColumnType.Items.Add(s);
            }

            BlankForm();
        }

        protected override void Dispose(bool disposing) {
            DBLibraryManager.WriteDatabase();

            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        public void txtNewDatabaseName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string newDatabaseName = txtNewDatabaseName.Text.Trim();
                DBLibrary dbl = DBLibraryManager.AddLibrary(newDatabaseName);
                listDatabases.Items.Add(dbl);
            }
        }

        private void listDatabases_SelectedIndexChanged(object sender, EventArgs e) {
            if (listDatabases.SelectedItem != null) {
                CurrentDatabase = (DBLibrary)listDatabases.SelectedItem;
                FillForm();
            } else {
                BlankForm();
            }
        }

        private void BlankForm() {
            CurrentDatabase = null;
            toolStrip.Enabled = false;
            lvLibrary.Items.Clear();
            lvLibrary.Enabled = false;

            txtAddDatabaseColumnName.Text = "";
        }

        private void FillForm() {
            if(CurrentDatabase != null) {
                toolStrip.Enabled = true;
                lvLibrary.Enabled = true;

                UpdateColumns();
            } else {
                BlankForm();
            }
        }

        private void lvLibrary_SubItemClicked(object sender, SubItemEventArgs e) {
            System.Diagnostics.Debug.WriteLine(e.Item + "|" + e.SubItem);

            if (e.SubItem < e.Item.SubItems.Count - 3) { //Extra buttons for moving up and down as well as delete
                Control c = GetRelevantControl(CurrentDatabase.GetColumnType(e.SubItem), true);

                if (c == null) {
                    MessageBox.Show("Sorry, that column type is not currently editable!");
                } else {
                    lvLibrary.StartEditing(c, e.Item, e.SubItem);
                }
            } else { //Move up or down
                int r = lvLibrary.Items.IndexOf(e.Item);

                if (e.SubItem == e.Item.SubItems.Count - 2) { //Move Down
                    if (r < lvLibrary.Items.Count - 1) {
                        lvLibrary.Items.RemoveAt(r);
                        lvLibrary.Items.Insert(r + 1, e.Item);

                        DBRow row = CurrentDatabase.Rows[r];
                        CurrentDatabase.Rows.RemoveAt(r);
                        CurrentDatabase.Rows.Insert(r + 1, row);
                    }
                } else if (e.SubItem == e.Item.SubItems.Count - 3) { //Move Up
                    if (r > 0) {
                        lvLibrary.Items.RemoveAt(r);
                        lvLibrary.Items.Insert(r - 1, e.Item);

                        DBRow row = CurrentDatabase.Rows[r];
                        CurrentDatabase.Rows.RemoveAt(r);
                        CurrentDatabase.Rows.Insert(r - 1, row);
                    }
                } else { //Delete
                    if (MessageBox.Show("Are you sure you want to remove this item?", "Delete?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        CurrentDatabase.Rows.RemoveAt(r);
                        lvLibrary.Items.RemoveAt(r);
                    }
                }
            }
        }

        private void lvLibrary_SubItemEndEditing(object sender, SubItemEndEditingEventArgs e) {
            DBRow dbr = (DBRow)e.Item.Tag;
            dbr.Cells[e.SubItem].SetString(GetRelevantControl(CurrentDatabase.GetColumnType(e.SubItem)).Text);
            e.DisplayText = dbr.Cells[e.SubItem].ToString();
        }

        private Control GetRelevantControl(Param type, bool fill = false) {
            switch (type) {
                case Param.Integer:
                case Param.Angle:
                case Param.Number:
                    return numHidden;
                case Param.String:
                    return txtHidden;
                case Param.Boolean:
                    if (fill) { cbHidden.Items.Clear(); cbHidden.Items.Add("False"); cbHidden.Items.Add("True"); }
                    return cbHidden;
                default:
                    return null;
            }
        }

        private void btnAddDatabaseColumn_Click(object sender, EventArgs e) {
            if (CurrentDatabase != null) {
                if (txtAddDatabaseColumnName.Text != "" && cbAddDatabaseColumnType.SelectedItem != null) {
                    CurrentDatabase.AddColumn(txtAddDatabaseColumnName.Text, (Param)Enum.Parse(typeof(Param), cbAddDatabaseColumnType.SelectedItem.ToString()));
                    txtAddDatabaseColumnName.Text = "";

                    UpdateColumns();
                }
            }
        }

        private void UpdateColumns() {
            if (CurrentDatabase != null) {
                lvLibrary.Columns.Clear();
                
                string[] Columns = CurrentDatabase.GetColumnNames();

                lvLibrary.Items.Clear();

                for (int i = 0; i < Columns.Length; i++) {
                    lvLibrary.Columns.Add(Columns[i]);
                }

                lvLibrary.Columns.Add("↑", 24, HorizontalAlignment.Center);
                lvLibrary.Columns.Add("↓", 24, HorizontalAlignment.Center);
                lvLibrary.Columns.Add("☓", 24, HorizontalAlignment.Center);

                InsertAllItems();
            }
        }

        private void InsertAllItems() {
            if (CurrentDatabase != null) {
                for (int i = 0; i < CurrentDatabase.Rows.Count; i++) {
                    lvLibrary.Items.Add(GetProcessedRow(CurrentDatabase.Rows[i]));
                }
            }
        }

        private void btnAddRow_Click(object sender, EventArgs e) {
            if (CurrentDatabase != null) {
                DBRow dbr = CurrentDatabase.InsertEmptyRow();
                lvLibrary.Items.Add(GetProcessedRow(dbr));
            }
        }

        private ListViewItem GetProcessedRow(DBRow r) {
            ListViewItem lvi = r.GetListViewItem();

            lvi.SubItems.Add("↑");
            lvi.SubItems.Add("↓");
            lvi.SubItems.Add("☓");

            return lvi;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (listDatabases.SelectedItems.Count > 0) {
                List<DBLibrary> toDelete = new List<DBLibrary>();

                for (int i = 0; i < listDatabases.SelectedItems.Count; i++) {
                    toDelete.Add(listDatabases.SelectedItems[i] as DBLibrary);
                }

                for (int i = 0; i < toDelete.Count; i++) {
                    DBLibraryManager.DeleteLibrary(toDelete[i]);
                    listDatabases.Items.Remove(toDelete[i]);
                }

                toDelete.Clear();
                toDelete = null;
            }
        }
    }
}
