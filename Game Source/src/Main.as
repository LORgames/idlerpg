package {
	import flash.desktop.NativeApplication;
	import flash.events.Event;
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	import Game.Equipment.EquipmentManager;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import Game.Map.WorldData;
	import InputSystems.IInputSystem;
	import InputSystems.KeyboardInput;
	import RenderSystem.Renderman;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class Main extends Sprite {
		//So can link back to this
		public static var I:Main;
		public static var OrderedLayer:Sprite = new Sprite();
		public static var Input:IInputSystem;
		
		//Some other important things
		public var Renderer:Renderman;
		
		public function Main():void {
			I = this;
			
			stage.scaleMode = StageScaleMode.NO_SCALE;
			stage.align = StageAlign.TOP_LEFT;
			stage.addEventListener(Event.DEACTIVATE, deactivate);
			
			// touch or gesture?
			Multitouch.inputMode = MultitouchInputMode.TOUCH_POINT;
			
			//Set up some other things
			Renderer = new Renderman();
			
			BinaryLoader.Initialize();
			ImageLoader.Initialize();
			
			WorldData.Initialize();
			new EquipmentManager();
			
			stage.addEventListener(Event.RESIZE, Resized);
			stage.addEventListener(Event.ENTER_FRAME, Cycle);
			
			Resized();
			
			//Need more logic to adding input system?
			Input = new KeyboardInput();
		}
		
		private function deactivate(e:Event):void {
			// auto-close
			NativeApplication.nativeApplication.exit();
		}
		
		private function Cycle(e:* = null):void {
			Renderer.Render();
		}
		
		private function Resized(e:* = null):void {
			Renderer.Resized();
		}
		
	}
	
}