package {
	import EngineTiming.Clock;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	import flash.utils.ByteArray;
	import Game.Critter.CritterManager;
	import Game.Critter.Factions;
	import Game.Effects.EffectManager;
	import Game.Equipment.EquipmentManager;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import Game.Map.WorldData;
	import Game.Scripting.GlobalVariables;
	import InputSystems.KeyboardInput;
	import InputSystems.TouchInput;
	/**
	 * ...
	 * @author Paul
	 */
	public class System {
		private var loadMapName:String;
		
		public function System(mapToLoad:String) {
			loadMapName = mapToLoad;
			
			BinaryLoader.Initialize();
			ImageLoader.Initialize();
			
			BinaryLoader.Load("Data/Settings.bin", ParseSettings, NoSettings);
		}
		
		private function ParseSettings(b:ByteArray):void {
			Main.I.Renderer.FadeToBlack(null, loadMapName);
			
			//Load in the data from the Settings file
			Global.GameName = BinaryLoader.GetString(b);
			var forBools:int = b.readByte();
			Global.TileSize = b.readShort();
			Global.FPS = b.readShort();
			
			Global.HasCharacter = (forBools & 0x2) == 0x0;
			Global.HasTiles = (forBools & 0x1) == 0x1;
			
			Main.I.stage.frameRate = Global.FPS;
			
			//Load up everything else as required
			WorldData.Initialize(loadMapName);
			
			if (Global.HasCharacter) {
				
				//Need more logic to adding input system?
				if (Multitouch.supportsTouchEvents && Multitouch.maxTouchPoints > 1) {
					// touch or gesture?
					Main.Input = new TouchInput();//new KeyboardInput();
				} else {
					Main.Input = new KeyboardInput();
				}
			}
			
			new EquipmentManager();
			new CritterManager();
			new EffectManager();
			new GlobalVariables();
			new Factions();
			
			Clock.I.Start(Main.I.stage);
		}
		
		private function NoSettings(message:String):void {
			Main.I.Renderer.FadeToBlack(null, "No Settings!");
		}
		
	}

}