package WindowSystem.AdvancedScrollWindow.ScrollPanel {
	import adobe.utils.CustomActions;
	import flash.display.Sprite;
	import flash.text.TextField;
	import WindowSystem.Fonts;
	/**
	 * ...
	 * @author Paul
	 */
	public class ScrollPanel extends Sprite {
		public var Items:Vector.<ScrollPanelItem> = new Vector.<ScrollPanelItem>();
		
		public var Title:TextField = new TextField();
		
		public function ScrollPanel() {
			Title = Fonts.GetTextField(24, Fonts.Header);
			this.addChild(Title);
			Title.text = "Inventory";
		}
		
		public function Resize(width:int, height:int):void {
			this.graphics.clear();
			
			this.graphics.beginFill(0xFF0000, 0.7);
			this.graphics.drawRect(10, 40, width-17, height-47);
			this.graphics.endFill();
			
			Title.x = (width - Title.width) / 2;
			Title.y = 7;
		}
		
		public function AddItem(newItem:ScrollPanelItem):void {
			
		}
		
	}

}