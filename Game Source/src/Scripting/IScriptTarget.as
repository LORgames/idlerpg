package Scripting {
	import CollisionSystem.PointX;
	import Game.Critter.BaseCritter;
	/**
	 * ...
	 * @author Paul
	 */
	public interface IScriptTarget {
		function UpdatePointX(position:PointX):void;
		function AlertMinionDeath(baseCritter:BaseCritter):void;
		
		function ChangeState(stateID:int, isLooping:Boolean):void;
		function UpdatePlaybackSpeed(newAnimationSpeed:Number):void;
		function GetCurrentState():int;
		
		function GetFaction():int;
	}
}