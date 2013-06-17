package Game.Equipment {
	import flash.display.BitmapData;
	import flash.geom.Point;
	import Game.General.ImageLoader;
	import Game.General.Script;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentInfo {
		
		public var Name:String;
		public var isAvailableAtStart:Boolean;
		
		public var SizeX:int;
		public var SizeY:int;
		public var AnimationSpeed:Number;
		
		public var OffsetsLocked:Boolean;
		public var Offset:Point;
		public var Offset_1:Point;
		public var Offset_2:Point;
		public var Offset_3:Point;
		
		public var Center:Point;
		
		public var FrameCounts:Vector.<int>;
		
		public var Image:BitmapData;
		
		private var Loading:Boolean = false;
		public var SpriteSheetYOffsets:Vector.<int>;
		
		public var MyScript:Script;
		
		public function EquipmentInfo() {
			
		}
		
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
			
			for (var i:int = 0; i < FrameCounts.length; i++) { //4 states
				for (var j:int = 0; j < 4; j++) { //4 directions
					var state_Direction:int = 0;
					
					for (var k:int = 0; k < 2; k++) { //2 layers
						if (FrameCount(i, j, k) > 0) {
							if (k == 0) {
								state_Direction = currentOffset & 0xFFFF;
							} else {
								var c:int = currentOffset;
								state_Direction |= (c << 16);
							}
							
							currentOffset += SizeY;
						}
					}
					
					//4 directions
					SpriteSheetYOffsets[4 * i + j] = state_Direction;
				}
			}
		}
		
		public function GetSpriteSheetOffset(state:int, direction:int, layer:int):int {	
			var _t:int = SpriteSheetYOffsets[direction + 4 * state];
			
			if (layer == 0) {
				_t &= 0xFFFF;
			} else {
				_t = _t >> 16;
			}
			
			return _t;
		}
		
		public function FrameCount(state:int, direction:int, layer:int):int {
			var sData:int = FrameCounts[state];
			
			var o:int = 4 * direction + 16 * layer;
			var s:int = (sData & (0xF << o)) >> o;
			
			return s;
		}
	}

}