package {
	import EngineTiming.Clock;
	import flash.events.MouseEvent;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	import flash.utils.ByteArray;
	import Game.Critter.CritterManager;
	import Game.Critter.Factions;
	import Game.Data.DataManager;
	import Game.Effects.EffectManager;
	import Game.Equipment.EquipmentManager;
	import Loaders.BinaryLoader;
	import Loaders.ImageLoader;
	import Game.Map.WorldData;
	import QDMF.Logic.Syncronizer;
	import Scripting.GlobalVariables;
	import Scripting.NetworkScriptExec;
	import Scripting.Script;
	import InputSystems.KeyboardInput;
	import InputSystems.MouseInput;
	import InputSystems.TouchInput;
	import QDMF.IPacketProcessor;
	import QDMF.Packet;
	import QDMF.PacketController;
	import SoundSystem.EffectsPlayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class System {
		public function System() {
			BinaryLoader.Initialize();
			ImageLoader.Initialize();
			
			BinaryLoader.Load("Data/Settings.bin", ParseSettings, NoSettings);
			
			NetworkScriptExec.Launch();
		}
		
		private function ParseSettings(b:ByteArray):void {
			Main.I.Renderer.FadeToBlack(null, Global.DefaultMap);
			
			//Load in the data from the Settings file
			Global.GameName = BinaryLoader.GetString(b);
			var forBools:int = b.readByte();
			Global.TileSize = b.readShort();
			Global.FPS = b.readShort();
			
			Global.PerspectiveSkew = b.readFloat();
			Global.HasTiles = (forBools & 0x1) == 0x1;
			
			Main.I.stage.frameRate = Global.FPS;
			
			Global.GV_WX = b.readShort();
			Global.GV_WY = b.readShort();
			Global.GV_LX = b.readShort();
			Global.GV_LY = b.readShort();
			Global.GV_MusicVolume = b.readShort();
			Global.GV_SoundVolume = b.readShort();
			
			Global.TotalPlayers = b.readByte();
			Global.CrittersPerPlayer = b.readByte();
			Global.TurnLength = b.readShort();
			
			Global.EffectsPerPlayer = Global.CrittersPerPlayer;
			Global.SIMULATION_LIMIT_CRITTER = 255 - (Global.CrittersPerPlayer * Global.TotalPlayers);
			Global.SIMULATION_LIMIT_EFFECTS = 255 - (Global.EffectsPerPlayer * Global.TotalPlayers);
			Global.MatchmakingAddress = BinaryLoader.GetString(b);
			Global.GV_PlayerID = b.readShort();
			
			Global.DefaultMap = BinaryLoader.GetString(b);
			
			//Load up everything else as required
			WorldData.Initialize(Global.DefaultMap);
			
			//Need more logic to adding input system?
			if (Multitouch.supportsTouchEvents && Multitouch.maxTouchPoints > 1) {
				// touch or gesture?
				Main.Input = new TouchInput();
			} else {
				Main.Input = new MouseInput();
				//Main.Input = new KeyboardInput();
			}
			
			new EquipmentManager();
			new CritterManager();
			new EffectManager();
			new GlobalVariables();
			new Factions();
			EffectsPlayer.Initialize();
			new DataManager();
			new Syncronizer();
			
			Clock.I.Start(Main.I.stage);
		}
		
		private function NoSettings(message:String):void {
			Main.I.Renderer.FadeToBlack(null, "No Settings!");
		}
		
	}

}