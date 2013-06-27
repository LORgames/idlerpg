package WindowSystem 
{
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import Game.General.ImageLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class HUD extends Sprite {
		
		private var expBar:Bitmap;
		private var butnsX:Bitmap;
		
		public function HUD() {
			ImageLoader.Load("OtherUI/exp bar.png", LoadedExperienceArt);
			ImageLoader.Load("OtherUI/Buttons.png", LoadedButtonsArt);
		}
		
		public function LoadedExperienceArt(e:BitmapData):void {
			expBar = new Bitmap(e.clone());
			this.addChild(expBar);
			
			expBar.x = (this.stage.stageWidth - expBar.width) / 2;
			expBar.y = this.stage.stageHeight - (expBar.height + 5);
		}
		
		public function LoadedButtonsArt(e:BitmapData):void {
			butnsX = new Bitmap(e.clone());
			this.addChild(butnsX);
			
			butnsX.x = this.stage.stageWidth - (butnsX.width + 5);
			butnsX.y = this.stage.stageHeight - (butnsX.height + 5);
		}
		
	}

}