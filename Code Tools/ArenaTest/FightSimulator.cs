using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArenaTest {
    public class FightSimulator {

        public static void SimulateFight(Entity a, Entity b, System.Windows.Forms.RichTextBox output) {
            output.Clear();

            output.AppendText("In the left corner level " + a.Level + " character, " + a.Name + "\n");
            output.AppendText("In the right corner level " + b.Level + " character, " + b.Name + "\n");

            AddRegion(output);

            a.ResetForSimulation();
            b.ResetForSimulation();

            float time = 0;

            while (!a.isDead() && !b.isDead()) {
                float nextTimeout = Math.Min(a.sim_NextTurn, b.sim_NextTurn);
                time += nextTimeout;
                
                a.FastForward(nextTimeout);
                b.FastForward(nextTimeout);

                output.AppendText(a.Process(b));
                output.AppendText(b.Process(a));

                if (time > 120) break;
            }

            AddRegion(output);

            if (a.isDead() && b.isDead()) {
                output.AppendText("The fight was a tie.");
            } else if (a.isDead()) {
                output.AppendText(b.Name + " was the victor!");
            } else {
                output.AppendText(a.Name + " was the victor!");
            }

            output.AppendText("\nFight took " + time + "ms");
        }

        private static void AddRegion(System.Windows.Forms.RichTextBox output) {
            output.AppendText("\n-----------------------------------------------------------------------\n\n");
        }

    }
}
