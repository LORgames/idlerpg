package Game.Critter 
{
	import flash.display.BitmapData;
	import flash.utils.ByteArray;
	import Game.Map.MapData;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterInfoBeast extends CritterInfoBase {
		
		public var playbackSpeed:Number;
		public var totalAnimation:int;
		
		public var AnimationPlaybackSpeeds:Vector.<int>;
		
		public function CritterInfoBeast(b:ByteArray) {
			LoadBasicInfo(b);
			
			playbackSpeed = b.readFloat();
			totalAnimation = b.readByte();
			
			//Each animation has frame information for all 4 directions (just in case really)
			AnimationPlaybackSpeeds = new Vector.<int>(totalAnimation * 4, true);
			
			var totalFrameCounts:int = totalAnimation * 4;
			
			while (--totalFrameCounts > -1) {
				AnimationPlaybackSpeeds[totalFrameCounts] = b.readShort();
			}
		}
		
		/*override public function CreateCritter(map:MapData, x:int, y:int):BaseCritter {
			var p:CritterHuman = new CritterHuman();
			
			p.Equipment.Equip(shadow, legs, body, face, headgear, weapon);
			
			p.CurrentMap = map;
			p.X = x;
			p.Y = y;
			
			p.Update(0);
			
			AICommands.Run(Script.Spawn, p);
			
			return p;
		}*/
		
	}

}