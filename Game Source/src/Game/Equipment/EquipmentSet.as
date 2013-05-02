package Game.Equipment {
	import flash.display.Sprite;
	import flash.geom.Point;
	import Interfaces.IObjectLayer;
	import RenderSystem.IAnimated;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentSet extends Sprite implements IObjectLayer {
		public var Shadow:EquipmentItem = new EquipmentItem();
		public var Legs:EquipmentItem = new EquipmentItem();
		public var Body1:EquipmentItem = new EquipmentItem();
		public var Body2:EquipmentItem = new EquipmentItem();
		public var Face:EquipmentItem = new EquipmentItem();
		public var Headgear:EquipmentItem = new EquipmentItem();
		public var Weapon1:EquipmentItem = new EquipmentItem();
		public var Weapon2:EquipmentItem = new EquipmentItem();
		
		public var Direction:int = 0;
		
		public function EquipmentSet() {
			this.addChild(Shadow);
			this.addChild(Weapon2);
			this.addChild(Legs);
			this.addChild(Body2);
			this.addChild(Face);
			this.addChild(Body1);
			this.addChild(Headgear);
			this.addChild(Weapon1);
		}
		
		public function UpdateSet():void {
            //The linking offsets
			Shadow.Offset(Direction);
            var p_offset:Point = Legs.Offset(Direction);
            var b_offset:Point = Body1.Offset(Direction);
            var f_offset:Point = Face.Offset(Direction);
            var w_offset:Point = Weapon1.Offset(Direction);
            var h_offset:Point = Headgear.Offset(Direction);
			
			Shadow.SetDirection(Direction);
			Legs.SetDirection(Direction);
			Body1.SetDirection(Direction);
			Body2.SetDirection(Direction);
			Headgear.SetDirection(Direction);
			Face.SetDirection(Direction);
			Weapon1.SetDirection(Direction);
			Weapon2.SetDirection(Direction);
			
            //The centers
            var shadowCenter:Point = Shadow.GetCenter();
            var pantsCenter:Point = Legs.GetCenter();
            var bodyCenter:Point = Body1.GetCenter();
            var faceCenter:Point = Face.GetCenter();
            var headCenter:Point = Headgear.GetCenter();
            var weaponCenter:Point = Weapon1.GetCenter();
			
            var WaistHeight:int = -p_offset.x;
			
            //Calculate shadow position
            Shadow.x = -shadowCenter.x;
            Shadow.y = -shadowCenter.y;
			
            //Calculate pants position
            Legs.x = - pantsCenter.x;
            Legs.y = + p_offset.y;
			
            //Solve body position
            Body1.x = - bodyCenter.x - b_offset.x;
            Body1.y = WaistHeight - b_offset.y - bodyCenter.y;
			
            //Solve body position
            Body2.x = Body1.x;
            Body2.y = Body1.y;
			
            //Solve head position
            Face.x = - f_offset.x - faceCenter.x;
            Face.y = WaistHeight - f_offset.y - faceCenter.y;
			
			//Solve headgear if possible
            Headgear.x = - h_offset.x - headCenter.x;
            Headgear.y = WaistHeight - h_offset.y - headCenter.y;
			
            //Solve weapon if possible
            Weapon1.x = - w_offset.x - weaponCenter.x;
            Weapon1.y = WaistHeight - w_offset.y - weaponCenter.y;
			
            Weapon2.x = Weapon1.x;
            Weapon2.y = Weapon1.y;
		}
		
		public function ChangeDirection(newDirection:int):void {
			if (Direction == 3 && newDirection != 3) {
				this.swapChildren(Body1, Headgear);
			} else if (Direction != 3 && newDirection == 3) {
				this.swapChildren(Body1, Headgear);
			}
			
			Direction = newDirection;
			UpdateSet();
		}
		
		public function ChangeState(newState:int, fromState:int):void {
			if ((newState == 1 && fromState == 0) || (newState == 0 && fromState == 1)) { //Walking
				Legs.SetState(newState);
			} else if (newState == 2) { //Attacking
				Weapon1.SetState(newState, false);
				Weapon2.SetState(newState, false);
			}
		}
		
		public function Equip(shadowID:int, pantsID:int, bodyID:int, faceID:int, headgearID:int, weaponID:int):void {
			Shadow.SetInformation(EquipmentManager.I.Shadows[shadowID]);
			Legs.SetInformation(EquipmentManager.I.Legs[pantsID]);
			Body1.SetInformation(EquipmentManager.I.Bodies[bodyID]);
			Body2.SetInformation(EquipmentManager.I.Bodies[bodyID], 1);
			Face.SetInformation(EquipmentManager.I.Heads[faceID]);
			Headgear.SetInformation(EquipmentManager.I.Headgear[headgearID]);
			Weapon1.SetInformation(EquipmentManager.I.Weapons[weaponID]);
			Weapon2.SetInformation(EquipmentManager.I.Weapons[weaponID], 1);
			
			ChangeDirection(3);
		}
		
		public function GetTrueY():int {
			return this.y;
		}
	}

}