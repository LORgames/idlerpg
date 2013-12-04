package QDMF.Logic {
	import adobe.utils.CustomActions;
	import EngineTiming.IUpdatable;
	/**
	 * ...
	 * @author ...
	 */
	public class Syncronizer implements IUpdatable {
		public var CurrentTurn:int = 0;		//id for the current turn
		public var TurnTime:Number = 0.25; 	//seconds between turns
		
		private const CACHED_TURNS:int = 5;
		public var UpcomingTurns:Vector.<Turn> = new Vector.<Turn>(CACHED_TURNS, true);
		
		public var MSSinceLastTurn:Number = 0;
		
		protected static var I:Syncronizer;
		
		public function Syncronizer() {
			I = this;
			
			for (var i:int = 0; i < CACHED_TURNS; i++) {
				UpcomingTurns[i] = new Turn();
			}
		}
		
		public function Update(dt:Number):void {
			MSSinceLastTurn += dt;
			
			if (MSSinceLastTurn > TurnTime) {
				trace("Executing turn " + CurrentTurn);
				
				MSSinceLastTurn -= TurnTime;
				CurrentTurn = CurrentTurn + 1;
				
				var _currentTurn:Turn = UpcomingTurns[0];
				_currentTurn.Execute();
				
				for (var i:int = 0; i < CACHED_TURNS-1; i++) {
					UpcomingTurns[i] = UpcomingTurns[i + 1];
				}
				
				UpcomingTurns[CACHED_TURNS - 1] = _currentTurn;
			}
		}
		
		static public function RegisterStep(step:TurnStep):void {
			step.Data.position = 0;
			I.UpcomingTurns[2].AddStep(step);
		}
		
		static public function RemoteStepAdded(turnID:int, step:TurnStep):void {
			
		}
		
		static public function Update(dt:Number):void {
			if (I != null) I.Update(dt);
		}
	}
}