package Strings {
	import Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class StringComponentGV implements IStringComponent {
		private var myID:int = 0;
		private var previousAmount:int = 0;
		
		private var padding:int = 0;
		
		public function StringComponentGV(id:int, padding:int) {
			myID = id;
			this.padding = padding;
		}
		
		public function Build():String {
			previousAmount = GlobalVariables.Variables[myID];
			if(padding == 0) {
				return previousAmount.toString();
			} else {
				return MathsEx.ZeroPad(previousAmount, padding);
			}
		}
		
		public function RequiresRebuild():Boolean {
			return (previousAmount != GlobalVariables.Variables[myID]);
		}
	}
}