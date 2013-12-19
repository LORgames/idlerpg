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
using ToolCache.UI;
using System.IO;
using CityTools.Components;

namespace CityTools {
    public partial class GlobalVariableEditor : Form {
        EventHandler addedHandler2;
        EventHandler removedHandler2;
        EventHandler addedHandler3;
        EventHandler removedHandler3;

        public GlobalVariableEditor() {
            InitializeComponent();

            lstLibraries.DataSource = UIManager.Libraries;
            lstLibraries.DisplayMember = Name;

            addedHandler2 = new EventHandler(new EventHandler(String_ItemAdded));
            removedHandler2 = new EventHandler(String_ItemRemoved);
            addedHandler3 = new EventHandler(new EventHandler(Function_ItemAdded));
            removedHandler3 = new EventHandler(Function_ItemRemoved);

            Variables.StringTable.ItemAdded += addedHandler2;
            Variables.StringTable.ItemRemoved += removedHandler2;
            Variables.FunctionTable.ItemAdded += addedHandler3;
            Variables.FunctionTable.ItemRemoved += removedHandler3;

            foreach (String key in Variables.StringTable.Keys) {
                AddString(key);
            }

            foreach (ScriptFunction key in Variables.FunctionTable.Values) {
                listFunctions.Items.Add(key);
            }
        }
        private void GlobalVariableEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SaveFunctionIfRequired();

            Variables.StringTable.ItemAdded -= addedHandler2;
            Variables.StringTable.ItemRemoved -= removedHandler2;
            Variables.FunctionTable.ItemAdded -= addedHandler3;
            Variables.FunctionTable.ItemRemoved -= removedHandler3;

            Variables.SaveDatabase();
            UIManager.WriteDatabase();
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
            listFunctions.Items.Add(Variables.FunctionTable[sender.ToString()]);
        }

        void Function_ItemRemoved(object sender, EventArgs e) {
            listFunctions.Items.Remove(Variables.FunctionTable[sender.ToString()]);
        }

        private void AddString(string key) {
            if (Variables.StringTable.ContainsKey(key)) {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = key;
                lvi.SubItems.Add(Variables.StringTable[lvi.Text]);
                listString.Items.Add(lvi);
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
            if (e.KeyCode == Keys.Enter) {
                string newVariable = txtNewLibraryName.Text.Trim();

                if (newVariable.Length > 0) {
                    UIManager.AddLibrary(new UILibrary(newVariable));
                }

                txtNewLibraryName.Text = "";
            }
        }

        private void pnlUILibrary_DragDrop(object sender, DragEventArgs e) {
            if (lstLibraries.SelectedItem == null) return;

            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (data != null) {
                    for (int i = 0; i < data.Length; i++) {
                        if (data.GetValue(i) is String) {
                            string filename = ((string[])data)[i];
                            string ext = Path.GetExtension(filename).ToLower();

                            string nFilename = "UI/" + Path.GetFileNameWithoutExtension(filename) + ".png";

                            if (ext == ".png") {
                                //Add animation
                                if (Path.GetFullPath(nFilename) == Path.GetFullPath(filename)) {
                                    //Don't need to do anything, its the same file
                                } else if (!File.Exists(nFilename)) {
                                    File.Copy(filename, nFilename);
                                } else if (MessageBox.Show("Overwrite " + nFilename + "?", "Overwrite?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                    File.Copy(filename, nFilename, true);
                                }

                                (lstLibraries.SelectedItem as UILibrary).Images.Add(nFilename);
                                AddImageToLibrary(nFilename);
                            }
                        }
                    }
                }
            }
        }

        private void AddImageToLibrary(string nFilename) {
            if (lstLibraries.SelectedItem != null) {
                UILibraryElement uile = new UILibraryElement(nFilename, lstLibraries.SelectedItem as UILibrary);
                pnlUILibrary.Controls.Add(uile);
            }
        }

        private void pnlUILibrary_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void lstLibraries_SelectedIndexChanged(object sender, EventArgs e) {
            if (lstLibraries.SelectedItem != null) {
                pnlUILibrary.Controls.Clear();

                for (int i = 0; i < (lstLibraries.SelectedItem as UILibrary).Images.Count; i++) {
                    AddImageToLibrary((lstLibraries.SelectedItem as UILibrary).Images[i]);
                }
            }
        }

        private void btnDeleteLibraries_Click(object sender, EventArgs e) {
            if (lstLibraries.SelectedItems.Count > 0) {
                List<UILibrary> toDelete = new List<UILibrary>();

                for (int i = 0; i < lstLibraries.SelectedItems.Count; i++) {
                    toDelete.Add(lstLibraries.SelectedItems[i] as UILibrary);
                }

                for (int i = 0; i < toDelete.Count; i++) {
                    UIManager.Libraries.Remove(toDelete[i]);
                }

                toDelete.Clear();
                toDelete = null;
            }
        }

        private void btnDeleteFunction_Click(object sender, EventArgs e) {
            if (listFunctions.SelectedItems.Count > 0) {
                List<ScriptFunction> toDelete = new List<ScriptFunction>();

                for (int i = 0; i < listFunctions.SelectedItems.Count; i++) {
                    toDelete.Add(listFunctions.SelectedItems[i] as ScriptFunction);
                }

                for (int i = 0; i < toDelete.Count; i++) {
                    Variables.FunctionTable.Remove(toDelete[i].Name);
                }

                toDelete.Clear();
                toDelete = null;
            }
        }
    }
}
