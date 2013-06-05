package WindowSystem {
	import flash.display.Sprite;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import Interfaces.IObjectLayer;
	import Interfaces.IUpdatable;
	import org.flashdevelop.utils.FlashConnect;
	/**
	 * ...
	 * @author Paul
	 */
	public class ScreenText extends Sprite {
		private var tf:TextField;
		
		public function ScreenText() {
			
			tf = new TextField()
			tf.text = "";
			tf.textColor = 0xFFFFFF;
			tf.backgroundColor = 0x000000;
			tf.background = true;
			tf.autoSize = TextFieldAutoSize.CENTER;
			tf.width = Main.I.stage.stageWidth*2;
			addChild(tf);
		}
		
		public function UpdateText(text:String):void {
			tf.text = text;
		}
	}

}