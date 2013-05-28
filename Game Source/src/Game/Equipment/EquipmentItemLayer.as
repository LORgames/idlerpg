package Game.Equipment {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import Game.General.Script;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentItemLayer extends Bitmap implements IAnimated {
		public var Owner:EquipmentItem;
		public var Info:EquipmentInfo;
		
		public var Direction:int = 0;
		public var Layer:int = 0;
		
		public var LoopState:Boolean = true;
		public var State:int = 0;
		
		public var TotalFrames:int = 0;
		public var Frame:int = 0;
		public var FrameDT:Number = 0;
		
		public var CopyRect:Rectangle = new Rectangle();
		public static var DestPoint:Point = new Point();
		
		public function EquipmentItemLayer(ei:EquipmentItem, _layer:int = 0) {
			Renderman.AnimatedObjects.push(this);
			Owner = ei;
			
			Layer = _layer;
			
			if(ei.Info != null) trace(ei.Info.Name + ": L" + Layer);
		}
		
		public function SetInformation(equipment:EquipmentInfo):void {
			Info = equipment;
			
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
			
			if (LoopState) Frame = 0;
			
			Recalculate();
		}
		
		public function Recalculate():void {
			if(Info != null) trace("Recalc: " + Info.Name + "; D" + Direction + " L" + Layer + " F" + Info.FrameCount(0, Direction, Layer));
			
			if (Info != null && Info.FrameCount(0, Direction, Layer) > 0) {
				this.visible = true;
				
				CopyRect.y = Info.GetSpriteSheetOffset(State, Direction, Layer);
				CopyRect.x = Frame * Info.SizeX;
				
				TotalFrames = Info.FrameCount(State, Direction, Layer);
				
				if (TotalFrames == 0) {
					TotalFrames = Info.FrameCount(0, Direction, Layer);
				}
				
				if (TotalFrames == 1) {
					if (Info.Image != null)
						this.bitmapData.copyPixels(Info.Image, CopyRect, DestPoint);
				}
			} else {
				this.visible = false;
			}
			trace("--------------------------------------------------------------");
		}
		
		public function UpdateAnimation(dt:Number):void {
			if(TotalFrames > 1) {
				FrameDT += dt;
				
				if (FrameDT > Info.AnimationSpeed) {
					FrameDT -= Info.AnimationSpeed;
					Frame++;
					if (Frame == TotalFrames) {
						if (LoopState) {
							Frame = 0;
						} else {
							Info.MyScript.Run(Script.AnimationEnded, Owner, Owner.Owner.Owner);
							Owner.SetState(0);
						}
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