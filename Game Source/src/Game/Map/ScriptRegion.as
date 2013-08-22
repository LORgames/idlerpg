package Game.Map 
{
	import Game.Critter.BaseCritter;
	import adobe.utils.CustomActions;
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import flash.utils.ByteArray;
	import Game.Scripting.IScriptTarget;
	import Game.Scripting.Script;
	import Game.Scripting.ScriptInstance;
	/**
	 * ...
	 * @author Paul
	 */
	public class ScriptRegion implements IScriptTarget {
		public var Map:MapData;
		public var Area:Vector.<Rect>;
		
		public var _S:Script;
		public var MyScript:ScriptInstance;
		
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
			
			return s;
		}
		
		/* INTERFACE Game.Scripting.IScriptTarget */
		public function UpdatePointX(position:PointX):void {
			position.X = 0;
			position.Y = 0;
			position.D = 0;
		}
		
		public function AlertMinionDeath(baseCritter:BaseCritter):void {
			MyScript.Run(Script.MinionDied);
		}
		
		public function ChangeState(stateID:int, isLooping:Boolean):void {
			//Do nothing
		}
		
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			//Do nothing
		}
		
		public function GetCurrentState():int {
			return 0;
		}
	}

}