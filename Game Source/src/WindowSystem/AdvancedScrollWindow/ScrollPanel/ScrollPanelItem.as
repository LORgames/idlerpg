package WindowSystem.AdvancedScrollWindow.ScrollPanel {
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
		
		public static function LoadIcons():void {
			ImageLoader.Load("Data/Items.png", LoadedAtlas);
		}
		
		public function ScrollPanelItem(id:int, text:String, icon:int) {
			this.SelectID = id;
			this.DisplayText = text;
			this.IconID = icon;
		}
	}
}