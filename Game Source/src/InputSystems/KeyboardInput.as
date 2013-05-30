package InputSystems {
	import flash.events.Event;
	import flash.events.KeyboardEvent;
	import flash.ui.Keyboard;
	import Game.Map.WorldData;
	/**
	 * ...
	 * @author Paul
	 */
	public class KeyboardInput implements IInputSystem {
		protected var xSpeed:int = 0;
		protected var ySpeed:int = 0;
		
		//Earlier LORgames games used a generic input system. This game is much more specific for speed reasons
		private static var downKeys:Vector.<Boolean> = new Vector.<Boolean>(256, true);
		
		public function KeyboardInput() {
			Main.I.stage.addEventListener(KeyboardEvent.KEY_DOWN, KeyDown);
			Main.I.stage.addEventListener(KeyboardEvent.KEY_UP, KeyUp);
			Main.I.stage.addEventListener(Event.DEACTIVATE, WipeKeys, false, 0, true);
		}
		
		public function IsSupported():Boolean {
			return true; //TODO: Make this figure out whats going on?
		}
		
		private function KeyDown(ke:KeyboardEvent):void {
			if(!downKeys[ke.keyCode]) {
				downKeys[ke.keyCode] = true;
				
				if (ke.keyCode == Keyboard.W) ySpeed -= 1;
				if (ke.keyCode == Keyboard.S) ySpeed += 1;
				if (ke.keyCode == Keyboard.A) xSpeed -= 1;
				if (ke.keyCode == Keyboard.D) xSpeed += 1;
				
				WorldData.ME.RequestMove(xSpeed, ySpeed);
				
				if (ke.keyCode == Keyboard.SPACE) {
					WorldData.ME.RequestBasicAttack();
				}
			}
		}
		
		private function KeyUp(ke:KeyboardEvent):void {
			downKeys[ke.keyCode] = false;
			
			if(ke.keyCode != Keyboard.SPACE) {
				if (ke.keyCode == Keyboard.W) ySpeed += 1;
				if (ke.keyCode == Keyboard.S) ySpeed -= 1;
				if (ke.keyCode == Keyboard.A) xSpeed += 1;
				if (ke.keyCode == Keyboard.D) xSpeed -= 1;
				
				WorldData.ME.RequestMove(xSpeed, ySpeed);
			}
		}
		
		private function WipeKeys(e:Event):void {
			for (var key:String in downKeys) {
				downKeys[key] = false;
			}
			
			ySpeed = 0;
			xSpeed = 0;
			WorldData.ME.RequestMove(xSpeed, ySpeed);
		}
		
	}

}