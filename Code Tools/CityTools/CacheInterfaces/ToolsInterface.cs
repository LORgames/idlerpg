using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CityTools.CacheInterfaces {
    public class ToolsInterface {
        public static void Initialize() {
            MainWindow.instance.btnExport.Click += new EventHandler(btnExport_Click);
            MainWindow.instance.btnCritterEditor.Click += new EventHandler(btnCritterEditor_Click);
            MainWindow.instance.btnElementalEditor.Click += new EventHandler(btnElementalEditor_Click);
            MainWindow.instance.btnEquipmentEditor.Click += new EventHandler(btnEquipmentEditor_Click);
            MainWindow.instance.btnItemEditor.Click += new EventHandler(btnItemEditor_Click);
            MainWindow.instance.btnObjectEditor.Click += new EventHandler(btnObjectEditor_Click);
            MainWindow.instance.btnSoundEditor.Click += new EventHandler(btnSoundEditor_Click);
            MainWindow.instance.btnTileEditorTool.Click += new EventHandler(btnTileEditorTool_Click);
            MainWindow.instance.btnWorldEditor.Click += new EventHandler(btnWorldEditor_Click);
        }

        public static bool ProcessKeys(Keys keyData) {
            if (keyData == Keys.F5) {
                ExportAndRun(); return true;
            } else if (keyData == Keys.T) {
                OpenTileEditor(); return true;
            } else if (keyData == Keys.O) {
                OpenTemplateEditor(); return true;
            } else if (keyData == Keys.R) {
                OpenElementEditor(); return true;
            } else if (keyData == Keys.I) {
                OpenItemEditor(); return true;
            } else if (keyData == Keys.U) {
                OpenEquipmentEditor(); return true;
            } else if (keyData == Keys.C) {
                OpenCritterEditor(); return true;
            } else if (keyData == Keys.Z) {
                OpenSoundEditor(); return true;
            } else if (keyData == Keys.X) {
                OpenWorldEditor(); return true;
            }

            return false;
        }

        private static void OpenTileEditor() {
            TileEditor t = new TileEditor();
            t.ShowDialog(MainWindow.instance);
            TileInterface.ReloadAll();
        }

        private static void OpenTemplateEditor() {
            TemplateEditor t = new TemplateEditor();
            t.OnSave += new TemplateEditor.SaveEventHandler(MainWindow.instance.ObjectTemplateSaved);
            t.ShowDialog(MainWindow.instance);
            ObjectInterface.ReloadAll();
        }

        private static void OpenElementEditor() {
            ElementEditor t = new ElementEditor();
            t.ShowDialog(MainWindow.instance);
        }

        private static void OpenEquipmentEditor() {
            EquipmentEditor t = new EquipmentEditor();
            t.ShowDialog(MainWindow.instance);
        }

        private static void OpenItemEditor() {
            ItemEditor t = new ItemEditor();
            t.ShowDialog(MainWindow.instance);
        }

        private static void OpenCritterEditor() {
            CritterEditor t = new CritterEditor();
            t.ShowDialog(MainWindow.instance);
        }

        private static void OpenSoundEditor() {
            SoundEditor t = new SoundEditor();
            t.ShowDialog(MainWindow.instance);
            SoundInterface.PopulateList();
        }

        internal static void OpenWorldEditor() {
            WorldEditor t = new WorldEditor();
            t.ShowDialog(MainWindow.instance);
        }

        private static void ExportAndRun() {
            string args = "map=" + MapPieceCache.CurrentPiece.Name;

            //try {
                if (ToolToGameExporter.Processor.Go("Build/Data/", true)) {
                    if (File.Exists("./Build/iRPG.exe")) {
                        Process p = Process.Start(Path.GetFullPath("./Build/iRPG.exe"), args);
                        p.WaitForExit();
                    } else {
                        MessageBox.Show("Cannot find build.");
                    }
                } else {
                    MessageBox.Show("Could not export data. Skipping running the build.");
                }
            //} catch {
            //    MessageBox.Show("Could not run the build. No idea why.\n\nSuggestions:\n1. Double check you have AIR3.7.\n2. Double check you don't already have the game open.\n\nIf problems continue, let Paul know and he'll look deeper.");
            //}
        }

        private static void btnTileEditorTool_Click(object sender, EventArgs e) {
            OpenTileEditor();
        }

        private static void btnObjectEditor_Click(object sender, EventArgs e) {
            OpenTemplateEditor();
        }

        private static void btnElementalEditor_Click(object sender, EventArgs e) {
            OpenElementEditor();
        }

        private static void btnItemEditor_Click(object sender, EventArgs e) {
            OpenItemEditor();
        }

        private static void btnEquipmentEditor_Click(object sender, EventArgs e) {
            OpenEquipmentEditor();
        }

        private static void btnCritterEditor_Click(object sender, EventArgs e) {
            OpenCritterEditor();
        }

        private static void btnExport_Click(object sender, EventArgs e) {
            ExportAndRun();
        }

        private static void btnSoundEditor_Click(object sender, EventArgs e) {
            OpenSoundEditor();
        }

        private static void btnWorldEditor_Click(object sender, EventArgs e) {
            OpenWorldEditor();
        }
    }
}
