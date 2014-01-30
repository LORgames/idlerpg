package QDMF.Logic {
	import adobe.utils.CustomActions;
	import EngineTiming.Clock;
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
		public var TurnTime:Number = 0.20; 	//seconds between turns
		
		private static const CACHED_TURNS:int = 10;		//How many turns do we cache in the system.
		private static const LOCAL_WITH_AHEAD:int = 5;	//How many turns in the future are things issued?
		
		public static var Ping:int = 0;
		public var UpcomingTurns:Vector.<Turn> = new Vector.<Turn>(CACHED_TURNS, true);
		public var MSSinceLastTurn:Number = 0;
		
		protected static var I:Syncronizer;
		
		public function Syncronizer() {
			I = this;
			var i:int;
			
			for (i = 0; i < CACHED_TURNS; i++) {
				UpcomingTurns[i] = new Turn();
			}
			
			for (i = 0; i < LOCAL_WITH_AHEAD; i++) {
				UpcomingTurns[i].isComplete = true;
			}
		}
		
		private var _pauseUntilNetwork:Boolean = false;
		public function Update(dt:Number):void {
			MSSinceLastTurn += dt;
			
			if (MSSinceLastTurn > TurnTime) {
				if (!UpcomingTurns[0].isComplete) {
					_pauseUntilNetwork = true;
					Clock.Stop();
					Global.Out.Log("Have not received completion message for TurnID=" + (CurrentTurn + 1));
					return;
				}
				
				if (_pauseUntilNetwork) {
					_pauseUntilNetwork = false;
					Clock.Resume();
				}
				
				if (Global.Network) {
					var p:Packet = new Packet(PacketTypes.ENDTURN);
					p.bytes.writeShort(Global.CurrentPlayerID);
					p.bytes.writeShort(I.CurrentTurn + LOCAL_WITH_AHEAD);
					//Global.Out.Log("Marked turn " + (I.CurrentTurn + LOCAL_WITH_AHEAD) + " complete.");
					Global.Network.SendPacket(p);
					Global.Network.Flush();
				}
				
				MSSinceLastTurn -= TurnTime;
				CurrentTurn = CurrentTurn + 1;
				
				UpcomingTurns[LOCAL_WITH_AHEAD - 1].CompletedBy(Global.CurrentPlayerID);
				var _currentTurn:Turn = UpcomingTurns[0];
				_currentTurn.Execute();
				
				for (var i:int = 0; i < CACHED_TURNS-1; i++) {
					UpcomingTurns[i] = UpcomingTurns[i + 1];
				}
				
				UpcomingTurns[CACHED_TURNS - 1] = _currentTurn;
				_currentTurn.ResetReady();
				
				PingHelper.DoPing();
			}
		}
		
		/**
		 * Registers a step coming in from a local event/script.
		 * Steps coming in through this NEED TO BE SYNCRONIZED!
		 * @param	step	The step that will be executed
		 */
		static public function RegisterLocalStep(step:TurnStep):void {
			step.Data.position = 0;
			I.UpcomingTurns[LOCAL_WITH_AHEAD-1].AddStep(step);
			
			if (Global.Network) {
				var b:ByteArray = step.Pack(I.CurrentTurn + LOCAL_WITH_AHEAD);
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
				Global.Out.Log("CATASTROPHIC DESYNC! MY-TURN="+I.CurrentTurn+" THIER-TURN="+turnID+" TIME=" + new Date().toString());
			} else {
				Global.Out.Log("Received some info for turnid=" + turnID + " from player=" + step.PlayerID);
				var _turn:int = turnID - I.CurrentTurn - 1;
				I.UpcomingTurns[_turn].AddStep(step);
			}
		}
		
		static public function Update(dt:Number):void {
			if (I != null) I.Update(dt);
		}
		
		static public function Reset(_offset:Number = 0):void {
			I.CurrentTurn = 0;
			I.MSSinceLastTurn = _offset;
			
			var i:int;
			
			for (i = 0; i < CACHED_TURNS; i++) {
				I.UpcomingTurns[i].ResetReady();
			}
			
			for (i = 0; i < LOCAL_WITH_AHEAD-1; i++) {
				I.UpcomingTurns[i].CompletedBy(1); //TODO: This really isn't the best solution.
				I.UpcomingTurns[i].CompletedBy(2);
			}
		}
		
		static public function MarkTurnEnded(playerID:int, turnID:int):void {
			//Global.Out.Log("Marking turnID=" + turnID + " ended for player=" + playerID); 
			
			var _turn:int = turnID - I.CurrentTurn - 1;
			I.UpcomingTurns[_turn].CompletedBy(playerID);
			Update(0);
		}
	}
}