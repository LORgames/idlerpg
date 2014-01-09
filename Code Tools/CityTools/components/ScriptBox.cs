using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ToolCache.Scripting;
using ToolCache.Scripting.Types;
using System.Text.RegularExpressions;

namespace CityTools.Components {
    public partial class ScriptBox : UserControl {
        public event EventHandler<ScriptInfoArgs> BeforeParse;
        public event EventHandler<EventArgs> ScriptUpdated;
        private FindAndReplaceDialog findAndReplace;
        private int lastFindIndex = -1;
        private string lastFindText = "";

        //Property for the internal script stuff, this will do formatting and stuff later
        public string Script {
            get {
                return txtScript.Text;
            }
            set {
                if (ScriptType == ScriptTypes.Unknown && value != "") {
                    MessageBox.Show("Warning: ScriptBox is still set to ScriptTypes.Unknown!");
                }
                txtScript.Text = value;
            }
        }

        //Would much rather if text wasn't used, for now it just calls the Script things
        public override string Text { get { return Script; } set { Script = value; } }

        private ScriptTypes _type = ScriptTypes.Unknown;
        public ScriptTypes ScriptType {
            get { return _type; }
            set { _type = value; }
        }

        public ScriptBox() {
            InitializeComponent();

            findAndReplace = new FindAndReplaceDialog();

            //Set the distance for tabs
            txtScript.SelectionTabs = new int[]{20, 40, 60, 80, 100, 120, 140, 160, 180, 200, 220, 240, 260, 280, 300 };
        }

        public void Setup(ScriptTypes newScriptType) {
            ScriptType = newScriptType;
        }

        private void btnParse_Click(object sender, EventArgs e) {
            ScriptInfo info = new ScriptInfo("IParseString", ScriptType);

            if(BeforeParse != null) BeforeParse(this, new ScriptInfoArgs(info));

            Parser.Parse(Script, info);

            string errors = String.Format("{0} Errors.", info.Errors.Count);

            if (info.Errors.Count > 0) {
                errors += "\n";

                foreach (String s in info.Errors) {
                    errors += "\n" + s;
                }
            }

            MessageBox.Show(errors);
        }

        private void txtScript_TextChanged(object sender, EventArgs e) {
            this.OnTextChanged(e);
            if(ScriptUpdated != null) this.ScriptUpdated(this, e);
        }

        private void btnGlobalVariables_Click(object sender, EventArgs e) {
            CacheInterfaces.ToolsInterface.OpenVariableEditor();
        }

        private void txtScript_SelectionChanged(object sender, EventArgs e) {
            lblLineNumber.Text = ""+((txtScript.GetLineFromCharIndex(txtScript.SelectionStart))+1);
        }

        private void txtScript_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.F) {
                findAndReplace.OnFind += new EventHandler(OnFind);
                findAndReplace.OnReplace += new EventHandler(OnReplace);
                findAndReplace.Show();
            }
        }

        private void OnFind(object sender, EventArgs e) {
            if (lastFindText != findAndReplace.Find) {
                lastFindIndex = txtScript.Find(findAndReplace.Find, 0, RichTextBoxFinds.None);
                lastFindText = "";
            } else {
                lastFindIndex = txtScript.Find(findAndReplace.Find, lastFindIndex + findAndReplace.Find.Length, RichTextBoxFinds.None);
            }
            if (lastFindIndex != -1) {
                this.ParentForm.Activate();
                txtScript.Select();
                lastFindText = findAndReplace.Find;
            } else {
                MessageBox.Show("Could not find text");
                lastFindText = "";
            }
        }

        private void OnReplace(object sender, EventArgs e) {
            txtScript.Text = txtScript.Text.Replace(findAndReplace.Find, findAndReplace.Replace);
        }
    }
}