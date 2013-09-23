package Strings {
	import Game.Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class StringComponentGV implements IStringComponent {
		private var myID:int = 0;
		private var previousAmount:int = 0;
		
		public function StringComponentGV(id:int) {
			myID = id;
		}
		
		public function Build():String {
			previousAmount = GlobalVariables.Variables[myID];
			return previousAmount.toString();
		}
		
		public function RequiresRebuild():Boolean {
			return (previousAmount != GlobalVariables.Variables[myID]);
		}
	}
}