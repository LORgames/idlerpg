package Storage.SaveAdv {
	import flash.display.ShaderData;
	import flash.events.NetStatusEvent;
	import flash.net.SharedObject;
	import flash.net.SharedObjectFlushStatus;
	import flash.utils.ByteArray;
	import Scripting.GlobalVariables;
	import Scripting.Script;
	import Storage.SaveInfo;
	import Strings.StringComponentDB;
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
			var i:int;
			
			mySo.data.id = GlobalVariables.DataID;
			
			var f:ByteArray = new ByteArray();
			mySo.data.saveData = f;
			
			f.writeShort(GlobalVariables.IntegerIndices.length);
			for (i = 0; i < GlobalVariables.IntegerIndices.length; i++) {
				f.writeShort(GlobalVariables.IntegerIndices[i]);
				f.writeInt(GlobalVariables.IntegerVariables[GlobalVariables.IntegerIndices[i]]);
			}
			
			f.writeShort(GlobalVariables.StringIndices.length);
			for (i = 0; i < GlobalVariables.StringIndices.length; i++) {
				f.writeShort(GlobalVariables.StringIndices[i]);
				f.writeUTF(GlobalVariables.StringVariables[GlobalVariables.StringIndices[i]]);
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
			
			var i:int;
			var totalElements:int;
			var index:int;
			var valueS:String;
			var valueI:int;
			
			if (old != null) {
				totalElements = old.readShort();
				for (i = 0; i < totalElements; i++) {
					index = old.readShort();
					valueI = old.readInt();
					
					if (GlobalVariables.IntegerIndices.indexOf(index) > -1) {
						GlobalVariables.IntegerVariables[index] = valueI;
					}
				}
				
				if (old.position == old.length) return;
				
				totalElements = old.readShort();
				for (i = 0; i < totalElements; i++) {
					index = old.readShort();
					valueS = old.readUTF();
					
					if (GlobalVariables.StringIndices.indexOf(index) > -1) {
						GlobalVariables.StringVariables[index] = valueS;
					}
				}
			}
		}
	}
}