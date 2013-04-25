package Game.Map {
	/**
	 * ...
	 * @author Paul
	 */
	public class TileInstance {
		public var TileID:int = 0;
		public var SolidRectangles:Vector.<Rect> = new Vector.<Rect>();
		
		public function RecalculateRectangles(tileX:int = 0, tileY:int = 0):void {
			var rectsToCopy:Vector.<Rect> = TileTemplate.Tiles[TileID].Collisions;
			var i:int = rectsToCopy.length;
			
			while (--i > -1) {
				var c:Rect = rectsToCopy[i];
				var r:Rect = new Rect(c.x + tileX * 48, c.y + tileY * 48, c.width, c.height);
				SolidRectangles.push(r);
			}
		}
	}
}