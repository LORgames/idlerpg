package RenderSystem {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Matrix;
	
	/**
	 * ...
	 * @author Miles
	 */
	public class LoadScreen extends Bitmap {
		[Embed(source = "../../lib/LoadingBackground.png")] private var BGImage:Class;
		public var RealAlpha:uint = 255;
		
		public function LoadScreen() {
			RealAlpha = 0;
			this.bitmapData = (new BGImage() as Bitmap).bitmapData;
		}
		
		public function Resized():void {
			this.scaleX = Main.I.stage.stageWidth / this.width;
			this.scaleY = Main.I.stage.stageHeight / this.height;
			Draw();
		}
		
		public function Draw():void {
			this.alpha = RealAlpha / 255.0;
		}
	}
}