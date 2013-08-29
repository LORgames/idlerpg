using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;
using CityTools.ObjectSystem;
using ToolCache.Map.Regions;
using CityTools.MiscHelpers;
using ToolCache.Critters;

namespace CityTools.CacheInterfaces {
    /// <summary>
    /// Responsible for controlling spawn regions.
    /// </summary>
    internal class SpawnRegionInterface {
        private static bool _Editing = false;

        /// <summary>
        /// Hooks into the GUI and sets up all the event handlers
        /// </summary>
        internal static void Initialize() {
            MainWindow.instance.btnSpawnAdd.Click += new EventHandler(btnAddRegion_Click);
            MainWindow.instance.btnSpawnDelete.Click += new EventHandler(btnDeleteRegions_Click);

            MainWindow.instance.listSpawns.SelectedIndexChanged += new EventHandler(listRegions_SelectedIndexChanged);
            MainWindow.instance.ckbDrawSpawns.CheckedChanged += new EventHandler(ckDrawRegions_CheckedChanged);

            MainWindow.instance.txtSpawnName.TextChanged += new EventHandler(txtRegionName_TextChanged);
            MainWindow.instance.txtSpawnName.LostFocus += new EventHandler(txtRegionName_LostFocus);

            MainWindow.instance.btnSpawnAreaAdd.Click += new EventHandler(btnSpawnAreaAdd_Click);
            MainWindow.instance.btnSpawnAreaClear.Click += new EventHandler(btnSpawnRegionClearAreas_Click);

            MainWindow.instance.numSpawnTimer.ValueChanged += new EventHandler(numValueChanged);
            MainWindow.instance.numSpawnLoad.ValueChanged += new EventHandler(numValueChanged);
            MainWindow.instance.numSpawnMax.ValueChanged += new EventHandler(numValueChanged);
            MainWindow.instance.cbExportSave.SelectedIndexChanged += new EventHandler(numValueChanged);

            MainWindow.instance.btnNormalizeSpawnRegion.Click += new EventHandler(btnNormalizeSpawnRegion_Click);

            UpdateSpawnRegionFactions();
        }

