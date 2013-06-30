package {
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.geom.Point;
	/**
	 * ...
	 * @author Paul
	 */
	public class Global {
		//Loading information
		public static var LoadingTotal:int = 0;
		public static var PrevLoadingTotal:int = 0;
		public static var FadeOnLoad:Boolean = true;
		
		//Portaling Information
		public static var MapPortalID:int = -1;
		public static var DisablePortals:Boolean = true;
		
		public static const ZeroPoint:Point = new Point();
		public static var DebugRender:Boolean = false;
		
		//Touch information
		public static var touchArea:Rect = new Rect(true, null, 0, 0, 0, 0);
		public static var thumb:Bitmap;
	}
}