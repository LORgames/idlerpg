package QDMF.Logic {
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Critter.CritterManager;
	import Game.Map.WorldData;
	import Scripting.IScriptTarget;
	/**
	 * ...
	 * @author ...
	 */
	public class TurnStep {
		public var RandomSeed:int = 0;
		
		public var PlayerID:int = 0;
		public var Type:int = 0;
		public var Action:int = 0;
		public var TypeID:int = 0;
		
		public var Data:ByteArray = null;
		
		public static const CRITTER:int = 0;
		public static const EFFECTS:int = 1;
		public static const VARABLE:int = 2;
		public static const OBJECTS:int = 3;
		public static const UNKNOWN:int = 255;
		
		public static const CREATE:int = 0;
		public static const UPDATE:int = 1;
		public static const DELETE:int = 2;
		public static const VERIFY:int = 3;
		
		public function TurnStep(playerID:int, type:int, action:int, typeid:int, additionaldata:ByteArray, seed:int = 0) {
			PlayerID = playerID;
			Action = action;
			Data = additionaldata;
			RandomSeed = seed;
			TypeID = typeid;
		}
		
		public function CleanUp():void {
			PlayerID = 0;
			Action = 0;
			if (Data) Data.clear();
			Data = null;
			TypeID = 0;
			
			RandomSeed = 0;
		}
		
		public function Execute():void {
			Rndm.seed = RandomSeed;
			
			if (Type == CRITTER && Action == CREATE) CreateCritter();
			else if (Type == EFFECTS && Action == CREATE) CreateEffects();
			else
				throw new Error("Uh oh spagettio!");
		}
		
		private function CreateCritter():void {
			var id:int = Data.readShort();
			var xpos:int = Data.readShort();
			var ypos:int = Data.readShort();
			var faction:int = Data.readShort();
			
			var ownertype:int = Data.readByte();
			var ownerID:int = Data.readShort();
			
			var object:IScriptTarget = GetObject(ownertype, ownerID);
			
			var critter:BaseCritter = CritterManager.I.CritterInfo[id].CreateCritter(WorldData.CurrentMap, xpos, ypos, false, TypeID);
			
			if(faction != -1) { // Get owner faction?
				critter.SetFaction(faction);
			}
			
			critter.SetOwner(object);
		}
		
		private function CreateEffects():void {
			//TODO: this
		}
		
		private function GetObject(ownertype:int, ownerID:int):IScriptTarget {
			if (ownertype == CRITTER) {
				return WorldData.CurrentMap.Critters[ownerID];
			} else if (ownertype == EFFECTS) {
				return WorldData.CurrentMap.Effects[ownerID];
			} else if (ownertype == OBJECTS) {
				return WorldData.CurrentMap.Objects[ownerID];
			}
			
			return null;
		}
		
		public function Pack(turnID:int):ByteArray {
			var b:ByteArray = new ByteArray();
			
			b.writeShort(turnID);
			b.writeByte(PlayerID);
			b.writeByte(Type);
			b.writeByte(Action);
			b.writeByte(TypeID);
			b.writeInt(RandomSeed);
			b.writeShort(Data.length);
			b.writeBytes(Data);
			
			return b;
		}
		
		public static function UnpackAndRegister(b:ByteArray):void {
			var turnID:int = b.readShort();
			
			var playerID:int = b.readUnsignedByte();
			var type:int = b.readUnsignedByte();
			var action:int = b.readUnsignedByte();
			var typeid:int = b.readUnsignedByte();
			var seed:int = b.readInt();
			var additionaldatalength:int = b.readShort();
			
			var additionaldata:ByteArray = new ByteArray();
			b.readBytes(additionaldata, 0, additionaldatalength);
			
			var t:TurnStep = new TurnStep(playerID, type, action, typeid, additionaldata, seed);
			
			Syncronizer.RegisterRemoteStep(turnID, t);
		}
	}
}