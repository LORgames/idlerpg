package Game.Critter {
	import Game.Equipment.EquipmentSet;
	import Game.General.Script;
	import Game.Map.MapData;
	import Game.Map.WorldData;
	import RenderSystem.Camera;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterBeast extends BaseCritter {
		public var Info:CritterInfoBeast;
		public var Animation:CritterAnimationSet;
		
		public function CritterBeast(MyInfo:CritterInfoBeast) {
			Info = MyInfo;
			
			Animation = new CritterAnimationSet(this);
			Animation.ChangeState(0);
			
			Main.OrderedLayer.addChild(Animation);
			
			MyRect.W = MyInfo.CollisionWidth;
			MyRect.H = MyInfo.CollisionHeight;
			
			CurrentHP = MyInfo.Health;
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
		
		override public function RequestMove(xSpeed:Number, ySpeed:Number):void {
			var _d:int = direction;
			var _m:Boolean = isMoving;
			
			super.RequestMove(xSpeed, ySpeed);
				
			if (_d != direction) {
				Animation.ChangeDirection(direction);
			}
			
			if (_m != isMoving) {
				if (isMoving) {
					MyScript.Run(Script.StartMoving, this);
				} else {
					MyScript.Run(Script.EndMoving, this);
				}
			}
		}
		
		override public function RequestBasicAttack():void {
			if (!ControlsLocked) MyScript.Run(Script.Attack, this);
		}
		
		public function toString():String {
			return "[" + Info.Name + "]";
		}
		
		override public function CleanUp():void {
			if (Persistent) return;
			super.CleanUp();
			
			Animation.CleanUp();
			Animation = null;
			
			Info = null;
		}
	}
}