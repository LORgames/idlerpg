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
		
		//Debug information
		public static var DebugRender:Boolean = false;
		static public var DebugFPS:Boolean = false;
		static public var IsEditor:Boolean = true;
		
		//Settings
		public static var GameName:String = "";
		public static var FPS:int = 20;
		public static var HasTiles:Boolean = false;
		public static var TileSize:int = 48;
		public static var HasCharacter:Boolean = false;
		public static var PerspectiveSkew:Number = 0.85;
	}
}