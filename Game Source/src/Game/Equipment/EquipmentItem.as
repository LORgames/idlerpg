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
		
		public var LoopState:Boolean = true;
		public var State:int = 0;
		
		public var TotalFrames:int = 0;
		public var Frame:int = 0;
		public var FrameDT:Number = 0;
		
		public var CopyRect:Rectangle = new Rectangle();
		public var DestPoint:Point = new Point();
		
		public function EquipmentItem() {
			Renderman.AnimatedObjects.push(this);
		}
		
		public function SetInformation(equipment:EquipmentInfo, layer:int = 0):void {
			Info = equipment;
			Info.LoadIfRequired();
			
			Layer = layer;
			this.bitmapData = new BitmapData(Info.SizeX, Info.SizeY);
			
			CopyRect.width = Info.SizeX;
			CopyRect.height = Info.SizeY;
		}
		
		public function SetState(newState:int, loop:Boolean = true):void {
			State = newState;
			Frame = 0;
			
			LoopState = loop;
			
			Recalculate();
		}
		
		public function SetDirection(newDirection:int):void {
			Direction = newDirection;
			if(LoopState) Frame = 0;
			Recalculate();
		}
		
		public function Offset(direction:int = 0):Point {
			if(Info != null) {
				if (direction == 1) return Info.Offset_1;
				if (direction == 2) return Info.Offset_2;
				if (direction == 3) return Info.Offset_3;
				return Info.Offset;
			} else {
				return DestPoint;
			}
		}
		
		public function Recalculate():void {
			if (Info.FrameCount(0, Direction, Layer) > 0) {
				this.visible = true;
				
				CopyRect.y = Info.GetSpriteSheetOffset(State, Direction, Layer);
				CopyRect.x = Frame * Info.SizeX;
				
				TotalFrames = Info.FrameCount(State, Direction, Layer);
				
				if (TotalFrames == 0) {
					TotalFrames = Info.FrameCount(0, Direction, Layer);
				}
			} else {
				this.visible = false;
			}
		}
		
		public function GetCenter():Point {
			return Info.Center;
		}
		
		public function UpdateAnimation(dt:Number):void {
			if(TotalFrames > 1) {
				FrameDT += dt;
				
				if (FrameDT > Info.AnimationSpeed) {
					FrameDT -= Info.AnimationSpeed;
					Frame++;
					if (Frame == TotalFrames) {
						if (LoopState) Frame = 0;
						else SetState(0);
					}
					
					CopyRect.x = Frame * Info.SizeX;
				}
			}
			
			if (Info != null && Info.Image != null && TotalFrames > 0) {
				this.bitmapData.copyPixels(Info.Image, CopyRect, DestPoint);
			}
		}
	}

}