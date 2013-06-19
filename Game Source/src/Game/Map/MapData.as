package Game.Map {
	import CollisionSystem.Rect;
	import EngineTiming.Clock;
	import EngineTiming.IUpdatable;
	import flash.display.IDrawCommand;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterHuman;
	import Game.General.BinaryLoader;
	import Interfaces.IMapObject;
	import SoundSystem.MusicPlayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class MapData implements IUpdatable {
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
		public var Spawns:Vector.<SpawnRegion>;
		
		public var Portals:Vector.<Portal>;
		public var Critters:Vector.<BaseCritter> = new Vector.<BaseCritter>();
		
		private static var firstload:Boolean = true;
		private var ExpectedAtPortalID:int = -1;
		
		public function MapData() {
			
		}
		
		public function LoadMap(mapname:String, portalID:int = -1):void {
			Name = mapname;
			this.ExpectedAtPortalID = portalID;
			if (portalID != -1) firstload = true;
			
			BinaryLoader.Load("Data/Map_" + mapname + ".bin", ParseData);
			
			Global.LoadingTotal++;
		}
		
		public function ParseData(b:ByteArray):void {
			//Some variables I'll need for loading
			var i:int;
			var x:int;
			var y:int;
			var _pID:int = 0;
			
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
				
				if (firstload && ExpectedAtPortalID == Portals[i].ID) {
					_pID = i;
				}
				
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
			
			//load the objects
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
			
			//Spawn things
			TotalObjects = b.readByte();
			Spawns = new Vector.<SpawnRegion>(TotalObjects);
			while (--TotalObjects > -1) {
				Spawns[TotalObjects] = SpawnRegion.LoadFromBinary(this, b);
			}
			
			Global.LoadingTotal--;
			
			MusicPlayer.PlaySong(Music);
			
			if (firstload) {
				firstload = false;
				if (Portals.length > 0) {
					Critters.push(WorldData.ME);
					WorldData.ME.RequestTeleport(this, Portals[_pID]);
				} else {
					WorldData.ME.ShiftMaps(this, 281);
				}
			}
			
			Main.I.Renderer.FadeToWorld();
		}
		
		public function GetObjectsInArea(rect:Rect, objects:Vector.<IMapObject>, type:int = 0xA004, scanner:BaseCritter = null):void {
			var _tiles:Vector.<TileInstance> = TileHelper.GetTiles(rect, this);
			
			var _tt:int = _tiles.length;
			var r:Rect;
			
			while (--_tt > -1) {
				var _tr:int = _tiles[_tt].SolidRectangles.length;
				
				while (--_tr > -1) {
					r = _tiles[_tt].SolidRectangles[_tr];
					
					if (r.Owner != null) {
						if(objects.indexOf(r.Owner) == -1) {
							objects.push(r.Owner);
						}
					}
				}
			}
			
			_tt = Critters.length;
			while (--_tt > -1) {
				if (Critters[_tt].MyRect.intersects(rect)) {
					if(objects.indexOf(Critters[_tt]) == -1) {
						objects.push(Critters[_tt]);
					}
				}
			}
		}
		
		public function CleanUp():void {
			var i:int = 0;
			
			i = Objects.length;
			while (--i > -1) {
				Objects[i].CleanUp();
				Objects[i] = null;
			}
			Objects = null;
			
			i = Spawns.length;
			while (--i > -1) {
				Spawns[i].CleanUp();
				Spawns[i] = null;
			}
			Spawns = null;
			
			i = Portals.length;
			while (--i > -1) {
				Portals[i].CleanUp();
				Portals[i] = null;
			}
			Portals = null;
			
			i = Critters.length;
			while (Critters.length > 0) {
				Critters.pop().CleanUp();
			}
			
			i = Tiles.length;
			while (--i > 0) {
				Tiles[i].CleanUp();
				Tiles[i] = null;
			}
			Tiles = null;
		}
		
		public function Update(dt:Number):void {
			PortalHelper.CheckForPortalling(this);
		}
	}

}