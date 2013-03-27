using System;
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
        public Rectangle drawArea = new Rectangle();
        public PaintMode paintMode = PaintMode.Off;

        //Our drawing buffers
        public LBuffer terrain_buffer;
        public LBuffer objects_buffer;
        public LBuffer input_buffer;

        public LBuffer minimapBuffer;

        //Terrain painting things
        public Brush terrainPaintBrush = new SolidBrush(Color.White);

        //Object painting things
        public Bitmap obj_paint_image = null;
        public String obj_paint_original = "";
        public bool was_mouse_down = false;

        public bool initialized = false;

        // Places copying things
        private int b_resources_copy = -1;
        private short b_NPC_copy = -1;

        public MainWindow() {
            instance = this;

            InitializeComponent();

            CacheInterfaces.MapInterface.Initialize();
            Terrain.TerrainHelper.InitializeTerrainSystem(tilesCB, panelTiles);

            pnlObjectScenicCache.Controls.Add(new ObjectCacheControl());

            List<String> dark = new List<string>();
            dark.InsertRange(0, Directory.GetDirectories("objcache"));

            for(int i = 0; i < dark.Count; i++) {
                dark[i] = dark[i].Split('\\')[1];
            }

            cbScenicCacheSelector.DataSource = dark;

            drawArea = mapViewPanel.DisplayRectangle;
            Camera.FixViewArea(drawArea);

            initialized = true;
            CreateBuffers();
        }

        private void CreateBuffers() {
            if (!initialized) return;

            drawArea = mapViewPanel.DisplayRectangle;

            terrain_buffer = new LBuffer(drawArea);
            objects_buffer = new LBuffer(drawArea);
            input_buffer = new LBuffer(drawArea);

            mapViewPanel.Invalidate();
        }

        private void mapViewPanel_Paint(object sender, PaintEventArgs e) {
            if (!initialized) return;
            if (REQUIRES_CLOSE) { this.Close(); return; }

            drawArea = e.ClipRectangle;
            e.Graphics.FillRectangle(new SolidBrush(BACKGROUND_COLOR), e.ClipRectangle);

            RedrawTerrain();

            e.Graphics.DrawImage(terrain_buffer.bmp, Point.Empty);
            e.Graphics.DrawImage(objects_buffer.bmp, Point.Empty);

            if (paintMode != PaintMode.Off) e.Graphics.DrawImage(input_buffer.bmp, Point.Empty);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (txtPieceName.Focused) return base.ProcessCmdKey(ref msg, keyData);

            this.ActiveControl = mapViewPanel;

            if (Camera.ProcessKeys(keyData)) {
                Camera.FixViewArea(drawArea);
                mapViewPanel.Invalidate();
            } else if (keyData == Keys.Escape) {
                input_buffer.gfx.Clear(Color.Transparent);
                paintMode = PaintMode.Off;
                mapViewPanel.Invalidate();
            } else if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.ProcessCmdKey(ref msg, keyData);
                mapViewPanel.Invalidate();
            } else if (keyData == Keys.T) {
                TileEditor t = new TileEditor();
                t.ShowDialog(this);
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
            BaseObjectDrawer.DrawObjects(objects_buffer);
        }

        private void mapViewPanel_Resize(object sender, EventArgs e) {
            if (!initialized) return;

            drawArea = mapViewPanel.DisplayRectangle;
            Camera.FixViewArea(drawArea);
            CreateBuffers();

            BaseObjectDrawer.DrawObjects(objects_buffer);

            mapViewPanel.Invalidate();
        }

        public void DrawWithObject(String objectName) {
            if (tabFirstLevel.SelectedTab == tabPalette) {
                obj_paint_original = objectName;
                obj_paint_image = (Bitmap)ImageCache.RequestImage(objectName);

                if (tabObjectTools.SelectedTab == tabObjects) {
                    //TODO: Reimplement this;
                    //ScenicPlacementHelper.object_index = ScenicObjectCache.s_StringToInt[objectName];//objectName;
                    paintMode = PaintMode.Objects;
                }
            } else if (tabFirstLevel.SelectedTab == tabTerrain) {
                paintMode = PaintMode.Terrain;
                Terrain.TerrainHelper.SetCurrentTile(Terrain.TerrainHelper.StripTileIDFromPath(objectName));
            }
        }

        private void obj_settings_ValueChanged(object sender, EventArgs e) {
            if (obj_paint_original != null && obj_paint_original.Length > 3) {
                obj_paint_image = (Bitmap)ImageCache.RequestImage(obj_paint_original);
                drawPanel_ME_move(null, new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, 0, 0, 0));
            }
        }

        private void obj_select_btn_Click(object sender, EventArgs e) {
            paintMode = PaintMode.ObjectSelector;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            //TODO: Save caches here probably
            MapPieceCache.SaveIfRequired();
        }

        private void obj_scenary_cache_CB_SelectionChangeCommitted(object sender, EventArgs e) {
            (pnlObjectScenicCache.Controls[0] as ObjectCacheControl).Activate(cbScenicCacheSelector.SelectedValue.ToString());
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
            (panelTiles.Controls[0] as ObjectCacheControl).Activate(tilesCB.SelectedValue.ToString());
        }
    }
}
