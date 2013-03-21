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
using CityTools.Places;
using CityTools.Physics;
using CityTools.MapPieces;

namespace CityTools {
    public enum PaintMode {
        Off,
        Terrain,
        Objects,
        Places,
        Physics,
        ObjectSelector,
        PlacesSelector,
    }

    public partial class MainWindow : Form {
        public Color BACKGROUND_COLOR = Color.CornflowerBlue;

        public static MainWindow instance;
        public bool REQUIRES_CLOSE = false;

        //Our drawing settings
        public Rectangle drawArea = new Rectangle();
        public PaintMode paintMode = PaintMode.Off;

        //Our drawing buffers
        public LBuffer terrain_buffer;
        public LBuffer objects0_buffer;
        public LBuffer places_buffer;
        public LBuffer objects1_buffer;
        public LBuffer physics_buffer;
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

            Box2D.B2System.Initialize();

            ScenicObjectCache.InitializeCache();
            PlacesObjectCache.InitializeCache();
            Terrain.MapCache.VerifyCacheFiles();

            MapPieceCache.Initialize();
            Terrain.TerrainHelper.InitializeTerrainSystem(tilesCB, tilesPanel);

            obj_scenary_objs.Controls.Add(new ObjectCacheControl());
            places_tab.Controls.Add(new ObjectCacheControl(PlacesObjectCache.PLACES_FOLDER, false));

            List<String> dark = new List<string>();
            dark.InsertRange(0, Directory.GetDirectories("objcache"));

            for(int i = 0; i < dark.Count; i++) {
                dark[i] = dark[i].Split('\\')[1];
            }

            obj_scenary_cache_CB.DataSource = dark;

            drawArea = mapViewPanel.DisplayRectangle;
            Camera.FixViewArea(drawArea);

            initialized = true;
            CreateBuffers();
        }

        private void CreateBuffers() {
            if (!initialized) return;

            drawArea = mapViewPanel.DisplayRectangle;

            terrain_buffer = new LBuffer();
            objects0_buffer = new LBuffer();
            places_buffer = new LBuffer();
            objects1_buffer = new LBuffer();
            physics_buffer = new LBuffer();
            input_buffer = new LBuffer();

            mapViewPanel.Invalidate();
        }

