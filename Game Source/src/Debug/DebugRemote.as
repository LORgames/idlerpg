package Debug {
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
	import flash.net.Socket;
	import flash.system.Security;
	import flash.utils.ByteArray;
	import Scripting.Script;
	/**
	 * ...
	 * @author Paul
	 */
	public class DebugRemote {
		private var Client:Socket;
		
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
		}
		
		private function ConnectHandler(event:Event):void {
			Global.Out.Log("RemoteDebugger Connected.");
		}
		
		private function IOErrorHandler(event:IOErrorEvent):void {
			Global.Out.Log("RemoteDebugger An unexpected IO Error occured!");
		}
		
		private function SecurityErrorHandler(event:SecurityErrorEvent):void {
			Global.Out.Log("RemoteDebugger A Security issue has been detected!");
		}
		
		private function SocketDataHandler(event:ProgressEvent):void {
			//TODO: This shouldn't happen
		}
		
		public function Close():void {
			Client.close();
		}
		
		public function Message(str:String):void {
			Client.writeUTF(str);
		}
	}
}