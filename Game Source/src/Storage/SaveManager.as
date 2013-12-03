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
		
		public static function Initialize():void {
			CONFIG::air {
				I = new AIRDatabaseSaver();
			}
			
			if (!CONFIG::air) {
				I = new SharedObjectSaver();
			}
		}
		
		static public function Load(key:String):void {
			I.Load(key);
		}
		
		static public function Save(key:String):void {
			I.Save(key)
		}
	}
}