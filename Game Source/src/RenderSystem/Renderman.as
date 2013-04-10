package RenderSystem {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class Renderman {
		
		public var bitmap:Bitmap;
		private var data:BitmapData; // Display thing: very bad if this needs to be resized
		
		public function Renderman() {
			bitmap = new Bitmap();
		}
		
		public function Resized():void {
			data = new BitmapData(Main.I.stage.stageWidth, Main.I.stage.stageHeight, false);
			bitmap.bitmapData = data;
		}
		
		public function Render():void {
			data.lock();
			
			
			
			data.unlock();
		}
		
	}

}