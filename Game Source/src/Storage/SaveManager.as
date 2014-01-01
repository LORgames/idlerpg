package Storage {
	import SoundSystem.EffectsPlayer;
	import SoundSystem.MusicPlayer;
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
		private static var _LOADED:Boolean = false;
		
		public static function Initialize():void {
			//CONFIG::air {
			//	I = new AIRDatabaseSaver();
			//}
			//
			//if (!CONFIG::air) {
				I = new SharedObjectSaver();
			//}
		}
		
		static public function Load(key:String):void {
			I.Load(key);
			_LOADED = true;
			
			EffectsPlayer.UpdateVolume();
			MusicPlayer.UpdateVolume();
		}
		
		static public function Save(key:String):void {
			if (!_LOADED) return; //Don't try saving without loading: wipes saves
			I.Save(key);
		}
	}
}