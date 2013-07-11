using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CityTools.Components;
using ToolCache.Effects;
using System.IO;
using ToolCache.Animation;
using ToolCache.General;

namespace CityTools {
    public partial class EffectEditor : Form {
        private Effect CurrentEffect;

        private bool EffectEdited = false;
        private bool EffectIsNew = false;
        private bool EffectSwitching = false;

        private Dictionary<String, TreeNode> ParentTreeNodes = new Dictionary<string, TreeNode>();

        public EffectEditor() {
            InitializeComponent();
            FillTree();

            if (!Directory.Exists("Effects")) Directory.CreateDirectory("Effects");
            animationList.SetSaveLocation("Effects");
            animationList.DisablePlaybackSpeed();
        }

        private void FillTree() {
            foreach (KeyValuePair<string, List<Effect>> kvp in EffectManager.EffectsInGroups) {
                kvp.Value.Sort(delegate(Effect e1, Effect e2) { return e1.Name.CompareTo(e2.Name); });
                VerifyGroup(kvp.Key);

                foreach(Effect e in kvp.Value) {
                    TreeNode node = new TreeNode(e.Name);
                    node.Tag = e;

                    ParentTreeNodes[e.Group].Nodes.Add(node);
                }
            }
        }

        private void VerifyGroup(string groupName) {
            if (!ParentTreeNodes.ContainsKey(groupName)) {
                TreeNode node = new TreeNode(groupName);
                ParentTreeNodes.Add(groupName, node);
                treeView.Nodes.Add(node);
                node.Expand();
                cbGroup.Items.Add(groupName);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            if (CurrentEffect != null) {
                e.Graphics.Clear(Color.Azure);
                if(animationList.GetAnimation() != null) {
                    animationList.GetAnimation().Draw(e.Graphics, 0, 0, 1);
                }

                if (ckbDrawDebug.Checked) {
                    Image im = ImageCache.RequestImage(animationList.GetAnimation().Frames[0]);
                    if(im != null) {
                        int x = im.Width/2 - (int)(numSizeX.Value/2) + (int)numOffsetX.Value;
                        int y = im.Height - (int)(numSizeY.Value) - (int)numOffsetY.Value;
                        e.Graphics.DrawRectangle(Pens.Red, x, y, (int)numSizeX.Value, (int)numSizeY.Value);
                    }
                }
            }
        }

        private void btnCreateNewEffect_Click(object sender, EventArgs e) {
            SaveIfRequired();

            EffectIsNew = true;
            CurrentEffect = new Effect();
            UpdateForm();
        }

        private void SaveIfRequired() {
            if (CurrentEffect != null && EffectEdited) {
                CurrentEffect.Name = txtEffectName.Text;
                CurrentEffect.Group = cbGroup.Text;
                CurrentEffect.Script = scriptEffect.Script;

                CurrentEffect.MovementSpeed = (short)numSpeed.Value;
                CurrentEffect.Life = (float)numLifetime.Value;

                CurrentEffect.Area.X = (int)numOffsetX.Value;
                CurrentEffect.Area.Y = (int)numOffsetY.Value;
                CurrentEffect.Area.Width = (int)numSizeX.Value;
                CurrentEffect.Area.Height = (int)numSizeY.Value;

                VerifyGroup(CurrentEffect.Group);

                if (EffectIsNew) {
                    EffectManager.AddEffect(CurrentEffect);
                    TreeNode node = new TreeNode(CurrentEffect.Name);
                    node.Tag = CurrentEffect;
                    ParentTreeNodes[CurrentEffect.Group].Nodes.Add(node);
                } else {
                    UpdateTreeNode();
                    EffectManager.UpdatedEffect(CurrentEffect);
                }

                EffectEdited = false;
                EffectIsNew = false;
            }
        }

        private void UpdateTreeNode() {
            if (CurrentEffect != null) {
                VerifyGroup(CurrentEffect.Group);

                if (CurrentEffect.Group != CurrentEffect.OldGroup || CurrentEffect.Name != CurrentEffect.OldName) {
                    foreach (TreeNode node in ParentTreeNodes[CurrentEffect.OldGroup].Nodes) {
                        if (node.Text == CurrentEffect.OldName) {
                            node.Text = CurrentEffect.Name;

                            node.Remove();
                            ParentTreeNodes[CurrentEffect.Group].Nodes.Add(node);
                            break;
                        }
                    }
                }
            }
        }

        private void UpdateForm() {
            if (CurrentEffect != null) {
                splitContainer1.Panel2.Enabled = true;

                EffectSwitching = true;

                txtEffectName.Text = CurrentEffect.Name;
                cbGroup.Text = CurrentEffect.Group;
                scriptEffect.Script = CurrentEffect.Script;

                numSpeed.Value = (decimal)CurrentEffect.MovementSpeed;
                numLifetime.Value = (decimal)CurrentEffect.Life;

                numOffsetX.Value = CurrentEffect.Area.X;
                numOffsetY.Value = CurrentEffect.Area.Y;
                numSizeX.Value = CurrentEffect.Area.Width;
                numSizeY.Value = CurrentEffect.Area.Height;

                //Add animations
                UpdateAnimationList();

                EffectSwitching = false;
            } else {
                splitContainer1.Panel2.Enabled = false;
            }
        }

        private void EffectEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SaveIfRequired();
            EffectManager.WriteDatabase();
        }

