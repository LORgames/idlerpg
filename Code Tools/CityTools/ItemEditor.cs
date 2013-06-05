using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ToolCache.Items;

namespace CityTools {
    public partial class ItemEditor : Form {
        private bool _iE = false;
        private bool _new = false;
        private bool _loading = true;

        private Item currentItem = null;

        private Dictionary<string, TreeNode> categories = new Dictionary<string, TreeNode>();
        private List<string> LoadedImageListIndices = new List<string>(); 

        public ItemEditor() {
            InitializeComponent();

            if (!Directory.Exists("Icons")) Directory.CreateDirectory("Icons");

            txtConsumeEffect.Setup(ToolCache.Scripting.ScriptTypes.Item);

            CreateNew();
            LoadItemList();
        }

        private void LoadItemList() {
            treeItemHeirachy.SuspendLayout();

            treeItemHeirachy.ImageList = new ImageList();

            foreach(String s in Directory.GetFiles("Icons", "*.png")) {
                treeItemHeirachy.ImageList.Images.Add(Image.FromFile(s));
                LoadedImageListIndices.Add(s);
            }

            foreach (String c in ItemDatabase.Categories) {
                if (!categories.ContainsKey(c)) {
                    categories.Add(c, new TreeNode(c));
                    treeItemHeirachy.Nodes.Add(categories[c]);
                }
            }

            foreach (Item i in ItemDatabase.Items) {
                TreeNode n = new TreeNode(i.Name);
                n.Tag = i.ID;

                if (File.Exists(i.IconName)) {
                    n.ImageIndex = LoadedImageListIndices.IndexOf(i.IconName);
                    n.SelectedImageIndex = n.ImageIndex;
                }

                if (!categories.ContainsKey(i.Category)) {
                    categories.Add(i.Category, new TreeNode(i.Category));
                    treeItemHeirachy.Nodes.Add(categories[i.Category]);
                }

                categories[i.Category].Nodes.Add(n);
            }

            treeItemHeirachy.ResumeLayout();
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

            currentItem.ConsumeEffect = txtConsumeEffect.Text;

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

            txtConsumeEffect.Text = currentItem.ConsumeEffect;
            numStackSize.Value = (decimal)currentItem.MaxInStack;

            txtDescription.Text = currentItem.Description;

            _loading = false;
        }

        private void pbItemIcon_Click(object sender, EventArgs e) {
            ImageSelector _is = new ImageSelector(NewIconSelected, Directory.GetFiles("Icons", "*.png"), "Icons");
            _is.Show(this);
        }

        internal int NewIconSelected(string iconname) {
            Edited();

            if (File.Exists(iconname)) {
                pbItemIcon.LoadAsync(iconname);

                if (LoadedImageListIndices.Contains(iconname)) {
                    treeItemHeirachy.ImageList.Images.Add(Image.FromFile(iconname));
                    LoadedImageListIndices.Add(iconname);
                }
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

        private void numMonetaryValue_KeyUp(object sender, EventArgs e) {
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

        private void numValue2_ValueChanged(object sender, EventArgs e) {
            numMonetaryValue.Value = numMonetaryBuy.Value / 1.5M;

            if (_loading) return;
            Edited();
        }

        private void btnAddItem_Click(object sender, EventArgs e) {
            CreateNew();
        }

        private void btnDuplicateItem_Click(object sender, EventArgs e) {
            MessageBox.Show("Trolled! This button doesn't do anything!");
        }
    }
}
