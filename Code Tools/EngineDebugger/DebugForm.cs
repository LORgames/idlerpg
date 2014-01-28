using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EngineDebugger {
    public partial class DebugForm : Form {
        delegate void SetTextCallback(string text);

        GenericServer gs;

        public DebugForm() {
            InitializeComponent();

            gs = new GenericServer(12685, this);

            this.FormClosed += new FormClosedEventHandler(DebugForm_FormClosed);

            VariableDebugHelper.BuildForm(this);
        }

        void DebugForm_FormClosed(object sender, FormClosedEventArgs e) {
            gs.Shutdown();
        }

        internal void AddTrace(String msg) {
            if (lstMessages.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(AddTrace);
                this.Invoke(d, msg);
            } else {
                lstMessages.Items.Add(msg);
            }
        }

        private void tmrUpdateTicker_Tick(object sender, EventArgs e) {
            if (tabControl1.SelectedTab == tabPage1) { //Do nothing

            } else if (tabControl1.SelectedTab == tabPage2) { //Update variables
                RequestVariables();
            }
        }

        private void RequestVariables() {
            gs.SendMessage(new NetworkMessage(MSG.REQUEST_VARIABLES));
        }
    }
}