        private void mapViewPanel_Paint(object sender, PaintEventArgs e) {
            if (!initialized) return;
            if (REQUIRES_CLOSE) { this.Close(); return; }

            drawArea = e.ClipRectangle;
            e.Graphics.FillRectangle(new SolidBrush(BACKGROUND_COLOR), e.ClipRectangle);

            RedrawTerrain();

            e.Graphics.DrawImage(terrain_buffer.bmp, Point.Empty);
            e.Graphics.DrawImage(objects0_buffer.bmp, Point.Empty);
            e.Graphics.DrawImage(places_buffer.bmp, Point.Empty);
            e.Graphics.DrawImage(objects1_buffer.bmp, Point.Empty);
            e.Graphics.DrawImage(physics_buffer.bmp, Point.Empty);

            if (paintMode != PaintMode.Off) e.Graphics.DrawImage(input_buffer.bmp, Point.Empty);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (txtPieceName.Focused) return base.ProcessCmdKey(ref msg, keyData);

            System.Diagnostics.Debug.WriteLine(this.ActiveControl);

            this.ActiveControl = mapViewPanel;

            if (Camera.ProcessKeys(keyData)) {
                Camera.FixViewArea(drawArea);
                mapViewPanel.Invalidate();
            } else if (keyData == Keys.Escape) {
                input_buffer.gfx.Clear(Color.Transparent);
                paintMode = PaintMode.Off;
                mapViewPanel.Invalidate();
            } else if (keyData == Keys.R) {
                if (obj_rot.Value < 315) { obj_rot.Value += 45; } else { obj_rot.Value = 0; }
            } else if (keyData == Keys.F) {
                if (obj_rot.Value > 0) { obj_rot.Value -= 45; } else { obj_rot.Value = 315; }
            } else if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.ProcessCmdKey(ref msg, keyData);
                mapViewPanel.Invalidate();
            } else if (paintMode == PaintMode.PlacesSelector) {
                if (keyData == (Keys.Control | Keys.C)) {
                    //Copy Data
                    if (PlacesHelper.selectedObjects.Count == 1) {
                        b_resources_copy = PlacesHelper.selectedObjects[0].b_resources;
                        b_NPC_copy = PlacesHelper.selectedObjects[0].b_NPC;
                        paintMode = PaintMode.Places;
                        PlacesPlacementHelper.object_index = PlacesHelper.selectedObjects[0].object_index;
                        DrawWithObject(PlacesObjectCache.s_objectTypes[PlacesHelper.selectedObjects[0].object_index].ImageName);
                    }
                } else {
                    PlacesHelper.ProcessCmdKey(ref msg, keyData);
                    mapViewPanel.Invalidate();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void layerSettingsChanged(object sender, EventArgs e) {
            mapViewPanel.Invalidate();
        }

        private void drawPanel_ME_up(object sender, MouseEventArgs e) {
            if (paintMode == PaintMode.Physics) {
                Physics.PhysicsDrawer.ReleaseMouse(e);
                input_buffer.gfx.Clear(Color.Transparent);
                mapViewPanel.Invalidate();
            } else if (paintMode == PaintMode.ObjectSelector) {
                input_buffer.gfx.Clear(Color.Transparent);
                mapViewPanel.Invalidate();
                ScenicHelper.MouseUp(e);
            } else if (paintMode == PaintMode.PlacesSelector) {
                input_buffer.gfx.Clear(Color.Transparent);
                mapViewPanel.Invalidate();
                PlacesHelper.MouseUp(e);
            } else if (paintMode == PaintMode.Objects || paintMode == PaintMode.Places) {
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
            } else if (paintMode == PaintMode.Places) {
                PlacesPlacementHelper.UpdateMouse(e, input_buffer);
            } else if (paintMode == PaintMode.Physics) {
                Physics.PhysicsDrawer.UpdateMouse(e, input_buffer);
            } else if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.UpdateMouse(e, input_buffer);
            } else if (paintMode == PaintMode.PlacesSelector) {
                PlacesHelper.UpdateMouse(e, input_buffer);
            } else if (paintMode == PaintMode.Terrain) {
                Terrain.TerrainHelper.MouseMoveOrDown(e, input_buffer);
            }

            mapViewPanel.Invalidate();
        }

        private void drawPanel_ME_down(object sender, MouseEventArgs e) {
            if (paintMode == PaintMode.Objects) {
                ScenicPlacementHelper.MouseDown(e, input_buffer);
                mapViewPanel.Invalidate();
            } else if (paintMode == PaintMode.Places) {
                // Send through details of copied stuff
                if (b_NPC_copy != -1 || b_resources_copy != -1) {
                    PlacesPlacementHelper.CopiedData(b_resources_copy, b_NPC_copy);
                    b_resources_copy = -1;
                    b_NPC_copy = -1;
                }
                PlacesPlacementHelper.MouseDown(e, input_buffer);
                mapViewPanel.Invalidate();
            } else if (paintMode == PaintMode.Physics) {
                Physics.PhysicsDrawer.MouseDown(e, input_buffer);
            } else if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.MouseDown(e);
            } else if (paintMode == PaintMode.PlacesSelector) {
                PlacesHelper.MouseDown(e);
            } else if (paintMode == PaintMode.Terrain) {
                Terrain.TerrainHelper.MouseMoveOrDown(e, input_buffer);
            }
        }

        private void RedrawTerrain() {
            if (!initialized) return;

            terrain_buffer.gfx.Clear(Color.Transparent);
            objects0_buffer.gfx.Clear(Color.Transparent);
            places_buffer.gfx.Clear(Color.Transparent);
            objects1_buffer.gfx.Clear(Color.Transparent);
            physics_buffer.gfx.Clear(Color.Transparent);

            Terrain.TerrainHelper.DrawTerrain(terrain_buffer);
            BaseObjectDrawer.DrawObjects(objects0_buffer, objects1_buffer, places_buffer, physics_buffer);
        }

        private void mapViewPanel_Resize(object sender, EventArgs e) {
            if (!initialized) return;

            drawArea = mapViewPanel.DisplayRectangle;
            Camera.FixViewArea(drawArea);
            CreateBuffers();

            BaseObjectDrawer.DrawObjects(objects0_buffer, objects1_buffer, places_buffer, physics_buffer);

            mapViewPanel.Invalidate();
        }

