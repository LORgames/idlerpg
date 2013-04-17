package Game.Map {
	import adobe.utils.CustomActions;
	import flash.display.BitmapData;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class ObjectTemplate implements IAnimated {
		
		public var ObjectID:int;
		public var TotalFrames:int;
		public var Base:Rectangle;
		
		public var isSolid:Boolean;
		
		private var isLoading:Boolean = false;
		private var bitmapCopy:BitmapData;
		private var fullBitmap:BitmapData;
		
		private var timeout:Number = 0;
		private var currentFrame:int = 0;
		private var frameSize:Rectangle = new Rectangle();
		
		public const EmptyPoint:Point = new Point();
		
		public function GetBitmap():BitmapData {
			if (!isLoading) {
				isLoading = true;
				ImageLoader.Load("Data/Object_" + ObjectID + ".png", LoadedBitmap);
			}
			
			return bitmapCopy;
		}
		
		private function LoadedBitmap(e:BitmapData):void {
			bitmapCopy.copyPixels(e, frameSize, EmptyPoint);
			
			if (TotalFrames > 1) {
				Renderman.AnimatedObjects.push(this);
				fullBitmap = e;
			}
		}
		
		public function UpdateAnimation(dt:Number):void {
			timeout += dt;
			if (timeout > 0.1) {
				timeout -= dt;
				currentFrame++;
				if (currentFrame == TotalFrames) currentFrame = 0;
				
				frameSize.x = currentFrame * frameSize.width;
				bitmapCopy.copyPixels(fullBitmap, frameSize, EmptyPoint);
			}
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
				
				obj.frameSize.width = e.readShort();
				obj.frameSize.height = e.readShort();
				
				obj.bitmapCopy = new BitmapData(obj.frameSize.width, obj.frameSize.height, true, 0x608080FF);
				
				Objects[i] = obj;
			}
			
			Global.LoadingTotal--;
		}
	}

}