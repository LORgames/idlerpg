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
using CityTools.Components;

namespace CityTools {
    public partial class ObjectEditor : Form {
        public delegate void SaveEventHandler(object source, short objectID);
        public event SaveEventHandler OnSave;

        private short objectID = 0;
        private MapObject CurrentObject = null;

        private Point p0 = new Point(-1, 0);
        private Point p1 = Point.Empty;

        private List<Rectangle> _bases = new List<Rectangle>();

        private Boolean _isEdited = false; //is edited
        private Boolean _isNew = false; //Is it new?
        private Boolean _isUpdating = false; //Is it updating?

        public ObjectEditor() {
            InitializeComponent();

            ccAnimation.SetSaveLocation("Objects");
            ccAnimation.ClearAnimation();
            ccAnimation.AnimationChanged += AnimationChanged;

            scriptBox1.ScriptUpdated += ValueChanged;

            UpdateObjectNames();
            ChangeTo(-1);

            timer1.Start();
        }

        private void ChangeTo(short objectID) {
            if (_isEdited) {
                if (_isNew && MessageBox.Show("Do you want to keep this object?", "Caption?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Save();
                } else if (!_isNew) {
                    Save();
                }
            }

            _isUpdating = true;

            if (MapObjectCache.G(objectID) != null) {
                _isNew = false;
                ccAnimation.ChangeToAnimation(MapObjectCache.G(objectID).Animation);
                cbTemplateGroup.Text = MapObjectCache.G(objectID).ObjectGroup;
                txtTemplateName.Text = MapObjectCache.G(objectID).ObjectName;
                numOffsetHeight.Value = MapObjectCache.G(objectID).OffsetY;
                ckbIsSolid.Checked = MapObjectCache.G(objectID).isSolid;
                _bases = MapObjectCache.G(objectID).Blocks;
                scriptBox1.Script = MapObjectCache.G(objectID).Script;
                this.objectID = objectID;
            } else {
                _isNew = true;
                this.objectID = MapObjectCache.NextID();
                ccAnimation.ClearAnimation();
                cbTemplateGroup.Text = "Unknown";
                txtTemplateName.Text = "<Unknown>";
                scriptBox1.Script = "";
                _bases = new List<Rectangle>();
            }

            lblTemplateID.Text = "N:" + this.objectID;

            _isUpdating = false;
            _isEdited = false;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Save();
        }

        private void Save() {
            if (MapObjectCache.G(objectID) != null) {
                MapObjectCache.G(objectID).Animation = ccAnimation.GetAnimation();
                MapObjectCache.G(objectID).ObjectGroup = cbTemplateGroup.Text;
                MapObjectCache.G(objectID).ObjectName = txtTemplateName.Text;
                MapObjectCache.G(objectID).Blocks = _bases;
                MapObjectCache.G(objectID).OffsetY = (int)numOffsetHeight.Value;
                MapObjectCache.G(objectID).isSolid = ckbIsSolid.Checked;
                MapObjectCache.G(objectID).Script = scriptBox1.Script;
            } else {
                MapObject t = new MapObject(objectID, txtTemplateName.Text, cbTemplateGroup.Text, ccAnimation.GetAnimation(), (int)numOffsetHeight.Value, _bases, ckbIsSolid.Checked, scriptBox1.Script);
                MapObjectCache.AddObject(t);
            }

            _isNew = false;
            _isEdited = false;

            UpdateObjectNames();
        }

        private void btnDeleteTemplate_Click(object sender, EventArgs e) {
            MapObjectCache.Delete(objectID);
            UpdateObjectNames();
        }

        private void btnNewTemplate_Click(object sender, EventArgs e) {
            ChangeTo(-1);
            UpdateObjectNames();
        }

        private void TemplateEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (_isEdited) {
                if (_isNew && MessageBox.Show("Do you want to keep this object?", "Save Object?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Save();
                } else if (!_isNew) {
                    Save();
                }
            }

            MapObjectCache.WriteDatabase();
        }

        private void UpdateObjectNames() {
            cbTemplateGroup.Items.Clear();
            treeTemplateNames.Nodes.Clear();

            Dictionary<string, TreeNode> rootNodes = new Dictionary<string, TreeNode>();
            List<string> groups = MapObjectCache.GetGroups();

            foreach (String groupName in groups) {
                rootNodes.Add(groupName, new TreeNode(groupName));
                treeTemplateNames.Nodes.Add(rootNodes[groupName]);

                cbTemplateGroup.Items.Add(groupName);
            }

            foreach (KeyValuePair<short, MapObject> kvp in MapObjectCache.ObjectTypes) {
                TreeNode node = new TreeNode(kvp.Value.ObjectName);
                node.Tag = kvp.Key;

                rootNodes[kvp.Value.ObjectGroup].Nodes.Add(node);
            }

            treeTemplateNames.ExpandAll();
        }

        private void pbExampleBase_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                p0 = e.Location;
                p1 = e.Location;
            }
        }

        private void pbExampleBase_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && p0.X > -1) {
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

                if (OnSave != null) {
                    OnSave(this, objectID);
                }

                p0.X = -1;
            }
        }

        private void pbExampleBase_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && p0.X > -1) {
                p1 = e.Location;
                pbExampleBase.Invalidate();
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

            //Draw the mouse rect if there is one
            if (p0.X > -1) {
                if (p0.X < 0) p0.X = 0; if (p0.Y < 0) p0.Y = 0; if (p1.X < 0) p1.X = 0; if (p1.Y < 0) p1.Y = 0;
                Rectangle r = new Rectangle();
                r.X = Math.Min(p0.X, p1.X); r.Y = Math.Min(p0.Y, p1.Y);
                r.Width = Math.Abs(p1.X - p0.X); r.Height = Math.Abs(p1.Y - p0.Y);
                e.Graphics.DrawRectangle(Pens.Magenta, r);
            }
        }

        private void treeTemplateNames_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeTemplateNames.SelectedNode.Tag != null) {
                ChangeTo((short)treeTemplateNames.SelectedNode.Tag);
            }
        }

        private void ValueChanged(object sender, EventArgs e) {
            Edited();
        }

        private void Edited() {
            if (!_isUpdating) _isEdited = true;
        }

        private void AnimationChanged(object sender, EventArgs e) {
            Edited();

            foreach (String s in ccAnimation.GetAnimation().Frames) {
                ImageCache.ForceCache(s);
            }
        }

        private void btnRemoveBoxes_Click(object sender, EventArgs e) {
            _bases.Clear();

            if (OnSave != null) {
                OnSave(this, objectID);
            }
        }
    }
}
