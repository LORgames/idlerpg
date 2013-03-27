using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CityTools.ObjectSystem;
using ToolCache.Map.Objects;

namespace CityTools.Components {
    public partial class ObjectCacheControl : UserControl {
        public ObjectCacheControl() {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public void Deactivate() {
            pnlInternal.SuspendLayout();
            pnlInternal.Controls.Clear();
            pnlInternal.ResumeLayout();
        }
    }
}
