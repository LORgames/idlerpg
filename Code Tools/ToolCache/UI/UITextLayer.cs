using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;
using ToolCache.Scripting;
using ToolCache.Scripting.Extensions;
using ToolCache.General;

namespace ToolCache.UI {
    public class UITextLayer : UILayer {
        public string Message = "";

        public UIAnchorPoint Align = UIAnchorPoint.TopLeft;
        public int FontFamily = 0;
        public int FontSize = 20;
        
        public bool WordWrap = false;
        public byte InputType = 0;

        public Color Colour = Color.White;

        protected override void ReadFromBinaryIOX(General.BinaryIO f) {
            base.ReadFromBinaryIOX(f);
            Message = f.GetString();

            Align = (UIAnchorPoint)f.GetByte();
            FontFamily = f.GetByte();
            FontSize = f.GetByte();

            byte info = f.GetByte();

            WordWrap = (info & 1) == 1;
            InputType = (byte)(info>>1);

            Colour = Color.FromArgb(f.GetInt());
        }

        internal override void WriteToBinaryIO(General.BinaryIO f) {
            base.WriteToBinaryIO(f);
            f.AddString(Message);

            f.AddByte((byte)Align);
            f.AddByte((byte)FontFamily);
            f.AddByte((byte)FontSize);

            byte info = (byte)((WordWrap ? 1 : 0) | (InputType<<1));
            f.AddByte(info);

            f.AddInt(Colour.ToArgb());
        }

        public string PrepareString(bool rawID = false) {
            Regex regex = new Regex("{(~?[A-Za-z0-9_>]*):?([0-9]+)?}");
            MatchCollection mc = regex.Matches(Message);

            if (mc.Count > 0) {
                string builder = "";
                int i = 0;
                int last_end = 0;

                for(i = 0; i < mc.Count; i++) {
                    builder = builder + Message.Substring(last_end, mc[i].Index-last_end);

                    int paddingLength = 0;
                    if (mc[i].Groups[2].Success) {
                        int.TryParse(mc[i].Groups[2].Value, out paddingLength);
                    }

                    if (mc[i].Groups[1].Value[0] == '~') { //Database entry
                        builder = builder + LinkDatabase(mc[i].Groups[1].Value.Substring(1), rawID);
                    } else if(Variables.GlobalVariables.ContainsKey(mc[i].Groups[1].Value)) {
                        if (!rawID) {
                            builder = builder + Variables.GlobalVariables[mc[i].Groups[1].Value].InitialValue.ToString().PadLeft(paddingLength, '0');
                        } else {
                            builder = builder + "{" + Variables.GlobalVariables[mc[i].Groups[1].Value].Index + "}";
                        }
                    } else {
                        builder = builder + "<UNKNOWN VAR>";
                    }

                    last_end = mc[i].Index + mc[i].Length;
                }

                builder = builder + Message.Substring(last_end);

                return builder;
            }

            return Message;
        }

        private string LinkDatabase(string databaseIdentifier, bool isRaw) {
            if (databaseIdentifier[0] != '~') {
                return "BAD DATABASE INDICATOR";
            }

            if (databaseIdentifier.Length < 6) {
                return "BAD DATABASE LENGTH!";
            }

            string[] subParamBits = databaseIdentifier.Substring(1).Split('>');
            short sparam;
            bool useVar;

            if (subParamBits.Length == 3) {
                string database = subParamBits[0];
                string column = subParamBits[1];
                string row = subParamBits[2];

                DataLibrary.DBLibrary lib = DataLibrary.DBLibraryManager.GetLibrary(database);

                if (lib == null) {
                    return "Cannot find a database named '" + database + "'";
                }

                if (isRaw && ExportCrushers.RemappedDatabaseNames != null) {
                    if (ExportCrushers.RemappedDatabaseNames.ContainsKey(database)) {
                        AdditionalBytecode.Add((ushort)ExportCrushers.RemappedDatabaseNames[database]);
                    } else {
                        return "The database was not compiled for exporting. Perhaps it is empty?";
                    }
                }
                

                sparam = 0;
                useVar = false;

                //Now find the column
                if (!short.TryParse(column, out sparam)) {
                    if (!VariableExists(column, info)) {
                        sparam = (short)lib.GetColumnID(column);
                        if (sparam == -1) {
                            return "Cannot find a column called '" + column + "'";
                        }
                    } else {
                        useVar = true;
                    }
                }

                if (!useVar && lib.Column_Names.Count <= sparam) {
                    return "Database '" + database + "' does not have " + sparam + " columns!";
                }

                if (useVar) {
                    WriteVariableIfExists(column, info);
                } else {
                    WriteVariableIfExists(sparam.ToString(), info);
                }

                //Now find the row
                sparam = 0;
                useVar = false;

                if (!WriteVariableIfExists(row, info)) {
                    return "Sorry, we don't yet support named rows!";
                }

                if (lib.Rows.Count > sparam) {
                    AdditionalBytecode.Add((ushort)sparam);
                } else {
                    info.Errors.Add("Database '" + database + "' does not have " + sparam + " rows!" + ErrorEnding());
                    return false;
                }
            } else {
                return "You need 3 parts for a database ID!";
            }

            return "Unexpected issue? Shouldn't have gotten here!";
        }

