package Game.Map 
{
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class WorldData {
		
		private static var Maps:Vector.<String>;
		public static var TileSheet:BitmapData;
		
		public static var CurrentMap:MapData;
		
		public static function Initialize():void {
			BinaryLoader.Load("Data/MapInfo.bin", ParseWorldFile);
			ImageLoader.Load("Data/TileSheet.png", LoadedTileSet);
			
			TileTemplate.LoadTileInfo();
			
			Global.LoadingTotal += 2;
		}
		
		public static function ParseWorldFile(data:ByteArray):void {
			var totalMaps:int = data.readShort();
			
			Maps = new Vector.<String>(totalMaps, true);
			
			var i:int = totalMaps;
			while(--i > -1) {
				var l:int = data.readShort();
				var s:String = data.readMultiByte(l, "iso-8859-1");
				
				Maps[i] = s;
            }
			
			if (totalMaps > 0) {
				CurrentMap = new MapData(Maps[0]);
			}
			
			Global.LoadingTotal--;
		}
		
		public static function LoadedTileSet(e:BitmapData):void {
			TileSheet = e;
			Global.LoadingTotal--;
		}
		
	}

}