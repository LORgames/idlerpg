package {
	import EngineTiming.Clock;
	import flash.desktop.NativeApplication;
	import flash.display.NativeWindow;
	import flash.display.Screen;
	import flash.display.StageQuality;
	import flash.events.Event;
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.events.InvokeEvent;
	import flash.events.TouchEvent;
	import flash.text.TextField;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	import Game.Critter.CritterManager;
	import Game.Equipment.EquipmentManager;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import Game.Map.WorldData;
	import InputSystems.IInputSystem;
	import InputSystems.KeyboardInput;
	import InputSystems.TouchInput;
	import RenderSystem.IObjectLayer;
	import EngineTiming.IUpdatable;
	import RenderSystem.Renderman;
	import SoundSystem.MusicPlayer;
	import WindowSystem.HUD;
	import WindowSystem.ScreenText;
	
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
			stage.quality = StageQuality.LOW;
			
			stage.addEventListener(Event.DEACTIVATE, deactivate);
			
			NativeApplication.nativeApplication.addEventListener(InvokeEvent.INVOKE, OnInvoke);
			
			// touch or gesture?
			Multitouch.inputMode = MultitouchInputMode.TOUCH_POINT;
			
			if (NativeWindow.isSupported && stage.nativeWindow.maximizable) {
				stage.nativeWindow.maximize();
			}
			
			//Need more logic to adding input system?
			if(Multitouch.supportsTouchEvents && Multitouch.maxTouchPoints > 1) {
				Input = new TouchInput();//new KeyboardInput();
			} else {
				Input = new KeyboardInput();
			}
		}
		
		private function OnInvoke(e:InvokeEvent):void {
			var loadMap:String = "Star Shrine";//"Tutorial Fair";
			
			if (e.arguments.length > 0) {
				var args:Array = e.arguments.join(" ").split("|");
				
				if ((args[0] as String).indexOf("map=") == 0) {
					loadMap = (args[0] as String).substr(4);
				}
			}
			
			//Set up some other things
			Renderer = new Renderman();
			Renderer.FadeToBlack(null, loadMap==""?"Tutorial":loadMap);
			
			BinaryLoader.Initialize();
			ImageLoader.Initialize();
			
			WorldData.Initialize(loadMap);
			
			new EquipmentManager();
			new CritterManager();
			
			Clock.I.Start(stage);
			
			stage.addEventListener(Event.RESIZE, Resized);
			
			this.addChild(new HUD());
			
			Resized();
		}
		
		private function deactivate(e:Event):void {
			// auto-close if mobile device :)
			if (Multitouch.supportsTouchEvents && Multitouch.maxTouchPoints > 1) {
				NativeApplication.nativeApplication.exit();
			}
		}
		
		private function Resized(e:* = null):void {
			Renderer.Resized();
		}
		
	}
	
}