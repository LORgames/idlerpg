package Strings {
	import Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class StringComponentVS implements IStringComponent {
		private var myID:int = 0;
		private var previousValue:String = "";
		
		public function StringComponentVS(id:int) {
			myID = id;
		}
		
		public function Build():String {
			previousValue = GlobalVariables.StringVariables[myID];
			return previousValue.toString();
		}
		
		public function RequiresRebuild():Boolean {
			return (previousValue != GlobalVariables.StringVariables[myID]);
		}
	}
}