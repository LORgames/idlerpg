package Game.Critter 
{
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	import Loaders.ImageLoader;
	import Scripting.Script;
	import Game.Map.MapData;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterInfoBeast extends CritterInfoBase {
		
		public var PlaybackSpeed:Number;
		public var TotalAnimationStates:int;
		
		public var SpriteWidth:int;
		public var SpriteHeight:int;
		public var CollisionWidth:int;
		public var CollisionHeight:int;
		public var CollisionOffsetX:int;
		public var CollisionOffsetY:int;
		public var HeadHeight:int;
		
		public var AnimationFrameCounts:Vector.<int>;
		public var AnimationsPerRow:int = 0;
		
		//Sprite sheet things
		private var MySpriteSheet:BitmapData;
		private var SpriteSheetWidth:int;
		private var SpriteSheetHeight:int;
		private var TotalUses:int = 0; //How many critters are currently using this spritesheet
		
		public function CritterInfoBeast(b:ByteArray, critterID:int) {
			ID = critterID;
			
			LoadBasicInfo(b);
			
			PlaybackSpeed = b.readFloat();
			
			CollisionWidth = b.readShort();
			CollisionHeight = b.readShort();
			CollisionOffsetX = b.readShort();
			CollisionOffsetY = b.readShort();
			HeadHeight = b.readShort();
			
			TotalAnimationStates = b.readByte();
			
			var TotalFrames:int = b.readByte();
			
			//Each animation has frame information for all 4 directions (just in case really), has 1 more for the total size as the last one for [i+1] checking later
			AnimationFrameCounts = new Vector.<int>(TotalAnimationStates * 4 + 1, true);
			
			var currentStateIndex:int = TotalAnimationStates * 4;
			AnimationFrameCounts[currentStateIndex] = TotalFrames;
			
			while (--currentStateIndex > -1) {
				TotalFrames -= b.readShort();
				AnimationFrameCounts[currentStateIndex] = TotalFrames;
			}
			
			SpriteSheetWidth = b.readUnsignedShort();
			SpriteSheetHeight = b.readUnsignedShort();
			SpriteWidth = b.readUnsignedShort();
			SpriteHeight = b.readUnsignedShort();
			
			AnimationsPerRow = SpriteSheetWidth / SpriteWidth;
			
			GetSprites();
		}
		
		override public function CreateCritter(map:MapData, x:int, y:int, isSimulated:Boolean = true, _id:int = -1):BaseCritter {
			var ID:int = _id;
			
			if (ID == -1) { ID = map.GetCritterID(isSimulated); }
			if (ID == -1) { Global.Out.Log("Critter Overflow!"); return null; }
			
			var p:CritterBeast = new CritterBeast(this, map, x, y, ID);
			p.Update(0);
			
			map.Critters[ID] = p;
			return p;
		}
		
		public function GetSprites():BitmapData {
			TotalUses++;
			
			if (MySpriteSheet == null) {
				MySpriteSheet = new BitmapData(SpriteSheetWidth, SpriteSheetHeight, true, (Global.DebugRender)?0x40FF0080:0x00FFFFFF);
				ImageLoader.Load("Data/Critter_" + ID + ".png", LoadedSpriteSheet);
			}
			
			return MySpriteSheet;
		}
		
		public function OneLessInstance():void {
			TotalUses--;
			
			//Can we unload this spritesheet?
			if (TotalUses == 0) {
				//TODO: This is supposed to dispose but due to budget cuts and retardedness had to comment it out. Therefore the texture is in memory forever. FOREVER!
				//MySpriteSheet.dispose();
				//MySpriteSheet = null;
			}
		}
		
		public function LoadedSpriteSheet(e:BitmapData):void {
			if (MySpriteSheet == null) {
				MySpriteSheet = new BitmapData(SpriteSheetWidth, SpriteSheetHeight, true, 0x40FF00FF);
			}
			
			MySpriteSheet.copyPixels(e, e.rect, Global.ZeroPoint);
		}
		
	}

}