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
    internal class RegionInterface {
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

        static void numValueChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listRegions.SelectedItem != null) {
                if (sender == MainWindow.instance.numSpawnTimer) {
                    (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).Timeout = (short)MainWindow.instance.numSpawnTimer.Value;
                } else if (sender == MainWindow.instance.numSpawnLoad) {
                    (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).SpawnOnLoad = (short)MainWindow.instance.numSpawnLoad.Value;
                } else if (sender == MainWindow.instance.numSpawnMax) {
                    (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).MaxSpawn = (short)MainWindow.instance.numSpawnMax.Value;
                }
            }
        }

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

        private static void UpdateSpawnList() {
            
        }

        internal static void UpdateRegionList() {
            //Fix the region list
            MainWindow.instance.listRegions.Items.Clear();

            foreach (SpawnRegion p in MapPieceCache.CurrentPiece.Spawns) {
                MainWindow.instance.listRegions.Items.Add(p);
            }

            UpdateRegionDrawList();
            UpdateGUI();
        }

        private static void UpdateRegionDrawList() {
            if (MainWindow.instance.cbDrawRegions.Checked) {
                RegionHelper.DrawList.AddRange(MapPieceCache.CurrentPiece.Spawns);
            } else {
                RegionHelper.DrawList.Clear();

                foreach (object p in MainWindow.instance.listRegions.SelectedItems) {
                    if (p is SpawnRegion) {
                        RegionHelper.DrawList.Add(p as SpawnRegion);
                    }
                }
            }
        }

        private static void listRegions_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listRegions.SelectedItems.Count == 1) {
                RegionHelper.selectedRegion = MainWindow.instance.listRegions.SelectedItems[0] as SpawnRegion;
            }

            UpdateGUI();
        }

        private static void txtRegionName_TextChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listRegions.SelectedItems.Count == 1) {
                if ((MainWindow.instance.listRegions.SelectedItem as SpawnRegion).Name != MainWindow.instance.txtRegionName.Text) {
                    (MainWindow.instance.listRegions.SelectedItem as SpawnRegion).Name = MainWindow.instance.txtRegionName.Text;
                    MapPieceCache.CurrentPiece.Edited();
                }
            }
        }

        private static void txtRegionName_LostFocus(object sender, EventArgs e) {
            UpdateRegionList();
        }

        private static void btnRegionResize_Click(object sender, EventArgs e) {
            if(MainWindow.instance.listRegions.SelectedItem != null) {
                MainWindow.instance.paintMode = PaintMode.Regions;
                RegionHelper.selectedRegion = (MainWindow.instance.listRegions.SelectedItem as SpawnRegion);
            }
        }

        private static void btnAddRegion_Click(object sender, EventArgs e) {
            MapPieceCache.CurrentPiece.Spawns.Add(new SpawnRegion());
            UpdateRegionList();
        }

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

        private static void ckDrawRegions_CheckedChanged(object sender, EventArgs e) {
            UpdateRegionDrawList();
        }
    }
}
