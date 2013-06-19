package EngineTiming {
	import flash.display.Stage;
	import flash.events.Event;
	/**
	 * ...
	 * @author Paul
	 */
	public class Clock {
		public static var I:Clock = new Clock();
		
		public var Updatables:Vector.<IUpdatable> = new Vector.<IUpdatable>();
		public var OneSecond:Vector.<IOneSecondUpdate> = new Vector.<IOneSecondUpdate>();
		public var FifteenSecond:Vector.<IFifteenSecondUpdate> = new Vector.<IFifteenSecondUpdate>();
		
		private var ExpectedFrameRate:Number = 0;
		
		public function Clock() {
			
		}
		
		public function Start(s:Stage):void {
			s.addEventListener(Event.ENTER_FRAME, Tick);
			ExpectedFrameRate = s.frameRate;
		}
		
		public function Tick(e:Event):void {
			var dt:Number = 1.0 / ExpectedFrameRate;
			var i:int;
			
			//Update what we need to update
			i = Updatables.length;
			while (--i > -1) {
				Updatables[i].Update(dt);
			}
			
			Main.I.Renderer.Render(dt);
		}
		
	}

}