        public void DrawWithObject(String objectName) {
            if (first_level_tabControl.SelectedTab == palette_tab) {
                obj_paint_original = objectName;
                obj_paint_image = (Bitmap)ImageCache.RequestImage(objectName, (int)obj_rot.Value);

                if (tool_tabs.SelectedTab == objects_tab) {
                    ScenicPlacementHelper.object_index = ScenicObjectCache.s_StringToInt[objectName];//objectName;
                    paintMode = PaintMode.Objects;
                } else if (tool_tabs.SelectedTab == places_tab) {
                    PlacesPlacementHelper.object_index = PlacesObjectCache.s_StringToInt[objectName];//objectName;
                    paintMode = PaintMode.Places;
                }
            } else if (first_level_tabControl.SelectedTab == terrain_tab) {
                paintMode = PaintMode.Terrain;
                Terrain.TerrainHelper.SetCurrentTile(Terrain.TerrainHelper.StripTileIDFromPath(objectName));
            }
        }

        private void obj_settings_ValueChanged(object sender, EventArgs e) {
            if (obj_paint_original != null && obj_paint_original.Length > 3) {
                obj_paint_image = (Bitmap)ImageCache.RequestImage(obj_paint_original, (int)obj_rot.Value);
                drawPanel_ME_move(null, new MouseEventArgs(System.Windows.Forms.MouseButtons.None, 0, 0, 0, 0));
            }
        }

        private void phys_add_shape(object sender, EventArgs e) {
            paintMode = PaintMode.Physics;
            Physics.PhysicsDrawer.SetShape(((Button)sender).Name);
        }

        private void obj_select_btn_Click(object sender, EventArgs e) {
            paintMode = PaintMode.ObjectSelector;
        }

        private void places_select_btn_Click(object sender, EventArgs e) {
            paintMode = PaintMode.PlacesSelector;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            ScenicObjectCache.SaveTypes();
            PlacesObjectCache.SaveTypes();
        }

        private void obj_scenary_cache_CB_SelectionChangeCommitted(object sender, EventArgs e) {
            (obj_scenary_objs.Controls[0] as ObjectCacheControl).Activate(obj_scenary_cache_CB.SelectedValue.ToString());
        }

        private void tsmSendBack_Click(object sender, EventArgs e) {
            if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.SendBack();
            } else if (paintMode == PaintMode.PlacesSelector) {
                PlacesHelper.SendBack();
            }

            // Get the window to redraw
            mapViewPanel.Invalidate();
        }

        private void tsmBringForward_Click(object sender, EventArgs e) {
            if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.BringForward();
            } else if (paintMode == PaintMode.PlacesSelector) {
                PlacesHelper.BringForward();
            }

            // Get the window to redraw
            mapViewPanel.Invalidate();
        }
        
        private void tsmSendToBack_Click(object sender, EventArgs e) {
            if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.SendToBack();
            } else if (paintMode == PaintMode.PlacesSelector) {
                PlacesHelper.SendToBack();
            }

            // Get the window to redraw
            mapViewPanel.Invalidate();
        }

        private void tsmBringToFront_Click(object sender, EventArgs e) {
            if (paintMode == PaintMode.ObjectSelector) {
                ScenicHelper.BringToFront();
            } else if (paintMode == PaintMode.PlacesSelector) {
                PlacesHelper.BringToFront();
            }

            // Get the window to redraw
            mapViewPanel.Invalidate();
        }

        private void newPieceBtn_Click(object sender, EventArgs e) {
            MapPieceCache.CreateNew();
        }

        private void savePieceClick(object sender, EventArgs e) {
            MapPieceCache.CurrentPiece.Save();
        }

        private void deleteBtn_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to delete '"+MapPieceCache.CurrentPiece.Name+"'?", "Delete?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                MapPieceCache.DeleteCurrent();
            }
        }

        private void duplicateBtn_Click(object sender, EventArgs e) {
            MapPieceCache.Duplicate();
        }

        private void tilesCB_SelectedIndexChanged(object sender, EventArgs e) {
            (tilesPanel.Controls[0] as ObjectCacheControl).Activate(tilesCB.SelectedValue.ToString());
        }
    }
}
