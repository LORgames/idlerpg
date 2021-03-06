﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CityTools.Components;
using CityTools.ObjectSystem;
using CityTools.Core;
using ToolCache.Drawing;
using ToolCache.General;
using ToolCache.Map;
using ToolCache.Map.Tiles;
using ToolCache.Animation;
using ToolCache.Map.Objects;
using ToolCache.Elements;
using ToolCache.Items;
using ToolCache.Equipment;
using System.Threading;
using CityTools.Terrain;
using System.Drawing.Imaging;
using ToolCache.Map.Background;
using CityTools.CacheInterfaces;
using CityTools.MiscHelpers;
using ToolCache.Map.Regions;

namespace CityTools {
    public enum PaintMode {
        Off,
        Terrain,
        Objects,
        ObjectSelector,
        Portals,
        Regions
    }

    public partial class MainWindow : Form {
        public Color BACKGROUND_COLOR = Color.Beige;

        public static MainWindow instance;
        public bool REQUIRES_CLOSE = false;

        //Our drawing settings
        public Size drawArea = new Size();
        public PaintMode paintMode = PaintMode.Off;

        //Our drawing buffers
        public LBuffer terrain_buffer;
        public LBuffer objects_buffer;
        public LBuffer input_buffer;

        public LBuffer minimapBuffer;

        //Terrain painting things
        public Brush terrainPaintBrush = new SolidBrush(Color.White);

        //Object painting things
        public AnimatedObject paintingAnimation = null;
        public bool was_mouse_down = false;

        public bool initialized = false;

        public MainWindow() {
            instance = this;

            InitializeComponent();
            InitializeInterfaces();
            InitializeDrawing();

            timerRefresh.Start();

#if !DEBUG
            CacheInterfaces.ToolsInterface.OpenWorldEditor();
#endif
        }

        private void InitializeDrawing() {
            drawArea = mapViewPanel.Size;
            Camera.FixViewArea(drawArea);

            initialized = true;
            CreateBuffers();
        }

        private static void InitializeInterfaces() {
            CacheInterfaces.MapInterface.Initialize();
            CacheInterfaces.TileInterface.Initialize();
            CacheInterfaces.ObjectInterface.Initialize();
            CacheInterfaces.SoundInterface.PopulateList();
            CacheInterfaces.ToolsInterface.Initialize();

            CacheInterfaces.SpawnRegionInterface.Initialize();
            CacheInterfaces.ScriptRegionInterface.Initialize();

            CacheInterfaces.SaveInterface.Initialize();
        }

        private void CreateBuffers() {
            if (!initialized) return;

            drawArea = mapViewPanel.DisplayRectangle.Size;

            terrain_buffer = new LBuffer(drawArea);
            objects_buffer = new LBuffer(drawArea);
            input_buffer = new LBuffer(drawArea);

            mapViewPanel.Invalidate();
        }

