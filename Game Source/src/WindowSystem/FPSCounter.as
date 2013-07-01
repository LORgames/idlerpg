package WindowSystem {
	import EngineTiming.Clock;
	import flash.display.Sprite;
	import flash.text.AntiAliasType;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	/**
	 * ...
	 * @author Paul
	 */
	public class FPSCounter extends TextField {
		
		public function FPSCounter() {
			super();
			autoSize = TextFieldAutoSize.LEFT;
			selectable = false;
			defaultTextFormat = new TextFormat(Fonts.Debug, 20, 0x000000);
			
			text = "FPS:0.0";
			
			Clock.FPSTF = this;
		}
		
	}

}