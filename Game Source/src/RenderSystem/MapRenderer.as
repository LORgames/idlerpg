package RenderSystem {
	import adobe.utils.CustomActions;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.display.Stage;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.Map.TileHelper;
	import Game.Map.TileInstance;
	import Game.Map.TileTemplate;
	import Game.Map.WorldData;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class MapRenderer extends Bitmap {
		
		private var data:BitmapData; // Display thing.
		public var DebugLayer:Sprite = new Sprite();
		public var fullRect:Rectangle = new Rectangle();
		
		public function MapRenderer() {
			
		}
		
		public function Resized():void {
			data = new BitmapData(Main.I.stage.stageWidth, Main.I.stage.stageHeight, false);
			this.bitmapData = data;
			
			fullRect.width = data.width;
			fullRect.height = data.height;
		}
		
		public function Draw():void {
			var destPoint:Point = new Point();
			
			var xTilePosL:int = -Camera.X / 48;
			var yTilePosL:int = -Camera.Y / 48;
			var xTilePosU:int = (-Camera.X + data.width) / 48;
			var yTilePosU:int = (-Camera.Y + data.height) / 48;
			
			if (xTilePosL < 0) xTilePosL = 0;
			if (yTilePosL < 0) yTilePosL = 0;
			if (xTilePosU >= WorldData.ME.CurrentMap.TileSizeX) xTilePosU = WorldData.ME.CurrentMap.TileSizeX - 1;
			if (yTilePosU >= WorldData.ME.CurrentMap.TileSizeY) yTilePosU = WorldData.ME.CurrentMap.TileSizeY - 1;
			
			var tiles:Vector.<TileInstance> = WorldData.ME.CurrentMap.Tiles;
			var tileArt:BitmapData = WorldData.TileSheet;
			
			var xPos:int = xTilePosU+1;
			var yPos:int = 0;
			var xSize:int = WorldData.ME.CurrentMap.TileSizeX;
			
			data.lock();
			
			data.fillRect(fullRect, 0x0);
			
			while (--xPos >= xTilePosL) {
				yPos = yTilePosU+1;
				
				while (--yPos >= yTilePosL) {
					var tileType:int = tiles[xPos+yPos*xSize].TileID;
					
					destPoint.x = 48 * xPos + Camera.X;
					destPoint.y = 48 * yPos + Camera.Y;
					
					data.copyPixels(tileArt, TileTemplate.Tiles[tileType].Frame, destPoint);
				}
			}
			
			data.unlock();
		}
		
	}
	
}