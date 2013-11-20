package Storage.SaveAdv 
{
	import flash.display.ShaderData;
	import flash.events.NetStatusEvent;
	import flash.net.SharedObject;
	import flash.net.SharedObjectFlushStatus;
	import Scripting.GlobalVariables;
	import Scripting.Script;
	import Storage.SaveInfo;
	/**
	 * ...
	 * @author Paul
	 */
	public class SharedObjectSaver implements ISaveData {
		private var mySo:SharedObject;
		
		public function SharedObjectSaver() {
			mySo = SharedObject.getLocal("LORgamesPusher");
		}
		
		/* INTERFACE Storage.SaveAdv.ISaveData */
		
		public function Save(key:String):void {
			mySo.data.gvars = GlobalVariables.Variables;
			
			var flushStatus:String = null;
			try {
                flushStatus = mySo.flush(1024);
            } catch (error:Error) {
                trace("Error...Could not write SharedObject to disk\n");
            }
		}
		
		public function Load(key:String):void {
			var old:Vector.<int> = mySo.data.gvars;
			
			if(old != null) {
				for (var i:int = 0; i < old.length; i++) {
					GlobalVariables.Variables[i] = old[i];
				}
			}
		}
	}
}