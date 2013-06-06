package Game.Map {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterManager;
	/**
	 * ...
	 * @author Paul
	 */
	public class SpawnRegion {
		
		public var Map:MapData;
		public var Area:Vector.<Rect>;
		
        public var SpawnChance:Vector.<int>;
		public var SpawnID:Vector.<int>;

        public var SpawnOnLoad:int = 1;
        public var MaxSpawn:int = 10;
        public var Timeout:int = 60;

		public function SpawnRegion(map:MapData, MaxSpawn:int, SpawnAtLoad:int, Timeout:int) {
			this.Map = map;
			this.MaxSpawn = MaxSpawn;
			this.SpawnOnLoad = SpawnAtLoad;
			this.Timeout = Timeout;
		}
		
		/**
		 * We're all loaded so lets actually spawn the things :)
		 */
		private function PreSpawn():void {
			while (--SpawnOnLoad > -1) {
				var critterID:int = GetNextCritterID();
				var critter:BaseCritter = CritterManager.I.CritterInfo[critterID].CreateCritter(Map, Area[0].X, Area[0].Y);
			}
		}
		
		/**
		 * Gets the critterID (yay!)
		 * @return Returns the CritterID of the monster to spawn
		 */
		private function GetNextCritterID():int {
			return SpawnID[0];
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
				s.Area[totalRects] = new Rect(true, b.readShort(), b.readShort(), b.readShort(), b.readShort());
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