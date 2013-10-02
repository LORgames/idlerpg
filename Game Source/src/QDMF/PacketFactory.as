package QDMF 
{
	/**
	 * ...
	 * @author Paul
	 */
	public class PacketFactory {
		private static var p:Packet = new Packet(7);
		
		public static function N(x:Vector.<int>):void {
			var p:Packet = new Packet(7);
			
			for (var i:int = 0; i < x.length; i++) {
				p.bytes.writeShort(x[i]);
			}
			
			p.bytes.writeShort(0xFFFF);
			
			Global.Network.SendPacket(p);
			p.bytes.clear();
			p.bytes.writeShort(7);
		}
	}

}