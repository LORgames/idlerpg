using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ToolCache.Animation.Form {
    public partial class AnimationList : UserControl {
        public AnimationList() {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_DragDrop(object sender, DragEventArgs e) {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null) {
                    for (int i = 0; i < data.Length; i++) {
                        if (data.GetValue(i) is String) {
                            string filename = ((string[])data)[i];
                            string ext = Path.GetExtension(filename).ToLower();
                            if (ext == ".png") {
                                //Add animation
                                File.Copy(filename, "objcache/" + Path.GetFileNameWithoutExtension(filename) + "_in.png");
                            }
                        }
                    }
                }
            }
        }
    }
}
