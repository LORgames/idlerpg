package Game.Critter 
{
	import Game.Equipment.EquipmentSet;
	/**
	 * ...
	 * @author Paul
	 */
	public class Person extends BaseCritter {
		public var equipment:EquipmentSet = new EquipmentSet();
		
		public function Person() {
			Main.OrderedLayer.addChild(equipment);
		}
		
		override public function UpdatePosition():void {
			super.UpdatePosition();
			equipment.x = this.X + 24;
			equipment.y = this.Y + 24;
		}
		
		override public function RequestMove(moveDir:int):void {
			equipment.ChangeDirection(moveDir);
			super.RequestMove(moveDir);
		}
		
	}

}