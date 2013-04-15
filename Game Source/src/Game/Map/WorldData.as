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
		private static var TileSheet:BitmapData;
		
		public static var CurrentMap:MapData;
		
		public static function Initialize():void {
			BinaryLoader.Load("Data/MapInfo.bin", ParseWorldFile, LoadFailed);
			ImageLoader.Load("Data/TileSheet.png", LoadedTileSet, LoadFailed);
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
		}
		
		public static function LoadedTileSet(e:BitmapData):void {
			TileSheet = e;
		}
		
		public static function LoadFailed(e:String):void {
			//Uhoh! No can load.
			trace("No can load something..?");
		}
		
	}

}