        /// <summary>
        /// One of the spawn numbercounter things was modified
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        static void numValueChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listSpawns.SelectedItem != null && !_Editing) {
                if (sender == MainWindow.instance.numSpawnTimer) {
                    (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).Timeout = (short)MainWindow.instance.numSpawnTimer.Value;
                } else if (sender == MainWindow.instance.numSpawnLoad) {
                    (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).SpawnOnLoad = (byte)MainWindow.instance.numSpawnLoad.Value;
                } else if (sender == MainWindow.instance.numSpawnMax) {
                    (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).MaxSpawn = (byte)MainWindow.instance.numSpawnMax.Value;
                } else if (sender == MainWindow.instance.cbSpawnRegionFaction) {
                    (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).Faction = MainWindow.instance.cbSpawnRegionFaction.SelectedText;
                }

                MapPieceCache.CurrentPiece.Edited();
            }
        }

        /// <summary>
        /// Updates all of the Spawn related GUI
        /// </summary>
        internal static void UpdateGUI() {
            if (MainWindow.instance.listSpawns.SelectedItems.Count != 1) {
                MainWindow.instance.txtSpawnName.Enabled = false;
                MainWindow.instance.btnSpawnAreaAdd.Enabled = false;
                MainWindow.instance.btnSpawnAreaClear.Enabled = false;
                MainWindow.instance.numSpawnLoad.Enabled = false;
                MainWindow.instance.numSpawnMax.Enabled = false;
                MainWindow.instance.numSpawnTimer.Enabled = false;
                MainWindow.instance.cbSpawnRegionFaction.Enabled = false;
            } else {
                MainWindow.instance.txtSpawnName.Enabled = true;
                MainWindow.instance.btnSpawnAreaAdd.Enabled = true;
                MainWindow.instance.btnSpawnAreaClear.Enabled = true;
                MainWindow.instance.numSpawnLoad.Enabled = true;
                MainWindow.instance.numSpawnMax.Enabled = true;
                MainWindow.instance.numSpawnTimer.Enabled = true;
                MainWindow.instance.cbSpawnRegionFaction.Enabled = true;

                _Editing = true;

                MainWindow.instance.txtSpawnName.Text = (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).Name;
                MainWindow.instance.numSpawnLoad.Value = (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).SpawnOnLoad;
                MainWindow.instance.numSpawnMax.Value = (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).MaxSpawn;
                MainWindow.instance.numSpawnTimer.Value = (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).Timeout;

                int fID = Factions.GetID((MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).Faction);
                MainWindow.instance.cbSpawnRegionFaction.SelectedIndex = fID > -1 ? fID : MainWindow.instance.cbSpawnRegionFaction.Items.Count - 1;

                _Editing = false;

                UpdateSpawnList();
            }
        }

        /// <summary>
        /// Updates the critter list for the current selected spawn region.
        /// </summary>
        private static void UpdateSpawnList() {
            MainWindow.instance.listSpawnCritters.Items.Clear();

            if (MainWindow.instance.listSpawns.SelectedItems.Count == 1) {
                foreach (CritterSpawn spawn in (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).SpawnList) {
                    MainWindow.instance.listSpawnCritters.Items.Add(spawn.GetListViewItem());
                }
            }
        }

        /// <summary>
        /// Fires when the user clicks the normalize button. Sorts out the SpawnRegion percentages
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void btnNormalizeSpawnRegion_Click(object sender, EventArgs e) {
            if (MainWindow.instance.listSpawns.SelectedItems.Count == 1) {
                (MainWindow.instance.listSpawns.SelectedItems[0] as SpawnRegion).FixSpawnRates();
                UpdateSpawnList();
            }
        }

        /// <summary>
        /// Updates the list of spawn areas on the map editor panel.
        /// </summary>
        internal static void UpdateSpawnRegionList() {
            //Fix the region list
            MainWindow.instance.listSpawns.Items.Clear();

            foreach (SpawnRegion p in MapPieceCache.CurrentPiece.Spawns) {
                MainWindow.instance.listSpawns.Items.Add(p);
            }

            UpdateRegionDrawList();
            UpdateGUI();
        }

        /// <summary>
        /// 
        /// </summary>
        internal static void UpdateRegionDrawList() {
            RegionHelper.DrawList.Clear();

            if (MainWindow.instance.ckbDrawSpawns.Checked) {
                RegionHelper.DrawList.AddRange(MapPieceCache.CurrentPiece.Spawns);
            } else {
                foreach (object p in MainWindow.instance.listSpawns.SelectedItems) {
                    if (p is SpawnRegion) {
                        RegionHelper.DrawList.Add(p as SpawnRegion);
                    }
                }
            }

            if (MainWindow.instance.ckbDrawScriptRegions.Checked) {
                RegionHelper.DrawList.AddRange(MapPieceCache.CurrentPiece.ScriptRegions);
            } else {
                foreach (object p in MainWindow.instance.listScriptRegions.SelectedItems) {
                    if (p is ScriptRegion) {
                        RegionHelper.DrawList.Add(p as ScriptRegion);
                    }
                }
            }
        }

        /// <summary>
        /// A different spawn region was clicked.
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void listRegions_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listSpawns.SelectedItems.Count == 1) {
                (MainWindow.instance.listSpawns.SelectedItems[0] as SpawnRegion).FixSpawnRates();
                RegionHelper.selectedRegion = MainWindow.instance.listSpawns.SelectedItems[0] as SpawnRegion;
            }

            UpdateGUI();
            UpdateRegionDrawList();
        }

        /// <summary>
        /// The name of the region was changed
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void txtRegionName_TextChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listSpawns.SelectedItems.Count == 1) {
                if ((MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).Name != MainWindow.instance.txtSpawnName.Text) {
                    (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).Name = MainWindow.instance.txtSpawnName.Text;
                    MapPieceCache.CurrentPiece.Edited();
                }
            }
        }

        /// <summary>
        /// Updates the region list when the name has changed
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void txtRegionName_LostFocus(object sender, EventArgs e) {
            UpdateSpawnRegionList();
        }


        /// <summary>
        /// Sets the control system to Region painting and sets the current region in the helper to the selected one
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void btnSpawnAreaAdd_Click(object sender, EventArgs e) {
            if(MainWindow.instance.listSpawns.SelectedItem != null) {
                MainWindow.instance.paintMode = PaintMode.Regions;
                RegionHelper.selectedRegion = (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion);
            }
        }

        /// <summary>
        /// Clears the spawn region for the current spawn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void btnSpawnRegionClearAreas_Click(object sender, EventArgs e) {
            if (MainWindow.instance.listSpawns.SelectedItem != null) {
                (MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).Areas.Clear();
                MapPieceCache.CurrentPiece.Edited();
            }
        }

        /// <summary>
        /// Adds a new region to the region list.
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void btnAddRegion_Click(object sender, EventArgs e) {
            MapPieceCache.CurrentPiece.Spawns.Add(new SpawnRegion());
            MapPieceCache.CurrentPiece.Edited();
            UpdateSpawnRegionList();
        }

        /// <summary>
        /// Deletes the currently selected regions.
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void btnDeleteRegions_Click(object sender, EventArgs e) {
            int totalItems = MapPieceCache.CurrentPiece.Spawns.Count;

            foreach (Object item in MainWindow.instance.listSpawns.SelectedItems) {
                if (item is SpawnRegion) {
                    MapPieceCache.CurrentPiece.Spawns.Remove(item as SpawnRegion);
                }
            }

            if (totalItems != MapPieceCache.CurrentPiece.Spawns.Count) {
                MapPieceCache.CurrentPiece.Edited();
            }

            UpdateSpawnRegionList();
        }

        /// <summary>
        /// The all regions checkbox has changed.
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void ckDrawRegions_CheckedChanged(object sender, EventArgs e) {
            UpdateRegionDrawList();
        }

        /// <summary>
        /// Updates the list of factions a spawn region can belong to.
        /// </summary>
        internal static void UpdateSpawnRegionFactions() {
            MainWindow.instance.cbSpawnRegionFaction.Items.Clear();

            foreach (String s in Factions.FactionNames()) {
                MainWindow.instance.cbSpawnRegionFaction.Items.Add(s);
            }

            MainWindow.instance.cbSpawnRegionFaction.Items.Add("");

            UpdateGUI();
        }
    }
}
