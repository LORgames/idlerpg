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

        private void entityEditor2_Load(object sender, EventArgs e) {

        }

        private void btnFight_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Left) {
                FightSimulator.SimulateFight(entityEditor1.I, entityEditor2.I, txtOutcome);
            } if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                int e1 = 0;
                int e2 = 0;
                int tie = 0;

                for (int i = 0; i < 100; i++) {
                    FightSimulator.SimulateFight(entityEditor1.I, entityEditor2.I, txtOutcome);

                    if (entityEditor1.I.sim_CurrentHP <= 0 && entityEditor2.I.sim_CurrentHP <= 0) {
                        tie++;
                    } else if (entityEditor1.I.sim_CurrentHP <= 0) {
                        e2++;
                    } else {
                        e1++;
                    }
                }

                MessageBox.Show("Played 100 rounds:\n\n" + entityEditor1.I.Name + " Wins: " + e1 + "\n" + entityEditor2.I.Name + " wins: " + e2 + "\nTies: " + tie);
            }
        }
    }
}
