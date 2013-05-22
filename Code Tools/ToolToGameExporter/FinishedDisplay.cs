using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolToGameExporter {
    public partial class FinishedDisplay : Form {
        public FinishedDisplay(string message, List<ProcessingError> errors) {
            InitializeComponent();

            lblDisplay.Text = message;

            foreach (ProcessingError error in errors) {
                listView1.Items.Add(error.GetAsListViewItem());
            }
        }
    }
}
