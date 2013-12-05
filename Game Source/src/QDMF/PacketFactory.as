package QDMF 
{
	/**
	 * ...
	 * @author Paul
	 */
	public class PacketFactory {
		private static var p:Packet = new Packet(PacketTypes.SCRIPT);
		
		public static function N(x:Vector.<int>):void {
			//var p:Packet = new Packet(Packet.TYPE_SCRIPT);
			
			for (var i:int = 0; i < x.length; i++) {
				p.bytes.writeShort(x[i]);
			}
			
			p.bytes.writeShort(0xFFFF);
			
			Global.Network.SendPacket(p);
			p.bytes.clear();
			p.bytes.writeShort(PacketTypes.SCRIPT);
		}
		
		public static function UpdateSyncStart():void {
			
		}
	}

}