        private void mapViewPanel_Paint(object sender, PaintEventArgs e) {
            if (!initialized) return;
            if (REQUIRES_CLOSE) { this.Close(); return; }

            drawArea = e.ClipRectangle.Size;
            e.Graphics.FillRectangle(new SolidBrush(BACKGROUND_COLOR), e.ClipRectangle);

            RedrawTerrain();


            if (!GlobalSettings.TilesEnabled) {
                int LeftEdge = (int)(Camera.Offset.X / TileTemplate.PIXELS);
                int TopEdge = (int)(Camera.Offset.Y / TileTemplate.PIXELS);

                int RightEdge = (int)Math.Ceiling(Camera.ViewArea.Right / TileTemplate.PIXELS);
                int BottomEdge = (int)Math.Ceiling(Camera.ViewArea.Bottom / TileTemplate.PIXELS) + 1;

                if (LeftEdge < 0) LeftEdge = 0;
                if (TopEdge < 0) TopEdge = 0;
                if (RightEdge >= MapPieceCache.CurrentPiece.Tiles.numTilesX) RightEdge = MapPieceCache.CurrentPiece.Tiles.numTilesX;
                if (BottomEdge >= MapPieceCache.CurrentPiece.Tiles.numTilesY) BottomEdge = MapPieceCache.CurrentPiece.Tiles.numTilesY;
                MapPieceCache.CurrentPiece.Background.Draw(e.Graphics, new Rectangle((int)Math.Floor((LeftEdge * TileTemplate.PIXELS - Camera.Offset.X) * Camera.ZoomLevel), (int)Math.Floor((TopEdge * TileTemplate.PIXELS - Camera.Offset.Y) * Camera.ZoomLevel), (int)Math.Ceiling(TileTemplate.PIXELS * Camera.ZoomLevel * (RightEdge - LeftEdge)), (int)Math.Ceiling(TileTemplate.PIXELS * Camera.ZoomLevel * (BottomEdge - TopEdge))));
            }

            e.Graphics.DrawImage(terrain_buffer.bmp, Point.Empty);
            e.Graphics.DrawImage(objects_buffer.bmp, Point.Empty);

            if (paintMode != PaintMode.Off) e.Graphics.DrawImage(input_buffer.bmp, Point.Empty);

            if (ckbViewportEnabled.Checked) {
                int viewH;
                int viewW;

                if (int.TryParse(txtViewportWidth.Text, out viewW) && int.TryParse(txtViewportHeight.Text, out viewH)) {
                    int panelH = (mapViewPanel.Height - (int)(viewH*Camera.ZoomLevel)) / 2;
                    int panelW = (mapViewPanel.Width - (int)(viewW*Camera.ZoomLevel)) / 2;
                    
                    Rectangle[] rects = new Rectangle[4];

                    rects[0] = new Rectangle(0, 0, mapViewPanel.Width, panelH);
                    rects[1] = new Rectangle(0, panelH, panelW, mapViewPanel.Height - panelH);
                    rects[2] = new Rectangle(mapViewPanel.Width-panelW, panelH, panelW, mapViewPanel.Height - panelH);
                    rects[3] = new Rectangle(panelW, mapViewPanel.Height-panelH, mapViewPanel.Width-(panelW*2), panelH);

                    e.Graphics.FillRectangles(new SolidBrush(Color.FromArgb(128, Color.Black)), rects);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            Control active = FindFocusedControl(this);

            if (active is TextBox || active is RichTextBox || active is ListBox || active is NumericUpDown || active is ComboBox) {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            this.ActiveControl = mapViewPanel;

            if (keyData == Keys.D1) {
                ckbShowTileGrid.Checked = !ckbShowTileGrid.Checked;
            } else if (keyData == Keys.D2) {
                ckbShowObjectBases.Checked = !ckbShowObjectBases.Checked;
                if (ckbShowObjectBases.Checked) {
                    paintMode = PaintMode.ObjectSelector;
                }
            } else if (keyData == Keys.D3) {
                ckbShowTileBases.Checked = !ckbShowTileBases.Checked;
            } else if (CacheInterfaces.ToolsInterface.ProcessKeys(keyData)) {
                //Do nothing
            } else if (Camera.ProcessKeys(keyData)) {
                Camera.FixViewArea(drawArea);
                mapViewPanel.Invalidate();
            } else if (keyData == Keys.Escape) {
                input_buffer.gfx.Clear(Color.Transparent);
                paintMode = PaintMode.Off;
                mapViewPanel.Invalidate();
            } else if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.ProcessCmdKey(ref msg, keyData);
                mapViewPanel.Invalidate();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void layerSettingsChanged(object sender, EventArgs e) {
            mapViewPanel.Invalidate();
        }

        private void drawPanel_MouseUp(object sender, MouseEventArgs e) {
            if (paintMode == PaintMode.ObjectSelector) {
                input_buffer.gfx.Clear(Color.Transparent);
                mapViewPanel.Invalidate();
                ScenicHelper.MouseUp(e);
            } else if (paintMode == PaintMode.Objects) {
                mapViewPanel.Invalidate();
            } else if (paintMode == PaintMode.Portals) {
                PortalHelper.MouseUp(e);
            } else if (paintMode == PaintMode.Regions) {
                RegionHelper.MouseUp(e);
            }

            was_mouse_down = false;
        }

        private void drawPanel_MouseMove(object sender, MouseEventArgs e) {
            if (ActiveForm == this) {
                mapViewPanel.Focus();
            }

            Point tilePos = Point.Empty;
            Point worldPos = Point.Empty;
            worldPos.X = (int)(Camera.Offset.X + e.X / Camera.ZoomLevel);
            worldPos.Y = (int)(Camera.Offset.Y + e.Y / Camera.ZoomLevel);

            tilePos.X = (int)(worldPos.X / TileTemplate.PIXELS);  // Doesn't work in negative tilePos
            tilePos.Y = (int)(worldPos.Y / TileTemplate.PIXELS);  // Doesn't work in negative tilePos

            lblHighlightedCell.Text = String.Format("({0},{1})({2},{3})", tilePos.X, tilePos.Y, worldPos.X, worldPos.Y);
            
            if(paintMode == PaintMode.Objects) {
                ScenicPlacementHelper.UpdateMouse(e, input_buffer);
            } else if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.UpdateMouse(e, input_buffer);
            } else if (paintMode == PaintMode.Terrain) {
                TerrainHelper.MouseMoveOrDown(e, input_buffer);
            } else if (paintMode == PaintMode.Portals) {
                PortalHelper.UpdateMouse(e, input_buffer);
            } else if (paintMode == PaintMode.Regions) {
                RegionHelper.UpdateMouse(e, input_buffer);
            }

            mapViewPanel.Invalidate();
        }

        private void drawPanel_MouseDown(object sender, MouseEventArgs e) {
            if (paintMode == PaintMode.Objects) {
                ScenicPlacementHelper.MouseDown(e, input_buffer);
                mapViewPanel.Invalidate();
            } else if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.MouseDown(e);
            } else if (paintMode == PaintMode.Terrain) {
                TerrainHelper.MouseMoveOrDown(e, input_buffer);
            } else if (paintMode == PaintMode.Portals) {
                PortalHelper.MouseDown(e);
            } else if (paintMode == PaintMode.Regions) {
                RegionHelper.MouseDown(e);
            }
        }

        private void RedrawTerrain() {
            if (!initialized) return;

            terrain_buffer.gfx.Clear(Color.Transparent);
            objects_buffer.gfx.Clear(Color.Transparent);

            TerrainHelper.DrawTerrain(terrain_buffer);

            if (GlobalSettings.TilesEnabled) {
                PortalHelper.Draw(terrain_buffer);
                RegionHelper.Draw(terrain_buffer);
            }

            ScenicHelper.DrawObjects(objects_buffer);

            if (!GlobalSettings.TilesEnabled) {
                PortalHelper.Draw(objects_buffer);
                RegionHelper.Draw(objects_buffer);
            }
        }

        private void mapViewPanel_Resize(object sender, EventArgs e) {
            if (!initialized) return;

            drawArea = mapViewPanel.Size;
            Camera.FixViewArea(drawArea);
            CreateBuffers();

            ScenicHelper.DrawObjects(objects_buffer);

            mapViewPanel.Invalidate();
        }

        public void DrawWithObject(String objectName) {
            if (tabFirstLevel.SelectedTab == tabPalette) {
                short objectID = short.Parse(objectName);
                paintingAnimation = MapObjectCache.G(objectID).Animations["Default"];

                ScenicPlacementHelper.object_index = objectID;
                paintMode = PaintMode.Objects;
            } else if (tabFirstLevel.SelectedTab == tabTerrain) {
                paintMode = PaintMode.Terrain;
                Terrain.TerrainHelper.SetCurrentTile(short.Parse(objectName));
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            MapPieceCache.SaveIfRequired();
        }

        private void newPieceBtn_Click(object sender, EventArgs e) {
            CacheInterfaces.MapInterface.NewPiece();
        }

        private void savePieceClick(object sender, EventArgs e) {
            CacheInterfaces.MapInterface.Save();
        }

        private void deleteBtn_Click(object sender, EventArgs e) {
            CacheInterfaces.MapInterface.Delete();
        }

        private void duplicateBtn_Click(object sender, EventArgs e) {
            CacheInterfaces.MapInterface.Duplicate();
        }

        private void timerRefresh_Tick(object sender, EventArgs e) {
            //ToolCache.Animation.AnimatedObject.Update(0.05);
            mapViewPanel.Invalidate();
        }

        private void timerRedraw_Tick(object sender, EventArgs e) {
            mapViewPanel.Invalidate();
        }

        public static Control FindFocusedControl(Control control) {
            var container = control as ContainerControl;
            while (container != null) {
                control = container.ActiveControl;
                container = control as ContainerControl;
            }
            return control;
        }

        private void btnResetWorldPosition_Click(object sender, EventArgs e) {
            if (MessageBox.Show("This will move the map back to (0, 0) in the World Editor. Are you sure you want to do that?", "Warning!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                MapPieceCache.CurrentPiece.WorldPosition = Point.Empty;
                MapPieceCache.CurrentPiece.Edited();
            }
        }

        private void btnChangeBackground_Click(object sender, EventArgs e) {
            if (cbBackgroundType.Text == "Solid") {
                if (MapPieceCache.CurrentPiece.Background is SolidBackground) {
                    colorDialog.Color = (MapPieceCache.CurrentPiece.Background as SolidBackground).myColour;
                } else {
                    colorDialog.Color = Color.CornflowerBlue;
                }

                if (colorDialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel) {
                    MapPieceCache.CurrentPiece.Background = new SolidBackground(colorDialog.Color);
                    MapPieceCache.CurrentPiece.Edited();
                }
            } else {
                MessageBox.Show("Unknown background type!");
            }
        }

        public void ObjectTemplateSaved(object sender, short objectID) {
            for (int i = 0; i < ScenicHelper.drawList.Count; i++) {
                if (ScenicHelper.drawList[i].ObjectTemplate.ObjectID == objectID) {
                    ScenicHelper.drawList[i].UnlinkFromTiles();
                    ScenicHelper.drawList[i].RecalculatePosition();
                }
            }
        }

        private void listTiles_SelectedIndexChanged(object sender, EventArgs e) {
            if (listTiles.SelectedItems.Count == 1 && listTiles.SelectedItems[0].Tag is TileTemplate) {
                DrawWithObject((listTiles.SelectedItems[0].Tag as TileTemplate).TileID.ToString());
            }
        }

        private void listCritterSpawns_SubItemClicked(object sender, SubItemEventArgs e) {
            if (e.SubItem == 1) {
                listSpawnCritters.StartEditing(numSpawnChance, e.Item, e.SubItem);
            }
        }

        private void listCritterSpawns_SubItemEndEditing(object sender, SubItemEndEditingEventArgs e) {
            (e.Item.Tag as CritterSpawn).spawnChance = (float)numSpawnChance.Value;
            e.DisplayText = numSpawnChance.Value.ToString();
            MapPieceCache.CurrentPiece.Edited();
        }

        private void btnNormalizeSpawnRegion_Click(object sender, EventArgs e) {
            if(MainWindow.instance.listSpawns.SelectedItem != null) {
                if ((MainWindow.instance.listSpawns.SelectedItem as SpawnRegion).FixSpawnRates()) {
                    //Now we have to update them :(
                    foreach (ListViewItem lvi in listSpawnCritters.Items) {
                        if (lvi.Tag is CritterSpawn) {
                            lvi.SubItems[1].Text = (lvi.Tag as CritterSpawn).spawnChance.ToString();
                        }
                    }

                    MapPieceCache.CurrentPiece.Edited();
                }
            }
        }

        private void listObjects_SelectedIndexChanged(object sender, EventArgs e) {
            if (listObjects.SelectedItems.Count == 1 && listObjects.SelectedItems[0].Tag is MapObject) {
                DrawWithObject((listObjects.SelectedItems[0].Tag as MapObject).ObjectID.ToString());
            }
        }

        private void scriptMap_BeforeParse(object sender, ScriptInfoArgs e) {
            ExportCrushers.CurrentMap = MapPieceCache.CurrentPiece;
        }

        private void btnOpenAdvanced_Click(object sender, EventArgs e) {
            CacheInterfaces.ToolsInterface.OpenVariableEditor();
        }
    }
}
