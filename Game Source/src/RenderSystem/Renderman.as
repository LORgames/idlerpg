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
		
		private var fadeAlpha:int = 255;
		private var fading:Boolean = false;
		private var fadeToBlack:Boolean = false;
		private var fadeCallback:Function = null;
		
		private var loadScreen:LoadScreen;
		
		public function Renderman() {
			map = new MapRenderer();
			
			loadScreen = new LoadScreen();
			
			Main.I.addChild(map);
			Main.I.addChild(Main.OrderedLayer);
			
			Main.I.addChild(loadScreen);
			
			Main.I.addChild(map.DebugLayer);
		}
		
		public function FadeToBlack(callbackIfRequired:Function = null):void {
			fadeToBlack = true;
			fading = true;
			fadeCallback = callbackIfRequired;
		}
		
		public function FadeToWorld(callbackIfRequired:Function = null):void {
			fadeToBlack = false;
			fading = true;
			fadeCallback = callbackIfRequired;
		}
		
		public function IsFading():Boolean {
			return fading;
		}
		
		public function Resized():void {
			map.Resized();
			loadScreen.Resized();
		}
		
		public function Render(dt:Number):void {
			if (fading) {
				if (fadeToBlack) {
					fadeAlpha += 13;
					if (fadeAlpha >= 255) {
						fadeAlpha = 255;
						fading = false;
					}
				} else {
					fadeAlpha -= 13;
					if (fadeAlpha <= 0) {
						fadeAlpha = 0;
						fading = false;
					}
				}
				
				if (!fading) {
					if (fadeCallback != null) {
						fadeCallback();
						fadeCallback = null;
					}
				}
				
				loadScreen.RealAlpha = fadeAlpha;
				loadScreen.Draw();
			}
			
			if (Global.LoadingTotal > 0) return;
			
			if (WorldData.ME.CurrentMap.SizeX <= Main.I.stage.stageWidth) {
				Camera.X = (Main.I.stage.stageWidth - WorldData.ME.CurrentMap.SizeX)/2;
			} else if (WorldData.ME.X <= Main.I.stage.stageWidth / 2) {
				Camera.X = 0;
			} else if (WorldData.ME.X > WorldData.ME.CurrentMap.SizeX - Main.I.stage.stageWidth / 2) {
				Camera.X = -WorldData.ME.CurrentMap.SizeX + Main.I.stage.stageWidth;
			} else {
				Camera.X = -WorldData.ME.X + Main.I.stage.stageWidth/2;
			}
			
			if (WorldData.ME.CurrentMap.SizeY <= Main.I.stage.stageHeight) {
				Camera.Y = (Main.I.stage.stageHeight - WorldData.ME.CurrentMap.SizeY)/2;
			} else if (WorldData.ME.Y <= Main.I.stage.stageHeight / 2) {
				Camera.Y = 0;
			} else if (WorldData.ME.Y > WorldData.ME.CurrentMap.SizeY - Main.I.stage.stageHeight / 2) {
				Camera.Y = -WorldData.ME.CurrentMap.SizeY + Main.I.stage.stageHeight;
			} else {
				Camera.Y = -WorldData.ME.Y + Main.I.stage.stageHeight / 2;
			}
			
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