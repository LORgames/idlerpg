package Game.Scripting {
	import flash.utils.ByteArray;
	import Game.General.BinaryLoader;
	import Storage.SaveManager;
	/**
	 * ...
	 * @author Paul
	 */
	public class GlobalVariables {
		public static var Variables:Vector.<int>;
		public static var Strings:Vector.<String>;
		public static var Functions:Script;
		
		public function GlobalVariables() {
			Global.LoadingTotal += 3;
			
			BinaryLoader.Load("Data\\Variables.bin", LoadedVariables);
			BinaryLoader.Load("Data\\Strings.bin", LoadedStrings);
			BinaryLoader.Load("Data\\Functions.bin", LoadedFunctions);
		}
		
		public function LoadedVariables(b:ByteArray):void {
			Variables = new Vector.<int>(b.readShort(), true);
			
			for (var i:int = 0; i < Variables.length; i++) {
				Variables[i] = b.readShort();
			}
			
			SaveManager.Load("");
			
			Global.LoadingTotal--;
		}
		
		public function LoadedStrings(b:ByteArray):void {
			Strings = new Vector.<String>(b.readShort(), true);
			
			for (var i:int = 0; i < Strings.length; i++) {
				Strings[i] = BinaryLoader.GetString(b);
			}
			
			Global.LoadingTotal--;
		}
		
		public function LoadedFunctions(b:ByteArray):void {
			var functions:Vector.<ByteArray> = new Vector.<ByteArray>(b.readShort(), true);
			
			var scriptI:int = 0;
			var readChar:int = 0;
			
			if(functions.length > 0) {
				while(true) {
					if (functions[scriptI] == null) {
						functions[scriptI] = new ByteArray();
					}
					
					readChar = b.readUnsignedShort();
					functions[scriptI].writeShort(readChar);
					
					if (readChar == 0xFFFF) {
						scriptI++;
						if (scriptI == functions.length) break;
					}
				}
			}
			
			Functions = new Script(functions, new Vector.<int>(0, true));
			
			if (b.position != b.length) {
				throw new Error("DID NOT FINISH READING THE SCRIPT!");
			} else {
				
			}
			
			Global.LoadingTotal--;
		}
	}
}