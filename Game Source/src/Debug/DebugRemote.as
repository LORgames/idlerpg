package Debug {
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
	import flash.net.Socket;
	import flash.system.Security;
	import flash.utils.ByteArray;
	import Scripting.GlobalVariables;
	import Scripting.Script;
	/**
	 * ...
	 * @author Paul
	 */
	public class DebugRemote {
		internal var Client:Socket;
		
		public function DebugRemote() {
			Client = new Socket();
			
			Client.addEventListener(Event.CLOSE, CloseHandler);
			Client.addEventListener(Event.CONNECT, ConnectHandler);
			Client.addEventListener(IOErrorEvent.IO_ERROR, IOErrorHandler);
			Client.addEventListener(SecurityErrorEvent.SECURITY_ERROR, SecurityErrorHandler);
			Client.addEventListener(ProgressEvent.SOCKET_DATA, SocketDataHandler);
			
			Client.connect("127.0.0.1", 12685);
		}
		
		private function CloseHandler(event:Event):void {
			Global.Out.Log("RemoteDebugger Disconnected.");
			
			Client.removeEventListener(Event.CLOSE, CloseHandler);
			Client.removeEventListener(Event.CONNECT, ConnectHandler);
			Client.removeEventListener(IOErrorEvent.IO_ERROR, IOErrorHandler);
			Client.removeEventListener(SecurityErrorEvent.SECURITY_ERROR, SecurityErrorHandler);
			Client.removeEventListener(ProgressEvent.SOCKET_DATA, SocketDataHandler);
			Client = null;
			
			Global.Out.Disconnect();
		}
		
		private function ConnectHandler(event:Event):void {
			Global.Out.Log("RemoteDebugger Connected.");
		}
		
		private function IOErrorHandler(event:IOErrorEvent):void {
			Global.Out.Log("RemoteDebugger An unexpected IO Error occured!");
			Client = null;
			Global.Out.Disconnect();
		}
		
		private function SecurityErrorHandler(event:SecurityErrorEvent):void {
			Global.Out.Log("RemoteDebugger A Security issue has been detected!");
			Client = null;
			Global.Out.Disconnect();
		}
		
		private function SocketDataHandler(event:ProgressEvent):void {
			var expectedLength:int = 0;
			var i:int;
			var p:ByteArray;
			
			while(Client.bytesAvailable > 0) {
				if (Client.bytesAvailable > 1) {
					expectedLength = Client.readInt();
					
					if (Client.bytesAvailable >= expectedLength) {
						p = new ByteArray();
						Client.readBytes(p, 0, expectedLength);
					} else {
						throw new Error("Cannot read " + expectedLength + "bytes when only " + Client.bytesAvailable + "bytes are available. Silly Networking!");
					}
				}
				
				if(p != null) {
					var type:int = p.readShort();
					switch(type) {
						case 0: //keep alive
							break;
						case 2: //Send variables
							var varBytes:ByteArray = new ByteArray();
							varBytes.writeShort(2);
							
							//Write Integers
							varBytes.writeInt(GlobalVariables.IntegerVariables.length);
							for (i = 0; i < GlobalVariables.IntegerVariables.length; i++) { varBytes.writeInt(GlobalVariables.IntegerVariables[i]); }
							
							//Write Strings
							varBytes.writeInt(GlobalVariables.StringVariables.length);
							for (i = 0; i < GlobalVariables.StringVariables.length; i++) { varBytes.writeUTF(GlobalVariables.StringVariables[i]); }
							
							varBytes.position = 0;
							Client.writeInt(varBytes.length);
							Client.writeBytes(varBytes);
							Client.flush();
							break;
						default:
							Global.Out.Log("Unknown request: " + type);
					}
				}
				
				p = null;
			}
		}
		
		public function Close():void {
			if(Client) Client.close();
		}
		
		public function Message(str:String):void {
			var b:ByteArray = new ByteArray();
			b.writeUTF(str);
			b.position = 0;
			
			Client.writeInt(b.length+2); //String bytes + 2 for the header
			Client.writeShort(1); //Message ID
			Client.writeBytes(b);
			Client.flush();
		}
	}
}