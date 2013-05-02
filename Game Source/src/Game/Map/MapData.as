package Game.Map {
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.General.BinaryLoader;
	import SoundSystem.MusicPlayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class MapData {
		
		public var Name:String = "";
		public var Music:int = 0;
		
		public var TileSizeX:int = 0;
		public var TileSizeY:int = 0;
		
		public var SizeX:int = 0;
		public var SizeY:int = 0;
		
		public var TotalTiles:int = 0;
		public var Tiles:Vector.<TileInstance>;
		
		public var TotalObjects:int = 0;
		public var Objects:Vector.<ObjectInstance>;
		
		public var Portals:Vector.<Portal>;
		
		public var Critters:Vector.<BaseCritter> = new Vector.<BaseCritter>();
		
		public function MapData(mapname:String) {
			Name = mapname;
			
			BinaryLoader.Load("Data/Map_" + mapname + ".bin", ParseData);
			
			Global.LoadingTotal++;
		}
		
		public function ParseData(b:ByteArray):void {
			//Some variables I'll need for loading
			var i:int;
			var x:int;
			var y:int;
			
			//Some map information
			BinaryLoader.GetString(b); //name of the map (can be discarded atm)
			Music = b.readShort(); //the ID of the music file
			
			//Load the portals
			var portals:int = b.readByte();
			Portals = new Vector.<Portal>(portals, true);
			i = 0;
			
			//Load in all the portals
			while (--portals > -1) {
				Portals[i] = new Portal(b);
				i++;
			}
			
			//Tiles First?
			TileSizeX = b.readShort();
			TileSizeY = b.readShort();
			TotalTiles = TileSizeX * TileSizeY;
			
			SizeX = TileSizeX * 48;
			SizeY = TileSizeY * 48;
			
			Tiles = new Vector.<TileInstance>(TotalTiles, true);
			
			for (i = 0; i < TileSizeX; i++) {
				for (var j:int = 0; j < TileSizeY; j++) {
					var ttt:TileInstance = new TileInstance();

					ttt.TileID = b.readShort();
					ttt.RecalculateRectangles(i, j);
					
					Tiles[i + TileSizeX * j] = ttt;
				}
			}
			
			//Now objects
			
			//First get rid of a lot of the objects already on the stage (theres probably a lot?)
			i = Main.OrderedLayer.numChildren;
			while (--i > -1) {
				if (Main.OrderedLayer.getChildAt(i) is ObjectInstance) {
					Main.OrderedLayer.removeChildAt(i);
				}
			}
			
			//Now we can load the new objects
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
			
			//MusicPlayer.PlaySong(Music);
			
			if (Portals.length > 0) {
				WorldData.ME.RequestTeleport(this, Portals[0]);
			} else {
				WorldData.ME.ShiftMaps(this, 281);
			}
		}
	}

}