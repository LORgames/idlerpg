using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EngineDebugger {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            ToolCache.General.Startup.GoGoGadget(); // Start the system

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DebugForm());
        }
    }
}
