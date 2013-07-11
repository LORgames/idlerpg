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
	import WindowSystem.AdvancedScrollWindow.AdvPanel;
	/**
	 * ...
	 * @author Paul
	 */
	public class KeyboardInput implements IInputSystem {
		protected var xSpeed:int = 0;
		protected var ySpeed:int = 0;
		
		//Earlier LORgames games used a generic input system. This game is much more specific for speed reasons
		private static var downKeys:Vector.<Boolean> = new Vector.<Boolean>(256, true);
		private static var CanTeleport:Boolean = false;
		
		public function KeyboardInput() {
			Main.I.stage.addEventListener(KeyboardEvent.KEY_DOWN, KeyDown);
			Main.I.stage.addEventListener(KeyboardEvent.KEY_UP, KeyUp);
			Main.I.stage.addEventListener(Event.DEACTIVATE, WipeKeys, false, 0, true);
			
			Main.I.stage.addEventListener(MouseEvent.CLICK, Clicked);
		}
		
		private function KeyDown(ke:KeyboardEvent):void {
			if(!downKeys[ke.keyCode]) {
				downKeys[ke.keyCode] = true;
				
				if (ke.keyCode == Keyboard.W || ke.keyCode == Keyboard.UP) ySpeed -= 1;
				if (ke.keyCode == Keyboard.S || ke.keyCode == Keyboard.DOWN) ySpeed += 1;
				if (ke.keyCode == Keyboard.A || ke.keyCode == Keyboard.LEFT) xSpeed -= 1;
				if (ke.keyCode == Keyboard.D || ke.keyCode == Keyboard.RIGHT) xSpeed += 1;
				if (ke.keyCode == Keyboard.NUMBER_7) CanTeleport = true;
				
				WorldData.ME.RequestMove(xSpeed, ySpeed);
				
				if (ke.keyCode == Keyboard.SPACE) {
					WorldData.ME.RequestBasicAttack();
				}
			}
		}
		
		private function KeyUp(ke:KeyboardEvent):void {
			downKeys[ke.keyCode] = false;
			
			if (ke.keyCode == Keyboard.W || ke.keyCode == Keyboard.UP) ySpeed += 1;
			if (ke.keyCode == Keyboard.S || ke.keyCode == Keyboard.DOWN) ySpeed -= 1;
			if (ke.keyCode == Keyboard.A || ke.keyCode == Keyboard.LEFT) xSpeed += 1;
			if (ke.keyCode == Keyboard.D || ke.keyCode == Keyboard.RIGHT) xSpeed -= 1;
			if (ke.keyCode == Keyboard.NUMBER_7) CanTeleport = false;
			
			if (ke.keyCode == Keyboard.M) {
				Main.I.stage.addChild(new CaveLight());
			}
			
			if (ke.keyCode == Keyboard.I) {
				Main.I.hud.addChild(new AdvPanel());
			}
			
			WorldData.ME.RequestMove(xSpeed, ySpeed);
		}
		
		private function WipeKeys(e:Event):void {
			for (var key:String in downKeys) {
				downKeys[key] = false;
			}
			
			ySpeed = 0;
			xSpeed = 0;
			WorldData.ME.RequestMove(xSpeed, ySpeed);
		}
		
		private function Clicked(me:MouseEvent):void {
			if (CanTeleport) {
				var xPos:int = me.stageX - Camera.X;//Main.OrderedLayer.x;
				var yPos:int = me.stageY - Camera.Y;//Main.OrderedLayer.y;
				
				WorldData.ME.X = xPos;
				WorldData.ME.Y = yPos;
			}
		}
	}

}