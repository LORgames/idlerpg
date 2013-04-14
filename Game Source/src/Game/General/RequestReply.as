package Game.General {
	import flash.events.ProgressEvent;
	/**
	 * ...
	 * @author Paul
	 */
	public class RequestReply {
		public var Filename:String;
		public var SuccessCallback:Function;
		public var FailureCallback:Function;
		public var ProgressCallback:Function;
		
		public function Clear():void {
			Filename = "";
			SuccessCallback = null;
			FailureCallback = function(s:String):void{};
			ProgressCallback  = function(e:ProgressEvent):void{};
		}
	}

}