package Game.Map {
	import Game.Critter.BaseCritter;
	import adobe.utils.CustomActions;
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import flash.utils.ByteArray;
	import Scripting.IScriptTarget;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	import EngineTiming.ICleanUp;
	/**
	 * ...
	 * @author Paul
	 */
	public class ScriptRegion implements IScriptTarget, ICleanUp {
		public var Map:MapData;
		public var Area:Vector.<Rect>;
		
		public var _S:Script;
		public var MyScript:ScriptInstance;
		
		public var SupportsPress:Boolean = false;
		public var SupportsDrag:Boolean = false;
		
		public function ScriptRegion() {
			
		}
		
		public static function LoadFromBinary(map:MapData, b:ByteArray):ScriptRegion {
			var s:ScriptRegion = new ScriptRegion();
			s.Map = map;
			
			var totalRects:int = b.readByte();
			s.Area = new Vector.<Rect>(totalRects, true);
			
			// Load rectangles
			while (--totalRects > -1) {
				s.Area[totalRects] = new Rect(true, null, b.readShort(), b.readShort(), b.readShort(), b.readShort());
			}
			
			s._S = Script.ReadScript(b);
			s.MyScript = new ScriptInstance(s._S, s, true);
			
			if (s._S.HasEvent(Script.Attack)) {
				s.SupportsPress = true;
			}
			
			if (s._S.HasEvent(Script.Use)) {
				s.SupportsDrag = true;
			}
			
			return s;
		}
		
		/* INTERFACE Scripting.IScriptTarget */
		public function GetScript():ScriptInstance { return MyScript; }
		public function GetTypeID():int { return 0; }
		public function UpdatePointX(position:PointX):void { position.X = 0; position.Y = 0; position.D = 1; }
		public function AlertMinionDeath(baseCritter:BaseCritter):void { MyScript.Run(Script.MinionDied); }
		public function ChangeState(stateID:int, isLooping:Boolean):void { /* Do nothing */ }
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void { /* Do nothing */ }
		public function GetAnimationSpeed():Number { return 0; }
		public function GetCurrentState():int { return 0; }
		public function GetFaction():int { return 0; }
		
		public function CleanUp():void {
			Map = null;
			
			var i:int;
			
			i = Area.length;
			while (--i > -1) {
				Area[i].Owner = null;
				Area[i] = null;
			}
			Area = null;
			
			MyScript.CleanUp();
			_S.CleanUp();
		}
	}
}