package WindowSystem 
{
	import flash.display.Sprite;
	import flash.errors.StackOverflowError;
	import flash.text.TextField;
	/**
	 * ...
	 * @author Paul
	 */
	public class BaseWindow extends Sprite {
		
		private var tfNamePlate:TextField = new TextField();
		
		protected var reqSizeX:int = 0;
		protected var reqSizeY:int = 0;
		
		protected const BORDER_WIDTH:int = 10;
		protected const LINE_WIDTH:int = 3;
		protected const LINE_COLOUR:int = 0x393535;
		protected const BG_COLOUR:int = 0x6E5C42;
		
		public var AlwaysOnTop:Boolean = false;
		public var Moveable:Boolean = false;
		
		public function BaseWindow() {
			tfNamePlate.selectable = false;
			tfNamePlate.text = "Unnamed Window";
		}
		
		protected function SetWindowTitle(name:String):void {
			tfNamePlate.text = name;
		}
		
		protected function FullRedraw():void {
			this.graphics.clear();
			
			this.graphics.lineStyle(LINE_WIDTH, LINE_COLOUR);
			
			this.graphics.beginFill(BG_COLOUR);
			this.graphics.drawRoundRect( -BORDER_WIDTH, -(BORDER_WIDTH + tfNamePlate.height), reqSizeX + BORDER_WIDTH * 2, reqSizeY + BORDER_WIDTH * 2 + tfNamePlate.height, BORDER_WIDTH / 2);
			this.graphics.endFill();
		}
		
		public function Update(dt:Number):void {
			
		}
		
	}

}