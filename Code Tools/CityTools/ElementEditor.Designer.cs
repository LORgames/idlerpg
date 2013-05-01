namespace CityTools {
    partial class ElementEditor {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblElementAddName = new System.Windows.Forms.ToolStripLabel();
            this.txtElementAddName = new System.Windows.Forms.ToolStripTextBox();
            this.btnElementAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDeleteElement = new System.Windows.Forms.ToolStripLabel();
            this.cbElementDeleteName = new System.Windows.Forms.ToolStripComboBox();
            this.btnElementDelete = new System.Windows.Forms.ToolStripButton();
            this.dgvElements = new System.Windows.Forms.DataGridView();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRedraw = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblElementAddName,
            this.txtElementAddName,
            this.btnElementAdd,
            this.toolStripSeparator1,
            this.lblDeleteElement,
            this.cbElementDeleteName,
            this.btnElementDelete,
            this.toolStripSeparator2,
            this.btnRedraw});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(638, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblElementAddName
            // 
            this.lblElementAddName.Name = "lblElementAddName";
            this.lblElementAddName.Size = new System.Drawing.Size(78, 22);
            this.lblElementAddName.Text = "Add Element:";
            // 
            // txtElementAddName
            // 
            this.txtElementAddName.Name = "txtElementAddName";
            this.txtElementAddName.Size = new System.Drawing.Size(100, 25);
            // 
            // btnElementAdd
            // 
            this.btnElementAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnElementAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnElementAdd.Image")));
            this.btnElementAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnElementAdd.Name = "btnElementAdd";
            this.btnElementAdd.Size = new System.Drawing.Size(33, 22);
            this.btnElementAdd.Text = "Add";
            this.btnElementAdd.Click += new System.EventHandler(this.btnElementAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // lblDeleteElement
            // 
            this.lblDeleteElement.Name = "lblDeleteElement";
            this.lblDeleteElement.Size = new System.Drawing.Size(89, 22);
            this.lblDeleteElement.Text = "Delete Element:";
            // 
            // cbElementDeleteName
            // 
            this.cbElementDeleteName.Name = "cbElementDeleteName";
            this.cbElementDeleteName.Size = new System.Drawing.Size(121, 25);
            // 
            // btnElementDelete
            // 
            this.btnElementDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnElementDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnElementDelete.Image")));
            this.btnElementDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnElementDelete.Name = "btnElementDelete";
            this.btnElementDelete.Size = new System.Drawing.Size(44, 22);
            this.btnElementDelete.Text = "Delete";
            this.btnElementDelete.Click += new System.EventHandler(this.btnElementDelete_Click);
            // 
            // dgvElements
            // 
            this.dgvElements.AllowUserToAddRows = false;
            this.dgvElements.AllowUserToDeleteRows = false;
            this.dgvElements.AllowUserToResizeColumns = false;
            this.dgvElements.AllowUserToResizeRows = false;
            this.dgvElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvElements.Location = new System.Drawing.Point(0, 25);
            this.dgvElements.Name = "dgvElements";
            this.dgvElements.Size = new System.Drawing.Size(638, 423);
            this.dgvElements.TabIndex = 0;
            this.dgvElements.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElements_CellValueChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRedraw
            // 
            this.btnRedraw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRedraw.Image = ((System.Drawing.Image)(resources.GetObject("btnRedraw.Image")));
            this.btnRedraw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(50, 22);
            this.btnRedraw.Text = "Refresh";
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // ElementEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 448);
            this.Controls.Add(this.dgvElements);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ElementEditor";
            this.Text = "Element Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElementEditor_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvElements;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblElementAddName;
        private System.Windows.Forms.ToolStripTextBox txtElementAddName;
        private System.Windows.Forms.ToolStripButton btnElementAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblDeleteElement;
        private System.Windows.Forms.ToolStripComboBox cbElementDeleteName;
        private System.Windows.Forms.ToolStripButton btnElementDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRedraw;
    }
}