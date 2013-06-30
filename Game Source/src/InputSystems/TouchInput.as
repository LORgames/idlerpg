package InputSystems {
	import flash.events.Event;
	import flash.events.KeyboardEvent;
	import flash.events.MouseEvent;
	import flash.events.TouchEvent;
	import flash.ui.Keyboard;
	import Game.Map.WorldData;
	/**
	 * ...
	 * @author Paul
	 */
	public class TouchInput implements IInputSystem {
		//Earlier LORgames games used a generic input system. This game is much more specific for speed
		
		private var MovementTouch:int = -1;
		private var MovementTouchX:int = 0;
		private var MovementTouchY:int = 0;
		
		public function TouchInput() {
			Main.I.stage.addEventListener(TouchEvent.TOUCH_BEGIN, TouchDown);
			Main.I.stage.addEventListener(TouchEvent.TOUCH_END, TouchUp);
			Main.I.stage.addEventListener(TouchEvent.TOUCH_MOVE, TouchMove);
		}
		
		public function IsSupported():Boolean {
			return true; //TODO: Make this figure out whats going on?
		}
		
		private function TouchDown(te:TouchEvent):void {
			if ((te.stageX > Global.touchArea.X && te.stageX < Global.touchArea.X + Global.touchArea.W)
				&& (te.stageY > Global.touchArea.Y && te.stageY < Global.touchArea.Y + Global.touchArea.H)) {
				if (MovementTouch == -1) {
					MovementTouch = te.touchPointID;
					MovementTouchX = te.stageX;
					MovementTouchY = te.stageY;
					Global.thumb.x = MovementTouchX;
					Global.thumb.y = MovementTouchY;
				}
			} else if (te.stageX > Main.I.stage.stageWidth / 2) {
				WorldData.ME.RequestBasicAttack();
			}
		}
		
		private function TouchUp(te:TouchEvent):void {
			if (te.touchPointID == MovementTouch) {
				MovementTouch = -1;
				WorldData.ME.RequestMove(0, 0);
			}
		}
		
		private function TouchMove(te:TouchEvent):void {
			if (te.touchPointID == MovementTouch) {
				var dX:Number = te.stageX - MovementTouchX;
				var dY:Number = te.stageY - MovementTouchY;
				
				var aX:Number = Math.abs(dX);
				var aY:Number = Math.abs(dY);
				
				if (aX > aY) {
					dX /= aX;
					dY /= aX;
				} else {
					dX /= aY;
					dY /= aY;
				}
				
				if (te.stageX > Global.touchArea.X && te.stageX < Global.touchArea.X + Global.touchArea.W) {
					Global.thumb.x = te.stageX - Global.thumb.width/2;
				}
				if (te.stageY > Global.touchArea.Y && te.stageY < Global.touchArea.Y + Global.touchArea.H) {
					Global.thumb.y = te.stageY - Global.thumb.height/2;
				}
				
				WorldData.ME.RequestMove(dX, dY);
			}
		}
		
	}

}