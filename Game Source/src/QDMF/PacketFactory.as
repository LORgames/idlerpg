package QDMF 
{
	import EngineTiming.Clock;
	/**
	 * ...
	 * @author Paul
	 */
	public class PacketFactory {
		private static var p:Packet = new Packet(PacketTypes.SCRIPT);
		
		public static function N(x:Vector.<int>):void {
			if (!Global.Network) return;
			
			for (var i:int = 0; i < x.length; i++) {
				p.bytes.writeShort(x[i]);
			}
			
			p.bytes.writeShort(0xFFFF);
			
			if(Clock.isRunning()) {
				Global.Network.SendPacket(p);
			} else {
				Global.Network.SendPacketImmediate(p);
			}
			p.bytes.clear();
			p.bytes.writeShort(PacketTypes.SCRIPT);
		}
		
		public static function UpdateSyncStart():void {
			
		}
	}

}