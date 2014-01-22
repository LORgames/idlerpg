package QDMF {
	/**
	 * ...
	 * @author Paul
	 */
	public interface IPacketProcessor {
		/**
		 * Allows the processor to process incoming packets.
		 * @param	p	The packet to process
		 * @return	True if this packet was processed, false otherwise.
		 */
		function ProcessPacket(p:Packet):Boolean;
		function Disconnect():void;
	}

}