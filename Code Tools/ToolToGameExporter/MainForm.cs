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
        }

        private void game_btn_Click(object sender, EventArgs e) {
            folderBrowserDialog1.ShowDialog();
            txtDataFolderLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private void convert_btn_Click(object sender, EventArgs e) {
            Processor.Go(txtDataFolderLocation.Text);
            this.Close();
        }
    }
}
