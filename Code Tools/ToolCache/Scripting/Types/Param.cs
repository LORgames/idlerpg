using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    public enum Param {
        Number,
        Integer,
        Angle,
        Boolean,
        String,
        Direction,
        CritterName,
        EffectName,
        ObjectName,
        ItemName,
        EquipmentName,
        SoundEffectName,
        MusicName,
        Portrait,
        FactionName,
        AnimationName,
        ImageDatabase,
        Optional = 128 //Optional is a flag, eg: Number|Optional
    }
}
