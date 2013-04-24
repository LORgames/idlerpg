package Game.Map {
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
		public var Objects:Vector.<ObjectInstance>
		
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
					
					var walkdata:int = b.readByte();
					ttt.Walkable = (walkdata & 32) > 0;
					ttt.AccessDirections = walkdata & ~32;
					
					Tiles[i + TileSizeX * j] = ttt;
				}
			}
			
			i = TotalTiles;
			while ( --i > -1) {
				if (!Tiles[i].Walkable) continue;
				
				x = int(i % TileSizeX);
				y = int(i / TileSizeX);
				
				if (x > 0) Tiles[i].Left = Tiles[i-1];
				if (x < TileSizeX - 1) Tiles[i].Right = Tiles[i+1];
				if (y > 0) Tiles[i].Up = Tiles[i - TileSizeX];
				if (y < TileSizeY - 1) Tiles[i].Down = Tiles[i + TileSizeX];
				
				if (Tiles[i].Left != null) {
					if (!Tiles[i].Left.Walkable || (Tiles[i].AccessDirections & TileTemplate.ACCESS_LEFT) == 0 || (Tiles[i].Left.AccessDirections & TileTemplate.ACCESS_RIGHT) == 0) {
						Tiles[i].Left = null;
					}
				}
				
				if (Tiles[i].Right != null) {
					if (!Tiles[i].Right.Walkable || (Tiles[i].AccessDirections & TileTemplate.ACCESS_RIGHT) == 0 || (Tiles[i].Right.AccessDirections & TileTemplate.ACCESS_LEFT) == 0) {
						Tiles[i].Right = null;
					}
				}
				
				if (Tiles[i].Up != null) {
					if (!Tiles[i].Up.Walkable || (Tiles[i].AccessDirections & TileTemplate.ACCESS_TOP) == 0 || (Tiles[i].Up.AccessDirections & TileTemplate.ACCESS_BOTTOM) == 0) {
						Tiles[i].Up = null;
					}
				}
				
				if (Tiles[i].Down != null) {
					if (!Tiles[i].Down.Walkable || (Tiles[i].AccessDirections & TileTemplate.ACCESS_BOTTOM) == 0 || (Tiles[i].Down.AccessDirections & TileTemplate.ACCESS_TOP) == 0) {
						Tiles[i].Down = null;
					}
				}
				
				if (Tiles[i].Walkable && Tiles[i].Left == null && Tiles[i].Right == null && Tiles[i].Up == null && Tiles[i].Down == null) {
					Tiles[i].Walkable = false;
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
			
			WorldData.ME.ShiftMaps(this, 7);
		}
	}

}