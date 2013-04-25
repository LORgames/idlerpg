package Game.Map {
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
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
		public var Tiles:Vector.<TileInstance>;
		
		public var TotalObjects:int = 0;
		public var Objects:Vector.<ObjectInstance>;
		
		public var Critters:Vector.<BaseCritter> = new Vector.<BaseCritter>();
		
		public function MapData(mapname:String) {
			Name = mapname;
			
			BinaryLoader.Load("Data/Map_" + mapname + ".bin", ParseData);
			
			Global.LoadingTotal++;
		}
		
		public function ParseData(b:ByteArray):void {
			BinaryLoader.GetString(b);
			
			//Tiles First?
			TileSizeX = b.readShort();
			TileSizeY = b.readShort();
			TotalTiles = TileSizeX * TileSizeY;
			
			Tiles = new Vector.<TileInstance>(TotalTiles, true);
			
			var i:int;
			var x:int;
			var y:int;
			
			for (i = 0; i < TileSizeX; i++) {
				for (var j:int = 0; j < TileSizeY; j++) {
					var ttt:TileInstance = new TileInstance();
					ttt.TileID = b.readShort();
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
				
				o.SetInformation(this, id, _x, _y);
				
				Objects[i] = o;
			}
			
			Global.LoadingTotal--;
			
			WorldData.ME.ShiftMaps(this, 8);
		}
	}

}