package Game.Critter {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import Game.Map.MapData;
	import Game.Map.TileInstance;
	import Game.Map.TileTemplate;
	import Game.Map.WorldData;
	/**
	 * ...
	 * @author Paul
	 */
	public class BaseCritter extends Bitmap {
		
		public var position:int = -1;
		public var movementSpeed:int = 0;
		public var direction:int = 0;
		
		public var state:int = 0;
		public var isMoving:Boolean = false;
		
		public var currentMap:MapData;
		
		public function BaseCritter() {
			this.bitmapData = new BitmapData(48, 48, true, 0xFFFF0000);
			Main.OrderedLayer.addChild(this);
		}
		
		public function UpdatePosition():void {
			this.x = int(position % currentMap.TileSizeX) * 48;
			this.y = int(position / currentMap.TileSizeX) * 48;
			
			trace(this.x + ", " + this.y);
		}
		
		public function ShiftMaps(newMap:MapData, location:int = 0):void {
			currentMap = newMap;
			newMap.Tiles[location].TemporaryLock = true;
			position = location;
			UpdatePosition();
		}
		
		public function RequestMove(moveDir:int):void {
			var n:TileInstance;
			var p:int = position;
			
			if (moveDir == 0) {
				n = currentMap.Tiles[position].Left;
				p--;
			} else if (moveDir == 1) {
				n = currentMap.Tiles[position].Up;
				p -= currentMap.TileSizeX;
			} else if (moveDir == 2) {
				n = currentMap.Tiles[position].Right;
				p++;
			} else {
				n = currentMap.Tiles[position].Down;
				p += currentMap.TileSizeX;
			}
			
			if (n != null) {
				if (n.TemporaryLock) n = null;
			}
			
			trace("Move: " + n + " & " + moveDir);
			
			if (n != null) {
				currentMap.Tiles[position].TemporaryLock = false;
				n.TemporaryLock = true;
				position = p;
				UpdatePosition();
			}
		}
		
		public function RequestTeleport(tileID:int):void {
			
		}
		
	}

}