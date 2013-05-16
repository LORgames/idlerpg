using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CityTools.Components;

namespace CityTools.Components {
    public partial class AnimationFrame : UserControl {
        AnimationList parent;

        public AnimationFrame(AnimationList _p) {
            InitializeComponent();

            parent = _p;
        }

        internal void SetFrame(string p) {
            pbThisFrame.LoadAsync(p);
        }

        private void btnDeleteFrame_Click(object sender, EventArgs e) {
            parent.DeleteFrame(this);
        }

        private void btnShiftFrameLeft_Click(object sender, EventArgs e) {
            parent.ShiftLeft(this);
        }

        private void btnShiftFrameRight_Click(object sender, EventArgs e) {
            parent.ShiftRight(this);
        }
    }
}
