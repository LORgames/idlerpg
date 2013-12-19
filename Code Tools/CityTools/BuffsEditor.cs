using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Critters;
using ToolCache.UI;

namespace CityTools {
    public partial class BuffsEditor : Form {

        private Buff CurrentBuff = null;
        private bool isChanging = false;
        private bool hasChanged = false;

        public BuffsEditor() {
            InitializeComponent();
            listBuffs.DataSource = BuffManager.Buffs;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            Buff b = new Buff();
            BuffManager.Buffs.Add(b);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            List<Buff> toDelete = new List<Buff>();

            for (int i = 0; i < listBuffs.SelectedItems.Count; i++) {
                toDelete.Add(listBuffs.SelectedItems[i] as Buff);
            }

            for (int i = 0; i < toDelete.Count; i++) {
                BuffManager.Buffs.Remove(toDelete[i]);
            }

            toDelete.Clear();
        }

        private void btnDuplicate_Click(object sender, EventArgs e) {
            if (listBuffs.SelectedItem != null) {
                Buff b = (listBuffs.SelectedItem as Buff);
                Buff b2 = b.Clone();
                BuffManager.Buffs.Add(b2);
            }
        }

        private void listBuffs_SelectedIndexChanged(object sender, EventArgs e) {
            isChanging = true;
            if (CurrentBuff != null) UpdateCurrentFromForm();
            if (listBuffs.SelectedItem != null) {
                CurrentBuff = (listBuffs.SelectedItem as Buff);
                UpdateFormFromCurrent();
            } else {
                CurrentBuff = null;
                ClearForm();
            }
            isChanging = false;
        }

        private void ClearForm() {
            txtName.Text = "";
            numIconID.Value = 0;
            ckbIsDebuff.Checked = false;
            numDuration.Value = 0;
            scriptBox1.Script = "";
            pbIconDisplay.Load("");
        }

        private void UpdateCurrentFromForm() {
            if (CurrentBuff == null) return;
            if (!hasChanged) return;
            CurrentBuff.Name = txtName.Text;
            CurrentBuff.IconID = (short)numIconID.Value;
            CurrentBuff.isDebuff = ckbIsDebuff.Checked;
            CurrentBuff.showsIcon = ckbShowIcon.Checked;
            CurrentBuff.Duration = (float)numDuration.Value;
            CurrentBuff.Script = scriptBox1.Script;
            hasChanged = false;

            int itemID = listBuffs.Items.IndexOf(CurrentBuff);
        }

        private void UpdateFormFromCurrent() {
            if (CurrentBuff == null) return;
            txtName.Text = CurrentBuff.Name;
            numIconID.Value = CurrentBuff.IconID;
            ckbIsDebuff.Checked = CurrentBuff.isDebuff;
            ckbShowIcon.Checked = CurrentBuff.showsIcon;
            numDuration.Value = (decimal)CurrentBuff.Duration;
            scriptBox1.Script = CurrentBuff.Script;

            RedrawIcon();

            hasChanged = false;
        }

        private void BuffsEditor_FormClosing(object sender, FormClosingEventArgs e) {
            UpdateCurrentFromForm();
            BuffManager.SaveDatabase();
        }

        private void ValueChanged(object sender, EventArgs e) {
            if (isChanging) return;
            hasChanged = true;

            if (sender == numIconID || sender == ckbShowIcon) {
                RedrawIcon();
            }
        }

        private void RedrawIcon() {
            if (ckbShowIcon.Checked) {
                int x = (int)numIconID.Value;
                if (UIManager.GetLibrary("Buff Icons") != null && UIManager.GetLibrary("Buff Icons").Images.Count > x && x > -1) {
                    pbIconDisplay.Load(UIManager.GetLibrary("Buff Icons").Images[x]);
                }
            } else {
                pbIconDisplay.Image = null;
            }
        }
    }
}
