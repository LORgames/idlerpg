using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.World;
using ToolCache.Map;
using CityTools.ObjectSystem;
using CityTools.MiscHelpers;

namespace CityTools.CacheInterfaces {
    /// <summary>
    /// Responsible for talking to the ToolCache library for anything Portal related.
    /// </summary>
    internal class PortalInterface {
        /// <summary>
        /// Creates any GUI hooks that might be required and loads any additional databases.
        /// </summary>
        internal static void Initialize() {
            MainWindow.instance.btnAddPortal.Click += new EventHandler(btnAddPortal_Click);
            MainWindow.instance.btnDeletePortals.Click += new EventHandler(btnDeletePortals_Click);

            MainWindow.instance.listPortals.SelectedIndexChanged += new EventHandler(listPortals_SelectedIndexChanged);
            MainWindow.instance.ckbDrawPortals.CheckedChanged += new EventHandler(ckbShowPortals_CheckedChanged);

            MainWindow.instance.txtPortalName.TextChanged += new EventHandler(txtPortalName_TextChanged);
            MainWindow.instance.txtPortalName.LostFocus += new EventHandler(txtPortalName_LostFocus);

            MainWindow.instance.btnPortalEntry.Click += new EventHandler(btnPortalEntry_Click);
            MainWindow.instance.btnPortalExit.Click += new EventHandler(btnPortalExit_Click);
        }

        /// <summary>
        /// Updates all the portal related gui in the map editor.
        /// </summary>
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


        /// <summary>
        /// Updates the List of all portals on the current map.
        /// </summary>
        internal static void UpdatePortalList() {
            //Fix the portal list
            MainWindow.instance.listPortals.Items.Clear();

            foreach (Portal p in MapPieceCache.CurrentPiece.Portals) {
                MainWindow.instance.listPortals.Items.Add(p);
            }

            UpdatePortalDrawList();
            UpdateGUI();
        }

        /// <summary>
        /// Updates the list of portals the user has selected for drawing.
        /// </summary>
        private static void UpdatePortalDrawList() {
            PortalHelper.DrawList.Clear();

            if (MainWindow.instance.ckbDrawPortals.Checked) {
                PortalHelper.DrawList.AddRange(MapPieceCache.CurrentPiece.Portals);
            } else {
                foreach (object p in MainWindow.instance.listPortals.SelectedItems) {
                    if (p is Portal) {
                        PortalHelper.DrawList.Add(p as Portal);
                    }
                }
            }
        }

        /// <summary>
        /// Called when the user clicks on a portal, updates the lists.
        /// </summary>
        /// <param name="sender">Not important, can be null.</param>
        /// <param name="e">Not important, can be null.</param>
        private static void listPortals_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainWindow.instance.listPortals.SelectedItems.Count == 1) {
                PortalHelper.selectedPortal = MainWindow.instance.listPortals.SelectedItems[0] as Portal;
            }

            UpdateGUI();
            UpdatePortalDrawList();
        }

        /// <summary>
        /// Called when the user renamed the portal.
        /// </summary>
        /// <param name="sender">Not important, can be null.</param>
        /// <param name="e">Not important, can be null.</param>
        private static void txtPortalName_TextChanged(object sender, EventArgs e) {
            //TODO: This is causing the portal to lose focus?
            if (MainWindow.instance.listPortals.SelectedItems.Count == 1) {
                if ((MainWindow.instance.listPortals.SelectedItem as Portal).Name != MainWindow.instance.txtPortalName.Text) {
                    (MainWindow.instance.listPortals.SelectedItem as Portal).Name = MainWindow.instance.txtPortalName.Text;
                    MapPieceCache.CurrentPiece.Edited();
                }
            }
        }

        /// <summary>
        /// Causes a lot of heartache...
        /// </summary>
        /// <param name="sender">Not important, can be null.</param>
        /// <param name="e">Not important, can be null.</param>
        private static void txtPortalName_LostFocus(object sender, EventArgs e) {
            UpdatePortalList();
        }

        /// <summary>
        /// Pretty obvious...
        /// </summary>
        /// <param name="sender">Not important, can be null.</param>
        /// <param name="e">Not important, can be null.</param>
        private static void btnPortalExit_Click(object sender, EventArgs e) {
            MainWindow.instance.paintMode = PaintMode.Portals;
            PortalHelper.PlacingEntry = false;
        }

        /// <summary>
        /// Comments are stupid...
        /// </summary>
        /// <param name="sender">Not important, can be null.</param>
        /// <param name="e">Not important, can be null.</param>
        private static void btnPortalEntry_Click(object sender, EventArgs e) {
            MainWindow.instance.paintMode = PaintMode.Portals;
            PortalHelper.PlacingEntry = true;
        }

        /// <summary>
        /// The wheels on the bus go round and round...
        /// </summary>
        /// <param name="sender">Not important, can be null.</param>
        /// <param name="e">Not important, can be null.</param>
        private static void btnAddPortal_Click(object sender, EventArgs e) {
            Portals.CreatePortal(MapPieceCache.CurrentPiece);

            UpdatePortalList();
        }

        /// <summary>
        /// Seriously, why... Fires when you click delete. Deletes the selected portals.
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
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

        /// <summary>
        /// Fires when the checkbox to draw is modified.
        /// </summary>
        /// <param name="sender">Not Important, Can be null.</param>
        /// <param name="e">Not Important, Can be null.</param>
        private static void ckbShowPortals_CheckedChanged(object sender, EventArgs e) {
            UpdatePortalDrawList();
        }
    }
}
