package UI {
	import flash.text.AntiAliasType;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	/**
	 * ...
	 * @author Paul
	 */
	public class Fonts {
		[Embed(source = "../../lib/Bangers.TTF", fontFamily = "_FONT_3", unicodeRange='U+0020-U+002F,U+0030-U+0039,U+003A-U+0040,U+0041-U+005A,U+005B-U+0060,U+0061-U+007A,U+007B-U+007E', mimeType='application/x-font', embedAsCFF='false')] private var EmbeddedFont3:Class;
		[Embed(source = "../../lib/Visitor1.TTF", fontFamily = "_FONT_5", unicodeRange='U+0020-U+002F,U+0030-U+0039,U+003A-U+0040,U+0041-U+005A,U+005B-U+0060,U+0061-U+007A,U+007B-U+007E', mimeType='application/x-font', embedAsCFF='false')] private var EmbeddedFont5:Class;
		
		public function Fonts() { };
		
		public static function GetTextField(fontSize:int, fontNumber:int, colour:int = 0xFFFFFF):TextField {
			var tf:TextField = new TextField();
			tf.embedFonts = true;
			tf.antiAliasType = AntiAliasType.NORMAL;
			tf.autoSize = TextFieldAutoSize.LEFT;
			tf.selectable = false;
			tf.defaultTextFormat = new TextFormat("_FONT_"+fontNumber, fontSize, colour);
			
			tf.text = "";
			
			return tf;
		}
		
		public static function SetupTextFormat(tf:TextField, fontNumber:int, fontSize:int, colour:int):void {
			tf.embedFonts = true;
			tf.antiAliasType = AntiAliasType.NORMAL;
			tf.autoSize = TextFieldAutoSize.LEFT;
			tf.selectable = false;
			tf.defaultTextFormat = new TextFormat("_FONT_"+fontNumber, fontSize, colour);
		}
	}
}