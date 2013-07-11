package Game.Effects {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import EngineTiming.Clock;
	import EngineTiming.ICleanUp;
	import EngineTiming.IUpdatable;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Rectangle;
	import flash.geom.Vector3D;
	import Game.Scripting.Script;
	import Game.Map.WorldData;
	import Game.Scripting.ScriptTypes;
	import Interfaces.IMapObject;
	import RenderSystem.IAnimated;
	import RenderSystem.IObjectLayer;
	import RenderSystem.Renderman;
	import EngineTiming.IUpdatable
	/**
	 * ...
	 * @author Paul
	 */
	public class EffectInstance extends Bitmap implements IMapObject, IAnimated, IObjectLayer, IUpdatable, ICleanUp {
		public var MyRect:Rect;
		public var Info:EffectInfo;
		public var Direction:int = 0;
		
		public var X:int = 0;
		public var Y:int = 0;
		
		public var StartFrame:int = 0;
		public var EndFrame:int = 0;
		public var CurrentFrame:int = 0;
		private var FrameTimeout:Number = 0;
		public var PlaybackSpeed:Number = 0;
		public var CopyRect:Rectangle = new Rectangle();
		public var IsLooping:Boolean = true;
		
		private var MyLife:int = 0;
		
		public function EffectInstance(info:EffectInfo, x:int, y:int, d:int) {
			this.Info = info;
			
			CopyRect.width = Info.FrameWidth;
			CopyRect.height = Info.FrameHeight;
			
			X = x;
			Y = y;
			
			this.bitmapData = new BitmapData(Info.FrameWidth, Info.FrameHeight, true, 0x40FF0000);
			
			this.Direction = d;
			Main.OrderedLayer.addChild(this);
			MyRect = new Rect(true, this, X-Info.W/2, y-Info.H/2, Info.W, info.H);
			Renderman.AnimatedObjectsPush(this);
			
			this.PlaybackSpeed = 0.2;
			ChangeState(0, true);
			
			Clock.I.Updatables.push(this);
			
			Info.MyScript.Run(Script.Spawn, this, this);
			WorldData.CurrentMap.Effects.push(this);
			
			MyLife = Info.Life;
		}
		
		public function ChangeState(animationIndex:int, loop:Boolean):void {
			this.StartFrame = Info.AnimationFrames[animationIndex];
			this.EndFrame = Info.AnimationFrames[animationIndex + 1];
			this.CurrentFrame = this.StartFrame;
			this.IsLooping = loop;
			
			CopyRect.x = int(CurrentFrame % Info.SpriteColumns) * CopyRect.width;
			CopyRect.y = int(CurrentFrame / Info.SpriteColumns) * CopyRect.height;
			
			if(Info.SpriteAtlas != null) {
				this.bitmapData.copyPixels(Info.SpriteAtlas, CopyRect, Global.ZeroPoint);
			}
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
			
			if (FrameTimeout >= PlaybackSpeed) {
				if (PlaybackSpeed > 0) {
					while(FrameTimeout >= PlaybackSpeed) {
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
				}
				
				CopyRect.x = int(CurrentFrame % Info.SpriteColumns) * CopyRect.width;
				CopyRect.y = int(CurrentFrame / Info.SpriteColumns) * CopyRect.height;
				
				if(Info.SpriteAtlas != null) {
					this.bitmapData.copyPixels(Info.SpriteAtlas, CopyRect, Global.ZeroPoint);
				}
			}
		}
		
		/* INTERFACE RenderSystem.IObjectLayer */
		
		public function GetTrueY():int {
			return this.Y;
		}
		
		/* INTERFACE EngineTiming.IUpdatable */
		
		public function Update(dt:Number):void {
			if (Info.MovementSpeed != 0) {
				switch(Direction) {
					case 0:
						X -= Info.MovementSpeed * dt;
						break;
					case 1:
						X += Info.MovementSpeed * dt;
						break;
					case 2:
						Y -= Info.MovementSpeed * dt;
						break;
					case 3:
						Y += Info.MovementSpeed * dt;
						break;
				}
			}
			
			this.x = X - Info.FrameWidth * 0.5;
			this.y = Y - Info.FrameHeight;
			
			MyRect.X = X - MyRect.W * 0.5;
			MyRect.Y = Y - MyRect.H * 0.5;
			
			Renderman.DirtyObjects.push(this);
			
			if (!WorldData.CurrentMap.Boundaries.ContainsPoint(X, Y)) {
				Clock.CleanUpList.push(this);
			} else {
				//Do some world scans?
				var objects:Vector.<IMapObject> = new Vector.<IMapObject>();
				WorldData.CurrentMap.GetObjectsInArea(MyRect, objects, ScriptTypes.NotMe, this);
				
				var i:int = objects.length;
				while (--i > -1) {
					if (Info.IsSolid) {
						Info.MyScript.Run(Script.EndMoving, this);
					} else {
						
					}
				}
				
				if (MyLife > 0) {
					trace(MyLife);
					
					MyLife -= dt;
					if (MyLife <= 0) {
						Clock.CleanUpList.push(this);
					}
				}
			}
		}
		
		/* INTERFACE EngineTiming.ICleanUp */
		
		public function CleanUp():void {
			if (MyRect != null) {
				Drawer.AddDebugRect(MyRect);
			}
			
			this.bitmapData.dispose();
			
			MyRect = null;
			Info = null;
			CopyRect = null;
			
			if(this.parent) Main.OrderedLayer.removeChild(this);
			Renderman.AnimatedObjectsRemove(this);
			Clock.I.Remove(this);
			WorldData.CurrentMap.EffectPop(this);
		}
	}
}