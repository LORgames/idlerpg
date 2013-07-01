package RenderSystem {
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.DisplayObject;
	import flash.display.Sprite;
	import flash.geom.Rectangle;
	import Game.Critter.CritterAnimationSet;
	import Game.Map.MapData;
	import Game.Map.WorldData;
	import WindowSystem.Fonts;
	import WindowSystem.ScreenText;
	
	/**
	 * ...
	 * @author Paul
	 */
	public class Renderman {
		private var map:MapRenderer;
		
		private static var AnimatedObjects:Vector.<IAnimated> = new Vector.<IAnimated>();
		public static var DirtyObjects:Vector.<IObjectLayer> = new Vector.<IObjectLayer>();
		
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
			
			MapText = new ScreenText(60, Fonts.Header);
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
			
			Main.OrderedLayer.scaleX = Camera.Z;
			Main.OrderedLayer.scaleY = Camera.Z;
		}
		
		public function Render(dt:Number):void {
			//Sort the children
			i = Main.OrderedLayer.numChildren;
			
			//Sort out all the dirty objects
			while (DirtyObjects.length > 0) {
				var obj:IObjectLayer = DirtyObjects.pop();
				
				i = Main.OrderedLayer.getChildIndex(obj as DisplayObject);
				
				if (i > 0 && TrySwap(i)) {
					i--;
					while (TrySwap(i--)) { }
				} else {
					i++;
					while (TrySwap(i++)) { }
				}
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
			} else if(Global.PrevLoadingTotal > 0 && Global.FadeOnLoad) {
				if (Global.LoadingTotal == 0) {
					FadeToWorld();
				}
			}
			
			if (Global.LoadingTotal > 0) return;
			if (WorldData.CurrentMap == null) return;
			
			var MyX:int = WorldData.ME.X;
			var MyY:int = WorldData.ME.Y;
			
			if (WorldData.CurrentMap.SizeX <= map.fullRect.width) {
				Camera.X = (map.fullRect.width - WorldData.CurrentMap.SizeX) / 2;
			} else if (MyX <= map.fullRect.width / 2) {
				Camera.X = 0;
			} else if (MyX > WorldData.CurrentMap.SizeX - map.fullRect.width / 2) {
				Camera.X = -WorldData.CurrentMap.SizeX + map.fullRect.width;
			} else {
				Camera.X = -MyX + map.fullRect.width / 2;
			}
			
			if (WorldData.CurrentMap.SizeY <= map.fullRect.height) {
				Camera.Y = (map.fullRect.height - WorldData.CurrentMap.SizeY) / 2;
			} else if (MyY <= map.fullRect.height / 2) {
				Camera.Y = 0;
			} else if (MyY > WorldData.CurrentMap.SizeY - map.fullRect.height / 2) {
				Camera.Y = -WorldData.CurrentMap.SizeY + map.fullRect.height;
			} else {
				Camera.Y = -MyY + map.fullRect.height / 2;
			}
			
			Main.OrderedLayer.x = Camera.X * Camera.Z;
			Main.OrderedLayer.y = Camera.Y * Camera.Z;
			map.DebugLayer.x = Camera.X * Camera.Z;
			map.DebugLayer.y = Camera.Y * Camera.Z;
			
			map.Draw();
			
			var i:int = AnimatedObjects.length;
			while (--i > -1) {
				AnimatedObjects[i].UpdateAnimation(dt);
			}
		}
		
		private function TrySwap(i:int):Boolean {
			var OrderedLayer:Sprite = Main.OrderedLayer;
			
			if (i < 1) return false;
			if (i >= OrderedLayer.numChildren) return false;
			
			if ((IObjectLayer)(OrderedLayer.getChildAt(i)).GetTrueY() < (IObjectLayer)(OrderedLayer.getChildAt(i-1)).GetTrueY()) {
				OrderedLayer.swapChildrenAt(i, i - 1);
				return true;
			}
			
			return false;
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