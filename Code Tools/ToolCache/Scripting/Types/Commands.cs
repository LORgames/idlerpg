﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    public class Commands {
        public static Dictionary<string, ValidCommand> All = new Dictionary<string, ValidCommand>();
        public static Dictionary<string, ValidCommand> MathFunctions = new Dictionary<string, ValidCommand>();
        public static Dictionary<string, ValidCommand> IfFunctions = new Dictionary<string, ValidCommand>();

        public static Dictionary<string, ValidCommand> ZoneFunctions = new Dictionary<string, ValidCommand>();

        public static Dictionary<Param, ushort[]> DefaultValues = new Dictionary<Param, ushort[]>();

        public static Dictionary<string, ushort> ScriptTargets = new Dictionary<string, ushort>();
        public static Dictionary<string, ushort> NetworkTypes = new Dictionary<string, ushort>();

        public static readonly string[] ValidBooleanNames = { "on", "true", "1", "yes", "y", "t" };

        public static void Initialize() {
            //General Commands :)
            All.Add("soundplay",
                new ValidCommand(0x1001, new Param[] { Param.SoundEffectName}));
            All.Add("spawn",
                new ValidCommand(0x1002, new Param[] { Param.CritterName, Param.Integer | Param.Optional, Param.Integer | Param.Optional, Param.Boolean | Param.Optional, Param.Boolean | Param.Optional })); //Critter, X, Y, Use My Faction, Spawn World Coords (true) or Relative Coords (false)
            All.Add("damage",
                new ValidCommand(0x1003, new Param[] { Param.Integer, Param.Integer | Param.Optional }));
            All.Add("knockback",
                new ValidCommand(0x1004, new Param[] { Param.Integer }));
            All.Add("damagepercent",
                new ValidCommand(0x1005, new Param[] { Param.Integer }));
            All.Add("spawnfaction",
                new ValidCommand(0x1006, new Param[] { Param.CritterName, Param.Integer, Param.Integer, Param.FactionName })); //Critter, WorldX, WorldY, Faction
            All.Add("destroy",
                new ValidCommand(0x1007, new Param[] { Param.Void }));
            All.Add("effectspawn",
                new ValidCommand(0x1008, new Param[] { Param.EffectName, Param.Integer | Param.Optional, Param.Integer | Param.Optional, Param.Boolean | Param.Optional })); // EffectID, X, Y, isRelative?1=Yes,0=No
            All.Add("effectspawndirectional",
                new ValidCommand(0x1009, new Param[] { Param.EffectName, Param.Integer | Param.Optional, Param.Integer | Param.Optional, Param.Direction | Param.Optional }));
            All.Add("effectspawndirectionalrelative",
                new ValidCommand(0x100A, new Param[] { Param.EffectName, Param.Integer | Param.Optional, Param.Integer | Param.Optional, Param.Direction | Param.Optional }));
            All.Add("objectspawn",
                new ValidCommand(0x100B, new Param[] { Param.ObjectName, Param.Integer | Param.Optional, Param.Integer | Param.Optional }));
            All.Add("triggerfire",
                new ValidCommand(0x100D, new Param[] { Param.Integer }));
            All.Add("soundgroupplay",
                new ValidCommand(0x100E, new Param[] { Param.SoundEffectGroup }));
            All.Add("netsync",
                new ValidCommand(0x100F, new Param[] { Param.Void }, true, new ushort[] { 0xF001 }));
            All.Add("mapchange",
                new ValidCommand(0x1010, new Param[] { Param.MapName }));
            All.Add("nethost",
                new ValidCommand(0x1011, new Param[] { Param.NetworkType, Param.Integer }));
            All.Add("netconnect",
                new ValidCommand(0x1012, new Param[] { Param.NetworkType, Param.String, Param.Integer }));
            All.Add("netclose",
                new ValidCommand(0x1013, new Param[] { Param.Void }));
            All.Add("spawnactive",
                new ValidCommand(0x1014, new Param[] { Param.SpawnRegion, Param.Boolean }));
            All.Add("netsyncvar",
                new ValidCommand(0x1015, new Param[] { Param.Integer }));
            All.Add("offset",
                new ValidCommand(0x1016, new Param[] { Param.Integer, Param.Integer }));
            All.Add("paramset",
                new ValidCommand(0x1017, new Param[] { Param.String, Param.Integer }));
            All.Add("tween",
                new ValidCommand(0x1018, new Param[] { Param.String, Param.Integer, Param.Integer, Param.Number }));
            All.Add("tweento",
                new ValidCommand(0x1019, new Param[] { Param.String, Param.Integer, Param.Number }));
            All.Add("applybuff",
                new ValidCommand(0x101A, new Param[] { Param.Buff }));
            All.Add("tweenchild",
                new ValidCommand(0x101B, new Param[] { Param.String, Param.String, Param.Integer, Param.Integer, Param.Number }));
            All.Add("joinmatchmaking",
                new ValidCommand(0x101C, new Param[] { Param.Void }));
            All.Add("forceupdatesound",
                new ValidCommand(0x101D, new Param[] { Param.Void }));
            All.Add("triggerlocal",
                new ValidCommand(0x101E, new Param[] { Param.Integer }));
            All.Add("aitargetdrop",
                new ValidCommand(0x101F, new Param[] { Param.Void }));
            All.Add("setstring",
                new ValidCommand(0x1020, new Param[] { Param.String, Param.String }));
            All.Add("netsyncstring",
                new ValidCommand(0x1021, new Param[] { Param.String }));
            All.Add("nettrigger",
                new ValidCommand(0x1022, new Param[] { Param.Integer }));
            All.Add("clockrunning",
                new ValidCommand(0x1023, new Param[] { Param.Boolean }));
            All.Add("scriptregionresize",
                new ValidCommand(0x1024, new Param[] { Param.ScriptRegion, Param.Integer, Param.Integer, Param.Integer, Param.Integer }));
            All.Add("netsyncstart",
                new ValidCommand(0x1025, new Param[] { Param.Boolean | Param.Optional }));

            //Quest and Inventory Commands
            All.Add("saydialogue",
                new ValidCommand(0x2000, new Param[] { Param.String, Param.Portrait | Param.Optional }));
            All.Add("saymessage",
                new ValidCommand(0x2001, new Param[] { Param.String, Param.Portrait | Param.Optional }));

            //Item Commands
            All.Add("consume",
                new ValidCommand(0x3000, new Param[] { Param.Void }));

            //Equipment Commands
            All.Add("equip",
                new ValidCommand(0x4001, new Param[] { Param.EquipmentName }));

            //Critter and Effect Commands
            All.Add("dash",
                new ValidCommand(0x5000, new Param[] { Param.Integer, Param.Integer | Param.Optional }));
            All.Add("movementspeed",
                new ValidCommand(0x5001, new Param[] { Param.Integer }));
            All.Add("movementdirection",
                new ValidCommand(0x5002, new Param[] { Param.Angle, Param.Boolean | Param.Optional }));
            All.Add("movementturn",
                new ValidCommand(0x5003, new Param[] { Param.Angle, Param.Boolean | Param.Optional }));
            All.Add("factionset",
                new ValidCommand(0x5004, new Param[] { Param.FactionName }));
            All.Add("movementstop",
                new ValidCommand(0x5005, new Param[] { Param.Void }));
            All.Add("gettargetfromowner",
                new ValidCommand(0x5006, new Param[] { Param.Void }));
            All.Add("setaitype",
                new ValidCommand(0x5007, new Param[] { Param.AIType, Param.Boolean }));
            All.Add("with",
                new ValidCommand(0x5008, new Param[] { Param.ScriptTarget }, true, new ushort[] { 0x5009 }));
            All.Add("poptarget",
                new ValidCommand(0x5009, new Param[] { Param.Void }));
            All.Add("offsetset",
                new ValidCommand(0x500A, new Param[] { Param.Integer, Param.Integer }));
            All.Add("withnearest",
                new ValidCommand(0x500B, new Param[] { Param.ObjectType, Param.Integer|Param.Optional }, true, new ushort[] { 0x5009 })); //Enemy/Ally etc, Maximum range
            All.Add("withnearestnottype",
                new ValidCommand(0x500C, new Param[] { Param.ObjectType, Param.FactionName, Param.Integer | Param.Optional }, true, new ushort[] { 0x5009 })); //Enemy/Ally etc, Type(eg. spellimmune), Maximum range

            //Animation Commands
            All.Add("animationplay",
                new ValidCommand(0x6000, new Param[] { Param.AnimationName }));
            All.Add("animationloop",
                new ValidCommand(0x6001, new Param[] { Param.AnimationName }));
            All.Add("animationspeed",
                new ValidCommand(0x6002, new Param[] { Param.Number }));

            // Flow control
            All.Add("continue",
                new ValidCommand(0x8004, new Param[] { Param.Void }));
            All.Add("break",
                new ValidCommand(0x8005, new Param[] { Param.Void }));
            All.Add("call",
                new ValidCommand(0x8006, new Param[] { Param.Function }));

            //UI Commands
            All.Add("uielementvisible",
                new ValidCommand(0xC001, new Param[] { Param.UIElement, Param.Boolean }));
            All.Add("uipanelvisible",
                new ValidCommand(0xC002, new Param[] { Param.UIPanel, Param.Boolean }));
            All.Add("uilayerredraw",
                new ValidCommand(0xC003, new Param[] { Param.UIElement }));
            All.Add("uitextchange",
                new ValidCommand(0xC004, new Param[] { Param.UILayer, Param.String }));
            All.Add("uilayeroffsets",
                new ValidCommand(0xC005, new Param[] { Param.UILayer, Param.Integer, Param.Integer }));
            All.Add("uisetlibraryid",
                new ValidCommand(0xC006, new Param[] { Param.UILayer, Param.Integer }));
            All.Add("uilayerplay",
                new ValidCommand(0xC007, new Param[] { Param.UILayer, Param.Number, Param.Boolean | Param.Optional }));
            All.Add("uielementoffsets",
                new ValidCommand(0xC008, new Param[] { Param.UIElement, Param.Integer, Param.Integer }));
            All.Add("uielementsize",
                new ValidCommand(0xC009, new Param[] { Param.UIElement, Param.Integer, Param.Integer }));
            All.Add("uilayersize",
                new ValidCommand(0xC00A, new Param[] { Param.UILayer, Param.Integer, Param.Integer }));
            All.Add("uielementpress",
                new ValidCommand(0xC00B, new Param[] { Param.UIElement }));
            All.Add("uielementsetrect", //X,Y,W,H
                new ValidCommand(0xC00C, new Param[] { Param.UIElement, Param.Integer, Param.Integer, Param.Integer, Param.Integer }));
            All.Add("uilayersetrect", //X,Y,W,H
                new ValidCommand(0xC00D, new Param[] { Param.UILayer, Param.Integer, Param.Integer, Param.Integer, Param.Integer }));
            All.Add("uilayerloopbetween",
                new ValidCommand(0xC00E, new Param[] { Param.UILayer, Param.Integer, Param.Integer, Param.Number }));

            All.Add("trace",
                new ValidCommand(0xCFFF, new Param[] { Param.String }));

            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////// MATH FUNCTIONS
            /////////////////////////////////////////////////////////////////////////

            MathFunctions.Add("sin",    new ValidCommand(0x00, new Param[] { Param.Number }));
            MathFunctions.Add("cos", new ValidCommand(0x01, new Param[] { Param.Number }));
            MathFunctions.Add("tan", new ValidCommand(0x02, new Param[] { Param.Number }));
            MathFunctions.Add("invoker",new ValidCommand(0x03, new Param[] { Param.String }));
            MathFunctions.Add("target", new ValidCommand(0x04, new Param[] { Param.String }));
            MathFunctions.Add("pow", new ValidCommand(0x05, new Param[] { Param.Number, Param.Number }));
            MathFunctions.Add("param",  new ValidCommand(0x06, new Param[] { Param.Integer }));
            MathFunctions.Add("random", new ValidCommand(0x07, new Param[] { Param.Number, Param.Number | Param.Optional }));
            MathFunctions.Add("getanimationspeed", new ValidCommand(0x08, new Param[] { Param.Void }));
            MathFunctions.Add("gettypeid", new ValidCommand(0x09, new Param[] { Param.Void }));
            MathFunctions.Add("settimer", new ValidCommand(0x0A, new Param[] { Param.Integer }));

            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////// IF FUNCTIONS
            /////////////////////////////////////////////////////////////////////////

            IfFunctions.Add("random",   new ValidCommand(0x7003, new Param[] { Param.Integer }));
            IfFunctions.Add("isalive",  new ValidCommand(0x7004, new Param[] { Param.Void }));
            IfFunctions.Add("equipped", new ValidCommand(0x7005, new Param[] { Param.EquipmentName }));
            IfFunctions.Add("animation",new ValidCommand(0x7006, new Param[] { Param.AnimationName }));
            IfFunctions.Add("direction",new ValidCommand(0x7007, new Param[] { Param.Direction }));
            IfFunctions.Add("isfaction",new ValidCommand(0x7008, new Param[] { Param.FactionName }));
            //0x7009 is MATH COMPARE!
            IfFunctions.Add("spend",    new ValidCommand(0x700A, new Param[] { Param.Integer, Param.Integer }));
            IfFunctions.Add("hastarget",new ValidCommand(0x700B, new Param[] { Param.Void }));
            IfFunctions.Add("hasbuff",  new ValidCommand(0x700C, new Param[] { Param.Buff }));
            IfFunctions.Add("hastype",  new ValidCommand(0x700D, new Param[] { Param.FactionName }));
            IfFunctions.Add("attackeristype", new ValidCommand(0x700E, new Param[] { Param.FactionName }));
            IfFunctions.Add("stringsequal", new ValidCommand(0x700F, new Param[] { Param.String, Param.String }));
            IfFunctions.Add("hasaitype", new ValidCommand(0x7010, new Param[] { Param.AIType }));
            IfFunctions.Add("aieventis",new ValidCommand(0x7FFF, new Param[] { Param.AIEventType }));
            IfFunctions.Add("triggeris",new ValidCommand(0x7FFF, new Param[] { Param.Integer }));
            IfFunctions.Add("timerid", new ValidCommand(0x7FFF, new Param[] { Param.Integer }));

            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////// ZONE FUNCTIONS
            /////////////////////////////////////////////////////////////////////////

            ZoneFunctions.Add("front", new ValidCommand(0x9000, new Param[] { Param.Integer, Param.Integer, Param.Integer | Param.Optional }));
            ZoneFunctions.Add("aoe", new ValidCommand(0x9001, new Param[] { Param.Integer }));
            ZoneFunctions.Add("myarea", new ValidCommand(0x9003, new Param[] { Param.Void }));
            ZoneFunctions.Add("map", new ValidCommand(0x9004, new Param[] { Param.Void }));
            ZoneFunctions.Add("factionmap", new ValidCommand(0x9005, new Param[] { Param.FactionName }));
            ZoneFunctions.Add("maparea", new ValidCommand(0x9006, new Param[] { Param.Integer, Param.Integer, Param.Integer, Param.Integer }));
            
            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////// DEFAULT VALUES
            /////////////////////////////////////////////////////////////////////////

            DefaultValues.Add(Param.Void, new ushort[] {});
            DefaultValues.Add(Param.Number, new ushort[] { 0xBFFF, 0 });
            DefaultValues.Add(Param.Integer, new ushort[] { 0xBFFF, 0 });
            DefaultValues.Add(Param.Angle, new ushort[] { 0xBFFF, 0 });
            DefaultValues.Add(Param.Boolean, new ushort[] { 1 });
            DefaultValues.Add(Param.CritterName, new ushort[] { 0xBFFF, 0 });

            Array types = Enum.GetValues(typeof(Param));

            foreach(Param x in types) {
                if (!DefaultValues.ContainsKey(x)) {
                    DefaultValues.Add(x, new ushort[] { 0 });
                    System.Diagnostics.Debug.WriteLine("No Default format for Param." + x + " setting as ushort[]{0};");
                }
            }

            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////// SCRIPT TARGETS
            /////////////////////////////////////////////////////////////////////////

            ScriptTargets.Add("invoker", 0x0);
            ScriptTargets.Add("aitarget", 0x1);
            ScriptTargets.Add("attacker", 0x2);
            ScriptTargets.Add("owner", 0x3);

            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////// NETWORK TYPES
            /////////////////////////////////////////////////////////////////////////

            NetworkTypes.Add("lan", 0x0);
            NetworkTypes.Add("bluetooth", 0xB);
        }
    }
}
