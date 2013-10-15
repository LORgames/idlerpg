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
using ToolCache.Scripting.Extensions;

namespace CityTools {
    public partial class GlobalVariableEditor : Form {
        EventHandler addedHandler;
        EventHandler removedHandler;
        EventHandler addedHandler2;
        EventHandler removedHandler2;
        EventHandler addedHandler3;
        EventHandler removedHandler3;

        public GlobalVariableEditor() {
            InitializeComponent();

            addedHandler = new EventHandler(new EventHandler(Variables_ItemAdded));
            removedHandler = new EventHandler(Variables_ItemRemoved);
            addedHandler2 = new EventHandler(new EventHandler(String_ItemAdded));
            removedHandler2 = new EventHandler(String_ItemRemoved);
            addedHandler3 = new EventHandler(new EventHandler(Function_ItemAdded));
            removedHandler3 = new EventHandler(Function_ItemRemoved);

            Variables.VerifyStats();
            Variables.GlobalVariables.ItemAdded += addedHandler;
            Variables.GlobalVariables.ItemRemoved += removedHandler;
            Variables.StringTable.ItemAdded += addedHandler2;
            Variables.StringTable.ItemRemoved += removedHandler2;
            Variables.FunctionTable.ItemAdded += addedHandler3;
            Variables.FunctionTable.ItemRemoved += removedHandler3;

            foreach (ScriptVariable sv in Variables.GlobalVariables.Values) {
                listVariables.Items.Add(sv.lvi);
            }

            foreach (String key in Variables.StringTable.Keys) {
                AddString(key);
            }

            foreach (ScriptFunction key in Variables.FunctionTable.Values) {
                listFunctions.Items.Add(key);
            }
        }
        private void GlobalVariableEditor_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (ListViewItem lvi in listVariables.Items) {
                listVariables.Items.Remove(lvi);
            }

            SaveFunctionIfRequired();

            Variables.GlobalVariables.ItemAdded -= addedHandler;
            Variables.GlobalVariables.ItemRemoved -= removedHandler;
            Variables.StringTable.ItemAdded -= addedHandler2;
            Variables.StringTable.ItemRemoved -= removedHandler2;
            Variables.FunctionTable.ItemAdded -= addedHandler3;
            Variables.FunctionTable.ItemRemoved -= removedHandler3;
            Variables.SaveDatabase();
        }

        void Variables_ItemAdded(object sender, EventArgs e) {
            if (Variables.GlobalVariables.ContainsKey(sender.ToString())) {
                listVariables.Items.Add(Variables.GlobalVariables[sender.ToString()].lvi);
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

        void Function_ItemAdded(object sender, EventArgs e) {
            listFunctions.Items.Add(sender);
        }

        void Function_ItemRemoved(object sender, EventArgs e) {
            listFunctions.Items.Remove(sender);
        }

        private void AddString(string key) {
            if (Variables.StringTable.ContainsKey(key)) {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = key;
                lvi.SubItems.Add(Variables.StringTable[lvi.Text]);
                listString.Items.Add(lvi);
            }
        }

        private void txtNewVariable_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string newVariable = Variables.FixVariableName(txtNewVariable.Text.Trim());

                ScriptVariable s = new ScriptVariable();
                s.Name = newVariable;
                s.InitialValue = 0;
                s.Index = 0;

                if (s.Name.Length > 0) {
                    Variables.AddVariableToDatabase(s);
                }

                txtNewVariable.Text = "";
            }
        }

        private void txtNewFunctionName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string newFunction = txtNewFunctionName.Text.Trim();

                ScriptFunction s = new ScriptFunction();
                s.Name = newFunction;
                s.Script = "";

                if (s.Name.Length > 0) {
                    Variables.FunctionTable.Add(s.Name, s);
                }

                txtNewFunctionName.Text = "";
            }
        }

        private void btnVarDeleteSelected_Click(object sender, EventArgs e) {
            List<String> keys = new List<string>();

            foreach (ListViewItem lvi in listVariables.SelectedItems) {
                keys.Add(lvi.Text);
            }

            foreach (String key in keys) {
                Variables.GlobalVariables.Remove(key);
            }

            keys.Clear();
            keys = null;
        }

        private void txtNewStringName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string newVariable = Variables.FixVariableName(txtNewStringName.Text.Trim());

                if (newVariable.Length > 0) {
                    Variables.StringTable.Add(newVariable, "");
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
                Variables.StringTable.Remove(key);
            }

            keys.Clear();
            keys = null;
        }

        void listString_SubItemEndEditing(object sender, Components.SubItemEndEditingEventArgs e) {
            string key = e.Item.Text;

            if (Variables.StringTable.ContainsKey(key)) {
                e.DisplayText = txtHiddenStringEditing.Text;
                Variables.StringTable[key] = txtHiddenStringEditing.Text;
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

        private ScriptFunction currentFunction;
        private void listFunctions_SelectedIndexChanged(object sender, EventArgs e) {
            if (listFunctions.SelectedItem is ScriptFunction) {
                SaveFunctionIfRequired();

                currentFunction = (listFunctions.SelectedItem as ScriptFunction);
                txtFunctionName.Text = currentFunction.Name;
                scriptFunction.Script = currentFunction.Script;

                txtFunctionName.Enabled = true;
                scriptFunction.Enabled = true;
            }
        }

        private void SaveFunctionIfRequired() {
            if (currentFunction != null) {
                currentFunction.Script = scriptFunction.Script;
                currentFunction.Name = txtFunctionName.Text;
                Variables.UpdatedFunction(currentFunction);
            }
        }

        private void txtNewLibraryName_KeyDown(object sender, KeyEventArgs e) {

        }
    }
}
