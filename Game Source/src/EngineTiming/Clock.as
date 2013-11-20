package EngineTiming {
	import flash.display.Stage;
	import flash.events.Event;
	import flash.text.TextField;
	import flash.utils.getTimer;
	import Game.Map.WorldData;
	import Game.Tweening.TweenManager;
	import Scripting.Script;
	import UI.FPSCounter;
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
		private var Stopped:Boolean = false;
		
		public static var FPSTF:FPSCounter;
        private var last:uint = getTimer();
        private var ticks:uint = 0;
		
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
			if (Stopped) return;
			
			if (FPSTF != null) {
				ticks++;
				var now:uint = getTimer();
				var delta:uint = now - last;
				if (delta >= 1000) {
					//trace(ticks / delta * 1000+" ticks:"+ticks+" delta:"+delta);
					var fps:Number = ticks / delta * 1000;
					FPSTF.UpdateInfo(fps.toFixed(1));
					ticks = 0;
					last = now;
				}
			}
			
			if (Global.LoadingTotal == 0) {
				var dt:Number = 1.0 / ExpectedFrameRate;
				var i:int;
				
				Sec_01_Count += dt;
				Sec_15_Count += dt;
				
				WorldData.CurrentMap.Update(dt);
				TweenManager.Update(dt);
				
				//Update what we need to update
				i = Updatables.length;
				while (--i > -1) {
					Updatables[i].Update(dt);
				}
				
				if (Sec_01_Count > 1) {
					Sec_01_Count -= 1;
					Script.ProcessUpdate();
					
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
			}
			
			Main.I.Renderer.Render(dt);
			
			while (CleanUpList.length > 0) {
				var x:ICleanUp = CleanUpList.pop();
				x.CleanUp();
			}
			
			Global.PrevLoadingTotal = Global.LoadingTotal;
		}
		
		public function Remove1(item:IOneSecondUpdate):void {
			var i:int = OneSecond.indexOf(item);
			
			if (i > -1) {
				OneSecond.splice(i, 1);
			}
		}
		
		public function Remove15(item:IFifteenSecondUpdate):void {
			var i:int = FifteenSecond.indexOf(item);
			
			if (i > -1) {
				FifteenSecond.splice(i, 1);
			}
		}
		
		static public function Stop():void {
			Clock.I.Stopped = true;
		}
	}

}