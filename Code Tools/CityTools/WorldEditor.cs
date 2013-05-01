using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolCache.Map;
using ToolCache.Drawing;
using CityTools.Core;
using ToolCache.World;

namespace CityTools {
    internal enum WorldEditMode {
        Move,
        AddLink,
        RemoveLink
    }

    public partial class WorldEditor : Form {
        private List<WorldData> Data = new List<WorldData>();
        private LBuffer buffer;

        private Point Offset = new Point();

        private bool isMouseDown = false;

        private WorldData selectedObject = null;
        private Portal selectedPortal = null;

        private Point p0 = Point.Empty;
        private Point p1 = Point.Empty;

        private WorldEditMode EditMode = WorldEditMode.Move;

        private Pen PortalPen_OneWay = new Pen(Color.Orange, 5);
        private Pen PortalPen_TwoWay = new Pen(Color.Magenta, 5);

        public WorldEditor() {
            InitializeComponent();

            foreach (MapPiece p in MapPieceCache.Pieces) {
                Data.Add(new WorldData(p));
            }

            buffer = new LBuffer(pbMainPanel.Size);

            PortalPen_OneWay.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            PortalPen_TwoWay.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            PortalPen_TwoWay.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        }

        private void pbMainPanel_Paint(object sender, PaintEventArgs e) {
            buffer.gfx.Clear(Color.Beige);

            foreach (WorldData d in Data) {
                d.Draw(buffer, Offset);
            }

            foreach (Portal portal0 in Portals.Data.Values) {
                if (portal0.ExitID > 0 && portal0.ExitID != portal0.ID && Portals.Data.ContainsKey(portal0.ExitID)) {
                    int x1 = portal0.Map.WorldPosition.X + portal0.ExitPoint.X / 10 + Offset.X;
                    int y1 = portal0.Map.WorldPosition.Y + portal0.ExitPoint.Y / 10 + Offset.Y;

                    Portal portal1 = Portals.Data[portal0.ExitID];
                    int x2 = portal1.Map.WorldPosition.X + portal1.ExitPoint.X / 10 + Offset.X;
                    int y2 = portal1.Map.WorldPosition.Y + portal1.ExitPoint.Y / 10 + Offset.Y;

                    System.Diagnostics.Debug.WriteLine(x1 + ", " + y2 + " => " + x2 + ", " + y2);

                    if (portal1.ExitID == portal0.ID) {
                        buffer.gfx.DrawLine(PortalPen_TwoWay, x1, y1, x2, y2);
                    } else {
                        buffer.gfx.DrawLine(PortalPen_OneWay, x1, y1, x2, y2);
                    }
                }
            }

            if (EditMode == WorldEditMode.AddLink && selectedPortal != null && isMouseDown) {
                buffer.gfx.DrawLine(PortalPen_OneWay, p0.X + Offset.X, p0.Y + Offset.Y, p1.X + Offset.X, p1.Y + Offset.Y);
            }

            e.Graphics.DrawImage(buffer.bmp, Point.Empty);
        }

        private void WorldEditor_FormClosing(object sender, FormClosingEventArgs e) {
            foreach (WorldData d in Data) {
                d.Dispose();
            }

            Data.Clear();
        }

        private void pbMainPanel_Resize(object sender, EventArgs e) {
            buffer.Dispose();
            buffer = new LBuffer(pbMainPanel.Size);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.W) {
                Offset.Y += 25;
            } else if (keyData == Keys.S) {
                Offset.Y -= 25;
            } else if (keyData == Keys.A) {
                Offset.X += 25;
            } else if (keyData == Keys.D) {
                Offset.X -= 25;
            }

            pbMainPanel.Invalidate();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Portal SelectPortal(MouseEventArgs e) {
            Rectangle r = new Rectangle(0, 0, 16, 16);

            Point _p = Point.Empty;
            _p.X = e.X - Offset.X;
            _p.Y = e.Y - Offset.Y;

            foreach (WorldData d in Data) {
                if (d.rect.Contains(_p)) {
                    foreach (Portal p in d.myPiece.Portals) {
                        r.X = p.ExitPoint.X / 10 + d.rect.X + Offset.X - 8;
                        r.Y = p.ExitPoint.Y / 10 + d.rect.Y + Offset.Y - 8;

                        if (r.Contains(e.Location)) {
                            return p;
                        }
                    }
                }
            }

            return null;
        }

