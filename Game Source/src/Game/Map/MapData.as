package Game.Map {
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class MapData {
		
		public var Name:String = "";
		public var TileSizeX:int = 0;
		public var TileSizeY:int = 0;
		
		public var TotalTiles:int = 0;
		public var Tiles:Vector.<int>;
		
		public function MapData(mapname:String) {
			Name = mapname;
			
			BinaryLoader.Load("Data/Map_" + mapname + ".bin", ParseData);
			
			Global.LoadingTotal++;
		}
		
		public function ParseData(b:ByteArray):void {
			var l:int = b.readShort();
			var s:String = b.readMultiByte(l, "iso-8859-1"); //map name
			
			//Tiles First?
			TileSizeX = b.readShort();
			TileSizeY = b.readShort();
			TotalTiles = TileSizeX * TileSizeY;
			
			Tiles = new Vector.<int>(TotalTiles, true);
			
			for (var i:int = 0; i < TileSizeX; i++) {
				for (var j:int = 0; j < TileSizeY; j++) {
					var ttt:int = b.readShort();
					Tiles[i + TileSizeY * j] = ttt;
				}
			}
			
			//Now objects
			/*f.AddShort((short)map.Objects.Count);
			
			for (int i = 0; i < map.Objects.Count; i++) {
				BaseObject obj = map.Objects[i];

				f.AddShort(ObjectCrusher.RealignedItemIndexes[obj.ObjectType]);
				f.AddShort((short)obj.Location.X);
				f.AddShort((short)obj.Location.Y);
			}*/
			
			Global.LoadingTotal--;
		}
	}

}