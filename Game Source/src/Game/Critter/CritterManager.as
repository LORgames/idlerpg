package Game.Critter {
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterManager {
		public static var I:CritterManager;
		
		public var Critters:Vector.<CritterInfoBase>;
		
		public function CritterManager() {
			I = this;
			BinaryLoader.Load("Data/CritterInfo.bin", ParseCritterFile);
		}
		
		public function ParseCritterFile(b:ByteArray):void {
			var critterCount:int = b.readShort();
			
			Critters = new Vector.<CritterInfoBase>(critterCount, true);
			
			for (var i:int = 0; i < critterCount; i++) {
				var type:int = b.readByte();
				
				if (type == 0) { //Is Humanoid
					Critters[i] = new CritterInfoHuman(b);
				} else if (type == 1) { //Is non-humanoid
					Critters[i] = new CritterInfoBeast(b);
				}
			}
		}
		
	}

}