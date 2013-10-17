using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.UI;
using System.Drawing;
using ToolCache.General;
using ToolToGameExporter.Helpers;
using ToolCache.Scripting;
using ToolCache.Scripting.Types;

namespace ToolToGameExporter {
    public class UICrusher {
        private static List<string> RemappedLibraryNames = new List<string>();

        internal static void Go() {
            CrushLibraries();

            List<Image> images = new List<Image>();
            List<String> imageNames = new List<string>();

            BinaryIO f = new BinaryIO();

            if (UIManager.Panels.Count > 255) Processor.Errors.Add(new ProcessingError("UI Exporter", "Panels", "Cannot export more than 255 UIPanels."));
            f.AddByte((byte)UIManager.Panels.Count);

            foreach (UIPanel p in UIManager.Panels) {
                f.AddByte((byte)(p.Enabled?1:0));

                if (p.Elements.Count > 255) Processor.Errors.Add(new ProcessingError("UI Exporter", p.Name+":Elements", "Cannot export more than 255 UIElements for a single UIPanel."));
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
                        f.AddByte((byte)((l is UIImageLayer) ? 0 : (l is UITextLayer) ? 1 : 2));
                        f.AddByte((byte)l.AnchorPoint);
                        f.AddShort(l.OffsetX);
                        f.AddShort(l.OffsetY);
                        f.AddShort(l.SizeX);
                        f.AddShort(l.SizeY);

                        f.AddByte((byte)l.MyType);

                        if (l is UIImageLayer) {
                            UIImageLayer l2 = (UIImageLayer)l;
                            f.AddShort((short)l2.GlobalVariable);

                            if (imageNames.Contains(l2.ImageFilename)) {
                                f.AddShort((short)imageNames.IndexOf(l2.ImageFilename));
                            } else {
                                f.AddShort((short)imageNames.Count);
                                images.Add(ImageCache.RequestImage(l2.ImageFilename));
                                imageNames.Add(l2.ImageFilename);
                            }
                        } else if (l is UITextLayer) {
                            UITextLayer l2 = (UITextLayer)l;
                            f.AddString(l2.PrepareString(true));

                            f.AddInt(l2.Colour.ToArgb());
                            f.AddByte((byte)l2.Align);
                            f.AddByte((byte)l2.FontSize);
                            f.AddByte((byte)l2.FontFamily);
                            f.AddByte((byte)(l2.WordWrap ? 1 : 0));
                        } else if (l is UILibraryLayer) {
                            UILibraryLayer l2 = (UILibraryLayer)l;

                            if (RemappedLibraryNames.IndexOf(l2.LibraryName) > -1) {
                                f.AddShort((short)RemappedLibraryNames.IndexOf(l2.LibraryName));
                                f.AddShort((short)l2.DefaultIndex);
                            } else {
                                Processor.Errors.Add(new ProcessingError("UI Layer", p.Name + ">" + e.Name + ">" + l.Name + ">" + l2.LibraryName, "Cannot find that library!"));
                            }
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

            BinaryIO f = new BinaryIO();
            
            int i = UIManager.Libraries.Count;
            int j = 0;
            UILibrary uil;
            List<Image> images = new List<Image>();

            f.AddShort((short)i);

            while (--i > -1) {
                images.Clear();

                uil = UIManager.Libraries[i];
                RemappedLibraryNames.Add(uil.Name);

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
                    Processor.Errors.Add(new ProcessingError("UI Library Exporter", "Atlas", "Could not generate a sprite atlas for the UI library "+uil.Name+"!"));
                } else {
                    atlas.Save(Global.EXPORT_DIRECTORY + "/UILibrary_"+(RemappedLibraryNames.Count-1)+".png");
                }
            }

            f.Encode(Global.EXPORT_DIRECTORY + "/UILibrary.bin");
        }
    }
}
