package InputSystems {
	import Debug.Drawer;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.KeyboardEvent;
	import flash.events.MouseEvent;
	import flash.events.TouchEvent;
	import flash.ui.Keyboard;
	import flash.ui.Multitouch;
	import flash.utils.getTimer;
	import Game.Map.WorldData;
	import UI.UIManager;
	/**
	 * ...
	 * @author Paul
	 */
	public class MouseInput implements IInputSystem {
		private var isMouseDown:Boolean = false;
		
		private var lastTouchTime:int = 0;
		private var lastTouchX:int = 0;
		private var lastTouchY:int = 0;
		
		private const TOUCH_DELAY_MULTITAP:int = 300;
		private const TOUCH_RANGE_MULTITAP:int = 20;	//pixels for it to be considered a multitap: should really be DPI independant
		
		public function MouseInput() {
			Main.I.stage.addEventListener(MouseEvent.MOUSE_DOWN, TouchDown);
			Main.I.stage.addEventListener(MouseEvent.MOUSE_UP, TouchUp);
			Main.I.stage.addEventListener(MouseEvent.MOUSE_MOVE, TouchMove);
			Main.I.stage.addEventListener(MouseEvent.ROLL_OUT, MouseLeft);
		}
		
		private function TouchDown(te:MouseEvent):void {
			Main.I.hud.AlertPress(te.stageX, te.stageY);
			isMouseDown = true;
			
			if (getTimer() - TOUCH_DELAY_MULTITAP < lastTouchTime) {
				if (Math.abs(te.stageX - lastTouchX) < TOUCH_RANGE_MULTITAP && Math.abs(te.stageY - lastTouchY) < TOUCH_RANGE_MULTITAP) {
					Main.I.hud.AlertDoublePress(te.stageX, te.stageY);
				}
			}
		}
		
		private function TouchUp(te:MouseEvent):void {
			Main.I.hud.AlertUnpress(te.stageX, te.stageY);
			isMouseDown = false;
			
			lastTouchTime = getTimer();
			lastTouchX = te.stageX;
			lastTouchY = te.stageY;
		}
		
		private function MouseLeft(te:MouseEvent):void {
			isMouseDown = false;
		}
		
		private function TouchMove(te:MouseEvent):void {
			if(isMouseDown) Main.I.hud.AlertPress(te.stageX, te.stageY, true);
		}
	}
}