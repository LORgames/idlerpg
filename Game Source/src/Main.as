package {
	import flash.display.Shape;
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.events.Event;
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
			
			if (stage) init();
			else addEventListener(Event.ADDED_TO_STAGE, init);
		}
		
		private function init(e:Event = null):void {
			removeEventListener(Event.ADDED_TO_STAGE, init);
			// entry point
			
			//Set up the stage
			stage.scaleMode = StageScaleMode.NO_SCALE;
			stage.align = StageAlign.TOP_LEFT;
			
			//Set up some other things
			Renderer = new Renderman();
			
			BinaryLoader.Initialize();
			ImageLoader.Initialize();
			
			WorldData.Initialize();
			
			stage.addEventListener(Event.RESIZE, Resized);
			stage.addEventListener(Event.ENTER_FRAME, Cycle);
			
			Resized();
			
			//Need more logic to adding input system?
			Input = new KeyboardInput();
		}
		
		private function Cycle(e:* = null):void {
			Renderer.Render();
		}
		
		private function Resized(e:* = null):void {
			Renderer.Resized();
		}
		
	}
	
}