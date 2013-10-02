package QDMF.Connectors {
	import adobe.utils.CustomActions;
	import Debug.ILogger;
	import flash.events.Event;
	import flash.events.ProgressEvent;
	import flash.events.ServerSocketConnectEvent;
	import flash.net.ServerSocket;
	import flash.net.Socket;
	import flash.utils.ByteArray;
	import Game.Scripting.Script;
	import QDMF.IHLNetwork;
	import QDMF.Packet;
	import QDMF.SocketTriggers;
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
		
		public function Connect(Hostname:String, Port:int, Logger:ILogger):void {
			this.Logger = Logger;
			
			//Does nothing :)
			HostSocket.bind(Port, Hostname);
            HostSocket.addEventListener(ServerSocketConnectEvent.CONNECT, OnConnect );
            HostSocket.listen();
		}
		
		private function OnConnect(e:ServerSocketConnectEvent):void {
			Client = e.socket;
            Client.addEventListener(ProgressEvent.SOCKET_DATA, SocketDataHandler);
			Client.addEventListener(Event.CLOSE, CloseHandler);
			
            Logger.Log("Connection from " + Client.remoteAddress + ":" + Client.remotePort);
			
			Script.FireTrigger(SocketTriggers.SOCKET_CONNECT);
		}

		private function CloseHandler(event:Event):void {
			Logger.Log("Disconnected.");
			
			Client.removeEventListener(ProgressEvent.SOCKET_DATA, SocketDataHandler);
			Client.removeEventListener(Event.CLOSE, CloseHandler);
			Client = null;
			
			Script.FireTrigger(SocketTriggers.SOCKET_DISCONNECT);
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
		
		public function Close():void {
			if (Client != null) {
				Client.close();
			}
			
			if (HostSocket != null) {
				HostSocket.close();
				HostSocket = null;
			}
		}
	}
}