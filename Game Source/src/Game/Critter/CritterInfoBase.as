package Game.Critter {
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.General.Script;
	import Game.Items.LootDrop;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterInfoBase {
		public var CritterType:int = 0;
		
        public var ID:uint;
        public var Name:String;
        public var AIType:uint;
		
        public var ExperienceGain:int;
        public var Health:int;
        public var OneOfAKind:Boolean;
		
        public var AICommands:Script;
		
        public var Loot:Vector.<LootDrop>;
		
		protected function LoadBasicInfo(b:ByteArray):void {
			Name = BinaryLoader.GetString(b);
			
			AIType = b.readInt();
			
			ExperienceGain = b.readInt();
			Health = b.readInt();
			
			AICommands = Script.ReadScript(b);
		}
		
		public function CreateCritter():BaseCritter {
			trace("CritterInfoBase cannot accurately create a critter!");
			return null;
		}
	}

}