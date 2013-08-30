package Game.Critter {
	import flash.utils.ByteArray;
	import Game.Scripting.Script;
	import Game.Map.MapData;
	import Game.Scripting.ScriptInstance;
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
		
		override public function CreateCritter(map:MapData, x:int, y:int):BaseCritter {
			var p:CritterHuman = new CritterHuman(x, y);
			
			p.Equipment.Equip(shadow, legs, body, face, headgear, weapon);
			p.PrimaryFaction = Factions[0];
			
			p.CurrentMap = map;
			map.Critters.push(p);
			
			p.Update(0);
			
			p.MyScript = new ScriptInstance(AICommands, p, false);
			p.MyScript.Run(Script.Initialize);
			
			p.MyAIType = this.AIType;
			p.CurrentHP = Health;
			
			p.AlertRange = AlertRange*AlertRange;
			p.MovementSpeed = MovementSpeed;
			
			return p;
		}
		
	}

}