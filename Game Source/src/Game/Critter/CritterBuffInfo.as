package Game.Critter {
	import flash.utils.ByteArray;
	import Scripting.Script;
	/**
	 * ...
	 * @author Paul
	 */
	public class CritterBuffInfo {
		
		public var name:String;
		public var iconID:int;
		public var showIcon:Boolean;
		public var isDebuff:Boolean;
		public var duration:Number;
		
		public var _Script:Script;
		
		public function CritterBuffInfo(b:ByteArray) {
			
		}
	}
}