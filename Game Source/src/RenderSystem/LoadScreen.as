package RenderSystem {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Matrix;
	import flash.text.TextField;
	import Loaders.BinaryLoader;
	import UI.Fonts;
	
	/**
	 * ...
	 * @author Miles
	 */
	public class LoadScreen extends Sprite {
		[Embed(source = "../../lib/LoadingBackground.png")] private var BGImage:Class;
		
		public var RealAlpha:uint = 255;
		public var tf:TextField;
		
		private var oX:int = 0;
		private var oY:int = 0;
		
		public function LoadScreen() {
			tf = Fonts.GetTextField(30, 3);
			RealAlpha = 0;
			
			this.addChild(new BGImage() as Bitmap);
			this.addChild(tf);
			
			oX = this.getChildAt(0).width;
			oY = this.getChildAt(0).height;
		}
		
		public function Resized():void {
			this.getChildAt(0).scaleX = Main.I.stage.stageWidth / oX;
			this.getChildAt(0).scaleY = Main.I.stage.stageHeight / oY;
			
			Draw();
		}
		
		public function Draw():void {
			this.alpha = RealAlpha / 255.0;
			
			if (RealAlpha == 255 && this.parent == null) Main.I.addChild(this);
			if (RealAlpha == 0 && this.parent != null) this.parent.removeChild(this);
			
			tf.text = Global.LoadingTotal + " items remaining.";
			tf.x = (Main.I.stage.stageWidth - tf.width) / 2;
		}
	}
}