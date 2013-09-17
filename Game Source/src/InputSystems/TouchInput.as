package InputSystems {
	import Debug.Drawer;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.KeyboardEvent;
	import flash.events.MouseEvent;
	import flash.events.TouchEvent;
	import flash.ui.Keyboard;
	import flash.ui.Multitouch;
	import Game.Map.WorldData;
	import UI.UIManager;
	/**
	 * ...
	 * @author Paul
	 */
	public class TouchInput implements IInputSystem {
		
		public function TouchInput() {
			Main.I.stage.addEventListener(TouchEvent.TOUCH_BEGIN, TouchDown);
			Main.I.stage.addEventListener(TouchEvent.TOUCH_END, TouchUp);
			Main.I.stage.addEventListener(TouchEvent.TOUCH_MOVE, TouchMove);
		}
		
		private function TouchDown(te:TouchEvent):void {
			Main.I.hud.AlertPress(te.stageX, te.stageY);
		}
		
		private function TouchUp(te:TouchEvent):void {
			Main.I.hud.AlertUnpress(te.stageX, te.stageY);
		}
		
		private function TouchMove(te:TouchEvent):void {
			Main.I.hud.AlertPress(te.stageX, te.stageY);
		}
	}

}