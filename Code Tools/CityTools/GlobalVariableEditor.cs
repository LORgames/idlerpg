using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Scripting;
using ToolCache.Scripting.Types;

namespace CityTools {
    public partial class GlobalVariableEditor : Form {
        EventHandler addedHandler;
        EventHandler removedHandler;
        EventHandler addedHandler2;
        EventHandler removedHandler2;

        public GlobalVariableEditor() {
            InitializeComponent();

            addedHandler = new EventHandler(new EventHandler(Variables_ItemAdded));
            removedHandler = new EventHandler(Variables_ItemRemoved);
            addedHandler2 = new EventHandler(new EventHandler(String_ItemAdded));
            removedHandler2 = new EventHandler(String_ItemRemoved);

            GlobalVariables.VerifyStats();
            GlobalVariables.Variables.ItemAdded += addedHandler;
            GlobalVariables.Variables.ItemRemoved += removedHandler;
            GlobalVariables.StringTable.ItemAdded += addedHandler2;
            GlobalVariables.StringTable.ItemRemoved += removedHandler2;

            foreach (ScriptVariable sv in GlobalVariables.Variables.Values) {
                listVariables.Items.Add(sv.lvi);
            }

            foreach (String key in GlobalVariables.StringTable.Keys) {
                AddString(key);
            }
        }
        private void GlobalVariableEditor_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (ListViewItem lvi in listVariables.Items) {
                listVariables.Items.Remove(lvi);
            }

            GlobalVariables.Variables.ItemAdded -= addedHandler;
            GlobalVariables.Variables.ItemRemoved -= removedHandler;
            GlobalVariables.StringTable.ItemAdded -= addedHandler2;
            GlobalVariables.StringTable.ItemRemoved -= removedHandler2;
            GlobalVariables.SaveDatabase();
        }

        void Variables_ItemAdded(object sender, EventArgs e) {
            if(GlobalVariables.Variables.ContainsKey(sender.ToString())) {
                listVariables.Items.Add(GlobalVariables.Variables[sender.ToString()].lvi);
            }
        }
        void Variables_ItemRemoved(object sender, EventArgs e) {
            List<ListViewItem> lvis = new List<ListViewItem>();

            foreach (ListViewItem lvi in listVariables.Items) {
                if (lvi.Text == sender.ToString()) {
                    lvis.Add(lvi);
                }
            }

            foreach (ListViewItem lvi in lvis) {
                listVariables.Items.Remove(lvi);
            }

            lvis.Clear();
            lvis = null;
        }

        void String_ItemAdded(object sender, EventArgs e) {
            AddString(sender.ToString());
        }
        void String_ItemRemoved(object sender, EventArgs e) {
            List<ListViewItem> lvis = new List<ListViewItem>();

            foreach (ListViewItem lvi in listString.Items) {
                if (lvi.Text == sender.ToString()) {
                    lvis.Add(lvi);
                }
            }

            foreach (ListViewItem lvi in lvis) {
                listString.Items.Remove(lvi);
            }

            lvis.Clear();
            lvis = null;
        }

        private void AddString(string key) {
            if (GlobalVariables.StringTable.ContainsKey(key)) {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = key;
                lvi.SubItems.Add(GlobalVariables.StringTable[lvi.Text]);
                listString.Items.Add(lvi);
            }
        }

        private void txtNewVariable_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string newVariable = GlobalVariables.FixVariableName(txtNewVariable.Text.Trim());

                ScriptVariable s = new ScriptVariable();
                s.Name = newVariable;
                s.InitialValue = 0;
                s.Index = 0;

                if (s.Name.Length > 0) {
                    GlobalVariables.AddVariableToDatabase(s);
                }

                txtNewVariable.Text = "";
            }
        }
        private void btnVarDeleteSelected_Click(object sender, EventArgs e) {
            List<String> keys = new List<string>();

            foreach (ListViewItem lvi in listVariables.SelectedItems) {
                keys.Add(lvi.Text);
            }

            foreach (String key in keys) {
                GlobalVariables.Variables.Remove(key);
            }

            keys.Clear();
            keys = null;
        }

        private void txtNewStringName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string newVariable = GlobalVariables.FixVariableName(txtNewStringName.Text.Trim());

                if (newVariable.Length > 0) {
                    GlobalVariables.StringTable.Add(newVariable, "");
                }

                txtNewStringName.Text = "";
            }
        }
        private void btnDeleteStrings_Click(object sender, EventArgs e) {
            List<String> keys = new List<string>();

            foreach (ListViewItem lvi in listString.SelectedItems) {
                keys.Add(lvi.Text);
            }

            foreach (String key in keys) {
                GlobalVariables.StringTable.Remove(key);
            }

            keys.Clear();
            keys = null;
        }

        void listString_SubItemEndEditing(object sender, Components.SubItemEndEditingEventArgs e) {
            string key = e.Item.Text;

            if (GlobalVariables.StringTable.ContainsKey(key)) {
                e.DisplayText = txtHiddenStringEditing.Text;
                GlobalVariables.StringTable[key] = txtHiddenStringEditing.Text;
            }
        }

        void listString_SubItemClicked(object sender, Components.SubItemEventArgs e) {
            if (e.SubItem == 1) {
                listString.StartEditing(txtHiddenStringEditing, e.Item, e.SubItem);
            }
        }

        private void listVariables_SubItemClicked(object sender, Components.SubItemEventArgs e) {
            if (e.SubItem == 1) {
                listVariables.StartEditing(numIntegerChanger, e.Item, e.SubItem);
            }
        }

        private void listVariables_SubItemEndEditing(object sender, Components.SubItemEndEditingEventArgs e) {
            ScriptVariable s = (ScriptVariable)e.Item.Tag;

            s.InitialValue = (short)numIntegerChanger.Value;
            e.DisplayText = numIntegerChanger.Value.ToString();
        }
    }
}
