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
        private bool _loading = true;

        private Item currentItem = null;

        public ItemEditor() {
            InitializeComponent();
            CreateNew();

            LoadItemList();
        }

        private void LoadItemList() {
            TreeNode node = treeItemHeirachy.Nodes.Add("TempAllItems");

            foreach (Item i in ItemDatabase.Items) {
                TreeNode n = new TreeNode(i.Name);
                n.Tag = i.ID;

                node.Nodes.Add(n);
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
            } else {
                ItemDatabase.UpdatedItem(currentItem);
            }
        }

        private void ResetForm() {
            _loading = true;

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

            _loading = false;
        }

        private void pbItemIcon_Click(object sender, EventArgs e) {
            if (!Directory.Exists("Icons")) Directory.CreateDirectory("Icons");

            ImageSelector _is = new ImageSelector(NewIconSelected, Directory.GetFiles("Icons", "*.png"));
            _is.Show(this);
        }

        internal int NewIconSelected(string iconname) {
            Edited();

            if (File.Exists(iconname)) {
                pbItemIcon.LoadAsync(iconname);
            }

            return 0;
        }

        private void Edited() {
            _iE = true;
        }

        private void ItemEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (_iE) { //If internal edit
                Save();
                ItemDatabase.SaveDatabase();
            }
        }

        private void FormEdited(object sender, EventArgs e) {
            if (_loading) return;
            Edited();
        }

        private void treeItemHeirachy_AfterSelect(object sender, TreeViewEventArgs e) {
            if (treeItemHeirachy.SelectedNode.Parent != null) {
                ShowItem(short.Parse(treeItemHeirachy.SelectedNode.Tag.ToString()));
            }
        }

        private void numMonetaryValue_KeyUp(object sender, KeyEventArgs e) {
            try {
                numMonetaryBuy.Value = (Decimal)(int)(1.50M * numMonetaryValue.Value);
            } catch {
                numMonetaryBuy.Value = 1M;
            }

            try {
                numMonetarySell.Value = (Decimal)(int)(0.75M * numMonetaryValue.Value);
            } catch {
                numMonetarySell.Value = 1M;
            }

            if (_loading) return;
            Edited();
        }

        private void numValue2_ValueChanged(object sender, KeyEventArgs e) {
            numMonetaryValue.Value = numMonetaryBuy.Value / 1.5M;

            if (_loading) return;
            Edited();
        }
    }
}