        private void ValueChanged(object sender, EventArgs e) {
            if (EffectSwitching) return;
            EffectEdited = true;
        }

        private void scriptEffect_BeforeParse(object sender, ScriptInfoArgs e) {
            e.Info.AnimationNames.AddRange(CurrentEffect.Animations.Keys);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeView.SelectedNode != null) {
                if (treeView.SelectedNode.Tag != null) {
                    if (treeView.SelectedNode.Tag is Effect) {
                        SaveIfRequired();
                        CurrentEffect = (treeView.SelectedNode.Tag as Effect);
                        UpdateForm();
                    }
                }
            }
        }

        private void cbAnimations_TextUpdate(object sender, EventArgs e) {
            if (CurrentEffect != null) {
                animationList.ChangeToAnimation(CurrentEffect.GetAnimation(cbAnimations.Text));
            }
        }

        private void Folder_DragDrop(object sender, DragEventArgs e) {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (data != null) {
                    for (int i = 0; i < data.Length; i++) {
                        if (data.GetValue(i) is String) {
                            string filename = ((string[])data)[i];
                            ProcessDirectory(filename);
                            UpdateAnimationList();
                        }
                    }
                }
            }
        }

        private void UpdateAnimationList() {
            if (CurrentEffect != null) {
                string selectedItem = cbAnimations.Text;
                bool setIndex = false;

                cbAnimations.Items.Clear();

                foreach (string animationName in CurrentEffect.Animations.Keys) {
                    cbAnimations.Items.Add(animationName);
                    if (animationName == selectedItem) {
                        cbAnimations.SelectedIndex = cbAnimations.Items.Count - 1;
                        setIndex = true;
                    }
                }

                if (!setIndex) {
                    if (cbAnimations.Items.Count > 0) {
                        cbAnimations.SelectedIndex = 0;
                    } else {
                        cbAnimations.Text = "";
                        animationList.ClearAnimation();
                    }
                }
            }
        }

        private void ProcessDirectory(string folder) {
            if (Directory.Exists(folder)) {
                string[] folders = Directory.GetDirectories(folder);

                if (folders.Length == 0) {
                    string animationName = Path.GetFileName(folder);
                    AnimatedObject ao = CurrentEffect.GetAnimation(animationName);

                    string[] files = Directory.GetFiles(folder, "*.png");

                    if(files.Length > 0) {
                        Array.Sort(files);

                        foreach (string file in files) {
                            string simpleName = Path.GetFileName(file);
                            File.Copy(file, ".\\Effects\\" + simpleName);
                            ao.Frames.Add(".\\Effects\\" + simpleName);
                        }

                        EffectEdited = true;
                    }
                } else {
                    foreach (string childFolder in folders) {
                        ProcessDirectory(childFolder);
                    }
                }
            }
        }

        private void Folder_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Copy;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            pictureBox1.Invalidate();
        }

        private void BoxChanged(object sender, EventArgs e) {
            //pictureBox1.Invalidate();
            EffectEdited = true;
        }
    }
}
