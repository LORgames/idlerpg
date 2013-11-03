﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    public enum Param {
        Void,
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
        SoundEffectGroup,
        MusicName,
        Portrait,
        FactionName,
        AnimationName,
        AIType,
        AIEventType,
        UIPanel,
        UIElement,
        UILayer,
        ScriptTarget,
        MapName,
        SpawnRegion,
        NetworkType,
        Function,
        Optional = 128 //Optional is a flag, eg: Number|Optional
    }
}
