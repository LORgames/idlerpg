using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CityTools.Components {
    public partial class formOutput : Form {

        private static formOutput _G = null;
        internal static formOutput Get() {
            if (_G == null) _G = new formOutput();
            if (!_G.Visible) _G.Show();
            return _G;
        }

        public formOutput() {
            InitializeComponent();
        }
    }
}
