using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolCache.GeneralForms {
    public partial class ImageSelector : Form {
        public ImageSelector() {
            InitializeComponent();
        }

        internal void Clicked(ClipIns.ImageSelector_ImagePnl imageSelector_ImagePnl) {
            MessageBox.Show("Clicked a image.");
        }
    }
}
