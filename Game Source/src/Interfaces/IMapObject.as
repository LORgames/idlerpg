package Interfaces {
	import CollisionSystem.Rect;
	import Scripting.IScriptTarget;
	/**
	 * ...
	 * @author Paul
	 */
	public interface IMapObject {
		function GetUnion():Rect;
		function HasPerfectCollision(other:Rect):Boolean;
		function ScriptAttack(isPercent:Boolean, amount:int, pierce:int, attacker:IScriptTarget):void;
	}
}