package WindowSystem 
{
	import flash.text.AntiAliasType;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	/**
	 * ...
	 * @author Paul
	 */
	public class Fonts {
		[Embed(source = "../../lib/VISITOR1.TTF", fontFamily = "_Gabriola", unicodeRange='U+0020-U+002F,U+0030-U+0039,U+003A-U+0040,U+0041-U+005A,U+005B-U+0060,U+0061-U+007A,U+007B-U+007E', mimeType='application/x-font', embedAsCFF='false')]
		private var EmbeddedFont:Class;
		
		public static const Header:String = "_Gabriola";
		public static const Debug:String = "Courier";
		
		public function Fonts() { };
		
		public static function GetTextField(fontSize:int, fontName:String):TextField {
			var tf:TextField = new TextField();
			tf.embedFonts = true;
			tf.antiAliasType = AntiAliasType.NORMAL;
			tf.autoSize = TextFieldAutoSize.LEFT;
			tf.selectable = false;
			tf.defaultTextFormat = new TextFormat(fontName, fontSize, 0xFFFFFF);
			
			tf.text = "";
			
			return tf;
		}
	}

}