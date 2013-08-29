package Game.Critter {
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class Factions {
		
		private static var Data:Vector.<int>;
		
		public function Factions() {
			BinaryLoader.Load("Data/Factions.bin", ParseFactions);
		}
		
		public function ParseFactions(b:ByteArray):void {
			var totalFactions:int = b.readShort();
			Data = new Vector.<int>(totalFactions, true);
			
			for (var i:int = 0; i < totalFactions; i++) {
				BinaryLoader.GetString(b);
			}
		}
	}
}