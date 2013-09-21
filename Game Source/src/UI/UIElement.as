package UI 
{
	import Game.Critter.BaseCritter;
	import CollisionSystem.PointX;
	import CollisionSystem.Rect;
	import Debug.Drawer;
	import flash.display.Sprite;
	import Game.Scripting.IScriptTarget;
	import Game.Scripting.Script;
	import Game.Scripting.ScriptInstance;
	/**
	 * ...
	 * @author Paul
	 */
	public class UIElement extends Sprite implements IScriptTarget {
        public var Layers:Vector.<UILayer>;
        public var OffsetX:int = 0;
        public var OffsetY:int = 0;
        public var AnchorPoint:int = 0;
        public var SizeX:int = 0;
        public var SizeY:int = 0;
        public var _script:Script;
        public var MyScript:ScriptInstance;
		
		public var SupportsTouch:Boolean = false;
		
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
                    this.x = (w - SizeX) / 2 + OffsetX;
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
                    this.y = (h - SizeY) / 2 + OffsetY;
                    break;
            }
			
			//Draw Layers
			var i:int = Layers.length;
            while (--i > -1) {
				Layers[i].Draw(SizeX, SizeY, ui);
			}
        }
		
		public function Contains(x:int, y:int):Boolean {
			if (x < this.x) return false;
			if (y < this.y) return false;
			if (x > this.x + SizeX) return false;
			if (y > this.y + SizeY) return false;
			
			return true;
		}
		
		/* INTERFACE Game.Scripting.IScriptTarget */
		public function UpdatePointX(position:PointX):void {
			position.X = x;
			position.Y = y;
		}
		
		public function AlertMinionDeath(baseCritter:BaseCritter):void {
			//how even?
		}
		
		public function ChangeState(stateID:int, isLooping:Boolean):void {
			//ok?
		}
		
		public function UpdatePlaybackSpeed(newAnimationSpeed:Number):void {
			//Cool cool
		}
		
		public function GetCurrentState():int {
			return 0;
		}
		
		public function GetFaction():int {
			return 0;
		}
	}

}