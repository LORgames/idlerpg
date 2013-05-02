using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Map.Objects;
using ToolCache.General;

namespace CityTools {
    public partial class TemplateEditor : Form {
        short objectID = 0;

        Point p0 = Point.Empty;
        Point p1 = Point.Empty;

        List<Rectangle> _bases = new List<Rectangle>();

        Boolean _iE = false; //is edited
        Boolean _new = false; //Is it new?
        Boolean _updating = false; //Is it updating?

        public TemplateEditor() {
            InitializeComponent();

            ccAnimation.SetSaveLocation("Objects");
            ccAnimation.ClearAnimation();
            ccAnimation.AnimationChanged += AnimationChanged;

            UpdateObjectNames();
            ChangeTo(-1);

            timer1.Start();
        }

        private void ChangeTo(short objectID) {
            if (_iE) {
                if (_new && MessageBox.Show("Do you want to keep this object?", "Caption?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Save();
                } else if (!_new) {
                    Save();
                }
            }

            _updating = true;

            if (TemplateCache.G(objectID) != null) {
                _new = false;
                ccAnimation.ChangeToAnimation(TemplateCache.G(objectID).Animation);
                cbTemplateGroup.Text = TemplateCache.G(objectID).ObjectGroup;
                txtTemplateName.Text = TemplateCache.G(objectID).ObjectName;
                numOffsetHeight.Value = TemplateCache.G(objectID).OffsetY;
                ckbIsSolid.Checked = TemplateCache.G(objectID).isSolid;
                _bases = TemplateCache.G(objectID).Blocks;
                this.objectID = objectID;
            } else {
                _new = true;
                this.objectID = TemplateCache.NextID();
                ccAnimation.ClearAnimation();
                cbTemplateGroup.Text = "Unknown";
                txtTemplateName.Text = "<Unknown>";
                _bases = new List<Rectangle>();
            }

            lblTemplateID.Text = "N:" + this.objectID;

            _updating = false;
            _iE = false;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Save();
        }

        private void Save() {
            if (TemplateCache.G(objectID) != null) {
                TemplateCache.G(objectID).Animation = ccAnimation.GetAnimation();
                TemplateCache.G(objectID).ObjectGroup = cbTemplateGroup.Text;
                TemplateCache.G(objectID).ObjectName = txtTemplateName.Text;
                TemplateCache.G(objectID).Blocks = _bases;
                TemplateCache.G(objectID).OffsetY = (int)numOffsetHeight.Value;
                TemplateCache.G(objectID).isSolid = ckbIsSolid.Checked;
            } else {
                Template t = new Template(objectID, txtTemplateName.Text, cbTemplateGroup.Text, ccAnimation.GetAnimation(), (int)numOffsetHeight.Value, _bases, ckbIsSolid.Checked);
                TemplateCache.AddObject(t);
            }

            _new = false;
            _iE = false;

            UpdateObjectNames();
        }

        private void btnDeleteTemplate_Click(object sender, EventArgs e) {
            TemplateCache.Delete(objectID);
            UpdateObjectNames();
        }

        private void btnNewTemplate_Click(object sender, EventArgs e) {
            ChangeTo(-1);
            UpdateObjectNames();
        }

        private void TemplateEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (_iE) {
                if (_new && MessageBox.Show("Do you want to keep this object?", "Save Object?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Save();
                } else if (!_new) {
                    Save();
                }
            }

            TemplateCache.WriteDatabase();
        }

        private void UpdateObjectNames() {
            cbTemplateGroup.Items.Clear();
            treeTemplateNames.Nodes.Clear();

            Dictionary<string, TreeNode> rootNodes = new Dictionary<string, TreeNode>();
            List<string> groups = TemplateCache.GetGroups();

            foreach (String groupName in groups) {
                rootNodes.Add(groupName, new TreeNode(groupName));
                treeTemplateNames.Nodes.Add(rootNodes[groupName]);

                cbTemplateGroup.Items.Add(groupName);
            }

            foreach (KeyValuePair<short, Template> kvp in TemplateCache.ObjectTypes) {
                TreeNode node = new TreeNode(kvp.Value.ObjectName);
                node.Tag = kvp.Key;

                rootNodes[kvp.Value.ObjectGroup].Nodes.Add(node);
            }

            treeTemplateNames.ExpandAll();
        }

        private void pbExampleBase_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p0 = e.Location;
                p1 = e.Location;
            }
        }

        private void pbExampleBase_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p1 = e.Location;

                if (p0.X < 0) p0.X = 0;
                if (p0.Y < 0) p0.Y = 0;
                if (p1.X < 0) p1.X = 0;
                if (p1.Y < 0) p1.Y = 0;

                Rectangle r = new Rectangle();
                r.X = Math.Min(p0.X, p1.X);
                r.Y = Math.Min(p0.Y, p1.Y);
                r.Width = Math.Abs(p1.X - p0.X);
                r.Height = Math.Abs(p1.Y - p0.Y);

                _bases.Add(r);
            }
        }

        private void pbExampleBase_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p1 = e.Location;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            pbExampleBase.Invalidate();
        }

        private void pbExampleBase_Paint(object sender, PaintEventArgs e) {
            ccAnimation.GetAnimation().Draw(e.Graphics, 0, 0, 1);

            if (ckbDrawRectangles.Checked) {
                foreach (Rectangle r in _bases) {
                    e.Graphics.DrawRectangle(Pens.White, r);
                }
            }

            if (ckbDrawOffset.Checked) {
                e.Graphics.DrawLine(Pens.Red, 0, (int)numOffsetHeight.Value, pbExampleBase.Width, (int)numOffsetHeight.Value);
            }
        }

        private void treeTemplateNames_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeTemplateNames.SelectedNode.Tag != null) {
                ChangeTo((short)treeTemplateNames.SelectedNode.Tag);
            }
        }

        private void ValueChanged(object sender, EventArgs e) {
            if(!_updating) _iE = true;
        }

        private void AnimationChanged(object sender, EventArgs e) {
            if (!_updating) _iE = true;

            foreach (String s in ccAnimation.GetAnimation().Frames) {
                ImageCache.ForceCache(s);
            }
        }

        private void btnRemoveBoxes_Click(object sender, EventArgs e) {
            _bases.Clear();
        }
    }
}
