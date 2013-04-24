package Game.Equipment {
	import flash.display.BitmapData;
	import flash.geom.Point;
	import Game.General.ImageLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentInfo {
		
		public var Name:String;
		public var isAvailableAtStart:Boolean;
		
		public var SizeX:int;
		public var SizeY:int;
		
		public var OffsetsLocked:Boolean;
		public var Offset:Point;
		public var Offset_1:Point;
		public var Offset_2:Point;
		public var Offset_3:Point;
		
		public var Center:Point;
		
		public var Frames_Default:int;
		public var Frames_Walking:int;
		public var Frames_Attacking:int;
		public var Frames_Dancing:int;
		
		public var Image:BitmapData;
		
		private var Loading:Boolean = false;
		private var SpriteSheetYOffsets:Vector.<int> = new Vector.<int>(32, true); //TODO: Badly need to optimize this
		
		public function LoadIfRequired():void {
			if (Image == null && !Loading) {
				Loading = true;
				ImageLoader.Load("Data/Equipment_" + Name + ".png", LoadedImage);
			}
		}
		
		public function LoadedImage(e:BitmapData):void {
			Image = e;
		}
		
		public function ProcessSpriteSheetOffsets():void {
			var currentOffset:int = 0;
			
			for (var i:int = 0; i < 4; i++) { //4 states
				for (var k:int = 0; k < 2; k++) { //2 layers
					for (var j:int = 0; j < 4; j++) { //4 directions
						if (FrameCount(i, j, k) > 0) {
							SpriteSheetYOffsets[16 * k + 4 * j + i] = currentOffset;
							currentOffset += SizeY;
						} else {
							SpriteSheetYOffsets[16 * k + 4 * j + i] = 0;
						}
					}
				}
			}
		}
		
		public function GetOffset(state:int, direction:int, layer:int):int {
			return SpriteSheetYOffsets[layer * 16 + direction * 4 + state];
		}
		
		public function FrameCount(state:int, direction:int, layer:int):int {
			var sData:int = 0;
			
			if (state == 0) sData = Frames_Default;
			if (state == 1) sData = Frames_Walking;
			if (state == 2) sData = Frames_Attacking;
			if (state == 3) sData = Frames_Dancing;
			
			var o:int = 4 * (3 - direction) + 16 * layer;
			var s:int = (sData & (0xF << o)) >> o;
			
			return s;
		}
	}

}