package Game.Map {
	import EngineTiming.Clock;
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	import Game.Critter.CritterHuman;
	import Loaders.BinaryLoader;
	import Loaders.ImageLoader;
	import Game.Map.Objects.ObjectTemplate;
	import Game.Map.Tiles.TileTemplate;
	/**
	 * ...
	 * @author Paul
	 */
	public class WorldData {
		public static var Maps:Vector.<String>;
		public static var PortalDestinations:Vector.<String>;
		
		private static var RequestedMapLoad:String = "";
		
		public static var TileSheet:BitmapData;
		
		public static var ME:CritterHuman;
		public static var CurrentMap:MapData = new MapData();
		
		public static function Initialize(loadReq:String):void {
			if (Global.HasCharacter) {
				ME = new CritterHuman(0, 0);
				ME.Persistent = true;
				ME.MovementSpeed = 150;
			}
			
			RequestedMapLoad = loadReq;
			
			BinaryLoader.Load("Data/MapInfo.bin", ParseWorldFile);
			
			if(Global.HasTiles) {
				ImageLoader.Load("Data/TileSheet.png", LoadedTileSet);
			}
			
			TileTemplate.LoadTileInfo();
			ObjectTemplate.LoadObjectInfo();
		}
		
		public static function ParseWorldFile(data:ByteArray):void {
			var totalMaps:int = data.readShort();
			var totalPortals:int = data.readShort();
			
			Maps = new Vector.<String>(totalMaps, true);
			PortalDestinations = new Vector.<String>(totalPortals, true);
			
			var loadMapID:int = 0;
			
			var i:int = totalMaps;
			for (i = 0; i < totalMaps; i++) {
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
				CurrentMap.LoadMap(Maps[loadMapID]);
			}
		}
		
		public static function LoadedTileSet(e:BitmapData):void {
			TileSheet = e.clone();
		}
		
		public static function UpdatePlayerPosition():void {
			CurrentMap.CleanUp();
			CurrentMap.LoadMap(PortalDestinations[Global.MapPortalID], Global.MapPortalID);
		}
		
		public static function YouAreDied():void {
			Clock.Stop();
		}
	}
}