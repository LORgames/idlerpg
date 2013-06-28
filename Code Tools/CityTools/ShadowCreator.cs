using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CityTools {
    public partial class ShadowCreator : Form {
        public ShadowCreator() {
            InitializeComponent();
        }

        private void previewBox_Paint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.White, e.ClipRectangle);
            e.Graphics.DrawString("Preview", new Font(FontFamily.GenericSerif, 10, FontStyle.Bold), Brushes.White, PointF.Empty);
        }
    }
}
