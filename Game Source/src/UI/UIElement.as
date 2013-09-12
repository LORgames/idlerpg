package UI 
{
	import CollisionSystem.Rect;
	import flash.display.Sprite;
	import Game.Scripting.Script;
	/**
	 * ...
	 * @author Paul
	 */
	public class UIElement extends Sprite {
        public var Layers:Vector.<UILayer>;
        public var OffsetX:int = 0;
        public var OffsetY:int = 0;
        public var AnchorPoint:int = 0;
        public var SizeX:int = 0;
        public var SizeY:int = 0;
        public var MyScript:Script;
		
		public function UIElement() {
			
		}
		
		public function Draw(w:int, h:int, ui:UIManager):void {
            //Calculate X
            switch (AnchorPoint) {
                case UIAnchorPoint.BottomLeft:
                case UIAnchorPoint.MiddleLeft:
                case UIAnchorPoint.TopLeft:
                    this.x = OffsetX;
                    break;
                case UIAnchorPoint.BottomRight:
                case UIAnchorPoint.MiddleRight:
                case UIAnchorPoint.TopRight:
                    this.x = w - SizeX - OffsetX;
                    break;
                default:
                    this.x = (w - SizeX) / 2;
                    break;
            }
            
            //Calculate Y
            switch (AnchorPoint) {
                case UIAnchorPoint.BottomLeft:
                case UIAnchorPoint.BottomCenter:
                case UIAnchorPoint.BottomRight:
                    this.y = h - SizeY - OffsetY;
                    break;
                case UIAnchorPoint.TopLeft:
                case UIAnchorPoint.TopCenter:
                case UIAnchorPoint.TopRight:
                    this.y = OffsetY;
                    break;
                default:
                    this.y = (h - SizeY) / 2;
                    break;
            }
			
			//Draw Layers
			var i:int = Layers.length;
            while (--i > -1) {
				Layers[i].Draw(SizeX, SizeY, ui);
			}
        }
		
		
	}

}