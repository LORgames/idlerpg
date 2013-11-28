package Game.Critter {
	import flash.utils.ByteArray;
	import Loaders.BinaryLoader;
	import Scripting.Script;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterBuffInfo {
		
		public var ID:int;
		public var name:String;
		public var iconID:int;
		public var showIcon:Boolean;
		public var isDebuff:Boolean;
		public var duration:Number;
		public var isStackable:Boolean = true;
		
		public var _Script:Script;
		
		public function CritterBuffInfo(b:ByteArray) {
			ID = CritterManager.I.CritterBuffs.length;
			
			name = BinaryLoader.GetString(b);
			iconID = b.readShort();
			
			showIcon = b.readByte() == 1;
			isDebuff = b.readByte() == 1;
			
			duration = b.readFloat();
			
			_Script = Script.ReadScript(b);
		}
	}
}