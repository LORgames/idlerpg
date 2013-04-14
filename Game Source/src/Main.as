package {
	import flash.display.Sprite;
	import flash.events.Event;
	import Game.General.BinaryLoader;
	import Game.Map.WorldData;
	import RenderSystem.Renderman;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class Main extends Sprite {
		//So can link back to this
		public static var I:Main;
		
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
			
			Renderer = new Renderman();
			this.addChild(Renderer.bitmap);
			
			BinaryLoader.Initialize();
			
			WorldData.Initialize();
			
			stage.addEventListener(Event.RESIZE, Resized);
			stage.addEventListener(Event.ENTER_FRAME, Cycle);
			
			
			Resized();
		}
		
		private function Cycle(e:* = null):void {
			Renderer.Render();
		}
		
		private function Resized(e:* = null):void {
			Renderer.Resized();
		}
		
	}
	
}