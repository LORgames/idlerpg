package Game.Equipment {
	import CollisionSystem.Rect;
	import flash.display.Sprite;
	import flash.geom.Point;
	import Game.Critter.CritterHuman;
	import Scripting.Script;
	import RenderSystem.IObjectLayer;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentSet extends Sprite implements IObjectLayer {
		public var Shadow:EquipmentItem;
		public var Legs:EquipmentItem;
		public var Body:EquipmentItem;
		public var Face:EquipmentItem;
		public var Headgear:EquipmentItem;
		public var Weapon:EquipmentItem;
		
		public var Owner:CritterHuman;
		
		public var Direction:int = 0;
		
		public function EquipmentSet(owner:CritterHuman) {
			this.Owner = owner;
			
			Shadow = new EquipmentItem(this);
			Legs = new EquipmentItem(this);
			Body = new EquipmentItem(this, true);
			Face = new EquipmentItem(this);
			Headgear = new EquipmentItem(this);
			Weapon = new EquipmentItem(this, true);
			
			this.addChild(Shadow.Layer);
			this.addChild(Weapon.Layer2);
			this.addChild(Legs.Layer);
			this.addChild(Body.Layer2);
			this.addChild(Face.Layer);
			this.addChild(Body.Layer);
			this.addChild(Headgear.Layer);
			this.addChild(Weapon.Layer);
		}
		
		public function UpdateSet():void {
            //The linking offsets
			Shadow.Offset(Direction);
            var p_offset:Point = Legs.Offset(Direction);
            var b_offset:Point = Body.Offset(Direction);
            var f_offset:Point = Face.Offset(Direction);
            var w_offset:Point = Weapon.Offset(Direction);
            var h_offset:Point = Headgear.Offset(Direction);
			
			Shadow.SetDirection(Direction);
			Legs.SetDirection(Direction);
			Body.SetDirection(Direction);
			Headgear.SetDirection(Direction);
			Face.SetDirection(Direction);
			Weapon.SetDirection(Direction);
			
            //The centers
            var shadowCenter:Point = Shadow.GetCenter();
            var pantsCenter:Point = Legs.GetCenter();
            var bodyCenter:Point = Body.GetCenter();
            var faceCenter:Point = Face.GetCenter();
            var headCenter:Point = Headgear.GetCenter();
            var weaponCenter:Point = Weapon.GetCenter();
			
            var WaistHeight:int = -p_offset.x;
			
            //Calculate shadow position
            Shadow.Layer.x = -shadowCenter.x;
            Shadow.Layer.y = -shadowCenter.y;
			
            //Calculate pants position
            Legs.Layer.x = - pantsCenter.x;
            Legs.Layer.y = + p_offset.y;
			
            //Solve body position
            Body.Layer.x = - bodyCenter.x - b_offset.x;
            Body.Layer.y = WaistHeight - b_offset.y - bodyCenter.y;
			
			Body.Layer2.x = Body.Layer.x;
			Body.Layer2.y = Body.Layer.y;
			
            //Solve head position
            Face.Layer.x = - f_offset.x - faceCenter.x;
            Face.Layer.y = WaistHeight - f_offset.y - faceCenter.y;
			
			//Solve headgear if possible
            Headgear.Layer.x = - h_offset.x - headCenter.x;
            Headgear.Layer.y = WaistHeight - h_offset.y - headCenter.y;
			
            //Solve weapon if possible
            Weapon.Layer.x = - w_offset.x - weaponCenter.x;
            Weapon.Layer.y = WaistHeight - w_offset.y - weaponCenter.y;
			
            Weapon.Layer2.x = Weapon.Layer.x;
            Weapon.Layer2.y = Weapon.Layer.y;
		}
		
		public function ChangeDirection(newDirection:int):void {
			if (Direction == 3 && newDirection != 3) {
				this.swapChildren(Body.Layer, Headgear.Layer);
			} else if (Direction != 3 && newDirection == 3) {
				this.swapChildren(Body.Layer, Headgear.Layer);
			}
			
			Direction = newDirection;
			UpdateSet();
		}
		
		public function ChangeState(newState:int, fromState:int):void {
			if ((newState == 1 && fromState == 0) || (newState == 0 && fromState == 1)) { //Walking
				//Legs.ChangeState(newState);
			} else if (newState == 2) { //Attacking
				Face.MyScript.Run(Script.Attack);
				Headgear.MyScript.Run(Script.Attack);
				Body.MyScript.Run(Script.Attack);
				Legs.MyScript.Run(Script.Attack);
				Shadow.MyScript.Run(Script.Attack);
				Weapon.MyScript.Run(Script.Attack);
			}
		}
		
		public function Equip(shadowID:int, pantsID:int, bodyID:int, faceID:int, headgearID:int, weaponID:int):void {
			Shadow.SetInformation(EquipmentManager.I.Shadows[shadowID]);
			Legs.SetInformation(EquipmentManager.I.Legs[pantsID]);
			Body.SetInformation(EquipmentManager.I.Bodies[bodyID]);
			Face.SetInformation(EquipmentManager.I.Heads[faceID]);
			Headgear.SetInformation(EquipmentManager.I.Headgear[headgearID]);
			Weapon.SetInformation(EquipmentManager.I.Weapons[weaponID]);
			
			ChangeDirection(3);
		}
		
		public function EquipSlot(slotID:uint, equipmentID:uint):void {
			switch (slotID) {
				case 0: //Shadow
					if(EquipmentManager.I.Shadows.length > equipmentID) {
						Shadow.SetInformation(EquipmentManager.I.Shadows[equipmentID]);
						Shadow.MyScript.Run(Script.Equip);
					} break;
				case 1: //Legs
					if(EquipmentManager.I.Legs.length > equipmentID) {
						Legs.SetInformation(EquipmentManager.I.Legs[equipmentID]);
						Legs.MyScript.Run(Script.Equip);
					} break;
				case 2: //Body
					if(EquipmentManager.I.Bodies.length > equipmentID) {
						Body.SetInformation(EquipmentManager.I.Bodies[equipmentID]);
						Body.MyScript.Run(Script.Equip);
					} break;
				case 3: //Face
					if(EquipmentManager.I.Heads.length > equipmentID) {
						Face.SetInformation(EquipmentManager.I.Heads[equipmentID]);
						Face.MyScript.Run(Script.Equip);
					} break;
				case 4: //Headgear
					if(EquipmentManager.I.Headgear.length > equipmentID) {
						Headgear.SetInformation(EquipmentManager.I.Headgear[equipmentID]);
						Headgear.MyScript.Run(Script.Equip);
					} break;
				case 5: //Weapon
					if(EquipmentManager.I.Weapons.length > equipmentID) {
						Weapon.SetInformation(EquipmentManager.I.Weapons[equipmentID]);
						Weapon.MyScript.Run(Script.Equip);
					} break;
			}
			
			UpdateSet();
		}
		
		public function GetTrueY():int {
			return this.y;
		}
		
		public function CleanUp():void {
			Owner = null;
			
			this.removeChild(Shadow.Layer);
			this.removeChild(Weapon.Layer2);
			this.removeChild(Legs.Layer);
			this.removeChild(Body.Layer2);
			this.removeChild(Face.Layer);
			this.removeChild(Body.Layer);
			this.removeChild(Headgear.Layer);
			this.removeChild(Weapon.Layer);
			
			Shadow.CleanUp();
			Legs.CleanUp();
			Body.CleanUp();
			Face.CleanUp();
			Headgear.CleanUp();
			Weapon.CleanUp();
			
			Shadow = null;
			Legs = null;
			Body = null;
			Face = null;
			Headgear = null;
			Weapon = null;
			
			if (this.parent != null) {
				this.parent.removeChild(this);
			}
		}
		
		public function IsEquipped(slotID:uint, itemID:uint):Boolean {
			switch (slotID) {
				case 0: //Shadow
					return (Shadow.Info.ID == itemID);
				case 1: //Legs
					return (Legs.Info.ID == itemID);
				case 2: //Body
					return (Body.Info.ID == itemID);
				case 3: //Face
					return (Face.Info.ID == itemID);
				case 4: //Headgear
					return (Headgear.Info.ID == itemID);
				case 5: //Weapon
					return (Weapon.Info.ID == itemID);
			}
			
			return false;
		}
	}

}