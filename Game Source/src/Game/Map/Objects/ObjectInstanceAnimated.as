package Game.Map.Objects {
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import Game.Map.MapData;
	import Interfaces.IMapObject;
	import RenderSystem.IAnimated;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class ObjectInstanceAnimated extends ObjectInstance implements IAnimated {
		public var HasLoaded:Boolean = false;
		public var StartFrame:int = 0;
		public var EndFrame:int = 0;
		public var CurrentFrame:int = 0;
		public var CurrentState:int = 0;
		
		private var isAddedToAnimatedList:Boolean = false;
		private var FrameTimeout:Number = 0;
		public var PlaybackSpeed:Number = 0;
		
		public var CopyRect:Rectangle = new Rectangle();
		public var IsLooping:Boolean = true;
		
		public function ObjectInstanceAnimated(_REFID:int) {
			super(_REFID);
			Renderman.DirtyObjects.push(this);
		}
		
		override public function SetInformation(map:MapData, id:int, _x:int, _y:int):void {
			super.SetInformation(map, id, _x, _y);
			
			CopyRect.x = 0;
			CopyRect.y = 0;
			CopyRect.width = Template.FrameSize.width;
			CopyRect.height = Template.FrameSize.height;
			
			ChangeState(0, true);
		}
		
		override public function CleanUp():void {
			super.CleanUp();
			
			if (isAddedToAnimatedList) {
				Renderman.AnimatedObjectsRemove(this);
				isAddedToAnimatedList = false;
			}
			
			if(Template == null) {
				this.bitmapData.dispose();
			}
			
			if(MyScript != null) {
				MyScript.CleanUp();
				MyScript = null;
			}
		}
		
		private function UpdateAnimationState():void {
			if (!isAddedToAnimatedList && EndFrame-StartFrame > 1) {
				Renderman.AnimatedObjectsPush(this);
				isAddedToAnimatedList = true;
				
				if (!HasLoaded) {
					if (this.bitmapData == null) this.bitmapData = new BitmapData(this.Template.FrameSize.width, this.Template.FrameSize.height);
					this.bitmapData = this.bitmapData.clone();
					HasLoaded = true;
				}
			} else if (isAddedToAnimatedList && EndFrame-StartFrame < 2) {
				Renderman.AnimatedObjectsRemove(this);
				isAddedToAnimatedList = false;
			}
		}
		
		public function UpdateAnimation(dt:Number):void {
			FrameTimeout += dt;
			
			if (FrameTimeout > PlaybackSpeed) {
				while(FrameTimeout > PlaybackSpeed) {
					FrameTimeout -= PlaybackSpeed;
					CurrentFrame++;
					
					if(CurrentFrame == EndFrame) {
						if(IsLooping) {
							CurrentFrame = StartFrame;
						} else {
							StartFrame = EndFrame-1;
							CurrentFrame = StartFrame;
							UpdateAnimationState();
							
							MyScript.Run(Script.AnimationEnded);
						}
					}
				}
				
				CopyRect.x = (int)(CurrentFrame % Template.SpriteColumns) * CopyRect.width;
				CopyRect.y = (int)(CurrentFrame / Template.SpriteColumns) * CopyRect.height;
				
				if(Template.SpriteAtlas != null) {
					this.bitmapData.copyPixels(Template.SpriteAtlas, CopyRect, Global.ZeroPoint);
				}
			}
		}
		
		override public function ScriptAttack(isPercent:Boolean, amount:int, pierce:int, attacker:IScriptTarget):void {
			MyScript.Run(Script.Attacked, attacker);
		}
		
		override public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			PlaybackSpeed = newAnimationSpeed;
		}
		
		override public function GetAnimationSpeed():Number { return PlaybackSpeed; }
		
		override public function ChangeState(stateID:int, isLooping:Boolean):void {
			CurrentState = stateID;
			PlaybackSpeed = Template.PlaybackSpeed[stateID];
			StartFrame = Template.TotalFrames[stateID];
			EndFrame = Template.TotalFrames[stateID + 1]-1;
			
			UpdateAnimationState();
			
			IsLooping = isLooping;
			
			CurrentFrame = StartFrame;
			
			CopyRect.x = (int)(CurrentFrame % Template.SpriteColumns) * CopyRect.width;
			CopyRect.y = (int)(CurrentFrame / Template.SpriteColumns) * CopyRect.height;
			
			if(Template.SpriteAtlas != null) {
				this.bitmapData.copyPixels(Template.SpriteAtlas, CopyRect, Global.ZeroPoint);
			}
		}
		
		override public function GetCurrentState():int {
			return CurrentState;
		}
	}
}