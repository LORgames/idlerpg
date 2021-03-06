package Debug {
	CONFIG::air {
		import flash.filesystem.File;
		import flash.filesystem.FileStream;
		import flash.filesystem.FileMode;
		import flash.net.Socket;
		import flash.trace.Trace;
		import flash.trace.Trace;
	}
	/**
	 * ...
	 * @author Paul
	 */
	public class DebugLogger {
		private var debugSock:DebugRemote;
		
		public function DebugLogger() {
			
		}
		
		public function Log(message:String):void {
			if (debugSock != null) {
				debugSock.Message(message);
			}
			
			trace(message);
			CONFIG::desktop {
				CONFIG::release {
					var file:File = File.applicationStorageDirectory.resolvePath("debug.log");
					var fs:FileStream = new FileStream();
					fs.open(file, FileMode.APPEND);
					fs.writeUTFBytes("[" + (new Date()) + "] " + message + "\n");
					fs.close();
				}
			}
		}
		
		public function Connect():void {
			if (debugSock == null) {
				trace("Debug connection requested");
				debugSock = new DebugRemote();
			} else {
				Disconnect();
			}
		}
		
		public function Disconnect():void {
			if (debugSock != null) {
				if (debugSock.Client == null) {
					debugSock = null;
				} else {
					trace("Debug disconnection requested");
					debugSock.Close();
				}
			}
		}
	}
}