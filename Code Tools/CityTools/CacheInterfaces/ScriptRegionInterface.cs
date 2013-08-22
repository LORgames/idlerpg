using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using ToolCache.Map.Regions;
using CityTools.MiscHelpers;

namespace CityTools.CacheInterfaces {
    public class ScriptRegionInterface {
        internal static void Initialize() {
            MainWindow.instance.btnScriptRegionAdd.Click += new EventHandler(btnScriptRegionAdd_Click);
            MainWindow.instance.btnScriptRegionDelete.Click += new EventHandler(btnScriptRegionDelete_Click);

            MainWindow.instance.listScriptRegions.SelectedIndexChanged += new EventHandler(listScriptRegions_SelectedIndexChanged);
            MainWindow.instance.ckbDrawScriptRegions.CheckedChanged += new EventHandler(ckbDrawScriptRegions_CheckedChanged);

            MainWindow.instance.txtScriptRegionName.TextChanged += new EventHandler(txtScriptRegionName_TextChanged);
            MainWindow.instance.txtScriptRegionName.LostFocus += new EventHandler(txtScriptRegionName_LostFocus);

            MainWindow.instance.btnScriptRegionAreaAdd.Click += new EventHandler(btnScriptRegionAreaAdd_Click);
            MainWindow.instance.btnScriptRegionAreaClear.Click += new EventHandler(btnScriptRegionAreaClear_Click);

            MainWindow.instance.scriptScriptRegion.ScriptUpdated += new EventHandler<EventArgs>(scriptScriptRegion_ScriptUpdated);
        }

        /// <summary>
        /// Updates the list of script areas on the map editor panel.
        /// </summary>
        internal static void UpdateScriptRegionList() {
            //Fix the region list
            MainWindow.instance.listScriptRegions.Items.Clear();

            foreach (ScriptRegion p in MapPieceCache.CurrentPiece.ScriptRegions) {
                MainWindow.instance.listScriptRegions.Items.Add(p);
            }

            SpawnRegionInterface.UpdateRegionDrawList();
            UpdateGUI();
        }

        /// <summary>
        /// Updates all of the ScriptRegion related GUI
        /// </summary>
        internal static void UpdateGUI() {
            if (MainWindow.instance.listScriptRegions.SelectedItems.Count != 1) {
                MainWindow.instance.txtScriptRegionName.Enabled = false;
                MainWindow.instance.btnScriptRegionAreaAdd.Enabled = false;
                MainWindow.instance.btnScriptRegionAreaClear.Enabled = false;
                MainWindow.instance.scriptScriptRegion.Enabled = false;

                MainWindow.instance.txtScriptRegionName.Text = "";
                MainWindow.instance.scriptScriptRegion.Script = "";
            } else {
                MainWindow.instance.txtScriptRegionName.Enabled = true;
                MainWindow.instance.btnScriptRegionAreaAdd.Enabled = true;
                MainWindow.instance.btnScriptRegionAreaClear.Enabled = true;
                MainWindow.instance.scriptScriptRegion.Enabled = true;

                MainWindow.instance.txtScriptRegionName.Text = (MainWindow.instance.listScriptRegions.SelectedItem as ScriptRegion).Name;
                MainWindow.instance.scriptScriptRegion.Script = (MainWindow.instance.listScriptRegions.SelectedItem as ScriptRegion).Script;
            }
        }

        private static void scriptScriptRegion_ScriptUpdated(object sender, EventArgs e) {
            if (MainWindow.instance.listScriptRegions.SelectedItem != null) {
                (MainWindow.instance.listScriptRegions.SelectedItem as ScriptRegion).Script = MainWindow.instance.scriptScriptRegion.Script;
                MapPieceCache.CurrentPiece.Edited();
            }
        }

        private static void btnScriptRegionAreaClear_Click(object sender, EventArgs e) {
            if (MainWindow.instance.listScriptRegions.SelectedItem != null) {
                (MainWindow.instance.listScriptRegions.SelectedItem as ScriptRegion).Areas.Clear();
                MapPieceCache.CurrentPiece.Edited();
            }
        }

        private static void btnScriptRegionAreaAdd_Click(object sender, EventArgs e) {
            if (MainWindow.instance.listScriptRegions.SelectedItem != null) {
                MainWindow.instance.paintMode = PaintMode.Regions;
                RegionHelper.selectedRegion = (MainWindow.instance.listScriptRegions.SelectedItem as ScriptRegion);
            }
        }

        private static void txtScriptRegionName_LostFocus(object sender, EventArgs e) {
            UpdateScriptRegionList();
        }

        private static void txtScriptRegionName_TextChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listScriptRegions.SelectedItems.Count == 1) {
                if ((MainWindow.instance.listScriptRegions.SelectedItem as ScriptRegion).Name != MainWindow.instance.txtScriptRegionName.Text) {
                    (MainWindow.instance.listScriptRegions.SelectedItem as ScriptRegion).Name = MainWindow.instance.txtScriptRegionName.Text;
                    MapPieceCache.CurrentPiece.Edited();
                }
            }
        }

        private static void ckbDrawScriptRegions_CheckedChanged(object sender, EventArgs e) {
            SpawnRegionInterface.UpdateRegionDrawList();
        }

        private static void listScriptRegions_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listScriptRegions.SelectedItems.Count == 1) {
                RegionHelper.selectedRegion = MainWindow.instance.listScriptRegions.SelectedItems[0] as ScriptRegion;
            }

            UpdateGUI();
            SpawnRegionInterface.UpdateRegionDrawList();
        }

        private static void btnScriptRegionDelete_Click(object sender, EventArgs e) {
            int totalItems = MapPieceCache.CurrentPiece.ScriptRegions.Count;

            foreach (Object item in MainWindow.instance.listScriptRegions.SelectedItems) {
                if (item is ScriptRegion) {
                    MapPieceCache.CurrentPiece.ScriptRegions.Remove(item as ScriptRegion);
                }
            }

            if (totalItems != MapPieceCache.CurrentPiece.ScriptRegions.Count) {
                MapPieceCache.CurrentPiece.Edited();
            }

            UpdateScriptRegionList();
        }

        private static void btnScriptRegionAdd_Click(object sender, EventArgs e) {
            MapPieceCache.CurrentPiece.ScriptRegions.Add(new ScriptRegion());
            MapPieceCache.CurrentPiece.Edited();
            UpdateScriptRegionList();
        }
    }
}
