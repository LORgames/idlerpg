package Game.General {
	import flash.display.Bitmap;
	import flash.display.Loader;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.ProgressEvent;
	import flash.events.SecurityErrorEvent;
	import flash.net.URLRequest;
	/**
	 * ...
	 * @author Paul
	 */
	public class ImageLoader {
		private static var loader:Loader = new Loader();
		
		private static var currentInfo:RequestReply = null;
		private static var loadQueue:Vector.<RequestReply> = new Vector.<RequestReply>();
		
		private static var TotalInQueue:int = 0;
		private static var UnusedObjects:Vector.<RequestReply> = new Vector.<RequestReply>();
		
		public static function Initialize():void {
			//Add Event Listeners
			loader.contentLoaderInfo.addEventListener(Event.COMPLETE, Event_LoadingCompleted);
			loader.contentLoaderInfo.addEventListener(ProgressEvent.PROGRESS, Event_LoadProgress);
			loader.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, Event_IOError);
			loader.contentLoaderInfo.addEventListener(SecurityErrorEvent.SECURITY_ERROR, Event_SecurityError);
		}
		
		private static function ProcessNext():void {
			if (currentInfo != null) return;
			if (loadQueue.length == 0) return;
			
			currentInfo = loadQueue.shift();
			
			loader.load(new URLRequest(currentInfo.Filename));
		}
		
		private static function Event_LoadingCompleted(e:Event):void {
			var image:Bitmap = Bitmap(loader.content); 
			currentInfo.SuccessCallback(image.bitmapData);
			image.bitmapData.dispose();
			
			CurrentLoadingEnded();
		}
		
		private static function Event_LoadProgress(e:ProgressEvent):void {
			currentInfo.ProgressCallback(e);
		}
		
		private static function Event_IOError(e:IOErrorEvent):void {
			trace("IO Error: " + e.text);
			currentInfo.FailureCallback(e.text);
			
			CurrentLoadingEnded();
		}
		
		private static function Event_SecurityError(e:SecurityErrorEvent):void {
			trace("Security Error: " + e.text);
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
			
			ProcessNext();
		}
	}

}