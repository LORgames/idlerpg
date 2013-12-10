package Game.Critter 
{
	import CollisionSystem.PointX;
	import EngineTiming.Clock;
	import EngineTiming.IUpdatable;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterBuff implements IScriptTarget, IUpdatable {
		public var critter:BaseCritter;
		public var myScript:ScriptInstance;
		public var info:CritterBuffInfo;
		
		public var duration:Number = 0;
		
		public function CritterBuff() {
			
		}
		
		public function ApplyToCritter(buffID:int, _critter:BaseCritter):void {
			this.critter = _critter;
			info = CritterManager.I.CritterBuffs[buffID];
			
			myScript = new ScriptInstance(info._Script, critter, true);
			
			duration = info.duration;
			
			if (duration > 0) {
				Clock.I.Updatables.push(this);
			}
		}
		
		public function CleanUp(removeFromCritter:Boolean = true):void {
			myScript.Run(Script.Died, critter);
			
			if (removeFromCritter) {
				critter.RemoveBuff(this);
			}
			
			if (info.duration > 0) {
				Clock.I.Remove(this);
			}
			
			critter = null;
			myScript.CleanUp();
			
			info = null;
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		public function GetScript():ScriptInstance {
			return myScript;
		}
		
		public function UpdatePointX(position:PointX):void {
			critter.UpdatePointX(position);
		}
		
		public function AlertMinionDeath(baseCritter:BaseCritter):void {
			myScript.Run(Script.MinionDied, null, baseCritter);
		}
		
		public function ChangeState(stateID:int, isLooping:Boolean):void {
			//critter.ChangeState(stateID, isLooping);
			Main.I.Log("Buff trying to change state. NP HARD " + info.name);
		}
		
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			critter.UpdatePlaybackSpeed(newAnimationSpeed);
		}
		
		public function GetCurrentState():int {
			Main.I.Log("Buff trying to get state. NP HARD. Returning Critter state. " + info.name);
			return critter.GetCurrentState();
		}
		
		public function GetFaction():int {
			return critter.GetFaction();
		}
		
		/* INTERFACE EngineTiming.IUpdatable */
		
		public function Update(dt:Number):void {
			if (duration > 0) {
				duration -= dt;
				if (duration < 0) {
					CleanUp();
				}
			}
		}
	}
}