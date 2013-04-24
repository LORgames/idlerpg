package RenderSystem {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Stage;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.Map.TileInstance;
	import Game.Map.TileTemplate;
	import Game.Map.WorldData;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class MapRenderer extends Bitmap {
		
		private var data:BitmapData; // Display thing: very bad if this needs to be resized
		
		public function MapRenderer() {
			
		}
		
		public function Resized():void {
			data = new BitmapData(Main.I.stage.stageWidth, Main.I.stage.stageHeight, false);
			this.bitmapData = data;
		}
		
		public function Draw():void {
			var i:int = WorldData.CurrentMap.TotalTiles;
			
			var _x:int = Camera.X;
			var _y:int = Camera.Y;
			var tiles:Vector.<TileInstance> = WorldData.CurrentMap.Tiles;
			var tileArt:BitmapData = WorldData.TileSheet;
			
			var destPoint:Point = new Point();
			
			var prevType:int = -1;
			
			data.lock();
			
			data.fillRect(data.rect, 0xFF336699);
			
			while (--i > -1) {
				var tileType:int = tiles[i].TileID;
				
				destPoint.x = 48 * int(i % WorldData.CurrentMap.TileSizeX) + _x;
				destPoint.y = 48 * int(i / WorldData.CurrentMap.TileSizeX) + _y;
				
				data.copyPixels(tileArt, TileTemplate.Tiles[tileType].Frame, destPoint);
				
				prevType = tileType;
			}
			
			data.unlock();
		}
		
	}
	
}