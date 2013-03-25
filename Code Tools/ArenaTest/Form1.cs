using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArenaTest {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnFight_Click(object sender, EventArgs e) {
            FightSimulator.SimulateFight(entityEditor1.I, entityEditor2.I, txtOutcome);
        }

        private void entityEditor2_Load(object sender, EventArgs e) {

        }
    }
}
