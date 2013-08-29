using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Critters;

namespace CityTools {
    public partial class FactionEditor : Form {
        private Boolean isEdited = false;
        private Boolean isEditing = false;

        public FactionEditor() {
            InitializeComponent();
            AddExistingFactions();

            lstFaction2.SmallImageList = new ImageList();
            lstFaction2.SmallImageList.Images.Add(Properties.Resources.Factions_Neutral);
            lstFaction2.SmallImageList.Images.Add(Properties.Resources.Factions_Friends);
            lstFaction2.SmallImageList.Images.Add(Properties.Resources.Factions_Enemies);
        }

        private void AddExistingFactions() {
            foreach (String s in Factions.FactionNames()) {
                AddItem(s);
            }
        }

        private void AddItem(string s) {
            lstFaction1.Items.Add(s);
            lstFaction2.Items.Add(new ListViewItem(s, 0));
            cbDeleteItem.Items.Add(s);
        }

        private void btnAddFaction_Click(object sender, EventArgs e) {
            if (!Factions.Has(txtNameNewFaction.Text)) {
                Factions.AddFaction(txtNameNewFaction.Text);
                AddItem(txtNameNewFaction.Text);
                txtNameNewFaction.Text = "";
                isEdited = true;
            } else {
                MessageBox.Show("A faction by that name already exists!");
            }
        }

        private void btnFactionDelete_Click(object sender, EventArgs e) {
            Factions.RemoveFaction(cbDeleteItem.SelectedItem.ToString());
            isEdited = true;

            //TODO: Remove the item from the lst's and the cb's
        }

        private void ChangedSelectedFaction(object sender, EventArgs e) {
            string faction1 = lstFaction1.SelectedItem==null?"":lstFaction1.SelectedItem.ToString();
            string faction2 = (lstFaction2.SelectedItems.Count != 1)?"":lstFaction2.SelectedItems[0].Text;

            isEditing = false;

            if (faction1 != "" && faction2 != "" && faction1 != faction2) {
                cbFactionAllegiance.Enabled = true;
                cbFactionAllegiance.SelectedIndex = Factions.GetRelationship(faction1, faction2);
                isEditing = true;
            } else {
                cbFactionAllegiance.Enabled = false;
            }

            if (sender == lstFaction1) {
                UpdateIcons();
            }
        }

        private void UpdateIcons() {
            string faction1 = lstFaction1.SelectedItem==null?"":lstFaction1.SelectedItem.ToString();

            if(faction1 != "") {
                foreach (ListViewItem lvi in lstFaction2.Items) {
                    lvi.ImageIndex = Factions.GetRelationship(faction1, lvi.Text);
                }
            }
        }

        private void FactionEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (isEdited) {
                Factions.SaveDatabase();
            }
        }

        private void cbFactionAllegiance_SelectedIndexChanged(object sender, EventArgs e) {
            if (isEditing) {
                string faction1 = lstFaction1.SelectedItem==null?"":lstFaction1.SelectedItem.ToString();
                string faction2 = (lstFaction2.SelectedItems.Count != 1)?"":lstFaction2.SelectedItems[0].Text;

                if (faction1 != "" && faction2 != "" && faction1 != faction2) {
                    isEdited = true;
                    Factions.SetRelationship(faction1, faction2, cbFactionAllegiance.SelectedIndex);
                    lstFaction2.SelectedItems[0].ImageIndex = cbFactionAllegiance.SelectedIndex;
                }
            }
        }
    }
}