        private void pbMainPanel_MouseDown(object sender, MouseEventArgs e) {
            isMouseDown = true;

            p0.X = e.X - Offset.X;
            p0.Y = e.Y - Offset.Y;

            selectedObject = null;
            
            foreach (WorldData d in Data) {
                if (d.rect.Contains(p0)) {
                    selectedObject = d;
                    break;
                }
            }

            if (EditMode == WorldEditMode.AddLink || EditMode == WorldEditMode.RemoveLink) {
                selectedPortal = SelectPortal(e);

                if (EditMode == WorldEditMode.RemoveLink) {
                    selectedPortal.ExitID = selectedPortal.ID;
                    selectedPortal = null;
                    selectedObject = null;
                }
            }


            if (selectedObject == null) isMouseDown = false;
        }

        private void pbMainPanel_MouseMove(object sender, MouseEventArgs e) {
            if (isMouseDown) {
                p1.X = e.X - Offset.X;
                p1.Y = e.Y - Offset.Y;

                if (EditMode == WorldEditMode.Move) {
                    int dx = p1.X - p0.X;
                    int dy = p1.Y - p0.Y;

                    selectedObject.rect.Offset(new Point(dx, dy));

                    selectedObject.myPiece.WorldPosition = selectedObject.rect.Location;

                    p0.X = p1.X;
                    p0.Y = p1.Y;
                }

                pbMainPanel.Invalidate();
            }
        }

        private void pbMainPanel_MouseUp(object sender, MouseEventArgs e) {
            isMouseDown = false;
            pbMainPanel.Invalidate();

            if (EditMode == WorldEditMode.AddLink) {
                Portal p2 = SelectPortal(e);

                if (selectedPortal != null) {
                    if (p2 != null && selectedPortal != p2) {
                        selectedPortal.ExitID = p2.ID;
                    } else {
                        selectedPortal.ExitID = selectedPortal.ID;
                    }

                    selectedPortal.Map.Save();
                } 
            }
        }

        private void pbMainPanel_MouseLeave(object sender, EventArgs e) {
            isMouseDown = false;
        }

        private void btnMoveMode_Click(object sender, EventArgs e) {
            EditMode = WorldEditMode.Move;
        }

        private void btnLinkAdd_Click(object sender, EventArgs e) {
            EditMode = WorldEditMode.AddLink;
        }
    }

    public class WorldData {
        private Image image;
        private static Image portalIcon;

        public Rectangle rect;
        public Rectangle ScrolledAABB = new Rectangle();
        public Rectangle PortalRect = new Rectangle(0, 0, 16, 16);

        public MapPiece myPiece;

        public WorldData(MapPiece piece) {
            if (portalIcon == null) {
                portalIcon = Image.FromFile("Icons/PortalIcon.png");
            }

            image = Image.FromFile("Maps/Thumbs/" + piece.Name + ".png");
            rect = new Rectangle(piece.WorldPosition, image.Size);

            myPiece = piece;

            if (!piece.isLoaded) {
                piece.Load(true);
            }
        }

        public void Draw(LBuffer buffer, Point offset) {
            ScrolledAABB.X = rect.X + offset.X;
            ScrolledAABB.Y = rect.Y + offset.Y;
            ScrolledAABB.Width = rect.Width;
            ScrolledAABB.Height = rect.Height;

            buffer.gfx.DrawImage(image, ScrolledAABB);
            buffer.gfx.DrawRectangle(Pens.Black, ScrolledAABB);

            foreach(Portal p in myPiece.Portals) {
                PortalRect.X = p.ExitPoint.X/10 + rect.X + offset.X - 8;
                PortalRect.Y = p.ExitPoint.Y/10 + rect.Y + offset.Y - 8;

                buffer.gfx.DrawImage(portalIcon, PortalRect);
            }
        }

        public void Dispose() {
            if (myPiece.WorldPosition.X != rect.X || myPiece.WorldPosition.Y != rect.Y) {
                myPiece.WorldPosition.X = rect.X;
                myPiece.WorldPosition.Y = rect.Y;

                myPiece.Save();
            }

            image.Dispose();
            image = null;
        }
    }
}
