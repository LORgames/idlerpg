package Game.Critter 
{
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
	public class Person extends BaseCritter {
		public var equipment:EquipmentSet;
		
		public function Person() {
			equipment = new EquipmentSet(this);
			
			Main.OrderedLayer.addChild(equipment);
			Main.Updatables.push(this);
			
			MyRect.width = 24;
			MyRect.height = 12;
		}
		
		public override function Update(dt:Number):void {
			super.Update(dt);
			
			equipment.x = this.X;
			equipment.y = this.Y;
			
			//Need to make sure there is a map for more advanced checks
			if (CurrentMap == null) return;
			
			//Check to see if this object can portal
			if(CurrentMap.Portals != null) {
				var j:int = CurrentMap.Portals.length;
				while (--j > -1) {
					if (CurrentMap.Portals[j].Entry.intersects(MyRect)) {
						var exitID:int = CurrentMap.Portals[j].ExitID;
						if (WorldData.ME.CurrentMap.Name == WorldData.PortalDestinations[exitID]) {
							var k:int = CurrentMap.Portals.length;
							while (--k > -1) {
								if (CurrentMap.Portals[j].ExitID == CurrentMap.Portals[k].ID) {
									Global.MapPortalID = k;
									Main.I.Renderer.FadeToBlack(RequestInMapTeleport);
								}
							}
							break;
						} else {
							Global.MapPortalID = exitID;
							Main.I.Renderer.FadeToBlack(WorldData.UpdatePlayerPosition);
						}
						break;
					}
				}
			}
		}
		
		override public function RequestMove(xSpeed:Number, ySpeed:Number):void {
			var _d:int = direction;
			var _m:Boolean = isMoving;
			
			super.RequestMove(xSpeed, ySpeed);
			
			if (_d != direction) {
				equipment.ChangeDirection(direction);
			}
			
			if (_m != isMoving) {
				if (isMoving) {
					equipment.ChangeState(1, 0);
				} else {
					equipment.ChangeState(0, 1);
				}
			}
		}
		
		override public function RequestBasicAttack():void {
			equipment.ChangeState(2, 0);
		}
		
	}

}