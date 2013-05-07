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
	 * @author Miles
	 */
	public class LoadScreen extends Bitmap {
		
		private var data:BitmapData; // Display thing.
		
		public function LoadScreen() {
			
		}
		
		public function Resized():void {
			data = new BitmapData(Main.I.stage.stageWidth, Main.I.stage.stageHeight, true);
			this.bitmapData = data;
		}
		
		public function Draw():void {
			data.lock();
			
			data.floodFill(0, 0, 0xFF000000);
			
			data.unlock();
		}
		
	}
	
}