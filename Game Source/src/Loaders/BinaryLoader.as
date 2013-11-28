package Loaders {
	import adobe.utils.CustomActions;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
	import flash.net.URLLoader;
	import flash.net.URLLoaderDataFormat;
	import flash.net.URLRequest;
	import flash.utils.ByteArray;
	/**
	 * ...
	 * @author Paul
	 */
	public class BinaryLoader {
		private static var loader:URLLoader = new URLLoader();
		
		private static var currentInfo:RequestReply = null;
		private static var loadQueue:Vector.<RequestReply> = new Vector.<RequestReply>();
		
		private static var TotalInQueue:int = 0;
		private static var UnusedObjects:Vector.<RequestReply> = new Vector.<RequestReply>();
		
		public static function Initialize():void {
			//Add Event Listeners
			loader.addEventListener(Event.COMPLETE, Event_LoadingCompleted);
			loader.addEventListener(ProgressEvent.PROGRESS, Event_LoadProgress);
			loader.addEventListener(IOErrorEvent.IO_ERROR, Event_IOError);
			loader.addEventListener(SecurityErrorEvent.SECURITY_ERROR, Event_SecurityError);
			
			loader.dataFormat = URLLoaderDataFormat.BINARY;
		}
		
		private static function ProcessNext():void {
			if (currentInfo != null) return;
			if (loadQueue.length == 0) return;
			
			currentInfo = loadQueue.shift();
			
			loader.load(new URLRequest(currentInfo.Filename));
		}
		
		private static function Event_LoadingCompleted(e:Event):void {
			Global.LoadingTotal--;
			currentInfo.SuccessCallback(loader.data);
			CurrentLoadingEnded();
		}
		
		private static function Event_LoadProgress(e:ProgressEvent):void {
			currentInfo.ProgressCallback(e);
		}
		
		private static function Event_IOError(e:IOErrorEvent):void {
			Main.I.Log("IO Error: " + e.text);
			currentInfo.FailureCallback(e.text);
			
			CurrentLoadingEnded();
		}
		
		private static function Event_SecurityError(e:SecurityErrorEvent):void {
			Main.I.Log("Security Error: " + e.text);
			currentInfo.FailureCallback(e.text);
			
			CurrentLoadingEnded();
		}
		
		private static function CurrentLoadingEnded():void {
			currentInfo.Clear();
			UnusedObjects.push(currentInfo);
			currentInfo = null;
			
			ProcessNext();
		}
		
		public static function Load(filename:String, success:Function, error:Function = null, progress:Function = null):void {
			if (UnusedObjects.length == 0) {
				var b:RequestReply = new RequestReply();
				b.Clear();
				UnusedObjects.push(b);
			}
			
			var l:RequestReply = UnusedObjects.pop();
			l.Filename = filename;
			l.SuccessCallback = success;
			if(error != null) l.FailureCallback = error;
			if(progress != null) l.ProgressCallback = progress;
			loadQueue.push(l);
			Global.LoadingTotal++;
			
			ProcessNext();
		}
		
		public static function GetString(b:ByteArray):String {
			var l:int = b.readShort();
			return b.readMultiByte(l, "utf-8"); //map name
		}
	}

}