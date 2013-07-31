package Game.Map.Objects {
	import adobe.utils.CustomActions;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import flash.geom.Vector3D;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import Game.Scripting.Script;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class ObjectTemplate implements IAnimated {
		
		public var ObjectID:int;
		public var Name:String;
		
		public var TotalFrames:Vector.<int>;
		public var PlaybackSpeed:Vector.<Number>;
		public var Bases:Vector.<Rectangle>;
		public var IndividualAnimations:Boolean = false;
		
		public var MyScript:Script;
		
		public var isSolid:Boolean;
		public var OffsetHeight:int;
		
		private var isLoading:Boolean = false;
		private var bitmapCopy:BitmapData;
		public var SpriteAtlas:BitmapData;
		
		private var timeout:Number = 0;
		
		private var CurrentFrame:int = 0;
		private var StartFrame:int = 0;
		private var EndFrame:int = 0;
		
		public var SpriteSizeW:int;
		public var SpriteSizeH:int;
		
		public var FrameSize:Rectangle = new Rectangle();
		
		private var Instances:int = 0;
		
		public function ObjectTemplate() {
			
		}
		
		public function GetBitmap():BitmapData {
			Instances++;
			
			if (!isLoading) {
				isLoading = true;
				Global.LoadingTotal++;
				ImageLoader.Load("Data/Object_" + ObjectID + ".png", LoadedBitmap);
			}
			
			return bitmapCopy;
		}
		
		public function OneLessInstance():void {
			Instances--;
			
			if (Instances == 0) {
				if (SpriteAtlas != null) {
					SpriteAtlas.dispose();
					SpriteAtlas = null;
				}
				
				isLoading = false;
				
				//Only has 1 state for non-instanced animation
				if (TotalFrames[1] > 1) {
					Renderman.AnimatedObjectsRemove(this);
				}
			}
		}
		
		private function LoadedBitmap(e:BitmapData):void {
			SpriteAtlas = e.clone();
			bitmapCopy.copyPixels(e, FrameSize, Global.ZeroPoint);
			Global.LoadingTotal--;
			
			//Only has 1 state for non-instanced animation
			if (TotalFrames[1] > 1) {
				Renderman.AnimatedObjectsPush(this);
			}
		}
		
		public function UpdateAnimation(dt:Number):void {
			timeout += dt;
			
			//Only has 1 state for non-instanced animation
			if (timeout > PlaybackSpeed[0]) {
				while(timeout > PlaybackSpeed[0]) {
					timeout -= PlaybackSpeed[0];
					CurrentFrame++;
					if (CurrentFrame == TotalFrames[1]) CurrentFrame = 0;
				}
				
				FrameSize.x = CurrentFrame * FrameSize.width;
				bitmapCopy.copyPixels(SpriteAtlas, FrameSize, Global.ZeroPoint);
			}
		}
		
		//The Static Things (Including Loading)
		public static var Objects:Vector.<ObjectTemplate>;
		public static var TotalObjects:int;
		
		public static function LoadObjectInfo():void {
			BinaryLoader.Load("Data/ObjectInfo.bin", LoadedObjects);
			Global.LoadingTotal++;
		}
		
		private static function LoadedObjects(b:ByteArray):void {
			TotalObjects = b.readShort();
			Objects = new Vector.<ObjectTemplate>(TotalObjects, true);
			var totalRects:int = 0;
			
			for (var i:int = 0; i < TotalObjects; i++) {
				var obj:ObjectTemplate = new ObjectTemplate();
				
				obj.ObjectID = i;
				obj.Name = BinaryLoader.GetString(b);
				
				var totalFrames:int = b.readByte();
				obj.TotalFrames = new Vector.<int>(totalFrames + 1, true);
				obj.PlaybackSpeed = new Vector.<Number>(totalFrames, true);
				
				obj.TotalFrames[0] = 0; //Always push 0 onto the bottom of the pile so that it starts at 0
				
				for (var j:int = 0; j < totalFrames; j++) {
					obj.TotalFrames[j + 1] = b.readByte() + obj.TotalFrames[j];
					obj.PlaybackSpeed[j] = b.readFloat();
				}
				
				obj.FrameSize.width = b.readShort();
				obj.FrameSize.height = b.readShort();
				obj.SpriteSizeW = b.readShort();
				obj.SpriteSizeH = b.readShort();
				
				obj.OffsetHeight = b.readShort();
				
				obj.bitmapCopy = new BitmapData(obj.FrameSize.width, obj.FrameSize.height, true, 0x608080FF);
				
				totalRects = b.readByte();
				
				obj.Bases = new Vector.<Rectangle>(totalRects, true);
				
				while(--totalRects > -1) {
					var _x:int = b.readShort();
					var _y:int = b.readShort();
					var _w:int = b.readShort();
					var _h:int = b.readShort();
					
					obj.Bases[totalRects] = new Rectangle(_x, _y, _w, _h);
				}
				
				var extraData:uint = b.readUnsignedByte();
				obj.isSolid = (extraData & 0x1) == 0x1;
				obj.IndividualAnimations = (extraData & 0x2) == 0x2;
				
				obj.MyScript = Script.ReadScript(b);
				
				Objects[i] = obj;
			}
			
			Global.LoadingTotal--;
		}
	}

}