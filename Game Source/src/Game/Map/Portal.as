package Game.Map 
{
	import CollisionSystem.Rect;
	import flash.geom.Point;
	import flash.utils.ByteArray;
	import Interfaces.IMapObject;
	/**
	 * ...
	 * @author Paul
	 */
	public class Portal implements IMapObject {
		public var Entry:Rect;
		public var ExitPoint:Point = new Point();
		
		public var ID:int;
		public var ExitID:int;
		
		public var MapName:int;
		
		public function Portal(b:ByteArray) {
			Entry = new Rect(true, this);
			
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
		
		public function GetUnion():Rect {
			return Entry;
		}
		
		public function HasPerfectCollision(other:Rect):Boolean {
			return Entry.intersects(other);
		}
		
	}

}