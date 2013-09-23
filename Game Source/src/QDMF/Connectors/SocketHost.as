package QDMF.Connectors {
	import adobe.utils.CustomActions;
	import Debug.ILogger;
	import flash.events.Event;
	import flash.events.ProgressEvent;
	import flash.events.ServerSocketConnectEvent;
	import flash.net.ServerSocket;
	import flash.net.Socket;
	import flash.utils.ByteArray;
	import QDMF.IHLNetwork;
	import QDMF.Packet;
	/**
	 * ...
	 * @author Paul
	 */
	public class SocketHost implements IHLNetwork {
		private var HostSocket:ServerSocket;
		private var Client:Socket;
		private var Logger:ILogger;
		
		public function SocketHost() {
			HostSocket = new ServerSocket();
		}
		
		/* INTERFACE QDMF.IHLNetwork */
		
		public function Connect(Hostname:String, Pin:int, Logger:ILogger):void {
			this.Logger = Logger;
			
			//Does nothing :)
			HostSocket.bind(Pin, Hostname);
            HostSocket.addEventListener(ServerSocketConnectEvent.CONNECT, OnConnect );
            HostSocket.listen();
            Logger.Log("Your pin is: " + (HostSocket.localPort*13-1456));
		}
		
		private function OnConnect(e:ServerSocketConnectEvent):void {
			Client = e.socket;
            Client.addEventListener(ProgressEvent.SOCKET_DATA, SocketDataHandler);
            Logger.Log("Connection from " + Client.remoteAddress + ":" + Client.remotePort);
		}
		
		private function SocketDataHandler(event:ProgressEvent):void {
			while (Client.bytesAvailable > 1) {
				Packet.UnpackFromInput(Client);
			}
		}
		
		public function IsConnected():Boolean {
			return (Client != null && Client.connected);
		}
		
		public function SendPacket(packet:Packet):Boolean {
			if (Client != null) {
				try {
					Client.writeShort(packet.bytes.length);
					Client.writeBytes(packet.bytes);
					Client.flush();
					
					return true;
				} catch (error:Error) {
					Logger.Log("An unexpected error occurred: " + error.message);
				}
			}
			
			return false;
		}
		
	}

}