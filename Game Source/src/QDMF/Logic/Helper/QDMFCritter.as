package QDMF.Logic.Helper {
	import flash.utils.ByteArray;
	import Game.Critter.BaseCritter;
	import Game.Effects.EffectInfo;
	import Game.Effects.EffectInstance;
	import Game.Map.Objects.ObjectInstance;
	import Game.Map.WorldData;
	import QDMF.Logic.Syncronizer;
	import QDMF.Logic.TurnStep;
	/**
	 * ...
	 * @author ...
	 */
	public class QDMFCritter {
		public static function Register(CritterID:int, xPos:int, yPos:int, faction:int, owner:Object):void {
			var slotID:int = WorldData.CurrentMap.GetCritterID(false);
			trace("NEXT CRITTER=" + slotID);
			
			var bytes:ByteArray = new ByteArray();
			bytes.writeShort(CritterID);
			bytes.writeShort(xPos);
			bytes.writeShort(yPos);
			bytes.writeShort(faction);
			
			if (owner is ObjectInstance) {
				bytes.writeByte(TurnStep.OBJECTS);
				bytes.writeShort((owner as ObjectInstance).GetID());
			} else if (owner is EffectInstance) {
				bytes.writeByte(TurnStep.EFFECTS);
				bytes.writeShort((owner as EffectInstance).GetID());
			} else if (owner is BaseCritter) {
				bytes.writeByte(TurnStep.CRITTER);
				bytes.writeShort((owner as BaseCritter).GetID());
			} else {
				bytes.writeByte(TurnStep.UNKNOWN);
				bytes.writeShort(0);
			}
			
			var retVal:TurnStep = new TurnStep(Global.CurrentPlayerID, TurnStep.CRITTER, TurnStep.CREATE, slotID, bytes, Math.random()*int.MAX_VALUE);
			Syncronizer.RegisterLocalStep(retVal);
		}
	}
}