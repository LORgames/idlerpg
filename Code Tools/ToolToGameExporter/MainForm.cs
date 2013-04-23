using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ToolCache.General;

namespace ToolToGameExporter {
    public partial class MainForm : Form {
        
        public MainForm() {
            InitializeComponent();
            ToolCache.General.Startup.GoGoGadget(); // Start the system
        }

        private void game_btn_Click(object sender, EventArgs e) {
            folderBrowserDialog1.ShowDialog();
            txtDataFolderLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private void convert_btn_Click(object sender, EventArgs e) {
            if (Directory.Exists(Global.EXPORT_DIRECTORY)) {
                Directory.Delete(Global.EXPORT_DIRECTORY, true);
            }

            Directory.CreateDirectory(Global.EXPORT_DIRECTORY);

            try {
                ObjectCrusher.Go();
                TileCrusher.Go();
                MapCrusher.Go();
                EquipmentCrusher.Go();

                if (Directory.Exists(txtDataFolderLocation.Text)) {
                    Directory.Delete(txtDataFolderLocation.Text, true);
                    Directory.Move(Global.EXPORT_DIRECTORY, txtDataFolderLocation.Text);
                }

                MessageBox.Show("Exported To The Data Folder");
            } catch {
                MessageBox.Show("Please close the exporter and try again! (Some kind of caching issue occurred)");

                try {
                    Directory.Delete(Global.EXPORT_DIRECTORY, true);
                } catch { }
            }

            this.Close();
        }
    }
}
