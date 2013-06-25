namespace ToolToGameExporter {
    partial class ExportProgressForm {
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
            this.lblExportTask = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblExportTask
            // 
            this.lblExportTask.AutoSize = true;
            this.lblExportTask.Location = new System.Drawing.Point(12, 14);
            this.lblExportTask.Name = "lblExportTask";
            this.lblExportTask.Size = new System.Drawing.Size(125, 13);
            this.lblExportTask.TabIndex = 0;
            this.lblExportTask.Text = "Calculating Differences...";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 40);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(347, 23);
            this.progress.TabIndex = 1;
            // 
            // ExportProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 75);
            this.ControlBox = false;
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lblExportTask);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Exporting";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblExportTask;
        internal System.Windows.Forms.ProgressBar progress;

    }
}