package Scripting {
	import flash.utils.ByteArray;
	import Loaders.BinaryLoader;
	import Storage.SaveManager;
	/**
	 * ...
	 * @author Paul
	 */
	public class GlobalVariables {
		public static var IntegerVariables:Vector.<int>;
		public static var Strings:Vector.<String>;
		public static var StringVariables:Vector.<String>;
		public static var Functions:Script;
		
		public static var IntegerIndices:Vector.<int>;
		public static var StringIndices:Vector.<int>;
		
		public static var DataID:int = 0;
		public static var StringDataID:int = 0;
		
		public static var LoadTotal:int = 0;
		private static const LOAD_SAVE_AMT:int = 2;
		
		public function GlobalVariables() {
			BinaryLoader.Load("Data/Variables.bin", LoadedVariables);
			BinaryLoader.Load("Data/StringVariables.bin", LoadedStringVariables);
			BinaryLoader.Load("Data/Strings.bin", LoadedStrings);
			BinaryLoader.Load("Data/Functions.bin", LoadedFunctions);
		}
		
		public function LoadedVariables(b:ByteArray):void {
			DataID = b.readShort();
			IntegerVariables = new Vector.<int>(b.readShort(), true);
			
			var i:int;
			for (i = 0; i < IntegerVariables.length; i++) {
				IntegerVariables[i] = b.readShort();
			}
			
			IntegerIndices = new Vector.<int>(b.readShort(), true);
			
			for (i = 0; i < IntegerIndices.length; i++) {
				IntegerIndices[i] = b.readShort();
			}
			
			LoadTotal++; if (LoadTotal == LOAD_SAVE_AMT) SaveManager.Load("");
		}
		
		public function LoadedStringVariables(b:ByteArray):void {
			StringDataID = b.readShort();
			StringVariables = new Vector.<String>(b.readShort(), true);
			
			var i:int;
			for (i = 0; i < StringVariables.length; i++) {
				StringVariables[i] = BinaryLoader.GetString(b);
			}
			
			StringIndices = new Vector.<int>(b.readShort(), true);
			
			for (i = 0; i < StringIndices.length; i++) {
				StringIndices[i] = b.readShort();
			}
			
			LoadTotal++; if (LoadTotal == LOAD_SAVE_AMT) SaveManager.Load("");
		}
		
		public function LoadedStrings(b:ByteArray):void {
			Strings = new Vector.<String>(b.readShort(), true);
			
			for (var i:int = 0; i < Strings.length; i++) {
				Strings[i] = BinaryLoader.GetString(b);
			}
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
			
			var _a:Vector.<int> = new Vector.<int>(0, true);
			var _b:Vector.<Number> = new Vector.<Number>(0, true);
			Functions = new Script(functions, _a, _b);
			_a = null;
			_b = null;
			
			if (b.position != b.length) {
				throw new Error("DID NOT FINISH READING THE SCRIPT!");
			} else {
				//TODO: this shouldn't be blank i think? why is there a lack of comments?
			}
		}
	}
}