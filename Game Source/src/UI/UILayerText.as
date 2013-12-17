package UI {
	import adobe.utils.CustomActions;
	import CollisionSystem.Rect;
	import flash.display.Bitmap;
	import flash.display.BitmapData;
	import flash.display.Sprite;
	import flash.display.StageQuality;
	import flash.events.Event;
	import flash.geom.Matrix;
	import flash.geom.Rectangle;
	import flash.text.AntiAliasType;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFieldType;
	import flash.text.TextFormat;
	import Scripting.GlobalVariables;
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
		
		public var EditMode:int = 0;
		public var StringID:int = 0;
		
		public function UILayerText() {
			
		}
		
		public function PrepareTF():void {
			tf = Fonts.GetTextField(FontSize, FontFamily, Colour);
			
			if (WordWrap) {
				tf.multiline = true;
				tf.wordWrap = true;
				tf.width = SizeX;
			}
			
			RequiresRedraw = true;
			tf.text = Message.GetBuilt();
			
			if (EditMode != 0) {
				StringID = parseInt(tf.text);
				
				if (this.parent) {
					this.parent.addChildAt(tf, this.parent.getChildIndex(this));
					this.parent.removeChild(this);
					tf.selectable = true;
					tf.type = TextFieldType.INPUT;
					tf.text = GlobalVariables.StringVariables[StringID];
					tf.addEventListener(Event.CHANGE, Changed, false, 0, true);
				}
			}
		}
		
		private function Changed(e:Event):void {
			if (EditMode > 0 && StringID != 0) {
				GlobalVariables.StringVariables[StringID] = tf.text;
			}
		}
		
		public override function Draw(w:int, h:int, ui:UIManager):void {
			if (tf == null) return;
			
			var newMessage:String = Message.GetBuilt();
			if (!RequiresRedraw && tf.text == newMessage) return;
			
			RequiresRedraw = false;
			tf.text = newMessage;
			
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
			
			///////////////////////////////////////////// Redraw if required
			if(EditMode == 0) {
				Main.I.stage.quality = StageQuality.BEST;
				this.bitmapData = new BitmapData(tf.width*1.02, tf.height, true, 0x0);
				Main.I.stage.quality = StageQuality.LOW;
				this.bitmapData.draw(tf);
			} else {
				tf.x = this.x;
				tf.y = this.y;
			}
		}
	}
}