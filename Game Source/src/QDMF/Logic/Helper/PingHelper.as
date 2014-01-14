package QDMF.Logic.Helper {
	import flash.utils.getTimer;
	import QDMF.Logic.Syncronizer;
	import QDMF.Packet;
	import QDMF.PacketTypes;
	/**
	 * ...
	 * @author ...
	 */
	public class PingHelper {
		private static var CurrentPingID:int = 0;
		private static var ActivePingTime:int = 0;
		
		private static var _TotalPingTime:int = 0;
		private static var _TotalPings:int = 0;
		
		public static function DoPing():void {
			if (Global.Network == null) return;
			if (ActivePingTime != 0) return;
			
			CurrentPingID++;
			ActivePingTime = getTimer();
			
			if (!Global.Network) {
				Syncronizer.Ping = 0;
				return;
			}
			
			var p:Packet = new Packet(PacketTypes.PING);
			p.bytes.writeByte(Global.CurrentPlayerID);
			p.bytes.writeInt(CurrentPingID);
			
			Global.Network.SendPacketImmediate(p);
		}
		
		public static function PingReply(id:int):void {
			if (id != CurrentPingID) return;
			
			_TotalPingTime += (getTimer() - ActivePingTime);
			_TotalPings++;
			
			Syncronizer.Ping = _TotalPingTime/_TotalPings;// getTimer() - ActivePingTime;
			
			ActivePingTime = 0;
		}
		
		static public function Reset():void {
			ActivePingTime = 0;
			_TotalPingTime = 0;
			_TotalPings = 0;
		}
	}
}