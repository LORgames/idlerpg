package Game.Map 
{
	import CollisionSystem.Rect;
	import flash.geom.Point;
	import flash.utils.ByteArray;
	/**
	 * ...
	 * @author Paul
	 */
	public class Portal {
		public var Entry:Rect = new Rect(true);
		public var ExitPoint:Point = new Point();
		
		public var ID:int;
		public var ExitID:int;
		
		public var MapName:int;
		
		public function Portal(b:ByteArray) {
			//portal id
			ID = b.readShort();
			ExitID = b.readShort();
			
			//read entry
			ExitPoint.x = b.readShort();
			ExitPoint.y = b.readShort();
			
			//read exit
			Entry.X = b.readShort();
			Entry.Y = b.readShort();
			Entry.W = b.readShort();
			Entry.H = b.readShort();
		}
		
	}

}