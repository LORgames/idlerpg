package Game.Map.Portals 
{
	import CollisionSystem.Rect;
	import flash.geom.Point;
	import flash.utils.ByteArray;
	import Interfaces.IMapObject;
	/**
	 * ...
	 * @author Paul
	 */
	public class Portal {
		public var Entry:Rect;
		public var ExitPoint:Point = new Point();
		
		public var ID:int;
		public var ExitID:int;
		
		public var MapName:int;
		
		public function Portal(b:ByteArray) {
			Entry = new Rect(true, null);
			
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
		
		public function CleanUp():void {
			Entry = null;
			ExitPoint = null;
			MapName = 0;
		}
		
	}

}