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
using ToolCache.Animation;

namespace CityTools {
    public partial class ObjectEditor : Form {
        public delegate void SaveEventHandler(object source, short objectID);
        public event SaveEventHandler OnSave;

        private MapObject CurrentObject = null;

        private Point p0 = new Point(-1, 0);
        private Point p1 = Point.Empty;

        private Boolean _isEdited = false; //is edited
        private Boolean _isNew = false; //Is it new?
        private Boolean _isUpdating = false; //Is it updating?

        public ObjectEditor() {
            InitializeComponent();

            ccAnimation.SetSaveLocation("Objects");
            ccAnimation.ClearAnimation();
            ccAnimation.AnimationChanged += AnimationChanged;

            scriptBox.ScriptUpdated += ValueChanged;

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
            _isNew = false;

            CurrentObject = MapObjectCache.G(objectID);

            if (CurrentObject == null) {
                _isNew = true;
                CurrentObject = new MapObject();
                CurrentObject.ObjectID = MapObjectCache.NextID();
            }

            ccAnimation.ChangeToAnimation(CurrentObject.Animations["Default"]);
            cbTemplateGroup.Text = CurrentObject.ObjectGroup;
            txtTemplateName.Text = CurrentObject.ObjectName;
            numOffsetHeight.Value = CurrentObject.OffsetY;
            ckbIsSolid.Checked = CurrentObject.isSolid;
            scriptBox.Script = CurrentObject.Script;
            ckIndividualAnimations.Checked = CurrentObject.IndividualAnimations;
            RefillAnimationNames();

            lblTemplateID.Text = "N:" + CurrentObject.ObjectID;

            _isUpdating = false;
            _isEdited = false;
        }

        private void RefillAnimationNames() {
            cbAnimationName.Items.Clear();
            foreach (String s in CurrentObject.Animations.Keys) {
                cbAnimationName.Items.Add(s);
            }

            cbAnimationName.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            Save();
        }

        private void Save() {
            if (CurrentObject != null) {
                CurrentObject.ObjectGroup = cbTemplateGroup.Text;
                CurrentObject.ObjectName = txtTemplateName.Text;
                CurrentObject.OffsetY = (int)numOffsetHeight.Value;
                CurrentObject.isSolid = ckbIsSolid.Checked;
                CurrentObject.Script = scriptBox.Script;
                CurrentObject.IndividualAnimations = ckIndividualAnimations.Checked;

                if (_isNew) {
                    MapObjectCache.AddObject(CurrentObject);
                }
            }

            _isNew = false;
            _isEdited = false;

            UpdateObjectNames();
        }

        private void btnDeleteTemplate_Click(object sender, EventArgs e) {
            MapObjectCache.Delete(CurrentObject);
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

                CurrentObject.Blocks.Add(r);
                Edited();

                if (OnSave != null) {
                    OnSave(this, CurrentObject.ObjectID);
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
                foreach (Rectangle r in CurrentObject.Blocks) {
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
            CurrentObject.Blocks.Clear();
            Edited();

            if (OnSave != null) {
                OnSave(this, CurrentObject.ObjectID);
            }
        }

        private void cbAnimationName_TextChanged(object sender, EventArgs e) {
            if (CurrentObject != null && !_isUpdating) {
                List<String> badAnims = CurrentObject.CleanUpAnimations();
                foreach (String s in badAnims) {
                    cbAnimationName.Items.Remove(s);
                }

                if (!CurrentObject.Animations.ContainsKey(cbAnimationName.Text)) {
                    CurrentObject.Animations.Add(cbAnimationName.Text, new AnimatedObject());
                    cbAnimationName.Items.Add(cbAnimationName.Text);
                }

                ccAnimation.ChangeToAnimation(CurrentObject.Animations[cbAnimationName.Text]);
            }
        }

        private void scriptBox_BeforeParse(object sender, ScriptInfoArgs e) {
            e.Info.AnimationNames.AddRange(CurrentObject.Animations.Keys);
        }
    }
}
