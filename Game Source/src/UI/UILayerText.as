package UI {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.display.StageQuality;
	import flash.geom.Matrix;
	import flash.geom.Rectangle;
	import flash.text.AntiAliasType;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	import Game.Scripting.GlobalVariables;
	import Strings.StringEx;
	import UI.Fonts;
	/**
	 * ...
	 * @author Paul
	 */
	public class UILayerText extends UILayer {
		
		///VARIABLES
        public var Message:StringEx;
		private var LastMessage:String = "";
		private var tf:TextField;
		
		public var Colour:int = 0;
		public var Align:int = 0;
		public var FontSize:int = 0;
		public var FontFamily:int = 0;
		public var WordWrap:Boolean = false;
		
		public function UILayerText() {
			
		}
		
		public function PrepareTF():void {
			tf = Fonts.GetTextField(FontSize, 3, Colour);
			
			if (WordWrap) {
				//tf.autoSize = TextFieldAutoSize.NONE;
				tf.multiline = true;
				tf.wordWrap = true;
				tf.width = SizeX;
			}
			
			tf.text = Message.GetBuilt();
		}
		
		public override function Draw(w:int, h:int, ui:UIManager):void {
			if (tf == null) return;
			
			///////////////////////////////////////////// Update the position
			var thisArea:Rect = new Rect(false, null, 0, 0, tf.width, tf.height);
			
			//Calculate X
			switch (AnchorPoint) {
				case UIAnchorPoint.BottomLeft: case UIAnchorPoint.MiddleLeft: case UIAnchorPoint.TopLeft:
					this.x = OffsetX; break;
				case UIAnchorPoint.BottomRight: case UIAnchorPoint.MiddleRight: case UIAnchorPoint.TopRight:
					this.x = w - SizeX - OffsetX; break;
				default:
					this.x = (w - SizeX) / 2 + OffsetX; break;
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
			
			//Calculate X
                switch (Align) {
                    case UIAnchorPoint.BottomCenter: case UIAnchorPoint.MiddleCenter: case UIAnchorPoint.TopCenter:
                        if (WordWrap) {
							tf.autoSize = TextFieldAutoSize.CENTER;
                        } else {
                            this.x -= tf.width / 2;
                        }
                        break;
                    case UIAnchorPoint.BottomRight: case UIAnchorPoint.MiddleRight: case UIAnchorPoint.TopRight:
                        if (WordWrap) {
							tf.autoSize = TextFieldAutoSize.RIGHT;
                        } else {
                            this.x -= tf.width;
                        }
                        break;
                }
			
			//Calculate Y
			switch (Align) {
				case UIAnchorPoint.BottomLeft: case UIAnchorPoint.BottomCenter: case UIAnchorPoint.BottomRight:
					this.y -= tf.height; break;
				case UIAnchorPoint.MiddleLeft: case UIAnchorPoint.MiddleCenter: case UIAnchorPoint.MiddleRight:
					this.y -= tf.height / 2; break;
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
			Main.I.stage.quality = StageQuality.BEST;
			this.bitmapData = new BitmapData(tf.width, tf.height, true, 0x00);
			Main.I.stage.quality = StageQuality.LOW;
			this.bitmapData.draw(tf);
		}
		
	}

}