package Game.Critter 
{
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import Interfaces.IObjectLayer;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterAnimationSet extends Bitmap implements IObjectLayer, IAnimated {
		private var Owner:CritterBeast;
		private var MyCritter:CritterInfoBeast;
		
		private var sprites:BitmapData;
		private var myBitmapData:BitmapData;
		
		private var currentAnimationID:int = 0;
		private var currentDirection:int = 0;
		private var currentState:int = 0;
		
		private var StartFrame:int = 0;
		private var EndFrame:int = 0;
		
		private var FrameRect:Rectangle = new Rectangle();
		private var FrameDT:Number = 0;
		private var CurrentPlaybackSpeed:Number = 0;
		private var CurrentFrame:int = 0;
		
		public function CritterAnimationSet(owner:CritterBeast) {
			Renderman.AnimatedObjects.push(this);
			
			Owner = owner;
			ChangeCritterInfo(Owner.Info);
		}
		
		public function ChangeCritterInfo(Info:CritterInfoBeast):void {
			Main.OrderedLayer.addChild(this);
			
			if (MyCritter != null) MyCritter.OneLessInstance();
			
			MyCritter = Info;
			sprites = Info.GetSprites();
			
			FrameRect.x = 0;
			FrameRect.y = 0;
			FrameRect.width = Info.SpriteWidth;
			FrameRect.height = Info.SpriteHeight;
			
			if (myBitmapData != null) {
				myBitmapData.dispose();
				myBitmapData = null;
			}
			
			myBitmapData = new BitmapData(Info.SpriteWidth, Info.SpriteHeight, true, 0x1000FF00);
			this.bitmapData = myBitmapData;
			
			CurrentPlaybackSpeed = MyCritter.PlaybackSpeed;
			
			UpdateInfo();
		}
		
		public function ChangeDirection(newDirection:int):void {
			//TODO: this function
		}
		
		public function GetTrueY():int {
			return y;
		}
		
		public function UpdateInfo():void {
			StartFrame = MyCritter.AnimationFrameCounts[currentAnimationID];
			EndFrame = MyCritter.AnimationFrameCounts[currentAnimationID+1];
			
			if (CurrentFrame < StartFrame || CurrentFrame >= EndFrame) CurrentFrame = StartFrame;
			
			FrameRect.x = (CurrentFrame % MyCritter.AnimationsPerRow) * width;
			FrameRect.y = (CurrentFrame / MyCritter.AnimationsPerRow) * height;
			
			myBitmapData.copyPixels(sprites, FrameRect, Global.ZeroPoint);
		}
		
		public function UpdateAnimation(dt:Number):void {
			FrameDT += dt;
			
			if (FrameDT > CurrentPlaybackSpeed) {
				FrameDT -= CurrentPlaybackSpeed;
				CurrentFrame++;
				
				if (CurrentFrame >= EndFrame) {
					CurrentFrame = StartFrame;
				}
				
				FrameRect.x = (CurrentFrame % MyCritter.AnimationsPerRow) * width;
				FrameRect.y = int(CurrentFrame / MyCritter.AnimationsPerRow) * height;
				
				myBitmapData.copyPixels(sprites, FrameRect, Global.ZeroPoint);
			}
		}
	}
}