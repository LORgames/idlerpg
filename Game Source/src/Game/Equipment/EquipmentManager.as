package Game.Equipment {
	import adobe.utils.CustomActions;
	import flash.geom.Point;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import Game.General.Script;
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
			//The equipment is packed into one file but is grouped by equipment type
			//This order is the order in the file, it works up the body (except weapons that are last)
			
			//First we need to read in how many of each type of weapon exist
			Shadows = new Vector.<EquipmentInfo>(b.readShort(), true);
			Legs = new Vector.<EquipmentInfo>(b.readShort(), true);
			Bodies = new Vector.<EquipmentInfo>(b.readShort(), true);
			Heads = new Vector.<EquipmentInfo>(b.readShort(), true);
			Headgear = new Vector.<EquipmentInfo>(b.readShort(), true);
			Weapons = new Vector.<EquipmentInfo>(b.readShort(), true);
			
			var i:int = 0;
			
			//Now we read in the actual information for each type of equipment
			i = Shadows.length; while ( --i > -1) ReadEquipmentInfo(b, Shadows, Shadows.length - (i+1));
			i = Legs.length; while ( --i > -1) ReadEquipmentInfo(b, Legs, Legs.length - (i+1));
			i = Bodies.length; while ( --i > -1) ReadEquipmentInfo(b, Bodies, Bodies.length - (i+1));
			i = Heads.length; while ( --i > -1) ReadEquipmentInfo(b, Heads, Heads.length - (i+1));
			i = Headgear.length; while ( --i > -1) ReadEquipmentInfo(b, Headgear, Headgear.length - (i+1));
			i = Weapons.length; while ( --i > -1) ReadEquipmentInfo(b, Weapons, Weapons.length - (i+1));
			
			//Then for some reason we set the player equipment up..?
			WorldData.ME.Equipment.Equip(0, 1, 2, 3, 5, 5);
			
			//And reset the loading total while some images load
			Global.LoadingTotal--;
		}
		
		public function ReadEquipmentInfo(b:ByteArray, v:Vector.<EquipmentInfo>, index:int):void {
			var e:EquipmentInfo = new EquipmentInfo();
			
			//Read the name
			e.Name = BinaryLoader.GetString(b);
			
			//Process some bools. To save app size, compressed as 1 byte rather than seperate ones
			var bool:int = b.readByte();
			e.isAvailableAtStart = (bool & 0x1) > 0;
			e.OffsetsLocked = (bool & 0x2) > 0;
			
			//Equipment must be animated at one speed, this is the speed reading.
			e.AnimationSpeed = b.readFloat();
			
			//Read in the animation set
			e.Offset = new Point(b.readShort(), b.readShort());
			
			//If the offsets are locked, copy the one set otherwise read the other sets in
			if (e.OffsetsLocked) {
				e.Offset_1 = e.Offset;
				e.Offset_2 = e.Offset;
				e.Offset_3 = e.Offset;
			} else {
				e.Offset_1 = new Point(b.readShort(), b.readShort());
				e.Offset_2 = new Point(b.readShort(), b.readShort());
				e.Offset_3 = new Point(b.readShort(), b.readShort());
			}
			
			//Read in the script
			e.MyScript = Script.ReadScript(b);
			
			//What size is each frame?
			e.SizeX = b.readByte();
			e.SizeY = b.readByte();
			
			//Calculate the center point of the frame
			e.Center = new Point(e.SizeX / 2, e.SizeY / 2);
			
			//Read in the animation frame counts (4bit snippets for each direction and layer (32bits per state)
			var totalStates:int = b.readByte();
			
			e.FrameCounts = new Vector.<int>(totalStates, true);
			e.SpriteSheetYOffsets = new Vector.<int>(totalStates * 8, true); //4 directions per state, 2 layers per state = x8
			
			while(--totalStates > -1) {
				e.FrameCounts[totalStates] = b.readInt();
			}
			
			//Figure out where each layer is on the spritesheet
			e.ProcessSpriteSheetOffsets();
			
			//Now save it in the vector
			v[index] = e;
		}
		
	}

}