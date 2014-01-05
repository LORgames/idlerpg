package Game.Critter 
{
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Rectangle;
	import flash.media.Microphone;
	import Scripting.Script;
	import RenderSystem.IObjectLayer;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterAnimationSet extends Sprite implements IObjectLayer, IAnimated {
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
			currentDirection = 3;
			ChangeCritterInfo(Owner.BeastInfo);
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
			
			myBitmapData = new BitmapData(Info.SpriteWidth, Info.SpriteHeight, true, Global.DebugRender?0x0000FF00:0xFF000000);
			this.addChild(new Bitmap(myBitmapData));
			
			this.addChild(Owner.miniPanel);
			
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
			StartFrame = Owner.BeastInfo.AnimationFrameCounts[currentAnimationID*4+currentDirection]
			EndFrame = Owner.BeastInfo.AnimationFrameCounts[currentAnimationID*4+currentDirection+1];
			CurrentFrame = StartFrame;
			
			FrameDT = CurrentPlaybackSpeed;
			
			FrameRect.x = (CurrentFrame % MyCritter.AnimationsPerRow) * myBitmapData.width;
			FrameRect.y = int(CurrentFrame / MyCritter.AnimationsPerRow) * myBitmapData.height;
			
			myBitmapData.copyPixels(sprites, FrameRect, Global.ZeroPoint);
		}
		
		public function GetTrueY():int {
			return Owner.Y;
		}
		
		public function UpdateInfo():void {
			StartFrame = MyCritter.AnimationFrameCounts[currentAnimationID];
			EndFrame = MyCritter.AnimationFrameCounts[currentAnimationID+1];
			
			if (CurrentFrame < StartFrame || CurrentFrame >= EndFrame) CurrentFrame = StartFrame;
			
			FrameRect.x = (CurrentFrame % MyCritter.AnimationsPerRow) * myBitmapData.width;
			FrameRect.y = (CurrentFrame / MyCritter.AnimationsPerRow) * myBitmapData.height;
			
			myBitmapData.copyPixels(sprites, FrameRect, Global.ZeroPoint);
		}
		
		public function SetPlaybackSpeed(speed:Number):void {
			CurrentPlaybackSpeed = speed;
		}
		
		public function UpdateAnimation(dt:Number):void {
			if (CurrentPlaybackSpeed == 0) return;
			
			FrameDT += dt;
			
			while (FrameDT >= CurrentPlaybackSpeed) {
				FrameDT -= CurrentPlaybackSpeed;
				CurrentFrame++;
				
				if (CurrentFrame >= EndFrame) {
					if(CurrentAnimationLooping) {
						CurrentFrame = StartFrame;
					} else {
						CurrentFrame = EndFrame-1;
						Owner.MyScript.Run(Script.AnimationEnded);
					}
				}
				
				FrameRect.x = (CurrentFrame % MyCritter.AnimationsPerRow) * myBitmapData.width;
				FrameRect.y = int(CurrentFrame / MyCritter.AnimationsPerRow) * myBitmapData.height;
				
				myBitmapData.copyPixels(sprites, FrameRect, Global.ZeroPoint);
			}
		}
		
		public function CurrentAnim():int {
			return currentAnimationID;
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
		
		public function GetPlaybackSpeed():Number {
			return CurrentPlaybackSpeed;
		}
	}
}