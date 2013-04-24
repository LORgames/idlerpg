package Game.Equipment {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentItem extends Bitmap implements IAnimated {
		
		public var Info:EquipmentInfo;
		
		public var Layer:int = 0;
		public var Direction:int = 0;
		public var State:int = 0;
		
		public var TotalFrames:int = 0;
		public var Frame:int = 0;
		
		
		public var CopyRect:Rectangle = new Rectangle();
		public var DestPoint:Point = new Point();
		
		public function EquipmentItem() {
			Renderman.AnimatedObjects.push(this);
		}
		
		public function SetInformation(equipment:EquipmentInfo, layer:int = 1):void {
			Info = equipment;
			Info.LoadIfRequired();
			
			Layer = layer - 1;
			this.bitmapData = new BitmapData(Info.SizeX, Info.SizeY);
			
			CopyRect.width = Info.SizeX;
			CopyRect.height = Info.SizeY;
		}
		
		public function Offset(direction:int = 0):Point {
			Direction = direction;
			Frame = 0;
			this.visible = true;
			
			if(Info != null) {
				if (direction == 1) return Info.Offset_1;
				if (direction == 2) return Info.Offset_2;
				if (direction == 3) return Info.Offset_3;
				return Info.Offset;
			} else {
				return DestPoint;
			}
		}
		
		public function GetCenter():Point {
			return Info.Center;
		}
		
		public function UpdateAnimation(dt:Number):void {
			if (Info != null && Info.Image != null) {
				if (Info.FrameCount(0, Direction, Layer) > 0) { //make sure this layer has a default at least
					CopyRect.y = Info.GetOffset(State, Direction, Layer);
					this.bitmapData.copyPixels(Info.Image, CopyRect, DestPoint);
				} else {
					this.visible = false;
				}
			}
		}
	}

}