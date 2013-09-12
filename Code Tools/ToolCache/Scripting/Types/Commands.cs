using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Scripting.Types {
    public class Commands {
        public static Dictionary<string, ValidCommand> All = new Dictionary<string, ValidCommand>();

        public static Dictionary<Param, ushort[]> DefaultValues = new Dictionary<Param, ushort[]>();
        public static Dictionary<String, ushort> ScriptTargets = new Dictionary<string, ushort>();

        public static readonly string[] ValidBooleanNames = { "on", "true", "1" };

        public static void Initialize() {
            //General Commands :)
            All.Add("soundplay",
                new ValidCommand(0x1001, new Param[] { Param.SoundEffectName}));
            All.Add("spawn",
                new ValidCommand(0x1002, new Param[] { Param.CritterName, Param.Integer | Param.Optional, Param.Integer | Param.Optional }));
            All.Add("damage",
                new ValidCommand(0x1003, new Param[] { Param.Integer }));
            All.Add("knockback",
                new ValidCommand(0x1004, new Param[] { Param.Integer }));
            All.Add("damagepercent",
                new ValidCommand(0x1005, new Param[] { Param.Integer }));
            All.Add("dot",
                new ValidCommand(0x1006, new Param[] { Param.Integer, Param.Integer }));
            All.Add("destroy",
                new ValidCommand(0x1007, new Param[] { Param.Void }));
            All.Add("effectspawn",
                new ValidCommand(0x1008, new Param[] { Param.EffectName, Param.Integer | Param.Optional, Param.Integer | Param.Optional }));
            All.Add("effectspawndirectional",
                new ValidCommand(0x1009, new Param[] { Param.EffectName, Param.Integer | Param.Optional, Param.Integer | Param.Optional, Param.Direction | Param.Optional }));
            All.Add("effectspawndirectionalrelative",
                new ValidCommand(0x100A, new Param[] { Param.EffectName, Param.Integer | Param.Optional, Param.Integer | Param.Optional, Param.Direction | Param.Optional }));
            All.Add("objectspawn",
                new ValidCommand(0x100B, new Param[] { Param.ObjectName, Param.Integer | Param.Optional, Param.Integer | Param.Optional }));
            All.Add("dotpercent",
                new ValidCommand(0x100C, new Param[] { Param.CritterName, Param.Integer | Param.Optional, Param.Integer | Param.Optional }));
            All.Add("triggerfire",
                new ValidCommand(0x100D, new Param[] { Param.Integer }));
            All.Add("soundgroupplay",
                new ValidCommand(0x100E, new Param[] { Param.SoundEffectGroup }));

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

            //Animation Commands
            All.Add("animationplay",
                new ValidCommand(0x6000, new Param[] { Param.AnimationName }));
            All.Add("animationloop",
                new ValidCommand(0x6001, new Param[] { Param.AnimationName }));
            All.Add("animationspeed",
                new ValidCommand(0x6002, new Param[] { Param.Number }));

            //UI Commands
            All.Add("replacelayerfromdatabase",
                new ValidCommand(0xC001, new Param[] { Param.UILayer, Param.ImageDatabase }));
            All.Add("uipanelvisible",
                new ValidCommand(0xC002, new Param[] { Param.UIPanel, Param.Boolean }));
            All.Add("uilayerredraw",
                new ValidCommand(0xC003, new Param[] { Param.UIElement }));


            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////// DEFAULT VALUES
            /////////////////////////////////////////////////////////////////////////

            DefaultValues.Add(Param.Void, new ushort[] {});
            DefaultValues.Add(Param.Number, new ushort[] { 0 });
            DefaultValues.Add(Param.Integer, new ushort[] { 0 });
            DefaultValues.Add(Param.Angle, new ushort[] { 0 });
            DefaultValues.Add(Param.Boolean, new ushort[] { 1 });
            DefaultValues.Add(Param.String, new ushort[] { 0 });
            DefaultValues.Add(Param.Direction, new ushort[] { 0 });
            DefaultValues.Add(Param.CritterName, new ushort[] { 0 });
            DefaultValues.Add(Param.EffectName, new ushort[] { 0 });
            DefaultValues.Add(Param.ObjectName, new ushort[] { 0 });
            DefaultValues.Add(Param.ItemName, new ushort[] { 0 });
            DefaultValues.Add(Param.EquipmentName, new ushort[] { 0 });
            DefaultValues.Add(Param.SoundEffectName, new ushort[] { 0 });
            DefaultValues.Add(Param.SoundEffectGroup, new ushort[] { 0 });
            DefaultValues.Add(Param.MusicName, new ushort[] { 0 });
            DefaultValues.Add(Param.Portrait, new ushort[] { 0 });
            DefaultValues.Add(Param.FactionName, new ushort[] { 0 });
            DefaultValues.Add(Param.AnimationName, new ushort[] { 0 });
            DefaultValues.Add(Param.ImageDatabase, new ushort[] { 0 });

            /////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////// SCRIPT TARGETS
            /////////////////////////////////////////////////////////////////////////

            ScriptTargets.Add("invoker", 0x0);
            ScriptTargets.Add("aitarget", 0x1);
            ScriptTargets.Add("attacker", 0x2);
        }
    }
}
