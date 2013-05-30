package  {
	/**
	 * ...
	 * @author Paul
	 */
	public class Rect {
		//Yes yes, Rectangle is a thing its also SUPER SLOW
		//So wrote my own (its also using ints which is faster again)
		public var x:int;
		public var y:int;
		public var width:int;
		public var height:int;
		
		public var CX:int;
		public var CY:int;
		
		public function Rect(x:int = 0, y:int = 0, w:int = 0, h:int = 0) {
			this.x = x;
			this.y = y;
			this.width = w;
			this.height = h;
			
			this.CX = w * 0.5;
			this.CY = h * 0.5;
		}
		
		public function intersects(b:Rect):Boolean{
			if (this.x > b.x + b.width) return false;
			if (this.y > b.y + b.height) return false;
			if (this.x + this.width < b.x) return false;
			if (this.y + this.height < b.y) return false;
			
			return true;
			
			//return !(this.x > b.x + (b.width - 1) || this.x + (this.width - 1) < b.x || this.y > b.y + (b.height - 1) || this.y + (this.height - 1) < b.y);
		}
		
		public function intersectEdge(b:Rect):int {
			var sides:int = 0;
			var cX0 = x + CX;
			var cY0 = y + CY;
			var cX1 = b.x + b.CX;
			var cY1 = b.y + b.CY;
			
			if (cX0 < cX1) {
				if (x+width < b.x) sides |= 1; // Left
			} else {
				if (b.x+b.width < x) sides |= 2; // Right
			}
			
			if (cY0 < cY1) {
				if (y + height < b.y) sides |= 4; // Up
			} else {
				if (b.y+b.height < y) sides |= 8; // Down
			}
			
			return sides;
		}
		
	}

}