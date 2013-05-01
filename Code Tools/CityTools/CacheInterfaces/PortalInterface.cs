﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.World;
using ToolCache.Map;
using CityTools.ObjectSystem;

namespace CityTools.CacheInterfaces {
    internal class PortalInterface {
        internal static void Initialize() {
            MainWindow.instance.btnAddPortal.Click += new EventHandler(btnAddPortal_Click);
            MainWindow.instance.btnDeletePortals.Click += new EventHandler(btnDeletePortals_Click);

            MainWindow.instance.listPortals.SelectedIndexChanged += new EventHandler(listPortals_SelectedIndexChanged);
            MainWindow.instance.ckbShowPortals.CheckedChanged += new EventHandler(ckbShowPortals_CheckedChanged);

            MainWindow.instance.txtPortalName.TextChanged += new EventHandler(txtPortalName_TextChanged);
            MainWindow.instance.txtPortalName.LostFocus += new EventHandler(txtPortalName_LostFocus);

            MainWindow.instance.btnPortalEntry.Click += new EventHandler(btnPortalEntry_Click);
            MainWindow.instance.btnPortalExit.Click += new EventHandler(btnPortalExit_Click);
        }

        internal static void UpdateGUI() {
            if (MainWindow.instance.listPortals.SelectedItems.Count != 1) {
                MainWindow.instance.txtPortalName.Enabled = false;
                MainWindow.instance.btnPortalEntry.Enabled = false;
                MainWindow.instance.btnPortalExit.Enabled = false;
            } else {
                MainWindow.instance.txtPortalName.Enabled = true;
                MainWindow.instance.btnPortalEntry.Enabled = true;
                MainWindow.instance.btnPortalExit.Enabled = true;

                MainWindow.instance.txtPortalName.Text = (MainWindow.instance.listPortals.SelectedItem as Portal).Name;
            }
        }

        internal static void UpdatePortalList() {
            //Fix the portal list
            MainWindow.instance.listPortals.Items.Clear();

            foreach (Portal p in MapPieceCache.CurrentPiece.Portals) {
                MainWindow.instance.listPortals.Items.Add(p);
            }

            UpdateGUI();
        }

        private static void UpdatePortalDrawList() {
            if (MainWindow.instance.ckbShowPortals.Checked) {
                PortalHelper.DrawList.AddRange(MapPieceCache.CurrentPiece.Portals);
            } else {
                PortalHelper.DrawList.Clear();

                foreach (object p in MainWindow.instance.listPortals.SelectedItems) {
                    if (p is Portal) {
                        PortalHelper.DrawList.Add(p as Portal);
                    }
                }
            }
        }

        private static void listPortals_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listPortals.SelectedItems.Count == 1) {
                PortalHelper.selectedPortal = MainWindow.instance.listPortals.SelectedItems[0] as Portal;
            }

            UpdateGUI();
            UpdatePortalDrawList();
        }

        private static void txtPortalName_TextChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listPortals.SelectedItems.Count == 1) {
                if ((MainWindow.instance.listPortals.SelectedItem as Portal).Name != MainWindow.instance.txtPortalName.Text) {
                    (MainWindow.instance.listPortals.SelectedItem as Portal).Name = MainWindow.instance.txtPortalName.Text;
                    MapPieceCache.CurrentPiece.Edited();
                }
            }
        }

        private static void txtPortalName_LostFocus(object sender, EventArgs e) {
            UpdatePortalList();
        }

        private static void btnPortalExit_Click(object sender, EventArgs e) {
            MainWindow.instance.paintMode = PaintMode.Portals;
            PortalHelper.PlacingEntry = false;
        }

        private static void btnPortalEntry_Click(object sender, EventArgs e) {
            MainWindow.instance.paintMode = PaintMode.Portals;
            PortalHelper.PlacingEntry = true;
        }

        private static void btnAddPortal_Click(object sender, EventArgs e) {
            Portals.CreatePortal(MapPieceCache.CurrentPiece);

            UpdatePortalList();
        }

        private static void btnDeletePortals_Click(object sender, EventArgs e) {
            int totalItems = MapPieceCache.CurrentPiece.Portals.Count;

            foreach (Object item in MainWindow.instance.listPortals.SelectedItems) {
                if (item is Portal) {
                    MapPieceCache.CurrentPiece.Portals.Remove(item as Portal);
                }
            }

            if (totalItems != MapPieceCache.CurrentPiece.Portals.Count) {
                MapPieceCache.CurrentPiece.Edited();
            }

            UpdatePortalList();
        }

        private static void ckbShowPortals_CheckedChanged(object sender, EventArgs e) {
            UpdatePortalDrawList();
        }
    }
}
