package {
	import EngineTiming.Clock;
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageQuality;
	import flash.display.StageScaleMode;
	import flash.events.Event;
	import flash.system.Capabilities;
	import RenderSystem.Camera;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	import Game.Critter.CritterManager;
	import Game.Effects.EffectManager;
	import Game.Equipment.EquipmentManager;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import Game.Map.WorldData;
	import InputSystems.IInputSystem;
	import InputSystems.KeyboardInput;
	import InputSystems.TouchInput;
	import RenderSystem.Renderman;
	import SoundSystem.MusicPlayer;
	import Storage.SaveManager;
	import WindowSystem.HUD;
	
	CONFIG::air {
		import flash.desktop.NativeApplication;
		import flash.display.NativeWindow;
		import flash.display.Screen;
		import flash.events.InvokeEvent;
	}
	
	/**
	 * ...
	 * @author Paul
	 */
	public class Main extends Sprite {
		//So can link back to this
		public static var I:Main;
		
		public static var OrderedLayer:Sprite = new Sprite();
		public static var Input:IInputSystem;
		public var hud:HUD = new HUD();
		
		//Some other important things
		public var Renderer:Renderman;
		
		public function Main():void {
			I = this;
			
			stage.scaleMode = StageScaleMode.NO_SCALE;
			stage.align = StageAlign.TOP_LEFT;
			stage.quality = StageQuality.LOW;
			
			stage.addEventListener(Event.DEACTIVATE, OnLostFocus);
			
			//Need more logic to adding input system?
			if (Multitouch.supportsTouchEvents && Multitouch.maxTouchPoints > 1) {
				// touch or gesture?
				Multitouch.inputMode = MultitouchInputMode.TOUCH_POINT;
				Input = new TouchInput();//new KeyboardInput();
			} else {
				Input = new KeyboardInput();
			}
			
			CONFIG::air {			
				if (NativeWindow.isSupported && stage.nativeWindow.maximizable) {
					stage.nativeWindow.maximize();
				}
				
				NativeApplication.nativeApplication.addEventListener(InvokeEvent.INVOKE, OnInvoke);
			}
			
			if(CONFIG::air == false) {
				if(!stage) {
					this.addEventListener(Event.ADDED_TO_STAGE, OnInvoke);
				} else {
					OnInvoke(null);
				}
			}
		}
		
		private function OnInvoke(e:Event):void {
			//Important Things
			SaveManager.Initialize();
			
			var loadMap:String = "Tutorial Fair";
			
			CONFIG::air {
				if ((e as InvokeEvent).arguments.length > 0) {
					var args:Array = (e as InvokeEvent).arguments.join(" ").split("+");
					
					for (var i:int = 0; i < args.length; i++) {
						var arg:String = args[i];
						if(arg.indexOf("=") == -1) continue;
						
						var param:String = (arg.split("=")[0] as String).toLowerCase();
						
						switch(param) {
							case "map":
								loadMap = arg.substr(4);
								break;
							case "debug":
								if (arg.substr(6) == "Yes") {
									Global.DebugRender = true;
								} else {
									Global.DebugRender = false;
								} break;
							case "showfps":
								if (arg.substr(8) == "Yes") {
									Global.DebugFPS = true;
								} else {
									Global.DebugFPS = false;
								} break;
							case "music":
								if (arg.substr(6) == "Yes") {
									MusicPlayer.MusicEnabled = true;
								} else {
									MusicPlayer.MusicEnabled = false;
								} break;
							case "save":
								SaveManager.Load(arg.substr(6)); break;
							default:
								trace("Unknown Param: " + arg);
						}
					}
				}
			}
			
			//Set up some other things
			Renderer = new Renderman();
			Renderer.FadeToBlack(null, loadMap);
			
			BinaryLoader.Initialize();
			ImageLoader.Initialize();
			
			WorldData.Initialize(loadMap);
			
			new EquipmentManager();
			new CritterManager();
			new EffectManager();
			
			Clock.I.Start(stage);
			
			stage.addEventListener(Event.RESIZE, Resized);
			
			this.addChild(hud);
			
			//var c:CaveLight = new CaveLight();
			//this.addChild(c);
			//c.Reset();
			
			Resized();
		}
		
		private function OnLostFocus(e:Event):void {
			// auto-close if mobile device :)
			CONFIG::air {
				if (Multitouch.supportsTouchEvents && Multitouch.maxTouchPoints > 1) {
					NativeApplication.nativeApplication.exit();
				}
			}
		}
		
		private function Resized(e:* = null):void {
			if (Capabilities.screenDPI > 250) {
				Camera.Z = 2;
			}
			
			Renderer.Resized();
			hud.Resized();
		}
		
	}
	
}