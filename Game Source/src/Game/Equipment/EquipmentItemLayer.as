package Game.Equipment {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import Game.Scripting.Script;
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
		public var PlaybackSpeed:Number = 0.2;
		
		public var TotalFrames:int = 0;
		public var Frame:int = 0;
		public var FrameDT:Number = 0;
		
		public var CopyRect:Rectangle = new Rectangle();
		
		public function EquipmentItemLayer(ei:EquipmentItem, _layer:int = 0) {
			Renderman.AnimatedObjectsPush(this);
			Owner = ei;
			
			Layer = _layer;
		}
		
		public function SetInformation(equipment:EquipmentInfo):void {
			if (equipment.SizeX == 0 || equipment.SizeY == 0) return;
			Info = equipment;
			PlaybackSpeed = Info.AnimationSpeed;
			
			this.bitmapData = new BitmapData(Info.SizeX, Info.SizeY, true, 0x00FF0000);
			
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
			if (Info != null) {
				var _frames:int = Info.FrameCount(0, Direction, Layer);
				
				if(_frames > 0) {
					this.visible = true;
					
					CopyRect.y = Info.GetSpriteSheetOffset(State, Direction, Layer);
					CopyRect.x = Frame * Info.SizeX;
					
					TotalFrames = Info.FrameCount(State, Direction, Layer);
					
					if (TotalFrames == 0) {
						TotalFrames = _frames;
					}
					
					if (TotalFrames == 1) {
						if (Info.Image != null)
							this.bitmapData.copyPixels(Info.Image, CopyRect, Global.ZeroPoint);
					}
				} else {
					this.visible = false;
					TotalFrames = 0;
				}
			} else {
				this.visible = false;
				TotalFrames = 0;
			}
		}
		
		public function UpdateAnimation(dt:Number):void {
			if(TotalFrames > 1) {
				FrameDT += dt;
				
				if (FrameDT > PlaybackSpeed) {
					FrameDT -= PlaybackSpeed;
					Frame++;
					
					if (Frame == TotalFrames) {
						if (LoopState) {
							Frame = 0;
						} else {
							var sb:int = State;
							
							Owner.MyScript.Run(Script.AnimationEnded);
							
							//We check that the script didn't reset the animation
							if(State == sb && Frame == TotalFrames) {
								Owner.ChangeState(0, true);
							}
						}
					}
					
					CopyRect.x = Frame * Info.SizeX;
				}
			}
			
			if (Info != null && Info.Image != null && TotalFrames > 0) {
				this.bitmapData.copyPixels(Info.Image, CopyRect, Global.ZeroPoint);
			}
		}
		
		public function CleanUp():void {
  			Renderman.AnimatedObjectsRemove(this);
			Owner = null;
			Info = null;
			
			CopyRect = null;
			
			if(this.bitmapData != null) {
				this.bitmapData.dispose();
			}
		}
	}
}