package QDMF.Logic {
	import adobe.utils.CustomActions;
	/**
	 * ...
	 * @author ...
	 */
	public class Turn {
		public var PlayerTurns:Vector.<TurnStep>;	
		public var isComplete:Boolean = false;		//Has the commands from all players been received
		
		public function Turn() {
			PlayerTurns = new Vector.<TurnStep>();
		}
		
		public function Execute():void {
			while(PlayerTurns.length > 0) {
				var step:TurnStep = PlayerTurns.pop();
				step.Execute();
			}
		}
		
		public function AddStep(step:TurnStep):void {
			PlayerTurns.push(step);
			isComplete = true;
		}
	}
}