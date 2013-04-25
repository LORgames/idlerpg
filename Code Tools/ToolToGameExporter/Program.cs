using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ToolToGameExporter {
    public static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ToolCache.General.Startup.GoGoGadget(); // Start the system

            if (args.Length == 0) {
                Application.Run(new MainForm());
            } else if (args.Length == 1) {
                Application.Run();
                Processor.Go(args[0]);
            } else {
                Application.Run();
                MessageBox.Show("Unknown arguments!");
            }
        }
    }
}
