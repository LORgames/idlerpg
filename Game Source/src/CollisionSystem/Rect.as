package CollisionSystem {
	import flash.geom.Point;
	import Interfaces.IMapObject;
	/**
	 * ...
	 * @author Paul
	 */
	public class Rect {
		//Yes yes, Rectangle is a thing its also SUPER SLOW
		//So wrote my own (its also using ints which is faster again)
		public var X:int;
		public var Y:int;
		public var W:int;
		public var H:int;
		
		public var IsStatic:Boolean = false;
		public var Owner:IMapObject;
		
		public function Rect(isStatic:Boolean, owner:IMapObject, x:int = 0, y:int = 0, w:int = 0, h:int = 0) {
			this.X = x;
			this.Y = y;
			this.W = w;
			this.H = h;
			
			Owner = owner;
			IsStatic = isStatic;
		}
		
		public function intersects(b:Rect):Boolean{
			if (this.X > b.X + b.W - 1) return false;
			if (this.Y > b.Y + b.H - 1) return false;
			if (this.X + this.W - 1 < b.X) return false;
			if (this.Y + this.H - 1 < b.Y) return false;
			
			return true;
			
			//return !(this.x > b.x + (b.width - 1) || this.x + (this.width - 1) < b.x || this.y > b.y + (b.height - 1) || this.y + (this.height - 1) < b.y);
		}
		
		public function CalculatePenetration(b:Rect, p:Point):void {
			/*if (X <= b.X && b.X < X + W) {
				p.x = -(X + W - b.X);
			}
			
			if (b.X <= X && X < b.X + b.W) {
				p.x = (b.X + b.W - X);
			}
			
			if (Y <= b.Y && b.Y < Y + H) {
				p.y = -(Y + H - b.Y);
			}
			
			if (b.Y <= Y && Y < b.Y + b.H) {
				p.y = (b.Y + b.H - Y);
			}*/
			
			var x0:int = -(X + W - b.X);
			var x1:int = (b.X + b.W - X);
			var y0:int = -(Y + H - b.Y);
			var y1:int = (b.Y + b.H - Y);
			
			var xr:int = (x0 < 0? -x0 : x0) < (x1 < 0? -x1 : x1)? x0 : x1;
			var yr:int = (y0 < 0? -y0 : y0) < (y1 < 0? -y1 : y1)? y0 : y1;
			
			if ((xr < 0 && p.x > 0) || (xr > 0 && p.x < 0)) {
				p.x = 0;
			} else {
				p.x = xr;
			}
			
			if ((yr < 0 && p.y > 0) || (yr > 0 && p.y < 0)) {
				p.y = 0;
			} else {
				p.y += yr;
			}
		}
		
		public function toString():String {
			return "[R: " + X + ", " + Y + " @" + W + "x" + H + "]";
		}
		
		public function ContainsPoint(xPos:Number, yPos:Number):Boolean {
			if (this.X > xPos) return false;
			if (this.Y > yPos) return false;
			if (this.X + this.W < xPos) return false;
			if (this.Y + this.H < yPos) return false;
			
			return true;
		}
		
		//Some helper functions
		public static function GetRectFromPointWithRadius(p:PointX, r:int, isStatic:Boolean = true, owner:IMapObject = null):Rect {
			var x:int = p.X - r;
			var y:int = p.Y - r;
			return new Rect(isStatic, owner, x, y, r * 2, r * 2);
		}
	}
}