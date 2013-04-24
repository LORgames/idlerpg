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
		//Earlier LORgames games used a generic input system. This game is much more specific for speed
		
		public function KeyboardInput() {
			Main.I.stage.addEventListener(KeyboardEvent.KEY_DOWN, KeyDown);
			Main.I.stage.addEventListener(KeyboardEvent.KEY_UP, KeyUp);
		}
		
		public function IsSupported():Boolean {
			return true; //TODO: Make this figure out whats going on?
		}
		
		private function KeyDown(ke:KeyboardEvent):void {
			if (ke.keyCode == Keyboard.W) {
				WorldData.ME.RequestMove(2);
			} else if (ke.keyCode == Keyboard.S) {
				WorldData.ME.RequestMove(3);
			} else if (ke.keyCode == Keyboard.A) {
				WorldData.ME.RequestMove(0);
			} else if (ke.keyCode == Keyboard.D) {
				WorldData.ME.RequestMove(1);
			}
		}
		
		private function KeyUp(ke:KeyboardEvent):void {
			
		}
		
	}

}