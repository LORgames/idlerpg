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
using ToolCache.Combat.Elements;
using ToolCache.Items;
using ToolCache.Equipment;
using System.Diagnostics;
using System.Threading;
using CityTools.Terrain;
using System.Drawing.Imaging;

namespace CityTools {
    public enum PaintMode {
        Off,
        Terrain,
        Objects,
        ObjectSelector
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

            CacheInterfaces.MapInterface.Initialize();
            CacheInterfaces.TileInterface.Initialize();
            CacheInterfaces.ObjectInterface.Initialize();
            CacheInterfaces.SoundInterface.PopulateList();
            CacheInterfaces.ToolsInterface.Initialize();

            drawArea = mapViewPanel.Size;
            Camera.FixViewArea(drawArea);

            initialized = true;
            CreateBuffers();

            timerRefresh.Start();
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
            if (txtPieceName.Focused) return base.ProcessCmdKey(ref msg, keyData);

            this.ActiveControl = mapViewPanel;

            if (keyData == Keys.D1) {
                ckbShowTileGrid.Checked = !ckbShowTileGrid.Checked;
            } else if (keyData == Keys.D2) {
                ckbShowObjectBases.Checked = !ckbShowObjectBases.Checked;
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

        private void drawPanel_ME_up(object sender, MouseEventArgs e) {
            if (paintMode == PaintMode.ObjectSelector) {
                input_buffer.gfx.Clear(Color.Transparent);
                mapViewPanel.Invalidate();
                ScenicHelper.MouseUp(e);
            } else if (paintMode == PaintMode.Objects) {
                mapViewPanel.Invalidate();
            }

            was_mouse_down = false;
        }

        private void drawPanel_ME_move(object sender, MouseEventArgs e) {
            if (ActiveForm == this) {
                mapViewPanel.Focus();
            }
            
            if(paintMode == PaintMode.Objects) {
                ScenicPlacementHelper.UpdateMouse(e, input_buffer);
            } else if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.UpdateMouse(e, input_buffer);
            } else if (paintMode == PaintMode.Terrain) {
                Terrain.TerrainHelper.MouseMoveOrDown(e, input_buffer);
            }

            mapViewPanel.Invalidate();
        }

        private void drawPanel_ME_down(object sender, MouseEventArgs e) {
            if (paintMode == PaintMode.Objects) {
                ScenicPlacementHelper.MouseDown(e, input_buffer);
                mapViewPanel.Invalidate();
            } else if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.MouseDown(e);
            } else if (paintMode == PaintMode.Terrain) {
                Terrain.TerrainHelper.MouseMoveOrDown(e, input_buffer);
            }
        }

        private void RedrawTerrain() {
            if (!initialized) return;

            terrain_buffer.gfx.Clear(Color.Transparent);
            objects_buffer.gfx.Clear(Color.Transparent);

            Terrain.TerrainHelper.DrawTerrain(terrain_buffer);
            ScenicHelper.DrawObjects(objects_buffer);
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
                paintingAnimation = TemplateCache.G(objectID).Animation;

                if (tabObjectTools.SelectedTab == tabObjects) {
                    ScenicPlacementHelper.object_index = objectID;
                    paintMode = PaintMode.Objects;
                }
            } else if (tabFirstLevel.SelectedTab == tabTerrain) {
                paintMode = PaintMode.Terrain;
                Terrain.TerrainHelper.SetCurrentTile(short.Parse(objectName));
            }
        }

        private void obj_select_btn_Click(object sender, EventArgs e) {
            paintMode = PaintMode.ObjectSelector;
            ckbShowObjectBases.Checked = true;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            MapPieceCache.SaveIfRequired();
        }

        private void obj_scenary_cache_CB_SelectionChangeCommitted(object sender, EventArgs e) {
            CacheInterfaces.ObjectInterface.UpdateObjectPage();
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

        private void cbTile_SelectedIndexChanged(object sender, EventArgs e) {
            (pnlTiles.Controls[0] as ObjectCacheControl).Deactivate();
            CacheInterfaces.TileInterface.UpdateTilePage();
        }

        private void timerRefresh_Tick(object sender, EventArgs e) {
            ToolCache.Animation.AnimatedObject.Update(0.05);
            mapViewPanel.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            mapViewPanel.Invalidate();
        }

        private void btnAddPortal_Click(object sender, EventArgs e) {

        }

        private void btnDeletePortals_Click(object sender, EventArgs e) {

        }
    }
}
