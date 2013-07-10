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
		private var PreviousX:int = 0;
		private var PreviousY:int = 0;
		
		public function TouchInput() {
			if(Multitouch.maxTouchPoints > 1) {
				Main.I.stage.addEventListener(TouchEvent.TOUCH_BEGIN, TouchDown);
				Main.I.stage.addEventListener(TouchEvent.TOUCH_END, TouchUp);
				Main.I.stage.addEventListener(TouchEvent.TOUCH_MOVE, TouchMove);
			} else {
				Main.I.stage.addEventListener(MouseEvent.MOUSE_DOWN, MouseDown);
				Main.I.stage.addEventListener(MouseEvent.MOUSE_UP, MouseUp);
				Main.I.stage.addEventListener(MouseEvent.MOUSE_MOVE, MouseMove);
			}
		}
		
		public function IsSupported():Boolean {
			return true; //TODO: Make this figure out whats going on?
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
		
		private function MouseDown(te:MouseEvent):void {
			var hud:HUD = Main.I.hud;
			
			if (hud.TouchArea.ContainsPoint(te.stageX, te.stageY)) {
				if (MovementTouch == -1) {
					MovementTouch = 1;
					hud.Thumb.x = te.stageX - hud.Thumb.width*0.5;
					hud.Thumb.y = te.stageY - hud.Thumb.height*0.5;
				}
			} else if (te.stageX > Main.I.stage.stageWidth*0.5) {
				WorldData.ME.RequestBasicAttack();
			}
		}
		
		private function MouseUp(te:MouseEvent):void {
			if (1 == MovementTouch) {
				var hud:HUD = Main.I.hud;
				
				MovementTouch = -1;
				WorldData.ME.RequestMove(0, 0);
				hud.ResetThumb();
			}
		}
		
		private function MouseMove(te:MouseEvent):void {
			if (1 == MovementTouch) {
				var hud:HUD = Main.I.hud;
				
				var xPos:Number = (te.stageX - hud.TouchArea.X) / hud.TouchArea.W;
				var yPos:Number = (te.stageY - hud.TouchArea.Y) / hud.TouchArea.H;
				
				if (hud.TouchArea.ContainsPoint(te.stageX, te.stageY)) {
					hud.Thumb.x = te.stageX - hud.Thumb.width * 0.5;
					hud.Thumb.y = te.stageY - hud.Thumb.height * 0.5;
					
					WorldData.ME.RequestMove((xPos-0.5)*2, (yPos-0.5)*2);
				}
			}
		}
		
	}

}