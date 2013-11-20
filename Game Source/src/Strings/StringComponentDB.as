package Strings {
	import Game.Data.DataManager;
	import Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class StringComponentDB implements IStringComponent {
		private var dbID:int = 0;
		
		private var colID:int = 0;
		private var rowID:int = 0;
		
		private var colVR:Boolean = false;
		private var rowVR:Boolean = false;
		
		private var _OC:int = -1;
		private var _OR:int = -1;
		
		public function StringComponentDB(_dbID:int, _colID:String, _rowID:String, padding:int) {
			this.dbID = _dbID;
			
			if (_colID.charAt(0) == 'a') {
				colID = parseInt(_colID.substr(1));
			} else if (_colID.charAt(0) == 'b') {
				colID = parseInt(_colID.substr(1));
				colVR = true;
			} else {
				throw new Error("Unexpected Type!");
			}
			
			if (_rowID.charAt(0) == 'a') {
				rowID = parseInt(_rowID.substr(1));
			} else if (_rowID.charAt(0) == 'b') {
				rowID = parseInt(_rowID.substr(1));
				rowVR = true;
			} else {
				throw new Error("Unexpected Type!");
			}
		}
		
		public function Build():String {
			_OC = (colVR?GlobalVariables.Variables[colID]:colID);
			_OR = (rowVR?GlobalVariables.Variables[rowID]:rowID);
			return DataManager.I.GetCellAsString(dbID, _OC, _OR);
		}
		
		public function RequiresRebuild():Boolean {
			return (_OC != (colVR?GlobalVariables.Variables[colID]:colID) || _OR != (rowVR?GlobalVariables.Variables[rowID]:rowID));
		}
	}
}