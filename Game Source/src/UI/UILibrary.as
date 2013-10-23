package UI {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class UILibrary {
		private var TextureAtlas:BitmapData;
		public var ImageCutouts:Vector.<BitmapData>;
		public var Rectangles:Vector.<Rectangle>;
		
		public function UILibrary(b:ByteArray, id:int) {
			var totalRects:int = b.readShort();
			Rectangles = new Vector.<Rectangle>(totalRects, true);
			ImageCutouts = new Vector.<BitmapData>(totalRects, true);
			
			for (var i:int = 0; i < totalRects; i++) {
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