package Game.Tweening {
	import adobe.utils.CustomActions;
	/**
	 * ...
	 * @author ...
	 */
	public class TweenManager {
		private static var _InactiveTweens:Vector.<Tween> = new Vector.<Tween>();
		private static var _ActiveTweens:Vector.<Tween> = new Vector.<Tween>();
		
		public static function StartTweenBetween(obj:Object, param:String, startValue:int, endValue:int, time:Number):void {
			var temp:Tween = GetInactiveTween();
			temp.Assign(obj, param, startValue, endValue, time);
			_ActiveTweens.push(temp);
		}
		
		public static function StartTweenTo(obj:Object, param:String, endValue:int, time:Number):void {
			var temp:Tween = GetInactiveTween();
			temp.Assign(obj, param, obj[param], endValue, time);
			_ActiveTweens.push(temp);
		}
		
		public static function Update(dt:Number):void {
			// Iterate over all active tweens and update
			for (var i:int = 0; i < _ActiveTweens.length; i++) {
				_ActiveTweens[i].Update(dt);
				if (_ActiveTweens[i].countdown <= 0) {
					var temp:Tween = _ActiveTweens[i];
					_ActiveTweens.splice(i, 1);
					_InactiveTweens.push(temp);
				}
			}
		}
		
		private static function GetInactiveTween():Tween {
			if (_InactiveTweens.length == 0) {
				return new Tween();
			} else {
				return _InactiveTweens.pop();
			}
		}
	}
}