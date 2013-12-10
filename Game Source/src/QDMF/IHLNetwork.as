package QDMF {
	import Debug.ILogger;
	/**
	 * Quick and Dirty Multiplayer Framework High-Level Network Interface
	 * @author Paul Fox
	 */
	public interface IHLNetwork {
		/**
		 * Connect to the remote network
		 * @param	Hostname	The IP or DNS name of the remote system
		 * @param	Pin	The Port or PIN (for Bluetooth networking) of the remote system.
		 * @param	Logger	The logger system for this network
		 */
		function Connect(Hostname:String, Pin:int, Logger:ILogger):void;
		
		/**
		 * Queue the network to send in bulk. Most communications should be done via this method
		 * @param	packet	The packet to send
		 */
		function SendPacket(packet:Packet):void;
		
		/**
		 * Send a packet IMMEDIATELY over the network. This can easily screw up the buffered network so should only be used for time critical messages (e.g. pinging)
		 * @param	packet	The packet to send
		 */
		function SendPacketInstant(packet:Packet):void;
		
		/**
		 * Is the network even active?
		 * @return true if something is listening at the other end. NOTE: Matchmaking will report a false positive
		 */
		function IsConnected():Boolean;
		
		/**
		 * Send the buffered messages
		 */
		function Flush():void;
		
		/**
		 * Disconnect from the remote client
		 */
		function Close():void;
	}
}