package UI {
	import flash.display.Bitmap;
	import flash.geom.Rectangle;
	/**
	 * ...
	 * @author Paul
	 */
	public class UILayer extends Bitmap {
		///CONSTANTS
        public static const Static:int = 0;
        public static const Tile:int = 1;
        public static const Stretch:int = 2;
        public static const StretchToValueX:int = 3;
        public static const StretchToValueY:int = 4;
        public static const StretchToValueXNeg:int = 5;
        public static const StretchToValueYNeg:int = 6;
        public static const PanX:int = 7;
        public static const PanY:int = 8;
        public static const PanXNeg:int = 9;
        public static const PanYNeg:int = 10;
        public static const Radial:int = 11;
		
		///VARIABLES
		public var LayerType:int = 0;
		public var AnchorPoint:int = 0;
		
		public var SizeX:int = 0;
		public var SizeY:int = 0;
		public var OffsetX:int = 0;
		public var OffsetY:int = 0;
		
		protected var RequiresRedraw:Boolean = true;
		protected var RedrawRect:Rectangle;
		
		public static var pw:int; //Stage Width
		public static var ph:int; //Stage Height
		
		public function UILayer() {
			
		}
		
		public function Draw(w:int, h:int, ui:UIManager):void {
			
		}
		
		public function FixPosition():void {
			//Calculate X
			switch (AnchorPoint) {
				case UIAnchorPoint.BottomLeft: case UIAnchorPoint.MiddleLeft: case UIAnchorPoint.TopLeft: //Left
					this.x = OffsetX; break;
				case UIAnchorPoint.BottomRight: case UIAnchorPoint.MiddleRight: case UIAnchorPoint.TopRight: //Right
					this.x = pw - SizeX - OffsetX; break;
				default:
					this.x = (pw - SizeX)/2 + OffsetX; break;
			}
			
			//Calculate Y
			switch (AnchorPoint) {
				case UIAnchorPoint.BottomLeft:case UIAnchorPoint.BottomCenter:case UIAnchorPoint.BottomRight: //Bottom
					this.y = ph - SizeY - OffsetY; break;
				case UIAnchorPoint.TopLeft: case UIAnchorPoint.TopCenter: case UIAnchorPoint.TopRight: //Top
					this.y = OffsetY; break;
				default:
					this.y = (ph-SizeY)/2 + OffsetY; break;
			}
		}
	}
}