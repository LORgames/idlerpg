package UI {
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Rectangle;
	import flash.security.XMLSignatureEnvelopedTransformer;
	import flash.utils.ByteArray;
	import Loaders.BinaryLoader;
	import Loaders.ImageLoader;
	import Game.Map.ScriptRegion;
	import Game.Map.WorldData;
	import Scripting.GlobalVariables;
	import Scripting.Script;
	import Scripting.ScriptInstance;
	import RenderSystem.Camera;
	import Strings.StringEx;
	/**
	 * ...
	 * @author Paul
	 */
	public class UIManager extends Sprite {
		public var Panels:Vector.<UIPanel>;
		public var ImageCutouts:Vector.<BitmapData>;
		public var TextureAtlas:BitmapData;
		
		public var Libraries:Vector.<UILibrary>;
		
		public function UIManager() {
			BinaryLoader.Load("Data/UILibrary.bin", ParseLibraries);
		}
		
		public function ParseLibraries(b:ByteArray):void {
			var totalLibraries:int = b.readShort();
			
			Libraries = new Vector.<UILibrary>(totalLibraries, true);
			
			for (var i:int = 0; i < totalLibraries; i++) {
				Libraries[i] = new UILibrary(b, i);
			}
			
			ImageLoader.Load("Data/UIAtlas.png", LoadedAtlas);
			//Not counting up or down the Global.LoadingTotal because it would be -1 and +1
		}
		
		public function LoadedAtlas(b:BitmapData):void {
			TextureAtlas = b.clone();
			BinaryLoader.Load("Data/UI.bin", ParseUI);
			//Not counting up or down the Global.LoadingTotal because it would be -1 and +1
		}
		
		public function ParseUI(b:ByteArray):void {
			var totalPanels:int = b.readByte();
			Panels = new Vector.<UIPanel>(totalPanels, true);
			
			//Load in UIPanels
			for (var i:int = 0; i < totalPanels; i++) {
				Panels[i] = new UIPanel();
				this.addChild(Panels[i]);
				
				Panels[i].visible = (b.readByte() == 1);
				
				var totalElements:int = b.readByte();
				Panels[i].Elements = new Vector.<UIElement>(totalElements, true);
				
				//Load in UIElements
				for (var j:int = 0; j < totalElements; j++) {
					Panels[i].Elements[j] = new UIElement();
					Panels[i].addChild(Panels[i].Elements[j]);
					
					Panels[i].Elements[j].AnchorPoint = b.readByte();
					Panels[i].Elements[j].OffsetX = b.readShort();
					Panels[i].Elements[j].OffsetY = b.readShort();
					Panels[i].Elements[j].SizeX = b.readShort();
					Panels[i].Elements[j].SizeY = b.readShort();
					Panels[i].Elements[j]._script = Script.ReadScript(b);
					Panels[i].Elements[j].MyScript = new ScriptInstance(Panels[i].Elements[j]._script, Panels[i].Elements[j], true);
					
					//Does the element have Press or PressAndDrag support.
					if (Panels[i].Elements[j]._script.HasEvent(Script.Attack) || Panels[i].Elements[j]._script.HasEvent(Script.Use)) {
						Panels[i].Elements[j].SupportsTouch = true;
						Panels[i].HasTouchElements = true;
					}
					
					var totalLayers:int = b.readByte();
					Panels[i].Elements[j].Layers = new Vector.<UILayer>(totalLayers, true);
					
					//Load in UILayers
					for (var k:int = 0; k < totalLayers; k++) {
						var layerType:int = b.readByte();
						
						if (layerType == 0) Panels[i].Elements[j].Layers[k] = new UILayerImage();
						if (layerType == 1) Panels[i].Elements[j].Layers[k] = new UILayerText();
						if (layerType == 2) Panels[i].Elements[j].Layers[k] = new UILayerLibrary(Panels[i].Elements[j]);
						Panels[i].Elements[j].addChild(Panels[i].Elements[j].Layers[k]);
						
						Panels[i].Elements[j].Layers[k].AnchorPoint = b.readByte();
						Panels[i].Elements[j].Layers[k].OffsetX = b.readShort();
						Panels[i].Elements[j].Layers[k].OffsetY = b.readShort();
						Panels[i].Elements[j].Layers[k].SizeX = b.readShort();
						Panels[i].Elements[j].Layers[k].SizeY = b.readShort();
						
						Panels[i].Elements[j].Layers[k].LayerType = b.readByte();
						
						if(layerType == 0) {
							(Panels[i].Elements[j].Layers[k] as UILayerImage).GlobalVariable = b.readShort();
							(Panels[i].Elements[j].Layers[k] as UILayerImage).ImageRect = b.readShort();
						} else if (layerType == 1) {
							(Panels[i].Elements[j].Layers[k] as UILayerText).Message = StringEx.BuildFromCore(BinaryLoader.GetString(b));
							
							(Panels[i].Elements[j].Layers[k] as UILayerText).Colour = b.readInt();
							(Panels[i].Elements[j].Layers[k] as UILayerText).Align = b.readByte();
							(Panels[i].Elements[j].Layers[k] as UILayerText).FontSize = b.readByte();
							(Panels[i].Elements[j].Layers[k] as UILayerText).FontFamily = b.readByte();
							(Panels[i].Elements[j].Layers[k] as UILayerText).WordWrap = b.readByte() == 1;
							
							(Panels[i].Elements[j].Layers[k] as UILayerText).PrepareTF();
						} else if (layerType == 2) {
							(Panels[i].Elements[j].Layers[k] as UILayerLibrary).Library = Libraries[b.readShort()];
							(Panels[i].Elements[j].Layers[k] as UILayerLibrary).ID = b.readShort();
						}
					}
				}
				
				//Run element spawn scripts
				//i = Panels.length;
				//while(--i > -1) {
				//	j = Panels[i].Elements.length;
				//	while (--j > -1) {
				//		Panels[i].Elements[j].MyScript.Run(Script.Initialize);
				//	}
				//}
			}
			
			var totalRects:int = b.readShort();
			ImageCutouts = new Vector.<BitmapData>(totalRects, true);
			
			for (var l:int = 0; l < totalRects; l++) {
				var r:Rectangle = new Rectangle(b.readShort(), b.readShort(), b.readShort(), b.readShort());
				var bmpd:BitmapData = new BitmapData(r.width, r.height, true, 0x0);
				bmpd.copyPixels(TextureAtlas, r, Global.ZeroPoint);
				
				ImageCutouts[l] = bmpd;
			}
			
			if (Global.DebugFPS) this.addChild(new FPSCounter());
			Resized();
		}
		
		public function Resized():void {
			if(Panels != null) {
				var i:int = Panels.length;
				var w:int = Main.I.stage.stageWidth;
				var h:int = Main.I.stage.stageHeight;
				
				while (--i > -1) {
					Panels[i].Draw(w, h, this);
				}
			}
		}
		
		public function AlertPress(x:int, y:int, dragged:Boolean = false):void {
			var wx:int = (x - Camera.X) / Camera.Z;
			var wy:int = (y - Camera.Y) / Camera.Z;
			
			GlobalVariables.Variables[Global.GV_WX] = wx;
			GlobalVariables.Variables[Global.GV_WY] = wy;
			
			var i:int = Panels.length;
			var j:int;
			
			//Trying UI first
			while (--i > -1) {
				if (!Panels[i].visible || !Panels[i].HasTouchElements) {
					continue;
				}
				
				j = Panels[i].Elements.length;
				
				while (--j > -1) {
					if (!Panels[i].Elements[j].SupportsTouch) {
						continue;
					}
					
					if (Panels[i].Elements[j].Contains(x, y)) {
						if(!dragged) {
							Panels[i].Elements[j].MyScript.Run(Script.Pressed);
						} else {
							Panels[i].Elements[j].MyScript.Run(Script.Use);
						} return;
					}
				}
			}
			
			//Try script regions as well, much more complicated though.
			if (WorldData.CurrentMap.ScriptRegions == null) return;
			i = WorldData.CurrentMap.ScriptRegions.length;
			
			while (--i > -1) {
				var s:ScriptRegion = WorldData.CurrentMap.ScriptRegions[i];
				if ((dragged && !s.SupportsDrag) || (!dragged && !s.SupportsPress)) {
					continue;
				}
				
				j = s.Area.length;
				
				while(--j > -1) {
					if (s.Area[j].ContainsPoint(wx, wy)) {
						if(!dragged) {
							s.MyScript.Run(Script.Pressed); //Press
						} else {
							s.MyScript.Run(Script.Use); //PressAndDrag
						} return;
					}
				}
			}
		}
		
		public function AlertUnpress(x:int, y:int):void {
			
		}
		
	}

}