using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Scripting;

namespace CityTools {
    public partial class GlobalVariableEditor : Form {
        EventHandler addedHandler;
        EventHandler removedHandler;

        public GlobalVariableEditor() {
            InitializeComponent();

            addedHandler = new EventHandler(new EventHandler(Variables_ItemAdded));
            removedHandler = new EventHandler(Variables_ItemRemoved);

            GlobalVariables.Variables.ItemAdded += addedHandler;
            GlobalVariables.Variables.ItemRemoved += removedHandler;

            foreach (ScriptVariable sv in GlobalVariables.Variables.Values) {
                listVariables.Items.Add(sv.lvi);
            }
        }

        void Variables_ItemRemoved(object sender, EventArgs e) {
            //TODO: this
        }

        void Variables_ItemAdded(object sender, EventArgs e) {
            if(GlobalVariables.Variables.ContainsKey(sender.ToString())) {
                listVariables.Items.Add(GlobalVariables.Variables[sender.ToString()].lvi);
            }
        }

        private void GlobalVariableEditor_FormClosing(object sender, FormClosingEventArgs e) {
            GlobalVariables.Variables.ItemAdded -= addedHandler;
            GlobalVariables.Variables.ItemRemoved -= removedHandler;
            GlobalVariables.SaveDatabase();
        }

        private void txtNewVariable_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string newVariable = txtNewVariable.Text.Trim();

                ScriptVariable s = new ScriptVariable();
                s.Name = newVariable;
                s.InitialValue = 0;
                s.Index = 0;

                s.Name.Replace(" ", ""); //remove spaces

                if (s.Name.Length > 0) {
                    GlobalVariables.AddToDatabase(s);
                }

                txtNewVariable.Text = "";
            }
        }

        private void btnVarDeleteSelected_Click(object sender, EventArgs e) {
            //TODO: this. Just delete from the GlobalVariables.Variables dictionary and the event will fire; its already being listened to.
            MessageBox.Show("Not implemented yet!");
        }
    }
}
