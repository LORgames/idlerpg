package  {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import flash.geom.Point;
	/**
	 * ...
	 * @author Paul
	 */
	public class MathsEx {
		
		public static function ZeroPad(n:int, minimumLength:int, radix:int = 10):String {
			var v:String = n.toString(radix);
			var stillNeed:int = minimumLength - v.length;       
			return (stillNeed <= 0) ? v : String(Math.pow(10, stillNeed) + v).substr(1);
		}
		
		public static function ClosestPointToAABB(x:int, y:int, aabb:Rect):PointX {
			var v:PointX = new PointX();
			var q:PointX = new PointX();
			
			v.X = x;
			if (v.X < aabb.X) v.X = aabb.X;
			if (v.X > aabb.X+aabb.W) v.X = aabb.X+aabb.W;
			q.X = v.X;
			
			v.Y = y;
			if (v.Y < aabb.Y) v.Y = aabb.Y;
			if (v.Y > aabb.Y+aabb.H) v.Y = aabb.Y+aabb.H;
			q.Y = v.Y;
			
			return q;
		}
	}

}