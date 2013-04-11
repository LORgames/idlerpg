package RenderSystem 
{
	import flash.display.Loader;
	/**
	 * ...
	 * @author Paul
	 */
	public class ImageLoader {
		private static var Loading0:Boolean = false;
		private static var Loading1:Boolean = false;
		private static var Loading2:Boolean = false;
		private static var Loading3:Boolean = false;
		private static var Loading4:Boolean = false;
		
		private static var Loader0:Loader = new Loader();
		private static var Loader1:Loader = new Loader();
		private static var Loader2:Loader = new Loader();
		private static var Loader3:Loader = new Loader();
		private static var Loader4:Loader = new Loader();
		
		private static var LoadQueue:Vector.<ImageRequest> = new Vector.<ImageRequest>();
		
		public static function AddToQueue(imageName:String, loadedCallback:Function):void {
			
		}
	}

}