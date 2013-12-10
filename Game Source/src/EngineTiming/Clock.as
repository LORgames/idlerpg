package EngineTiming {
	import flash.display.Stage;
	import flash.events.Event;
	import flash.text.TextField;
	import flash.utils.getTimer;
	import Game.Map.WorldData;
	import Game.Tweening.TweenManager;
	import QDMF.Logic.Syncronizer;
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
		
		private var Stopped:Boolean = false;
		
		public static var FPSTF:FPSCounter;
        private var last:uint = getTimer();
        private var ticks:uint = 0;
		private var edt:Number = 0; //Effective dt;
		private const dt:Number = 0.0167; //Update at 60FPS
		private var summedTime:int = 0;
		
		public static var CleanUpList:Vector.<ICleanUp> = new Vector.<ICleanUp>();
		
		public function Clock() {
			
		}
		
		public function Start(s:Stage):void {
			s.addEventListener(Event.ENTER_FRAME, Tick);
			//dt = 0.6 / s.frameRate;
		}
		
		public function Remove(x:IUpdatable):void {
			if (Updatables.indexOf(x) > -1) {
				Updatables.splice(Updatables.indexOf(x), 1);
			}
		}
		
		public function Tick(e:Event):void {
			if (Stopped) return;
			
			var now:uint = getTimer();
			var delta:uint = now - last;
			last = now;
			
			if (FPSTF != null) {
				ticks++;
				summedTime += delta;
				if (summedTime >= 1000) {
					//Main.I.Log(ticks / delta * 1000+" ticks:"+ticks+" delta:"+delta);
					var fps:Number = 1000 * ticks / summedTime;
					FPSTF.UpdateInfo(fps.toFixed(1), Syncronizer.Ping);
					ticks = 0;
					summedTime = 0;
				}
			}
			
			if (Global.LoadingTotal == 0) {
				var i:int;
				edt += (delta / 1000);
				
				while (edt >= dt) {
					edt -= dt;
					
					Syncronizer.Update(dt);
					Sec_01_Count += dt;
					
					WorldData.CurrentMap.Update(dt);
					TweenManager.Update(dt);
					
					//Preupdate critters
					i = WorldData.CurrentMap.Critters.length;
					while (--i > -1) {
						if (WorldData.CurrentMap.Critters[i] != null) {
							WorldData.CurrentMap.Critters[i].PreUpdate(dt);
						}
					}
					
					//Update what we need to update
					i = Updatables.length;
					while (--i > -1) {
						Updatables[i].Update(dt);
					}
					
					//Post update critters
					i = WorldData.CurrentMap.Critters.length;
					while (--i > -1) {
						if (WorldData.CurrentMap.Critters[i] != null) {
							WorldData.CurrentMap.Critters[i].PostUpdate();
						}
					}
					
					if (Sec_01_Count > 1) {
						Sec_01_Count -= 1;
						Script.ProcessUpdate();
						
						i = OneSecond.length;
						while (--i > -1) {
							OneSecond[i].UpdateOneSecond();
						}
					}
					
					Main.I.Renderer.Update(dt);
					
					while (CleanUpList.length > 0) {
						var x:ICleanUp = CleanUpList.pop();
						x.CleanUp();
					}
					
					Global.PrevLoadingTotal = Global.LoadingTotal;
				}
			}
			
			Main.I.Renderer.Render();
			
			while (CleanUpList.length > 0) {
				var x2:ICleanUp = CleanUpList.pop();
				x2.CleanUp();
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
		
		static public function Resume():void {
			Clock.I.Stopped = false;
		}
		
		public function Reset():void {
			Sec_01_Count = 0;
			last = getTimer();
			ticks = 0;
			edt = 0; //Effective dt;
			summedTime = 0;
		}
	}

}