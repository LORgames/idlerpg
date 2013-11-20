package Game.Data {
	import adobe.utils.CustomActions;
	import flash.utils.ByteArray;
	import Loaders.BinaryLoader;
	/**
	 * ...
	 * @author ...
	 */
	public class DataManager {
		public static var I:DataManager;
		
		private var ints:Vector.<int> = new Vector.<int>();
		private var strings:Vector.<String> = new Vector.<String>();
		private var floats:Vector.<Number> = new Vector.<Number>();
		
		private var startID_DB:Vector.<int> = new Vector.<int>();
		private var startID_Rows:Vector.<int> = new Vector.<int>();
		private var typeID_Cols:Vector.<int> = new Vector.<int>();
		
		public function DataManager() {
			I = this;
			BinaryLoader.Load("Data/Databases.bin", ParseDatabases);
		}
		
		public function ParseDatabases(b:ByteArray):void {
			var totalLibraries:int = b.readShort();
			var totalColumns:int = 0;
			var totalRows:int = 0;
			
			var i:int = 0;
			var j:int = 0;
			var k:int = 0;
			
			for (i = 0; i < totalLibraries; i++) {
				totalColumns = b.readShort();
				totalRows = b.readShort();
				
				startID_DB.push(startID_Rows.length);
				
				for (j = 0; j < totalColumns; j++) {
					var type:int = b.readByte();
					typeID_Cols.push(type);
					
					if (type == 0) {
						startID_Rows.push(ints.length);
						for (k = 0; k < totalRows; k++) { ints.push(b.readShort()); }
					} else if (type == 1) {
						startID_Rows.push(strings.length);
						for (k = 0; k < totalRows; k++) { strings.push(BinaryLoader.GetString(b)); }
					} else if (type == 2) {
						startID_Rows.push(floats.length);
						for (k = 0; k < totalRows; k++) { floats.push(b.readFloat()); }
					} else {
						throw new Error("Unexpected type!");
					}
				}
			}
		}
		
		public function GetIntegerFromCell(dbID:int, columnID:int, rowID:int):int {
			var dbStartIndex:int = startID_DB[dbID];
			var rwStartIndex:int = startID_Rows[dbStartIndex + columnID];
			
			return ints[rwStartIndex + rowID];
		}
		
		public function GetStringFromCell(dbID:int, columnID:int, rowID:int):String {
			var dbStartIndex:int = startID_DB[dbID];
			var rwStartIndex:int = startID_Rows[dbStartIndex + columnID];
			
			return strings[rwStartIndex + rowID];
		}
		
		public function GetFloatFromCell(dbID:int, columnID:int, rowID:int):Number {
			var dbStartIndex:int = startID_DB[dbID];
			var rwStartIndex:int = startID_Rows[dbStartIndex + columnID];
			
			return floats[rwStartIndex + rowID];
		}
		
		public function GetCellAsString(dbID:int, columnID:int, rowID:int):String {
			var dbStartIndex:int = startID_DB[dbID];
			var rwStartIndex:int = startID_Rows[dbStartIndex + columnID];
			var type:int = typeID_Cols[dbStartIndex + columnID];
			
			if (type == 0) {
				return ""+ints[rwStartIndex + rowID];
			} else if (type == 1) {
				return ""+strings[rwStartIndex + rowID];
			} else if (type == 2) {
				return ""+floats[rwStartIndex + rowID];
			}
			
			return "{ERROR}";
		}
		
	}

}