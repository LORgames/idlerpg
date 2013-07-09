package WindowSystem.AdvancedScrollWindow.LeftPanels {
	import flash.display.DisplayObject;
	import flash.display.Sprite;
	import WindowSystem.AdvancedScrollWindow.IAdvLeftPanel;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentPanel extends Sprite implements IAdvLeftPanel {
		
		public function EquipmentPanel() {
			
		}
		
		/* INTERFACE WindowSystem.AdvancedScrollWindow.IAdvLeftPanel */
		
		public function Resize(width:int, height:int):void {
			
		}
		
		public function CleanUp():void {
			
		}
		
		public function GetDisplayObject():DisplayObject {
			return this;
		}
		
	}

}