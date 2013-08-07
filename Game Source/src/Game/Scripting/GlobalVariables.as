package Game.Scripting {
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	/**
	 * ...
	 * @author Paul
	 */
	public class GlobalVariables {
		
		public static var Variables:Vector.<int>;
		public static var Strings:Vector.<String>;
		
		public function GlobalVariables() {
			Global.LoadingTotal += 2;
			
			BinaryLoader.Load("Data\\Variables.bin", LoadedVariables);
			BinaryLoader.Load("Data\\Strings.bin", LoadedStrings);
		}
		
		public function LoadedVariables(b:ByteArray):void {
			Variables = new Vector.<int>(b.readShort(), true);
			
			for (var i:int = 0; i < Variables.length; i++) {
				Variables[i] = b.readShort();
			}
			
			Global.LoadingTotal--;
		}
		
		public function LoadedStrings(b:ByteArray):void {
			Strings = new Vector.<String>(b.readShort(), true);
			
			for (var i:int = 0; i < Strings.length; i++) {
				Strings[i] = BinaryLoader.GetString(b);
			}
			
			Global.LoadingTotal--;
		}
		
	}

}