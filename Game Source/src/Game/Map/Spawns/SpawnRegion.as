package Game.Map.Spawns {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import EngineTiming.Clock;
	import EngineTiming.IUpdatable;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterManager;
	import Game.Map.MapData;
	import Scripting.IScriptTarget;
	import Interfaces.IMapObject;
	import Scripting.ScriptInstance;
	/**
	 * ...
	 * @author Paul
	 */
	public class SpawnRegion implements IUpdatable, IScriptTarget {
		public var Map:MapData;
		public var Area:Vector.<Rect>;
		
        public var SpawnChance:Vector.<int>;
		public var SpawnID:Vector.<int>;

        public var SpawnOnLoad:int = 1;
        public var MaxSpawn:int = 10;
        public var Timeout:int = 60;
		
		private var UsedTimeout:int;
		private var Enabled:Boolean = true;
		
		private var FractionalSeconds:Number = 0;
		
		public var Critters:Vector.<BaseCritter>;

		public function SpawnRegion(map:MapData, MaxSpawn:int, SpawnAtLoad:int, Timeout:int) {
			this.Map = map;
			this.MaxSpawn = MaxSpawn;
			this.SpawnOnLoad = SpawnAtLoad;
			this.Timeout = Timeout;
			this.Critters = new Vector.<BaseCritter>();
			
			if (MaxSpawn > 0) {
				UsedTimeout = Rndm.random() * Timeout;
				Clock.I.RegisterUpdatable(this);
			}
		}
		
		/**
		 * We're all loaded so lets actually spawn the things :)
		 */
		public function PreSpawn():void {
			while (--SpawnOnLoad > -1) {
				Spawn();
			}
		}
		
		private function Spawn():void {
			if (Area.length == 0) return;
			
			var critterID:int = GetNextCritterID();
			var randArea:int = Rndm.random() * (Area.length);
			var randX:int = Area[randArea].X + Rndm.random() * Area[randArea].W;
			var randY:int = Area[randArea].Y + Rndm.random() * Area[randArea].H;
			
			var newCritter:BaseCritter = CritterManager.I.CritterInfo[critterID].CreateCritter(Map, randX, randY, true);
			newCritter.SetOwner(this);
			
			Critters.push(newCritter);
		}
		
		/**
		 * Gets the critterID (yay!)
		 * @return Returns the CritterID of the monster to spawn
		 */
		private function GetNextCritterID():int {
			var x:int = Rndm.random() * SpawnID.length;
			return SpawnID[x];
		}
		
		public function CleanUp():void {
			var i:int = 0;
			
			Map = null;
			
			i = Area.length;
			while (--i > -1) {
				Area[i] = null;
			}
			Area = null;
			
			i = SpawnChance.length;
			while (--i > -1) {
				SpawnChance[i] = null;
				SpawnID[i] = null;
			}
			SpawnChance = null;
			SpawnID = null;
			
			i = Critters.length;
			while (--i > -1) {
				Critters[i] = null;
			}
			Critters = null;
			
			Clock.I.Remove(this);
		}
		
		////////////////////////////////////////
		// Static methods
		///////////////////////////////////////
        public static function LoadFromBinary(map:MapData, b:ByteArray):SpawnRegion {
			// All the spawn information (thats relevant)
			var s:SpawnRegion = new SpawnRegion(map, b.readByte(), b.readByte(), b.readShort());
			
			// Rectangles
			var totalRects:int = b.readByte();
			s.Area = new Vector.<Rect>(totalRects, true);

			// Load rectangles
			while (--totalRects > -1) {
				s.Area[totalRects] = new Rect(true, null, b.readShort(), b.readShort(), b.readShort(), b.readShort());
			}
			
			// Add what critters are here and what percents
			totalRects = b.readByte();
			
			s.SpawnID = new Vector.<int>(totalRects, true);
			s.SpawnChance = new Vector.<int>(totalRects, true);
			
			while (--totalRects > -1) {
				s.SpawnID[totalRects] = b.readShort();
				s.SpawnChance[totalRects] = b.readByte();
			}
			
			//s.PreSpawn();
			
            return s;
        }
		
		public function Update(dt:Number):void {
			if (!Enabled) return;
			
			FractionalSeconds += dt;
			
			if(FractionalSeconds >= 1) {
				UsedTimeout++;
				
				if (UsedTimeout >= Timeout) {
					UsedTimeout = 0;
					
					if (MaxSpawn > Critters.length) {
						Spawn();
					}
				}
				
				FractionalSeconds -= 1;
			}
		}
		
		public function SetEnabled(b:Boolean):void {
			Enabled = b;
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		public function AlertMinionDeath(minion:BaseCritter):void {
			var i:int = Critters.indexOf(minion);
			
			if (i > -1) {
				Critters.splice(i, 1);
			} else {
				Global.Out.Log("Being alerted of unexpected critter death!");
			}
		}
		
		public function GetTypeID():int { return 0; }
		public function UpdatePointX(position:PointX):void { /* Does nothing obviously... */ }
		public function ChangeState(stateID:int, isLooping:Boolean):void { /* Does nothing obviously... */ }
		public function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IScriptTarget):void { /* Can't even attack a spawn region so thats a little bit silly... */ }
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void { /* Don't see what this could possibly do here either... */ }
		public function GetAnimationSpeed():Number { return 0; }
		public function GetScript():ScriptInstance { return null; }
		public function GetCurrentState():int { return 0; }
		public function GetFaction():int { return 0; }
	}
}