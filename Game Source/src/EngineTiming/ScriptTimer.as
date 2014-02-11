package EngineTiming {
	import flash.utils.getTimer;
	import Scripting.IScriptTarget;
	/**
	 * ...
	 * @author Paul
	 */
	public class ScriptTimer {
		public var EndTime:int = -1; //This should be -1 for unused
		public var Invoker:IScriptTarget = null; //Who actually owns the timer?
		
		public function ScriptTimer() {
			
		}
		
		public function CleanUp():void {
			Invoker = null;
			EndTime = -1;
		}
		
		//STATIC FUNCTIONS
		private static var gTimers:Vector.<ScriptTimer> = new Vector.<ScriptTimer>(256, true);
		private static var nextTimer:int = 0;
		public static function RequestTimer(invoker:IScriptTarget, time:int):int {
			var rID:int = nextTimer;
			
			while (gTimers[nextTimer].Invoker != null) {
				nextTimer++;
				if (nextTimer > 255) nextTimer = 0;
				if (nextTimer == rID) return -1;
			}
			
			//Set the values
			gTimers[nextTimer].EndTime = getTimer() + time;
			gTimers[nextTimer].Invoker = invoker;
			
			var rID:int = nextTimer;
			
			nextTimer++;
			if (nextTimer > 255) nextTimer = 0;
			
			return (nextTimer-1);
		}
	}
}