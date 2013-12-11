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
            pbExample.LoadCompleted += new AsyncCompletedEventHandler(pbExample_LoadCompleted);

            Library = lib;
            ImageName = imagename;

            this.ParentChanged += new EventHandler(UILibraryElement_ParentChanged);
        }

        void pbExample_LoadCompleted(object sender, AsyncCompletedEventArgs e) {
            int w = pbExample.Image.Width;
            int h = pbExample.Image.Height;
            
            lblSize.Text = w + "x" + h;

            if (w < 100) {
                w = 100;
                pbExample.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            
            if (h < 60) {
                h = 60;
                pbExample.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            if (w > 250) {
                w = 250;
            }

            if (h > 250) {
                h = 250;
            }

            this.Width = w;
            this.Height = h;
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

                FixOrdering(this.Parent);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (this.Parent != null) {
                Control _p = this.Parent;
                this.Parent.Controls.Remove(this);
                FixOrdering(_p);
            }
        }

        private void FixOrdering(Control _p) {
            Library.Images.Clear();
            foreach (Control c in _p.Controls) {
                if (c is UILibraryElement) {
                    UILibraryElement uile = (c as UILibraryElement);

                    uile.UpdateLabel();
                    Library.Images.Add(uile.ImageName);
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
