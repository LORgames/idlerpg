package Storage.SaveAdv {
	/**
	 * ...
	 * @author Paul
	 */
	public interface ISaveData {
		function Save(key:String):void;
		function Load(key:String):void;
	}
}