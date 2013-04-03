using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolCache.GeneralForms.ClipIns {
    public partial class ImageSelector_ImagePnl : UserControl {
        internal ImageSelector owner = null;
        internal string displayedImage = "";

        public ImageSelector_ImagePnl() {
            InitializeComponent();
        }

        public void LinkToSelector(ImageSelector _is, string imageToShow) {
            owner = _is;
            displayedImage = imageToShow;
            pbInternal.Load(imageToShow);

            this.Width = pbInternal.Image.Width;
            this.Height = pbInternal.Image.Height;
        }

        private void ImageSelector_ImagePnl_Click(object sender, EventArgs e) {
            if (owner != null) {
                owner.Clicked(this);
            }
        }
    }
}
