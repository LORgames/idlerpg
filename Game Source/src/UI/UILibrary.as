package UI {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Loaders.BinaryLoader;
	import Loaders.ImageLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class UILibrary {
		private var TextureAtlas:BitmapData;
		public var ImageCutouts:Vector.<BitmapData>;
		public var Rectangles:Vector.<Rectangle>;
		public var TotalFrames:int = 0;
		
		public function UILibrary(b:ByteArray, id:int) {
			TotalFrames = b.readShort();
			Rectangles = new Vector.<Rectangle>(TotalFrames, true);
			ImageCutouts = new Vector.<BitmapData>(TotalFrames, true);
			
			for (var i:int = 0; i < TotalFrames; i++) {
				Rectangles[i] = new Rectangle(b.readShort(), b.readShort(), b.readShort(), b.readShort());
			}
			
			ImageLoader.Load("Data/UILibrary_" + id + ".png", LoadedAtlas);
		}
		
		public function LoadedAtlas(b:BitmapData):void {
			TextureAtlas = b.clone();
			
			for (var i:int = 0; i < Rectangles.length; i++) {
				ImageCutouts[i] = new BitmapData(Rectangles[i].width, Rectangles[i].height);
				ImageCutouts[i].copyPixels(TextureAtlas, Rectangles[i], Global.ZeroPoint);
			}
		}
	}
}