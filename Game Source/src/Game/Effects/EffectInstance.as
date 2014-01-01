package Game.Effects {
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import EngineTiming.Clock;
	import EngineTiming.ICleanUp;
	import EngineTiming.IUpdatable;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import Game.Critter.BaseCritter;
	import Game.Map.WorldData;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	import Scripting.ScriptTypes;
	import Interfaces.IMapObject;
	import RenderSystem.IAnimated;
	import RenderSystem.IObjectLayer;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class EffectInstance extends Bitmap implements IMapObject, IAnimated, IObjectLayer, IUpdatable, ICleanUp, IScriptTarget {
		public var MyRect:Rect;
		public var Info:EffectInfo;
		public var Direction:int = 0;
		public var MyScript:ScriptInstance;
		
		public var X:int = 0;
		public var Y:int = 0;
		
		public var OffsetX:int = 0;
		public var OffsetY:int = 0;
		
		public var CurrentState:int = 0;
		public var StartFrame:int = 0;
		public var EndFrame:int = 0;
		public var CurrentFrame:int = 0;
		private var FrameTimeout:Number = 0;
		public var PlaybackSpeed:Number = 0;
		public var CopyRect:Rectangle;
		public var IsLooping:Boolean = true;
		
		private var MyLife:int = 0;
		protected var ID:int;
		
		public function EffectInstance(_info:EffectInfo, _x:int, _y:int, _d:int, isSimulated:Boolean, _id:int = -1) {
 			ID = _id;
			if (ID == -1) {
				ID = WorldData.CurrentMap.GetEffectID(false);
			}
			
			this.Info = _info;
			
			OffsetX = Info.X;
			OffsetY = Info.Y;
			
			CopyRect = new Rectangle();
			CopyRect.width = Info.FrameWidth;
			CopyRect.height = Info.FrameHeight;
			
			X = _x;
			Y = _y;
			Direction = _d;
			
			this.bitmapData = new BitmapData(Info.FrameWidth, Info.FrameHeight, true, 0x40FF0000);
			
			Main.OrderedLayer.addChild(this);
			MyRect = new Rect(true, this, X-Info.W/2, Y-Info.H/2, Info.W, Info.H);
			Renderman.AnimatedObjectsPush(this);
			
			this.PlaybackSpeed = 0.2;
			ChangeState(0, true);
			
			Clock.I.RegisterUpdatable(this);
			
			MyScript = new ScriptInstance(Info.MyScript, this);
			WorldData.CurrentMap.Effects[ID] = this;
			
			MyLife = Info.Life;
			
			Update(0);
		}
		
		/* INTERFACE Interfaces.IMapObject */
		
		public function GetUnion():Rect {
			return MyRect;
		}
		
		public function HasPerfectCollision(other:Rect):Boolean {
			return other.intersects(MyRect);
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
								MyScript.Run(Script.AnimationEnded);
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
			
            //DrawPositionX = X - (Info.FrameWidth / 2) - Info.X;
            //DrawPositionY = Y - (Info.FrameHeight) + (Info.H/2) + Info.Y;
			
			this.x = X - Info.FrameWidth * 0.5 - OffsetX;
			this.y = Y - Info.FrameHeight + MyRect.H*0.5 + OffsetY;
			
			MyRect.X = X - MyRect.W * 0.5;
			MyRect.Y = Y - MyRect.H * 0.5;
			
			Renderman.DirtyObjects.push(this);
			
			if (!WorldData.CurrentMap.Boundaries.ContainsPoint(X, Y)) {
				Clock.CleanUpList.push(this);
			} else {
				//Do some world scans?
				var objects:Vector.<IScriptTarget> = new Vector.<IScriptTarget>();
				WorldData.CurrentMap.GetObjectsInArea(MyRect, objects, ScriptTypes.NotMe, this);
				
				var i:int = objects.length;
				while (--i > -1) {
					if (Info.IsSolid) {
						MyScript.Run(Script.EndMoving);
					} else {
						
					}
				}
				
				if (MyLife > 0) {
					MyLife -= dt;
					if (MyLife <= 0) {
						MyScript.Run(Script.Died);
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
			
			if(MyScript != null) {
				MyScript.CleanUp();
				MyScript = null;
			}
			
			if(this.parent) Main.OrderedLayer.removeChild(this);
			Renderman.AnimatedObjectsRemove(this);
			Clock.I.Remove(this);
			WorldData.CurrentMap.EffectPop(this);
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		public function GetScript():ScriptInstance {
			return MyScript;
		}
		
		public function ScriptAttack(isPercent:Boolean, amount:int, pierce:int, attacker:IScriptTarget):void { if (MyScript == null) return; MyScript.Run(Script.Attacked); }
		public function AlertMinionDeath(baseCritter:BaseCritter):void { MyScript.Run(Script.MinionDied); }
		public function UpdatePointX(position:PointX):void { position.X = X; position.Y = Y; position.D = Direction; }
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void { PlaybackSpeed = newAnimationSpeed; }
		public function GetAnimationSpeed():Number { return PlaybackSpeed; }
		
		public function ChangeState(animationIndex:int, loop:Boolean):void {
			CurrentState = animationIndex;
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
		
		public function GetCurrentState():int {
			return CurrentState;
		}
		
		public function GetFaction():int {
			return 0;
		}
		
		override public function toString():String {
			if (Info != null) return "[EffectInstance Type=" + Info.Name + " X=" +X + " Y=" + Y + "]";
			
			return "[EffectInstance NULL]";
		}
		
		public function GetID():int {
			return ID;
		}
		
	}
}