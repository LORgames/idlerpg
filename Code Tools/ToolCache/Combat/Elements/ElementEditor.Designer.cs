namespace ToolCache.Combat.Elements {
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
            this.dgvElements = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvElements
            // 
            this.dgvElements.AllowUserToResizeColumns = false;
            this.dgvElements.AllowUserToResizeRows = false;
            this.dgvElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvElements.Location = new System.Drawing.Point(0, 0);
            this.dgvElements.Name = "dgvElements";
            this.dgvElements.Size = new System.Drawing.Size(552, 448);
            this.dgvElements.TabIndex = 0;
            this.dgvElements.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElements_CellValueChanged);
            this.dgvElements.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvElements_UserAddedRow);
            // 
            // ElementEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 448);
            this.Controls.Add(this.dgvElements);
            this.Name = "ElementEditor";
            this.Text = "ElementEditor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvElements)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvElements;
    }
}