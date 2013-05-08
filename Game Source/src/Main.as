package {
	import flash.desktop.NativeApplication;
	import flash.display.NativeWindow;
	import flash.events.Event;
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.events.InvokeEvent;
	import flash.events.TouchEvent;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	import Game.Equipment.EquipmentManager;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import Game.Map.WorldData;
	import InputSystems.IInputSystem;
	import InputSystems.KeyboardInput;
	import InputSystems.TouchInput;
	import Interfaces.IObjectLayer;
	import Interfaces.IUpdatable;
	import RenderSystem.Renderman;
	import SoundSystem.MusicPlayer;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class Main extends Sprite {
		//So can link back to this
		public static var I:Main;
		
		public static var OrderedLayer:Sprite = new Sprite();
		public static var Updatables:Vector.<IUpdatable> = new Vector.<IUpdatable>();
		
		public static var Input:IInputSystem;
		
		//Some other important things
		public var Renderer:Renderman;
		
		public function Main():void {
			I = this;
			
			stage.scaleMode = StageScaleMode.NO_SCALE;
			stage.align = StageAlign.TOP_LEFT;
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
			var loadMap:String = "";
			
			if (e.arguments.length > 0) {
				var args:Array = e.arguments.join(" ").split("|");
				
				if ((args[0] as String).indexOf("map=") == 0) {
					loadMap = (args[0] as String).substr(4);
				}
			}
			
			//Set up some other things
			Renderer = new Renderman();
			
			BinaryLoader.Initialize();
			ImageLoader.Initialize();
			
			WorldData.Initialize(loadMap);
			new EquipmentManager();
			
			stage.addEventListener(Event.RESIZE, Resized);
			stage.addEventListener(Event.ENTER_FRAME, Cycle);
			
			Resized();
		}
		
		private function deactivate(e:Event):void {
			// auto-close if mobile device :)
			if (Multitouch.supportsTouchEvents && Multitouch.maxTouchPoints > 1) {
				NativeApplication.nativeApplication.exit();
			}
		}
		
		private function Cycle(e:* = null):void {
			var dt:Number = 1.0 / stage.frameRate;
			var i:int;
			
			//Update what we need to update
			i = Updatables.length;
			while (--i > -1) {
				Updatables[i].Update(dt);
			}
			
			//Sort the children
			i = OrderedLayer.numChildren;
			while(--i > 4) {
				TrySwap(i-0);
				TrySwap(i-1);
				TrySwap(i-2);
				TrySwap(i-3);
				TrySwap(i-4);
			}
			
			//Do some fading?
			if (Global.PrevLoadingTotal == 0 && Global.LoadingTotal != 0) {
				//fade out
				Renderer.FadeToBlack();
			} else if (Global.PrevLoadingTotal > 0 && Global.LoadingTotal == 0) {
				//fade in
				Renderer.FadeToWorld();
			}
			
			Global.PrevLoadingTotal = Global.LoadingTotal;
			
			Renderer.Render(dt);
		}
		
		private function TrySwap(i:int):void {
			if ((IObjectLayer)(OrderedLayer.getChildAt(i)).GetTrueY() < (IObjectLayer)(OrderedLayer.getChildAt(i-1)).GetTrueY()) {
				OrderedLayer.swapChildrenAt(i, i-1);
			}
		}
		
		private function Resized(e:* = null):void {
			Renderer.Resized();
		}
		
	}
	
}