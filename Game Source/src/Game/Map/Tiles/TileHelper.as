package Game.Map.Tiles {
	import CollisionSystem.Rect;
	import flash.geom.Rectangle;
	import Game.Map.MapData;
	/**
	 * ...
	 * @author Paul
	 */
	public class TileHelper {
		
		public static const TILE_SIZE:int = 48;
		
		public static function GetTiles(r:Rect, Map:MapData, b:Boolean = false):Vector.<TileInstance> {
			var retVal:Vector.<TileInstance> = new Vector.<TileInstance>();
			
			var xTilePosL:int = r.X / TILE_SIZE;
			var yTilePosL:int = r.Y / TILE_SIZE;
			var xTilePosU:int = (r.X + r.W) / TILE_SIZE;
			var yTilePosU:int = (r.Y + r.H) / TILE_SIZE;
			
			if (xTilePosL < 0) xTilePosL = 0;
			if (yTilePosL < 0) yTilePosL = 0;
			if (xTilePosU >= Map.TileSizeX) xTilePosU = Map.TileSizeX - 1;
			if (yTilePosU >= Map.TileSizeY) yTilePosU = Map.TileSizeY - 1;
			
			var xPos:int = xTilePosU+1;
			var yPos:int = 0;
			
			while (--xPos >= xTilePosL) {
				yPos = yTilePosU+1;
				
				while (--yPos >= yTilePosL) {
					retVal.push(Map.Tiles[xPos  + yPos * Map.TileSizeX]);
				}
			}
			
			return retVal;
		}
		
	}

}