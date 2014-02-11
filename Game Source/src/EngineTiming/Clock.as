package EngineTiming {
	import Debug.Drawer;
	import flash.display.Stage;
	import flash.events.Event;
	import flash.text.TextField;
	import flash.utils.getTimer;
	import Game.Map.WorldData;
	import Game.Tweening.TweenManager;
	import QDMF.Logic.Syncronizer;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import UI.FPSCounter;
	/**
	 * ...
	 * @author Paul
	 */
	public class Clock {
		public static var I:Clock = new Clock();
		
		private var Updatables:Vector.<IUpdatable> = new Vector.<IUpdatable>();
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
			var now:uint = getTimer();
			var delta:uint = now - last;
			last = now;
			
			if (Stopped) return;
			
			if (FPSTF != null) {
				ticks++;
				summedTime += delta;
				if (summedTime >= 1000) {
					//Global.Out.Log(ticks / delta * 1000+" ticks:"+ticks+" delta:"+delta);
					var fps:Number = 1000 * ticks / summedTime;
					FPSTF.UpdateInfo(fps.toFixed(1), Syncronizer.Ping);
					ticks = 0;
					summedTime = 0;
				}
			}
			
			var i:int;
			edt += (delta / 1000);
			
			while (edt >= dt) {
				edt -= dt;
				
				Syncronizer.Update(dt);
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
				
				Script.ProcessUpdate(dt);
				Main.I.Renderer.Update(dt);
				
				while (CleanUpList.length > 0) {
					var x:ICleanUp = CleanUpList.pop();
					x.CleanUp();
				}
			}
			
			Main.I.Renderer.Render();
			
			while (CleanUpList.length > 0) {
				var x2:ICleanUp = CleanUpList.pop();
				x2.CleanUp();
			}
			
			Global.PrevLoadingTotal = Global.LoadingTotal;
		}
		
		static public function Stop():void {
			Clock.I.Stopped = true;
		}
		
		static public function Resume():void {
			Clock.I.Stopped = false;
		}
		
		static public function isRunning():Boolean {
			return !Clock.I.Stopped;
		}
		
		public function Reset(_offset:Number = 0):void {
			last = getTimer();
			ticks = 0;
			edt = _offset; //Effective dt;
			summedTime = 0;
		}
		
		public function RegisterUpdatable(obj:IUpdatable):void {
			Updatables.push(obj);
		}
	}

}