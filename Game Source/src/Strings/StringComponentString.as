package Strings 
{
	/**
	 * ...
	 * @author Paul
	 */
	public class StringComponentString implements IStringComponent {
		
		private var myStr:String;
		
		public function StringComponentString(str:String) {
			this.myStr = str;
		}
		
		public function RequiresRebuild():Boolean {
			return false;
		}
		
		public function Build():String {
			return myStr;
		}
	}
}