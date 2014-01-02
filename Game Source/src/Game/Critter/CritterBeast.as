package Game.Critter {
	import Game.Map.MapData;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterBeast extends BaseCritter {
		public var BeastInfo:CritterInfoBeast;
		public var Animation:CritterAnimationSet;
		
		public function CritterBeast(MyInfo:CritterInfoBeast, map:MapData, x:int, y:int, REFID:int) {
			super(REFID, MyInfo);
			
			BeastInfo = MyInfo;
			
			Animation = new CritterAnimationSet(this);
			Animation.ChangeState(0, true);
			Main.OrderedLayer.addChild(Animation);
			
			CurrentMap = map;
			PrimaryFaction = MyInfo.MyFactions[0];
			
			X = x;
			Y = y;
			
			MyRect.W = MyInfo.CollisionWidth;
			MyRect.H = MyInfo.CollisionHeight;
			
			CurrentHP = MyInfo.Health;
			MaximumHP = MyInfo.Health;
			CurrentDefence = MyInfo.Defence;
			
			MovementSpeed = MyInfo.MovementSpeed;
			SetAlertRangeSqrd(MyInfo.AlertRange * MyInfo.AlertRange);
			AttackRange = MyInfo.AttackRange * MyInfo.AttackRange;
			
			MyScript = new ScriptInstance(BeastInfo.AICommands, this, false);
			MyScript.Run(Script.Initialize);
			MyAIType = BeastInfo.AIType;
			
			CheckScriptRegions();
		}
		
		public override function Update(dt:Number):void {
			var _d:int = direction;
			
			super.Update(dt);
			
			if (_d != direction) {
				Animation.ChangeDirection(direction);
			}
			
			if (direction < 2) { //Left or right
				Animation.x = int(X) - BeastInfo.SpriteWidth / 2 + (direction==0?-BeastInfo.CollisionOffsetX:BeastInfo.CollisionOffsetX);
			} else {
				Animation.x = int(X) - BeastInfo.SpriteWidth / 2;
			}
			
			Animation.y = int(Y) - BeastInfo.SpriteHeight + MyRect.H / 2 + BeastInfo.CollisionOffsetY;
			
			miniPanel.x = (int(X) - 32) - Animation.x;
			miniPanel.y = (int(Y) - BeastInfo.HeadHeight - 16) - Animation.y;
			
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
			Animation.SetPlaybackSpeed(newAnimationSpeed);
			Animation.UpdateAnimation(newAnimationSpeed);
		}
		
		override public function GetAnimationSpeed():Number {
			return Animation.GetPlaybackSpeed();
		}
		
		override public function RequestBasicAttack():void {
			if (!ControlsLocked) MyScript.Run(Script.Attack);
		}
		
		public function toString():String {
			if(BeastInfo != null) {
				return "[Critter>Beast>" + BeastInfo.Name + " Faction=" + PrimaryFaction + "]";
			} else {
				return "[Critter>DELETED]";
			}
		}
		
		override public function CleanUp():void {
			if (BeastInfo == null) return;
			if (Persistent) return;
			super.CleanUp();
			
			if(Animation != null) {
				Animation.CleanUp();
				Animation = null;
			}
			
			BeastInfo = null;
		}
	}
}