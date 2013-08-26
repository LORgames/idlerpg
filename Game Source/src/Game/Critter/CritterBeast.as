package Game.Critter {
	import Game.Equipment.EquipmentSet;
	import Game.Scripting.Script;
	import Game.Map.MapData;
	import Game.Map.WorldData;
	import Game.Scripting.ScriptInstance;
	import Interfaces.IMapObject;
	import RenderSystem.Camera;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterBeast extends BaseCritter {
		public var Info:CritterInfoBeast;
		public var Animation:CritterAnimationSet;
		
		public function CritterBeast(MyInfo:CritterInfoBeast, map:MapData, x:int, y:int) {
			Info = MyInfo;
			
			Animation = new CritterAnimationSet(this);
			Animation.ChangeState(0, true);
			Main.OrderedLayer.addChild(Animation);
			
			CurrentMap = map;
			
			X = x;
			Y = y;
			
			MyRect.W = MyInfo.CollisionWidth;
			MyRect.H = MyInfo.CollisionHeight;
			
			CurrentHP = MyInfo.Health;
			
			MovementSpeed = MyInfo.MovementSpeed;
			AlertRange = MyInfo.AlertRange*MyInfo.AlertRange;
			
			MyScript = new ScriptInstance(Info.AICommands, this, false);
			MyScript.Run(Script.Initialize);
			MyAIType = Info.AIType;
		}
		
		public override function Update(dt:Number):void {
			var _d:int = direction;
			
			super.Update(dt);
			
			if (_d != direction) {
				Animation.ChangeDirection(direction);
			}
			
			Animation.x = this.X - Animation.width/2;
			Animation.y = this.Y - Animation.height + MyRect.H / 2 + Info.CollisionOffsetY;
			
			Renderman.DirtyObjects.push(Animation);
		}
		
		override public function RequestMove(xSpeed:Number, ySpeed:Number, move:Boolean = true):void {
			var _d:int = direction;
			var _m:Boolean = isMoving;
			
			super.RequestMove(xSpeed, ySpeed, move);
				
			if (_d != direction) {
				Animation.ChangeDirection(direction);
			}
			
			if (_m != isMoving) {
				if (isMoving) {
					MyScript.Run(Script.StartMoving);
				} else {
					MyScript.Run(Script.EndMoving);
				}
			}
		}
		
		override public function ChangeState(stateID:int, isLooping:Boolean):void {
			Animation.ChangeState(stateID, isLooping);
		}
		
		override public function GetCurrentState():int {
			return Animation.CurrentAnim();
		}
		
		override public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			Animation.UpdateAnimation(newAnimationSpeed);
		}
		
		override public function RequestBasicAttack():void {
			if (!ControlsLocked) MyScript.Run(Script.Attack);
		}
		
		public function toString():String {
			return "[Critter:" + Info.Name + "]";
		}
		
		override public function CleanUp():void {
			if (Persistent) return;
			super.CleanUp();
			
			if(Animation != null) {
				Animation.CleanUp();
				Animation = null;
			}
			
			Info = null;
		}
	}
}