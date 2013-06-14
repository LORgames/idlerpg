package RenderSystem 
{
	import CollisionSystem.Rect;
	import flash.display.Sprite;
	/**
	 * ...
	 * @author Paul
	 */
	public class DebugDrawingHelper {
		
		public static function AddDebugRect(r:Rect):void {
			var spr:Sprite = new Sprite();
			spr.x = Main.OrderedLayer.x;
			spr.y = Main.OrderedLayer.y;
			
			spr.graphics.clear();
			spr.graphics.lineStyle(1, 0xFF0000);
			spr.graphics.drawRect(r.X, r.Y, r.W, r.H);
			Main.I.addChild(spr);
		}
		
	}

}