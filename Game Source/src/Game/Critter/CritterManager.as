package Game.Critter {
	import adobe.utils.CustomActions;
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	import Loaders.BinaryLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterManager {
		public static var I:CritterManager;
		
		public var CritterInfo:Vector.<CritterInfoBase>;
		public var CritterBuffs:Vector.<CritterBuffInfo>;
		public var DatabaseID:int = 1;
		
		public function CritterManager() {
			I = this;
			BinaryLoader.Load("Data/CritterInfo.bin", ParseCritterFile);
			BinaryLoader.Load("Data/CritterBuffs.bin", ParseBuffFile);
		}
		
		public function ParseCritterFile(b:ByteArray):void {
			var critterCount:int = b.readShort();
			
			CritterInfo = new Vector.<CritterInfoBase>(critterCount, true);
			
			for (var i:int = 0; i < critterCount; i++) {
				var type:int = b.readByte();
				
				if (type == 0) { //Is Humanoid
					CritterInfo[i] = new CritterInfoHuman(b, i);
				} else if (type == 1) { //Is non-humanoid
					CritterInfo[i] = new CritterInfoBeast(b, i);
				}
			}
		}
		
		public function ParseBuffFile(b:ByteArray):void {
			var buffsCount:int = b.readShort();
			
			CritterBuffs = new Vector.<CritterBuffInfo>(buffsCount, true);
			DatabaseID = b.readShort();
			
			for (var i:int = 0; i < buffsCount; i++) {
				CritterBuffs[i] = new CritterBuffInfo(b);
			}
		}
		
		public function GetBuff():CritterBuff {
			//TODO: Pool these objects.
			return new CritterBuff();
		}
	}
}