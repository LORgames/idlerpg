package EngineTiming {
	import flash.display.Stage;
	import flash.events.Event;
	import Game.Map.SpawnRegion;
	import Game.Map.WorldData;
	/**
	 * ...
	 * @author Paul
	 */
	public class Clock {
		public static var I:Clock = new Clock();
		
		public var Updatables:Vector.<IUpdatable> = new Vector.<IUpdatable>();
		public var OneSecond:Vector.<IOneSecondUpdate> = new Vector.<IOneSecondUpdate>();
		public var FifteenSecond:Vector.<IFifteenSecondUpdate> = new Vector.<IFifteenSecondUpdate>();
		
		private var Sec_01_Count:Number = 0;
		private var Sec_15_Count:Number = 0;
		
		private var ExpectedFrameRate:Number = 0;
		
		public static var CleanUpList:Vector.<ICleanUp> = new Vector.<ICleanUp>();
		
		public function Clock() {
			
		}
		
		public function Start(s:Stage):void {
			s.addEventListener(Event.ENTER_FRAME, Tick);
			ExpectedFrameRate = s.frameRate;
		}
		
		public function Remove(x:IUpdatable):void {
			if (Updatables.indexOf(x) > -1) {
				Updatables.splice(Updatables.indexOf(x), 1);
			}
		}
		
		public function Tick(e:Event):void {
			var dt:Number = 1.0 / ExpectedFrameRate;
			var i:int;
			
   			Sec_01_Count += dt;
			Sec_15_Count += dt;
			
			WorldData.CurrentMap.Update(dt);
			
			//Update what we need to update
			i = Updatables.length;
			while (--i > -1) {
				Updatables[i].Update(dt);
			}
			
			if (Sec_01_Count > 1) {
				Sec_01_Count -= 1;
				
				i = OneSecond.length;
				while (--i > -1) {
					OneSecond[i].UpdateOneSecond();
				}
			}
			
			if (Sec_15_Count > 15) {
				Sec_15_Count -= 15;
				
				i = FifteenSecond.length;
				while (--i > -1) {
					FifteenSecond[i].UpdateFifteenSecond();
				}
			}
			
			Main.I.Renderer.Render(dt);
			
			while (CleanUpList.length > 0) {
				var x:ICleanUp = CleanUpList.pop();
				x.CleanUp();
			}
		}
		
		public function Remove1(item:IOneSecondUpdate):void {
			var i:int = OneSecond.indexOf(item);
			
			if (i > -1) {
				OneSecond.splice(i, 1);
			}
		}
		
		public function Remove15(item:IOneSecondUpdate):void {
			var i:int = FifteenSecond.indexOf(item);
			
			if (i > -1) {
				FifteenSecond.splice(i, 1);
			}
		}
	}

}