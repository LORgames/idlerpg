package RenderSystem.Overlays 
{
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.BlendMode;
	import flash.display.Sprite;
	/**
	 * ...
	 * @author Paul
	 */
	public class CaveLight extends Bitmap {
		
		public function CaveLight() {
			this.blendMode = BlendMode.MULTIPLY;
			Reset();
		}
		
		public function Reset():void {
			if (this.bitmapData != null) {
				this.bitmapData.dispose();
			}
			
			this.bitmapData = new BitmapData(Main.I.stage.width, Main.I.stage.height, true, 0x00FFFFFF);
			
			var s:Sprite = new Sprite();
			//s.graphics.beginFill(0x00009B, 1);
			s.graphics.beginFill(0x7A4500, 1);
			s.graphics.drawRect(0, 0, Main.I.stage.stageWidth, Main.I.stage.stageHeight);
			//s.graphics.drawCircle(Main.I.stage.stageWidth / 2, Main.I.stage.stageHeight / 2, 200);
			s.graphics.endFill();
			
			this.bitmapData.draw(s);
		}
		
	}

}