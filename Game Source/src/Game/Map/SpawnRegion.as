package Game.Map {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterManager;
	import Interfaces.IMapObject;
	/**
	 * ...
	 * @author Paul
	 */
	public class SpawnRegion implements IMapObject {
		
		public var Map:MapData;
		public var Area:Vector.<Rect>;
		
        public var SpawnChance:Vector.<int>;
		public var SpawnID:Vector.<int>;

        public var SpawnOnLoad:int = 1;
        public var MaxSpawn:int = 10;
        public var Timeout:int = 60;
		
		public var Critters:Vector.<BaseCritter>;

		public function SpawnRegion(map:MapData, MaxSpawn:int, SpawnAtLoad:int, Timeout:int) {
			this.Map = map;
			this.MaxSpawn = MaxSpawn;
			this.SpawnOnLoad = SpawnAtLoad;
			this.Timeout = Timeout;
			this.Critters = new Vector.<BaseCritter>();
		}
		
		/**
		 * We're all loaded so lets actually spawn the things :)
		 */
		private function PreSpawn():void {
			while (--SpawnOnLoad > -1) {
				var critterID:int = GetNextCritterID();
				var randArea:int = Math.floor(Math.random() * (Area.length));
				var randX:int = Area[randArea].X + Math.floor(Math.random() * Area[randArea].W);
				var randY:int = Area[randArea].Y + Math.floor(Math.random() * Area[randArea].H);
				Critters.push(CritterManager.I.CritterInfo[critterID].CreateCritter(Map, randX, randY));
			}
		}
		
		/**
		 * Gets the critterID (yay!)
		 * @return Returns the CritterID of the monster to spawn
		 */
		private function GetNextCritterID():int {
			return SpawnID[0];
		}
		
		
		public function GetUnion():Rect {
			return null;
		}
		
		public function HasPerfectCollision(other:Rect):Boolean {
			return false;
		}
		
		public function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IMapObject):void {
			
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
				Critters[i].CleanUp();
				Critters[i] = null;
			}
			Critters = null;
		}
		
		////////////////////////////////////////
		//Static methods
		///////////////////////////////////////
        public static function LoadFromBinary(map:MapData, b:ByteArray):SpawnRegion {
			// All the spawn information (thats relevant)
			var s:SpawnRegion = new SpawnRegion(map, b.readByte(), b.readByte(), b.readShort());
			
			// Rectangles
			var totalRects:int = b.readByte();
			s.Area = new Vector.<Rect>(totalRects, true);

			// Rectangle0 (needs to be extended)
			while (--totalRects > -1) {
				s.Area[totalRects] = new Rect(true, s, b.readShort(), b.readShort(), b.readShort(), b.readShort());
			}
			
			// Add what critters are here and what percents
			totalRects = b.readByte();
			
			s.SpawnID = new Vector.<int>(totalRects, true);
			s.SpawnChance = new Vector.<int>(totalRects, true);
			
			while (--totalRects > -1) {
				s.SpawnID[totalRects] = b.readShort();
				s.SpawnChance[totalRects] = b.readByte();
			}
			
			s.PreSpawn();
			
            return s;
        }
		
	}

}