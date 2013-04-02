using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.GeneralForms;
using System.IO;

namespace ToolCache.Items {
    public partial class ItemEditor : Form {


        public ItemEditor() {
            InitializeComponent();
        }

        private void pbItemIcon_Click(object sender, EventArgs e) {
            if (!Directory.Exists("Icons")) Directory.CreateDirectory("Icons");

            ImageSelector _is = new ImageSelector(NewIconSelected, Directory.GetFiles("Icons", "*.png"));
            _is.Show(this);
        }

        internal int NewIconSelected(string iconname) {
            return 0;
        }
    }
}
