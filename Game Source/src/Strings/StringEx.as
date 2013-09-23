package Strings 
{
	import InputSystems.IInputSystem;
	/**
	 * ...
	 * @author Paul
	 */
	public class StringEx {
		private var Prebuilt:String = "";
		private var Components:Vector.<IStringComponent> = new Vector.<IStringComponent>();
		
		public static function BuildFromCore(open:String):StringEx {
			var s:StringEx = new StringEx();
			
			var myPattern:RegExp = /{([0-9]+)}/ig;  
			var result:Object = myPattern.exec(open);
			
			var lastEnd:int = 0;
			
			if (result == null) {
				s.AddComponent(new StringComponentString(open));
			} else {
				while (result != null) {
					if (result.index > lastEnd) {
						s.AddComponent(new StringComponentString(open.substr(lastEnd, result.index - lastEnd)));
					}
					
					s.AddComponent(new StringComponentGV(parseInt(result[1])));
					
					lastEnd = result.index + result[0].length;
					
					result = myPattern.exec(open);
				}
				
				if (lastEnd < open.length) {
					s.AddComponent(new StringComponentString(open.substr(lastEnd)));
				}
			}
			
			return s;
		}
		
		public function StringEx() {
			
		}
		
		public function AddComponent(com:IStringComponent):void {
			Prebuilt += com.Build();
			Components.push(com);
		}
		
		public function GetBuilt():String {
			RebuildIfRequired();
			return Prebuilt;
		}
		
		private function RebuildIfRequired():void {
			var i:int = Components.length;
			var b:Boolean = false;
			
			while (--i > -1) {
				b = b || Components[i].RequiresRebuild();
			}
			
			if (b) {
				i = Components.length;
				Prebuilt = "";
				while (--i > -1) {
					Prebuilt = Components[i].Build() + Prebuilt;
				}
			}
		}
	}
}