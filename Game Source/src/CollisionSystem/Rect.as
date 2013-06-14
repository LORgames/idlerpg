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
			if (this.X > b.X + b.W) return false;
			if (this.Y > b.Y + b.H) return false;
			if (this.X + this.W < b.X) return false;
			if (this.Y + this.H < b.Y) return false;
			
			return true;
			
			//return !(this.x > b.x + (b.width - 1) || this.x + (this.width - 1) < b.x || this.y > b.y + (b.height - 1) || this.y + (this.height - 1) < b.y);
		}
		
		public function CalculatePenetration(b:Rect, p:Point):void {
			if(X <= b.X && b.X < X + W){
				p.x = -(X + W - b.X);
			}

			if(b.X <= X && X < b.X+b.W){
				p.x = (b.X + b.W - X);
			}

			if(Y <= b.Y && b.Y < Y+H){
				p.y = -(Y + H - b.Y);
			}

			if(b.Y <= Y && Y < b.Y+b.H){
				p.y = (b.Y + b.H - Y);
			}
		}
		
		public function toString():String {
			return "[R: " + X + ", " + Y + " @" + W + "x" + H + "]";
		}
		
	}

}