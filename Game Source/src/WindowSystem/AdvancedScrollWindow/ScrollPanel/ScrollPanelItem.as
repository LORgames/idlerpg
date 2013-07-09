package WindowSystem.AdvancedScrollWindow.ScrollPanel {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import Game.General.ImageLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class ScrollPanelItem extends Sprite {
		public var SelectID:int;
		public var DisplayText:String;
		public var IconID:int;
		
		private static var IconAtlas:BitmapData;
		private static var BackgroundData:BitmapData;
		
		public static function LoadIcons():void {
			ImageLoader.Load("Data/Items.png", LoadedAtlas);
			ImageLoader.Load("OtherUI/PanelInfoScroller.png", LoadedAtlas);
			
			Global.LoadingTotal += 2;
		}
		
		private static function LoadedAtlas(e:BitmapData):void {
			IconAtlas = e.clone();
			Global.LoadingTotal--;
		}
		
		private static function LoadedBackground(e:BitmapData):void {
			BackgroundData = e.clone();
			Global.LoadingTotal--;
		}
		
		public function ScrollPanelItem(id:int, text:String, icon:int) {
			this.SelectID = id;
			this.DisplayText = text;
			this.IconID = icon;
			
			this.addChild(new Bitmap(BackgroundData));
		}
	}
}