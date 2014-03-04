package QDMF 
{
	import EngineTiming.Clock;
	import Scripting.GlobalVariables;
	/**
	 * ...
	 * @author Paul
	 */
	public class PacketFactory {
		private static var p:Packet = new Packet(PacketTypes.CONTROL);
		
		private static function Send():void {
			if(Clock.isRunning()) {
				Global.Network.SendPacket(p);
			} else {
				Global.Network.SendPacketImmediate(p);
			}
			p.bytes.clear();
			p.bytes.writeShort(PacketTypes.CONTROL);
		}
		
		public static function ChangeMap(id:int):void {
			p.bytes.writeShort(3);
			p.bytes.writeShort(id);
			Send();
		}
		
		static private function Verify():void {
			if (p.bytes.length != 2)
				Global.Out.Log("Uhoh! Bad Packet!");
		}
		
		public static function SyncVariable(type:int, id:int):void {
			if (type != 0xBFFE) return;
			p.bytes.writeShort(4);
			p.bytes.writeShort(id);
			p.bytes.writeInt(GlobalVariables.IntegerVariables[id]);
			Send();
		}
		
		public static function SyncString(id:int):void {
			p.bytes.writeShort(5);
			p.bytes.writeShort(id);
			p.bytes.writeUTF(GlobalVariables.StringVariables[id]);
			Send();
		}
		
		public static function SpawnObject(id:int, x:int, y:int):void {
			p.bytes.writeShort(6);
			p.bytes.writeShort(id);
			p.bytes.writeShort(x);
			p.bytes.writeShort(y);
			Send();
		}
		
		public static function NetTrigger(i:int):void {
			p.bytes.writeShort(7);
			p.bytes.writeShort(i);
			Send();
		}
		
		public static function UpdateSyncStart():void {
			p.bytes.writeShort(8);
			p.bytes.writeShort(0); //Empty for Packet.CONTROL type
			Send();
		}
	}

}