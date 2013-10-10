package UI {
	import EngineTiming.Clock;
	import flash.display.Sprite;
	import flash.system.Capabilities;
	import flash.text.AntiAliasType;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	import Game.Map.WorldData;
	/**
	 * ...
	 * @author Paul
	 */
	public class FPSCounter extends TextField {
		
		public function FPSCounter() {
			super();
			
			Fonts.SetupTextFormat(this, 5, 20, 0x0);
			
			this.background = true;
			this.backgroundColor = 0xFFFF00;
			
			UpdateInfo("0.0");
			this.y = 80;
			
			Clock.FPSTF = this;
		}
		
		public function UpdateInfo(newFPS:String):void {
			text = "FPS:" + newFPS + "|DPI=" + Capabilities.screenDPI;
		}
		
	}

}