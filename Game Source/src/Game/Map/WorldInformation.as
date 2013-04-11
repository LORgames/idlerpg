package Game.Map {
	/**
	 * ...
	 * @author Paul
	 */
	public class WorldInformation {
		public static var I:WorldInformation;
		
		private var LoadedCallback:Function = null;
		
		public function WorldInformation(onReady:Function) {
			I = this;
			
			LoadedCallback = onReady;
			
			Load();
		}
		
		private function Load():void {
			
		}
		
	}

}