        internal override void Draw(System.Drawing.Graphics gfx, System.Drawing.Rectangle canvasArea, UIElement owner, float displayValue, bool drawRect) {
            if (this.Message != "") {
                string displayString = PrepareString();

                Font f = new Font(UIManager.Fonts[FontFamily], FontSize);
                SizeF size = gfx.MeasureString(displayString, f, WordWrap?SizeX:0);

                RectangleF r = new RectangleF(0, 0, WordWrap?SizeX:size.Width, size.Height);
                StringFormat format = new StringFormat();

                //Calculate X
                switch (AnchorPoint) {
                    case UIAnchorPoint.BottomLeft:
                    case UIAnchorPoint.MiddleLeft:
                    case UIAnchorPoint.TopLeft:
                        r.X = OffsetX;
                        break;
                    case UIAnchorPoint.BottomRight:
                    case UIAnchorPoint.MiddleRight:
                    case UIAnchorPoint.TopRight:
                        r.X = canvasArea.Width - SizeX - OffsetX;
                        break;
                    default:
                        r.X = (canvasArea.Width - SizeX) / 2 + OffsetX;
                        break;
                }

                //Calculate Y
                switch (AnchorPoint) {
                    case UIAnchorPoint.BottomLeft:
                    case UIAnchorPoint.BottomCenter:
                    case UIAnchorPoint.BottomRight:
                        r.Y = canvasArea.Height - SizeY - OffsetY;
                        break;
                    case UIAnchorPoint.TopLeft:
                    case UIAnchorPoint.TopCenter:
                    case UIAnchorPoint.TopRight:
                        r.Y = OffsetY;
                        break;
                    default:
                        r.Y = (canvasArea.Height - SizeY) / 2 + OffsetY;
                        break;
                }

                //Calculate X
                switch (Align) {
                    case UIAnchorPoint.BottomCenter:
                    case UIAnchorPoint.MiddleCenter:
                    case UIAnchorPoint.TopCenter:
                        if (WordWrap) {
                            format.Alignment = StringAlignment.Center;
                        } else {
                            r.X -= size.Width / 2;
                        }
                        break;
                    case UIAnchorPoint.BottomRight:
                    case UIAnchorPoint.MiddleRight:
                    case UIAnchorPoint.TopRight:
                        if (WordWrap) {
                            format.Alignment = StringAlignment.Far;
                        } else {
                            r.X -= size.Width;
                        }
                        break;
                }

                //Calculate Y
                switch (Align) {
                    case UIAnchorPoint.BottomLeft:
                    case UIAnchorPoint.BottomCenter:
                    case UIAnchorPoint.BottomRight:
                        r.Y -= size.Height;
                        break;
                    case UIAnchorPoint.MiddleLeft:
                    case UIAnchorPoint.MiddleCenter:
                    case UIAnchorPoint.MiddleRight:
                        r.Y -= size.Height / 2;
                        break;
                }

                r.X += canvasArea.X;
                r.Y += canvasArea.Y;

                //if (MyType == UILayerType.PanX) r.X += (int)(SizeX * displayValue);
                //if (MyType == UILayerType.PanY) r.Y += (int)(SizeY * displayValue);
                //if (MyType == UILayerType.PanXNeg) r.X += (int)(SizeX * (1 - displayValue));
                //if (MyType == UILayerType.PanYNeg) r.Y += (int)(SizeY * (1 - displayValue));

                if(drawRect) gfx.DrawRectangle(new Pen(Colour), new Rectangle((int)r.X, (int)r.Y, (int)r.Width, (int)r.Height));
                gfx.DrawString(displayString, f, new SolidBrush(Colour), r, format);
            }
        }

        public override string ToString() {
            return base.ToString()+" [T]";
        }
    }
}
