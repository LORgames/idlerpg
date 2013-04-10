package StateSystem {
	import flash.display.Bitmap;
	/**
	 * ...
	 * @author Paul
	 */
	public interface IState {
		
		function Render(bitmap:Bitmap):void;
		function Update(dt:Number):void;
		
	}

}