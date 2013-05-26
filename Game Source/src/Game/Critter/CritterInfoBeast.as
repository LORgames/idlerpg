package Game.Critter 
{
	import flash.utils.ByteArray;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterInfoBeast extends CritterInfoBase {
		
		public var shadow:int;
		public var legs:int;
		public var body:int;
		public var face:int;
		public var headgear:int;
		public var weapon:int;
		
		public function CritterInfoBeast(b:ByteArray) {
			LoadBasicInfo(b);
		}
		
	}

}