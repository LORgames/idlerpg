package QDMF.Logic {
	import adobe.utils.CustomActions;
	import EngineTiming.IUpdatable;
	import flash.utils.ByteArray;
	import QDMF.Logic.Helper.PingHelper;
	import QDMF.Packet;
	import QDMF.PacketFactory;
	import QDMF.PacketTypes;
	/**
	 * ...
	 * @author ...
	 */
	public class Syncronizer implements IUpdatable {
		public var CurrentTurn:int = 0;		//id for the current turn
		public var TurnTime:Number = 0.25; 	//seconds between turns
		
		private const CACHED_TURNS:int = 3;		//How many turns do we cache in the system.
		private const LOCAL_WITH_AHEAD:int = 1;	//How many turns in the future are things issued?
		
		public static var Ping:int = 0;
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
				MSSinceLastTurn -= TurnTime;
				CurrentTurn = CurrentTurn + 1;
				
				var _currentTurn:Turn = UpcomingTurns[0];
				_currentTurn.Execute();
				
				for (var i:int = 0; i < CACHED_TURNS-1; i++) {
					UpcomingTurns[i] = UpcomingTurns[i + 1];
				}
				
				UpcomingTurns[CACHED_TURNS - 1] = _currentTurn;
				
				if (CurrentTurn % CACHED_TURNS == 0) {
					PingHelper.DoPing();
				}
			}
		}
		
		/**
		 * Registers a step coming in from a local event/script.
		 * Steps coming in through this NEED TO BE SYNCRONIZED!
		 * @param	step	The step that will be executed
		 */
		static public function RegisterLocalStep(step:TurnStep):void {
			step.Data.position = 0;
			I.UpcomingTurns[2].AddStep(step);
			
			if (Global.Network) {
				var b:ByteArray = step.Pack(I.CurrentTurn + 3);
				var p:Packet = new Packet(PacketTypes.TURNSTEP);
				p.bytes.writeBytes(b);
				Global.Network.SendPacket(p);
			}
		}
		
		/**
		 * Registers a step coming in over the network
		 * @param	turnID	The turn that this step is expected to run
		 * @param	step	The step that will be executed
		 */
		static public function RegisterRemoteStep(turnID:int, step:TurnStep):void {
			if (turnID <= I.CurrentTurn) {
				trace("CATASTROPHIC DESYNC!");
			} else {
				var _turn:int = turnID - I.CurrentTurn - 1;
				I.UpcomingTurns[_turn].AddStep(step);
			}
		}
		
		static public function Update(dt:Number):void {
			if (I != null) I.Update(dt);
		}
	}
}