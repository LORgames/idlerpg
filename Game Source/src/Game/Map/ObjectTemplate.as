package Game.Map 
{
	import adobe.utils.CustomActions;
	import flash.display.BitmapData;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class ObjectTemplate {
		
		public var ObjectID:int;
		public var TotalFrames:int;
		public var Base:Rectangle;
		
		public var isSolid:Boolean;
		
		private var isLoading:Boolean = false;
		private var bitmapCopy:BitmapData;
		private var fullBitmap:BitmapData;
		
		public function GetBitmap():BitmapData {
			if (!isLoading) {
				isLoading = true;
				ImageLoader.Load("Data/Object_" + ObjectID + ".png", LoadedBitmap);
			}
			
			return bitmapCopy;
		}
		
		private function LoadedBitmap(e:BitmapData):void {
			fullBitmap = e;
			bitmapCopy.copyPixels(e, new Rectangle(0, 0, bitmapCopy.width, bitmapCopy.height), new Point());
		}
		
		//The Static Things (Including Loading)
		public static var Objects:Vector.<ObjectTemplate>;
		public static var TotalObjects:int;
		
		public static function LoadObjectInfo():void {
			BinaryLoader.Load("Data/ObjectInfo.bin", LoadedObjects);
			Global.LoadingTotal++;
		}
		
		private static function LoadedObjects(e:ByteArray):void {
			TotalObjects = e.readShort();
			Objects = new Vector.<ObjectTemplate>(TotalObjects, true);
			
			for (var i:int = 0; i < TotalObjects; i++) {
				var obj:ObjectTemplate = new ObjectTemplate();
				
				obj.ObjectID = i;
				obj.TotalFrames = e.readByte();
				
				var _x:int = e.readShort();
				var _y:int = e.readShort();
				var _w:int = e.readShort();
				var _h:int = e.readShort();
				
				obj.Base = new Rectangle(_x, _y, _w, _h);
				
				obj.isSolid = (e.readByte() == 1);
				
				_w = e.readShort();
				_h = e.readShort();
				
				obj.bitmapCopy = new BitmapData(_w, _h);
				
				Objects[i] = obj;
			}
			
			Global.LoadingTotal--;
		}
	}

}