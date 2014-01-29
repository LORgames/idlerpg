package QDMF.Logic {
	import adobe.utils.CustomActions;
	/**
	 * ...
	 * @author ...
	 */
	public class Turn {
		//TODO: This needs to be changed if we have more players
		public var PlayerTurns_1:Vector.<TurnStep>;
		public var PlayerTurns_2:Vector.<TurnStep>;
		public var PlayerReady:Vector.<Boolean> = new Vector.<Boolean>(2, true); 
		
		public var isComplete:Boolean = false;		//Has the commands from all players been received
		
		
		public function Turn() {
			PlayerTurns_1 = new Vector.<TurnStep>();
			PlayerTurns_2 = new Vector.<TurnStep>();
		}
		
		public function Execute():void {
			var step:TurnStep;
			
			while(PlayerTurns_1.length > 0) {
				step = PlayerTurns_1.pop();
				step.Execute();
			}
			
			while(PlayerTurns_2.length > 0) {
				step = PlayerTurns_2.pop();
				step.Execute();
			}
		}
		
		public function AddStep(step:TurnStep):void {
			if(step.PlayerID == 1) {
				PlayerTurns_1.push(step);
			} else if (step.PlayerID == 2) {
				PlayerTurns_2.push(step);
			}
		}
		
		public function CompletedBy(playerID:int):void {
			if (playerID == 1) {
				PlayerReady[0] = true;
			} else if (playerID == 2) {
				PlayerReady[1] = true;
			}
			
			if (Global.Network) {
				isComplete = PlayerReady[0] && PlayerReady[1];
			} else {
				isComplete = true;
			}
		}
		
		public function ResetReady():void {
			isComplete = false;
			PlayerReady[0] = false;
			PlayerReady[1] = false;
			
			while(PlayerTurns_1.length > 0) { PlayerTurns_1.pop(); }
			while(PlayerTurns_2.length > 0) { PlayerTurns_2.pop(); }
		}
	}
}