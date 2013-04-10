using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Map.Objects;

namespace CityTools {
    public partial class TemplateEditor : Form {
        short objectID = 0;

        Point p0 = Point.Empty;
        Point p1 = Point.Empty;

        Rectangle _base = Rectangle.Empty;

        public TemplateEditor() {
            InitializeComponent();

            ccAnimation.SetSaveLocation("Objects");
            ccAnimation.ClearAnimation();

            UpdateObjectNames();
            ChangeTo(-1);

            timer1.Start();
        }

        private void ChangeTo(short objectID) {
            if (TemplateCache.G(objectID) != null) {
                ccAnimation.ChangeToAnimation(TemplateCache.G(objectID).Animation);
                cbTemplateGroup.Text = TemplateCache.G(objectID).ObjectGroup;
                txtTemplateName.Text = TemplateCache.G(objectID).ObjectName;
                _base = TemplateCache.G(objectID).Base;
                this.objectID = objectID;
            } else {
                this.objectID = TemplateCache.NextID();
                ccAnimation.ClearAnimation();
                cbTemplateGroup.Text = "Unknown";
                txtTemplateName.Text = "<Unknown>";
                _base = Rectangle.Empty;
            }

            lblTemplateID.Text = "N:" + this.objectID;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (TemplateCache.G(objectID) != null) {
                TemplateCache.G(objectID).Animation = ccAnimation.GetAnimation();
                TemplateCache.G(objectID).ObjectGroup = cbTemplateGroup.Text;
                TemplateCache.G(objectID).ObjectName = txtTemplateName.Text;
                TemplateCache.G(objectID).Base = _base;
            } else {
                Template t = new Template(objectID, txtTemplateName.Text, cbTemplateGroup.Text, ccAnimation.GetAnimation(), _base, true);
                TemplateCache.AddObject(t);
            }
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
            TemplateCache.WriteDatabase();
        }

        private void UpdateObjectNames() {
            cbTemplateNames.Items.Clear();
            cbTemplateGroup.Items.Clear();

            foreach (KeyValuePair<short, Template> kvp in TemplateCache.ObjectTypes) {
                cbTemplateNames.Items.Add(kvp.Key + "| " + kvp.Value.ObjectName);
            }

            foreach (String groupName in TemplateCache.GetGroups()) {
                cbTemplateGroup.Items.Add(groupName);
            }
        }

        private void cbTemplateNames_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbTemplateNames.Text.IndexOf('|') > -1) {
                string txt = cbTemplateNames.Text.Split('|')[0];

                short value;

                if (short.TryParse(txt, out value)) {
                    if (TemplateCache.G(value) != null) {
                        ChangeTo(value);
                    }
                }
            }
        }

        private void pbExampleBase_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p0 = e.Location;
                p1 = e.Location;

                _base.X = e.Location.X;
                _base.Y = e.Location.Y;
            }
        }

        private void pbExampleBase_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p1 = e.Location;

                if (p0.X < 0) p0.X = 0;
                if (p0.Y < 0) p0.Y = 0;
                if (p1.X < 0) p1.X = 0;
                if (p1.Y < 0) p1.Y = 0;

                _base.X = Math.Min(p0.X, p1.X);
                _base.Y = Math.Min(p0.Y, p1.Y);
                _base.Width = Math.Abs(p1.X - p0.X);
                _base.Height = Math.Abs(p1.Y - p0.Y);
            }
        }

        private void pbExampleBase_MouseMove(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                p1 = e.Location;

                _base.Width = p1.X - p0.X;
                _base.Height = p1.Y - p0.Y;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            pbExampleBase.Invalidate();
        }

        private void pbExampleBase_Paint(object sender, PaintEventArgs e) {
            ccAnimation.GetAnimation().Draw(e.Graphics, 0, 0, 1);
            e.Graphics.DrawRectangle(Pens.Red, _base);

            System.Diagnostics.Debug.WriteLine(_base);
        }
    }
}
