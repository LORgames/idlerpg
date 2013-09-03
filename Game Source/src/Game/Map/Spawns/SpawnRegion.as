package Game.Map.Spawns {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import EngineTiming.Clock;
	import EngineTiming.IOneSecondUpdate;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterManager;
	import Game.Map.MapData;
	import Game.Scripting.IScriptTarget;
	import Interfaces.IMapObject;
	/**
	 * ...
	 * @author Paul
	 */
	public class SpawnRegion implements IOneSecondUpdate, IScriptTarget {
		public var Map:MapData;
		public var Area:Vector.<Rect>;
		
        public var SpawnChance:Vector.<int>;
		public var SpawnID:Vector.<int>;

        public var SpawnOnLoad:int = 1;
        public var MaxSpawn:int = 10;
        public var Timeout:int = 60;
		
		private var UsedTimeout:int;
		
		public var Critters:Vector.<BaseCritter>;

		public function SpawnRegion(map:MapData, MaxSpawn:int, SpawnAtLoad:int, Timeout:int) {
			this.Map = map;
			this.MaxSpawn = MaxSpawn;
			this.SpawnOnLoad = SpawnAtLoad;
			this.Timeout = Timeout;
			this.Critters = new Vector.<BaseCritter>();
			
			if (MaxSpawn > 0) {
				UsedTimeout = Math.random() * Timeout;
				Clock.I.OneSecond.push(this);
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
			var randArea:int = Math.random() * (Area.length);
			var randX:int = Area[randArea].X + Math.random() * Area[randArea].W;
			var randY:int = Area[randArea].Y + Math.random() * Area[randArea].H;
			
			var newCritter:BaseCritter = CritterManager.I.CritterInfo[critterID].CreateCritter(Map, randX, randY);
			newCritter.Owner = this;
			
			Critters.push(newCritter);
		}
		
		/**
		 * Gets the critterID (yay!)
		 * @return Returns the CritterID of the monster to spawn
		 */
		private function GetNextCritterID():int {
			var x:int = Math.random() * SpawnID.length;
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
			
			Clock.I.Remove1(this);
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
		
		/* INTERFACE EngineTiming.IOneSecondUpdate */
		
		public function UpdateOneSecond():void {
			UsedTimeout++;
			
			if (UsedTimeout >= Timeout) {
				UsedTimeout = 0;
				
				if (MaxSpawn > Critters.length) {
					Spawn();
				}
			}
		}
		
		/* INTERFACE Game.Scripting.IScriptTarget */
		
		public function AlertMinionDeath(minion:BaseCritter):void {
			var i:int = Critters.indexOf(minion);
			
			if (i > -1) {
				Critters.splice(i, 1);
			} else {
				trace("Being alerted of unexpected critter death!");
			}
		}
		
		public function UpdatePointX(position:PointX):void {
			//Does nothing obviously...
		}
		
		public function ChangeState(stateID:int, isLooping:Boolean):void {
			//Does nothing obviously...
		}
		
		public function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IScriptTarget):void {
			//Can't even attack a spawn region so thats a little bit silly...
		}
		
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			//Don't see what this could possibly do here either...
		}
		
		public function GetCurrentState():int {
			return 0;
		}
		
		/* INTERFACE Game.Scripting.IScriptTarget */
		
		public function GetFaction():int {
			return 0;
		}
	}
}