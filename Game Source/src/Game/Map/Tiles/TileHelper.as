package Game.Map.Tiles {
	import CollisionSystem.Rect;
	import flash.geom.Rectangle;
	import Game.Map.MapData;
	/**
	 * ...
	 * @author Paul
	 */
	public class TileHelper {
		
		public static function GetTiles(r:Rect, Map:MapData, b:Boolean = false):Vector.<TileInstance> {
			var retVal:Vector.<TileInstance> = new Vector.<TileInstance>();
			
			var xTilePosL:int = r.X / Global.TileSize;
			var yTilePosL:int = r.Y / Global.TileSize;
			var xTilePosU:int = (r.X + r.W) / Global.TileSize;
			var yTilePosU:int = (r.Y + r.H) / Global.TileSize;
			
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