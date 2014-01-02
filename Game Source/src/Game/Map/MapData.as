package Game.Map {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import EngineTiming.IUpdatable;
	import flash.utils.ByteArray;
	import Game.Critter.AITypes;
	import Game.Critter.BaseCritter;
	import Game.Critter.Factions;
	import Game.Effects.EffectInstance;
	import Game.Map.Objects.ObjectInstance;
	import Game.Map.Objects.ObjectInstanceAnimated;
	import Game.Map.Objects.ObjectTemplate;
	import Game.Map.Portals.Portal;
	import Game.Map.Portals.PortalHelper;
	import Game.Map.Spawns.SpawnRegion;
	import Game.Map.Tiles.TileHelper;
	import Game.Map.Tiles.TileInstance;
	import Loaders.BinaryLoader;
	import RenderSystem.Camera;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	import Scripting.ScriptTypes;
	import SoundSystem.MusicPlayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class MapData implements IUpdatable, IScriptTarget {
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
		public var Critters:Vector.<BaseCritter> = new Vector.<BaseCritter>(256, true);
		public var Effects:Vector.<EffectInstance> = new Vector.<EffectInstance>(256, true);
		
		private static var firstload:Boolean = true;
		private var ExpectedAtPortalID:int = -1;
		public var Dying:Boolean = false;
		public var Boundaries:Rect = new Rect(true, null);
		
		private var _script:Script;
		public var MyScript:ScriptInstance;
		
		public var NextBlankCritterForPlayer:Vector.<int>;
		public var NextBlankEffectForPlayer:Vector.<int>;
		
		public function MapData() {
			
		}
		
		public function LoadMap(mapname:String, portalID:int = -1):void {
			Name = mapname;
			this.ExpectedAtPortalID = portalID;
			if (portalID != -1) firstload = true;
			
			NextBlankCritterForPlayer = new Vector.<int>(Global.TotalPlayers+1, true);
			NextBlankEffectForPlayer = new Vector.<int>(Global.TotalPlayers+1, true);
			
			for (var i:int = 1; i < Global.TotalPlayers+1; i++) {
				NextBlankCritterForPlayer[i] = Global.SIMULATION_LIMIT_CRITTER + (i-1) * Global.CrittersPerPlayer;
				NextBlankEffectForPlayer[i] = Global.SIMULATION_LIMIT_EFFECTS + (i-1) * Global.EffectsPerPlayer;
			}
			
			BinaryLoader.Load("Data/Map_" + mapname + ".bin", ParseData);
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
				
				if (ObjectTemplate.Objects[id].IndividualAnimations) {
					o = new ObjectInstanceAnimated(i);
				} else {
					o = new ObjectInstance(i);
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
			
			_script = Script.ReadScript(b);
			MyScript = new ScriptInstance(_script, this);
			
			MusicPlayer.PlaySong(Music);
			
			//TODO: Port this over to the newest system
			/*if (firstload && Global.HasCharacter) {
				firstload = false;
				if (Portals.length > 0) {
					Critters.push(WorldData.ME);
					WorldData.ME.RequestTeleport(this, Portals[_pID]);
				} else {
					WorldData.ME.ShiftMaps(this, 281);
				}
			}*/
			
			Main.I.Resized();
		}
		
		public function GetObjectsInArea(rect:Rect, objects:Vector.<IScriptTarget>, type:int, scanner:IScriptTarget = null):void {
			if (rect == null) rect = new Rect(false, null, 0, 0, SizeX, SizeY);
			
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
						
						if (r.Owner != null && r.Owner is IScriptTarget) {
							if (objects.indexOf(r.Owner as IScriptTarget) == -1) {
								if (r.intersects(rect)) {
									objects.push(r.Owner as IScriptTarget);
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
					if (Critters[_tt] == null) continue;
					
					if (type == ScriptTypes.NotMe) {
 						if (Critters[_tt] == scanner) {
							continue;
						}
					}
					
					if (type == ScriptTypes.Enemy && !Factions.IsEnemies(primaryfaction, Critters[_tt].GetFaction())) {
						continue;
					}
					
					if (type == ScriptTypes.Ally && !Factions.IsFriends(primaryfaction, Critters[_tt].GetFaction())) {
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
			if (Dying) return; //Already dying somehow- serious problem actually
			Dying = true;
			
			var i:int = 0;
			
			i = Objects.length;
			while (--i > -1) {
				Objects[i].CleanUp();
				Objects[i] = null;
			}
			Objects = null;
			
			i = Portals.length;
			while (--i > -1) {
				Portals[i].CleanUp();
				Portals[i] = null;
			}
			Portals = null;
			
			i = Critters.length;
			while (--i > -1) {
				if (Critters[i] != null) {
					Critters[i].CleanUp();
					Critters[i] = null;
				}
			}
			
			i = Spawns.length;
			while (--i > -1) {
				Spawns[i].CleanUp();
				Spawns[i] = null;
			}
			Spawns = null;
			
			i = Tiles.length;
			while (--i > -1) {
				Tiles[i].CleanUp();
				Tiles[i] = null;
			}
			Tiles = null;
			
			i = Effects.length;
			while (--i > -1) {
				if(Effects[i] != null) {
					Effects[i].CleanUp();
					Effects[i] = null;
				}
			}
			
			i = ScriptRegions.length;
			while (--i > -1) {
				ScriptRegions[i].CleanUp();
				ScriptRegions[i] = null;
			}
			ScriptRegions = null;
			
			MyScript.CleanUp();
			_script.CleanUp();
			
			NextBlankCritterForPlayer = null;
			
			Dying = false;
		}
		
		public function Update(dt:Number):void {
			PortalHelper.CheckForPortalling(this);
		}
		
		public function CritterPop(baseCritter:BaseCritter):void {
			var i:int = Critters.indexOf(baseCritter);
			
			if (i > -1) {
				Critters[i] = null;
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
				Effects[i] = null;
			}
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		public function GetScript():ScriptInstance { return MyScript; }
		public function UpdatePointX(position:PointX):void { position.X = 0; position.Y = 0; position.D = 1; }
		public function AlertMinionDeath(baseCritter:BaseCritter):void { MyScript.Run(Script.MinionDied); }
		public function ChangeState(stateID:int, isLooping:Boolean):void {}
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {}
		public function GetAnimationSpeed():Number { return 0; }
		public function GetCurrentState():int { return -1; }
		public function GetFaction():int { return -1; }
		
		public function Resize():void {
			if(SizeX > 0) {
				Camera.Z = Main.I.stage.stageWidth / SizeX; //Math.floor(Main.I.stage.stageWidth / SizeX*2) / 2;
			} else {
				Camera.Z = 1;
				Camera.Y = 0;
				Camera.X = 0;
			}
		}
		
		public function GetCritterID(isSimulated:Boolean):int {
			var pID:int = 0;
			
			if (!isSimulated) {
				pID = Global.CurrentPlayerID;
			}
			
			var i:int = NextBlankCritterForPlayer[pID];
			IncrementPlayerBlank(pID);
			
			while (Critters[NextBlankCritterForPlayer[pID]] != null) {
				IncrementPlayerBlank(pID);
				
				if (NextBlankCritterForPlayer[pID] == i) {
					Main.I.Log("Uhoh! We hit the critter limit for playerID=" + pID);
					return -1;
				}
			}
			
			return NextBlankCritterForPlayer[pID];
		}
		
		private function IncrementPlayerBlank(pID:int):void {
			NextBlankCritterForPlayer[pID] = NextBlankCritterForPlayer[pID] + 1;
				
				if (NextBlankCritterForPlayer[pID] == Global.SIMULATION_LIMIT_CRITTER + Global.CrittersPerPlayer * pID) {
					if(pID == 0) {
						NextBlankCritterForPlayer[pID] = 0;
					} else {
						NextBlankCritterForPlayer[pID] = Global.SIMULATION_LIMIT_CRITTER + Global.CrittersPerPlayer * (pID - 1);
					}
				}
		}
		
		public function GetEffectID(isSimulated:Boolean):int {
			var pID:int = 0;
			
			if (!isSimulated) {
				pID = Global.CurrentPlayerID;
			}
			
			var i:int = NextBlankEffectForPlayer[pID];
			while (Effects[NextBlankEffectForPlayer[pID]] != null) {
				NextBlankEffectForPlayer[pID] = NextBlankEffectForPlayer[pID] + 1;
				
				if (NextBlankEffectForPlayer[pID] == Global.SIMULATION_LIMIT_EFFECTS + Global.EffectsPerPlayer * pID) {
					if(pID == 0) {
						NextBlankEffectForPlayer[pID] = 0;
					} else {
						NextBlankEffectForPlayer[pID] = Global.SIMULATION_LIMIT_EFFECTS + Global.EffectsPerPlayer * (pID - 1);
					}
				}
				
				if (NextBlankEffectForPlayer[pID] == i) {
					return -1;
				}
			}
			
			return NextBlankEffectForPlayer[pID];
		}
	}

}