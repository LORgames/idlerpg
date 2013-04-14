package Game.Map 
{
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class WorldData {
		
		private static var Maps:Vector.<String> = new Vector.<String>();
		
		public static function Initialize():void {
			BinaryLoader.Load("Data/MapInfo.bin", ParseWorldFile, NoMap);
		}
		
		public static function ParseWorldFile(data:ByteArray):void {
			var totalMaps:int = data.readShort();
			
			var i:int = totalMaps;
			while(--i > -1) {
				var l:int = data.readShort();
				var s:String = data.readMultiByte(l, "iso-8859-1");
				
				Maps.push(s);
            }
		}
		
		public static function NoMap(e:String):void {
			
		}
		
	}

}