package Game.Critter {
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.Scripting.Script;
	import Game.Items.LootDrop;
	import Game.Map.MapData;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterInfoBase {
		public var CritterType:int = 0;
		
        public var ID:uint;
        public var Name:String;
        public var AIType:uint;
		
		public var MovementSpeed:int;
		public var AlertRange:int;
		public var AttackRange:int;
		
        public var ExperienceGain:int;
        public var Health:int;
        public var OneOfAKind:Boolean;
		
        public var AICommands:Script;
		
		public var Factions:Vector.<int>;
        public var Loot:Vector.<LootDrop>;
		
		public function CritterInfoBase() {}
		
		protected function LoadBasicInfo(b:ByteArray):void {
			Name = BinaryLoader.GetString(b);
			
			AIType = b.readInt();
			
			ExperienceGain = b.readInt();
			Health = b.readInt();
			
			MovementSpeed = b.readShort();
			AlertRange = b.readShort();
			AttackRange = b.readShort();
			
			AICommands = Script.ReadScript(b);
			
			Factions = new Vector.<int>(b.readByte());
			for (var i:int = 0; i < Factions.length; i++) {
				Factions[i] = b.readByte();
			}
		}
		
		public function CreateCritter(map:MapData, x:int, y:int):BaseCritter {
			trace("CritterInfoBase cannot accurately create a critter!");
			return null;
		}
	}

}