package Game.Map {
	import CollisionSystem.Rect;
	import EngineTiming.IUpdatable;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.Factions;
	import Game.Effects.EffectInstance;
	import Game.General.BinaryLoader;
	import Game.Map.Objects.ObjectInstance;
	import Game.Map.Objects.ObjectInstanceAnimated;
	import Game.Map.Objects.ObjectTemplate;
	import Game.Map.Portals.Portal;
	import Game.Map.Portals.PortalHelper;
	import Game.Map.Spawns.SpawnRegion;
	import Game.Map.Tiles.TileHelper;
	import Game.Map.Tiles.TileInstance;
	import Game.Scripting.IScriptTarget;
	import Game.Scripting.ScriptTypes;
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
		public var ScriptRegions:Vector.<ScriptRegion>;
		
		public var Portals:Vector.<Portal>;
		public var Critters:Vector.<BaseCritter> = new Vector.<BaseCritter>();
		public var Effects:Vector.<EffectInstance> = new Vector.<EffectInstance>;
		
		private static var firstload:Boolean = true;
		private var ExpectedAtPortalID:int = -1;
		public var Dying:Boolean = false;
		public var Boundaries:Rect = new Rect(true, null);
		
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
			
			SizeX = TileSizeX * Global.TileSize;
			SizeY = TileSizeY * Global.TileSize;
				
			Boundaries.W = SizeX;
			Boundaries.H = SizeY;
			
			TotalTiles = TileSizeX * TileSizeY;
			Tiles = new Vector.<TileInstance>(TotalTiles, true);
			
			for (i = 0; i < TileSizeX; i++) {
				for (var j:int = 0; j < TileSizeY; j++) {
					var ttt:TileInstance = new TileInstance();
					
					if(Global.HasTiles) {
						ttt.TileID = b.readShort();
						ttt.RecalculateRectangles(i, j);
					} else {
						ttt.TileID = 0;
					}
					
					Tiles[i + TileSizeX * j] = ttt;
				}
			}
			
			//load the objects
			TotalObjects = b.readShort();
			Objects = new Vector.<ObjectInstance>(TotalObjects, false);
			
			for (i = 0; i < TotalObjects; i++) {
				var id:int = b.readShort();
				var _x:int = b.readShort();
				var _y:int = b.readShort();
				
				var o:ObjectInstance;
				
				trace("OBJID: " + id + "/" + TotalObjects);
				if (ObjectTemplate.Objects[id].IndividualAnimations) {
					o = new ObjectInstanceAnimated();
				} else {
					o = new ObjectInstance();
				}
				
				o.SetInformation(this, id, _x, _y);
				Objects[i] = o;
			}
			
			//Spawn things
			TotalObjects = b.readByte();
			Spawns = new Vector.<SpawnRegion>(TotalObjects, true);
			while (--TotalObjects > -1) {
				Spawns[TotalObjects] = SpawnRegion.LoadFromBinary(this, b);
			}
			
			//Script regions
			TotalObjects = b.readByte();
			ScriptRegions = new Vector.<ScriptRegion>(TotalObjects, true);
			while (--TotalObjects > -1) {
				ScriptRegions[TotalObjects] = ScriptRegion.LoadFromBinary(this, b);
			}
			
			//Prespawn the spawn area's
			TotalObjects = Spawns.length;
			while (--TotalObjects > -1) {
				Spawns[TotalObjects].PreSpawn();
			}
			
			Global.LoadingTotal--;
			
			MusicPlayer.PlaySong(Music);
			
			if (firstload && Global.HasCharacter) {
				firstload = false;
				if (Portals.length > 0) {
					Critters.push(WorldData.ME);
					WorldData.ME.RequestTeleport(this, Portals[_pID]);
				} else {
					WorldData.ME.ShiftMaps(this, 281);
				}
			}
		}
		
		public function GetObjectsInArea(rect:Rect, objects:Vector.<IScriptTarget>, type:int, scanner:IScriptTarget = null):void {
			var primaryfaction:int = scanner.GetFaction();
			
			var _tiles:Vector.<TileInstance> = TileHelper.GetTiles(rect, this);
			var _factionsearchflag:int = 0x1 << primaryfaction;
			
			var _tt:int = _tiles.length;
			var r:Rect;
			
			//Look at the objects
			if(type == ScriptTypes.MapObject || type == ScriptTypes.NotCritter || type == ScriptTypes.NotMe) {
				while (--_tt > -1) {
					var _tr:int = _tiles[_tt].SolidRectangles.length;
					
					while (--_tr > -1) {
						if (type == ScriptTypes.NotMe) {
							if (_tiles[_tt].SolidRectangles[_tr].Owner == scanner) {
								continue;
							}
						}
						
						r = _tiles[_tt].SolidRectangles[_tr];
						
						if (r.Owner != null) {
							if (objects.indexOf(r.Owner) == -1) {
								if (r.intersects(rect)) {
									objects.push(r.Owner);
								}
							}
						}
					}
				}
			}
			
			//Look at the critters
			if(type != ScriptTypes.NotCritter) {
				_tt = Critters.length;
				while (--_tt > -1) {
					if (type == ScriptTypes.NotMe) {
 						if (Critters[_tt] == scanner) {
							continue;
						}
					}
					
					if (type == ScriptTypes.Enemy && !Factions.IsEnemies(primaryfaction, Critters[_tt].PrimaryFaction)) {
						continue;
					}
					
					if (type == ScriptTypes.Ally && !Factions.IsFriends(primaryfaction, Critters[_tt].PrimaryFaction)) {
						continue;
					}
					
					if (Critters[_tt].MyRect.intersects(rect)) {
						if(objects.indexOf(Critters[_tt]) == -1) {
							objects.push(Critters[_tt]);
						}
					}
				}
			}
		}
		
		public function CleanUp():void {
			Dying = true;
			
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
			
			i = Effects.length;
			while (--i > 0) {
				Effects[i].CleanUp();
			}
			
			Dying = false;
		}
		
		public function Update(dt:Number):void {
			PortalHelper.CheckForPortalling(this);
		}
		
		public function CritterPush(baseCritter:BaseCritter):void {
			Critters.push(baseCritter);
			baseCritter.CurrentMap = this;
		}
		
		public function CritterPop(baseCritter:BaseCritter):void {
			var i:int = Critters.indexOf(baseCritter);
			
			if (i > -1) {
				Critters.splice(i, 1);
			}
			
			baseCritter.CurrentMap = null;
		}
		
		public function RemoveObject(objectInstance:ObjectInstance):void {
			var i:int = Objects.indexOf(objectInstance);
			
			if (i > -1) {
				Objects.splice(i, 1);
			}
			
			objectInstance.DetachFromTiles();
			
			Dying = true;
			objectInstance.CleanUp();
			Dying = false;
		}
		
		public function EffectPop(effectInstance:EffectInstance):void {
			var i:int = Effects.indexOf(effectInstance);
			
			if (i > -1) {
				Effects.splice(i, 1);
			}
		}
	}

}