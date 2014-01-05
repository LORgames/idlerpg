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
	public class UILayerBlackout extends UILayer {
		///VARIABLES
        public var Colour:int = 0;
		
		private var LB:Bitmap;	//Left
		private var TB:Bitmap;	//Top
		private var RB:Bitmap;	//Right
		private var BB:Bitmap;	//Bottom
		
		public function UILayerBlackout() {
			
		}
		
		public function Prepare():void {
			if (this.parent) {
				var bitmapData:BitmapData = new BitmapData(1, 1, true, Colour);
				LB = new Bitmap(bitmapData);
				RB = new Bitmap(bitmapData);
				TB = new Bitmap(bitmapData);
				BB = new Bitmap(bitmapData);
				
				this.parent.addChild(LB);
				this.parent.addChild(RB);
				this.parent.addChild(TB);
				this.parent.addChild(BB);
			}
		}
		
		public override function Draw(w:int, h:int, ui:UIManager):void {
			///////////////////////////////////////////// Update the position
			FixPosition();
			
			if (!this.parent) return;
			
			var X:int = -this.parent.x;
			var Y:int = -this.parent.y;
			var L:int = this.x - X;
            var R:int = L + SizeX;
            var T:int = this.y - Y;
            var B:int = T + SizeY;
			var W:int = Main.I.stage.stageWidth;
			var H:int = Main.I.stage.stageHeight;
			
			LB.x = X+0; LB.y = Y+0; LB.width = L - 0; LB.height = H - 0;
			RB.x = X+R; RB.y = Y+0; RB.width = W - R; RB.height = H - 0;
			TB.x = X+L; TB.y = Y+0; TB.width = R - L; TB.height = T - 0;
			BB.x = X+L; BB.y = Y+B; BB.width = R - L; BB.height = H - B;
		}
		
	}

}