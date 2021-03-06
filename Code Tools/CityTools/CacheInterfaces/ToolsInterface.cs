﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CityTools.Components;
using ToolCache.SaveSystem;

namespace CityTools.CacheInterfaces {
    public class ToolsInterface {
        private static GlobalVariableEditor gve;

        public static void Initialize() {
            MainWindow.instance.btnExport.ButtonClick += new EventHandler(btnExport_Click);
            MainWindow.instance.btnCritterEditor.Click += new EventHandler(btnCritterEditor_Click);
            MainWindow.instance.btnEquipmentEditor.Click += new EventHandler(btnEquipmentEditor_Click);
            MainWindow.instance.btnItemEditor.Click += new EventHandler(btnItemEditor_Click);
            MainWindow.instance.btnObjectEditor.Click += new EventHandler(btnObjectEditor_Click);
            MainWindow.instance.btnSoundEditor.Click += new EventHandler(btnSoundEditor_Click);
            MainWindow.instance.btnTileEditorTool.Click += new EventHandler(btnTileEditorTool_Click);
            MainWindow.instance.btnWorldEditor.Click += new EventHandler(btnWorldEditor_Click);
            MainWindow.instance.btnShadowTool.Click += new EventHandler(btnShadowTool_Click);
            MainWindow.instance.btnTileMerger.Click += new EventHandler(btnTileMerger_Click);
            MainWindow.instance.btnUIEditor.Click += new EventHandler(btnUIEditor_Click);
            MainWindow.instance.btnEffectEditor.Click += new EventHandler(btnEffectEditor_Click);
            MainWindow.instance.btnSaveEditor.Click += new EventHandler(btnSaveEditor_Click);
            MainWindow.instance.btnPortraitEditor.Click += new EventHandler(btnPortraitEditor_Click);
            MainWindow.instance.btnGlobalSettingsEditor.Click += new EventHandler(btnGlobalSettingsEditor_Click);
            MainWindow.instance.btnFactionEditor.Click += new EventHandler(btnFactionEditor_Click);
            MainWindow.instance.btnBuffEditor.Click += new EventHandler(btnBuffEditor_Click);
            MainWindow.instance.btnDebugWithoutLaunch.Click += new EventHandler(btnDebugWithoutLaunch_Click);
        }

        public static bool ProcessKeys(Keys keyData) {
            if (keyData == Keys.F5) {
                ExportAndRun(); return true;
            } else if (keyData == Keys.T) {
                OpenTileEditor(); return true;
            } else if (keyData == Keys.O) {
                OpenTemplateEditor(); return true;
            } else if (keyData == Keys.R) {
                //OpenElementEditor(); return true;
            } else if (keyData == Keys.I) {
                OpenItemEditor(); return true;
            } else if (keyData == Keys.E) {
                OpenEquipmentEditor(); return true;
            } else if (keyData == Keys.C) {
                OpenCritterEditor(); return true;
            } else if (keyData == Keys.Z) {
                OpenSoundEditor(); return true;
            } else if (keyData == Keys.X) {
                OpenWorldEditor(); return true;
            } else if (keyData == Keys.U) {
                OpenUIEditor(); return true;
            } else if (keyData == Keys.F) {
                OpenEffectEditor(); return true;
            } else if (keyData == Keys.V) {
                OpenSaveEditor(); return true;
            } else if (keyData == Keys.P) {
                OpenPortraitEditor(); return true;
            } else if (keyData == Keys.G) {
                OpenGlobalSettingsEditor(); return true;
            } else if (keyData == Keys.Q) {
                OpenFactionEditor(); return true;
            } else if (keyData == Keys.B) {
                OpenBuffEditor(); return true;
            }

            return false;
        }

        private static void OpenTileEditor() {
            TileEditor t = new TileEditor();
            t.ShowDialog(MainWindow.instance);
            t.Dispose();
            TileInterface.ForceUpdate();
        }

        private static void OpenTemplateEditor() {
            ObjectEditor t = new ObjectEditor();
            t.OnSave += new ObjectEditor.SaveEventHandler(MainWindow.instance.ObjectTemplateSaved);
            t.ShowDialog(MainWindow.instance);
            t.Dispose();
            ObjectInterface.ReloadAll();
        }

        private static void OpenEquipmentEditor() {
            EquipmentEditor t = new EquipmentEditor();
            t.ShowDialog(MainWindow.instance);
            t.Dispose();
        }

        private static void OpenItemEditor() {
            ItemEditor t = new ItemEditor();
            t.ShowDialog(MainWindow.instance);
            t.Dispose();
        }

        private static void OpenCritterEditor() {
            CritterEditor t = new CritterEditor();
            t.ShowDialog(MainWindow.instance);
            t.Dispose();
        }

