package UI {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.geom.Matrix;
	import flash.geom.Rectangle;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	import Game.Scripting.GlobalVariables;
	import Strings.StringEx;
	/**
	 * ...
	 * @author Paul
	 */
	public class UILayerText extends UILayer {
		
		///VARIABLES
        public var Message:StringEx;
		private var LastMessage:String = "";
		private var tf:TextField;
		
		public function UILayerText() {
			
		}
		
		public function PrepareTF():void {
			tf = new TextField();
			tf.selectable = false;
			tf.setTextFormat(new TextFormat("Verdana", 10, 0xFFFFFF));
			tf.autoSize = TextFieldAutoSize.LEFT;
			tf.text = Message.GetBuilt();
		}
		
		public override function Draw(w:int, h:int, ui:UIManager):void {
			if (tf == null) return;
			
			///////////////////////////////////////////// Update the position
			var thisArea:Rect = new Rect(false, null, 0, 0, tf.width, tf.height);
			
			//Calculate X
			switch (AnchorPoint) {
				case UIAnchorPoint.BottomLeft: case UIAnchorPoint.MiddleLeft: case UIAnchorPoint.TopLeft: //Left
					this.x = OffsetX; break;
				case UIAnchorPoint.BottomRight: case UIAnchorPoint.MiddleRight: case UIAnchorPoint.TopRight: //Right
					this.x = w - SizeX - OffsetX; break;
				default:
					this.x = (w - SizeX)/2 + OffsetX; break;
			}
			
			//Calculate Y
			switch (AnchorPoint) {
				case UIAnchorPoint.BottomLeft:case UIAnchorPoint.BottomCenter:case UIAnchorPoint.BottomRight: //Bottom
					this.y = h - SizeY - OffsetY; break;
				case UIAnchorPoint.TopLeft: case UIAnchorPoint.TopCenter: case UIAnchorPoint.TopRight: //Top
					this.y = OffsetY; break;
				default:
					this.y = (h-SizeY)/2 + OffsetY; break;
			}
			
			//Special Layer Types
			/*if (LayerType == PanX) {
				this.x += (int)(SizeX * displayValue);
			} else if (LayerType == PanY) {
				this.y += (int)(SizeY * displayValue);
			} else if (LayerType == PanXNeg) {
				this.x += (int)(SizeX * (1 - displayValue));
			} else if (LayerType == PanYNeg) {
				this.y += (int)(SizeY * (1 - displayValue));
			}*/
			
			///////////////////////////////////////////// Redraw if required
			//if (!RequiresRedraw) return;
			
			tf.text = Message.GetBuilt();
			this.bitmapData = new BitmapData(tf.width, tf.height, true, 0x00);
			this.bitmapData.draw(tf);
		}
		
	}

}