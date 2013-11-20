package UI {
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Matrix;
	import flash.geom.Rectangle;
	import Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class UILayerImage extends UILayer {
		///VARIABLES
        public var GlobalVariable:int = 0;
		public var ImageRect:int = 0;
		
		public function UILayerImage() {
			
		}
		
		public override function Draw(w:int, h:int, ui:UIManager):void {
			///////////////////////////////////////////// Update the position
			var thisArea:Rect = new Rect(false, null, 0, 0, SizeX, SizeY);
			var displayValue:Number = GlobalVariables.Variables[GlobalVariable]/100.0;
			
			pw = w;
			ph = h;
			FixPosition();
			
			//Special Layer Types
			if (LayerType == StretchToValueXNeg) {
				this.x += (int)((1 - displayValue) * SizeX);
			} else if (LayerType == StretchToValueYNeg) {
				this.y += (int)((1 - displayValue) * SizeY);
			} else if (LayerType == PanX) {
				this.x += (int)(SizeX * displayValue);
			} else if (LayerType == PanY) {
				this.y += (int)(SizeY * displayValue);
			} else if (LayerType == PanXNeg) {
				this.x += (int)(SizeX * (1 - displayValue));
			} else if (LayerType == PanYNeg) {
				this.y += (int)(SizeY * (1 - displayValue));
			}
			
			///////////////////////////////////////////// Redraw if required
			if (!RequiresRedraw) return;
			
			if (LayerType == StretchToValueX || LayerType == StretchToValueXNeg) {
				thisArea.W = (int)(displayValue * SizeX);
			} if (LayerType == StretchToValueY || LayerType == StretchToValueYNeg) {
				thisArea.H = (int)(displayValue * SizeY);
			}
			
			var bmpd:BitmapData = ui.ImageCutouts[ImageRect];
			var m:Matrix = new Matrix();
			
			if (LayerType == Stretch || LayerType == StretchToValueX || 
				LayerType == StretchToValueY || LayerType == StretchToValueXNeg ||
				LayerType == StretchToValueYNeg) {
					if (this.bitmapData == null) {
						this.bitmapData = new BitmapData(SizeX, SizeY, true, 0x0);
						RedrawRect = new Rectangle(0, 0, SizeX, SizeY);
					}
					
					this.bitmapData.fillRect(RedrawRect, 0x0);
					
					m.scale(thisArea.W / bmpd.width, thisArea.H / bmpd.height);
					this.bitmapData.draw(bmpd, m);
					
					if (LayerType == Stretch) {
						RequiresRedraw = false;
					}
			} else if (LayerType == Static || LayerType == PanX || LayerType == PanY || LayerType == PanXNeg || LayerType == PanYNeg) {
				this.bitmapData = new BitmapData(Math.min(bmpd.width, thisArea.W), Math.min(bmpd.height, thisArea.H), true, 0x0);
				this.bitmapData.draw(bmpd, m);
				RequiresRedraw = false;
			} else if (LayerType == Tile) {
				//TODO: Cannot draw 'tile' types easily?
				RequiresRedraw = false;
			}
		}
		
	}

}