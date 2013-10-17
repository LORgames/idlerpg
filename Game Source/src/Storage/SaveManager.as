package Storage {
	import Storage.SaveAdv.EditorSaving;
	import Storage.SaveAdv.AIRDatabaseSaver;
	import Storage.SaveAdv.ISaveData;
	import Storage.SaveAdv.SharedObjectSaver;
	/**
	 * ...
	 * @author Paul
	 */
	public class SaveManager {
		public static var I:ISaveData;
		public static var CurrentSave:SaveInfo;
		
		public static var Saves:Vector.<SaveInfo> = new Vector.<SaveInfo>(); 
		
		public static function Initialize():void {
			//CONFIG::air {
				//if (Global.IsEditor) {
				//	I = new EditorSaving();
				//} else {
				//	I = new AIRDatabaseSaver();
				//}
			//}
			
			//if (!CONFIG::air) {
				I = new SharedObjectSaver();
			//}
			
			//if (Saves.length > 0) {
			//	CurrentSave = Saves[0];
			//}
		}
		
		static public function Load(key:String):void {
			//for (var i:int = Saves.length - 1; i > -1; --i) {
			//	trace("SaveKEY: " + Saves[i].key);
			//	if (Saves[i].key == key) {
			//		CurrentSave = Saves[i];
			//		return;
			//	}
			//}
			
			I.Load(key);
		}
		
		static public function Save(key:String):void {
			I.Save(key)
		}
	}
}