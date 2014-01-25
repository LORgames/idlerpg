package InputSystems {
	import flash.events.Event;
	import flash.events.KeyboardEvent;
	import flash.events.MouseEvent;
	import RenderSystem.Camera;
	import flash.ui.Keyboard;
	import Game.Effects.EffectInstance;
	import Game.Effects.EffectManager;
	import Game.Map.WorldData;
	import RenderSystem.Overlays.CaveLight;
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
		
		private function KeyDown(ke:KeyboardEvent):void {
			if(!downKeys[ke.keyCode]) {
				downKeys[ke.keyCode] = true;
				
				if (ke.keyCode == Keyboard.F12) Global.Out.Connect();
			}
		}
		
		private function KeyUp(ke:KeyboardEvent):void {
			downKeys[ke.keyCode] = false;
		}
		
		private function WipeKeys(e:Event):void {
			for (var key:String in downKeys) {
				downKeys[key] = false;
			}
		}
	}

}