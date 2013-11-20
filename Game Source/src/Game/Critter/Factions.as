package Game.Critter {
	import flash.utils.ByteArray;
	import Loaders.BinaryLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class Factions {
		
		private static var Friends:Vector.<int>;
		private static var Enemies:Vector.<int>;
		
		public function Factions() {
			BinaryLoader.Load("Data/Factions.bin", ParseFactions);
		}
		
		public function ParseFactions(b:ByteArray):void {
			var totalFactions:int = b.readByte();
			
			Friends = new Vector.<int>(totalFactions, true);
			Enemies = new Vector.<int>(totalFactions, true);
			
			for (var i:int = 0; i < totalFactions; i++) {
				Friends[i] = b.readInt();
				Enemies[i] = b.readInt();
			}
		}
		
		public static function IsEnemies(faction1:int, faction2:int):Boolean {
			return (Enemies[faction1] & (0x1 << faction2)) > 0;
		}
		
		public static function IsFriends(faction1:int, faction2:int):Boolean {
			return (Friends[faction1] & (0x1 << faction2)) > 0;
		}
		
		public static function GetFactionColour(faction:int):int {
			return (0xFF << (faction * 8));
		}
	}
}