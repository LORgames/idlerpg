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
		private var bossHPBar:Bitmap;
		private var butnsX:Bitmap;
		
		//Touch stuff
		public var TouchArea:Rect = new Rect(true, null);
		private var Stick:Bitmap;
		public var Thumb:Bitmap;
		
		public function HUD() {
			//ImageLoader.Load("OtherUI/Buttons.png", LoadedButtonsArt); Global.LoadingTotal++;
			//ImageLoader.Load("OtherUI/Stick.png", LoadedStickArt); Global.LoadingTotal++;
			//ImageLoader.Load("OtherUI/Thumb.png", LoadedThumbArt); Global.LoadingTotal++; //THUMB MUST LOAD AFTER STICK!!!
			//ImageLoader.Load("OtherUI/UI Test.png", LoadedBossHP); Global.LoadingTotal++;
			ScrollPanelItem.LoadIcons();
			
			if(Global.DebugFPS) this.addChild(new FPSCounter());
		}
		
		public function Resized():void {
			if (bossHPBar != null) {
				bossHPBar.x = (this.stage.stageWidth - bossHPBar.width) * 0.5;
				bossHPBar.y = (this.stage.stageHeight-bossHPBar.height) * 0.5;
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