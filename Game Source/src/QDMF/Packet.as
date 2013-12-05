package QDMF {
	import flash.utils.ByteArray;
	import flash.utils.IDataInput;
	/**
	 * ...
	 * @author Paul
	 */
	public class Packet {
		public var bytes:ByteArray;
		public var type:int;
		
		public function Packet(type:int) {
			if(type >= 0 && type <= 256) {
				this.type = type;
				
				bytes = new ByteArray();
				bytes.writeShort(type);
			}
		}
		
		public function WriteString(msg:String):void {
			bytes.writeUTF(msg);
		}
		
		public function ReadString():String {
			return bytes.readUTF();
		}
		
		public static function UnpackFromInput(input:IDataInput):void {
			var expectedLength:int = 0;
			var p:Packet = new Packet(-1);
			
			if(input.bytesAvailable > 1) {
				expectedLength = input.readShort();
				
				if (input.bytesAvailable >= expectedLength) {
					p.bytes = new ByteArray();
					input.readBytes(p.bytes, 0, expectedLength);
				} else {
					throw new Error("Cannot read " + expectedLength + "bytes when only " + input.bytesAvailable + "bytes are available. Silly Networking!");
				}
			}
			
			if(p.bytes != null) {
				p.type = p.bytes.readShort();
				
				PacketController.ProcessPacket(p);
				p.bytes.clear();
				p = null;
			}
		}
	}
}