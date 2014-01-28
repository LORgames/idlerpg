using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Scripting.Extensions;
using ToolCache.Scripting.Types;
using System.Windows.Forms;

namespace EngineDebugger {
    public class VariableDebugHelper {
        public static List<int> IntVarValues;
        public static List<String> StrVarValues;

        public static void BuildForm(DebugForm form) {
            foreach (KeyValuePair<String, ScriptVariable> kvp in Variables.GlobalVariables) {
                ListViewItem lvi = new ListViewItem(kvp.Value.Index.ToString());
                lvi.SubItems.Add("Int");
                lvi.SubItems.Add(kvp.Key);
                lvi.SubItems.Add(kvp.Value.InitialValue.ToString());
                lvi.SubItems.Add(kvp.Value.InitialValue.ToString());
                lvi.Tag = kvp.Value;
                form.lstVariables.Items.Add(lvi);
            }

            foreach (KeyValuePair<String, StringVariable> kvp in Variables.StringVariables) {
                ListViewItem lvi = new ListViewItem(kvp.Value.Index.ToString());
                lvi.SubItems.Add("String");
                lvi.SubItems.Add(kvp.Key);
                lvi.SubItems.Add(kvp.Value.InitialValue);
                lvi.SubItems.Add(kvp.Value.InitialValue);
                lvi.Tag = kvp.Value;
                form.lstVariables.Items.Add(lvi);
            }
        }

        public static void RebuildForm(DebugForm form) {
            foreach (ListViewItem lvi in form.lstVariables.Items) {
                if (lvi.Tag is ScriptVariable) {
                    lvi.SubItems[4].Text = IntVarValues[(lvi.Tag as ScriptVariable).Index].ToString();
                } else if (lvi.Tag is StringVariable) {
                    lvi.SubItems[4].Text = StrVarValues[(lvi.Tag as StringVariable).Index];
                }
            }
        }
    }
}
