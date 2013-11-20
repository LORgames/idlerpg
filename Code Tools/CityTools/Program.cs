using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CityTools {

    public delegate void ChangedEventHandler(object sender, EventArgs e);

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
#if (!DEBUG)
            //try {
#endif
                ToolCache.General.Startup.GoGoGadget();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
#if (!DEBUG)
            //} catch (Exception ex) {
            //    MessageBox.Show("Message:\n" + ex.Message + "\n\nStack:\n" + ex.StackTrace);
            //}
#endif
        }
    }
}
