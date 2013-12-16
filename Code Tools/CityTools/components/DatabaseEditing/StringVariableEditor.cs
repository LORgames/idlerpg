using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Scripting.Extensions;
using ToolCache.Scripting.Types;

namespace CityTools.Components.DatabaseEditing {
    public partial class StringVariableEditor : UserControl {
        EventHandler addedHandler;
        EventHandler removedHandler;

        public StringVariableEditor() {
            InitializeComponent();
            
            txtNewVariable.KeyDown += new KeyEventHandler(txtNewVariable_KeyDown);

            addedHandler = new EventHandler(new EventHandler(Variables_ItemAdded));
            removedHandler = new EventHandler(Variables_ItemRemoved);
            Variables.StringVariables.ItemAdded += addedHandler;
            Variables.StringVariables.ItemRemoved += removedHandler;

            foreach (StringVariable sv in Variables.StringVariables.Values) {
                listVariables.Items.Add(sv.lvi);
            }
        }

        protected override void Dispose(bool disposing) {
            foreach (ListViewItem lvi in listVariables.Items) {
                listVariables.Items.Remove(lvi);
            }
            
            Variables.StringVariables.ItemAdded -= addedHandler;
            Variables.StringVariables.ItemRemoved -= removedHandler;
            
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        void Variables_ItemAdded(object sender, EventArgs e) {
            if (Variables.StringVariables.ContainsKey(sender.ToString())) {
                listVariables.Items.Add(Variables.StringVariables[sender.ToString()].lvi);
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

        private void txtNewVariable_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string newVariable = Variables.FixVariableName(txtNewVariable.Text.Trim());

                StringVariable s = new StringVariable();
                s.Name = newVariable;
                s.InitialValue = "";
                s.Index = 0;

                if (s.Name.Length > 0) {
                    Variables.AddStringVariableToDatabase(s);
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
                Variables.StringVariables.Remove(key);
            }

            keys.Clear();
            keys = null;
        }

        private void listVariables_SubItemClicked(object sender, Components.SubItemEventArgs e) {
            if (e.SubItem == 1) {
                listVariables.StartEditing(txtStringChanger, e.Item, e.SubItem);
            }
        }

        private void listVariables_SubItemEndEditing(object sender, Components.SubItemEndEditingEventArgs e) {
            StringVariable s = (StringVariable)e.Item.Tag;

            s.InitialValue = txtStringChanger.Text;
            e.DisplayText = txtStringChanger.Text;
        }

        private void listVariables_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if (e.Item.Tag is StringVariable) {
                System.Diagnostics.Debug.WriteLine("VARIABLE=" + (e.Item.Tag as StringVariable).Name + " Saveable=" + e.Item.Checked);
                (e.Item.Tag as StringVariable).Saveable = e.Item.Checked;
            }
        }
    }
}
