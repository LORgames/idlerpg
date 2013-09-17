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
	public class MouseInput implements IInputSystem {
		private var isMouseDown:Boolean = false;
		
		public function MouseInput() {
			Main.I.stage.addEventListener(MouseEvent.MOUSE_DOWN, TouchDown);
			Main.I.stage.addEventListener(MouseEvent.MOUSE_UP, TouchUp);
			Main.I.stage.addEventListener(MouseEvent.MOUSE_MOVE, TouchMove);
			Main.I.stage.addEventListener(MouseEvent.MOUSE_OUT, MouseLeft);
		}
		
		private function TouchDown(te:MouseEvent):void {
			Main.I.hud.AlertPress(te.stageX, te.stageY);
			isMouseDown = true;
		}
		
		private function TouchUp(te:MouseEvent):void {
			Main.I.hud.AlertUnpress(te.stageX, te.stageY);
			isMouseDown = false;
		}
		
		private function MouseLeft(te:MouseEvent):void {
			isMouseDown = false;
		}
		
		private function TouchMove(te:MouseEvent):void {
			if(isMouseDown) Main.I.hud.AlertPress(te.stageX, te.stageY);
		}
	}
}