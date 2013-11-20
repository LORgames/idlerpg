package Game.Critter 
{
	import CollisionSystem.PointX;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterBuff : IScriptTarget {
		
		public var critter:BaseCritter;
		public var iconID:int = 0;
		public var myScript:ScriptInstance
		
		public function CritterBuff() {
			
		}
		
		public function ApplyToCritter(buffID:int, critter:BaseCritter):void {
			myScript = new ScriptInstance(CritterManager.I.CritterBuffs[buffID]._Script, this, true);
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		
		public function UpdatePointX(position:PointX):void {
			critter.UpdatePointX(position);
		}
		
		public function AlertMinionDeath(baseCritter:BaseCritter):void {
			myScript.Run(Script.MinionDied, null, baseCritter);
		}
		
		public function ChangeState(stateID:int, isLooping:Boolean):void {
			critter.ChangeState(stateID, isLooping);
		}
		
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			critter.UpdatePlaybackSpeed(newAnimationSpeed);
		}
		
		public function GetCurrentState():int {
			return critter.GetCurrentState();
		}
		
		public function GetFaction():int {
			return critter.GetFaction();
		}
	}
}