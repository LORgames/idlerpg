package Game.Equipment {
	import adobe.utils.CustomActions;
	import flash.geom.Point;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import Game.Map.WorldData;
	/**
	 * ...
	 * @author Paul
	 */
	public class EquipmentManager {
		public var Shadows:Vector.<EquipmentInfo>;
		public var Legs:Vector.<EquipmentInfo>;
		public var Bodies:Vector.<EquipmentInfo>;
		public var Heads:Vector.<EquipmentInfo>;
		public var Headgear:Vector.<EquipmentInfo>;
		public var Weapons:Vector.<EquipmentInfo>;
		
		public static var I:EquipmentManager;
		
		public function EquipmentManager() {
			I = this;
			BinaryLoader.Load("Data/EquipmentInfo.bin", ParseEquipmentFile);
			Global.LoadingTotal++;
		}
		
		public function ParseEquipmentFile(b:ByteArray):void {
			Shadows = new Vector.<EquipmentInfo>(b.readShort(), true);
			Legs = new Vector.<EquipmentInfo>(b.readShort(), true);
			Bodies = new Vector.<EquipmentInfo>(b.readShort(), true);
			Heads = new Vector.<EquipmentInfo>(b.readShort(), true);
			Headgear = new Vector.<EquipmentInfo>(b.readShort(), true);
			Weapons = new Vector.<EquipmentInfo>(b.readShort(), true);
			
			var i:int = 0;
			
			i = Shadows.length; while ( --i > -1) ReadEquipmentInfo(b, Shadows, Shadows.length - (i+1));
			i = Legs.length; while ( --i > -1) ReadEquipmentInfo(b, Legs, Legs.length - (i+1));
			i = Bodies.length; while ( --i > -1) ReadEquipmentInfo(b, Bodies, Bodies.length - (i+1));
			i = Heads.length; while ( --i > -1) ReadEquipmentInfo(b, Heads, Heads.length - (i+1));
			i = Headgear.length; while ( --i > -1) ReadEquipmentInfo(b, Headgear, Headgear.length - (i+1));
			i = Weapons.length; while ( --i > -1) ReadEquipmentInfo(b, Weapons, Weapons.length - (i+1));
			
			WorldData.ME.equipment.Equip(0, 0, 0, 0, 1, 2);
			Global.LoadingTotal--;
		}
		
		public function ReadEquipmentInfo(b:ByteArray, v:Vector.<EquipmentInfo>, index:int):void {
			var e:EquipmentInfo = new EquipmentInfo();
			
			e.Name = BinaryLoader.GetString(b);
			
			var bool:int = b.readByte();
			e.isAvailableAtStart = (bool & 0x1) > 0;
			e.OffsetsLocked = (bool & 0x2) > 0;
			
			e.AnimationSpeed = b.readFloat();
			
			e.Offset = new Point(b.readShort(), b.readShort());
			
			if (e.OffsetsLocked) {
				e.Offset_1 = e.Offset;
				e.Offset_2 = e.Offset;
				e.Offset_3 = e.Offset;
			} else {
				e.Offset_1 = new Point(b.readShort(), b.readShort());
				e.Offset_2 = new Point(b.readShort(), b.readShort());
				e.Offset_3 = new Point(b.readShort(), b.readShort());
			}
			
			e.SizeX = b.readByte();
			e.SizeY = b.readByte();
			e.Center = new Point(e.SizeX / 2, e.SizeY / 2);
			
			e.Frames_Default = b.readInt();
			e.Frames_Walking = b.readInt();
			e.Frames_Attacking = b.readInt();
			e.Frames_Dancing = b.readInt();
			
			e.ProcessSpriteSheetOffsets();
			
			v[index] = e;
		}
		
	}

}