package WindowSystem 
{
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import Game.General.ImageLoader;
	import WindowSystem.AdvancedScrollWindow.AdvPanel;
	import WindowSystem.AdvancedScrollWindow.ScrollPanel.ScrollPanelItem;
	/**
	 * ...
	 * @author Paul
	 */
	public class HUD extends Sprite {
		
		//UI Stuff
		private var lowerMiddle:Bitmap;
		private var bossHPBar:Bitmap;
		private var butnsX:Bitmap;
		
		//Touch stuff
		public var TouchArea:Rect = new Rect(true, null);
		private var Stick:Bitmap;
		public var Thumb:Bitmap;
		
		public function HUD() {
			//ImageLoader.Load("OtherUI/Test Boss HP.png", LoadedBossHP);
			ImageLoader.Load("OtherUI/Buttons.png", LoadedButtonsArt);
			ImageLoader.Load("OtherUI/Stick.png", LoadedStickArt);
			ImageLoader.Load("OtherUI/Thumb.png", LoadedThumbArt); //THUMB MUST LOAD AFTER STICK!!!
			//ImageLoader.Load("OtherUI/Test UI.png", LoadedLowerMiddle);
			//ScrollPanelItem.LoadIcons();
			
			if(Global.DebugFPS) this.addChild(new FPSCounter());
			
			Global.LoadingTotal += 3;
		}
		
		public function Resized():void {
			if (bossHPBar != null) {
				bossHPBar.x = (this.stage.stageWidth - bossHPBar.width) * 0.5;
				bossHPBar.y = 5;
			}
			
			if (lowerMiddle != null) {
				lowerMiddle.x = (this.stage.stageWidth - lowerMiddle.width) * 0.5;
				lowerMiddle.y = this.stage.stageHeight - (lowerMiddle.height + 5);
			}
			
			if (butnsX != null) {
				butnsX.x = this.stage.stageWidth - (butnsX.width + 5);
				butnsX.y = this.stage.stageHeight - (butnsX.height + 5);
			}
			
			if (Stick != null) {
				Stick.x = 0;
				Stick.y = this.stage.stageHeight - (Stick.height + 5);
				
				TouchArea.X = Stick.x;
				TouchArea.Y = Stick.y;
				TouchArea.W = Stick.width;
				TouchArea.H = Stick.height;
			}
			
			if (Thumb != null) {
				ResetThumb();
			}
		}
		
		public function LoadedBossHP(e:BitmapData):void {
			bossHPBar = new Bitmap(e.clone());
			this.addChild(bossHPBar);
			
			Global.LoadingTotal--;
			
			Resized();
		}
		
		public function LoadedLowerMiddle(e:BitmapData):void {
			lowerMiddle = new Bitmap(e.clone());
			this.addChild(lowerMiddle);
			
			Global.LoadingTotal--;
			
			Resized();
		}
		
		public function LoadedButtonsArt(e:BitmapData):void {
			butnsX = new Bitmap(e.clone());
			this.addChild(butnsX);
			
			Global.LoadingTotal--;
			
			Resized();
		}
		
		public function LoadedStickArt(e:BitmapData):void {
			Stick = new Bitmap(e.clone());
			this.addChild(Stick);
			
			Global.LoadingTotal--;
			
			Resized();
		}
		
		public function LoadedThumbArt(e:BitmapData):void {
			Thumb = new Bitmap(e.clone());
			this.addChild(Thumb);
			
			Global.LoadingTotal--;
			
			Resized();
		}
		
		public function ResetThumb():void {
			Thumb.x = Stick.x + (Stick.width - Thumb.width) * 0.5;
			Thumb.y = Stick.y + (Stick.height - Thumb.height) * 0.5;
		}
	}

}