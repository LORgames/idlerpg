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
        public const float PHYSICS_SCALE = 10.0f;

        Dictionary<int, int> remappedKeysForPlaces = new Dictionary<int, int>();  // <old, new>
        Dictionary<int, int> remappedKeysForScenary = new Dictionary<int, int>();  // <old, new>

        public Form1() {
            InitializeComponent();
        }

        private void tool_btn_Click(object sender, EventArgs e) {
            folderBrowserDialog1.ShowDialog();
            tool_loc_TB.Text = folderBrowserDialog1.SelectedPath;
        }

        private void game_btn_Click(object sender, EventArgs e) {
            folderBrowserDialog1.ShowDialog();
            game_loc_TB.Text = folderBrowserDialog1.SelectedPath;
        }

        private void convert_btn_Click(object sender, EventArgs e) {
            MessageBox.Show("This tool is not yet implemented.");
        }
    }
}
