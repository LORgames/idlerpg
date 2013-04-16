package RenderSystem {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class Renderman {
		private var map:MapRenderer;
		
		public static var AnimatedObjects:Vector.<AnimatedCache> = new Vector.<AnimatedCache>();
		
		public function Renderman() {
			map = new MapRenderer();
			
			Main.I.addChild(map);
			Main.I.addChild(Main.OrderedLayer);
		}
		
		public function Resized():void {
			map.Resized();
		}
		
		public function Render():void {
			if (Global.LoadingTotal > 0) return;
			
			map.Draw();
			
			var i:int = AnimatedObjects.length;
			
			while (--i > -1) {
				AnimatedObjects[i].UpdateAnimation(0.05);
			}
		}
		
	}

}