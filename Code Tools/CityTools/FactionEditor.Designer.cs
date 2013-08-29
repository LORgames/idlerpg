namespace CityTools {
    partial class FactionEditor {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lstFaction1 = new System.Windows.Forms.ListBox();
            this.cbFactionAllegiance = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddFaction = new System.Windows.Forms.Button();
            this.txtNameNewFaction = new System.Windows.Forms.TextBox();
            this.btnFactionDelete = new System.Windows.Forms.Button();
            this.cbDeleteItem = new System.Windows.Forms.ComboBox();
            this.lstFaction2 = new System.Windows.Forms.ListView();
            this.FactionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFaction1
            // 
            this.lstFaction1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFaction1.FormattingEnabled = true;
            this.lstFaction1.Location = new System.Drawing.Point(12, 12);
            this.lstFaction1.Name = "lstFaction1";
            this.lstFaction1.Size = new System.Drawing.Size(200, 251);
            this.lstFaction1.Sorted = true;
            this.lstFaction1.TabIndex = 0;
            this.lstFaction1.SelectedIndexChanged += new System.EventHandler(this.ChangedSelectedFaction);
            // 
            // cbFactionAllegiance
            // 
            this.cbFactionAllegiance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbFactionAllegiance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFactionAllegiance.Enabled = false;
            this.cbFactionAllegiance.FormattingEnabled = true;
            this.cbFactionAllegiance.Items.AddRange(new object[] {
            "Neutral",
            "Friends",
            "Enemies"});
            this.cbFactionAllegiance.Location = new System.Drawing.Point(219, 269);
            this.cbFactionAllegiance.Name = "cbFactionAllegiance";
            this.cbFactionAllegiance.Size = new System.Drawing.Size(200, 21);
            this.cbFactionAllegiance.TabIndex = 2;
            this.cbFactionAllegiance.SelectedIndexChanged += new System.EventHandler(this.cbFactionAllegiance_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAddFaction);
            this.panel1.Controls.Add(this.txtNameNewFaction);
            this.panel1.Controls.Add(this.btnFactionDelete);
            this.panel1.Controls.Add(this.cbDeleteItem);
            this.panel1.Location = new System.Drawing.Point(12, 269);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 60);
            this.panel1.TabIndex = 3;
            // 
            // btnAddFaction
            // 
            this.btnAddFaction.Image = global::CityTools.Properties.Resources.add;
            this.btnAddFaction.Location = new System.Drawing.Point(172, 3);
            this.btnAddFaction.Name = "btnAddFaction";
            this.btnAddFaction.Size = new System.Drawing.Size(23, 23);
            this.btnAddFaction.TabIndex = 3;
            this.btnAddFaction.UseVisualStyleBackColor = true;
            this.btnAddFaction.Click += new System.EventHandler(this.btnAddFaction_Click);
            // 
            // txtNameNewFaction
            // 
            this.txtNameNewFaction.Location = new System.Drawing.Point(3, 3);
            this.txtNameNewFaction.Name = "txtNameNewFaction";
            this.txtNameNewFaction.Size = new System.Drawing.Size(163, 20);
            this.txtNameNewFaction.TabIndex = 2;
            // 
            // btnFactionDelete
            // 
            this.btnFactionDelete.Image = global::CityTools.Properties.Resources.delete;
            this.btnFactionDelete.Location = new System.Drawing.Point(172, 29);
            this.btnFactionDelete.Name = "btnFactionDelete";
            this.btnFactionDelete.Size = new System.Drawing.Size(23, 23);
            this.btnFactionDelete.TabIndex = 1;
            this.btnFactionDelete.UseVisualStyleBackColor = true;
            this.btnFactionDelete.Click += new System.EventHandler(this.btnFactionDelete_Click);
            // 
            // cbDeleteItem
            // 
            this.cbDeleteItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDeleteItem.FormattingEnabled = true;
            this.cbDeleteItem.Location = new System.Drawing.Point(3, 29);
            this.cbDeleteItem.Name = "cbDeleteItem";
            this.cbDeleteItem.Size = new System.Drawing.Size(163, 21);
            this.cbDeleteItem.Sorted = true;
            this.cbDeleteItem.TabIndex = 0;
            // 
            // lstFaction2
            // 
            this.lstFaction2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFaction2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FactionName});
            this.lstFaction2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstFaction2.Location = new System.Drawing.Point(219, 12);
            this.lstFaction2.Name = "lstFaction2";
            this.lstFaction2.ShowGroups = false;
            this.lstFaction2.Size = new System.Drawing.Size(200, 251);
            this.lstFaction2.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstFaction2.TabIndex = 4;
            this.lstFaction2.UseCompatibleStateImageBehavior = false;
            this.lstFaction2.View = System.Windows.Forms.View.Details;
            this.lstFaction2.SelectedIndexChanged += new System.EventHandler(this.ChangedSelectedFaction);
            // 
            // FactionName
            // 
            this.FactionName.Text = "Faction Name";
            this.FactionName.Width = 170;
            // 
            // FactionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 339);
            this.Controls.Add(this.lstFaction2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbFactionAllegiance);
            this.Controls.Add(this.lstFaction1);
            this.Name = "FactionEditor";
            this.Text = "FactionEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FactionEditor_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstFaction1;
        private System.Windows.Forms.ComboBox cbFactionAllegiance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFactionDelete;
        private System.Windows.Forms.ComboBox cbDeleteItem;
        private System.Windows.Forms.ListView lstFaction2;
        private System.Windows.Forms.Button btnAddFaction;
        private System.Windows.Forms.TextBox txtNameNewFaction;
        private System.Windows.Forms.ColumnHeader FactionName;
    }
}