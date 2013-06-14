﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ToolCache.Scripting;

namespace CityTools.Components {
    public partial class ScriptBox : UserControl {
        public event EventHandler<ScriptInfoArgs> BeforeParse;
        public event EventHandler<EventArgs> ScriptUpdated;

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

        private void QuickParseText() {
            if (txtScript.SelectionLength == 0) {
                int x = txtScript.SelectionStart;

                txtScript.SelectAll();
                txtScript.SelectionColor = Color.Black;

                int startPoint = 0;
                int endPoint = 0;

                while (startPoint != -1 && endPoint != -1) {
                    startPoint = txtScript.Text.IndexOf("//", endPoint);
                    if (startPoint == -1) break;

                    endPoint = txtScript.Text.IndexOf("\n", startPoint);

                    if (endPoint != -1) {
                        txtScript.Select(startPoint, endPoint-startPoint);
                    } else {
                        txtScript.Select(startPoint, txtScript.TextLength - startPoint);
                    }

                    txtScript.SelectionColor = Color.Green;
                }

                txtScript.SelectionStart = x;
                txtScript.SelectionLength = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            QuickParseText();
        }
    }
}