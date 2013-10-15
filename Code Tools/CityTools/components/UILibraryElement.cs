using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.UI;

namespace CityTools.Components {
    public partial class UILibraryElement : UserControl {
        public string ImageName;
        public UILibrary Library;

        public UILibraryElement(string imagename, UILibrary lib) {
            InitializeComponent();

            pbExample.LoadAsync(imagename);

            Library = lib;
            ImageName = imagename;

            this.ParentChanged += new EventHandler(UILibraryElement_ParentChanged);
        }

        void UILibraryElement_ParentChanged(object sender, EventArgs e) {
            UpdateLabel();
        }

        private void btnDown_Click(object sender, EventArgs e) {
            MoveZ(-1);
        }

        private void btnUp_Click(object sender, EventArgs e) {
            MoveZ(1);
        }

        private void MoveZ(int p) {
            if (this.Parent != null) {
                int index = this.Parent.Controls.GetChildIndex(this);

                index += p;

                if (index < this.Parent.Controls.Count && index > -1) {
                    this.Parent.Controls.SetChildIndex(this, index);
                }

                Library.Images.Clear();
                foreach (Control c in Parent.Controls) {
                    if (c is UILibraryElement) {
                        UILibraryElement uile = (c as UILibraryElement);

                        uile.UpdateLabel();
                        Library.Images.Add(uile.ImageName);
                    }
                }
            }
        }

        private void UpdateLabel() {
            if (this.Parent != null) {
                lblID.Text = this.Parent.Controls.GetChildIndex(this).ToString();
            }
        }
    }
}
