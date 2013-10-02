package QDMF.Connectors 
{
	import Debug.ILogger;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
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
	public class SocketClient implements IHLNetwork {
		private var Client:Socket;
		private var Logger:ILogger;
		
		public function SocketClient() {
			Client = new Socket();
			
			Client.addEventListener(Event.CLOSE, CloseHandler);
			Client.addEventListener(Event.CONNECT, ConnectHandler);
			Client.addEventListener(IOErrorEvent.IO_ERROR, IOErrorHandler);
			Client.addEventListener(SecurityErrorEvent.SECURITY_ERROR, SecurityErrorHandler);
			Client.addEventListener(ProgressEvent.SOCKET_DATA, SocketDataHandler);
		}
		
		/* INTERFACE QDMF.IHLNetwork */
		
		public function Connect(Hostname:String, Port:int, Logger:ILogger):void {
			this.Logger = Logger;
			Client.connect(Hostname, Port);
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

		private function CloseHandler(event:Event):void {
			Logger.Log("Disconnected.");
			
			Client.removeEventListener(Event.CLOSE, CloseHandler);
			Client.removeEventListener(Event.CONNECT, ConnectHandler);
			Client.removeEventListener(IOErrorEvent.IO_ERROR, IOErrorHandler);
			Client.removeEventListener(SecurityErrorEvent.SECURITY_ERROR, SecurityErrorHandler);
			Client.removeEventListener(ProgressEvent.SOCKET_DATA, SocketDataHandler);
			Client = null;
			
			Script.FireTrigger(SocketTriggers.SOCKET_DISCONNECT);
		}
		
		private function ConnectHandler(event:Event):void {
			Logger.Log("Connected to server.");
			Script.FireTrigger(SocketTriggers.SOCKET_CONNECT);
		}
		
		private function IOErrorHandler(event:IOErrorEvent):void {
			Logger.Log("An unexpected IO Error occured!");
			Script.FireTrigger(SocketTriggers.SOCKET_ERROR);
		}
		
		private function SecurityErrorHandler(event:SecurityErrorEvent):void {
			Logger.Log("A Security issue has been detected!");
			Script.FireTrigger(SocketTriggers.SOCKET_ERROR);
		}
		
		private function SocketDataHandler(event:ProgressEvent):void {
			while (Client.bytesAvailable > 1) {
				Packet.UnpackFromInput(Client);
			}
		}
		
		public function Close():void {
			if (IsConnected()) {
				Client.close();
			}
		}
	}
}