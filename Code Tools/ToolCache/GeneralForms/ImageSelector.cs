using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.GeneralForms.ClipIns;

namespace ToolCache.GeneralForms {
    public partial class ImageSelector : Form {
        private Func<string, int> afterCompletion;

        public ImageSelector(Func<string, int> callback, string[] files) {
            InitializeComponent();

            afterCompletion = callback;
        }

        internal void Clicked(ImageSelector_ImagePnl imageSelector_ImagePnl) {
            MessageBox.Show("Clicked a image.");

            afterCompletion(imageSelector_ImagePnl.displayedImage);

            this.Close();
        }
    }
}
