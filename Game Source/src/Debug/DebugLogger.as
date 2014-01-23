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
				//debugSock.Trace(message);
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
				debugSock = new DebugRemote();
			}
		}
	}
}