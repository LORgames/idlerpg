package {
	import flash.desktop.SystemIdleMode;
	import flash.display.Sprite;
	import flash.display.StageAlign;
	import flash.display.StageQuality;
	import flash.display.StageScaleMode;
	import flash.events.Event;
	import flash.events.KeyboardEvent;
	import flash.system.Capabilities;
	import flash.ui.Keyboard;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	import Game.Map.WorldData;
	import InputSystems.IInputSystem;
	import RenderSystem.Renderman;
	import SoundSystem.MusicPlayer;
	import Storage.SaveManager;
	import UI.UIManager;
	
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
		public var hud:UIManager;
		
		//Some other important things
		public var Renderer:Renderman;
		
		public function Main():void {
			I = this;
			
			stage.scaleMode = StageScaleMode.NO_SCALE;
			stage.align = StageAlign.TOP_LEFT;
			stage.quality = StageQuality.LOW;
			
			stage.addEventListener(Event.DEACTIVATE, OnLostFocus);
			
			Multitouch.inputMode = MultitouchInputMode.TOUCH_POINT;
			
			CONFIG::air {			
				if (NativeWindow.isSupported && stage.nativeWindow.maximizable) {
					//stage.nativeWindow.maximize();
				}
				
				NativeApplication.nativeApplication.addEventListener(InvokeEvent.INVOKE, OnInvoke, false, 0, true);
				NativeApplication.nativeApplication.addEventListener(KeyboardEvent.KEY_DOWN, HardwareKeyDown, false, 0, true);
				
				CONFIG::mobile {
					NativeApplication.nativeApplication.systemIdleMode = SystemIdleMode.KEEP_AWAKE;
				}
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
			
			var loadMap:String = "Menu";
			
			CONFIG::air {
				if ((e as InvokeEvent).arguments.length > 0) {
					var args:Array = (e as InvokeEvent).arguments.join(" ").split("+");
					
					for (var i:int = 0; i < args.length; i++) {
						var arg:String = args[i];
						if(arg.indexOf("=") == -1) continue;
						
						var param:String = (arg.split("=")[0] as String).toLowerCase();
						
						switch(param) {
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
								Global.Out.Log("Unknown Param: " + arg);
						}
					}
				}
			}
			
			//Set up some other things
			Renderer = new Renderman();
			new System();
			
			stage.addEventListener(Event.RESIZE, Resized);
			
			hud = new UIManager();
			this.addChild(hud);
			
			Renderer.Attach();
			
			//var c:CaveLight = new CaveLight();
			//this.addChild(c);
			//c.Reset();
			
			Resized();
		}
		
		private function OnLostFocus(e:Event):void {
			SaveManager.Save("");
			
			if (Global.Network) {
				Global.Network.Close();
			}
		}
		
		public function Resized(e:* = null):void {
			if (Capabilities.screenDPI > 250) {
				//Camera.Z = 2;
				//TODO: Some global setting thing for ZoomMode
			}
			
			WorldData.CurrentMap.Resize();
			
			Renderer.Resized();
			hud.Resized();
		}
		
		public function HardwareKeyDown(event:KeyboardEvent):void {
			switch (event.keyCode) {
				case Keyboard.BACK:
					event.preventDefault();
					break;
				case Keyboard.MENU:
					break;
				case Keyboard.SEARCH:
					break;
			}
		}
	}
}