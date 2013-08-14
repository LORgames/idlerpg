﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;
using System.Drawing;

namespace ToolCache.NPC {
    public class PortraitManager {
        public static DictionaryEx<string, Portrait> Portraits = new DictionaryEx<string, Portrait>();

        public static decimal MarginLeft = 0;
        public static decimal MarginRight = 0;
        public static decimal MarginBottom = 0;
        public static decimal Height = 200;
        
        public static Color BackgroundColour = Color.Blue;
        public static decimal Transparency = 50;

        internal static void Initialize() {
            Portraits.Clear();
            LoadFromBinaryIO();
        }

        private static void LoadFromBinaryIO() {
            if(File.Exists(Settings.Database + "Portraits.bin")) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(Settings.Database + "Portraits.bin"));

                MarginLeft = f.GetShort();
                MarginRight = f.GetByte();
                MarginBottom = f.GetByte();
                Height = f.GetByte();
                BackgroundColour = Color.FromArgb(f.GetByte(), f.GetByte(), f.GetByte());
                Transparency = f.GetByte();

                short totalPortraits = f.GetShort();

                while (--totalPortraits > -1) {
                    Portrait p = Portrait.LoadFromBinaryIO(f);
                    Portraits.Add(p.Name, p);
                }
            }
        }

        public static void SaveToBinaryIO() {
            BinaryIO f = new BinaryIO();

            f.AddShort((short)MarginLeft);
            f.AddByte((byte)MarginRight);
            f.AddByte((byte)MarginBottom);
            f.AddByte((byte)Height);
            f.AddByte(BackgroundColour.R);
            f.AddByte(BackgroundColour.G);
            f.AddByte(BackgroundColour.B);
            f.AddByte((byte)Transparency);

            f.AddShort((short)Portraits.Count);

            foreach (Portrait p in Portraits.Values) {
                p.SaveToBinaryIO(f);
            }

            f.Encode(Settings.Database + "Portraits.bin");
        }
    }
}
