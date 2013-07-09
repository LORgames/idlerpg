package RenderSystem {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Matrix;
	
	/**
	 * ...
	 * @author Miles
	 */
	public class LoadScreen extends Bitmap {
		public var RealAlpha:uint = 255;
		
		public function LoadScreen() {
			this.bitmapData = new BitmapData(1, 1, true, 0x000000 | RealAlpha << 24);
		}
		
		public function Resized():void {
			this.scaleX = Main.I.stage.stageWidth;
			this.scaleY = Main.I.stage.stageHeight;
			Draw();
		}
		
		public function Draw():void {
			this.bitmapData.setPixel32(0, 0, 0x000000 | RealAlpha << 24);
		}
		
	}
	
}