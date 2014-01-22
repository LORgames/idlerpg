package QDMF.Connectors {
	import Debug.ILogger;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
	import flash.net.Socket;
	import flash.system.Security;
	import flash.utils.ByteArray;
	import QDMF.Logic.Syncronizer;
	import QDMF.PacketController;
	import Scripting.Script;
	import QDMF.IHLNetwork;
	import QDMF.Packet;
	import QDMF.SocketTriggers;
	/**
	 * ...
	 * @author Paul
	 */
	public class MatchMakingClient implements IHLNetwork {
		private var Client:Socket;
		private var Logger:ILogger;
		private var nextFlush:ByteArray = new ByteArray();
		
		public function MatchMakingClient() {
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
			Client.connect(Hostname, 5000);
		}
		
		public function IsConnected():Boolean {
			return (Client != null && Client.connected);
		}
		
		public function SendPacket(packet:Packet):void {
			nextFlush.writeShort(packet.bytes.length);
			nextFlush.writeBytes(packet.bytes);
		}
		
		public function SendPacketImmediate(packet:Packet):void {
			if (Client != null) {
				try {
					Client.writeShort(packet.bytes.length);
					Client.writeBytes(packet.bytes);
					Client.flush();
				} catch (error:Error) {
					Logger.Log("MatchMaking: An unexpected error occurred: " + error.message);
				}
			}
		}
		
		private function CloseHandler(event:Event):void {
			Logger.Log("MatchMaking: Disconnected.");
			
			Client.removeEventListener(Event.CLOSE, CloseHandler);
			Client.removeEventListener(Event.CONNECT, ConnectHandler);
			Client.removeEventListener(IOErrorEvent.IO_ERROR, IOErrorHandler);
			Client.removeEventListener(SecurityErrorEvent.SECURITY_ERROR, SecurityErrorHandler);
			Client.removeEventListener(ProgressEvent.SOCKET_DATA, SocketDataHandler);
			Client = null;
			
			PacketController.Disconnected();
		}
		
		private function ConnectHandler(event:Event):void {
			Logger.Log("MatchMaking: Connected to server.");
			
			Client.writeByte("P".charCodeAt(0));
			Client.writeByte("L".charCodeAt(0));
			Client.writeByte("E".charCodeAt(0));
			Client.writeByte("A".charCodeAt(0));
			Client.writeByte("S".charCodeAt(0));
			Client.writeByte("3".charCodeAt(0));
			Client.writeByte("_".charCodeAt(0));
			Client.writeByte("M".charCodeAt(0));
			Client.writeByte("M".charCodeAt(0));
			Client.flush();
			
			//We don't fire the connected trigger here because the server may or may not have found us a match yet.
			//We will wait until we get told a player ID
		}
		
		private function IOErrorHandler(event:IOErrorEvent):void {
			Logger.Log("MatchMaking: An unexpected IO Error occured!");
			Script.FireTrigger(SocketTriggers.SOCKET_ERROR);
		}
		
		private function SecurityErrorHandler(event:SecurityErrorEvent):void {
			Logger.Log("MatchMaking: A Security issue has been detected! " + event.text);
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
				CloseHandler(null);
			}
		}
		
		public function Flush():void {
			if (Client != null && nextFlush.length > 0) {
				try {
					Logger.Log("Sending " + nextFlush.length + " bytes. [BUFFERED]");
					Client.writeBytes(nextFlush);
					Client.flush();
					nextFlush.clear();
				} catch (error:Error) {
					Logger.Log("MatchMaking: An unexpected error occurred: " + error.message);
				}
			}
		}
	}
}