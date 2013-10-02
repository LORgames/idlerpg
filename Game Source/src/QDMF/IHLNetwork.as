package QDMF {
	import Debug.ILogger;
	/**
	 * Quick and Dirty Multiplayer Framework High-Level Network Interface
	 * @author Paul Fox
	 */
	public interface IHLNetwork {
		function Connect(Hostname:String, Pin:int, Logger:ILogger):void;
		function SendPacket(packet:Packet):Boolean;
		function IsConnected():Boolean;
		function Close():void;
	}
}