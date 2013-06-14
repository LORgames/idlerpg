package Interfaces {
	import CollisionSystem.Rect;
	/**
	 * ...
	 * @author Paul
	 */
	public interface IMapObject {
		function GetUnion():Rect;
		function HasPerfectCollision(other:Rect):Boolean;
	}
}