using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ToolCache.General {
    public class ImageCache {

        private static Dictionary<String, Image> img_store = new Dictionary<string, Image>();

        public static Image RequestImage(string filename) {
            //Hopefully more often then not its already cached :)
            if (img_store.ContainsKey(filename)) {
                return img_store[filename];
            }

            if (!File.Exists(filename)) {
                MessageBox.Show("File does not exist! Cannot Cache Missing Files: " + filename);
                return null;
            }

            //If its not cached, then boohoo...
            using (var bmpTemp = new Bitmap(filename)) {
                img_store.Add(filename, new Bitmap(bmpTemp)); //(well that was easy)
            }

            return img_store[filename];
        }

        internal static bool HasCached(string filename) {
            return img_store.ContainsKey(filename);
        }

        public static void ForceCache(string filename) {
            using (var bmpTemp = new Bitmap(filename)) {
                if (img_store.ContainsKey(filename)) {
                    img_store[filename] = new Bitmap(bmpTemp);
                } else {
                    img_store.Add(filename, new Bitmap(bmpTemp)); //(well that was easy)
                }
            }
        }

        public static void Release(String s) {
            if (img_store.ContainsKey(s)) {
                img_store[s].Dispose();
                img_store[s] = null;
                img_store.Remove(s);
            }
        }
    }
}
