using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EngineDebugger {
    public partial class DebugForm : Form {
        delegate void SetTextCallback(string text);

        internal GenericServer gs;

        public DebugForm() {
            InitializeComponent();

            gs = new GenericServer(12685, this);

            this.FormClosed += new FormClosedEventHandler(DebugForm_FormClosed);
            this.FormClosing += new FormClosingEventHandler(DebugForm_FormClosing);

            VariableDebugHelper.BuildForm(this);
        }

        void DebugForm_FormClosing(object sender, FormClosingEventArgs e) {
            //e.Cancel = true;
            tmrUpdateTicker.Stop();
            //Logger.Log(this, "Cannot close before network is finished.");
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
            Thread clientThread = new Thread(new ThreadStart(RequestVariables));
            clientThread.Name = "DebugForm_VariableRequestThread";
            clientThread.Start();
        }

        private void RequestVariables() {
            gs.SendMessage(new NetworkMessage(MSG.REQUEST_VARIABLES));
        }
    }
}
