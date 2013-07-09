package WindowSystem.AdvancedScrollWindow {
	import adobe.utils.CustomActions;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import Game.General.ImageLoader;
	import WindowSystem.AdvancedScrollWindow.ScrollPanel.ScrollPanel;
	import WindowSystem.AdvancedScrollWindow.LeftPanels.EquipmentPanel;
	import WindowSystem.AdvancedScrollWindow.ScrollPanel.ScrollPanelItem;
	/**
	 * ...
	 * @author Paul
	 */
	public class AdvPanel extends Sprite {
		
		public var background:Bitmap = new Bitmap();
		public var Panel1:IAdvLeftPanel;
		public var Panel2:ScrollPanel = new ScrollPanel();
		
		public function AdvPanel() {
			ImageLoader.Load("OtherUI/PanelBG.png", LoadedPanel);
		}
		
		public function LoadedPanel(e:BitmapData):void {
			background = new Bitmap(e.clone());
			this.addChild(background);
			
			this.x = (stage.stageWidth - this.width) / 2;
			this.y = (stage.stageHeight - this.height) / 2;
			
			Panel1 = new EquipmentPanel();
			Panel1.Resize(this.width / 2, this.height);
			this.addChild(Panel1.GetDisplayObject());
			
			this.addChild(Panel2);
			Panel2.Resize(this.width / 2, this.height);
			Panel2.x = this.width / 2;
			
			Panel2.AddItem(new ScrollPanelItem(0, "Bow", 0));
		}
	}
}