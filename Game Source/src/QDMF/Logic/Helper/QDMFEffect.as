package QDMF.Logic.Helper {
	import flash.utils.ByteArray;
	import Game.Map.MapData;
	import Game.Map.WorldData;
	import QDMF.Logic.Syncronizer;
	import QDMF.Logic.TurnStep;
	/**
	 * ...
	 * @author ...
	 */
	public class QDMFEffect {
		public static function Register(EffectID:int, xPos:int, yPos:int, direction:int):void {
			var slotID:int = WorldData.CurrentMap.GetCritterID(false);
			
			var bytes:ByteArray = new ByteArray();
			bytes.writeShort(EffectID);
			bytes.writeShort(xPos);
			bytes.writeShort(yPos);
			bytes.writeShort(direction);
			
			var retVal:TurnStep = new TurnStep(Global.CurrentPlayerID, TurnStep.EFFECTS, TurnStep.CREATE, slotID, bytes, Math.random()*int.MAX_VALUE);
			Syncronizer.RegisterLocalStep(retVal);
		}
	}
}