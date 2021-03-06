package Game.Critter {
	import Game.Equipment.EquipmentSet;
	import Game.Map.MapData;
	import Game.Map.WorldData;
	import RenderSystem.Camera;
	import RenderSystem.Renderman;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterHuman extends BaseCritter {
		public var Equipment:EquipmentSet;
		
		public function CritterHuman(x:int, y:int, REFID:int, info:CritterInfoBase) {
			super(REFID, info);
			
			Equipment = new EquipmentSet(this);
			
			Main.OrderedLayer.addChild(Equipment);
			
			MyRect.W = 24;
			MyRect.H = 12;
			MyRect.X = x-12;
			MyRect.Y = y-6;
			
			this.X = x;
			this.Y = y;
		}
		
		public override function Update(dt:Number):void {
			var _d:int = direction;
			
			super.Update(dt);
			
			if (_d != direction) {
				Equipment.ChangeDirection(direction);
			}
			
			Equipment.x = this.X;
			Equipment.y = this.Y;
			
			Renderman.DirtyObjects.push(Equipment);
 		}
		
		override public function RequestMove(xSpeed:Number, ySpeed:Number, move:Boolean = true):void {
			var _m:Boolean = isMoving;
			var _d:int = direction;
			
			super.RequestMove(xSpeed, ySpeed, move);
			
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
		
		public function toString():String {
			return "[Critter>Humanoid>" + Info.Name+ " Faction=" + PrimaryFaction + "]";
		}
		
		public override function CleanUp():void {
			if (Persistent) return;
			
			if(Equipment != null) {
				Equipment.CleanUp();
				Equipment = null;
			}
			
			super.CleanUp();
		}
		
	}

}