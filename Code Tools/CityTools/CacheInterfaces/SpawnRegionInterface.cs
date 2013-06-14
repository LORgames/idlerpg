using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.World;
using ToolCache.Map;
using CityTools.ObjectSystem;
using ToolCache.Map.Regions;
using CityTools.MiscHelpers;

namespace CityTools.CacheInterfaces {
    /// <summary>
    /// Responsible for controlling spawn regions.
    /// </summary>
    internal class SpawnRegionInterface {
        /// <summary>
        /// Hooks into the GUI and sets up all the event handlers
        /// </summary>
        internal static void Initialize() {
            MainWindow.instance.btnAddRegion.Click += new EventHandler(btnAddRegion_Click);
            MainWindow.instance.btnDeleteRegion.Click += new EventHandler(btnDeleteRegions_Click);

            MainWindow.instance.listRegions.SelectedIndexChanged += new EventHandler(listRegions_SelectedIndexChanged);
            MainWindow.instance.cbDrawRegions.CheckedChanged += new EventHandler(ckDrawRegions_CheckedChanged);

            MainWindow.instance.txtRegionName.TextChanged += new EventHandler(txtRegionName_TextChanged);
            MainWindow.instance.txtRegionName.LostFocus += new EventHandler(txtRegionName_LostFocus);

            MainWindow.instance.btnRegionResize.Click += new EventHandler(btnRegionResize_Click);

            MainWindow.instance.numSpawnTimer.ValueChanged += new EventHandler(numValueChanged);
            MainWindow.instance.numSpawnLoad.ValueChanged += new EventHandler(numValueChanged);
            MainWindow.instance.numSpawnMax.ValueChanged += new EventHandler(numValueChanged);
        }

        /// <summary>
        /// One of the spawn numbercounter things was modified
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        static void numValueChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listRegions.SelectedItem != null) {
                if (sender == MainWindow.instance.numSpawnTimer) {
                    (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).Timeout = (short)MainWindow.instance.numSpawnTimer.Value;
                } else if (sender == MainWindow.instance.numSpawnLoad) {
                    (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).SpawnOnLoad = (byte)MainWindow.instance.numSpawnLoad.Value;
                } else if (sender == MainWindow.instance.numSpawnMax) {
                    (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).MaxSpawn = (byte)MainWindow.instance.numSpawnMax.Value;
                }
            }
        }

        /// <summary>
        /// Updates all of the Spawn related GUI
        /// </summary>
        internal static void UpdateGUI() {
            if (MainWindow.instance.listRegions.SelectedItems.Count != 1) {
                MainWindow.instance.txtRegionName.Enabled = false;
                MainWindow.instance.btnRegionResize.Enabled = false;
                MainWindow.instance.numSpawnLoad.Enabled = false;
                MainWindow.instance.numSpawnMax.Enabled = false;
                MainWindow.instance.numSpawnTimer.Enabled = false;
            } else {
                MainWindow.instance.txtRegionName.Enabled = true;
                MainWindow.instance.btnRegionResize.Enabled = true;
                MainWindow.instance.numSpawnLoad.Enabled = true;
                MainWindow.instance.numSpawnMax.Enabled = true;
                MainWindow.instance.numSpawnTimer.Enabled = true;

                MainWindow.instance.txtRegionName.Text = (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).Name;
                MainWindow.instance.numSpawnLoad.Value = (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).SpawnOnLoad;
                MainWindow.instance.numSpawnMax.Value = (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).MaxSpawn;
                MainWindow.instance.numSpawnTimer.Value = (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).Timeout;

                UpdateSpawnList();
            }
        }

        /// <summary>
        /// Updates the critter list for the current selected spawn region.
        /// </summary>
        private static void UpdateSpawnList() {
            MainWindow.instance.listCritterSpawns.Items.Clear();

            if (MainWindow.instance.listRegions.SelectedItems.Count == 1) {
                foreach (CritterSpawn spawn in (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).SpawnList) {
                    MainWindow.instance.listCritterSpawns.Items.Add(spawn.GetListViewItem());
                }
            }
        }

        /// <summary>
        /// Updates the list of spawn areas on the map editor panel.
        /// </summary>
        internal static void UpdateRegionList() {
            //Fix the region list
            MainWindow.instance.listRegions.Items.Clear();

            foreach (SpawnRegion p in MapPieceCache.CurrentPiece.Spawns) {
                MainWindow.instance.listRegions.Items.Add(p);
            }

            UpdateRegionDrawList();
            UpdateGUI();
        }

        /// <summary>
        /// 
        /// </summary>
        private static void UpdateRegionDrawList() {
            RegionHelper.DrawList.Clear();

            if (MainWindow.instance.cbDrawRegions.Checked) {
                RegionHelper.DrawList.AddRange(MapPieceCache.CurrentPiece.Spawns);
            } else {
                foreach (object p in MainWindow.instance.listRegions.SelectedItems) {
                    if (p is SpawnRegion) {
                        RegionHelper.DrawList.Add(p as SpawnRegion);
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
            if (MainWindow.instance.listRegions.SelectedItems.Count == 1) {
                RegionHelper.selectedRegion = MainWindow.instance.listRegions.SelectedItems[0] as SpawnRegion;
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
            if (MainWindow.instance.listRegions.SelectedItems.Count == 1) {
                if ((MainWindow.instance.listRegions.SelectedItem as SpawnRegion).Name != MainWindow.instance.txtRegionName.Text) {
                    (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).Name = MainWindow.instance.txtRegionName.Text;
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
            UpdateRegionList();
        }


        /// <summary>
        /// Sets the control system to Region painting and sets the current region in the helper to the selected one
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void btnRegionResize_Click(object sender, EventArgs e) {
            if(MainWindow.instance.listRegions.SelectedItem != null) {
                MainWindow.instance.paintMode = PaintMode.Regions;
                RegionHelper.selectedRegion = (MainWindow.instance.listRegions.SelectedItem as SpawnRegion);
            }
        }

        /// <summary>
        /// Adds a new region to the region list.
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void btnAddRegion_Click(object sender, EventArgs e) {
            MapPieceCache.CurrentPiece.Spawns.Add(new SpawnRegion());
            UpdateRegionList();
        }

        /// <summary>
        /// Deletes the currently selected regions.
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void btnDeleteRegions_Click(object sender, EventArgs e) {
            int totalItems = MapPieceCache.CurrentPiece.Spawns.Count;

            foreach (Object item in MainWindow.instance.listRegions.SelectedItems) {
                if (item is SpawnRegion) {
                    MapPieceCache.CurrentPiece.Spawns.Remove(item as SpawnRegion);
                }
            }

            if (totalItems != MapPieceCache.CurrentPiece.Spawns.Count) {
                MapPieceCache.CurrentPiece.Edited();
            }

            UpdateRegionList();
        }

        /// <summary>
        /// The all regions checkbox has changed.
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void ckDrawRegions_CheckedChanged(object sender, EventArgs e) {
            UpdateRegionDrawList();
        }
    }
}
