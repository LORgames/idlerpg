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
		
		public var fg:Bitmap;
		public var bg:Bitmap;
		
		public function LoadScreen() {
			RealAlpha = 0;
			
			bg = new Bitmap(new BitmapData(1, 1, false, 0xFF000000));
			fg = new BGImage() as Bitmap;
			tf = Fonts.GetTextField(30, 3);
			
			this.addChild(bg);
			this.addChild(fg);
			this.addChild(tf);
		}
		
		public function Resized():void {
			bg.scaleX = Main.I.stage.stageWidth;
			bg.scaleY = Main.I.stage.stageHeight;
			
			fg.x = (Main.I.stage.width - fg.width) / 2;
			fg.y = (Main.I.stage.height - fg.height) / 2;
			
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