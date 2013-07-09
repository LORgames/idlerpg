package WindowSystem 
{
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import Game.General.ImageLoader;
	import WindowSystem.AdvancedScrollWindow.AdvPanel;
	/**
	 * ...
	 * @author Paul
	 */
	public class HUD extends Sprite {
		
		private var expBar:Bitmap;
		private var butnsX:Bitmap;
		private var stick:Bitmap;
		
		public function HUD() {
			ImageLoader.Load("OtherUI/exp bar.png", LoadedExperienceArt);
			ImageLoader.Load("OtherUI/Buttons.png", LoadedButtonsArt);
			ImageLoader.Load("OtherUI/Stick.png", LoadedStickArt);
			ImageLoader.Load("OtherUI/Thumb.png", LoadedThumbArt);
			
			if(Global.DebugFPS) {
				this.addChild(new FPSCounter());
				this.graphics.beginFill(0xFFFF00, 0.8);
				this.graphics.drawRect(0, 0, 100, 25);
				this.graphics.endFill();
			}
			
			this.addChild(new AdvPanel());
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
		
		public function LoadedStickArt(e:BitmapData):void {
			stick = new Bitmap(e.clone());
			this.addChild(stick);
			
			stick.x = 0;
			stick.y = this.stage.stageHeight - (stick.height + 5);
			Global.touchArea.X = stick.x;
			Global.touchArea.Y = stick.y;
			Global.touchArea.W = stick.width;
			Global.touchArea.H = stick.height;
		}
		
		public function LoadedThumbArt(e:BitmapData):void {
			Global.thumb = new Bitmap(e.clone());
			this.addChild(Global.thumb);
			
			Global.thumb.x = stick.width*0.5 - Global.thumb.width*0.5;
			Global.thumb.y = this.stage.stageHeight - ((stick.height - Global.thumb.height*0.5) + 5);
		}
	}

}