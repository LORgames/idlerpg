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
	public class TouchInput implements IInputSystem {
		
		private var lastTouchTime:int = 0;
		private var lastTouchX:int = 0;
		private var lastTouchY:int = 0;
		
		private const TOUCH_DELAY_MULTITAP:int = 300;
		private const TOUCH_RANGE_MULTITAP:int = 20;	//pixels for it to be considered a multitap: should really be DPI independant
		
		public function TouchInput() {
			Main.I.stage.addEventListener(TouchEvent.TOUCH_BEGIN, TouchDown);
			Main.I.stage.addEventListener(TouchEvent.TOUCH_END, TouchUp);
			Main.I.stage.addEventListener(TouchEvent.TOUCH_MOVE, TouchMove);
		}
		
		private function TouchDown(te:TouchEvent):void {
			Main.I.hud.AlertPress(te.stageX, te.stageY);
			
			if (getTimer() - TOUCH_DELAY_MULTITAP < lastTouchTime) {
				if (Math.abs(te.stageX - lastTouchX) < TOUCH_RANGE_MULTITAP && Math.abs(te.stageY - lastTouchY) < TOUCH_RANGE_MULTITAP) {
					Main.I.hud.AlertDoublePress(te.stageX, te.stageY);
				}
			}
		}
		
		private function TouchUp(te:TouchEvent):void {
			Main.I.hud.AlertUnpress(te.stageX, te.stageY);
			
			lastTouchTime = getTimer();
			lastTouchX = te.stageX;
			lastTouchY = te.stageY;
		}
		
		private function TouchMove(te:TouchEvent):void {
			Main.I.hud.AlertPress(te.stageX, te.stageY, true);
		}
	}

}