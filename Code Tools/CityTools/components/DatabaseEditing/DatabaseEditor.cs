using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.DataLibrary;

namespace CityTools.Components.DatabaseEditing {
    public partial class DatabaseEditor : UserControl {
        public DatabaseEditor() {
            InitializeComponent();

            txtNewDatabaseName.KeyDown += new KeyEventHandler(txtNewDatabaseName_KeyDown);
        }

        public void txtNewDatabaseName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                string newDatabaseName = txtNewDatabaseName.Text.Trim();
                DBLibraryManager.AddLibrary(newDatabaseName);
            }
        }


    }
}
