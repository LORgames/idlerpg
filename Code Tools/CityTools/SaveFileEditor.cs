using System;
using System.Drawing;
using System.Windows.Forms;
using ToolCache.SaveSystem;
using ToolCache.Equipment;
using ToolCache.Drawing;

namespace CityTools {
    public partial class SaveFileEditor : Form {
        private SaveInfo currentInfo;
        private bool isEdited = false;
        private bool isUpdating = false;
        
        public SaveFileEditor() {
            InitializeComponent();
            listAllSaves.DataSource = SaveManager.Saves;
            FillEquipmentSets();

            UpdateEnabled(false);
        }

        private void FillEquipmentSets() {
            foreach (EquipmentItem ei in EquipmentManager.TypeLists[EquipmentTypes.Shadow]) cbEquipmentShadow.Items.Add(ei);
            foreach (EquipmentItem ei in EquipmentManager.TypeLists[EquipmentTypes.Legs]) cbEquipmentPants.Items.Add(ei);
            foreach (EquipmentItem ei in EquipmentManager.TypeLists[EquipmentTypes.Body]) cbEquipmentBody.Items.Add(ei);
            foreach (EquipmentItem ei in EquipmentManager.TypeLists[EquipmentTypes.Head]) cbEquipmentFace.Items.Add(ei);
            foreach (EquipmentItem ei in EquipmentManager.TypeLists[EquipmentTypes.Headgear]) cbEquipmentHeadgear.Items.Add(ei);
            foreach (EquipmentItem ei in EquipmentManager.TypeLists[EquipmentTypes.Weapon]) cbEquipmentWeapon.Items.Add(ei);
        }

        private void btnSelectSlotClicked(object sender, EventArgs e) {
            int slot = int.Parse(((Button)sender).Text.Substring(((Button)sender).Text.Length - 2));
            if (currentInfo != null) {
                //TODO: Implement slots
                MessageBox.Show("Not implemented yet.");
            }
        }

        private void Edited(object sender, EventArgs e) {
            if (isUpdating) return;

            pbDisplay.Invalidate();
            isEdited = true;
        }

        private void pbDisplay_Paint(object sender, PaintEventArgs e) {
            EquipmentItem shadow = (EquipmentItem)cbEquipmentShadow.SelectedItem;
            EquipmentItem body = (EquipmentItem)cbEquipmentBody.SelectedItem;
            EquipmentItem face = (EquipmentItem)cbEquipmentFace.SelectedItem;
            EquipmentItem pants = (EquipmentItem)cbEquipmentPants.SelectedItem;
            EquipmentItem weapon = (EquipmentItem)cbEquipmentWeapon.SelectedItem;
            EquipmentItem head = (EquipmentItem)cbEquipmentHeadgear.SelectedItem;

            PersonDrawer.Draw(e.Graphics, new Point(1 * e.ClipRectangle.Width / 5, e.ClipRectangle.Height - 20), Direction.Left, shadow, head, face, body, pants, weapon, false);
            PersonDrawer.Draw(e.Graphics, new Point(2 * e.ClipRectangle.Width / 5, e.ClipRectangle.Height - 20), Direction.Up, shadow, head, face, body, pants, weapon, false);
            PersonDrawer.Draw(e.Graphics, new Point(3 * e.ClipRectangle.Width / 5, e.ClipRectangle.Height - 20), Direction.Right, shadow, head, face, body, pants, weapon, false);
            PersonDrawer.Draw(e.Graphics, new Point(4 * e.ClipRectangle.Width / 5, e.ClipRectangle.Height - 20), Direction.Down, shadow, head, face, body, pants, weapon, false);
        }

        private void listAllSaves_SelectedIndexChanged(object sender, EventArgs e) {
            SaveIfRequired();

            isUpdating = true;

            if (listAllSaves.SelectedItems.Count == 1) {
                currentInfo = (SaveInfo)listAllSaves.SelectedItem;
                UpdateEnabled(true);
            } else {
                UpdateEnabled(false);
            }

            UpdateForm();

            isUpdating = false;
        }

        private void UpdateForm() {
            if (currentInfo != null) {
                txtCharName.Text = currentInfo.name;
                txtCharTitle.Text = currentInfo.title;
                numCharExperience.Value = currentInfo.experienceAmount;

                cbEquipmentShadow.SelectedItem = EquipmentManager.Get(currentInfo.shadow);
                cbEquipmentPants.SelectedItem = EquipmentManager.Get(currentInfo.legs);
                cbEquipmentBody.SelectedItem = EquipmentManager.Get(currentInfo.body);
                cbEquipmentFace.SelectedItem = EquipmentManager.Get(currentInfo.face);
                cbEquipmentHeadgear.SelectedItem = EquipmentManager.Get(currentInfo.headgear);
                cbEquipmentWeapon.SelectedItem = EquipmentManager.Get(currentInfo.weapon);

                pbDisplay.Invalidate();
            }
        }

        private void SaveIfRequired() {
            if (currentInfo != null && isEdited) {
                currentInfo.name = txtCharName.Text;
                currentInfo.title = txtCharTitle.Text;
                currentInfo.experienceAmount = (uint)numCharExperience.Value;

                currentInfo.shadow = cbEquipmentShadow.Text;
                currentInfo.legs = cbEquipmentPants.Text;
                currentInfo.body = cbEquipmentBody.Text;
                currentInfo.face = cbEquipmentFace.Text;
                currentInfo.headgear = cbEquipmentHeadgear.Text;
                currentInfo.weapon = cbEquipmentWeapon.Text;

                currentInfo.Save();
            }

            isEdited = false;
        }

        private void UpdateEnabled(bool newState) {
            tabControl1.Enabled = newState;
            txtCharName.Enabled = newState;
            txtCharTitle.Enabled = newState;
            numCharExperience.Enabled = newState;
            btnSetSlot0.Enabled = newState;
            btnSetSlot1.Enabled = newState;
            btnSetSlot2.Enabled = newState;
            btnSetSlot3.Enabled = newState;
        }

        private void btnDeleteSelectedSaves_Click(object sender, EventArgs e) {
            foreach (SaveInfo x in listAllSaves.SelectedItems) {
                if (x.IsDefault()) {
                    SaveManager.Saves.Remove(x);
                }
            }
        }

        private void btnCreateNewSave_Click(object sender, EventArgs e) {
            SaveManager.Saves.Add(new SaveInfo());
        }

        private void SaveFileEditor_FormClosing(object sender, FormClosingEventArgs e) {
            SaveIfRequired();
        }
    }
}
