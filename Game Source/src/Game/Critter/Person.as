package Game.Critter 
{
	import Game.Equipment.EquipmentSet;
	import Game.Map.WorldData;
	import RenderSystem.Camera;
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
			
			if (this == WorldData.ME) {
				Camera.X = -this.X + Main.I.stage.stageWidth/2;
				Camera.Y = -this.Y + Main.I.stage.stageHeight/2;
				Main.OrderedLayer.x = Camera.X;
				Main.OrderedLayer.y = Camera.Y;
			}
		}
		
		override public function RequestMove(moveDir:int):void {
			equipment.ChangeDirection(moveDir);
			super.RequestMove(moveDir);
		}
		
	}

}