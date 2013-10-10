package UI {
	import flash.display.Sprite;
	/**
	 * ...
	 * @author Paul
	 */
	
	public class UIPanel extends Sprite {
		public var Elements:Vector.<UIElement>;
		
		public var HasTouchElements:Boolean = false;
		
		public function UIPanel():void {
			
		}
		
		public function Draw(w:int, h:int, ui:UIManager):void {
			var i:int = Elements.length;
            while (--i > -1) {
				Elements[i].Draw(w, h, ui);
			}
        }
	}
}