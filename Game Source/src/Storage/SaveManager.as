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
			CONFIG::air {
				if (Global.IsEditor) {
					I = new EditorSaving();
				} else {
					I = new AIRDatabaseSaver();
				}
			}
			
			if (!CONFIG::air) {
				I = new SharedObjectSaver();
			}
			
			if (Saves.length > 0) {
				CurrentSave = Saves[0];
			}
		}
	}
}