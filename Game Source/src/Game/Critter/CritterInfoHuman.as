package Game.Critter {
	import flash.utils.ByteArray;
	import Game.General.Script;
	import Game.Map.MapData;
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
			var p:CritterHuman = new CritterHuman();
			
			p.Equipment.Equip(shadow, legs, body, face, headgear, weapon);
			
			p.CurrentMap = map;
			map.Critters.push(p);
			
			p.X = x;
			p.Y = y;
			
			p.Update(0);
			
			p.MyScript = AICommands;
			AICommands.Run(Script.Spawn, p);
			
			return p;
		}
		
	}

}