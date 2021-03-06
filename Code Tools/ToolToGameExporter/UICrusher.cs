﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.UI;
using System.Drawing;
using ToolCache.General;
using ToolToGameExporter.Helpers;
using ToolCache.Scripting;
using ToolCache.Scripting.Types;
using ToolCache.Storage;
using ToolCache.Scripting.Extensions;

namespace ToolToGameExporter {
    public class UICrusher {
        private static Dictionary<string, short> RemappedLibraryNames = new Dictionary<string, short>();

        internal static void Precrush() {
            CrushLibraries();
        }

        internal static void Go() {
            List<Image> images = new List<Image>();
            List<String> imageNames = new List<string>();

            BinaryIO f = new BinaryIO();

            if (UIManager.Panels.Count > 255) Processor.Errors.Add(new ProcessingError("UI Exporter", "Panels", "Cannot export more than 255 UIPanels."));
            f.AddByte((byte)UIManager.Panels.Count);

            foreach (UIPanel p in UIManager.Panels) {
                f.AddByte((byte)(p.Enabled ? 1 : 0));

                if (p.Elements.Count > 255) Processor.Errors.Add(new ProcessingError("UI Exporter", p.Name + ":Elements", "Cannot export more than 255 UIElements for a single UIPanel."));
                f.AddByte((byte)p.Elements.Count);

                foreach (UIElement e in p.Elements) {
                    f.AddByte((byte)e.AnchorPoint);
                    f.AddShort(e.OffsetX);
                    f.AddShort(e.OffsetY);
                    f.AddShort(e.SizeX);
                    f.AddShort(e.SizeY);

                    ScriptInfo info = new ScriptInfo("UIPanel(" + p.Name + "):UIElement(" + e.Name + "):Script", ScriptTypes.Region);
                    ScriptCrusher.ProcessScript(info, e.Script, f);

                    if (e.Layers.Count > 255) Processor.Errors.Add(new ProcessingError("UI Exporter", p.Name + ":" + e.Name + ":Layers", "Cannot export more than 255 UILayers for a single UIElement."));
                    f.AddByte((byte)e.Layers.Count);

                    foreach (UILayer l in e.Layers) {
                        f.AddByte((byte)((l is UILayerImage) ? 0 : (l is UILayerText) ? 1 : (l is UILayerLibrary) ? 2 : (l is UILayerRoller) ? 3 : (l is UILayerBlackout) ? 4 : 255));
                        f.AddByte((byte)l.AnchorPoint);
                        f.AddShort(l.OffsetX);
                        f.AddShort(l.OffsetY);
                        f.AddShort(l.SizeX);
                        f.AddShort(l.SizeY);

                        f.AddByte((byte)l.MyType);

                        if (l is UILayerImage) {
                            UILayerImage l2 = (UILayerImage)l;
                            f.AddShort((short)l2.GlobalVariable);

                            if (imageNames.Contains(l2.ImageFilename)) {
                                f.AddShort((short)imageNames.IndexOf(l2.ImageFilename));
                            } else {
                                f.AddShort((short)imageNames.Count);
                                images.Add(ImageCache.RequestImage(l2.ImageFilename));
                                imageNames.Add(l2.ImageFilename);
                            }
                        } else if (l is UILayerText) {
                            UILayerText l2 = (UILayerText)l;

                            if (l2.InputType > 0) {
                                if (Variables.StringVariables.ContainsKey(l2.Message)) {
                                    f.AddString(Variables.StringVariables[l2.Message].Index.ToString());
                                } else {
                                    Processor.Errors.Add(new ProcessingError("No Variable", p.Name + ">" + e.Name + ">" + l2.Name, "An input box MUST be tied to a String Variable. '" + l2.Message + "' is not a string variable."));
                                }
                            } else {
                                try {
                                    f.AddString(StringMagic.PrepareString(l2.Message, true));
                                } catch (Exception ex) {
                                    Processor.Errors.Add(new ProcessingError("Bad String", p.Name + ">" + e.Name + ">" + l2.Name, ex.Message));
                                }
                            }

                            f.AddInt(l2.Colour.ToArgb());
                            f.AddByte((byte)l2.Align);
                            f.AddByte((byte)l2.FontSize);
                            f.AddByte((byte)l2.FontFamily);
                            f.AddByte((byte)(l2.WordWrap ? 1 : 0));
                            f.AddByte((byte)l2.InputType);
                            f.AddByte((byte)l2.Justification);
                        } else if (l is UILayerLibrary) {
                            UILayerLibrary l2 = (UILayerLibrary)l;

                            if (RemappedLibraryNames.ContainsKey(l2.LibraryName)) {
                                f.AddShort((short)RemappedLibraryNames[l2.LibraryName]);
                                f.AddShort((short)l2.DefaultIndex);
                            } else {
                                Processor.Errors.Add(new ProcessingError("UI Layer", p.Name + ">" + e.Name + ">" + l.Name + ">" + l2.LibraryName, "Cannot find that library!"));
                            }
                        } else if (l is UILayerBlackout) {
                            f.AddInt(((UILayerBlackout)l).Colour);
                        } else {
                            Processor.Errors.Add(new ProcessingError("UI Layer", p.Name + ">" + e.Name + ">" + l.Name, "Unknown layer type!"));
                        }
                    }
                }
            }

            //images.Sort((Image a, Image b) => (b.Size.Width * b.Size.Height).CompareTo(a.Size.Width * a.Size.Height));

            Bitmap atlas;
            Rectangle[] rects = MaxRects.PackTextures(images.ToArray(), 256, 256, 2048, out atlas);

            f.AddShort((short)rects.Length);

            for (int i = 0; i < rects.Length; i++) {
                f.AddShort((short)rects[i].X);
                f.AddShort((short)rects[i].Y);
                f.AddShort((short)rects[i].Width);
                f.AddShort((short)rects[i].Height);
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/UI.bin");

            if (atlas == null) {
                Processor.Errors.Add(new ProcessingError("UI Exporter", "Atlas", "Could not generate a sprite atlas for the UI components!"));
            } else {
                atlas.Save(Global.EXPORT_DIRECTORY + "/UIAtlas.png");
            }
        }

        private static void CrushLibraries() {
            RemappedLibraryNames.Clear();
            ExportCrushers.MappedUILibraryNames = RemappedLibraryNames;

            BinaryIO f = new BinaryIO();

            int TotalLibraries = UIManager.Libraries.Count;
            int j = 0;
            UILibrary uil;
            List<Image> images = new List<Image>();

            f.AddShort((short)TotalLibraries);

            for (short i = 0; i < TotalLibraries; i++) {
                images.Clear();

                uil = UIManager.Libraries[i];
                RemappedLibraryNames.Add(uil.Name, i);

                f.AddShort((short)uil.Images.Count);

                for (j = 0; j < uil.Images.Count; j++) {
                    images.Add(ImageCache.RequestImage(uil.Images[j]));
                }

                Bitmap atlas;
                Rectangle[] rects = MaxRects.PackTextures(images.ToArray(), 256, 256, 2048, out atlas);

                for (j = 0; j < rects.Length; j++) {
                    f.AddShort((short)rects[j].X);
                    f.AddShort((short)rects[j].Y);
                    f.AddShort((short)rects[j].Width);
                    f.AddShort((short)rects[j].Height);
                }

                if (atlas == null) {
                    Processor.Errors.Add(new ProcessingError("UI Library Exporter", "Atlas", "Could not generate a sprite atlas for the UI library " + uil.Name + "!"));
                } else {
                    atlas.Save(Global.EXPORT_DIRECTORY + "/UILibrary_" + (RemappedLibraryNames.Count - 1) + ".png");
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/UILibrary.bin");
        }
    }
}