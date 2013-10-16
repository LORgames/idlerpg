package UI {
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Matrix;
	import flash.geom.Rectangle;
	import Game.Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class UILayerLibrary extends UILayer {
		///VARIABLES
        public var Library:UILibrary;
		public var ID:int = 0;
		
		public function UILayerLibrary() {
			
		}
		
		public override function Draw(w:int, h:int, ui:UIManager):void {
			///////////////////////////////////////////// Update the position
			var thisArea:Rect = new Rect(false, null, 0, 0, SizeX, SizeY);
			
			FixPosition();
			
			///////////////////////////////////////////// Redraw if required
			//if (!RequiresRedraw) return;
			
			var bmpd:BitmapData = Library.ImageCutouts[ID];
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