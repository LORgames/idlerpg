package Game.Critter {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import Game.Map.MapData;
	/**
	 * ...
	 * @author Paul
	 */
	public class BaseCritter extends Bitmap {
		
		public var position:int = -1;
		public var movementSpeed:int = 0;
		public var direction:int = 0;
		
		public var currentMap:MapData;
		
		public function BaseCritter() {
			
		}
		
		public function ShiftMaps(newMap:MapData, location:int = 0) {
			
		}
		
		public function RequestMove(moveDir:int):void {
			
		}
		
		public function RequestTeleport(tileID:int):void {
			
		}
		
	}

}