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
				
				if (ke.keyCode == Keyboard.W) {
					WorldData.ME.RequestMove(0, -1);
				} else if (ke.keyCode == Keyboard.S) {
					WorldData.ME.RequestMove(0, 1);
				} else if (ke.keyCode == Keyboard.A) {
					WorldData.ME.RequestMove(-1, 0);
				} else if (ke.keyCode == Keyboard.D) {
					WorldData.ME.RequestMove(1, 0);
				}
				
				if (ke.keyCode == Keyboard.SPACE) {
					WorldData.ME.RequestBasicAttack();
				}
			}
		}
		
		private function KeyUp(ke:KeyboardEvent):void {
			downKeys[ke.keyCode] = false;
			
			if(ke.keyCode != Keyboard.SPACE) {
				WorldData.ME.RequestMove(0, 0);
			}
		}
		
		private static function WipeKeys(e:Event):void {
			for (var key:String in downKeys) {
				downKeys[key] = false;
			}
		}
		
	}

}