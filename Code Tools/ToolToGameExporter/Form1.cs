using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using System.IO;
using ToolCache.General;

namespace ToolToGameExporter {
    public partial class Form1 : Form {
        
        public Form1() {
            InitializeComponent();
            ToolCache.General.Startup.GoGoGadget(); // Start the system
        }

        private void game_btn_Click(object sender, EventArgs e) {
            folderBrowserDialog1.ShowDialog();
            game_loc_TB.Text = folderBrowserDialog1.SelectedPath;
        }

        private void convert_btn_Click(object sender, EventArgs e) {
            if (Directory.Exists(Global.EXPORT_DIRECTORY)) {
                Directory.Delete(Global.EXPORT_DIRECTORY, true);
            }

            Directory.CreateDirectory(Global.EXPORT_DIRECTORY);

            ObjectCrusher.Go();
            TileCrusher.Go();
        }
    }
}
