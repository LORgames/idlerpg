package Game.Tweening {
	/**
	 * ...
	 * @author ...
	 */
	public class Tween {
		
		public var obj:Object;
		public var param:String;
		public var value0:int;
		public var value1:int;
		public var countdown:Number;
		public var valueShift:int;
		
		public function Tween() {
			
		}
		
		public function Assign(obj:Object, param:String, value0:int, value1:int, time:Number):void {
			this.obj = obj;
			this.value0 = value0;
			this.value1 = value1;
			this.countdown = time;
			this.param = param;
			this.obj[this.param] = this.value0;
			this.valueShift = (int)((value1 - value0) / time);
		}
		
		public function Update(dt:Number):void {
			trace("TweenUpdate Obj="+obj+" Param=" + param + " V0=" + value0 + " V1=" + value1 + " T=" + countdown + " vShift=" + valueShift + " dt="+dt);
			
			countdown -= dt;
			obj[param] += (int)(valueShift * dt);
			if (valueShift > 0) {
				if (obj[param] > value1) {
					obj[param] = value1;
				}
			} else {
				if (obj[param] < value1) {
					obj[param] = value1;
				}
			}
		}
	}
}