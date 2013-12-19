using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolCache.Map;

namespace ToolCache.General {
    public class ExportCrushers {
        public static MapPiece CurrentMap;
        public static Dictionary<string, short> MappedEquipmentIDs;
        public static Dictionary<string, short> MappedEffectIDs;
        public static Dictionary<string, short> MappedObjectIDs;

        public static Dictionary<string, short> MusicConversions = new Dictionary<string, short>();
        public static Dictionary<string, short> AmbienceConversions = new Dictionary<string, short>();
        public static Dictionary<string, short> MappedSoundEffectIDs;
        public static Dictionary<string, short> MappedSoundEffectGroups;

        public static Dictionary<string, short> MappedCritterIDs;
        public static Dictionary<string, short> MappedMapIDs;
        public static Dictionary<string, short> MappedFunctionIDs;
        public static Dictionary<string, short> MappedDatabaseNames;
        public static Dictionary<string, short> MappedBuffIDs;
        public static Dictionary<string, short> MappedUILibraryNames;

        public static Dictionary<string, short> MappedStringTable;

        public static void BlankAll() {
            CurrentMap = null;

            MappedEquipmentIDs = null;
            MappedEffectIDs = null;
            MappedObjectIDs = null;
            
            MusicConversions = null;
            AmbienceConversions = null;
            MappedSoundEffectIDs = null;
            MappedSoundEffectGroups = null;

            MappedCritterIDs = null;
            MappedMapIDs = null;
            MappedFunctionIDs = null;
            MappedDatabaseNames = null;
            MappedBuffIDs = null;

            MappedStringTable = null;
        }
    }
}
