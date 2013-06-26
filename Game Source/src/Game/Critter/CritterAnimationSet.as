package Game.Critter 
{
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import Game.General.Script;
	import RenderSystem.IObjectLayer;
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
		private var CurrentAnimationLooping:Boolean = false;
		
		public function CritterAnimationSet(owner:CritterBeast) {
			Renderman.AnimatedObjectsPush(this);
			
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
			
			myBitmapData = new BitmapData(Info.SpriteWidth, Info.SpriteHeight, true, 0x0000FF00);
			this.bitmapData = myBitmapData;
			
			CurrentPlaybackSpeed = MyCritter.PlaybackSpeed;
			
			UpdateInfo();
		}
		
		public function ChangeDirection(newDirection:int):void {
			currentDirection = newDirection;
			UpdateFrameEnds();
		}
		
		public function ChangeState(newState:int, isLooping:Boolean):void {
			currentAnimationID = newState;
			CurrentAnimationLooping = isLooping;
			UpdateFrameEnds();
		}
		
		private function UpdateFrameEnds():void {
			StartFrame = Owner.Info.AnimationFrameCounts[currentAnimationID*4+currentDirection]
			EndFrame = Owner.Info.AnimationFrameCounts[currentAnimationID*4+currentDirection+1];
			CurrentFrame = StartFrame;
		}
		
		public function GetTrueY():int {
			return Owner.Y;
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
					if(CurrentAnimationLooping) {
						CurrentFrame = StartFrame;
					} else {
						Owner.MyScript.Run(Script.AnimationEnded, this, Owner);
					}
				}
				
				FrameRect.x = (CurrentFrame % MyCritter.AnimationsPerRow) * width;
				FrameRect.y = int(CurrentFrame / MyCritter.AnimationsPerRow) * height;
				
				myBitmapData.copyPixels(sprites, FrameRect, Global.ZeroPoint);
			}
		}
		
		public function CleanUp():void {
			if (this.parent != null)
				this.parent.removeChild(this);
			
			MyCritter.OneLessInstance();
			MyCritter = null;
			FrameRect = null;
			
			Renderman.AnimatedObjectsRemove(this);
			
			if (myBitmapData != null) {
				myBitmapData.dispose();
				myBitmapData = null;
			}
		}
	}
}