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

        internal static void Go() {
            List<Image> images = new List<Image>();
            List<String> imageNames = new List<string>();

            BinaryIO f = new BinaryIO();

            if (UIManager.Panels.Count > 255) Processor.Errors.Add(new ProcessingError("UI Exporter", "Panels", "Cannot export more than 255 UIPanels."));
            f.AddByte((byte)UIManager.Panels.Count);

            foreach (UIPanel p in UIManager.Panels) {
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
                        f.AddByte((byte)((l is UIImageLayer) ? 0 : 1));
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
                            f.AddString(l2.Message);
                        }
                    }
                }
            }

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
    }
}
