using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    public enum Param {
        Void,               //Nothing, does not exist
        Number,             //(fractional numbers) 0.0, 1.5, 6.0, -112.456
        Integer,            //(whole numbers) 1, 10, 56, -350
        Angle,
        Boolean,
        String,
        Direction,          //Left, Right, Up, Down
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
        AIEventType,        //FactionChanged, TargetChanged
        UIPanel,
        UIElement,
        UILayer,
        ScriptTarget,       //Script targets such as AITarget, Attacker, Minion
        MapName,
        SpawnRegion,
        NetworkType,        //TCP/IP, Bluetooth etc
        Function,
        Buff,
        ObjectType,         //Critter, Enemy, Ally, NotMe etc
        Optional = 128 //Optional is a flag, eg: Number|Optional
    }
}
