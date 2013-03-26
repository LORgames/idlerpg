namespace ArenaTest {
    partial class Form1 {
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
            this.btnFight = new System.Windows.Forms.Button();
            this.txtOutcome = new System.Windows.Forms.RichTextBox();
            entityEditor1 = new EntityEditor(true);
            entityEditor2 = new EntityEditor(false);
            this.SuspendLayout();
            // 
            // btnFight
            // 
            this.btnFight.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFight.Location = new System.Drawing.Point(0, 595);
            this.btnFight.Name = "btnFight";
            this.btnFight.Size = new System.Drawing.Size(878, 23);
            this.btnFight.TabIndex = 3;
            this.btnFight.Text = "Fight!";
            this.btnFight.UseVisualStyleBackColor = true;
            this.btnFight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnFight_MouseUp);
            // 
            // txtOutcome
            // 
            this.txtOutcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutcome.Location = new System.Drawing.Point(211, 0);
            this.txtOutcome.Name = "txtOutcome";
            this.txtOutcome.Size = new System.Drawing.Size(456, 595);
            this.txtOutcome.TabIndex = 4;
            this.txtOutcome.Text = "Set Stats and Choose Fight Below To See Combat Log";
            // 
            // entityEditor1
            // 
            this.entityEditor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.entityEditor1.Dock = System.Windows.Forms.DockStyle.Left;
            this.entityEditor1.Location = new System.Drawing.Point(0, 0);
            this.entityEditor1.Name = "entityEditor1";
            this.entityEditor1.Size = new System.Drawing.Size(211, 595);
            this.entityEditor1.TabIndex = 0;
            // 
            // entityEditor2
            // 
            this.entityEditor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.entityEditor2.Dock = System.Windows.Forms.DockStyle.Right;
            this.entityEditor2.Location = new System.Drawing.Point(667, 0);
            this.entityEditor2.Name = "entityEditor2";
            this.entityEditor2.Size = new System.Drawing.Size(211, 595);
            this.entityEditor2.TabIndex = 1;
            this.entityEditor2.Load += new System.EventHandler(this.entityEditor2_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 618);
            this.Controls.Add(this.txtOutcome);
            this.Controls.Add(this.entityEditor2);
            this.Controls.Add(this.entityEditor1);
            this.Controls.Add(this.btnFight);
            this.Name = "Form1";
            this.Text = "Idle Arena";
            this.ResumeLayout(false);

        }

        #endregion

        private EntityEditor entityEditor1;
        private EntityEditor entityEditor2;
        private System.Windows.Forms.Button btnFight;
        private System.Windows.Forms.RichTextBox txtOutcome;
    }
}

