package  {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import flash.geom.Point;
	import Interfaces.IMapObject;
	import Scripting.IScriptTarget;
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
		
		static public function GetDistanceSquared(p0:PointX, p1:PointX):int {
			var x:int = p0.X - p1.X;
			var y:int = p0.Y - p1.Y;
			
			return x * x + y * y;
		}
		
		static public function GetClosestObjectInVector(p0:PointX, objects:Vector.<IScriptTarget>):IScriptTarget {
			if (objects.length == 0) return null;
			
			var p1:PointX = new PointX();
			
			var minobj:IScriptTarget = objects[0]; minobj.UpdatePointX(p1);
			var mindist:int = GetDistanceSquared(p0, p1);
			var trydist:int;
			
			for (var i:int = 1; i < objects.length; i++) {
				objects[i].UpdatePointX(p1);
				trydist = GetDistanceSquared(p0, p1);
				
				if (trydist < mindist) {
					minobj = objects[i];
					mindist = trydist;
				}
			}
			
			return minobj;
		}
	}

}