package WindowSystem {
	import EngineTiming.Clock;
	import flash.display.Sprite;
	import flash.system.Capabilities;
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
			
			this.background = 0xFFFF00;
			
			UpdateInfo("0.0");
			
			Clock.FPSTF = this;
		}
		
		public function UpdateInfo(newFPS:String):void {
			text = "FPS:" + newFPS + "|DPI=" + Capabilities.screenDPI;
			
			if (Main.I != null && Main.I.stage != null) {
				appendText("|W=" + Main.I.stage.stageWidth + "|H=" + Main.I.stage.stageHeight + "|SX=" + Main.I.stage.scaleX + "|SY=" + Main.I.stage.scaleY);
				
				CONFIG::air {
					if(Main.I.stage.nativeWindow != null) {
						appendText("|WW=" + Main.I.stage.nativeWindow.width + "|WH=" + Main.I.stage.nativeWindow.height);
					}
				}
			}
		}
		
	}

}