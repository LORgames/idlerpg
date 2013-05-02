package RenderSystem {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.geom.Rectangle;
	import Game.Map.MapData;
	import Game.Map.WorldData;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class Renderman {
		private var map:MapRenderer;
		
		public static var AnimatedObjects:Vector.<IAnimated> = new Vector.<IAnimated>();
		
		private var fade:Number = 1;
		private var fadeOut:Boolean = false;
		private var fadeIn:Boolean = false;
		
		private var loadScreen:LoadScreen;
		
		public function Renderman() {
			map = new MapRenderer();
			
			loadScreen = new LoadScreen();
			
			Main.I.addChild(map);
			Main.I.addChild(Main.OrderedLayer);
			
			Main.I.addChild(loadScreen);
			
			Main.I.addChild(map.DebugLayer);
		}
		
		public function FadeOut():void {
			fadeOut = true;
		}
		
		public function FadeIn():void {
			fadeIn = true;
		}
		
		public function Resized():void {
			map.Resized();
			loadScreen.Resized();
		}
		
		public function Render(dt:Number):void {
			if (fade > 0) {
				if (fadeOut) {
					fade -= 0.05;
					if (fade <= 0) {
						fade = 0;
						fadeOut = false;
					}
				} else {
					if (fadeIn) {
						fade += 0.05;
						if (fade >= 1) {
							fade = 1;
							fadeIn = false;
						}
					}
				}
				
				loadScreen.alpha = fade;
				loadScreen.Draw();
			}
			
			if (Global.LoadingTotal > 0) return;
			
			Camera.X = -WorldData.ME.X + Main.I.stage.stageWidth/2;
			Camera.Y = -WorldData.ME.Y + Main.I.stage.stageHeight / 2;
			
			Main.OrderedLayer.x = Camera.X;
			Main.OrderedLayer.y = Camera.Y;
			map.DebugLayer.x = Camera.X;
			map.DebugLayer.y = Camera.Y;
			
			map.Draw();
			
			var i:int = AnimatedObjects.length;
			
			while (--i > -1) {
				AnimatedObjects[i].UpdateAnimation(dt);
			}
		}
	}
}