        private static void OpenSoundEditor() {
            SoundEditor t = new SoundEditor();
            t.ShowDialog(MainWindow.instance);
            SoundInterface.PopulateList();
            t.Dispose();
        }

        internal static void OpenWorldEditor() {
            WorldEditor t = new WorldEditor();
            t.ShowDialog(MainWindow.instance);
            t.Dispose();
        }

        private static void OpenTileMerger() {
            TileMergeDialog t = new TileMergeDialog();
            t.ShowDialog(MainWindow.instance);
            t.Dispose();
        }

        private static void OpenShadowEditor() {
            ShadowCreator t = new ShadowCreator();
            t.ShowDialog();
            t.Dispose();
        }

        private static void OpenUIEditor() {
            UIEditor t = new UIEditor();
            t.Show(MainWindow.instance);
        }

        private static void OpenEffectEditor() {
            EffectEditor t = new EffectEditor();
            t.ShowDialog();
            t.Dispose();
        }

        private static void OpenSaveEditor() {
            SaveFileEditor t = new SaveFileEditor();
            t.ShowDialog();
        }

        private static void OpenPortraitEditor() {
            PortraitEditor t = new PortraitEditor();
            t.ShowDialog();
            t.Dispose();
        }

        private static void OpenGlobalSettingsEditor() {
            GlobalSettingsEditor t = new GlobalSettingsEditor();
            t.Show(MainWindow.instance);
        }

        private static void OpenFactionEditor() {
            FactionEditor t = new FactionEditor();
            t.ShowDialog(MainWindow.instance);
            SpawnRegionInterface.UpdateSpawnRegionFactions();
            t.Dispose();
        }

        private static void OpenBuffEditor() {
            BuffsEditor t = new BuffsEditor();
            t.Show(MainWindow.instance);
        }

        public static void OpenVariableEditor() {
            if (gve == null) gve = new GlobalVariableEditor();

            if (!gve.Visible) {
                gve.Show(MainWindow.instance);
                gve = null;
            } else {
                gve.Focus();
            }
        }

        private static void ExportAndRun() {
            string args = "map=" + MapPieceCache.CurrentPiece.Name;

            if (MainWindow.instance.ckbExportDebugRender.Checked) {
                args = args + "+debug=Yes";
            }

            if (MainWindow.instance.ckbExportShowFPS.Checked) {
                args = args + "+showfps=Yes";
            }

            if (!MainWindow.instance.ckbExportMusicEnabled.Checked) {
                args = args + "+music=No";
            }

            if (MainWindow.instance.cbExportSave.SelectedItem is SaveInfo) {
                if (!Directory.Exists("Build/Saves/")) {
                    Directory.CreateDirectory("Build/Saves/");
                }
                
                File.Copy((MainWindow.instance.cbExportSave.SelectedItem as SaveInfo).filename, "Build/Saves/" + (MainWindow.instance.cbExportSave.SelectedItem as SaveInfo).ToString());

                args = args + "+save=" + (MainWindow.instance.cbExportSave.SelectedItem as SaveInfo).ToString();
            }

            try {
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
            } catch {
                MessageBox.Show("Could not run the build. No idea why.\n\nSuggestions:\n1. Double check you have AIR3.8.\n2. Double check you don't already have the game open.\n\nIf problems continue, let Paul know and he'll look deeper.");
            }
        }

        private static void btnDebug(bool debug, bool runGame) {
            
        }

        private static void btnTileEditorTool_Click(object sender, EventArgs e) {
            OpenTileEditor();
        }

        private static void btnObjectEditor_Click(object sender, EventArgs e) {
            OpenTemplateEditor();
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

        private static void btnTileMerger_Click(object sender, EventArgs e) {
            OpenTileMerger();
        }

        private static void btnShadowTool_Click(object sender, EventArgs e) {
            OpenShadowEditor();
        }

        private static void btnUIEditor_Click(object sender, EventArgs e) {
            OpenUIEditor();
        }

        private static void btnEffectEditor_Click(object sender, EventArgs e) {
            OpenEffectEditor();
        }

        static void btnSaveEditor_Click(object sender, EventArgs e) {
            OpenSaveEditor();
        }

        static void btnPortraitEditor_Click(object sender, EventArgs e) {
            OpenPortraitEditor();
        }

        private static void btnGlobalSettingsEditor_Click(object send, EventArgs e) {
            OpenGlobalSettingsEditor();
        }

        private static void btnFactionEditor_Click(object sender, EventArgs e) {
            OpenFactionEditor();
        }

        static void btnBuffEditor_Click(object sender, EventArgs e) {
            OpenBuffEditor();
        }

        static void btnDebugWithoutLaunch_Click(object sender, EventArgs e) {
            
        }
    }
}
