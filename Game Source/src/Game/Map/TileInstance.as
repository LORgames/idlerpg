package Game.Map {
	/**
	 * ...
	 * @author Paul
	 */
	public class TileInstance {
		public var TileID:int = 0;
		
		public var Walkable:Boolean = true;
		public var AccessDirections:int = TileTemplate.ACCESS_ALL;
		
		public var TemporaryLock:Boolean = false;
		
		public var Left:TileInstance;
		public var Right:TileInstance;
		public var Up:TileInstance;
		public var Down:TileInstance;
	}
}