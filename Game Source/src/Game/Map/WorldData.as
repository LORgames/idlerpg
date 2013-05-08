package Game.Map {
	import flash.desktop.NativeApplication;
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.Person;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import SoundSystem.MusicPlayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class WorldData {
		public static var Maps:Vector.<String>;
		public static var PortalDestinations:Vector.<String>;
		
		private static var RequestedMapLoad:String = "";
		
		public static var TileSheet:BitmapData;
		
		public static var ME:Person = new Person();
		
		public static function Initialize(loadReq:String):void {
			RequestedMapLoad = loadReq;
			trace("Looking for: " + RequestedMapLoad);
			
			BinaryLoader.Load("Data/MapInfo.bin", ParseWorldFile);
			ImageLoader.Load("Data/TileSheet.png", LoadedTileSet);
			
			TileTemplate.LoadTileInfo();
			ObjectTemplate.LoadObjectInfo();
			
			Global.LoadingTotal += 2;
		}
		
		public static function ParseWorldFile(data:ByteArray):void {
			var totalMaps:int = data.readShort();
			var totalPortals:int = data.readShort();
			
			Maps = new Vector.<String>(totalMaps, true);
			PortalDestinations = new Vector.<String>(totalPortals, true);
			
			var loadMapID:int = 0;
			
			var i:int = totalMaps;
			while(--i > -1) {
				var s:String = BinaryLoader.GetString(data);
				
				var p:int = data.readByte();
				
				while (--p > -1) {
					var portalID:int = data.readShort();
					PortalDestinations[portalID] = s;
					
					if (RequestedMapLoad == "" && portalID == 0) {
						loadMapID = i;
					}
				}
				
				if (s == RequestedMapLoad) {
					loadMapID = i;
				}
				
				Maps[i] = s;
            }
			
			if (totalMaps > 0) {
				ME.CurrentMap = new MapData(Maps[loadMapID]);
			}
			
			Global.LoadingTotal--;
		}
		
		public static function LoadedTileSet(e:BitmapData):void {
			TileSheet = e;
			Global.LoadingTotal--;
		}
		
		public static function UpdatePlayerPosition():void {
			ME.CurrentMap = new MapData(PortalDestinations[Global.MapPortalID], Global.MapPortalID);
			Main.I.Renderer.FadeToWorld();
		}
		
	}

}