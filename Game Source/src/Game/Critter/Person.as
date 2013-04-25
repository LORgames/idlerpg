package Game.Critter 
{
	import Game.Equipment.EquipmentSet;
	import Game.Map.WorldData;
	import Interfaces.IUpdatable;
	import RenderSystem.Camera;
	/**
	 * ...
	 * @author Paul
	 */
	public class Person extends BaseCritter {
		public var equipment:EquipmentSet = new EquipmentSet();
		
		public function Person() {
			Main.OrderedLayer.addChild(equipment);
			Main.Updatables.push(this);
			
			MyRect.width = 24;
			MyRect.height = 12;
		}
		
		public override function Update(dt:Number):void {
			super.Update(dt);
			equipment.x = this.X;
			equipment.y = this.Y;
		}
		
		override public function RequestMove(xSpeed:Number, ySpeed:Number):void {
			var _d:int = direction
			
			super.RequestMove(xSpeed, ySpeed);
			
			if (_d != direction) {
				equipment.ChangeDirection(direction);
			}
		}
		
		override public function RequestBasicAttack():void {
			equipment.ChangeState(2);
		}
		
	}

}