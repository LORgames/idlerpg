package Game.Critter {
	import flash.utils.ByteArray;
	import Scripting.Script;
	import Game.Map.MapData;
	import Scripting.ScriptInstance;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterInfoHuman extends CritterInfoBase {
		
		public var shadow:int;
		public var legs:int;
		public var body:int;
		public var face:int;
		public var headgear:int;
		public var weapon:int;
		
		public function CritterInfoHuman(b:ByteArray, critterID:int) {
			ID = critterID;
			
			LoadBasicInfo(b);
			
			shadow = b.readShort();
			legs = b.readShort();
			body = b.readShort();
			face = b.readShort();
			headgear = b.readShort();
			weapon = b.readShort();
		}
		
		override public function CreateCritter(map:MapData, x:int, y:int, isSimulated:Boolean = true, _id:int = -1):BaseCritter {
			var ID:int = _id;
			if (ID == -1) { map.GetCritterID(isSimulated); }
			if (ID == -1) { Global.Out.Log("Critter Overflow! Cannot create a new CritterHuman!"); return null; }
			
			var p:CritterHuman = new CritterHuman(x, y, ID, this);
			
			p.Equipment.Equip(shadow, legs, body, face, headgear, weapon);
			p.SetFaction(Factions[0]);
			
			p.CurrentMap = map;
			map.Critters[ID] = p;
			
			p.Update(0);
			
			p.MyScript = new ScriptInstance(AICommands, p, false);
			p.MyScript.Run(Script.Initialize);
			
			p.MyAIType = this.AIType;
			p.CurrentHP = Health;
			p.MaximumHP = Health;
			p.CurrentDefence = Defence;
			
			p.SetAlertRangeSqrd(AlertRange*AlertRange);
			p.MovementSpeed = MovementSpeed;
			p.AttackRange = AttackRange;
			
			return p;
		}
		
	}

}