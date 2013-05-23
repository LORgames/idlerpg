package Game.Critter 
{
	import flash.utils.ByteArray;
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
		
		public function CritterInfoHuman(b:ByteArray) {
			LoadBasicInfo(b);
			
			shadow = b.readShort();
			legs = b.readShort();
			body = b.readShort();
			face = b.readShort();
			headgear = b.readShort();
			weapon = b.readShort();
		}
		
	}

}