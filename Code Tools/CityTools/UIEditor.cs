using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CityTools {
    public partial class UIEditor : Form {
        public UIEditor() {
            InitializeComponent();

            if (File.Exists("UI\\Background.png")) {
                pbExample.LoadAsync("UI\\Background.png");
            }
        }
    }
}
