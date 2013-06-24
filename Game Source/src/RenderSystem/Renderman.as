package RenderSystem {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Rectangle;
	import Game.Critter.CritterAnimationSet;
	import Game.Map.MapData;
	import Game.Map.WorldData;
	import WindowSystem.ScreenText;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class Renderman {
		private var map:MapRenderer;
		
		private static var AnimatedObjects:Vector.<IAnimated> = new Vector.<IAnimated>();
		
		private var fadeAlpha:int = 255;
		private var fading:Boolean = false;
		private var fadeToBlack:Boolean = false;
		private var fadeCallback:Function = null;
		public var MapText:ScreenText;
		
		private var loadScreen:LoadScreen;
		
		public function Renderman() {
			map = new MapRenderer();
			
			loadScreen = new LoadScreen();
			
			Main.I.addChild(map);
			Main.I.addChild(Main.OrderedLayer);
			
			Main.I.addChild(loadScreen);
			
			Main.I.addChild(map.DebugLayer);
			
			MapText = new ScreenText(60);
			Main.I.addChild(MapText);
		}
		
		public function FadeToBlack(callbackIfRequired:Function = null, message:String = ""):void {
			fadeToBlack = true;
			fading = true;
			fadeCallback = callbackIfRequired;
			
			MapText.UpdateText(message);
			MapText.x = (Main.I.stage.stageWidth - MapText.width) / 2;
			MapText.y = (Main.I.stage.stageHeight - MapText.height) / 2;
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
			//Sort the children
			i = Main.OrderedLayer.numChildren;
			while(--i > 4) {
				TrySwap(i-4);
				TrySwap(i-3);
				TrySwap(i-2);
				TrySwap(i-1);
				TrySwap(i-0);
			}
			
			//Update the fading
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
				
				MapText.alpha = fadeAlpha / 255.0;
				loadScreen.RealAlpha = fadeAlpha;
				loadScreen.Draw();
			}
			
			if (Global.LoadingTotal > 0) return;
			if (WorldData.CurrentMap == null) return;
			
			if (WorldData.CurrentMap.SizeX <= Main.I.stage.stageWidth) {
				Camera.X = (Main.I.stage.stageWidth - WorldData.CurrentMap.SizeX)/2;
			} else if (WorldData.ME.X <= Main.I.stage.stageWidth / 2) {
				Camera.X = 0;
			} else if (WorldData.ME.X > WorldData.CurrentMap.SizeX - Main.I.stage.stageWidth / 2) {
				Camera.X = -WorldData.CurrentMap.SizeX + Main.I.stage.stageWidth;
			} else {
				Camera.X = -WorldData.ME.X + Main.I.stage.stageWidth/2;
			}
			
			if (WorldData.CurrentMap.SizeY <= Main.I.stage.stageHeight) {
				Camera.Y = (Main.I.stage.stageHeight - WorldData.CurrentMap.SizeY)/2;
			} else if (WorldData.ME.Y <= Main.I.stage.stageHeight / 2) {
				Camera.Y = 0;
			} else if (WorldData.ME.Y > WorldData.CurrentMap.SizeY - Main.I.stage.stageHeight / 2) {
				Camera.Y = -WorldData.CurrentMap.SizeY + Main.I.stage.stageHeight;
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
		
		private function TrySwap(i:int):void {
			var OrderedLayer:Sprite = Main.OrderedLayer;
			
			if ((IObjectLayer)(OrderedLayer.getChildAt(i)).GetTrueY() < (IObjectLayer)(OrderedLayer.getChildAt(i-1)).GetTrueY()) {
				OrderedLayer.swapChildrenAt(i, i-1);
			}
		}
		
		static public function AnimatedObjectsPush(animation:IAnimated):void {
			AnimatedObjects.push(animation);
		}
		
		static public function AnimatedObjectsRemove(animation:IAnimated):void {
			var i:int = AnimatedObjects.indexOf(animation);
			
			if (i > -1) {
				AnimatedObjects.splice(i, 1);
			} else {
				trace(animation + " is not in the queue");
			}
		}
	}
}