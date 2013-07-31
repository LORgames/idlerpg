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
	import WindowSystem.HUD;
	/**
	 * ...
	 * @author Paul
	 */
	public class TouchInput implements IInputSystem {
		//Earlier LORgames games used a generic input system. This game is much more specific for speed
		private var MovementTouch:int = -1;
		
		public function TouchInput() {
			Main.I.stage.addEventListener(TouchEvent.TOUCH_BEGIN, TouchDown);
			Main.I.stage.addEventListener(TouchEvent.TOUCH_END, TouchUp);
			Main.I.stage.addEventListener(TouchEvent.TOUCH_MOVE, TouchMove);
		}
		
		private function TouchDown(te:TouchEvent):void {
			var hud:HUD = Main.I.hud;
			
			if (hud.TouchArea.ContainsPoint(te.stageX, te.stageY)) {
				if (MovementTouch == -1) {
					MovementTouch = te.touchPointID;
					hud.Thumb.x = te.stageX - hud.Thumb.width * 0.5;
					hud.Thumb.y = te.stageY - hud.Thumb.height * 0.5;
				}
			} else if (te.stageX > Main.I.stage.stageWidth*0.5) {
				WorldData.ME.RequestBasicAttack();
			}
		}
		
		private function TouchUp(te:TouchEvent):void {
			if (te.touchPointID == MovementTouch) {
				var hud:HUD = Main.I.hud;
				
				MovementTouch = -1;
				WorldData.ME.RequestMove(0, 0);
				hud.ResetThumb();
			}
		}
		
		private function TouchMove(te:TouchEvent):void {
			if (te.touchPointID == MovementTouch) {
				var hud:HUD = Main.I.hud;
				
				
				var xPos:Number = (te.stageX - hud.TouchArea.X) / hud.TouchArea.W;
				var yPos:Number = (te.stageY - hud.TouchArea.Y) / hud.TouchArea.H;
				
				if (hud.TouchArea.ContainsPoint(te.stageX, te.stageY)) {
					hud.Thumb.x = te.stageX - hud.Thumb.width*0.5;
					hud.Thumb.y = te.stageY - hud.Thumb.height*0.5;
					
					WorldData.ME.RequestMove((xPos-0.5)*2, (yPos-0.5)*2);
				}
			}
		}
	}

}