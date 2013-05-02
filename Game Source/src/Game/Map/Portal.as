package Game.Map 
{
	import flash.geom.Point;
	import flash.utils.ByteArray;
	/**
	 * ...
	 * @author Paul
	 */
	public class Portal {
		public var Entry:Rect = new Rect();
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
			Entry.x = b.readShort();
			Entry.y = b.readShort();
			Entry.width = b.readShort();
			Entry.height = b.readShort();
		}
		
	}

}