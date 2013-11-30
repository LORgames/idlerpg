package QDMF.Logic {
	import EngineTiming.IUpdatable;
	/**
	 * ...
	 * @author ...
	 */
	public class Syncronizer implements IUpdatable {
		public var CurrentTurn:int = 0;
		public var TurnTime:Number = 250; //milliseconds between turns
		
		public var UpcomingTurns:Vector.<Turn> = new Vector.<Turn>(5, true);
		public var MSSinceLastTurn:int = 0;
		
		public function Syncronizer() {
			
		}
		
		public function Update(dt:Number):void {
			
		}
	}
}