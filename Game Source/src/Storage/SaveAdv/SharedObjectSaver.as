package Storage.SaveAdv {
	import flash.display.ShaderData;
	import flash.events.NetStatusEvent;
	import flash.net.SharedObject;
	import flash.net.SharedObjectFlushStatus;
	import flash.utils.ByteArray;
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
			mySo.data.id = GlobalVariables.DataID;
			
			var f:ByteArray = new ByteArray();
			mySo.data.saveData = f;
			
			f.writeShort(GlobalVariables.Indices.length);
			for (var i:int = 0; i < GlobalVariables.Indices.length; i++) {
				f.writeShort(GlobalVariables.Indices[i]);
				f.writeInt(GlobalVariables.Variables[GlobalVariables.Indices[i]]);
			}
			
			var flushStatus:String = null;
			try {
                flushStatus = mySo.flush(1024);
            } catch (error:Error) {
                Main.I.Log("Error...Could not write SharedObject to disk\n");
            }
		}
		
		public function Load(key:String):void {
			var old:ByteArray = mySo.data.saveData;
			var id:int = mySo.data.id;
			
			var saveData:ByteArray = new ByteArray();
			
			if (id != GlobalVariables.DataID) {
				return;
			}
			
			if (old != null) {
				var totalElements:int = old.readShort();
				for (var i:int = 0; i < totalElements; i++) {
					var index:int = old.readShort();
					var value:int = old.readInt();
					
					if (GlobalVariables.Indices.indexOf(index) > -1) {
						GlobalVariables.Variables[index] = value;
					}
				}
			}
		}
	}
}