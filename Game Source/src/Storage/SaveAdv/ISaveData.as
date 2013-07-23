package Storage.SaveAdv 
{
	import flash.filesystem.StorageVolumeInfo;
	import Storage.SaveInfo;
	/**
	 * ...
	 * @author Paul
	 */
	public interface ISaveData {
		function Save(key:String):void;
		function Load(key:String):void;
	}

}