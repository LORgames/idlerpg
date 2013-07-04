package Game.Effects {
	import CollisionSystem.Rect;
	import flash.display.Sprite;
	import flash.geom.Rectangle;
	import Interfaces.IMapObject;
	import RenderSystem.IAnimated;
	import RenderSystem.IObjectLayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class EffectInstance extends Sprite implements IMapObject, IAnimated, IObjectLayer {
		public var MyRect:Rect;
		public var Info:EffectInfo;
		
		public var StartFrame:int = 0;
		public var EndFrame:int = 0;
		public var CurrentFrame:int = 0;
		private var FrameTimeout:Number = 0;
		public var PlaybackSpeed:Number = 0;
		public var CopyRect:Rectangle = new Rectangle();
		public var IsLooping:Boolean = true;
		
		public function EffectInstance(info:EffectInfo) {
			this.Info = info;
			
			CopyRect.width = Info.FrameWidth;
			CopyRect.height = Info.FrameHeight;
			
			Main.OrderedLayer.addChild(this);
			MyRect = new Rect(true, this, Info.X, Info.Y, Info.W, info.H);
			Renderman.AnimatedObjectsPush(this);
		}
		
		/* INTERFACE Interfaces.IMapObject */
		
		public function GetUnion():Rect {
			return MyRect;
		}
		
		public function HasPerfectCollision(other:Rect):Boolean {
			return other.intersects(MyRect);
		}
		
		public function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IMapObject):void {
			//Does nothing at this stage
		}
		
		/* INTERFACE RenderSystem.IAnimated */
		
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
							Info.MyScript.Run(Script.AnimationEnded, this);
							return;
						}
					}
				}
				
				CopyRect.x = CurrentFrame * CopyRect.width;
				
				if(Template.SpriteAtlas != null) {
					this.bitmapData.copyPixels(Info.SpriteAtlas, CopyRect, Global.ZeroPoint);
				}
			}
		}
		
		/* INTERFACE RenderSystem.IObjectLayer */
		
		public function GetTrueY():int {
			return this.Y;
		}
		
	}

}