package  {
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
		
	}

}