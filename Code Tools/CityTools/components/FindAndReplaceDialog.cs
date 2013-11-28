using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CityTools.Components {
    public partial class FindAndReplaceDialog : Form {
        public string Find {
            get { return txtFind.Text; }
        }

        public string Replace {
            get { return txtReplace.Text; }
        }

        public event EventHandler OnFind {
            add { btnFind.Click += new EventHandler(value); }
            remove { btnFind.Click -= new EventHandler(value); }
        }

        public event EventHandler OnReplace {
            add { btnReplace.Click += new EventHandler(value); }
            remove { btnReplace.Click -= new EventHandler(value); }
        }

        public FindAndReplaceDialog() {
            InitializeComponent();
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) {
                btnFind.PerformClick();
            }
        }

        private void txtReplace_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) {
                btnReplace.PerformClick();
            }
        }
    }
}
