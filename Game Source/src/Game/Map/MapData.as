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
		
		public var TotalObjects:int = 0;
		public var Objects:Vector.<ObjectInstance>
		
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
			
			var i:int;
			
			for (i = 0; i < TileSizeX; i++) {
				for (var j:int = 0; j < TileSizeY; j++) {
					var ttt:int = b.readShort();
					Tiles[i + TileSizeX * j] = ttt;
				}
			}
			
			//Now objects
			TotalObjects = b.readShort();
			Objects = new Vector.<ObjectInstance>(TotalObjects, true);
			
			for (i = 0; i < TotalObjects; i++) {
				var o:ObjectInstance = new ObjectInstance();
				
				var id:int = b.readShort();
				var _x:int = b.readShort();
				var _y:int = b.readShort();
				
				o.SetInformation(id, _x, _y);
				
				Objects[i] = o;
			}
			
			Global.LoadingTotal--;
		}
	}

}