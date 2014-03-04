package EngineTiming {
	import adobe.utils.CustomActions;
	import flash.utils.getTimer;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	/**
	 * ...
	 * @author Paul
	 */
	public class ScriptTimer {
		private static const TOTAL_TIMERS:int = 256;
		
		public var TimeRemaining:Number = -1; //This should be -1 for unused
		public var Invoker:ScriptInstance = null; //Who actually owns the timer?
		
		public function ScriptTimer() {
			
		}
		
		public function CleanUp():void {
			Invoker = null;
			TimeRemaining = -1;
		}
		
		//STATIC FUNCTIONS
		private static var gTimers:Vector.<ScriptTimer> = new Vector.<ScriptTimer>(TOTAL_TIMERS, true);
		private static var nextTimer:int = 0;
		
		public static function Initialize():void {
			for (var i:int = 0; i < TOTAL_TIMERS; i++) {
				gTimers[i] = new ScriptTimer();
			}
		}
		
		public static function RequestTimer(invoker:ScriptInstance, time:int):int {
			var rID:int = nextTimer;
			
			while (gTimers[nextTimer].Invoker != null) {
				nextTimer++;
				if (nextTimer > TOTAL_TIMERS-1) nextTimer = 0;
				if (nextTimer == rID) return -1;
			}
			
			//Set the values
			gTimers[nextTimer].EndTime = time/1000.0;
			gTimers[nextTimer].Invoker = invoker;
			
			rID = nextTimer;
			
			nextTimer++;
			if (nextTimer > TOTAL_TIMERS-1) nextTimer = 0;
			
			return rID;
		}
		
		static public function ReleaseTimer(id:int):void {
			gTimers[id].CleanUp();
		}
		
		public static function Update(dt:Number):void {
			for (var i:int = 0; i < TOTAL_TIMERS; i++) {
				if (gTimers[i].TimeRemaining != -1) {
					gTimers[i].TimeRemaining -= dt;
					if(gTimers[i].TimeRemaining <= 0) {
						gTimers[i].Invoker.Run(Script.TimerEvent, null, i);
						gTimers[i].CleanUp();
					}
				}
			}
		}
	}
}