package Game.Map {
	import flash.geom.Rectangle;
	/**
	 * ...
	 * @author Paul
	 */
	public class TileHelper {
		
		public static const TILE_SIZE:int = 48;
		
		public static function GetTiles(r:Rectangle, Map:MapData):Vector.<TileInstance> {
			var retVal:Vector.<TileInstance> = new Vector.<TileInstance>();
			
			var xTilePosL:int = r.x / TILE_SIZE;
			var yTilePosL:int = r.y / TILE_SIZE;
			var xTilePosU:int = xTilePosL + r.width / TILE_SIZE;
			var yTilePosU:int = yTilePosL + r.height / TILE_SIZE;
			
			var xPos:int = xTilePosU;
			var yPos:int = 0;
			
			while (xPos-- >= xTilePosL) {
				yPos = yTilePosU;
				
				while (yPos-- >= yTilePosL) {
					retVal.push(Map.Tiles[xTilePosU  + yTilePosU * Map.TileSizeX]);
				}
			}
			
			return retVal;
		}
		
	}

}