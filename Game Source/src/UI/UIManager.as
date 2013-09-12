package UI {
	import adobe.utils.CustomActions;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Rectangle;
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Game.General.ImageLoader;
	import Game.Scripting.Script;
	/**
	 * ...
	 * @author Paul
	 */
	public class UIManager extends Sprite {
		public var Panels:Vector.<UIPanel>;
		public var ImageCutouts:Vector.<BitmapData>;
		public var TextureAtlas:BitmapData;
		
		public function UIManager() {
			ImageLoader.Load("Data/UIAtlas.png", LoadedAtlas);
			Global.LoadingTotal++;
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
					Panels[i].Elements[j].MyScript = Script.ReadScript(b);
					
					var totalLayers:int = b.readByte();
					Panels[i].Elements[j].Layers = new Vector.<UILayer>(totalLayers, true);
					
					//Load in UILayers
					for (var k:int = 0; k < totalLayers; k++) {
						Panels[i].Elements[j].Layers[k] = new UILayer();
						Panels[i].Elements[j].addChild(Panels[i].Elements[j].Layers[k]);
						
						Panels[i].Elements[j].Layers[k].AnchorPoint = b.readByte();
						Panels[i].Elements[j].Layers[k].OffsetX = b.readShort();
						Panels[i].Elements[j].Layers[k].OffsetY = b.readShort();
						Panels[i].Elements[j].Layers[k].SizeX = b.readShort();
						Panels[i].Elements[j].Layers[k].SizeY = b.readShort();
						
						Panels[i].Elements[j].Layers[k].LayerType = b.readByte();
						Panels[i].Elements[j].Layers[k].GlobalVariable = b.readShort();
						Panels[i].Elements[j].Layers[k].ImageRect = b.readShort();
					}
				}
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
			Global.LoadingTotal--;
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
		
		public function AlertPress(x:int, y:int):void {
			
		}
		
	}

}