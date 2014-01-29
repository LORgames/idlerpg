using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Scripting.Extensions;
using ToolCache.Scripting.Types;
using System.Windows.Forms;

namespace EngineDebugger {
    public class VariableDebugHelper {
        public static List<int> IntVarValues = new List<int>();
        public static List<String> StrVarValues = new List<string>();
        private static List<ListViewItem> lvis = new List<ListViewItem>();

        private delegate void UpdateLVISubItem(DebugForm form, ListViewItem lvi, int itemIndex, string newText);
        private static void ULSI(DebugForm form, ListViewItem lvi, int index, string txt) {
            if (form.InvokeRequired) {
                UpdateLVISubItem ulsii = new UpdateLVISubItem(ULSI);
                form.Invoke(ulsii, new object[] { form, lvi, index, txt });
            } else {
                lvi.SubItems[index].Text = txt;
            }
        }

        public static void BuildForm(DebugForm form) {
            foreach (KeyValuePair<String, ScriptVariable> kvp in Variables.GlobalVariables) {
                ListViewItem lvi = new ListViewItem(kvp.Value.Index.ToString());
                lvi.SubItems.Add("Int");
                lvi.SubItems.Add(kvp.Key);
                lvi.SubItems.Add(kvp.Value.InitialValue.ToString());
                lvi.SubItems.Add(kvp.Value.InitialValue.ToString());
                lvi.Tag = kvp.Value;
                form.lstVariables.Items.Add(lvi);
                lvis.Add(lvi);
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
            foreach (ListViewItem lvi in lvis) {
                if (lvi.Tag is ScriptVariable) {
                    if ((lvi.Tag as ScriptVariable).Index < IntVarValues.Count) {
                        ULSI(form, lvi, 4, IntVarValues[(lvi.Tag as ScriptVariable).Index].ToString());
                    }
                } else if (lvi.Tag is StringVariable) {
                    if (StrVarValues.Count > (lvi.Tag as StringVariable).Index) {
                        ULSI(form, lvi, 4, StrVarValues[(lvi.Tag as ScriptVariable).Index].ToString());
                    }
                }
            }
        }
    }
}
