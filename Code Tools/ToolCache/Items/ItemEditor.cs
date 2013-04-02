using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.GeneralForms;
using System.IO;

namespace ToolCache.Items {
    public partial class ItemEditor : Form {
        private bool _iE = false;
        private bool _new = false;

        private Item currentItem = null;

        public ItemEditor() {
            InitializeComponent();
            CreateNew();

            LoadItemList();
        }

        private void LoadItemList() {
            TreeNode node = treeItemHeirachy.Nodes.Add("TempAllItems");

            foreach (Item i in ItemDatabase.Items) {
                treeItemHeirachy.Nodes.Add(i.ID + "| " + i.Name);
            }
        }

        private void CreateNew() {
            if (_iE) Save(); //Edited so save now

            _new = true;
            currentItem = new Item();
            currentItem.ID = ItemDatabase.NextItemID;
            ResetForm();
        }

        private void ShowItem(short itemID) {
            if (_iE) Save(); //Edited so save now

            _new = false;
            currentItem = ItemDatabase.Get(itemID);
            ResetForm();
        }

        private void Save() {
            if (pbItemIcon.Image != null) {
                currentItem.IconName = pbItemIcon.ImageLocation;
            } else {
                currentItem.IconName = "";
            }

            currentItem.Category = cbCategory.Text;
            currentItem.Name = txtName.Text;
            currentItem.Rarity = (byte)cbRarity.SelectedIndex;

            currentItem.Value = (int)numMonetaryValue.Value;
            currentItem.BuyPrice = (int)numMonetaryBuy.Value;
            currentItem.SellPrice = (int)numMonetarySell.Value;

            currentItem.MaxInStack = (short)numStackSize.Value;

            //TODO: Implement effects

            currentItem.Description = txtDescription.Text;

            if (_new) {
                ItemDatabase.AddItem(currentItem);
                _new = false;
            }
        }

        private void ResetForm() {
            txtItemID.Text = currentItem.ID.ToString();

            if(File.Exists(currentItem.IconName)) {
                pbItemIcon.Image = null;
                pbItemIcon.LoadAsync(currentItem.IconName);
            } else {
                pbItemIcon.Image = null;
                pbItemIcon.Invalidate();
            }

            cbCategory.Text = currentItem.Category;
            txtName.Text = currentItem.Name;
            cbRarity.SelectedIndex = currentItem.Rarity;

            numMonetaryValue.Value = (decimal)currentItem.Value;
            numMonetaryBuy.Value = (decimal)currentItem.BuyPrice;
            numMonetarySell.Value = (decimal)currentItem.SellPrice;

            numStackSize.Value = (decimal)currentItem.MaxInStack;

            //TODO: Implement effects

            txtDescription.Text = currentItem.Description;
        }

        private void pbItemIcon_Click(object sender, EventArgs e) {
            if (!Directory.Exists("Icons")) Directory.CreateDirectory("Icons");

            ImageSelector _is = new ImageSelector(NewIconSelected, Directory.GetFiles("Icons", "*.png"));
            _is.Show(this);
        }

        internal int NewIconSelected(string iconname) {
            return 0;
        }

        private void numMonetaryValue_ValueChanged(object sender, EventArgs e) {
            numMonetaryBuy.Value = 1.50M * numMonetaryValue.Value;
            numMonetaryBuy.Value = 0.75M * numMonetaryValue.Value;
            Edited();
        }

        private void Edited() {
            _iE = true;
        }

        private void numValue2_ValueChanged(object sender, EventArgs e) {
            numMonetaryValue.Value = numMonetaryBuy.Value / 1.5M;
            Edited();
        }

        private void ItemEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (_iE) { //If internal edit
                Save();
                ItemDatabase.SaveDatabase();
            }
        }
    }
}
