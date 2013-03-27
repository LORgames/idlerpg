﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CityTools {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
#if (!DEBUG)
            try {
#endif
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
#if (!DEBUG)
            } catch (Exception ex) {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
#endif
        }
    }
}
