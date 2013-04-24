﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.General;
using System.IO;

namespace ToolCache.Critters {
    public class CritterManager {
        public const string DATABASE_FILENAME = Settings.CACHE + "db_critters.bin";

        public static Dictionary<short, Critter> Critters = new Dictionary<short, Critter>();
        public static short NextCritterID = 0;

        public static void Initialize() {
            Critters.Clear();

            NextCritterID = 0;
            ReadDatabase();
        }

        private static void ReadDatabase() {
            // Load object types from file
            if (File.Exists(DATABASE_FILENAME)) {
                BinaryIO f = new BinaryIO(File.ReadAllBytes(DATABASE_FILENAME));

                short totalObjects = f.GetShort();

                for (int i = 0; i < totalObjects; i++) {
                    CritterTypes peakedType = (CritterTypes)f.GetByte();
                    Critter _Critter = null;

                    switch (peakedType) {
                        case CritterTypes.Humanoid:
                            _Critter = CritterHuman.LoadHumanoid(f); break;
                        case CritterTypes.NonHumanoid:
                            _Critter = CritterBeast.LoadBeastoid(f); break;
                    }

                    if(_Critter != null) Critters.Add(_Critter.ID, _Critter);
                }
            }
        }
    }
}