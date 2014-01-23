package Game.Critter {
	import flash.utils.ByteArray;
	import Loaders.BinaryLoader;
	import Scripting.Script;
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
		public var Defence:int;
		
        public var OneOfAKind:Boolean;
		
        public var AICommands:Script;
		
		public var MyFactions:Vector.<int>;
        public var Loot:Vector.<LootDrop>;
		
		public function CritterInfoBase() {}
		
		protected function LoadBasicInfo(b:ByteArray):void {
			Name = BinaryLoader.GetString(b);
			
			AIType = b.readInt();
			
			ExperienceGain = b.readInt();
			
			Health = b.readInt();
			Defence = b.readInt();
			
			MovementSpeed = b.readShort();
			AlertRange = b.readShort();
			AttackRange = b.readShort();
			
			AICommands = Script.ReadScript(b);
			
			MyFactions = new Vector.<int>(b.readByte());
			for (var i:int = 0; i < MyFactions.length; i++) {
				MyFactions[i] = b.readByte();
			}
		}
		
		/**
		 * Creates a critter on the specified map
		 * @param	map	The map to attach this too, will almost always be WorldData.CurrentMap
		 * @param	x	The X position that this critter will be placed at
		 * @param	y	The Y position that this critter will be placed at
		 * @param	isSimulated	Is this a simulation object or a player specific object?
		 * @return	The critter that was created
		 */
		public function CreateCritter(map:MapData, x:int, y:int, isSimulated:Boolean = true, _id:int = -1):BaseCritter {
			Global.Out.Log("CritterInfoBase cannot accurately create a critter!");
			return null;
		}
	}

}