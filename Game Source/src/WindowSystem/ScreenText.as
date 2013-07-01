package WindowSystem {
	import flash.display.Sprite;
	import flash.text.AntiAliasType;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	/**
	 * ...
	 * @author Paul
	 */
	public class ScreenText extends Sprite {
		private var tf:TextField;
		
		public function ScreenText(fontSize:int, fontName:String) {
			tf = new TextField();
			tf.embedFonts = true;
			tf.antiAliasType = AntiAliasType.NORMAL;
			tf.autoSize = TextFieldAutoSize.LEFT;
			tf.selectable = false;
			tf.defaultTextFormat = new TextFormat(fontName, fontSize, 0xFFFFFF);
			
			tf.text = "";
			
			addChild(tf);
		}
		
		public function UpdateText(text:String):void {
			tf.text = text;
		}
	}

}