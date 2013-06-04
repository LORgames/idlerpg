package Game.Critter {
	import Game.Equipment.EquipmentSet;
	import Game.Map.MapData;
	import Game.Map.WorldData;
	import Interfaces.IUpdatable;
	import RenderSystem.Camera;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterHuman extends BaseCritter {
		public var Equipment:EquipmentSet;
		
		public function CritterHuman() {
			Equipment = new EquipmentSet(this);
			
			Main.OrderedLayer.addChild(Equipment);
			Main.Updatables.push(this);
			
			MyRect.W = 24;
			MyRect.H = 12;
		}
		
		public override function Update(dt:Number):void {
			super.Update(dt);
			
			Equipment.x = this.X;
			Equipment.y = this.Y;
		}
		
		override public function RequestMove(xSpeed:Number, ySpeed:Number):void {
			var _d:int = direction;
			var _m:Boolean = isMoving;
			
			super.RequestMove(xSpeed, ySpeed);
			
			if (_d != direction) {
				Equipment.ChangeDirection(direction);
			}
			
			if (_m != isMoving) {
				if (isMoving) {
					Equipment.ChangeState(1, 0);
				} else {
					Equipment.ChangeState(0, 1);
				}
			}
		}
		
		override public function RequestBasicAttack():void {
			if (!ControlsLocked) Equipment.ChangeState(2, 0);
		}
		
	}

}