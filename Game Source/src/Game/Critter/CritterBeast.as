package Game.Critter 
{
	import Game.Equipment.EquipmentSet;
	import Game.General.Script;
	import Game.Map.MapData;
	import Game.Map.WorldData;
	import Interfaces.IUpdatable;
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
			
			Main.OrderedLayer.addChild(Animation);
			Main.Updatables.push(this);
			
			MyRect.W = MyInfo.CollisionWidth;
			MyRect.H = MyInfo.CollisionHeight;
			MyRect.HalfWidth = MyRect.W * 0.5;
			MyRect.HalfHeight = MyRect.H * 0.5;
		}
		
		public override function Update(dt:Number):void {
			super.Update(dt);
			
			Animation.x = this.X - Animation.width/2;
			Animation.y = this.Y - Animation.height;
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
		
	}

}