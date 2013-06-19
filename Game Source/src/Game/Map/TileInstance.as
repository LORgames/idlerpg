package Game.Map {
	import CollisionSystem.Rect;
	import Interfaces.IMapObject;
	/**
	 * ...
	 * @author Paul
	 */
	public class TileInstance implements IMapObject {
		public var TileID:int = 0;
		public var SolidRectangles:Vector.<Rect> = new Vector.<Rect>();
		
		public function TileInstance() {
			
		}
		
		public function RecalculateRectangles(tileX:int = 0, tileY:int = 0):void {
			var rectsToCopy:Vector.<Rect> = TileTemplate.Tiles[TileID].Collisions;
			var i:int = rectsToCopy.length;
			
			while (--i > -1) {
				var c:Rect = rectsToCopy[i];
				var r:Rect = new Rect(true, this, c.X + tileX * 48, c.Y + tileY * 48, c.W, c.H);
				SolidRectangles.push(r);
			}
		}
		
		public function GetUnion():Rect {
			return null;
		}
		
		public function HasPerfectCollision(other:Rect):Boolean {
			return false;
		}
		
		public function ScriptAttack(isPercent:Boolean, isDOT:Boolean, amount:int, attacker:IMapObject):void {
			
		}
		
		public function CleanUp():void {
			var i:int = SolidRectangles.length;
			
			while (--i > -1) {
				SolidRectangles[i] = null;
			}
			
			SolidRectangles = null;
		}
	}
}