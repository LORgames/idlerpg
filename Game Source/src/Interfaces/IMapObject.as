package Interfaces {
	import CollisionSystem.Rect;
	import Game.Scripting.IScriptTarget;
	/**
	 * ...
	 * @author Paul
	 */
	public interface IMapObject {
		function GetUnion():Rect;
		function HasPerfectCollision(other:Rect):Boolean;
		function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IScriptTarget):void;
	}
}