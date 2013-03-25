using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArenaTest {
    public partial class EntityEditor : UserControl {
        private Entity gEntity = new Entity();

        public Entity I {
            get {
                UpdateValues();
                return gEntity;
            }
        }

        public EntityEditor(Boolean isLeft) {
            InitializeComponent();

            if (isLeft) {
                txtName.Text = "LEFT";
                txtCharacter.Text = "Attacker";
            } else {
                txtName.Text = "RIGHT";
                txtCharacter.Text = "Defender";
            }

            Governed_ValueChanged(null, null);
        }

        private void EntityEditor_Load(object sender, EventArgs e) {

        }

        private void UpdateValues() {
            //General
            gEntity.Name = txtName.Text;

            //Governed
            gEntity.RawStr = (int)numStr.Value;
            gEntity.RawVit = (int)numVit.Value;
            gEntity.RawAgi = (int)numAgi.Value;
            gEntity.RawDex = (int)numDex.Value;
            gEntity.RawLuk = (int)numLuk.Value;

            //Ungoverned
            gEntity.Defence = (int)numDef.Value;

            //Process things
            gEntity.CalculateLevel();

            //Update this UI
            this.txtLevel.Text = gEntity.Level.ToString();
            this.txtUnused.Text = gEntity.UnusedStats.ToString();

            this.txtPassiveStats.Clear();

            this.txtPassiveStats.AppendText("MaxHP: " + gEntity.MaxHP + "\n");
            this.txtPassiveStats.AppendText("AttackPower: " + gEntity.AttackPower + "\n");
            this.txtPassiveStats.AppendText("HitChance: " + gEntity.HitChance + "\n");

            this.txtPassiveStats.AppendText("CriticalHitChance: " + gEntity.CriticalHitChance + "\n");
            this.txtPassiveStats.AppendText("DodgeChance: " + gEntity.DodgeChance + "\n");
            this.txtPassiveStats.AppendText("AttackSpeed: " + gEntity.AttackSpeed + "\n");
            this.txtPassiveStats.AppendText("Attack Delay: " + gEntity.AttackDelay + "\n");
        }

        private void Governed_ValueChanged(object sender, EventArgs e) {
            UpdateValues();
        }
    }
}
